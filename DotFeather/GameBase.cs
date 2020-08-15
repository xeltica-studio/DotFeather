using System;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using SixLabors.ImageSharp;
using Color = System.Drawing.Color;
using Size = System.Drawing.Size;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;
using System.Threading;

namespace DotFeather
{
	/// <summary>
	/// DotFeather のメインループおよび、各種メソッドを揃えている、ゲームエントリーポイントの基底クラスです。
	/// </summary>
	public abstract class GameBase : IDisposable
	{
		/// <summary>
		/// Get or set X coordinate of this window.
		/// </summary>
		public int X
		{
			get => window.X;
			set => window.X = value;
		}

		/// <summary>
		/// Get or set Y coordinate of this window.
		/// </summary>
		public int Y
		{
			get => window.Y;
			set => window.Y = value;
		}

		/// <summary>
		/// Get or set whether this window is visible.
		/// </summary>
		public bool Visible
		{
			get => window.Visible;
			set => window.Visible = value;
		}

		/// <summary>
		/// Get or set virtual width of this window.
		/// </summary>
		/// <value>The width.</value>
		public int Width
		{
			get => (int)(window.ClientSize.Width / (FollowsDpi ? Dpi : 1));
			set => window.ClientSize = new Size((int)(value * (FollowsDpi ? Dpi : 1)), window.ClientSize.Height);
		}

		/// <summary>
		/// Get or set virtual height of this window.
		/// </summary>
		/// <value>The height.</value>
		public int Height
		{
			get => (int)(window.ClientSize.Height / (FollowsDpi ? Dpi : 1));
			set => window.ClientSize = new Size(window.ClientSize.Width, (int)(value * (FollowsDpi ? Dpi : 1)));
		}

		/// <summary>
		/// Get or set actual width of this window.
		/// </summary>
		/// <value>The width.</value>
		public int ActualWidth
		{
			get => window.ClientSize.Width;
			set => window.ClientSize = new Size(value, window.ClientSize.Height);
		}

		/// <summary>
		/// Get or set actual height of this window.
		/// </summary>
		/// <value>The height.</value>
		public int ActualHeight
		{
			get => window.ClientSize.Height;
			set => window.ClientSize = new Size(window.ClientSize.Width, value);
		}

		/// <summary>
		/// Get whether this window is focused.
		/// </summary>
		/// <value>The height.</value>
		public bool IsFocused => window.Focused;

		/// <summary>
		/// Get or set background color of this window.
		/// </summary>
		public Color BackgroundColor { get; set; }

		/// <summary>
		/// Get or set refresh rate of this window.
		/// </summary>
		/// <value>The refresh rate.</value>
		public int RefreshRate { get; }

		/// <summary>
		/// Get or set title of this window.
		/// </summary>
		public string Title
		{
			get => window.Title;
			set => window.Title = value;
		}

		/// <summary>
		/// Get or set a top level <see cref="Container"/>  of this window.
		/// </summary>
		public Container Root { get; } = new Container();

		/// <summary>
		/// Get DPI of the current display.
		/// </summary>
		public float Dpi => (float)window.ClientSize.Width / window.Size.Width;

		/// <summary>
		/// Get or set whether the game follows your display's DPI.
		/// If true, the window will be scaled according to your display's DPI.
		/// If you are creating video, this setting won't suitable.
		/// </summary>
		public bool FollowsDpi { get; set; }

		/// <summary>
		/// Get total number of frames since startup.
		/// </summary>
		/// <value></value>
		public long TotalFrame { get; private set; }

		/// <summary>
		/// Get whether the game is in capture mode.
		/// </summary>
		public bool IsCaptureMode { get; private set; }

		/// <summary>
		/// Get or set a text color of the console.
		/// </summary>
		/// <value></value>
		public Color ForegroundColor { get; set; } = Color.White;

		/// <summary>
		/// Get or set a cursor of the console.
		/// </summary>
		public VectorInt ConsoleCursor { get; set; }

		/// <summary>
		/// Get or set a font size of the console.
		/// </summary>
		/// <value></value>
		public int ConsoleSize { get; set; } = 16;

