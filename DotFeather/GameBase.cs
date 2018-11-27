using System;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;

namespace DotFeather
{
	public abstract partial class GameBase
	{
		public int Width { get; }
		public int Height { get;}

		public int RefreshRate { get; }

		public string Title { get; }

		private int? statusCode;

		private readonly GameWindow window;

		protected GameBase(int width, int height, string title = null, int refreshRate = 60)
		{
			Width = width;
			Height = height;
			RefreshRate = refreshRate;

			window = new GameWindow(width, height, GraphicsMode.Default, title ?? "DotFeather Window", GameWindowFlags.FixedWindow);
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
	}
}
