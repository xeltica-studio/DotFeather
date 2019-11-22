using System.Collections.Generic;

namespace DotFeather.Demo
{
	[DemoScene("/sample1")]
	[Description("en", @"""Hello, world!""")]
	[Description("ja", @"""Hello, world!""")]
	public class Sample1ExampleScene : Scene
	{
		public override void OnStart(Router router, GameBase game, Dictionary<string, object> args)
		{
			game.Print("Hello, world!");
			game.Print("Press [ESC] to exit");

			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
		}
	}
}
