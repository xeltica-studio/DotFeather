using System;
using System.Drawing;

namespace DotFeather.Demo
{
    class Game : GameBase
	{

		public Game(int width, int height, string title = "", int refreshRate = 60) : base(width, height, title, refreshRate)
		{
			WindowMode = WindowMode.Resizable;
			router = new Router(this);
		}

		protected override void OnLoad(object sender, EventArgs e)
		{
			router.ChangeScene<LauncherScene>();
		}

		protected override void OnUpdate(object sender, DFEventArgs e)
		{
			router.Update(e);

			// DPI に合わせる
			// Handle DPI
			Root.Scale = Vector.One * Dpi;
		}

		private Router router;
	}
}
