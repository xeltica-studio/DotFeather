using System;
using DotFeather;

namespace NineSlice
{
	class Program
	{
		static int Main()
		{
			DF.Root.Add(
				new Element("main",
					new Element("sprite").With(sprite = new SpriteRenderer("rect.png")),
					new Element("9slice").With(nineslice = new NineSliceSpriteRenderer("rect.png", 16, 16, 16, 16))
				)
			);

			DF.Window.Update += OnUpdate;

			return DF.Run();
		}

		private static void OnUpdate()
		{
			// sprites location
			sprite.Transform.Location = (DF.Window.Width / 4 - 128, 64);
			nineslice.Transform.Location = (DF.Window.Width / 4 + 32, 64);

			sprite.Width = nineslice.Width = (int)(64 + 64 * Math.Abs(Math.Sin(Time.Now * 2)));
			sprite.Height = nineslice.Height = (int)(64 + 256 * Math.Abs(Math.Sin(Time.Now * 2)));
		}

		private static SpriteRenderer sprite;
		private static NineSliceSpriteRenderer nineslice;
		// private static readonly TextDrawable t1 = new TextDrawable("Sprite", DFFont.GetDefault(18), Color.Lime);
		// private static readonly TextDrawable t2 = new TextDrawable("9-slice Sprite", DFFont.GetDefault(18), Color.Lime);
	}
}
