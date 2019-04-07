using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;

namespace DotFeather.Models
{
	/// <summary>
	/// テクスチャのハンドルを持ちます。
	/// </summary>
	public struct Texture2D
	{
        /// <summary>
        /// このテクスチャの OpenGL ハンドルを取得します。
        /// </summary>
		public int Handle { get; }

        /// <summary>
        /// このテクスチャのサイズを取得します。
        /// </summary>
		public Size Size { get; }

		internal Texture2D(int handle, Size size)
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
            using (var file = new Bitmap(path))
            {
                return RegisterTexture(file.LockBits(new Rectangle(0, 0, file.Width, file.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb));
            }
        }

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
            using (var file = new Bitmap(path))
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
                        datas.Add(RegisterTexture(locked));
                        file.UnlockBits(locked);
                    }
                }
                return datas.ToArray();
            }
        }



        /// <summary>
        /// テクスチャを登録し、ハンドルを返します。
        /// </summary>
        private static Texture2D RegisterTexture(BitmapData bmp)
        {
            var texture = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, texture);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmp.Width, bmp.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmp.Scan0);
            return new Texture2D(texture, new Size(bmp.Width, bmp.Height));
        }
	}
}
