using System.Collections;
using System.Collections.Generic;

namespace DotFeather.Demo
{
	[DemoScene("/coroutine/start")]
	[Description("en", "Run several coroutines parallelly")]
	[Description("ja", "複数のコルーチンを並行して実行します")]
	public class StartExampleScene : Scene
	{
		public override void OnStart(Dictionary<string, object> args)
		{
			Print("Start Coroutines");
			CoroutineRunner.Start(Coroutine(1, 0));
			CoroutineRunner.Start(Coroutine(2, 1))
				.Then(_ =>
				{
					Print("Press [ESC] to return");
				});
		}

		public override void OnUpdate()
		{
			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}

		IEnumerator Coroutine(int id, float delay)
		{
			Print($"Start Coroutine {id} after {delay}s!");
			yield return new WaitForSeconds(delay);
			for (var i = 1; i <= 5; i++)
			{
				// Write count number
				Print($"{id}: Count {i}");
				// Wait for 0.25s
				yield return new WaitForSeconds(0.5f);
			}
			Print($"Coroutine {id} ended!");
		}
	}

}
