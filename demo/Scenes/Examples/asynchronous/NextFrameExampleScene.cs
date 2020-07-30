using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFeather.Demo
{
	[DemoScene("/asynchronous/next-frame")]
	[Description("en", "Run a task at the next frame")]
	[Description("ja", "次のフレームに処理の実行を予約する例")]
	public class NextFrameExampleScene : Scene
	{
		public override void OnStart(Router router, GameBase game, Dictionary<string, object> args)
		{
			game.Print("Via OnStart() method. Frame:" + game.TotalFrame);
			game.NextFrame(() =>
			{
				game.Print("Via NextFrame. Frame:" + game.TotalFrame);
				game.NextFrame(() =>
				{
					game.Print("Via nested NextFrame. Frame:" + game.TotalFrame);
					game.Print("Press ESC key to return");

				});
			});
		}

		public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
		{
			if (DFKeyboard.Escape.IsKeyUp)
			{
				router.ChangeScene<LauncherScene>();
			}
		}
	}

}
