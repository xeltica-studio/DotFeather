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
			neko = Sprite.LoadFrom("pokeball.png");
			neko.Location = new Vector(64, 64);
			Root.Add(text = new TextDrawable("", new Font(FontFamily.GenericSansSerif, 32), Color.White));
			Root.Add(neko);
		}

		protected override void OnUpdate(object sender, DFEventArgs e)
		{
			if (Input.Keyboard.Escape.IsPressed)
				Exit(0);
			var delta = Time.Now % 10 < 5 ? 1 : 2;
			neko.Scale = Vector.One * delta;
			text.Text = $"{Time.Fps}\n{neko.Scale} {delta} {neko.Texture.Size} {neko.Width} {neko.Height}";
			neko.Location = new Vector(Input.Mouse.Position.X, Input.Mouse.Position.Y);
        }

        private Sprite neko;
        private TextDrawable text;
    }
}
