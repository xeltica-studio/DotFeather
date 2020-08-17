using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFeather.Demo
{
	[DemoScene("/asynchronous/async-await-pattern")]
	[Description("en", "Run a heavy task to generate texture with await expression")]
	[Description("ja", "await 式を用いてテクスチャを生成する重たいタスクを実行する例")]
	public class AsyncAwaitPatternExampleScene : Scene
	{
		public override async void OnStart(Dictionary<string, object> args)
		{
			var bitmap = new byte[16, 16, 4];
			Print("Generating texture");
			for (var y = 0; y < 16; y++)
			{
				for (var x = 0; x < 16; x++)
				{
					if (cts.IsCancellationRequested)
					{
						break;
					}
					bitmap[x, y, 0] = (byte)(y * 16);
					bitmap[x, y, 1] = (byte)(x * 16);
					bitmap[x, y, 2] = (byte)(x * 16);
					bitmap[x, y, 3] = 255;
					Print($"Generated ({x}, {y})");
					await Task.Delay(15);
				}
			}
			tex = Texture2D.Create(bitmap);
			Root.Add(sp = new Sprite(tex));
			Print("Generated! Press ESC to return");
		}

		public override void OnUpdate()
		{
			if (DFKeyboard.Escape.IsKeyUp)
			{
				cts.Cancel();
				Router.ChangeScene<LauncherScene>();
			}

			if (sp != null)
			{
				sp.Location = DFMouse.Position;
			}
		}

		public override void OnDestroy()
		{
			tex.Dispose();
		}

		readonly CancellationTokenSource cts = new CancellationTokenSource();
		Sprite? sp;
		Texture2D tex;
	}

}
