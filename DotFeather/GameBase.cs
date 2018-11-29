using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
//using OpenTK.Graphics.ES20;
using OpenTK.Input;

namespace DotFeather
{
	public abstract class GameBase : IDisposable
	{
		public int Width
		{
			get => window.Size.Width;
			set => window.Size = new Size(value, window.Size.Height);
		}

		public int Height
		{
			get => window.Size.Height;
			set => window.Size = new Size(window.Size.Width, value);
		}

		public int RefreshRate { get; }

		public string Title
		{
			get => window?.Title;
			set => window.Title = value;
		}

		public Input Input { get; } = new Input();

		public List<ILayer> Layers { get; } = new List<ILayer>();


		public void Randomize(int? seed = null)
		{
			Random = seed is int s ? new Random(s) : new Random();
		}

		protected GameBase(int width, int height, string title = null, int refreshRate = 60)
		{
			RefreshRate = refreshRate;

			window = new GameWindow(width, height, GraphicsMode.Default, title ?? "DotFeather Window", GameWindowFlags.FixedWindow);
			window.UpdateFrame += (object sender, FrameEventArgs e) => OnUpdate(this, new DFEventArgs
			{
				DeltaTime = e.Time,
			});

			//window.VSync = VSyncMode.On;

			window.RenderFrame += (object sender, FrameEventArgs e) => 
			{
				GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
				Layers.ForEach(l => l.Draw(this));
				window.SwapBuffers();
			};

			window.Load += (object sender, EventArgs e) => 
			{
				GL.ClearColor(Color.Black);
				GL.LineWidth(1);
				window.VSync = VSyncMode.On;

				GL.Enable(EnableCap.DepthTest);
				window.WindowBorder = WindowBorder.Resizable;
			};

			window.Resize += (object sender, EventArgs e) => 
			{
				GL.Viewport(window.ClientRectangle);
			};
		}

		protected virtual void OnUpdate(object sender, DFEventArgs e)
		{

		}

		public int Run()
		{
			window.Run(RefreshRate);
			return statusCode ?? 0;
		}

		public void Exit(int status = 0)
		{
			statusCode = status;
			window.Close();
		}

		public void Dispose()
		{
			window.Dispose();
		}

		private int? statusCode;
		private readonly GameWindow window;
		protected Random Random { get; private set; } = new Random();
	}
}
