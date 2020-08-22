using System.Drawing;

namespace DotFeather
{
	/// <summary>
	/// <see cref="Tilemap"/> が扱えるタイルを定義します。
	/// </summary>
	public interface ITile
	{
		/// <summary>
		/// この <see cref="ITile"/> をレンダリングします。
		/// </summary>
		void Draw(ITilemap map, VectorInt tileLocation, Vector locationToDraw, Color? color);

		/// <summary>
		/// この <see cref="ITile"/> を破棄します。
		/// </summary>
		void Destroy();
	}
}
