using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static DotFeather.ComponentFactory;

namespace DotFeather.Demo
{
	[DemoScene("/drawable/screenshot")]
	[Description("en", "An example to take a screenshot and use it")]
	[Description("ja", "スクリーンショットを撮影し利用する例")]
	public class ScreenshotExampleScene : Scene
	{
		public override void OnStart(Dictionary<string, object> args)
		{
			Root.Add(canvas);
			CoroutineRunner.Start(Main());
		}

		public override void OnUpdate()
		{
			if (sprite != null)
			{
				sprite.Transform.Location = DFMouse.Position;
				sprite.Transform.Scale += Vector.One * (DFMouse.Scroll.Y / 10);
			}
			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}

		public override void OnDestroy()
		{
			tex.Dispose();
		}

		IEnumerator Main()
		{
			Print("Rendering...");
			yield return DrawAll();

			Print("Taking a screenshot");
			yield return null;
			tex = Window.TakeScreenshot();
			Root.Remove(canvas);

			Print("Generate a sprite from the screenshot");

			sprite = Sprite("ss", tex).With((0, 0), (0.25f, 0.25f));
			Root.Add(sprite);

			Print("Move mouse cursor to move it");
			Print("Rotate mouse wheel to scale it");
			Print("Press ESC to return");
		}

		IEnumerator DrawAll()
		{
			VectorInt Rnd() => Random.NextVectorInt(Window.Width, Window.Height);

			for (var i = 0; i < 120; i++)
			{
				var (v1, v2, v3) = (Rnd(), Rnd(), Rnd());
				switch (Random.Next(6))
				{
					case 0:
						canvas.AddComponent(ShapeRenderer.CreateLine(v1, v2, Random.NextColor()));
						break;
					case 1:
						canvas.AddComponent(ShapeRenderer.CreateRect(v1, v2, Random.NextColor(), Random.Next(4), Random.NextColor()));
						break;
					case 2:
						canvas.AddComponent(ShapeRenderer.CreateEllipse(v1, v2, Random.NextColor(), Random.Next(4), Random.NextColor()));
						break;
					case 3:
						canvas.AddComponent(ShapeRenderer.CreatePixel(v1, Random.NextColor()));
						break;
					case 4:
						canvas.AddComponent(ShapeRenderer.CreateTriangle(v1, v2, v3, Random.NextColor(), Random.Next(4), Random.NextColor()));
						break;
					case 5:
						var v = Enumerable.Repeat(5, 15).Select(_ => Rnd()).ToArray();
						canvas.AddComponent(ShapeRenderer.CreatePolygon(Random.NextColor(), Random.Next(4), Random.NextColor(), v));
						break;
				}
				if (i % 8 == 0)
					yield return null;
			}
		}

		private readonly Element canvas = new Element("canvas");
		private Texture2D tex;
		private Element? sprite;
	}
}
