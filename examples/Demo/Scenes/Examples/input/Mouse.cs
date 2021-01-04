namespace DotFeather.Demo
{
	[DemoScene("/input/mouse")]
	[Description("en", "Display mouse states")]
	[Description("ja", "マウスのステートを表示します")]
	public class MouseExampleScene : Scene
	{
		public override void OnUpdate()
		{
			Cls();
			Print("Mouse State");
			Print($"Left: {Left()}");
			Print($"Middle: {Middle()}");
			Print($"Right: {Right()}");
			Print($"Scroll: {DFMouse.Scroll}");
			Print($"Pos: {DFMouse.Position}");
			Print("Press [ESC] to return");

			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
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
