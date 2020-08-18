using System.Drawing;
using System.IO;

namespace DotFeather
{
	public class SpriteRenderer : Component
	{
		public Texture2D Texture { get; set; }

		public Color TintColor { get; set; } = Color.White;

		public VectorInt? Size
		{
			get => (Width is int w && Height is int h) ? (w, h) : default;
			set => (Width, Height) = (value?.X, value?.Y);
		}

		public int? Width { get; set; }
		public int? Height { get; set; }

		public SpriteRenderer(Texture2D texture)
		{
			Texture = texture;
		}

		public SpriteRenderer(string path)
		{
			Texture = Texture2D.LoadFrom(path);
			hasGeneratedTexture = true;
		}

		public SpriteRenderer(Stream stream)
		{
			Texture = Texture2D.LoadFrom(stream);
			hasGeneratedTexture = true;
		}

		public override void OnRender()
		{
			if (Transform == null) return;
			TextureDrawer.Draw(Texture, Transform.GlobalLocation, Transform.GlobalScale, 0, TintColor, Width, Height);
		}

		public override void OnDestroy()
		{
			if (hasGeneratedTexture)
				Texture.Dispose();
		}

		private readonly bool hasGeneratedTexture;
	}
}
