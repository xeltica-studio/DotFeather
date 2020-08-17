using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace DotFeather.Demo
{
	[DemoScene("/sample4")]
	[Description("en", @"Display 10k sprites and measure fps")]
	[Description("ja", @"10000スプライトを表示してFPSを計測します")]
	public class BenchmarkScene : Scene
	{
		public override async void OnStart(Dictionary<string, object> args)
		{
			strawberry = Texture2D.LoadFrom("ichigo.png");
			for (var i = 0; i < sprites.Length; i++)
			{
				Title = $"Creating sprites {(int)((i + 1) / 200f)}%";
				sprites[i] = new Sprite(strawberry)
				{
					Location = rnd.NextVector(Window.Width - 16, Window.Height - 16)
				};
				if (i % 1000 == 0)
					await Task.Delay(1);
			}
			Title = "Adding all sprites to the scene";
			Root.AddRange(sprites);

			initialized = true;
		}

		public override void OnUpdate()
		{
			if (!initialized) return;
			Title = $"{Time.Fps} FPS";

			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}

		public override void OnDestroy()
		{
			strawberry.Dispose();
		}

		private Texture2D strawberry;
		private bool initialized;
		private readonly Sprite[] sprites = new Sprite[10000];
		private readonly Random rnd = new Random();

	}
}
