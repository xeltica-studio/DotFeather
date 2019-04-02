using System;
using System.Drawing;
using DotFeather.Drawable;
using DotFeather.InputSystems;
using DotFeather.Models;

namespace DotFeather.Test.NetCore
{
	class Game : GameBase
	{
		static void Main(string[] args)
		{
			using (var g = new Game(640, 480))
			{
				g.Run();
			}
		}


		public Game(int width, int height, string title = null, int refreshRate = 60) : base(width, height, title, refreshRate)
		{
			Title = "New Game";
		}

		protected override void OnLoad(object sender, EventArgs e)
		{
			var texture = LoadImage("cat.png");
			var sprite = new Sprite(texture, 4, 1, 0, new Vector(16, 24));

			this.Children.Add(sprite);
		}

		protected override void OnUpdate(object sender, DFEventArgs e)
		{
			if (Input.Keyboard.Escape.IsPressed)
				Exit(0);
		}
	}
}
