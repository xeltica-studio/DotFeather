using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace DotFeather.Demo
{
	[DemoScene("/graphics/container")]
	[Description("en", "Add some elements into the container and control it")]
	[Description("ja", "エレメントをコンテナーにいくつか追加し、制御するサンプル")]
	public class ContainerExampleScene : Scene
	{
		public override void OnStart(Dictionary<string, object> args)
		{
			ichigo = Texture2D.LoadFrom("ichigo.png");
			Root.Add(container);

			var canvas = new Graphic() { Location = (400, 200) };

			var random = new Random(300);

			VectorInt Rnd() => random.NextVectorInt(256, 256);

			Parallel.For(0, 120, (_) =>
			{
				var (v1, v2, v3) = (Rnd(), Rnd(), Rnd());
				switch (random.Next(4))
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
			});

			container.Add(new TextElement("O", 32, DFFontStyle.Normal, Color.White));

			container.Add(canvas);

			Parallel.For(0, 8, (_) =>
			{
				container.Add(new Sprite(ichigo)
				{
					Location = random.NextVector(Window.Width, Window.Height),
					Scale = Vector.One + random.NextVectorFloat() * 7,
					TintColor = random.NextColor(),
				});
			});

			Print("Scroll to move");
			Print("Press ↑ to scale up");
			Print("Press ↓ to scale down");
			Print("Press ESC to return");
		}

		public override void OnUpdate()
		{
			if (DFKeyboard.Up) container.Scale += Vector.One * 0.25f * Time.DeltaTime;
			if (DFKeyboard.Down) container.Scale -= Vector.One * 0.25f * Time.DeltaTime;
			container.Location += DFMouse.Scroll * (-1, 1);
			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}

		public override void OnDestroy()
		{
			ichigo.Dispose();
		}

		private Texture2D ichigo;
		private readonly Container container = new();
	}
}
