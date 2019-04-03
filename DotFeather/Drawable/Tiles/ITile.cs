using System;
namespace DotFeather.Drawable.Tiles
{
	public interface ITile
	{
		void Draw(GameBase game, Vector location);
	}
}
