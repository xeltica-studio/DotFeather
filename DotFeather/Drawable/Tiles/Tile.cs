using System;
using System.Drawing;
using DotFeather.Helpers;
using DotFeather.Models;

namespace DotFeather.Drawable.Tiles
{
	public class Tile : ITile
	{
		public Texture2D Texture { get; private set; }

		public Texture2D[] Animations { get; private set; }

		public double Interval { get; private set; }

		int animationState;
		double timer;

		public Tile(Texture2D texture)
		{
			Texture = texture;
		}

		public Tile(Texture2D[] animations, double interval)
		{
			if (animations == null)
				throw new ArgumentNullException(nameof(animations));
			if (animations.Length < 1)
				throw new ArgumentException(nameof(animations));
			Animations = animations;
			Interval = interval;
			Texture = Animations[0];
		}

		public void Draw(GameBase game, Tilemap _, Vector location, Color? color)
		{
			if (Animations != default)
			{
				if (timer > Interval)
				{
					animationState++;
					if (animationState >= Animations.Length)
						animationState = 0;
				}

				Texture = Animations[animationState];

				timer += Time.DeltaTime;
			}

			TextureDrawer.Draw(game, Texture, location, Vector.One, 0, color);
		}
	}
}
