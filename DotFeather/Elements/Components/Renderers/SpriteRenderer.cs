using System.Drawing;
using System.IO;

namespace DotFeather
{
	public class SpriteRenderer : Component
	{
		public Texture2D? Texture { get; set; }

		public Color? TintColor { get; set; }

		public VectorInt? Size
		{
			get => (Width is int w && Height is int h) ? (w, h) : default;
			set => (Width, Height) = (value?.X, value?.Y);
		}

		public int? Width { get; set; }
		public int? Height { get; set; }

		public SpriteRenderer() { }

		public SpriteRenderer(Texture2D texture)
		{
			Texture = texture;
		}

		public SpriteRenderer(string path)
		{
			Texture = generatedTexture = Texture2D.LoadFrom(path);
		}

		public SpriteRenderer(Stream stream)
		{
			Texture = generatedTexture = Texture2D.LoadFrom(stream);
		}

		public override void OnRender()
		{
			if (Transform == null) return;
			if (!(Texture is Texture2D tex)) return;
			TextureDrawer.Draw(tex, Transform.GlobalLocation, Transform.GlobalScale, TintColor, Width, Height);
		}

		public override void OnDestroy()
		{
			if (generatedTexture != null)
				generatedTexture.Value.Dispose();
		}

		private readonly Texture2D? generatedTexture;
	}
}
