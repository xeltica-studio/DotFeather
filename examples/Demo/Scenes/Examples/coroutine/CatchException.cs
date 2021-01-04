using System.Collections;
using System.Collections.Generic;

namespace DotFeather.Demo
{
	[DemoScene("/coroutine/catch exception")]
	[Description("en", "Catch an exception thrown in the coroutine")]
	[Description("ja", "コルーチンで発生した例外をキャッチします")]
	public class CatchExceptionExampleScene : Scene
	{
		public override void OnStart(Dictionary<string, object> args)
		{
			CoroutineRunner.Start(Coroutine())
				.Error(e =>
				{
					// Catch an exception
					// 例外をキャッチ
					Print(e.GetType().Name);
					Print(e.Message);
					Print(e.StackTrace!);
					Print("Press [ESC] to return");
				});
		}

		public override void OnUpdate()
		{
			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}

		IEnumerator Coroutine()
		{
			yield return new WaitForSeconds(0.5f);

			throw new System.Exception("TEST");
		}
	}

}
