using System.IO;

namespace DotFeather
{
	public static class ComponentFactory
	{
		public static Element Sprite(string name, Texture2D texture, params Element[] children)
		{
			return new Element(name, children).With(new SpriteRenderer(texture));
		}

		public static Element Sprite(string name, string path, params Element[] children)
		{
			return new Element(name, children).With(new SpriteRenderer(path));
		}

		public static Element Sprite(string name, Stream stream, params Element[] children)
		{
			return new Element(name, children).With(new SpriteRenderer(stream));
		}
	}
}
