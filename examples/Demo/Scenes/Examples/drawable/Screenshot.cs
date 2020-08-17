using System.Collections;
using System.Collections.Generic;
using SixLabors.ImageSharp;

namespace DotFeather.Demo
{
	[DemoScene("/drawable/screenshot")]
	[Description("en", "An example to take a screenshot and use it")]
	[Description("ja", "スクリーンショットを撮影し利用する例")]
	public class ScreenshotExampleScene : Scene
	{
		public override void OnStart(Dictionary<string, object> args)
		{
			Root.Add(g);
			CoroutineRunner.Start(Main());
		}

		public override void OnUpdate()
		{
			if (sprite != null)
			{
				sprite.Location = DFMouse.Position;
				sprite.Scale += Vector.One * (DFMouse.Scroll.Y / 10);
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
			yield return new WaitForSeconds(1);
			yield return DrawAll();

			Print("Taking a screenshot");
			yield return null;
			tex = Window.TakeScreenshot();
			g.Clear();
			Root.Remove(g);

			Print("Generate a sprite from the screenshot");
			yield return new WaitForSeconds(1);

			sprite = new Sprite(tex)
			{
				Scale = Vector.One * 0.25f,
			};
			Root.Add(sprite);

			Print("Press ESC to return");
		}

		IEnumerator DrawAll()
		{
			VectorInt Rnd() => Random.NextVectorInt(Window.Width, Window.Height);

			for (var i = 0; i < 120; i++)
			{
				switch (Random.Next(5))
				{
					case 0:
						g.Line(Rnd(), Rnd(), Random.NextColor());
						break;
					case 1:
						g.Rect(Rnd(), Rnd(), Random.NextColor(), Random.Next(4), Random.NextColor());
						break;
					case 2:
						g.Ellipse(Rnd(), Rnd(), Random.NextColor(), Random.Next(4), Random.NextColor());
						break;
					case 3:
						g.Pixel(Rnd(), Random.NextColor());
						break;
					case 4:
						g.Triangle(Rnd(), Rnd(), Rnd(), Random.NextColor(), Random.Next(4), Random.NextColor());
						break;
				}
				yield return null;
			}
		}

		private readonly Graphic g = new Graphic();
		private Texture2D tex;
		private Sprite? sprite;
	}
}
