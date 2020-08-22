using System.Collections;
using System.Drawing;
using static DotFeather.ComponentFactory;

namespace DotFeather.Demo
{
	[DemoScene("/drawable/tilemap")]
	[Description("en", "Generate tilemap and scroll")]
	[Description("ja", "タイルマップを作成し動かします")]
	public class TilemapExampleScene : Scene
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
			var tile = Tile.LoadFrom("./ichigo.png");
			var el = Tilemap("map", (16, 16));
			Root.Add(el);
			var map = el.GetComponent<TilemapRenderer>()!;
			if (map.Transform == null) yield break;

			Print("Initialized a tilemap.");
			Print("Put tiles randomly...");
			for (var i = 0; i < 512; i++)
			{
				map.SetTile(
					// Determine the random position
					Random.NextVectorInt(Window.Width / 16, Window.Height / 16),
					tile,
					// Specify tint color with 50% probability
					Random.Next(10) < 5 ? default(Color?) : Random.NextColor()
				);
				if (i % 8 == 0)
					yield return null;
			}
			yield return new WaitForSeconds(0.8f);

			Print("Set map's location to (64, 64)");
			map.Transform.Location = Vector.One * 64;
			yield return new WaitForSeconds(1);

			Print("Set map's scale to (0.5, 0.5)");
			map.Transform.Scale = Vector.One * 0.5f;
			yield return new WaitForSeconds(1);

			map.Clear();
			map.Line(0, 0, Window.Width / 16, Window.Height / 16, tile);
			Print("Drew line.");
			yield return new WaitForSeconds(1);

			map.Clear();
			map.Fill(3, 6, 24, 16, tile);
			Print("Filled.");
			yield return new WaitForSeconds(1);

			Print("Press ESC to return");
		}
	}
}