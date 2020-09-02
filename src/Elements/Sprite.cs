using System.Drawing;
using System.IO;

namespace DotFeather
{
	public class Sprite : ElementBase
	{
		public Texture2D? Texture { get; set; }

		public Color? TintColor { get; set; }

		public override VectorInt Size
		{
			get => size ?? Texture?.Size ?? (0, 0);
			set => size = value;
		}

		public Sprite() { }

		public Sprite(Texture2D texture)
		{
			Texture = texture;
		}

		public Sprite(string path)
		{
			Texture = generatedTexture = Texture2D.LoadFrom(path);
		}

		public Sprite(Stream stream)
		{
			Texture = generatedTexture = Texture2D.LoadFrom(stream);
		}

		public void ResetSize()
		{
			size = null;
		}

		protected override void OnRender()
		{
			if (!(Texture is Texture2D tex)) return;
			TextureDrawer.Draw(tex, AbsoluteLocation, AbsoluteScale, TintColor, Width, Height);
		}

		protected override void OnDestroy()
		{
			if (generatedTexture != null)
				generatedTexture.Value.Dispose();
		}

		private readonly Texture2D? generatedTexture;
		private VectorInt? size;
	}
}
