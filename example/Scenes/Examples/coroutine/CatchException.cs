using System.Collections;
using System.Collections.Generic;

namespace DotFeather.Example
{
    [ExampleScene("/coroutine/catch exception")]
    [Description("en", "Catch an exception thrown in the coroutine")]
    [Description("ja", "コルーチンで発生した例外をキャッチします")]
    public class CatchExceptionExampleScene : Scene
    {
        public override void OnStart(Router router, GameBase game, Dictionary<string, object> args)
        {
			game.StartCoroutine(Coroutine())
				.Error(e => {
					// Catch an exception
					// 例外をキャッチ
					Root.Add(ExampleOS.Text($"{e.GetType().Name}: {e.Message}\n{e.StackTrace}\n\nPress [ESC] to return", 24));
				});
        }

        public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
        {
			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
        }

		IEnumerator Coroutine()
		{
			var a = 4;
			var b = 0;
			yield return new WaitForSeconds(0.5f);

			// 0 除算エラーを引き起こす
			// This causes a division-by-zero exception
			var c = a / b;
		}
    }

}
