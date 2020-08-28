using System;
using System.Drawing;
using DotFeather;

namespace FollowStrawberry
{
	class Program
	{
		static int Main()
		{
			DF.Root.Add(
				new Sprite("strawberry.png")
					.With(new StrawberryController())
			);

			return DF.Run();
		}
	}

	public class StrawberryController : Component
	{
		public override void OnUpdate()
		{
			if (!DF.Window.IsFocused) return;
			if (Transform == null) return;
			Transform.Location = DFMouse.Position;
			Transform.Scale = DFMouse.IsLeft ? (4, 4) : (1, 1);

			renderer = GetComponent<SpriteRenderer>();
			if (renderer == null) return;

			renderer.Width = DFKeyboard.W.ElapsedFrameCount + renderer.Texture.Size.X;
			renderer.Height = DFKeyboard.H.ElapsedFrameCount + renderer.Texture.Size.Y;
			renderer.TintColor = DFKeyboard.C ? rnd.NextColor() : Color.White;
		}

		private readonly Random rnd = new Random();
		private SpriteRenderer? renderer;
	}
}
