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
			var head = DemoOS.Text("Start Coroutine", 48);
			head.Location = Vector.One * 16;
			log.Location = new Vector(16, 32 + head.Height);
			Root.Add(head);
			Root.Add(log);

			WriteLog("Start Coroutines");
			game.StartCoroutine(Coroutine(1, 0));
			game.StartCoroutine(Coroutine(2, 1))
				.Then(_ =>
				{
					WriteLog("Press [ESC] to return");
				});
        }

        public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
        {
			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
        }

		IEnumerator Coroutine(int id, float delay)
		{
			WriteLog($"Start Coroutine {id} after {delay}s!");
			yield return new WaitForSeconds(delay);
			for (var i = 1; i <= 5; i++)
			{
				// Write count number
				WriteLog($"{id}: Count {i}");
				// Wait for 0.25s
				yield return new WaitForSeconds(0.5f);
			}
			WriteLog($"Coroutine {id} ended!");
		}

		public void WriteLog(string text) => log.Text += text + "\n";

		TextDrawable log = DemoOS.Text("", 16);
    }

}
