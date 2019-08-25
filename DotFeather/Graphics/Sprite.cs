#pragma warning disable RECS0018 // 等値演算子による浮動小数点値の比較


using System.IO;

namespace DotFeather
{
	/// <summary>
	/// テクスチャを描画する <see cref="IDrawable"/> オブジェクトです。
	/// </summary>
	public class Sprite : TextureDrawableBase
	{
		/// <summary>
		/// <see cref="Sprite"/> クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <value></value>
		public Sprite(Texture2D texture, Vector location, float angle, Vector scale, int zOrder, string name)
		{
			this.Texture = texture;
			this.Location = location;
			this.Angle = angle;
			this.Scale = scale;
			this.ZOrder = zOrder;
			this.Name = name;
		}

		/// <summary>
		/// この <see cref="Sprite"/> が描画するテクスチャを取得または設定します。
		/// </summary>
		/// <value></value>
		public new Texture2D Texture
		{
			get => base.Texture;
			set => base.Texture = value;
		}

		/// <summary>
		/// <see cref="Sprite"/> クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="texture">この <see cref="Sprite"/> が使用するテクスチャ。</param>
		/// <param name="x">初期位置 X。</param>
		/// <param name="y">初期位置 Y。</param>
		/// <param name="angle">初期角度。</param>
		/// <param name="scale">初期スケール</param>
		public Sprite(Texture2D texture, int x, int y, float angle = default, Vector scale = default)
			: this(texture)
		{
			Location = new Vector(x, y);
			Angle = angle;
			Scale = scale != default ? scale : new Vector(1, 1);
		}

		/// <summary>
		/// <see cref="Sprite"/> クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="texture">この <see cref="Sprite"/> が使用するテクスチャ。</param>
		public Sprite(Texture2D texture)
		{
			Texture = texture;
			Width = Texture.Size.Width;
	Height = Texture.Size.Height;
		}

		/// <summary>
		/// 指定した画像ファイルから <see cref="Sprite"/> を生成します。
		/// </summary>
		/// <param name="path">ファイルパス。</param>
		/// <returns>生成された <see cref="Sprite"/>。</returns>
		public static Sprite LoadFrom(string path) => new Sprite(path);

		/// <summary>
		/// 指定した画像ファイルから <see cref="Sprite"/> を生成します。
		/// </summary>
		/// <param name="stream">ファイルを示すストリーム。</param>
		/// <returns>生成された <see cref="Sprite"/>。</returns>
		public static Sprite LoadFrom(Stream stream) => new Sprite(stream);

		/// <summary>
		/// この <see cref="Sprite"/> を破棄します。
		/// </summary>
		public override void Destroy()
		{
			internalTexture.Dispose();
			base.Destroy();
		}

		private Sprite(string path)
			: this(Texture2D.LoadFrom(path))
		{　
			internalTexture = Texture;
		}

		private Sprite(Stream path)
			: this(Texture2D.LoadFrom(path))
		{　
			internalTexture = Texture;
		}

		private Texture2D internalTexture;
	}
}
