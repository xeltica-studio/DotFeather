using System;
using System.Drawing;

namespace DotFeather.Example
{
    class Game : GameBase
	{

		public Game(int width, int height, string title = null, int refreshRate = 60) : base(width, height, title, refreshRate)
		{
			WindowMode = WindowMode.Resizable;
		}

		protected override void OnLoad(object sender, EventArgs e)
		{
			router = new Router(this);
			router.ChangeScene<LauncherScene>();
		}

		protected override void OnUpdate(object sender, DFEventArgs e)
		{
			router.Update(e);
		}

		private Router router;
	}
}
