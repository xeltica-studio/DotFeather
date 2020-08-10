using System.Drawing;

namespace DotFeather.Demo
{
	[DemoScene("/debug/fix-105")]
	[Description("en", "A debug scene for https://github.com/Xeltica/DotFeather/issues/105")]
	public class Fix105DebugScene : Scene
	{
		public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
		{
			var text = new TextDrawable("test", Font.GetDefault(18, FontStyle.Bold))
			{
				Color = Color.White,
				BorderColor = Color.Yellow,
				BorderThickness = 2,
			};

			// add twice
			Root.Add(text);
			Root.Add(new TextDrawable("NEKO")
			{
				Color = Color.Red,
			});
			Root.Add(text);
		}

		public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
		{
			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
		}

	}
}
