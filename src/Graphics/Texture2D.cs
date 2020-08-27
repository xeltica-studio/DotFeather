using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SD = System.Drawing;
using OpenTK.Graphics.OpenGL;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using System.Runtime.InteropServices;

namespace DotFeather
{
	/// <summary>
	/// Wrap a handle of 2D texture.
	/// </summary>
	public readonly struct Texture2D : IDisposable
	{
		/// <summary>
		/// Get a OpenGL handle of this texture.
		/// </summary>
		public int Handle { get; }

		/// <summary>
		/// Get size of this texture.
		/// </summary>
		public VectorInt Size { get; }

		/// <summary>
		/// Initialize a new instance of  <see cref="Texture2D"/> with the specified handle and size.
		/// </summary>
		/// <param name="handle"></param>
		/// <param name="size"></param>
		public Texture2D(int handle, VectorInt size)
		{
			Handle = handle;
			Size = size;
		}

		/// <summary>
		/// Load an image file as a texture.
		/// </summary>
		/// <returns>Loaded texture</returns>
		/// <param name="path">File path.</param>
		public static Texture2D LoadFrom(string path)
		{
			return LoadFrom(Image.Load(path));
		}

		/// <summary>
		/// Load an image file as a texture.
		/// </summary>
		/// <returns>Loaded texture</returns>
		/// <param name="stream">File stream.</param>
		public static Texture2D LoadFrom(Stream stream)
		{
			return LoadFrom(Image.Load(stream));
		}

		/// <summary>
		/// Register a texture by a bitmap array.
		/// </summary>
		public static Texture2D Create(byte[,,] bmp)
		{
			var width = bmp.GetLength(0);
			var height = bmp.GetLength(1);
			var arr = new byte[width * height * 4];
			for (int y = 0, i = 0; y < height; y++)
				for (var x = 0; x < width; x++)
				{
					for (var j = 0; j < 4; j++)
						arr[i++] = bmp[x, y, j];
				}
			return Create(arr, width, height);
		}

		/// <summary>
		/// Register a texture by a bitmap array.
		/// </summary>
		public static Texture2D Create(byte[] bmp, int width, int height)
		{
			var texture = GL.GenTexture();
			GL.BindTexture(TextureTarget.Texture2D, texture);

			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
			GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, width, height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Rgba, PixelType.UnsignedByte, bmp);
			return new Texture2D(texture, new VectorInt(width, height));
		}

		/// <summary>
		/// Generate a solid color texture with specified color and size.
		/// </summary>
		/// <returns>Generated texture.</returns>
		public static Texture2D CreateSolid(SD.Color color, int sizeX, int sizeY)
		{
			var arr = new byte[sizeX, sizeY, 4];

			for (var y = 0; y < sizeY; y++)
				for (var x = 0; x < sizeX; x++)
				{
					arr[x, y, 0] = color.R;
					arr[x, y, 1] = color.G;
					arr[x, y, 2] = color.B;
					arr[x, y, 3] = color.A;
				}
			return Create(arr);
		}

		/// <summary>
		/// Generate a solid color texture with specified color and size.
		/// </summary>
		/// <returns>Generated texture.</returns>
		public static Texture2D CreateSolid(SD.Color color, VectorInt size) => CreateSolid(color, size.X, size.Y);

		/// <summary>
		/// Reads an image file and cuts it out in order from the top left at the specified size.
		/// </summary>
		/// <returns>All the image data cut out.</returns>
		/// <param name="path">File path</param>
		/// <param name="horizonalCount">The number of images in the horizontal direction.</param>
		/// <param name="verticalCount">The number of images in the vertical direction.</param>
		/// <param name="sizeOfCroppedImage">The size of a piece of image.</param>
		public static Texture2D[] LoadAndSplitFrom(string path, int horizonalCount, int verticalCount, VectorInt sizeOfCroppedImage)
		{
			return LoadAndSplitFrom(Image.Load(path), horizonalCount, verticalCount, sizeOfCroppedImage);
		}

		/// <summary>
		/// Reads an image file and cuts it out in order from the top left at the specified size.
		/// </summary>
		/// <returns>All the image data cut out.</returns>
		/// <param name="stream">File stream</param>
		/// <param name="horizonalCount">The number of images in the horizontal direction.</param>
		/// <param name="verticalCount">The number of images in the vertical direction.</param>
		/// <param name="sizeOfCroppedImage">The size of a piece of image.</param>
		public static Texture2D[] LoadAndSplitFrom(Stream stream, int horizonalCount, int verticalCount, VectorInt sizeOfCroppedImage)
		{
			return LoadAndSplitFrom(Image.Load(stream), horizonalCount, verticalCount, sizeOfCroppedImage);
		}

		internal static Texture2D LoadFrom(Image bmp)
		{
			using (bmp)
			using (var img = bmp.CloneAs<Rgba32>())
			{
				var rgbaBytes = MemoryMarshal.AsBytes(img.GetPixelSpan()).ToArray();
				return Create(rgbaBytes, img.Width, img.Height);
			}
		}

		private static Texture2D[] LoadAndSplitFrom(Image bmp, int horizonalCount, int verticalCount, VectorInt sizeOfCroppedImage)
		{
			using (bmp)
			using (var img = bmp.CloneAs<Rgba32>())
			{
				var datas = new List<Texture2D>();

				for (int y = 0; y < verticalCount; y++)
				{
					for (int x = 0; x < horizonalCount; x++)
					{
						(var px, var py) = (x * sizeOfCroppedImage.X, y * sizeOfCroppedImage.Y);
						if (px + sizeOfCroppedImage.X > img.Width)
						{
							throw new ArgumentException(nameof(horizonalCount));
						}
						if (py + sizeOfCroppedImage.Y > img.Height)
						{
							throw new ArgumentException(nameof(verticalCount));
						}
						using var cropped = img.Clone(ctx => ctx.Crop(new Rectangle(px, py, sizeOfCroppedImage.X, sizeOfCroppedImage.Y)));
						datas.Add(LoadFrom(cropped));
					}
				}
				return datas.ToArray();
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
