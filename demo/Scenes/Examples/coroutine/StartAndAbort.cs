using System.Collections;

namespace DotFeather.Demo
{
	[DemoScene("/coroutine/start and abort")]
	[Description("en", "Start coroutine and stop after 5 seconds")]
	[Description("ja", "コルーチンを開始し、5秒で停止させます")]
	public class StartAndAbortExampleScene : Scene
	{
		public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
		{
			game.Print("Start and abort Coroutine");

			// Start the coroutine
			// コルーチンを開始
			coroutine = game.StartCoroutine(Coroutine(game));
			game.Print("Started the coroutine!");
		}

		public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
		{
			timeCount += e.DeltaTime;
			if (timeCount > 5 && coroutine!.IsRunning)
			{
				// Stop the coroutine
				// コルーチンを停止
				game.StopCoroutine(coroutine!);
				game.Print("Stopped the coroutine!");
				game.Print("Press [ESC] to return");
			}

			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
		}

		public IEnumerator Coroutine(GameBase game)
		{
			var time = 0;
			// 1秒ずつカウントするだけのコルーチン
			// A coroutine which counts time in second.
			while (true)
			{
				game.Print($"{time}s");
				time++;
				yield return new WaitForSeconds(1);
			}
		}
		private Coroutine? coroutine;

		private float timeCount;
	}

}
