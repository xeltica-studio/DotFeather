using System.Drawing;

namespace DotFeather
{
	public class TextElement : ElementBase
	{
		public Texture2D RenderedTexture => texture;

		public override VectorInt Size { get => texture.Size; set { /* nop */ } }

		public string Text
		{
			get => text;
			set => Set(ref text, value);
		}

		public Color? Color
		{
			get => textColor;
			set => Set(ref textColor, value);
		}

		public Color? BorderColor
		{
			get => borderColor;
			set => Set(ref borderColor, value);
		}

		public int BorderThickness
		{
			get => borderThickness;
			set => Set(ref borderThickness, value);
		}

		public DFFont Font
		{
			get => font;
			set => Set(ref font, value);
		}

		public TextElement() : this("") { }

		public TextElement(string text) : this(text, DFFont.GetDefault(16)) { }

		public TextElement(string text, DFFont font) : this(text, font, null) { }

		public TextElement(string text, DFFont font, Color? color)
		{
			this.text = text;
			this.font = font;
			textColor = color;

			RenderTexture();
		}

		public TextElement(string text, float fontSize) : this(text, fontSize, DFFontStyle.Normal) { }

		public TextElement(string text, float fontSize, DFFontStyle fontStyle) : this(text, fontSize, fontStyle, null) { }

		public TextElement(string text, float fontSize, DFFontStyle fontStyle, Color? color) : this(text, DFFont.GetDefault(fontSize, fontStyle), color) { }

		protected override void OnRender()
		{
			TextureDrawer.Draw(texture, AbsoluteLocation, AbsoluteScale);
		}

		protected override void OnDestroy()
		{
			texture.Dispose();
		}

		private void Set<T>(ref T variable, T value)
		{
			if (variable?.Equals(value) ?? false) return;
			variable = value;
			RenderTexture();
		}

		private void RenderTexture()
		{
			texture.Dispose();

			texture = TextTextureGenerator.Generate(Text, Font, Color, BorderColor, BorderThickness);
		}

		private Texture2D texture;
		private string text = "";
		private Color? textColor;
		private Color? borderColor;
		private int borderThickness;
		private DFFont font;
	}
}
