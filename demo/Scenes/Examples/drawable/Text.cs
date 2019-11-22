using System.Drawing;

namespace DotFeather.Demo
{
	[DemoScene("/drawable/text")]
	[Description("en", "Draw text on the screen.")]
	[Description("ja", "画面上にテキストを描画します。")]
	public class TextExampleScene : Scene
	{
		public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
		{
			game.Print("Press ESC to return");
		}

		public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
		{
			time += e.DeltaTime;
			if (time > 0.125f)
			{
				var t = new TextDrawable($"Test {count++}", Font.GetDefault(Random.Next(8, 48)), Random.NextColor());
				t.Location = Random.NextVector(game.Width, game.Height) / (int)game.Dpi;
				Root.Add(t);
				time = 0;
			}
			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
		}

		private float time;
		private int count;
	}
}
