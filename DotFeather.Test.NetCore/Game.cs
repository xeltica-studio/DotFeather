using System;
using System.Drawing;
using DotFeather.Drawable;
using DotFeather.InputSystems;
using DotFeather.Models;

namespace DotFeather.Test.NetCore
{
	class Game : GameBase
	{
		Texture2D[] chars;
		Texture2D[] field;

		int charIndex;
		int animIndex;

		bool prevIsWalking;
		bool isWalking;

		Container sprite;
		Sprite spriteChar;

		double time;

		static void Main(string[] args)
		{
			using (var g = new Game(320, 240))
			{
				g.Run();
			}
		}


		public Game(int width, int height, string title = null, int refreshRate = 60) : base(width, height, title, refreshRate)
		{

		}

		protected override void OnLoad(object sender, EventArgs e)
		{
			chars = LoadDividedImage("Char.png", 6, 4, new Size(14, 20));
			//field = LoadDividedImage("Field.png", 1, 5, new Size(16, 16));

			sprite = new Container
			{
				Location = new Vector(32, 32)
			};

			var s = spriteChar = new Sprite(chars[0], 0, 0, 0, Vector.One);
			sprite.Children.Add(new Sprite(LoadImage("Shadow.png"), 0, 14));
			sprite.Children.Add(s);

			s.ZOrder = -1;
			Children.Add(sprite);
		}

		protected override void OnUpdate(object sender, DFEventArgs e)
		{
			if (Input.Keyboard.Escape.IsPressed)
				Exit(0);

			var x = Input.Keyboard.Left.IsPressed ? -1 : Input.Keyboard.Right.IsPressed ? 1 : 0;
			var y = Input.Keyboard.Up.IsPressed ? -1 : Input.Keyboard.Down.IsPressed ? 1 : 0;

			if (x != 0 || y != 0)
			{
				charIndex = y == +1 ? (x == -1 ? 1 : x == +1 ? 3 : 0) :
							y == -1 ? (x == -1 ? 5 : x == +1 ? 7 : 6) :
									  (x == -1 ? 2 : x == +1 ? 4 : charIndex);
				charIndex *= 3;
				sprite.Location += new Vector(x, y) * 2;
				time += e.DeltaTime;
				isWalking = true;
			}
			else
			{
				animIndex = 1;
				time = 0;
				isWalking = false;
			}

			if (time > 0.08f)
			{
				animIndex++;
				if (animIndex > 3)
					animIndex = 0;

				time = 0;
			}
			spriteChar.Texture = chars[charIndex + (animIndex == 3 ? 1 : animIndex)];

			prevIsWalking = isWalking;
		}
	}
}
