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
		Texture2D[] catTexture;
		//readonly TextureDrawable catDrawable;

		Vector nekoPos;

		Vector nekoVel;

		int ground;


		public Game(int width, int height, string title = null, int refreshRate = 60) : base(width, height, title, refreshRate)
		{
			this.title = Title;
			g = new GraphicLayer();
			this.Layers.Add(g);
			nekoPos = new Vector(width / 2, height / 2);
			ground = height - 96;
		}

		protected override void OnLoad(object sender, EventArgs e)
		{
			g.Line(0, 0, 320, 240, Color.Red);
			g.Line(320, 0, 0, 240, Color.Blue);
			g.Line(0, 120, 320, 120, Color.Lime);

			g.Rect(400, 320, 432, 352, Color.Cyan);
			catTexture = LoadDividedImage("cat.png", 4, 1, new Size(16, 24));
		}

		protected override void OnUpdate(object sender, DFEventArgs e)
		{
			if (Input.Keyboard.Space.IsPressed)
				Exit(0);

			if (Input.Keyboard.Number1.IsPressed)
			{
				title = "ねこ";
				g.Clear();
				isCatMode = true;
			}
			if (Input.Keyboard.Number2.IsPressed)
				title = "いぬ";
			if (Input.Keyboard.Number3.IsPressed)
				title = "さる";
			if (Input.Keyboard.Number4.IsPressed)
			{
				Width = Random.Next(64, 256);
				Height = Random.Next(64, 256);
			}

			if (isCatMode)
			{
				g.Clear();
				var tex = catTexture[DateTime.Now.Millisecond % 8 < 4 ? 0 : 1];
				nekoVel.X = Input.Keyboard.Left.IsPressed ? -2 : Input.Keyboard.Right.IsPressed ? 2 : 0;

				if (nekoVel.X != 0) 
					tex = catTexture[0];

				nekoVel.Y = (int)(nekoVel.Y + 9.8 * e.DeltaTime);


				if (nekoPos.Y >= ground && nekoVel.Y > 0)
				{
					nekoPos.Y = ground;
					nekoVel.Y = 0;
				}
				nekoPos += nekoVel;

				g.Texture(nekoPos.X, nekoPos.Y, tex);
			}


			Title = $"{Input.Mouse.Position} - {(int)(1 / e.DeltaTime + .5)}fps";
		}
	}
}
