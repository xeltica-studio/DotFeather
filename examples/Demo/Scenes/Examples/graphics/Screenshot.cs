using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DotFeather.Demo
{
	[DemoScene("/graphics/screenshot")]
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
			yield return DrawAll();

			Print("Taking a screenshot");
			yield return null;
			tex = Window.TakeScreenshot();
			Root.Remove(canvas);

			Print("Generate a sprite from the screenshot");

			sprite = new Sprite(tex)
			{
				Location = (0, 0),
				Scale = (0.25f, 0.25f)
			};
			Root.Add(sprite);

			Print("Move mouse cursor to move it");
			Print("Rotate mouse wheel to scale it");
			Print("Press ESC to return");
		}

		IEnumerator DrawAll()
		{
			VectorInt Rnd() => random.NextVectorInt(Window.Width, Window.Height);

			for (var i = 0; i < 120; i++)
			{
				var (v1, v2, v3) = (Rnd(), Rnd(), Rnd());
				switch (random.Next(6))
				{
					case 0:
						canvas.Line(v1, v2, random.NextColor());
						break;
					case 1:
						canvas.Rect(v1, v2, random.NextColor(), random.Next(4), random.NextColor());
						break;
					case 2:
						canvas.Pixel(v1, random.NextColor());
						break;
					case 3:
						canvas.Triangle(v1, v2, v3, random.NextColor(), random.Next(4), random.NextColor());
						break;
				}
				if (i % 8 == 0)
					yield return null;
			}
		}

		private readonly Random random = new();
		private readonly Graphic canvas = new();
		private Texture2D tex;
		private Sprite? sprite;
	}
}
