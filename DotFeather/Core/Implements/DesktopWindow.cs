using System;
using System.Drawing;
using SDColor = System.Drawing.Color;
using System.IO;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;

namespace DotFeather.Internal
{
	/// <summary>
	/// A implementation of <see cref="IWindow"/> for the desktop environment.
	/// </summary>
	internal sealed class DesktopWindow : IWindow
	{
		public VectorInt Location
		{
			get => new VectorInt(window.Location.X, window.Location.Y);
			set => window.Location = new Point(value.X, value.Y);
		}

		public VectorInt Size
		{
			get => (VectorInt)((Vector)ActualSize / (FollowsDpi ? Dpi : 1));
			set => ActualSize = (VectorInt)((Vector)value * (FollowsDpi ? Dpi : 1));
		}

		public VectorInt ActualSize
		{
			get => new VectorInt(window.ClientSize.Width, window.ClientSize.Height);
			set => window.ClientSize = new Size(value.X, value.Y);
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
			get => window.Visible;
			set => window.Visible = value;
		}

		public bool IsFocused
		{
			get => window.Focused;
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

		public float Dpi => (float)window.ClientSize.Width / window.Size.Width;

		public SDColor BackgroundColor { get; set; }

		public WindowMode Mode
		{
			get => window.WindowBorder switch
			{
				WindowBorder.Resizable => WindowMode.Resizable,
				WindowBorder.Fixed => WindowMode.Fixed,
				WindowBorder.Hidden => WindowMode.NoFrame,
				_ => throw new InvalidOperationException("unexpected window state"),
			};

			set => window.WindowBorder = value switch
			{
				WindowMode.Fixed => WindowBorder.Fixed,
				WindowMode.NoFrame => WindowBorder.Hidden,
				WindowMode.Resizable => WindowBorder.Resizable,
				_ => throw new ArgumentException(),
			};
		}

		internal DesktopWindow()
		{
			window = new GameWindow(640, 480, GraphicsMode.Default, "DotFeather Window", GameWindowFlags.FixedWindow);

			if (IsCaptureMode && !Directory.Exists("./shot"))
			{
				Directory.CreateDirectory("shot");
			}

			window.Load += OnLoad;
			window.Resize += OnResize;
			window.FileDrop += OnFileDrop;
			window.RenderFrame += OnRenderFrame;
			window.UpdateFrame += OnUpdateFrame;
			window.Unload += OnUnload;

			window.KeyPress += (s, e) =>
			{
				DFKeyboard.keychars.Enqueue(e.KeyChar);
				DFKeyboard.OnKeyPress(new DFKeyPressEventArgs(e.KeyChar));
			};

			window.KeyDown += (s, e) => DFKeyboard.OnKeyDown(new DFKeyEventArgs(e));
			window.KeyUp += (s, e) => DFKeyboard.OnKeyUp(new DFKeyEventArgs(e));

			window.MouseMove += (s, e) => DFMouse.Position = new VectorInt((int)(e.Position.X / (FollowsDpi ? Dpi : 1)), (int)(e.Position.Y / (FollowsDpi ? Dpi : 1)));
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
			window.Exit();
		}

		private SixLabors.ImageSharp.Image TakeScreenshotAsImage()
		{
			if (GraphicsContext.CurrentContext == null)
				throw new GraphicsContextMissingException();

			var arr = new byte[ActualWidth * ActualHeight * 4];

			GL.ReadPixels(0, 0, ActualWidth, ActualHeight, PixelFormat.Rgba, PixelType.UnsignedByte, arr);

			var img = SixLabors.ImageSharp.Image.LoadPixelData<Rgba32>(arr, ActualWidth, ActualHeight);

			img.Mutate(i => i.Flip(FlipMode.Vertical));

			return img;
		}

		private void OnLoad(object s, EventArgs e)
		{
			GL.ClearColor(SDColor.Black);
			GL.LineWidth(1);
			GL.Disable(EnableCap.DepthTest);

			Start?.Invoke();
		}

		private void OnResize(object s, EventArgs e)
		{
			GL.Viewport(window.ClientRectangle);

			Resize?.Invoke();
		}

		private void OnFileDrop(object s, FileDropEventArgs e)
		{
			FileDropped?.Invoke(new DFFileDroppedEventArgs(new[] { e.FileName }));
		}

		private void OnRenderFrame(object _, FrameEventArgs e)
		{
			// 画面の初期化
			GL.ClearColor(BackgroundColor);
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			var transform = DF.Root.Transform;
			var scale = transform.Scale;
			transform.Scale = scale * (FollowsDpi ? Dpi : 1);
			DF.Root.Update();
			transform.Scale = scale;

			Render?.Invoke();

			window.ProcessEvents();

			if (IsCaptureMode)
			{
				var path = $"./shot/{TotalFrame:00000000}.png";
				if (!File.Exists(path))
				{
					GL.Flush();
					using var bmp = TakeScreenshotAsImage();
					using var stream = File.OpenWrite(path);
					bmp.SaveAsPng(stream);
				}
			}
			window.SwapBuffers();
		}

		private void OnUpdateFrame(object s, FrameEventArgs e)
		{
			// キャプチャーモードであれば、デルタタイムは均一に
			var deltaTime = IsCaptureMode ? 1f / RefreshRate : (float)e.Time;
			Time.Now += deltaTime;
			Time.DeltaTime = deltaTime;

			CalculateFps();
			DFKeyboard.Update();
			DFMouse.Update();
			PreUpdate?.Invoke();
			Update?.Invoke();

			DF.Root.Update();
			CoroutineRunner.Update();

			PostUpdate?.Invoke();

			TotalFrame++;
		}

		private void OnUnload(object s, EventArgs e)
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

		public event Action? Start;
		public event Action? Update;
		public event Action? Render;
		public event Action? Destroy;
		public event Action<DFFileDroppedEventArgs>? FileDropped;
		public event Action? Resize;
		public event Action? PreUpdate;
		public event Action? PostUpdate;

		private readonly GameWindow window;

		private int frameCount;
		private int prevSecond;
	}
}