		/// <summary>
		/// Get or set current window mode.
		/// </summary>
		public WindowMode WindowMode
		{
			get
			{
				return window.WindowBorder == WindowBorder.Resizable ? WindowMode.Resizable :
						window.WindowBorder == WindowBorder.Fixed ? WindowMode.Fixed :
						window.WindowBorder == WindowBorder.Hidden ? WindowMode.NoFrame :
						throw new InvalidOperationException("unexpected window state");
			}
			set
			{
				switch (value)
				{
					case WindowMode.Fixed:
						window.WindowBorder = WindowBorder.Fixed;
						break;
					case WindowMode.NoFrame:
						window.WindowBorder = WindowBorder.Hidden;
						break;
					case WindowMode.Resizable:
						window.WindowBorder = WindowBorder.Resizable;
						break;
				}
			}
		}

		/// <summary>
		/// Get or set whether the game is in fullscreen.
		/// </summary>
		public bool IsFullScreen
		{
			get => window.WindowState == WindowState.Fullscreen;
			set => window.WindowState = value ? WindowState.Fullscreen : WindowState.Normal;
		}

		public void Print(object? obj)
		{
			var text = obj as string ?? obj?.ToString() ?? "null";
			var (x, y) = ConsoleCursor;
			x = Math.Max(0, x);
			y = Math.Max(0, y);
			if (y < consoleBuffer.Count)
			{
				// 置換
				consoleBuffer[y] = consoleBuffer[y].ReplaceAt(x, text);
			}
			else
			{
				// 挿入
				consoleBuffer.AddRange(Enumerable.Repeat("", y - consoleBuffer.Count));
				consoleBuffer.Add(new string(' ', x) + text);
			}
			ConsoleCursor = new VectorInt(0, y + 1);
		}

		public void Cls()
		{
			consoleBuffer.Clear();
			ConsoleSize = 16;
			ConsoleCursor = VectorInt.Zero;
		}

		/// <summary>
		/// Initialize a new instance of <see cref="GameBase"/> class with specified parameters.
		/// </summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="title"></param>
		/// <param name="refreshRate"></param>
		/// <param name="isCaptureMode">Set <see langword="true"/> to enable capture mode. When the capture mode is enabled, a captured folder is created in the current directory, and all frame sequential images are automatically created. Although the operation is very slow, it always behaves as if the refresh rate and FPS match. Please use it for the production of video works.にするとキャプチャーモードになります。キャプチャーモードにした場合、カレントディレクトリにcapturedフォルダが生成され、自動的に全フレームの連番画像が生成されます。非常に動作が遅くなりますが、常にリフレッシュレートとFPSが一致している状態として振る舞います。映像作品の制作に用いてください。</param>
		/// <param name="followsDpi">
		/// Whether the game follows your display's DPI.
		/// If true, the window will be scaled according to your display's DPI.
		/// If you are creating video, this setting won't suitable.
		/// </param>
		protected GameBase(int width, int height, string title = "", int refreshRate = 60, bool isCaptureMode = false, bool followsDpi = false)
		{
			ctx = new DFSynchronizationContext();
			SynchronizationContext.SetSynchronizationContext(ctx);

			RefreshRate = refreshRate;
			IsCaptureMode = isCaptureMode;
			FollowsDpi = followsDpi;

			window = new GameWindow(width, height, GraphicsMode.Default, title ?? "DotFeather Window", GameWindowFlags.FixedWindow)
			{
				VSync = VSyncMode.Adaptive,
				TargetRenderFrequency = refreshRate,
				TargetUpdateFrequency = refreshRate,
			};

			if (IsCaptureMode && !Directory.Exists("./shot"))
			{
				Directory.CreateDirectory("shot");
			}

			window.Load += (s, e) =>
			{
				GL.ClearColor(Color.Black);
				GL.LineWidth(1);
				GL.Disable(EnableCap.DepthTest);
				Load?.Invoke(s, e);
				OnLoad(s, e);
			};

			window.Resize += (s, e) =>
			{
				GL.Viewport(window.ClientRectangle);
				Resize?.Invoke(s, e);
				OnResize(s, e);
			};

			window.FileDrop += (s, e) =>
			{
				var a = new DFFileDroppedEventArgs(e.FileName);
				FileDrop?.Invoke(s, a);
				OnFileDrop(s, a);
			};

			window.RenderFrame += OnRenderFrame;

			window.Unload += (s, e) =>
			{
				Unload?.Invoke(s, e);
				OnUnload(s, e);
			};

			window.KeyPress += (s, e) =>
			{
				DFKeyboard.keychars.Enqueue(e.KeyChar);

				KeyPress?.Invoke(s, new DFKeyPressEventArgs(e.KeyChar));

				OnKeyPress(s, new DFKeyPressEventArgs(e.KeyChar));
			};

			window.KeyDown += (s, e) =>
			{
				KeyDown?.Invoke(s, new DFKeyEventArgs(e));

				OnKeyDown(s, new DFKeyEventArgs(e));
			};

			window.KeyUp += (s, e) =>
			{
				KeyUp?.Invoke(s, new DFKeyEventArgs(e));
				OnKeyUp(s, new DFKeyEventArgs(e));
			};

			window.MouseMove += (object sender, OpenTK.Input.MouseMoveEventArgs e) =>
				DFMouse.Position = new VectorInt((int)(e.Position.X / (FollowsDpi ? Dpi : 1)), (int)(e.Position.Y / (FollowsDpi ? Dpi : 1)));

			console = new TextDrawable("", DFFont.GetDefault(ConsoleSize), ForegroundColor);
		}

