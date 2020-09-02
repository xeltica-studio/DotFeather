using System;
using System.Drawing;
using DotFeather;

namespace FollowStrawberry
{
	class Program
	{
		static int Main()
		{
			DF.Window.Start += () =>
			{
				var strawberry = new Sprite("strawberry.png");
				strawberry.AddComponent<StrawberryController>();
				DF.Root.Add(strawberry);
			};

			return DF.Run();
		}
	}

	public class StrawberryController : Component
	{
		public override void OnUpdate()
		{
			if (!DF.Window.IsFocused) return;
			Element.Location = DFMouse.Position;
			Element.Scale = DFMouse.IsLeft ? (4, 4) : (1, 1);

			if (!(Element is Sprite sprite)) throw new Exception("Strawberry must be a sprite");

			if (DFKeyboard.W) sprite.Width = 128;
			if (DFKeyboard.H) sprite.Height = 256;

			if (!DFKeyboard.W && !DFKeyboard.H) sprite.ResetSize();

			sprite.TintColor = DFKeyboard.C ? rnd.NextColor() : Color.White;
		}

		private readonly Random rnd = new Random();
	}
}
