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
			BackgroundColor = Color.Green;
		}

		protected override void OnLoad(object sender, EventArgs e)
		{
			Root.Add(text = new TextDrawable("", new Font(FontFamily.GenericSansSerif, 32), Color.White));
			for (int i = 0; i < 100; i++)
			{
				var s = Sprite.LoadFrom("neko.png");
				s.Location = new Vector(Random.Next(512), Random.Next(512));
				s.Scale = new Vector((float)Random.NextDouble() * 2 + 0.25f, (float)Random.NextDouble() * 2 + 0.25f);
				Root.Add(s);
			}
		}

		protected override void OnUpdate(object sender, DFEventArgs e)
		{
			if (Input.Keyboard.Escape.IsKeyUp)
				Exit(0);
			text.Text = Input.Keyboard.Space.IsKeyDown ? "おした" : "おしてない";
			Root.Scale = Vector.One * Math.Abs((float)Math.Sin(DFMath.ToRadian((float)Time.Now * 90)) * 2);
        }

        private TextDrawable text;
    }
}
