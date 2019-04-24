using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace DotFeather
{
    public class TextDrawable : IDrawable
    {
        public int ZOrder { get; set; }
        public string Name { get; set; }
        public Vector Location { get; set; }
        public float Angle { get; set; } = 0;
        public Vector Scale { get; set; } = new Vector(1, 1);
        public Texture2D RenderedTexture { get; private set; }

		public string Text
		{
			get => text;
			set
			{
				text = value;
				UpdateTexture();
			}
        }
        public Font Font
        {
            get => font;
            set
            {
                font = value;
                UpdateTexture();
            }
        }

        public Color Color
        {
            get => color;
            set
            {
                color = value;
                UpdateTexture();
            }
        }

		public TextDrawable(string text, Font font = default, Color color = default)
		{
            this.text = text;
            this.font = font;
			this.color = color;
            this.UpdateTexture();
		}

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

        public void Destroy()
        {
			RenderedTexture.Dispose();
        }

        public void Draw(GameBase game, Vector location)
        {
			TextureDrawer.Draw(game, RenderedTexture, location + Location, Scale, Angle);
        }

		private string text;
        private Font font;
        private Color color;
    }
}
