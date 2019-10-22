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
		const string SYSTEM_FONT_PATH = "./font.ttf";

		const string VERSION = "1.0";


		public Game(int width, int height, string title = null, int refreshRate = 60) : base(width, height, title, refreshRate)
		{
			BackgroundColor = Color.FromArgb(255, 32, 32, 32);
			WindowMode = WindowMode.Resizable;
			Title = $"DotFeather SAMPLE PROGRAM {VERSION}";

			var titleText = Text("DotFeather", 56);
			var sampleProgramText = Text($"SAMPLE PROGRAM {VERSION}", 24);
			titleText.Location = new Vector(24, 24);
			sampleProgramText.Location = new Vector(24 + titleText.Width + 8, 50);

			Root.Add(titleText);
			Root.Add(sampleProgramText);
		}

		protected override void OnLoad(object sender, EventArgs e)
		{

		}

		protected override void OnUpdate(object sender, DFEventArgs e)
		{

		}

		private TextDrawable Text(string text, int size, Color? color = null)
		{
			return new TextDrawable(text, new Font(SYSTEM_FONT_PATH, size), color ?? Color.White);
		}
	}

	public class ClickableSprite : Sprite, IUpdatable
	{
		public ClickableSprite(Texture2D texture) : base(texture) { }

		public event Action<ClickableSprite> Click;

		public void OnUpdate(GameBase game)
		{
			
		}
	}
}
