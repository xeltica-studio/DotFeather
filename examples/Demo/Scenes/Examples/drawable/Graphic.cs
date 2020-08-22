using System.Collections.Generic;
using System.Linq;

namespace DotFeather.Demo
{
	[DemoScene("/drawable/graphic")]
	[Description("en", "Create graphic screen and draw shapes")]
	[Description("ja", "グラフィック面を作成し図形描画を行います")]
	public class GraphicExampleScene : Scene
	{
		public override void OnStart(Dictionary<string, object> args)
		{
			Print("Left click to draw randomly");
			Print("Press ESC to return");
			Root.Add(canvas);
		}

		public override void OnUpdate()
		{
			if (DFMouse.IsLeftDown)
			{
				VectorInt Rnd() => Random.NextVectorInt(Window.Width, Window.Height);
				var (v1, v2, v3) = (Rnd(), Rnd(), Rnd());
				switch (Random.Next(6))
				{
					case 0:
						DF.Console.Print($"Line from {v1} to {v2}");
						canvas.AddComponent(ShapeRenderer.CreateLine(v1, v2, Random.NextColor()));
						break;
					case 1:
						DF.Console.Print($"Rect from {v1} to {v2}");
						canvas.AddComponent(ShapeRenderer.CreateRect(v1, v2, Random.NextColor(), Random.Next(4), Random.NextColor()));
						break;
					case 2:
						DF.Console.Print($"Ellipse from {v1} to {v2}");
						canvas.AddComponent(ShapeRenderer.CreateEllipse(v1, v2, Random.NextColor(), Random.Next(4), Random.NextColor()));
						break;
					case 3:
						DF.Console.Print($"Pixel at {v1}");
						canvas.AddComponent(ShapeRenderer.CreatePixel(v1, Random.NextColor()));
						break;
					case 4:
						DF.Console.Print($"Triangle of {v1}, {v2} and {v3}");
						canvas.AddComponent(ShapeRenderer.CreateTriangle(v1, v2, v3, Random.NextColor(), Random.Next(4), Random.NextColor()));
						break;
					case 5:
						DF.Console.Print($"Polygon");
						var v = Enumerable.Repeat(5, 15).Select(_ => Rnd()).ToArray();
						canvas.AddComponent(ShapeRenderer.CreatePolygon(Random.NextColor(), Random.Next(4), Random.NextColor(), v));
						break;
				}
			}
			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}

		private readonly Element canvas = new Element("canvas");
	}
}
