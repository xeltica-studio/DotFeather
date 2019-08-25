using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using OpenTK.Graphics.OpenGL;

namespace DotFeather
{
	/// <summary>
	/// テクスチャのハンドルを持ちます。
	/// </summary>
	public struct Texture2D : IDisposable
	{
		/// <summary>
		/// このテクスチャの OpenGL ハンドルを取得します。
		/// </summary>
		public int Handle { get; }

		/// <summary>
		/// このテクスチャのサイズを取得します。
		/// </summary>
		public Size Size { get; }

		/// <summary>
		/// ハンドルとサイズを指定して、 <see cref="Texture2D"/> クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="handle"></param>
		/// <param name="size"></param>
		public Texture2D(int handle, Size size)
		{
			Handle = handle;
			Size = size;
		}

		/// <summary>
		/// 画像ファイルを読み込みます。
		/// </summary>
		/// <returns>読み込んだ画像のデータ。</returns>
		/// <param name="path">ファイルパス。</param>
		public static Texture2D LoadFrom(string path)
		{
			return LoadFrom(new Bitmap(path));
		}

		/// <summary>
		/// 画像ファイルを読み込みます。
		/// </summary>
		/// <returns>読み込んだ画像のデータ。</returns>
		/// <param name="stream">ストリーム。</param>
		public static Texture2D LoadFrom(Stream stream)
		{
			return LoadFrom(new Bitmap(stream));
		}

		private static Texture2D LoadFrom(Bitmap bmp)
		{
			using (var file = bmp)
			{
				return LoadFrom(file.LockBits(new Rectangle(0, 0, file.Width, file.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb));
			}
		}

		/// <summary>
		/// テクスチャを登録し、ハンドルを返します。
		/// </summary>
		public static Texture2D LoadFrom(BitmapData bmp)
		{
			var texture = GL.GenTexture();
			GL.BindTexture(TextureTarget.Texture2D, texture);

			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
			GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmp.Width, bmp.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmp.Scan0);
			return new Texture2D(texture, new Size(bmp.Width, bmp.Height));
		}

		public static Texture2D CreateSolid(Color color, int sizeX, int sizeY)
		{
			var texture = GL.GenTexture();
			GL.BindTexture(TextureTarget.Texture2D, texture);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);

			var arr = new float[sizeX, sizeY, 4];

			for (var y = 0; y < sizeY; y++)
			for (var x = 0; x < sizeX; x++)
			{
				arr[x, y, 0] = color.R / 256f;
				arr[x, y, 1] = color.G / 256f;
				arr[x, y, 2] = color.B / 256f;
				arr[x, y, 3] = color.A / 256f;
			}

			GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, sizeX, sizeY, 0, OpenTK.Graphics.OpenGL.PixelFormat.Rgba, PixelType.Float, arr);