		/// <summary>
		/// Initializes a random number with the specified seed value.
		/// </summary>
		/// <param name="seed">Seed value. If <c>null</c>, the default constructor of <see cref="System.Random"/> will be called.</param>
		public void Randomize(int? seed = null)
		{
			Random = seed is int s ? new Random(s) : new Random();
		}

		/// <summary>
		/// Run the game.
		/// </summary>
		/// <returns>Status code.</returns>
		public int Run()
		{
			window.Run(RefreshRate);
			return statusCode ?? 0;
		}

		/// <summary>
		/// End the game.
		/// </summary>
		/// <param name="status">Status code.</param>
		public void Exit(int status = 0)
		{
			statusCode = status;
			window.Close();
		}

		/// <summary>
		/// Releases all resource used by the <see cref="T:DotFeather.GameBase"/> object.
		/// </summary>
		/// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="T:DotFeather.GameBase"/>. The
		/// <see cref="Dispose"/> method leaves the <see cref="T:DotFeather.GameBase"/> in an unusable state. After calling
		/// <see cref="Dispose"/>, you must release all references to the <see cref="T:DotFeather.GameBase"/> so the garbage
		/// collector can reclaim the memory that the <see cref="T:DotFeather.GameBase"/> was occupying.</remarks>
		public void Dispose()
		{
			window.Dispose();
		}

		/// <summary>
		/// Take a screenshot of the current screen.
		/// </summary>
		public Image TakeScreenshot()
		{
			if (GraphicsContext.CurrentContext == null)
				throw new GraphicsContextMissingException();

			var arr = new byte[ActualWidth * ActualHeight * 4];

			GL.ReadPixels<byte>(0, 0, ActualWidth, ActualHeight, OpenTK.Graphics.OpenGL.PixelFormat.Rgba, PixelType.UnsignedByte, arr);

			var img = Image.LoadPixelData<Rgba32>(arr, ActualWidth, ActualHeight);

			img.Mutate(i => i.Flip(FlipMode.Vertical));

			return img;
		}

		public void NextFrame(Action task)
		{
			nextFrameQueue.Add(task);
		}

		/// <summary>
		/// Start the coroutine.
		/// </summary>
		public Coroutine StartCoroutine(IEnumerator coroutine) => CoroutineRunner.Start(coroutine);

		/// <summary>
		/// Stop the coroutine.
		/// </summary>
		public void StopCoroutine(Coroutine coroutine) => CoroutineRunner.Stop(coroutine);

		/// <summary>
		/// Called when the game frame is updated. Override this method to write the main loop of the game.
		/// </summary>
		protected virtual void OnUpdate(object sender, DFEventArgs e) { }

