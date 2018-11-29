using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;

namespace DotFeather
{
	public abstract partial class GameBase
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

		private int? statusCode;

		private readonly GameWindow window;

		protected GameBase(int width, int height, string title = null, int refreshRate = 60)
		{
			RefreshRate = refreshRate;

			window = new GameWindow(width, height, GraphicsMode.Default, title ?? "DotFeather Window", GameWindowFlags.FixedWindow);
			window.UpdateFrame += (object sender, FrameEventArgs e) => OnUpdate(this, new DFEventArgs
			{
				DeltaTime = e.Time,
			});
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
	}
}
