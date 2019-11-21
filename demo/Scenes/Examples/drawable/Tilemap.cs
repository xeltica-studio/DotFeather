using System.Collections;
using System.Drawing;

namespace DotFeather.Demo
{
	[DemoScene("/drawable/tilemap")]
	[Description("en", "Generate tilemap and scroll")]
	[Description("ja", "タイルマップを作成しスクロールします")]
	public class TilemapExampleScene : Scene
	{
		public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
		{
			game.StartCoroutine(Main(game));
		}

		public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
		{
			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
		}

		IEnumerator Main(GameBase game)
		{
			var tile = Tile.LoadFrom("./ichigo.png");
			var map = new Tilemap(Vector.One * 16);
			Root.Add(map);
			game.Print("Initialized a tilemap.");
			yield return new WaitForSeconds(1);

			game.Print("Put tiles randomly...");
			for (var i = 0; i < 512; i++)
			{
				map.SetTile(
					// Determine the random position
					Random.NextVectorInt(game.Width / 16, game.Height / 16),
					tile,
					// Specify tint color with 50% probability
					Random.Next(10) < 5 ? default(Color?) : Random.NextColor()
				);
				if (i % 4 == 0)
					yield return null;
			}
			yield return new WaitForSeconds(0.8f);

			game.Print("Set map's location to (64, 64)");
			map.Location = Vector.One * 64;
			yield return new WaitForSeconds(1);

			game.Print("Set map's scale to (0.5, 0.5)");
			map.Scale = Vector.One * 0.5f;
			yield return new WaitForSeconds(1);

			map.Clear();
			map.Line(0, 0, game.Width / 16, game.Height / 16, tile);
			game.Print("Drew line.");
			yield return new WaitForSeconds(1);

			map.Clear();
			map.Fill(3, 6, 24, 16, tile);
			game.Print("Filled.");
			yield return new WaitForSeconds(1);

			game.Print("Press ESC to return");
		}
	}

}
