using System.Collections.Generic;
using System.Drawing;

namespace DotFeather.Demo
{
	[DemoScene("/sample2")]
	[Description("en", "Simple paint tool")]
	[Description("ja", "簡単なお絵かきツール")]
	public class Sample2ExampleScene : Scene
	{
		public override void OnStart(Dictionary<string, object> args)
		{
			Print("PAINT EXAMPLE");
			Print("Mouse Left: Paint");
			Print("Mouse Right: Clear");
			Print("Keyboard [ESC]: Quit");
			Root.Add(g);
		}

		public override void OnUpdate()
		{
			var mouse = DFMouse.Position;
			if (DFMouse.IsRightDown)
				g.Clear();

			if (DFMouse.IsLeft)
				g.Line(prevMouse, mouse, Color.White);

			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();

			prevMouse = mouse;
		}

		private readonly Graphic g = new Graphic();
		private VectorInt prevMouse;
	}
}
