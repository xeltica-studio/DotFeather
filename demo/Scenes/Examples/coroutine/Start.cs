using System.Collections;
using System.Collections.Generic;

namespace DotFeather.Demo
{
	[DemoScene("/coroutine/start")]
	[Description("en", "Run several coroutines parallelly")]
	[Description("ja", "複数のコルーチンを並行して実行します")]
	public class StartExampleScene : Scene
	{
		public override void OnStart(Router router, GameBase game, Dictionary<string, object> args)
		{
			game.Print("Start Coroutines");
			game.StartCoroutine(Coroutine(1, 0, game));
			game.StartCoroutine(Coroutine(2, 1, game))
				.Then(_ =>
				{
					game.Print("Press [ESC] to return");
				});
		}

		public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
		{
			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
		}

		IEnumerator Coroutine(int id, float delay, GameBase game)
		{
			game.Print($"Start Coroutine {id} after {delay}s!");
			yield return new WaitForSeconds(delay);
			for (var i = 1; i <= 5; i++)
			{
				// Write count number
				game.Print($"{id}: Count {i}");
				// Wait for 0.25s
				yield return new WaitForSeconds(0.5f);
			}
			game.Print($"Coroutine {id} ended!");
		}
	}

}
