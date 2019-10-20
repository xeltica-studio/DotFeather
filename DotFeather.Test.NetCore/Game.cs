using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using SF = SixLabors.Fonts;

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
			red = new ClickableSprite(Texture2D.CreateSolid(Color.FromArgb(0x7fff0000), 256, 256));
			green = new ClickableSprite(Texture2D.CreateSolid(Color.FromArgb(0x7f00ff00), 256, 256));

			var text = new TextDrawable("Ubuntu", new Font("Ubuntu", 120), Color.White);

			red.Location = new Vector(64, 64);
			green.Location = new Vector(192, 192);

			Root.Add(green);
			Root.Add(red);
			Root.Add(text);

			red.Click += (s) => Root.Remove(s);
			green.Click += (s) => Root.Remove(s);
		}

		protected override void OnUpdate(object sender, DFEventArgs e)
		{
			if (DFKeyboard.Escape.IsKeyUp)
				Exit(0);
		}

		ClickableSprite red, green;
	}

	public class ClickableSprite : Sprite, IUpdatable
	{
		public ClickableSprite(Texture2D texture) : base(texture) { }

		public event Action<ClickableSprite> Click;

		public void OnUpdate(GameBase game)
		{
			var (x, y) = (DFMouse.Position.X, DFMouse.Position.Y);

			if (Location.X < x && Location.Y < y && x < Location.X + Width && y < Location.Y + Height && DFMouse.IsLeftUp)
			{
				Click?.Invoke(this);
			}
		}
	}
}
