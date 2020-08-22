using System.Collections.Generic;

namespace DotFeather.Demo
{
	[DemoScene("/sample1")]
	[Description("en", @"""Hello, world!""")]
	[Description("ja", @"""Hello, world!""")]
	public class Sample1ExampleScene : Scene
	{
		public override void OnStart(Dictionary<string, object> args)
		{
			Print("Hello, world!");
			Print("Press [ESC] to exit");
		}

		public override void OnUpdate()
		{
			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}
	}
}
