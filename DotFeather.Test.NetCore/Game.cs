using System;
using System.Drawing;

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

		GraphicLayer g;

		bool isCatMode = false;

		public Game(int width, int height, string title = null, int refreshRate = 60) : base(width, height, title, refreshRate)
		{
			this.title = Title;
			g = new GraphicLayer();
			this.Layers.Add(g);
		}

		protected override void OnLoad(object sender, EventArgs e)
		{
			g.Line(0, 0, 320, 240, Color.Red);
			g.Line(320, 0, 0, 240, Color.Blue);
			g.Line(0, 120, 320, 120, Color.Lime);

			g.Rect(400, 320, 432, 352, Color.Cyan);
		}

		protected override void OnUpdate(object sender, DFEventArgs e)
		{
			if (Input.Keyboard.Space.IsPressed)
				Exit(0);

			if (Input.Keyboard.F1.IsPressed)
			{
				title = "ねこ";
				g.Clear();
				isCatMode = true;
			}
			if (Input.Keyboard.F2.IsPressed)
				title = "いぬ";
			if (Input.Keyboard.F3.IsPressed)
				title = "さる";
			if (Input.Keyboard.F4.IsPressed)
			{
				Width = Random.Next(64, 256);
				Height = Random.Next(64, 256);
			}

			if (isCatMode)
			{

			}


			Title = $"{title} - {(int)(1 / e.DeltaTime + .5)}fps";
		}
	}
}
