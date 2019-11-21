using System.Collections;

namespace DotFeather.Demo
{
	[DemoScene("/miscellaneous/window title")]
	[Description("en", "Switch title")]
	[Description("ja", "タイトルを切り替えます")]
	public class TitleExampleScene : Scene
	{
		public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
		{
			CoroutineRunner.Start(Main(game));
		}

		public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
		{
			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
		}

		IEnumerator Main(GameBase game)
		{
			yield return SetTitle("Cupcake", game);
			yield return SetTitle("Donut", game);
			yield return SetTitle("Eclair", game);
			yield return SetTitle("Froyo", game);
			yield return SetTitle("Gingerbread", game);
			yield return SetTitle("Honeycomb", game);
			yield return SetTitle("Ice Cream Sandwich", game);
			yield return SetTitle("Jelly Bean", game);
			game.Print("Press [ESC] to return");
		}

		IEnumerator SetTitle(string title, GameBase game)
		{
			yield return new WaitForSeconds(1);
			Title = title;
			game.Print($"Changed title to '{title}'\n");
		}
	}

}
