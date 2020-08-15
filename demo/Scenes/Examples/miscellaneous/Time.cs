namespace DotFeather.Demo
{
	[DemoScene("/miscellaneous/Time")]
	[Description("en", "Display time information")]
	[Description("ja", "時間情報を表示します")]
	public class TimeExampleScene : Scene
	{
		public override void OnUpdate()
		{
			Cls();
			Print($"Time: {Time.Now}");
			Print($"DeltaTime: {Time.DeltaTime}");
			Print($"Fps: {Time.Fps}");
			Print("Press [ESC] to return");

			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}
	}
}
