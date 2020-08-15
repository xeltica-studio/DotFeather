#pragma warning disable RECS0018 // 等値演算子による浮動小数点値の比較


using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace DotFeather
{
	/// <summary>
	/// A <see cref="IDrawable"/> object to draw 9-slice sprite.
	/// </summary>
	public class NineSliceSprite : IContainable, ISizedDrawable
	{
		/// <summary>
		///　Get 9 textures.
		/// </summary>
		public Texture2D[] Textures { get; }

		public int ZOrder { get; set; }

		public string Name { get; set; } = "";

		public Vector Location { get; set; }

		public float Angle { get; set; }

		public Vector Scale { get; set; } = Vector.One;

		public Color? Color { get; set; }

		/// <summary>
		/// Get or set width.
		/// </summary>
		public int Width { get; set; }

		/// <summary>
		/// Get or set height.
		/// </summary>
		public int Height { get; set; }

		/// <summary>
		/// Get absolute location.
		/// </summary>
		public Vector AbsoluteLocation => Location + (Parent?.AbsoluteLocation ?? Vector.Zero);

		float ISizedDrawable.Width
		{
			get => Width;
			set => Width = (int)value;
		}

		float ISizedDrawable.Height
		{
			get => Height;
			set => Height = (int)value;
		}

		/// <summary>
		/// Get a parent of this drawable.
		/// </summary>
		public IContainable? Parent { get; internal set; }

		IContainable? IContainable.Parent
		{
			get => Parent;
			set => Parent = value;
		}

		/// <summary>
		/// Initialize a new instance of <see cref="NineSliceSprite"/> class.
		/// </summary>
		public NineSliceSprite(Texture2D[] textures)
		{
			if (textures.Length != 9)
				throw new ArgumentException(nameof(textures));
			this.Textures = textures;
			Width = WidthOf(0) + WidthOf(1) + WidthOf(2);
			Height = HeightOf(0) + HeightOf(3) + HeightOf(6);
		}

		/// <summary>
		/// Generate <see cref="NineSliceSprite"/> from the specified texture.
		/// </summary>
		/// <param name="path">File path.</param>
		/// <param name="left">Pixel value from left.</param>
		/// <param name="top">Pixel value from top.</param>
		/// <param name="right">Pixel value from right.</param>
		/// <param name="bottom">Pixel value from bottom.</param>
		/// <returns>Generated <see cref="NineSliceSprite"/>。</returns>
		public static NineSliceSprite LoadFrom(string path, int left, int top, int right, int bottom) => new NineSliceSprite(path, left, top, right, bottom);

		/// <summary>
		/// Generate <see cref="NineSliceSprite"/> from the specified texture.
		/// </summary>
		/// <param name="stream">File stream.</param>
		/// <param name="left">Pixel value from left.</param>
		/// <param name="top">Pixel value from top.</param>
		/// <param name="right">Pixel value from right.</param>
		/// <param name="bottom">Pixel value from bottom.</param>
		/// <returns>Generated <see cref="NineSliceSprite"/>。</returns>
		public static NineSliceSprite LoadFrom(Stream stream, int left, int top, int right, int bottom) => new NineSliceSprite(stream, left, top, right, bottom);

		/// <summary>
		/// Dispose this <see cref="NineSliceSprite"/>.
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
		/// Draw the object.
		/// </summary>
		public void Draw(Vector location)
		{
			var xSpan = this.Width - WidthOf(0) - WidthOf(2);
			var ySpan = this.Height - HeightOf(0) - HeightOf(6);
			TextureDrawer.Draw(Textures[0], location + Location, Scale, Angle, Color);
			TextureDrawer.Draw(Textures[1], location + Location + (Vector.Right * WidthOf(0)) * Scale, Scale, Angle, Color, xSpan);
			TextureDrawer.Draw(Textures[2], location + Location + (Vector.Right * (WidthOf(0) + xSpan)) * Scale, Scale, Angle, Color);
			TextureDrawer.Draw(Textures[3], location + Location + (new Vector(0, HeightOf(0))) * Scale, Scale, Angle, Color, null, ySpan);
			TextureDrawer.Draw(Textures[4], location + Location + (new Vector(WidthOf(0), HeightOf(0))) * Scale, Scale, Angle, Color, xSpan, ySpan);
			TextureDrawer.Draw(Textures[5], location + Location + (new Vector(WidthOf(0) + xSpan, HeightOf(0))) * Scale, Scale, Angle, Color, null, ySpan);
			TextureDrawer.Draw(Textures[6], location + Location + (new Vector(0, HeightOf(0) + ySpan)) * Scale, Scale, Angle, Color, null);
			TextureDrawer.Draw(Textures[7], location + Location + (new Vector(WidthOf(0), HeightOf(0) + ySpan)) * Scale, Scale, Angle, Color, xSpan);
			TextureDrawer.Draw(Textures[8], location + Location + (new Vector(WidthOf(0) + xSpan, HeightOf(0) + ySpan)) * Scale, Scale, Angle, Color, null);
		}

		private int WidthOf(int index) => Textures[index].Size.X;

		private int HeightOf(int index) => Textures[index].Size.Y;

		private NineSliceSprite(string path, int left, int top, int right, int bottom)
				: this(Texture2D.LoadAndSplitFrom(path, left, top, right, bottom))
		{
			internalTexture = Textures;
		}

		private NineSliceSprite(Stream stream, int left, int top, int right, int bottom)
				: this(Texture2D.LoadAndSplitFrom(stream, left, top, right, bottom))
		{
			internalTexture = Textures;
		}

		private readonly Texture2D[]? internalTexture;
	}
}