		/// <summary>
		/// Called once when the window is opened.
		/// </summary>
		protected virtual void OnLoad(object sender, EventArgs e) { }

		/// <summary>
		/// Called once when the window is closed.
		/// </summary>
		protected virtual void OnUnload(object sender, EventArgs e) { }

		/// <summary>
		/// Called once when the window is closed.
		/// </summary>
		protected virtual void OnFileDrop(object sender, DFFileDroppedEventArgs e) { }

		/// <summary>
		/// Called when the window is resized.
		/// </summary>
		protected virtual void OnResize(object sender, EventArgs e) { }

		/// <summary>
		/// Called when the key pressed.
		/// </summary>
		protected virtual void OnKeyPress(object sender, DFKeyPressEventArgs e) { }

		/// <summary>
		/// Called when the key pressed.
		/// </summary>
		protected virtual void OnKeyDown(object sender, DFKeyEventArgs e) { }

		/// <summary>
		/// Called when the key released.
		/// </summary>
		protected virtual void OnKeyUp(object sender, DFKeyEventArgs e) { }

		/// <summary>
		/// Get a random generator.
		/// </summary>
		protected Random Random { get; private set; } = new Random();

		private void OnRenderFrame(object sender, FrameEventArgs e)
		{
			// 画面の初期化
			GL.ClearColor(BackgroundColor);
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			// キャプチャーモードであれば、デルタタイムは均一に
			var deltaTime = IsCaptureMode ? 1f / RefreshRate : (float)e.Time;
			Time.Now += deltaTime;
			Time.DeltaTime = deltaTime;

			CalculateFps();
			DFKeyboard.Update();
			DFMouse.Update();
			ctx.Update();

			RunNextFrameTasks();

			OnUpdate(sender, new DFEventArgs { DeltaTime = (float)Time.DeltaTime });
			Root.OnUpdate(this);
			CoroutineRunner.Update();

			UpdateConsole();

			// Drawable をレンダリング
			var s = Root.Scale;
			Root.Scale = s * (FollowsDpi ? Dpi : 1);
			Root.Draw(this, Vector.Zero);
			Root.Scale = s;

			console.Draw(this, Vector.Zero);

			window.ProcessEvents();

			if (IsCaptureMode)
			{
				var path = $"./shot/{TotalFrame:00000000}.png";
				if (!File.Exists(path))
				{
					GL.Flush();
					using var bmp = TakeScreenshot();
					using var stream = File.OpenWrite(path);
					bmp.SaveAsPng(stream);
				}
			}
			TotalFrame++;
			window.SwapBuffers();
		}

		private void RunNextFrameTasks()
		{
			if (nextFrameQueue.Count == 0) return;
			nextFrameQueue.ToList().ForEach(task =>
			{
				task();
				nextFrameQueue.Remove(task);
			});
		}

		private void UpdateConsole()
		{
			var f = console.Font;
			if (f.Size != ConsoleSize * Dpi)
				console.Font = DFFont.GetDefault(ConsoleSize * Dpi);

			var maxLine = Height / ConsoleSize;

			var buf = consoleBuffer.Count > maxLine ? consoleBuffer.Skip(consoleBuffer.Count - maxLine) : consoleBuffer;

			console.Color = ForegroundColor;
			console.Text = string.Join('\n', buf);
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

		public event EventHandler<EventArgs>? Load;
		public event EventHandler<EventArgs>? Unload;
		public event EventHandler<DFFileDroppedEventArgs>? FileDrop;
		public event EventHandler<EventArgs>? Resize;
		public event EventHandler<DFKeyEventArgs>? KeyDown;
		public event EventHandler<DFKeyPressEventArgs>? KeyPress;
		public event EventHandler<DFKeyEventArgs>? KeyUp;

		private int? statusCode;
		private int frameCount;
		private int prevSecond;
		private readonly List<string> consoleBuffer = new List<string>();
		private readonly TextDrawable console;
		private readonly GameWindow window;
		private readonly DFSynchronizationContext ctx;
		private readonly List<Action> nextFrameQueue = new List<Action>();
	}
}
