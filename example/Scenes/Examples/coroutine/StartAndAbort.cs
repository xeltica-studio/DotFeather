using System.Collections;

namespace DotFeather.Example
{
    [ExampleScene("/coroutine/start and abort")]
    [Description("en", "Start coroutine and stop after 5 seconds")]
    [Description("ja", "コルーチンを開始し、5秒で停止させます")]
    public class StartAndAbortExampleScene : Scene
    {
        public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
        {
			var head = ExampleOS.Text("Start and abort Coroutine", 48);
			head.Location = Vector.One * 16;
			log.Location = new Vector(16, 32 + head.Height);
			Root.Add(head);
			Root.Add(log);

			// Start the coroutine
			// コルーチンを開始
			coroutine = game.StartCoroutine(Coroutine());
			WriteLog("Started the coroutine!");
        }

        public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
        {
			timeCount += e.DeltaTime;
			if (timeCount > 5 && coroutine!.IsRunning)
			{
				// Stop the coroutine
				// コルーチンを停止
				game.StopCoroutine(coroutine!);
				WriteLog("Stopped the coroutine!");
				WriteLog("Press [ESC] to return");
			}

			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
        }

		public IEnumerator Coroutine()
		{
			var time = 0;
			// 1秒ずつカウントするだけのコルーチン
			// A coroutine which counts time in second.
			while (true)
			{
				WriteLog($"{time}s");
				time++;
				yield return new WaitForSeconds(1);
			}
		}


		public void WriteLog(string text) => log.Text += text + "\n";

		TextDrawable log = ExampleOS.Text("", 16);

		private Coroutine? coroutine;

		private float timeCount;
    }

}
