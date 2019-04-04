#pragma warning disable RECS0018 // 等値演算子による浮動小数点値の比較

using DotFeather.Drawable;
using DotFeather.Helpers;
using DotFeather.Models;

namespace DotFeather
{
	/// <summary>
	/// テクスチャを描画する <see cref="IDrawable"/> オブジェクトです。
	/// </summary>
	public class Sprite : IDrawable
	{
		public Texture2D Texture { get; set; }

		public Vector Location { get; set; }

		public float Angle { get; set; }

		public Vector Scale { get; set; }

		public int ZOrder { get; set; }
		public string Name { get; set; }

		/// <summary>
		/// <see cref="Sprite"/> クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="texture">この <see cref="Sprite"/> が使用するテクスチャ。</param>
		/// <param name="x">初期位置 X。</param>
		/// <param name="y">初期位置 Y。</param>
		/// <param name="angle">初期角度。</param>
		/// <param name="scale">初期スケール</param>
		public Sprite(Texture2D texture, int x, int y, float angle = default, Vector scale = default)
		{
			Texture = texture;
			Location = new Vector(x, y);
			Angle = angle;
			Scale = scale != default ? scale : new Vector(1, 1);
		}

		public void Draw(GameBase game, Vector location)
		{
			TextureDrawer.Draw(game, Texture, location + Location, Scale, Angle);
		}
	}
}