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
			g = new Graphic();
			for (int i = 0; i < 4; i++)
			{
				RandomDraw();
			}
			Root.Add(g);
		}

		protected override void OnUpdate(object sender, DFEventArgs e)
		{
			if (Input.Keyboard.Escape.IsKeyUp)
				Exit(0);
			text.Text = Input.Keyboard.Space.IsKeyDown ? "おした" : "おしてない";
			g.Scale = Vector.One * Math.Abs((float)Math.Sin(DFMath.ToRadian((float)Time.Now * 90)) * 2);
			if (Input.Keyboard.Space.IsKeyDown)
				RandomDraw();
        }

		private void RandomDraw()
		{
			switch (Random.Next(5))
			{
				case 0:
					g.Pixel(Random.Next(0, 400), Random.Next(0, 400), Random.NextColor());
					break;
                case 1:
                    g.Line(Random.Next(0, 400), Random.Next(0, 400), Random.Next(0, 400), Random.Next(0, 400), Random.NextColor());
                    break;
                case 2:
					g.Rect(Random.Next(0, 400), Random.Next(0, 400), Random.Next(0, 400), Random.Next(0, 400), Random.NextColor(), Random.Next(5), Random.NextColor());
                    break;
                case 3:
                    g.Ellipse(Random.Next(0, 400), Random.Next(0, 400), Random.Next(0, 400), Random.Next(0, 400), Random.NextColor(), Random.Next(5), Random.NextColor());
                    break;
                case 4:
                    g.Triangle(Random.Next(0, 400), Random.Next(0, 400), Random.Next(0, 400), Random.Next(0, 400), Random.Next(0, 400), Random.Next(0, 400), Random.NextColor(), Random.Next(5), Random.NextColor());
                    break;
			}
		}

        private TextDrawable text;
		private Graphic g;
    }
}
