using System;
using System.Collections;
using System.Drawing;

namespace DotFeather.Demo
{
	[DemoScene("/graphics/tilemap2")]
	[Description("en", "Generate tilemap and scroll")]
	[Description("ja", "タイルマップを作成し動かします")]
	public class Tilemap2ExampleScene : Scene
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
			var map = new Tilemap((16, 16));
			Root.Add(map);

			Print("Put tiles randomly...");
			for (var i = 0; i < 512; i++)
			{
				map.SetTile(
					// Determine the random position
					random.NextVectorInt(Window.Width / 16, Window.Height / 16),
					tile,
					// Specify tint color with 50% probability
					random.Next(10) < 5 ? default(Color?) : random.NextColor()
				);
			}
			yield return new WaitForSeconds(0.8f);

			var dest = 48;
			var speed = 16;

			Print($"Move map's location to (-{dest}, 0)");

			while (map.Location.X > -dest)
			{
				map.Location += Vector.Left * speed * Time.DeltaTime;
				yield return null;
			}

			map.Location = Vector.Zero;

			Print($"Move map's location to ({dest}, 0)");

			while (map.Location.X < dest)
			{
				map.Location += Vector.Right * speed * Time.DeltaTime;
				yield return null;
			}

			map.Location = Vector.Zero;

			Print($"Move map's location to (0, -{dest})");

			while (map.Location.Y > -dest)
			{
				map.Location += Vector.Up * speed * Time.DeltaTime;
				yield return null;
			}

			map.Location = Vector.Zero;

			Print($"Move map's location to (0, {dest})");

			while (map.Location.Y < dest)
			{
				map.Location += Vector.Down * speed * Time.DeltaTime;
				yield return null;
			}

			Print("Press ESC to return");
		}
		private readonly Random random = new Random();
	}
}
