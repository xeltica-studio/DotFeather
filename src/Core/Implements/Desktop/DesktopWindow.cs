using System;
using SDColor = System.Drawing.Color;
using System.IO;
using SixLabors.ImageSharp;
using Silk.NET.Windowing;
using Silk.NET.Maths;
using Silk.NET.Input;
using Silk.NET.OpenGL;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace DotFeather.Internal
{
	/// <summary>
	/// A implementation of <see cref="IWindow"/> for the desktop environment.
	/// </summary>
	internal sealed class DesktopWindow : IWindow
	{
		public VectorInt Location
		{
			get => (window.Position.X, window.Position.Y);
			set => window.Position = new Vector2D<int>(value.X, value.Y);
		}

		public VectorInt Size
		{
			get => (VectorInt)((Vector)ActualSize / (FollowsDpi ? PixelRatio : 1));
			set
			{
				ActualSize = (VectorInt)((Vector)value * (FollowsDpi ? PixelRatio : 1));
				screenshotBuffer = new byte[ActualWidth * ActualHeight * 4];
			}
		}

		public VectorInt ActualSize
		{
			get => (window.Size.X, window.Size.Y);
			set => window.Size = new Vector2D<int>(value.X, value.Y);
		}

		public int X
		{
			get => Location.X;
			set => Location = (value, Y);
		}

		public int Y
		{
			get => Location.Y;
			set => Location = (X, value);
		}

		public int Width
		{
			get => Size.X;
			set => Size = (value, Height);
		}

		public int Height
		{
			get => Size.Y;
			set => Size = (Width, value);
		}

		public int ActualWidth
		{
			get => ActualSize.X;
			set => ActualSize = (value, ActualHeight);
		}

		public int ActualHeight
		{
			get => ActualSize.Y;
			set => ActualSize = (ActualWidth, value);
		}

		public bool IsVisible
		{
			get => window.IsVisible;
			set => window.IsVisible = value;
		}

		public bool IsFocused
		{
			get
			{
				Debug.NotImpl("DesktopWindow.IsFocused get");
				return true;
			}
		}

		public bool IsFullScreen
		{
			get => window.WindowState == WindowState.Fullscreen;
			set => window.WindowState = value ? WindowState.Fullscreen : WindowState.Normal;
		}

		public string Title
		{
			get => window.Title;
			set => window.Title = value;
		}

		public bool IsCaptureMode { get; private set; }

		public bool FollowsDpi { get; set; } = true;

		public long TotalFrame { get; private set; }

		// todo ゲーム起動前に変更可能にする
		public int RefreshRate => 60;

		public float PixelRatio
		{
			get
			{
				Debug.NotImpl("DesktopWindow.PixelRatio get");
				return 1;
			}
		}

		public SDColor BackgroundColor { get; set; }

		public WindowMode Mode
		{
			get => window.WindowBorder switch
			{
				WindowBorder.Fixed => WindowMode.Fixed,
				WindowBorder.Hidden => WindowMode.NoFrame,
				WindowBorder.Resizable => WindowMode.Resizable,
				_ => throw new InvalidOperationException("unexpected window state"),
			};
			set => window.WindowBorder = value switch
			{
				WindowMode.Fixed => WindowBorder.Fixed,
				WindowMode.NoFrame => WindowBorder.Hidden,
				WindowMode.Resizable => WindowBorder.Resizable,
				_ => throw new ArgumentException(null, nameof(value)),
			};
		}

		internal DesktopWindow()
		{
            var options = WindowOptions.Default;
            options.Size = new Vector2D<int>(640, 480);
            options.Title = "DotFeather Window";
			options.WindowBorder = WindowBorder.Fixed;
            window = Window.Create(options);

			if (IsCaptureMode && !Directory.Exists("./shot"))
			{
				Directory.CreateDirectory("shot");
			}

			window.Load += OnLoad;
			window.Resize += OnResize;
			window.FileDrop += OnFileDrop;
			window.Render += OnRenderFrame;
			window.Update += OnUpdateFrame;
			window.Closing += OnUnload;
		}

		public Texture2D TakeScreenshot()
		{
			return Texture2D.LoadFrom(TakeScreenshotAsImage());
		}

		public void Run()
		{
			window.Run();
		}

		public void Exit()
		{
			window.Close();
		}

		private unsafe Image TakeScreenshotAsImage()
		{
			fixed (byte* buffer = screenshotBuffer)
			{
				DF.GL.ReadPixels(0, 0, (uint)ActualWidth, (uint)ActualHeight, GLEnum.Rgba, GLEnum.UnsignedByte, buffer);
			}
			var img = SixLabors.ImageSharp.Image.LoadPixelData<Rgba32>(screenshotBuffer, ActualWidth, ActualHeight);
			img.Mutate(i => i.Flip(FlipMode.Vertical));
			return img;
		}

		private void OnLoad()
		{
			Debug.FixMe("DesktopWindow.Load");
			var gl = DF.GL = GL.GetApi(window);

			DF.InputContext = window.CreateInput();

			var kb = DF.InputContext.Keyboards[0];

			screenshotBuffer = new byte[ActualWidth * ActualHeight * 4];

			kb.KeyChar += (_, e) =>
			{
				DFKeyboard.keychars.Enqueue(e);
				DFKeyboard.OnKeyPress(new DFKeyPressEventArgs(e));
			};

			kb.KeyDown += (_, e, _) => DFKeyboard.OnKeyDown(new DFKeyEventArgs(e.ToDF(), false, false, false));
			kb.KeyUp += (_, e, _) => DFKeyboard.OnKeyUp(new DFKeyEventArgs(e.ToDF(), false, false, false));

			Start?.Invoke();
		}

		private void OnResize(Vector2D<int> vec)
		{
			DF.GL.Viewport(window.FramebufferSize);

			Resize?.Invoke();
		}

		private void OnFileDrop(string[] files)
		{
			FileDropped?.Invoke(new DFFileDroppedEventArgs(files));
		}

		private void OnRenderFrame(double delta)
		{
			Debug.FixMe("DesktopWindow.OnRenderFrame");
			// 画面の初期化
			DF.GL.ClearColor(BackgroundColor);
			DF.GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			DF.Root.Render();

			Render?.Invoke();

			if (IsCaptureMode)
			{
				var path = $"./shot/{TotalFrame:00000000}.png";
				if (!File.Exists(path))
				{
					Debug.FixMe("DesktopWindow.OnRenderFrame", "Capture");
					DF.GL.Flush();
					using var bmp = TakeScreenshotAsImage();
					using var stream = File.OpenWrite(path);
					bmp.SaveAsPng(stream);
				}
			}
		}

		private void OnUpdateFrame(double delta)
		{
			// キャプチャーモードであれば、デルタタイムは均一に
			var deltaTime = IsCaptureMode ? 1f / RefreshRate : (float)delta;
			Time.Now += deltaTime;
			Time.DeltaTime = deltaTime;

			CalculateFps();
			if (DF.InputContext != null)
			{

				var kb = DF.InputContext.Keyboards[0];
				DFKeyboard.Update(keyCode =>
				{
					var silkKey = keyCode.ToSilk();
					if (silkKey < 0) return;
					var isPressed = kb.IsKeyPressed(silkKey);
					var prevIsPressed = prevState[(int)keyCode];
					var key = DFKeyboard.KeyOf(keyCode);
					key.IsPressed = isPressed;
					key.IsKeyDown = isPressed && !prevIsPressed;
					key.IsKeyUp = !isPressed && prevIsPressed;
					key.ElapsedFrameCount = isPressed ? key.ElapsedFrameCount + 1 : 0;
					key.ElapsedTime = isPressed ? key.ElapsedTime + Time.DeltaTime : 0;
					prevState[(int)keyCode] = isPressed;
				});

				var mouse = DF.InputContext.Mice[0];
				var wheel = mouse.ScrollWheels[0];
				DFMouse.Update(
					mouse.IsButtonPressed(MouseButton.Left),
					mouse.IsButtonPressed(MouseButton.Right),
					mouse.IsButtonPressed(MouseButton.Middle),
					(wheel.X, wheel.Y)
				);
				DFMouse.Position = ((int)mouse.Position.X, (int)mouse.Position.Y);
			}
			PreUpdate?.Invoke();
			Update?.Invoke();

			DF.Root.Update();
			CoroutineRunner.Update();

			PostUpdate?.Invoke();

			TotalFrame++;
		}

		private void OnUnload()
		{
			Destroy?.Invoke();
		}

		private void CalculateFps()
		{
			frameCount++;
			if (Environment.TickCount - prevSecond > 1000)
			{
				Time.Fps = frameCount;
				frameCount = 0;
				prevSecond = Environment.TickCount;
			}
		}

		private readonly Silk.NET.Windowing.IWindow window;

		private int frameCount;
		private int prevSecond;
		private byte[] screenshotBuffer = new byte[0];

		public event Action? Start;
		public event Action? Update;
		public event Action? Render;
		public event Action? Destroy;
		public event Action<DFFileDroppedEventArgs>? FileDropped;
		public event Action? Resize;
		public event Action? PreUpdate;
		public event Action? PostUpdate;

		private static readonly bool[] prevState = new bool[(int)DFKeyCode.LastKey + 1];
	}
}
