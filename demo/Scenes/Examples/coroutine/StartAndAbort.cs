using System.Collections;

namespace DotFeather.Demo
{
	[DemoScene("/coroutine/start and abort")]
	[Description("en", "Start coroutine and stop after 5 seconds")]
	[Description("ja", "コルーチンを開始し、5秒で停止させます")]
	public class StartAndAbortExampleScene : Scene
	{
		public override void OnStart(System.Collections.Generic.Dictionary<string, object> args)
		{
			Print("Start and abort Coroutine");

			// Start the coroutine
			// コルーチンを開始
			coroutine = CoroutineRunner.Start(Coroutine());
			Print("Started the coroutine!");
		}

		public override void OnUpdate()
		{
			timeCount += Time.DeltaTime;
			if (timeCount > 5 && coroutine!.IsRunning)
			{
				// Stop the coroutine
				// コルーチンを停止
				CoroutineRunner.Stop(coroutine!);
				Print("Stopped the coroutine!");
				Print("Press [ESC] to return");
			}

			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}

		public IEnumerator Coroutine()
		{
			var time = 0;
			// 1秒ずつカウントするだけのコルーチン
			// A coroutine which counts time in second.
			while (true)
			{
				Print($"{time}s");
				time++;
				yield return new WaitForSeconds(1);
			}
		}
		private Coroutine? coroutine;

		private float timeCount;
	}

}
