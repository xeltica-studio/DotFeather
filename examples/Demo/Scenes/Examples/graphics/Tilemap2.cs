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
			DF.Window.Mode = WindowMode.Resizable;

			var tile = Tile.LoadFrom("./ichigo.png");
			map = new Tilemap((16, 16));
			var g = new Graphic();
			g.Line((-128, 0), (127, 0), Color.Red);
			g.Line((0, -128), (0, 127), Color.Blue);
			Root.Add(map);
			Root.Add(g);

			for (var i = 0; i < 32768; i++)
			{
				map.SetTile(
					// Determine the random position
					random.NextVectorInt(Window.Width * 8 / 16, Window.Height * 8 / 16) - Window.Size / 4 / 16,
					tile,
					// Specify tint color with 50% probability
					random.Next(10) < 5 ? default(Color?) : random.NextColor()
				);
			}

			map.RenderingMode = TilemapRenderingMode.Scan;
		}

		public override void OnUpdate()
		{
			Cls();
			if (hudVisible)
			{
				Print("[W] Key: Scroll Up");
				Print("[A] Key: Scroll Left");
				Print("[S] Key: Scroll Right");
				Print("[D] Key: Scroll Down");
				Print("[Z] Key: Zoom In");
				Print("[X] Key: Zoom Out");
				Print("[H] Key: Hide HUD");
				Print("[R] Key: Toggle Rendering Mode");
				Print("[ESC] Key: Return");
				Print("... You can also use mouse wheel to scroll the map");
				Print("");
				Print("Window Size: " + DF.Window.Size);
				Print("Rendering Mode: " + map.RenderingMode);
				Print("Preffered Mode: " + map.PreferredRenderingMode);
			}

			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();

			Root.Location += DFMouse.Scroll * (-1, 1) * 2;

			Title = Time.Fps + "FPS";

			if (DFKeyboard.W) Root.Location += Vector.Up;
			if (DFKeyboard.A) Root.Location += Vector.Left;
			if (DFKeyboard.S) Root.Location += Vector.Down;
			if (DFKeyboard.D) Root.Location += Vector.Right;
			if (DFKeyboard.H.IsKeyDown) hudVisible = !hudVisible;
			if (DFKeyboard.R.IsKeyDown)
				map.RenderingMode = map.RenderingMode switch
				{
					TilemapRenderingMode.Auto => TilemapRenderingMode.RenderAll,
					TilemapRenderingMode.RenderAll => TilemapRenderingMode.Scan,
					TilemapRenderingMode.Scan => TilemapRenderingMode.Auto,
					_ => throw new InvalidOperationException(),
				};
			if (DFKeyboard.Z.IsKeyDown) Root.Scale *= 2.0f;
			if (DFKeyboard.X.IsKeyDown) Root.Scale *= 0.5f;
		}

		private readonly Random random = new Random();
		private Tilemap map;
		private bool hudVisible = true;
	}
}
