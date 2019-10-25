using System;
using System.Drawing.Imaging;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Collections;
using System.IO;

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
		/// Get or set width of this window.
		/// </summary>
		/// <value>The width.</value>
		public int Width
		{
			get => window.ClientSize.Width;
			set => window.ClientSize = new Size(value, window.Size.Height);
		}

		/// <summary>
		/// Get or set height of this window.
		/// </summary>
		/// <value>The height.</value>
		public int Height
		{
			get => window.ClientSize.Height;
			set => window.ClientSize = new Size(window.Size.Width, value);
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
		/// Get total number of frames since startup.
		/// </summary>
		/// <value></value>
		public long TotalFrame { get; private set; }

		/// <summary>
		/// Get whether the game is in capture mode.
		/// </summary>
		public bool IsCaptureMode { get; private set; }

		/// <summary>
		/// Get or set current window mode.
		/// </summary>
		public WindowMode WindowMode
		{
			get
			{
				return  window.WindowBorder == WindowBorder.Resizable ? WindowMode.Resizable :
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

        /// <summary>
        /// Initialize a new instance of <see cref="GameBase"/> class with specified parameters.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="title"></param>
        /// <param name="refreshRate"></param>
        /// <param name="isCaptureMode">See <see langword="true"/> to enable capture mode. When the capture mode is enabled, a captured folder is created in the current directory, and all frame sequential images are automatically created. Although the operation is very slow, it always behaves as if the refresh rate and FPS match. Please use it for the production of video works.にするとキャプチャーモードになります。キャプチャーモードにした場合、カレントディレクトリにcapturedフォルダが生成され、自動的に全フレームの連番画像が生成されます。非常に動作が遅くなりますが、常にリフレッシュレートとFPSが一致している状態として振る舞います。映像作品の制作に用いてください。</param>
        protected GameBase(int width, int height, string title = "", int refreshRate = 60, bool isCaptureMode = false)
		{
			RefreshRate = refreshRate;
			IsCaptureMode = isCaptureMode;

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

				OnLoad(s, e);
			};

			window.Resize += (s, e) =>
			{
				GL.Viewport(window.ClientRectangle);
				OnResize(s, e);
			};

			window.FileDrop += (s, e) =>
			{

			};

			window.RenderFrame += OnRenderFrame;
			window.Unload += OnUnload;
			window.KeyDown += (s, e) => OnKeyDown(s, new DFKeyEventArgs(e));
			window.KeyUp += (s, e) => OnKeyUp(s, new DFKeyEventArgs(e));

			window.MouseMove += (object sender, OpenTK.Input.MouseMoveEventArgs e) =>
				DFMouse.Position = new VectorInt((int)(e.Position.X / Dpi), (int)(e.Position.Y / Dpi));
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
		public Bitmap TakeScreenshot()
		{
			if (GraphicsContext.CurrentContext == null)
				throw new GraphicsContextMissingException();
			int w = Width;
			int h = Height;
			Bitmap bmp = new Bitmap(w, h);
			System.Drawing.Imaging.BitmapData data =
				bmp.LockBits(new Rectangle(0, 0, w, h), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
			GL.ReadPixels(0, 0, w, h, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, data.Scan0);
			bmp.UnlockBits(data);

			bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
			return bmp;
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
		/// Called when the window is resized.
		/// </summary>
		protected virtual void OnResize(object sender, EventArgs e) { }

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
			GL.ClearColor(BackgroundColor);
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			var deltaTime = IsCaptureMode ? 1f / RefreshRate : (float)e.Time;
			Time.Now += deltaTime;
			Time.DeltaTime = deltaTime;

			CalculateFps();

			Root.Draw(this, Vector.Zero);

			Update(sender);

			window.ProcessEvents();

			if (IsCaptureMode)
			{
				var path = $"./shot/{TotalFrame:00000000}.png";
				if (!File.Exists(path))
				{
					GL.Flush();
					var bmp = TakeScreenshot();
					bmp.Save(path, ImageFormat.Png);
					bmp.Dispose();
				}
				TotalFrame++;
			}
			window.SwapBuffers();
		}

		private void Update(object sender)
		{
			DFKeyboard.Update();
			DFMouse.Update();
			CoroutineRunner.Update();
			Root.OnUpdate(this);
			OnUpdate(sender, new DFEventArgs { DeltaTime = (float)Time.DeltaTime });
		}

		private void CalculateFps()
		{
			frameCount++;
			if (prevSecond != DateTime.Now.Second)
			{
				Time.Fps = frameCount;
				frameCount = 0;
				prevSecond = DateTime.Now.Second;
			}
		}

		private int? statusCode;
		private int frameCount;
		private int prevSecond;
		private readonly GameWindow window;
	}
}
