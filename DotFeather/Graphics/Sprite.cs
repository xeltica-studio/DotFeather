#pragma warning disable RECS0018 // 等値演算子による浮動小数点値の比較


using System.IO;

namespace DotFeather
{
	/// <summary>
	/// A <see cref="IDrawable"/> object to draw a texture.
	/// </summary>
	public class Sprite : TextureDrawableBase
	{
		/// <summary>
		/// Get or set a texture drawn by this <see cref="Sprite"/>.
		/// </summary>
		public new Texture2D Texture
		{
			get => base.Texture;
			set => base.Texture = value;
		}

		/// <summary>
		/// Initialize a new instance of <see cref="Sprite"/> class.
		/// </summary>
		/// <param name="texture">A texture for this <see cref="Sprite"/>.</param>
		public Sprite(Texture2D texture)
		{
			Texture = texture;
			Width = Texture.Size.X;
			Height = Texture.Size.Y;
		}

		/// <summary>
		/// Generate a <see cref="Sprite"/> from the specified image file.
		/// </summary>
		/// <param name="path">File path.</param>
		/// <returns>Generated <see cref="Sprite"/>。</returns>
		public static Sprite LoadFrom(string path) => new Sprite(path);

		/// <summary>
		/// Generate a <see cref="Sprite"/> from the specified image file.
		/// </summary>
		/// <param name="stream">File stream.</param>
		/// <returns>Generated <see cref="Sprite"/>。</returns>
		public static Sprite LoadFrom(Stream stream) => new Sprite(stream);

		/// <summary>
		/// Dispose this <see cref="Sprite"/>.
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
