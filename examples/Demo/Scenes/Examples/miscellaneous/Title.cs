using System.Collections;

namespace DotFeather.Demo
{
	[DemoScene("/miscellaneous/window title")]
	[Description("en", "Switch title")]
	[Description("ja", "タイトルを切り替えます")]
	public class TitleExampleScene : Scene
	{
		public override void OnStart(System.Collections.Generic.Dictionary<string, object> args)
		{
			CoroutineRunner.Start(Main());
		}

		public override void OnUpdate()
		{
			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}

		IEnumerator Main()
		{
			yield return SetTitle("Cupcake");
			yield return SetTitle("Donut");
			yield return SetTitle("Eclair");
			yield return SetTitle("Froyo");
			yield return SetTitle("Gingerbread");
			yield return SetTitle("Honeycomb");
			yield return SetTitle("Ice Cream Sandwich");
			yield return SetTitle("Jelly Bean");
			Print("Press [ESC] to return");
		}

		IEnumerator SetTitle(string title)
		{
			yield return new WaitForSeconds(1);
			Title = title;
			Print($"Changed title to '{title}'\n");
		}
	}
}
