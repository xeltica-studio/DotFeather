#pragma warning disable RECS0018 // 等値演算子による浮動小数点値の比較


using System;
using System.Drawing;
using System.Linq;

namespace DotFeather
{
	/// <summary>
	/// 9 スライステクスチャを描画する <see cref="IDrawable"/> オブジェクトです。
	/// </summary>
	public class NineSliceSprite : IDrawable
	{
		/// <summary>
		/// 9枚のテクスチャを取得します。
		/// </summary>
		/// <value></value>
		public Texture2D[] Textures { get; }

	/// <summary>
		/// この <see cref="NineSliceSprite"/> の描画優先順位を取得または設定します。数値が低いほど奥に描画されます。
		/// </summary>
		public int ZOrder { get; set; }

		/// <summary>
		/// この <see cref="NineSliceSprite"/> の名前を取得または設定します。
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// この <see cref="NineSliceSprite"/> の座標を取得または設定します。
		/// </summary>
		public Vector Location { get; set; }

		/// <summary>
		/// この <see cref="NineSliceSprite"/> の角度を取得または設定します。
		/// </summary>
		public float Angle { get; set; }

		/// <summary>
		/// この <see cref="NineSliceSprite"/> のスケーリングを取得または設定します。
		/// </summary>
		public Vector Scale { get; set; } = Vector.One;

		/// <summary>
		/// この <see cref="NineSliceSprite"/> のカラーを取得または設定します。
		/// </summary>
		public Color? Color { get; set; }

		/// <summary>
		/// 幅を取得または設定します。
		/// </summary>
		public int Width { get; set; }

		/// <summary>
		/// 高さを取得または設定します。
		/// </summary>
		public int Height { get; set; }

	/// <summary>
	/// <see cref="NineSliceSprite"/> クラスの新しいインスタンスを初期化します。
	/// </summary>
	/// <value></value>
	public NineSliceSprite(Texture2D[] textures)
		{
			if (textures.Length != 9)
				throw new ArgumentException(nameof(textures));
			this.Textures = textures;
			Width = WidthOf(0) + WidthOf(1) + WidthOf(2);
			Height = HeightOf(0) + HeightOf(3) + HeightOf(6);
		}

	/// <summary>
	/// 指定した画像ファイルから <see cref="NineSliceSprite"/> を生成します。
	/// </summary>
	/// <param name="path">ファイルパス。</param>
	/// <param name="left">左からのピクセル値。</param>
	/// <param name="top">上からのピクセル値。</param>
	/// <param name="right">右からのピクセル値。</param>
	/// <param name="bottom">下からのピクセル値。</param>
	/// <returns>生成された <see cref="Sprite"/>。</returns>
	public static NineSliceSprite LoadFrom(string path, int left, int top, int right, int bottom) => new NineSliceSprite(path, left, top, right, bottom);

		/// <summary>
		/// この <see cref="NineSliceSprite"/> を破棄します。
		/// </summary>
		public void Destroy()
		{
			if (internalTexture == null) return;
			foreach (var t in internalTexture)
			{
				t.Dispose();
			}
		}

		/// <summary>
		/// オブジェクトを描画します。
		/// </summary>
	public void Draw(GameBase game, Vector location)
	{
			var xSpan = this.Width - WidthOf(0) - WidthOf(2);
			var ySpan = this.Height - HeightOf(0) - HeightOf(6);
			TextureDrawer.Draw(game, Textures[0], location + Location, Scale, Angle, Color);
			TextureDrawer.Draw(game, Textures[1], location + Location + (Vector.Right * WidthOf(0)) * Scale, Scale, Angle, Color, xSpan);
			TextureDrawer.Draw(game, Textures[2], location + Location + (Vector.Right * (WidthOf(0) + xSpan)) * Scale, Scale, Angle, Color);
			TextureDrawer.Draw(game, Textures[3], location + Location + (new Vector(0, HeightOf(0))) * Scale, Scale, Angle, Color, null, ySpan);
			TextureDrawer.Draw(game, Textures[4], location + Location + (new Vector(WidthOf(0), HeightOf(0))) * Scale, Scale, Angle, Color, xSpan, ySpan);
			TextureDrawer.Draw(game, Textures[5], location + Location + (new Vector(WidthOf(0) + xSpan, HeightOf(0))) * Scale, Scale, Angle, Color, null, ySpan);
			TextureDrawer.Draw(game, Textures[6], location + Location + (new Vector(0, HeightOf(0) + ySpan)) * Scale, Scale, Angle, Color, null);
			TextureDrawer.Draw(game, Textures[7], location + Location + (new Vector(WidthOf(0), HeightOf(0) + ySpan)) * Scale, Scale, Angle, Color, xSpan);
			TextureDrawer.Draw(game, Textures[8], location + Location + (new Vector(WidthOf(0) + xSpan, HeightOf(0) + ySpan)) * Scale, Scale, Angle, Color, null);
	}

		private int WidthOf(int index) => Textures[index].Size.Width;

		private int HeightOf(int index) => Textures[index].Size.Height;

	private NineSliceSprite(string path, int left, int top, int right, int bottom)
			: this(Texture2D.LoadAndSplitFrom(path, left, top, right, bottom))
		{　
			internalTexture = Textures;
		}

		private Texture2D[] internalTexture;
	}
}
