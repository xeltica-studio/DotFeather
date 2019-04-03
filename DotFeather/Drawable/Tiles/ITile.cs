using System;
using System.Drawing;

namespace DotFeather.Drawable.Tiles
{
	public interface ITile
	{
		void Draw(GameBase game, Tilemap map, Vector location, Color? color);
	}
}
