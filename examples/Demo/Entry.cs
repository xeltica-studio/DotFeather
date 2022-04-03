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
			DF.Window.Start += () =>
			{
				DF.Router.ChangeScene<LauncherScene>();
				DF.Window.Mode = WindowMode.Resizable;
			};

			// スクリーンショット撮影機能
			DF.Window.Update += () =>
			{
				if (DFKeyboard.F12.IsKeyDown)
				{

				}
			};
			return DF.Run();
		}
	}
}
