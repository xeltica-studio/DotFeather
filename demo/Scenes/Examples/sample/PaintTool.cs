using System.Collections.Generic;
using System.Drawing;

namespace DotFeather.Demo
{
	[DemoScene("/sample2")]
	[Description("en", "Simple paint tool")]
	[Description("ja", "簡単なお絵かきツール")]
	public class Sample2ExampleScene : Scene
	{
		public override void OnStart(Router router, GameBase game, Dictionary<string, object> args)
		{
			game.Print("PAINT EXAMPLE");
			game.Print("Mouse Left: Paint");
			game.Print("Mouse Right: Clear");
			game.Print("Keyboard [ESC]: Quit");
			Root.Add(g);
		}

		public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
		{
			var mouse = DFMouse.Position;
			if (DFMouse.IsRightDown)
				g.Clear();

			if (DFMouse.IsLeft)
				g.Line(prevMouse, mouse, Color.White);

			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();

			prevMouse = mouse;
		}

		private readonly Graphic g = new Graphic();
		private VectorInt prevMouse;
	}
}
