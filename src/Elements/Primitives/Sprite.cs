using System.Drawing;
using System.IO;

namespace DotFeather
{
	public class Sprite : PrimitiveElement<SpriteRenderer>
	{
		public Texture2D? Texture
		{
			get => component.Texture;
			set => component.Texture = value;
		}

		public int? Width { get => component.Width; set => component.Width = value; }

		public int? Height { get => component.Height; set => component.Height = value; }

		public VectorInt? Size { get => component.Size; set => component.Size = value; }

		public Color? TintColor { get => component.TintColor; set => component.TintColor = value; }

		public Sprite() : base()
		{
			AddComponent(component = new SpriteRenderer());
		}

		public Sprite(Texture2D texture) : base("")
		{
			AddComponent(component = new SpriteRenderer(texture));
		}

		public Sprite(Texture2D texture, params Element[] children) : base("", children)
		{
			AddComponent(component = new SpriteRenderer(texture));
		}

		public Sprite(string path)
		{
			AddComponent(component = new SpriteRenderer(path));
		}

		public Sprite(Stream stream)
		{
			AddComponent(component = new SpriteRenderer(stream));
		}
	}
}
