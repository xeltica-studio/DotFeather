using System;

namespace DotFeather.Test.NetCore
{
	class Game : GameBase
	{

		string title;

		static void Main(string[] args)
		{
			using (var g = new Game(640, 480))
			{
				g.Run();
			}
		}

		public Game(int width, int height, string title = null, int refreshRate = 60) : base(width, height, title, refreshRate)
		{
			this.title = Title;
		}

		protected override void OnUpdate(object sender, DFEventArgs e)
		{
			if (Input.Keyboard.Space.IsPressed)
				Exit(0);

			if (Input.Keyboard.F1.IsPressed)
				title = "ねこ";
			if (Input.Keyboard.F2.IsPressed)
				title = "いぬ";
			if (Input.Keyboard.F3.IsPressed)
				title = "さる";
			if (Input.Keyboard.F4.IsPressed)
			{
				Width = Random.Next(64, 256);
				Height = Random.Next(64, 256);
			}


			Title = $"{title} - {(int)(1 / e.DeltaTime + .5)}fps";
		}
	}
}
