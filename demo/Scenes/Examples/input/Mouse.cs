namespace DotFeather.Demo
{
	[DemoScene("/input/mouse")]
	[Description("en", "Display mouse states")]
	[Description("ja", "マウスのステートを表示します")]
	public class MouseExampleScene : Scene
	{
		public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
		{

		}

		public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
		{
			game.Cls();
			game.Print("Mouse State");
			game.Print($"Left: {Left()}");
			game.Print($"Middle: {Middle()}");
			game.Print($"Right: {Right()}");
			game.Print($"Scroll: {DFMouse.Scroll}");
			game.Print($"Pos: {DFMouse.Position}");
			game.Print("Press [ESC] to return");

			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
		}

		public string Left()
		{
			return DFMouse.IsLeftDown ? "Pressed" :
					DFMouse.IsLeftUp ? "Released" :
					DFMouse.IsLeft ? "Pressing" : "";
		}

		public string Middle()
		{
			return DFMouse.IsMiddleDown ? "Pressed" :
					DFMouse.IsMiddleUp ? "Released" :
					DFMouse.IsMiddle ? "Pressing" : "";
		}

		public string Right()
		{
			return DFMouse.IsRightDown ? "Pressed" :
					DFMouse.IsRightUp ? "Released" :
					DFMouse.IsRight ? "Pressing" : "";
		}
	}
}
