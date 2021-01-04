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
		public override void OnStart(Dictionary<string, object> args)
		{
			Print("Via OnStart() method. Frame:" + Window.TotalFrame);
			DF.NextFrame(() =>
			{
				Print("Via NextFrame. Frame:" + Window.TotalFrame);
				DF.NextFrame(() =>
				{
					Print("Via nested NextFrame. Frame:" + Window.TotalFrame);
					Print("Press ESC key to return");
				});
			});
		}

		public override void OnUpdate()
		{
			if (DFKeyboard.Escape.IsKeyUp)
			{
				Router.ChangeScene<LauncherScene>();
			}
		}
	}

}
