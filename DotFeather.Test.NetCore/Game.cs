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
			var neko = Tile.LoadFrom("neko.png");
			map = new Tilemap(Vector.One * 32);
			map.Fill(0, 0, 16, 16, neko);
			map.Location = new Vector(8, 8);
			Root.Add(text = new TextDrawable("", new Font(FontFamily.GenericSansSerif, 32), Color.White));
			Root.Add(map);
		}

		protected override void OnUpdate(object sender, DFEventArgs e)
		{
			if (Input.Keyboard.Escape.IsKeyUp)
				Exit(0);
			text.Text = Input.Keyboard.Space.IsKeyDown ? "おした" : "おしてない";
			map.Scale = Vector.One * Math.Abs((float)Math.Sin(DFMath.ToRadian((float)Time.Now * 90)) * 2);
        }

        private Tilemap map;
        private TextDrawable text;
    }
}
