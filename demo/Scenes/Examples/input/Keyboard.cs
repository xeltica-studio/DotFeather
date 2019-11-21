using System.Linq;

namespace DotFeather.Demo
{
	[DemoScene("/input/keyboard")]
	[Description("en", "Display keyboard states")]
	[Description("ja", "キーボードのステートを表示します")]
	public class KeyboardExampleScene : Scene
	{
		public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
		{

		}

		public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
		{
			game.Cls();
			game.Print("Keyboard State");
			game.Print($@"Pressing: {string.Join(",", DFKeyboard.AllPressedKeys.Select(d => d.ToString()))}");
			game.Print($@"Pressed: {string.Join(",", DFKeyboard.AllDownKeys.Select(d => d.ToString()))}");
			game.Print($@"Released: {string.Join(",", DFKeyboard.AllUpKeys.Select(d => d.ToString()))}");
			game.Print("Press [ESC] to return");

			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
		}
	}
}
