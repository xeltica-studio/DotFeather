using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using DotFeather.Audio;
using DotFeather.Drawable.Tiles;
using DotFeather.Models;

namespace DotFeather.Test.NetCore
{
    class Game : GameBase
	{
		public Game(int width, int height, string title = null, int refreshRate = 60) : base(width, height, title, refreshRate)
		{
			BackgroundColor = Color.Black;
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
			chars = Texture2D.LoadAndSplitFrom("Char.png", 6, 4, new Size(14, 20));
			var texs = Texture2D.LoadAndSplitFrom("font.png", 16, 17, new Size(8, 8));

			fontTable = fontMap
				.Select((c, i) => (c, i))
				.ToDictionary(kv => kv.c, kv => new Tile(texs[kv.i]));

			map = new Tilemap(new Vector(8, 8));

			Root.Add(map);
			scene = new Container();
			Root.Add(scene);

			var font = new Font("ヒラギノ角ゴ Pro", 10.5f);
			Root.Add(fpsText = new TextDrawable("", font, Color.White));

			sprite = new Container
			{
				Location = new Vector(32, 32)
			};

			var s = spriteChar = new Sprite(chars[0], 0, 0, 0, Vector.One);
			sprite.Add(s);
			sprite.Add(new Sprite(Texture2D.LoadFrom("Shadow.png"), 0, 14));
			sprite.Location = new Vector(Width / 2, Height / 2);

			scene.Add(sprite);

			var graphic = new Graphic()
				.Triangle(0, 128, 128, 128, 128, 0, Color.Brown, 4, Color.Red)
                .Rect(0, 96, 128, 224, Color.Transparent, 1, Color.Lime)
				.Ellipse(128, 0, 400, 100, Color.Black, 8, Color.Red);
			scene.Add(graphic);

			for (int _ = 0; _ < 100; _++)
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

			var pressed1 = Input.Keyboard.Number1.IsPressed;
            var pressed2 = Input.Keyboard.Number2.IsPressed;
            var pressed3 = Input.Keyboard.Number3.IsPressed;
            var pressed4 = Input.Keyboard.Number4.IsPressed;

			if (pressed1 && !prev1)
				player.Play(bgmField, 12250);
            if (pressed2 && !prev2)
                player.Play(bgmBattle, 377853);
            if (pressed3 && !prev3)
                player.Stop();
            if (pressed4 && !prev4)
                player.Pitch = player.Pitch == 1 ? 1.4f : 1;

			prev1 = pressed1;
			prev2 = pressed2;
			prev3 = pressed3;
            prev4 = pressed4;

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

			fpsText.Text = $"{fps}FPS";

			prevIsWalking = isWalking;
		}

        private readonly char[] fontMap = File.ReadAllText("./font.txt").ToCharArray();
        private Dictionary<char, Tile> fontTable;
        private Texture2D[] chars;
        private Texture2D[] field;
        private int charIndex;
        private int animIndex;
        private bool prevIsWalking;
        private bool isWalking;
        private Container sprite;
        private Sprite spriteChar;
        private Tilemap map;
        private Container scene;
        private int prevSecond, fps, f;
        private double time;
		private AudioPlayer player = new AudioPlayer();
		private bool prev1, prev2, prev3, prev4;
        private IAudioSource bgmField = new WaveAudioSource("field.wav");
        private IAudioSource bgmBattle = new VorbisAudioSource("Battle.ogg");
        private IAudioSource drum3 = new WaveAudioSource("drum03.wav");
        private TextDrawable fpsText;
    }
}