			return new Texture2D(texture, new Size(sizeX, sizeY));
		}

		public static Texture2D CreateSolid(Color color, Vector size) => CreateSolid(color, (int)size.X, (int)size.Y);

		/// <summary>
		/// 画像ファイルを読み込み、指定したサイズで左上から順番に切り取ります。
		/// </summary>
		/// <returns>切り取られた全ての画像データ。</returns>
		/// <param name="path">画像のファイルパス。</param>
		/// <param name="horizonalCount">横方向の画像の枚数。</param>
		/// <param name="verticalCount">盾向の画像の枚数。</param>
		/// <param name="sizeOfCroppedImage">画像1枚分のサイズ。</param>
		public static Texture2D[] LoadAndSplitFrom(string path, int horizonalCount, int verticalCount, Size sizeOfCroppedImage)
		{
			return LoadAndSplitFrom(new Bitmap(path), horizonalCount, verticalCount, sizeOfCroppedImage);
		}

		/// <summary>
		/// 画像ファイルを読み込み、指定したサイズで左上から順番に切り取ります。
		/// </summary>
		/// <returns>切り取られた全ての画像データ。</returns>
		/// <param name="stream">画像のファイルを示すストリーム。</param>
		/// <param name="horizonalCount">横方向の画像の枚数。</param>
		/// <param name="verticalCount">盾向の画像の枚数。</param>
		/// <param name="sizeOfCroppedImage">画像1枚分のサイズ。</param>
		public static Texture2D[] LoadAndSplitFrom(Stream stream, int horizonalCount, int verticalCount, Size sizeOfCroppedImage)
		{
			return LoadAndSplitFrom(new Bitmap(stream), horizonalCount, verticalCount, sizeOfCroppedImage);
		}

		private static Texture2D[] LoadAndSplitFrom(Bitmap bmp, int horizonalCount, int verticalCount, Size sizeOfCroppedImage)
		{
			using (var file = bmp)
			{
				var datas = new List<Texture2D>();

				for (int y = 0; y < verticalCount; y++)
				{
					for (int x = 0; x < horizonalCount; x++)
					{
						(var px, var py) = (x * sizeOfCroppedImage.Width, y * sizeOfCroppedImage.Height);
						if (px + sizeOfCroppedImage.Width > file.Width)
						{
							throw new ArgumentException(nameof(horizonalCount));
						}
						if (py + sizeOfCroppedImage.Height > file.Height)
						{
							throw new ArgumentException(nameof(verticalCount));
						}
						var locked = file.LockBits(new Rectangle(px, py, sizeOfCroppedImage.Width, sizeOfCroppedImage.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
						datas.Add(LoadFrom(locked));
						file.UnlockBits(locked);
					}
				}
				return datas.ToArray();
			}
		}

		/// <summary>
		/// 画像ファイルを読み込み、9スライス用に切り抜きます。
		/// </summary>
		/// <param name="path">画像ファイル。</param>
		/// <param name="left">左からのピクセル値。</param>
		/// <param name="top">上からのピクセル値。</param>
		/// <param name="right">右からのピクセル値。</param>
		/// <param name="bottom">下からのピクセル値。</param>
		/// <returns>切り取られた9枚のテクスチャ。</returns>
		public static Texture2D[] LoadAndSplitFrom(string path, int left, int top, int right, int bottom)
		{
			return LoadAndSplitFrom(new Bitmap(path), left, top, right, bottom);
		}

		/// <summary>
		/// 画像ファイルを読み込み、9スライス用に切り抜きます。
		/// </summary>
		/// <param name="stream">画像を示すストリーム。</param>
		/// <param name="left">左からのピクセル値。</param>
		/// <param name="top">上からのピクセル値。</param>
		/// <param name="right">右からのピクセル値。</param>
		/// <param name="bottom">下からのピクセル値。</param>
		/// <returns>切り取られた9枚のテクスチャ。</returns>
		public static Texture2D[] LoadAndSplitFrom(Stream stream, int left, int top, int right, int bottom)
		{
			return LoadAndSplitFrom(new Bitmap(stream), left, top, right, bottom);
		}

		private static Texture2D[] LoadAndSplitFrom(Bitmap bitmap, int left, int top, int right, int bottom)
		{
			using (var file = bitmap)
			{
				if (left > file.Width)
					throw new ArgumentException(nameof(left));
				if (top > file.Height)
					throw new ArgumentException(nameof(top));
				if (right > file.Width - left)
					throw new ArgumentException(nameof(right));
				if (bottom > file.Height - top)
					throw new ArgumentException(nameof(bottom));
				Rectangle[] atlas = 
				{
					new Rectangle(0, 0, left, top),
					new Rectangle(left, 0, file.Width - left - right, top),
					new Rectangle(file.Width - right, 0, right, top),
					new Rectangle(0, top, left, file.Height - top - bottom),
					new Rectangle(left, top, file.Width - left - right, file.Height - top - bottom),
					new Rectangle(file.Width - right, top, right, file.Height - top - bottom),
					new Rectangle(0, file.Height - bottom, left, bottom),
					new Rectangle(left, file.Height - bottom, file.Width - left - right, bottom),
					new Rectangle(file.Width - right, file.Height - bottom, right, bottom),
				};
				return atlas.Select(a => 
				{
					var locked = file.LockBits(a, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
					var tex = LoadFrom(locked);
					file.UnlockBits(locked);
					return tex;
				}).ToArray();
			}
		}

		/// <summary>
		/// この <see cref="Texture2D"/> を破棄します。
		/// </summary>
		public void Dispose()
		{
			GL.DeleteTexture(Handle);
		}
	}
}
