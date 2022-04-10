using System;
using System.IO;
using System.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace DotFeather
{
	/// <summary>
	/// Wrap a handles of 9-sliced textures.
	/// </summary>
	public readonly struct Texture9Sliced
	{
		public Texture2D TopLeft { get; }
		public Texture2D TopCenter { get; }
		public Texture2D TopRight { get; }
		public Texture2D MiddleLeft { get; }
		public Texture2D MiddleCenter { get; }
		public Texture2D MiddleRight { get; }
		public Texture2D BottomLeft { get; }
		public Texture2D BottomCenter { get; }
		public Texture2D BottomRight { get; }

		public VectorInt Size { get; }

		private Texture9Sliced(Texture2D[] textures, VectorInt size)
		{
			TopLeft = textures[0];
			TopCenter = textures[1];
			TopRight = textures[2];
			MiddleLeft = textures[3];
			MiddleCenter = textures[4];
			MiddleRight = textures[5];
			BottomLeft = textures[6];
			BottomCenter = textures[7];
			BottomRight = textures[8];
			Size = size;
		}

		public static Texture9Sliced LoadFrom(string path, int left, int top, int right, int bottom)
		{
			return new Texture9Sliced(LoadFrom(Image.Load(path), left, top, right, bottom, out var size), size);
		}

		public static Texture9Sliced LoadFrom(Stream stream, int left, int top, int right, int bottom)
		{
			return new Texture9Sliced(LoadFrom(Image.Load(stream), left, top, right, bottom, out var size), size);
		}

		/// <summary>
		/// Destroy this <see cref="Texture2D"/>.
		/// </summary>
		public void Dispose()
		{
			TopLeft.Dispose();
			TopCenter.Dispose();
			TopRight.Dispose();
			MiddleLeft.Dispose();
			MiddleCenter.Dispose();
			MiddleRight.Dispose();
			BottomLeft.Dispose();
			BottomCenter.Dispose();
			BottomRight.Dispose();
		}

		private static Texture2D[] LoadFrom(Image bitmap, int left, int top, int right, int bottom, out VectorInt size)
		{
			using var img = bitmap.CloneAs<Rgba32>();
			bitmap.Dispose();

			size = (img.Width, img.Height);

			if (left > img.Width)
				throw new ArgumentException(null, nameof(left));
			if (top > img.Height)
				throw new ArgumentException(null, nameof(top));
			if (right > img.Width - left)
				throw new ArgumentException(null, nameof(right));
			if (bottom > img.Height - top)
				throw new ArgumentException(null, nameof(bottom));

			var atlas = new[]
			{
				new Rectangle(0, 0, left, top),
				new Rectangle(left, 0, img.Width - left - right, top),
				new Rectangle(img.Width - right, 0, right, top),
				new Rectangle(0, top, left, img.Height - top - bottom),
				new Rectangle(left, top, img.Width - left - right, img.Height - top - bottom),
				new Rectangle(img.Width - right, top, right, img.Height - top - bottom),
				new Rectangle(0, img.Height - bottom, left, bottom),
				new Rectangle(left, img.Height - bottom, img.Width - left - right, bottom),
				new Rectangle(img.Width - right, img.Height - bottom, right, bottom),
			};

			return atlas.Select(a =>
			{
				using var locked = img.Clone(ctx => ctx.Crop(a));
				return Texture2D.LoadFrom(locked);
			}).ToArray();
		}
	}
}
