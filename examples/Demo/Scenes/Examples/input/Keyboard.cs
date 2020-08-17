using System.Linq;

namespace DotFeather.Demo
{
	[DemoScene("/input/keyboard")]
	[Description("en", "Display keyboard states")]
	[Description("ja", "キーボードのステートを表示します")]
	public class KeyboardExampleScene : Scene
	{
		public override void OnStart(System.Collections.Generic.Dictionary<string, object> args)
		{
			// Delete char buffer
			DFKeyboard.GetString();
		}

		public override void OnUpdate()
		{
			Cls();
			Print("Keyboard State");
			Print($@"Pressing: {string.Join(",", DFKeyboard.AllPressedKeys.Select(d => d.ToString()))}");
			Print($@"Pressed: {string.Join(",", DFKeyboard.AllDownKeys.Select(d => d.ToString()))}");
			Print($@"Released: {string.Join(",", DFKeyboard.AllUpKeys.Select(d => d.ToString()))}");
			Print($@"Input Buffer: {buf}");
			Print("Press [ESC] to return");
			buf += DFKeyboard.GetString();

			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}

		private string buf = "";
	}
}
