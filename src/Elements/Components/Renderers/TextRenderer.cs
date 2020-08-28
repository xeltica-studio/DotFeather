using System.Drawing;

namespace DotFeather
{
	public class TextRenderer : Component
	{
		public Texture2D RenderedTexture => texture;

		public VectorInt Size => texture.Size;

		public int Width => Size.X;

		public int Height => Size.Y;

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

		public TextRenderer() : this("") { }

		public TextRenderer(string text) : this(text, DFFont.GetDefault(16)) { }

		public TextRenderer(string text, DFFont font) : this(text, font, null) { }

		public TextRenderer(string text, DFFont font, Color? color)
		{
			this.text = text;
			this.font = font;
			textColor = color;

			RenderTexture();
		}

		public override void OnRender()
		{
			if (Transform == null) return;
			TextureDrawer.Draw(texture, Transform.GlobalLocation, Transform.GlobalScale);
		}

		public override void OnDestroy()
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
