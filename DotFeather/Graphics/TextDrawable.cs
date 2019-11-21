using System;
using SixLabors.ImageSharp;
using SF = SixLabors.Fonts;
using SD = System.Drawing;
using System.IO;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Collections.Generic;
using System.Linq;

namespace DotFeather
{
	/// <summary>
	/// A <see cref="IDrawable"/> object to render text.
	/// </summary>
	public class TextDrawable : TextureDrawableBase
	{
		/// <summary>
		/// Get or set a text to draw.
		/// </summary>
		/// <value></value>
		public string Text
		{
			get => text;
			set
			{
				if (text == value)
					return;
				text = value;
				UpdateTexture();
			}
		}

		/// <summary>
		/// Get or set a font to draw.
		/// </summary>
		/// <value></value>
		public Font Font
		{
			get => font;
			set
			{
				if (font.Equals(value))
					return;
				font = value;
				UpdateTexture();
			}
		}

		/// <summary>
		/// Get and set a color to draw.
		/// </summary>
		/// <value></value>
		public override SD.Color? Color
		{
			get => color;
			set
			{
				if (color == value)
					return;
				color = value;
				UpdateTexture();
			}
		}

		/// <summary>
		/// Get or set a color of the border.
		/// </summary>
		public SD.Color? BorderColor
		{
			get => borderColor;
			set
			{
				if (borderColor == value)
					return;
				borderColor = value;
				UpdateTexture();
			}
		}

		/// <summary>
		/// Get or set a thickness of the border.
		/// </summary>
		public int BorderThickness
		{
			get => borderThickness;
			set
			{
				if (borderThickness == value)
					return;
				borderThickness = value;
				UpdateTexture();
			}
		}

		/// <summary>
		/// Same as <see cref="TextureDrawableBase.Texture"/>
		/// </summary>
		public Texture2D RenderedTexture
		{
			get => Texture;
			private set => Texture = value;
		}

		/// <summary>
		/// Initialize a new instance of <see cref="TextDrawable"/>.
		/// </summary>
		public TextDrawable(string text, Font font, SD.Color? color = default)
		{
			this.text = text;
			this.font = font;
			this.color = color;
			this.UpdateTexture();
		}

		/// <summary>
		/// Initialize a new instance of <see cref="TextDrawable"/>.
		/// </summary>
		public TextDrawable(string text, float fontSize = 16, FontStyle fontStyle = FontStyle.Normal, SD.Color? color = default)
		{
			this.text = text;
			this.font = Font.GetDefault(fontSize, fontStyle);
			this.color = color;
			this.UpdateTexture();
		}

		/// <summary>
		/// Update the texture.
		/// </summary>
		public void UpdateTexture()
		{
			var f = ResolveFont(font);
			var size = SF.TextMeasurer.Measure(Text, new SF.RendererOptions(f));
			using var img = new Image<Rgba32>((int)size.Width + 8, (int)size.Height + 8);
			var col = Color ?? SD.Color.Black;
			var isColor = SixLabors.ImageSharp.Color.FromRgba(col.R, col.G, col.B, col.A);

			if (BorderColor != null)
			{
				var bc = BorderColor ?? SD.Color.Black;
				var isBorderColor = SixLabors.ImageSharp.Color.FromRgba(bc.R, bc.G, bc.B, bc.A);
				img.Mutate(ctx => ctx.DrawText(Text, f, new SolidBrush(isColor), new Pen(isBorderColor, BorderThickness), SixLabors.Primitives.PointF.Empty));
			}
			else
			{
				img.Mutate(ctx => ctx.DrawText(Text, f, isColor, SixLabors.Primitives.PointF.Empty));
			}

			Texture.Dispose();
			Texture = Texture2D.LoadFrom(img);
			Width = img.Width;
			Height = img.Height;
		}

		/// <summary>
		/// Dispose this object.
		/// </summary>
		public override void Destroy()
		{
			Texture.Dispose();
		}

		private SF.Font ResolveFont(Font f)
		{
			SF.FontFamily family;
			if (fontCache.ContainsKey(f.Id))
			{
				family = fontCache[f.Id];
			}
			else if (f.Path != null && File.Exists(f.Path))
			{
				family = new SF.FontCollection().Install(f.Path);
			}
			else if (f.Path != null)
			{
				family = SF.SystemFonts.Find(f.Path);
			}
			else if (f.Stream != null)
			{
				f.Stream.Position = 0;
				family = new SF.FontCollection().Install(f.Stream);
			}
			else
			{
				throw new ArgumentException("Font class must have either a path or a stream.");
			}
			fontCache[f.Id] = family;
			return new SF.Font(family, f.Size, (SF.FontStyle)f.FontStyle);
		}

		private static Dictionary<object, SF.FontFamily> fontCache = new Dictionary<object, SF.FontFamily>();

		private string text;
		private Font font;
		private SD.Color? color;
		private SD.Color? borderColor;
		private int borderThickness = 1;
	}
}
