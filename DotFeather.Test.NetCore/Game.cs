using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using DotFeather.Drawable.Tiles;
using DotFeather.Models;

namespace DotFeather.Test.NetCore
{
	class Game : GameBase
	{
		readonly char[] fontMap = File.ReadAllText("./font.txt").ToCharArray();
		Dictionary<char, Tile> fontTable;
		Texture2D[] chars;
		Texture2D[] field;

		int charIndex;
		int animIndex;

		bool prevIsWalking;
		bool isWalking;

		Container sprite;
		Sprite spriteChar;

		Tilemap map;

		Container scene;

		int prevSecond, fps, f;

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
			BackgroundColor = Color.White;
		}

		public void DrawString(int x, int y, string text, Color? color = null)
		{
			var _x = x;
			var _y = y;
			text = text.Replace("\r\n", "\n").Replace('\r', '\n');
			foreach (var c in text)
			{
				if (c == '\n')
				{
					_y++;
					_x = x;
					continue;
				}
				map.SetTile(_x, _y, fontTable[fontTable.ContainsKey(c) ? c : '?'], color);
				_x++;
			}
		}

		protected override void OnLoad(object sender, EventArgs e)
		{
			chars = LoadDividedImage("Char.png", 6, 4, new Size(14, 20));
			var texs = LoadDividedImage("font.png", 16, 17, new Size(8, 8));

			fontTable = fontMap
				.Select((c, i) => (c, i))
				.ToDictionary(kv => kv.c, kv => new Tile(texs[kv.i]));

			map = new Tilemap(new Vector(8, 8));

			Root.Add(map);
			scene = new Container();
			Root.Add(scene);

			DrawString(1, 1, @"DotFeatherへ ようこそ!

DotFeatherは 2Dゲームを かんたんにつくれる
C#の ための ゲームエンジンです!

Sprite Tilemap などの べんりきのうが
さいしょから つかえるので
めんどうな コードを かかずに
あなたの さくひんを つくれます!

それでは DotFeatherで
あなただけの めいさくを つくりましょう!", Color.Black);

			sprite = new Container
			{
				Location = new Vector(32, 32)
			};

			var s = spriteChar = new Sprite(chars[0], 0, 0, 0, Vector.One);
			sprite.Add(s);
			sprite.Add(new Sprite(LoadImage("Shadow.png"), 0, 14));
			sprite.Location = new Vector(Width / 2, Height / 2);

			scene.Add(sprite);
			for (int _ = 0; _ < 10000; _++)
			{
				var sp = new Sprite(chars[0], Random.Next(-Width, Width * 2), Random.Next(-Height, Height * 2));
				scene.Add(sp);
			}
		}

		protected override void OnUpdate(object sender, DFEventArgs e)
		{
			if (Input.Keyboard.Escape.IsPressed)
				Exit(0);

			var sec = DateTime.Now.Second;

			var x = Input.Keyboard.Left.IsPressed ? -1 : Input.Keyboard.Right.IsPressed ? 1 : 0;
			var y = Input.Keyboard.Up.IsPressed ? -1 : Input.Keyboard.Down.IsPressed ? 1 : 0;

			if (x != 0 || y != 0)
			{
				charIndex = y == +1 ? (x == -1 ? 1 : x == +1 ? 3 : 0) :
							y == -1 ? (x == -1 ? 5 : x == +1 ? 7 : 6) :
									  (x == -1 ? 2 : x == +1 ? 4 : charIndex);
				charIndex *= 3;
				var shift = Input.Keyboard.LShift.IsPressed;
				sprite.Location += new Vector(x, y) * (shift ? 4 : 2);
				scene.Location -= new Vector(x, y) * (shift ? 4 : 2);
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

			if (sec != prevSecond)
			{
				fps = f;
				f = 0;
				prevSecond = sec;
			}

			f++;

			spriteChar.Texture = chars[charIndex + (animIndex == 3 ? 1 : animIndex)];

			Title = $"DotFeather Window {fps}fps";

			prevIsWalking = isWalking;
		}
	}
}
