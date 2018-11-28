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
			get => window?.Width ?? 0;
			set => window.Width = value;
		}

		public int Height
		{
			get => window?.Height ?? 0;
			set => window.Height = value;
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
