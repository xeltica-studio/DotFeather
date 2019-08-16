using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;

namespace DotFeather
{
	class Game : GameBase
	{
        public Game(int width, int height, string title = null, int refreshRate = 60) : base(width, height, title, refreshRate)
		{
			BackgroundColor = Color.Black;
		}

		protected override void OnLoad(object sender, EventArgs e)
		{
			var fnt = new Font(new FontFamily("ヒラギノ角ゴ Std"), 40);
			red = new TextDrawable("ちくわぶ\nねこ", fnt, Color.White);
			green = new TextDrawable("かに", fnt, Color.Aquamarine);
			Root.Add(red);
			Root.Add(green);
			red.Location = new Vector(Width / 4 - red.Width / 2, Height / 2 - red.Height / 2);
			green.Location = new Vector(Width / 4 * 3 - green.Width / 2, Height / 2 - green.Height / 2);
		}

		protected override void OnUpdate(object sender, DFEventArgs e)
		{
			if (Input.Keyboard.Escape.IsKeyUp)
				Exit(0);
			
			if (Input.Keyboard.Space.IsKeyDown)
			{
				BackgroundColor = BackgroundColor == Color.Black ? Color.White : Color.Black;
			}
			const int speed = 256;
			if (Input.Keyboard.W)
				red.Location += new Vector(0, -1) * (float)(speed * e.DeltaTime);
			if (Input.Keyboard.A)
				red.Location += new Vector(-1, 0) * (float)(speed * e.DeltaTime);
			if (Input.Keyboard.S)
				red.Location += new Vector(0, 1) * (float)(speed * e.DeltaTime);
			if (Input.Keyboard.D)
				red.Location += new Vector(1, 0) * (float)(speed * e.DeltaTime);

			if (Input.Keyboard.Up)
				green.Location += new Vector(0, -1) * (float)(speed * e.DeltaTime);
			if (Input.Keyboard.Left)
				green.Location += new Vector(-1, 0) * (float)(speed * e.DeltaTime);
			if (Input.Keyboard.Down)
				green.Location += new Vector(0, 1) * (float)(speed * e.DeltaTime);
			if (Input.Keyboard.Right)
				green.Location += new Vector(1, 0) * (float)(speed * e.DeltaTime);

			if (Input.Keyboard.Number1)
				WindowMode = WindowMode.Fixed;

			if (Input.Keyboard.Number2)
				WindowMode = WindowMode.NoFrame;

			if (Input.Keyboard.Number3)
				WindowMode = WindowMode.Resizable;

			if (Input.Keyboard.Number4)
				IsFullScreen = !IsFullScreen;
        }

		private TextureDrawableBase red, green;
    }
}
