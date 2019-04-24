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
	public class TextDrawable : IDrawable
	{
		/// <summary></summary>
		public int ZOrder { get; set; }
		/// <summary></summary>
		public string Name { get; set; }
		/// <summary></summary>
		public Vector Location { get; set; }
		/// <summary></summary>
		public float Angle { get; set; } = 0;
		/// <summary></summary>
		public Vector Scale { get; set; } = new Vector(1, 1);

		/// <summary>
		/// 描画されるテキストをテクスチャとして取得します。
		/// </summary>
		/// <value></value>
		public Texture2D RenderedTexture { get; private set; }

		/// <summary>
		/// 描画されるテキストを取得または設定します。
		/// </summary>
		/// <value></value>
		public string Text
		{
			get => text;
			set
			{
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
				font = value;
				UpdateTexture();
			}
		}

		/// <summary>
		/// 描画色を取得または設定します。
		/// </summary>
		/// <value></value>
		public Color Color
		{
			get => color;
			set
			{
				color = value;
				UpdateTexture();
			}
		}

		/// <summary>
		/// <see cref="TextDrawable"/> の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="text"></param>
		/// <param name="font"></param>
		/// <param name="color"></param>
		public TextDrawable(string text, Font font = default, Color color = default)
		{
			this.text = text;
			this.font = font;
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
			g.InterpolationMode = InterpolationMode.NearestNeighbor;
			g.SmoothingMode = SmoothingMode.None;
			g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
			g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
			g.DrawString(Text, Font, new SolidBrush(Color), 0, 0, StringFormat.GenericTypographic);

			RenderedTexture.Dispose();
			RenderedTexture = Texture2D.LoadFrom(bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb));
			bmp.Dispose();
		}

		/// <summary>
		/// この <see cref="TextDrawable"/> を破棄します。
		/// </summary>
		public void Destroy()
		{
			RenderedTexture.Dispose();
		}

		/// <summary>
		/// 描画します。
		/// </summary>
		public void Draw(GameBase game, Vector location)
		{
			TextureDrawer.Draw(game, RenderedTexture, location + Location, Scale, Angle);
		}

		private string text;
		private Font font;
		private Color color;
	}
}
