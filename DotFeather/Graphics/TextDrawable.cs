using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace DotFeather
{
	/// <summary>
	/// テキストを描画する <see cref="IDrawable"/> オブジェクトです。
	/// </summary>
	public class TextDrawable : TextureDrawableBase
	{
		/// <summary>
		/// 描画されるテキストを取得または設定します。
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
		/// 描画に使用するフォントを取得または設定します。
		/// </summary>
		/// <value></value>
		public Font Font
		{
			get => font;
			set
			{
				if (font == value)
					return;
				font = value;
				UpdateTexture();
			}
		}

		/// <summary>
		/// 描画色を取得または設定します。
		/// </summary>
		/// <value></value>
		public override Color? Color
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
		/// Same as <see cref="TextureDrawableBase.Texture"/>
		/// </summary>
		public Texture2D RenderedTexture
		{
			get => Texture;
			private set => Texture = value;
		}

		/// <summary>
		/// <see cref="TextDrawable"/> の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="text"></param>
		/// <param name="font"></param>
		/// <param name="color"></param>
		public TextDrawable(string text, Font? font = null, Color? color = default)
		{
			this.text = text;
			this.font = font ?? new Font(FontFamily.GenericSansSerif, 16);
			this.color = color;
			this.UpdateTexture();
		}

		/// <summary>
		/// テクスチャを更新します。
		/// </summary>
		public void UpdateTexture()
		{
			var bmp = new Bitmap(32, 32);
			var g = Graphics.FromImage(bmp);

			SizeF size = g.MeasureString(text, font);
			size += new Size(8, 8);
			bmp.Dispose();
			bmp = new Bitmap((int)size.Width, (int)size.Height);
			g = Graphics.FromImage(bmp);
			g.DrawString(Text, Font, new SolidBrush(Color ?? System.Drawing.Color.Black), 0, 0, StringFormat.GenericDefault);

			Texture.Dispose();
			Texture = Texture2D.LoadFrom(bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb));
			Width = bmp.Width;
			Height = bmp.Height;
			bmp.Dispose();
		}

		/// <summary>
		/// このオブジェクトを破棄します。
		/// </summary>
		public override void Destroy()
		{
			Texture.Dispose();
		}

		private string text;
		private Font font;
		private Color? color;
	}
}
