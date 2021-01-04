namespace DotFeather.Demo
{
	[DemoScene("/miscellaneous/window mode")]
	[Description("en", "Change window mode")]
	[Description("ja", "ウィンドウのモードを切り替えます")]
	public class WindowModeExampleScene : Scene
	{
		public override void OnStart(System.Collections.Generic.Dictionary<string, object> args)
		{
			Print("Window Mode");
			Print("[1]: No Frame");
			Print("[2]: Resizable");
			Print("[3]: Fixed");
			Print("[4]: Toggle FullScreen");
			Print("[ESC]: Escape");
		}

		public override void OnUpdate()
		{
			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
			else if (DFKeyboard.Number1.IsKeyUp)
				Window.Mode = WindowMode.NoFrame;
			else if (DFKeyboard.Number2.IsKeyUp)
				Window.Mode = WindowMode.Resizable;
			else if (DFKeyboard.Number3.IsKeyUp)
				Window.Mode = WindowMode.Fixed;
			else if (DFKeyboard.Number4.IsKeyUp)
				Window.IsFullScreen ^= true;
		}
	}
}
