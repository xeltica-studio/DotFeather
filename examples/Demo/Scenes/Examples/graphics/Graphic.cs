using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFeather.Demo
{
	[DemoScene("/graphics/graphic")]
	[Description("en", "Create graphic screen and draw shapes")]
	[Description("ja", "グラフィック面を作成し図形描画を行います")]
	public class GraphicExampleScene : Scene
	{
		public override void OnStart(Dictionary<string, object> args)
		{
			Print("Left click to draw randomly");
			Print("Scroll to move");
			Print("Press ↑ to scale up");
			Print("Press ↓ to scale down");
			Print("Press ESC to return");
			Root.Add(canvas);
		}

		public override void OnUpdate()
		{
			if (DFKeyboard.Up) canvas.Scale += Vector.One * Time.DeltaTime;
			if (DFKeyboard.Down) canvas.Scale -= Vector.One * Time.DeltaTime;
			canvas.Location += DFMouse.Scroll * (-1, 1);
			if (DFMouse.IsLeftDown)
			{
				VectorInt Rnd() => random.NextVectorInt(Window.Width, Window.Height);
				var (v1, v2, v3) = (Rnd(), Rnd(), Rnd());
				switch (random.Next(6))
				{
					case 0:
						DF.Console.Print($"Line from {v1} to {v2}");
						canvas.Line(v1, v2, random.NextColor());
						break;
					case 1:
						DF.Console.Print($"Rect from {v1} to {v2}");
						canvas.Rect(v1, v2, random.NextColor(), random.Next(4), random.NextColor());
						break;
					case 2:
						DF.Console.Print($"Ellipse from {v1} to {v2}");
						canvas.Ellipse(v1, v2, random.NextColor(), random.Next(4), random.NextColor());
						break;
					case 3:
						DF.Console.Print($"Pixel at {v1}");
						canvas.Pixel(v1, random.NextColor());
						break;
					case 4:
						DF.Console.Print($"Triangle of {v1}, {v2} and {v3}");
						canvas.Triangle(v1, v2, v3, random.NextColor(), random.Next(4), random.NextColor());
						break;
					case 5:
						DF.Console.Print($"Polygon");
						var v = Enumerable.Repeat(5, 15).Select(_ => Rnd()).ToArray();
						canvas.Polygon(random.NextColor(), random.Next(4), random.NextColor(), v);
						break;
				}
			}
			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}

		private readonly Graphic canvas = new Graphic();
		private readonly Random random = new Random();
	}
}
