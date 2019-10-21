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

			var text = new TextDrawable("いろはにほへと", new Font("./font.ttf", 120), Color.White);

			frame = new Container
			{
				Location = new Vector(32, 32),
				Width = 256, 
				Height = 256,
				IsTrimmable = true,
			};

			var g = new Graphic();
			g.Rect(32, 32, 288, 288, Color.Transparent, 2, Color.Blue);

			red.Location = new Vector(0, 0);
			green.Location = new Vector(96, 96);

			frame.Add(green);
			frame.Add(red);
			Root.Add(text);
			Root.Add(frame);
			Root.Add(g);

			red.Click += (s) => Root.Remove(s);
			green.Click += (s) => Root.Remove(s);
		}

		protected override void OnUpdate(object sender, DFEventArgs e)
		{
			if (DFKeyboard.Escape.IsKeyUp)
				Exit(0);

			if (DFKeyboard.W)
				red.Location += Vector.Up * 64 * e.DeltaTime;
			if (DFKeyboard.A)
				red.Location += Vector.Left * 64 * e.DeltaTime;
			if (DFKeyboard.S)
				red.Location += Vector.Down * 64 * e.DeltaTime;
			if (DFKeyboard.D)
				red.Location += Vector.Right * 64 * e.DeltaTime;

			if (DFKeyboard.Up)
				green.Location += Vector.Up * 64 * e.DeltaTime;
			if (DFKeyboard.Left)
				green.Location += Vector.Left * 64 * e.DeltaTime;
			if (DFKeyboard.Down)
				green.Location += Vector.Down * 64 * e.DeltaTime;
			if (DFKeyboard.Right)
				green.Location += Vector.Right * 64 * e.DeltaTime;

			if (DFKeyboard.Space.IsKeyDown)
				frame.IsTrimmable = !frame.IsTrimmable;

			frame.Scale = (Vector.One * MathF.Sin(Time.Now) + Vector.One);
		}

		ClickableSprite red, green;
		Container frame;
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
