using System.Drawing;

namespace DotFeather
{
	public class TextElement : PrimitiveElement<TextRenderer>
	{
		public Texture2D? RenderedTexture { get => component.RenderedTexture; }

		public int Width { get => component.Width; }

		public int Height { get => component.Height; }

		public VectorInt Size { get => component.Size; }

		public Color? BorderColor { get => component.BorderColor; set => component.BorderColor = value; }

		public int BorderThickness { get => component.BorderThickness; set => component.BorderThickness = value; }

		public Color? Color { get => component.Color; set => component.Color = value; }

		public DFFont Font { get => component.Font; set => component.Font = value; }

		public string Text { get => component.Text; set => component.Text = value; }

		public TextElement(string text, float size = 16, DFFontStyle style = DFFontStyle.Normal, Color? color = null) : this(text, DFFont.GetDefault(size, style), color) { }

		public TextElement(string text, DFFont font, Color? color = null, params Element[] children) : base("", children)
		{
			AddComponent(component = new TextRenderer(text, font, color));
		}
	}
}
