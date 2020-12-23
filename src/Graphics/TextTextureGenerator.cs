using System;
using System.Collections.Generic;
using System.IO;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace DotFeather
{
	public static class TextTextureGenerator
	{
		internal static Texture2D Generate(string text, DFFont font, System.Drawing.Color? color, System.Drawing.Color? borderColor, int borderThickness)
		{
			var f = ResolveFont(font);
			var size = TextMeasurer.Measure(text, new RendererOptions(f));
			using var img = new Image<Rgba32>((int)size.Width + 8, (int)size.Height + 8);
			var col = color ?? System.Drawing.Color.Black;
			var isColor = Color.FromRgba(col.R, col.G, col.B, col.A);

			if (borderColor != null)
			{
				var bc = borderColor ?? System.Drawing.Color.Black;
				var isBorderColor = Color.FromRgba(bc.R, bc.G, bc.B, bc.A);
				img.Mutate(ctx => ctx.DrawText(text, f, new SolidBrush(isColor), new Pen(isBorderColor, borderThickness), PointF.Empty));
			}
			else
			{
				img.Mutate(ctx => ctx.DrawText(text, f, isColor, PointF.Empty));
			}
			return Texture2D.LoadFrom(img);
		}

		internal static Font ResolveFont(DFFont f)
		{
			FontFamily family;
			if (fontCache.ContainsKey(f.Id))
			{
				family = fontCache[f.Id];
			}
			else if (f.Path != null && File.Exists(f.Path))
			{
				family = new FontCollection().Install(f.Path);
			}
			else if (f.Path != null)
			{
				family = SystemFonts.Find(f.Path);
			}
			else if (f.Stream != null)
			{
				f.Stream.Position = 0;
				family = new FontCollection().Install(f.Stream);
			}
			else
			{
				throw new ArgumentException("Font class must have either a path or a stream.");
			}
			fontCache[f.Id] = family;
			return new Font(family, f.Size, (FontStyle)f.FontStyle);
		}

		private static readonly Dictionary<object, FontFamily> fontCache = new Dictionary<object, FontFamily>();
	}
}
