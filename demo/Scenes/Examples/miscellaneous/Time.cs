namespace DotFeather.Demo
{
	[DemoScene("/miscellaneous/Time")]
	[Description("en", "Display time information")]
	[Description("ja", "時間情報を表示します")]
	public class TimeExampleScene : Scene
	{
		public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
		{

		}

		public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
		{
			game.Cls();
			game.Print($"Time: {Time.Now}");
			game.Print($"DeltaTime: {Time.DeltaTime}");
			game.Print($"Fps: {Time.Fps}");
			game.Print("Press [ESC] to return");

			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
		}
	}

}
