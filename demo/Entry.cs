namespace DotFeather.Demo
{
	static class Entry
	{
		static int Main()
		{
			// この行は実際に使うときには無視してください
			// Please ignore this line when you actually use.
			DemoOS.Init();

			// ゲームを初期化して実行します
			// Initialize and run the game
			DotFeather.Router.ChangeScene<LauncherScene>();
			DotFeather.Window.Mode = WindowMode.Resizable;

			return DotFeather.Run();
		}
	}
}
