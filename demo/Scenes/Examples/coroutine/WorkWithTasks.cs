using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotFeather.Demo
{
	[DemoScene("/coroutine/work with tasks")]
	[Description("en", "Await tasks in the coroutine.")]
	[Description("ja", "コルーチン内でタスクを待機します。")]
	public class WorkWithTasks : Scene
	{
		public override void OnStart(Router router, GameBase game, Dictionary<string, object> args)
		{
			game.Print("Start Coroutines");
			game.StartCoroutine(Coroutine(game));
		}

		public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
		{
			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
		}

		IEnumerator Coroutine(GameBase game)
		{
			game.Print("Waiting 5 seconds...");
			yield return Task.Delay(5000);
			game.Print("Complete! Next, waiting for the ValueTask instance.");
			yield return Work();
			game.Print("Complete!");
			game.Print("Press ESC to return");
		}

		async ValueTask Work()
		{
			await Task.Delay(1000);
		}
	}

}
