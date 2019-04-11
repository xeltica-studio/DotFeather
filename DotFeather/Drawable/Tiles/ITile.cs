using System.Drawing;

namespace DotFeather.Drawable.Tiles
{
	public interface ITile
	{
		/// <summary>
		/// この <see cref="ITile"/> をレンダリングします。
		/// </summary>
		void Draw(GameBase game, Tilemap map, Vector location, Color? color);

        /// <summary>
        /// この <see cref="ITile"/> を破棄します。
        /// </summary>
        void Destroy();
	}
}
