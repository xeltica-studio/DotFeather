using System.Collections;
using System.Drawing;

namespace DotFeather.Demo
{
	[DemoScene("/drawable/tilemap2")]
	[Description("en", "Generate tilemap and scroll")]
	[Description("ja", "タイルマップを作成し動かします")]
	public class Tilemap2ExampleScene : Scene
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
			}
			yield return new WaitForSeconds(0.8f);

			var dest = 48;
			var speed = 16;

			game.Print($"Move map's location to (-{dest}, 0)");

			while (map.Location.X > -dest)
			{
				map.Location += Vector.Left * speed * Time.DeltaTime;
				yield return null;
			}

			map.Location = Vector.Zero;

			game.Print($"Move map's location to ({dest}, 0)");

			while (map.Location.X < dest)
			{
				map.Location += Vector.Right * speed * Time.DeltaTime;
				yield return null;
			}

			map.Location = Vector.Zero;

			game.Print($"Move map's location to (0, -{dest})");

			while (map.Location.Y > -dest)
			{
				map.Location += Vector.Up * speed * Time.DeltaTime;
				yield return null;
			}

			map.Location = Vector.Zero;

			game.Print($"Move map's location to (0, {dest})");

			while (map.Location.Y < dest)
			{
				map.Location += Vector.Down * speed * Time.DeltaTime;
				yield return null;
			}

			game.Print("Press ESC to return");
		}
	}
}
