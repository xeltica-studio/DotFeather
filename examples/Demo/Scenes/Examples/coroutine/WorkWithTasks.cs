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
		public override void OnStart(Dictionary<string, object> args)
		{
			Print("Start Coroutines");
			CoroutineRunner.Start(Coroutine());
		}

		public override void OnUpdate()
		{
			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}

		IEnumerator Coroutine()
		{
			Print("Waiting 5 seconds...");
			yield return Task.Delay(5000);
			Print("Complete! Next, waiting for the ValueTask instance.");
			yield return Work();
			Print("Complete!");
			Print("Press ESC to return");
		}

		async ValueTask Work()
		{
			await Task.Delay(1000);
		}
	}

}
