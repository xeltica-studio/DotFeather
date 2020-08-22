using System.Drawing;
using System.IO;

namespace DotFeather
{
	public class SpriteRenderer : Component
	{

		public Color? TintColor { get; set; }

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
		}

		public SpriteRenderer(Stream stream)
		{
		}

		public override void OnRender()
		{
			if (Transform == null) return;
		}

		public override void OnDestroy()
		{
		}

	}
}
