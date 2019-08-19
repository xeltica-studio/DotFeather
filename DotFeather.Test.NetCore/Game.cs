using System;
using System.Collections;
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
			red = new Sprite(Texture2D.CreateSolid(Color.FromArgb(0x7fff0000), 256, 256));
			green = new Sprite(Texture2D.CreateSolid(Color.FromArgb(0x7f00ff00), 256, 256));

			red.Location = new Vector(64, 64);
			green.Location = new Vector(192, 192);

			Root.Add(green);
			Root.Add(red);
		}

		protected override void OnUpdate(object sender, DFEventArgs e)
		{
			if (Input.Keyboard.Escape.IsKeyUp)
				Exit(0);
	}

		Sprite red, green;
    }
}
