using System.Drawing;
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

		public static Element NineSliceSprite(string name, Texture9Sliced texture, params Element[] children)
		{
			return new Element(name, children).With(new NineSliceSpriteRenderer(texture));
		}

		public static Element NineSliceSprite(string name, string path, int left, int top, int right, int bottom, params Element[] children)
		{
			return new Element(name, children).With(new NineSliceSpriteRenderer(path, left, top, right, bottom));
		}

		public static Element NineSliceSprite(string name, Stream stream, int left, int top, int right, int bottom, params Element[] children)
		{
			return new Element(name, children).With(new NineSliceSpriteRenderer(stream, left, top, right, bottom));
		}

		public static Element Text(string name, params Element[] children)
		{
			return new Element(name, children).With(new TextRenderer());
		}

		public static Element Text(string name, string text, params Element[] children)
		{
			return new Element(name, children).With(new TextRenderer(text));
		}

		public static Element Text(string name, string text, DFFont font, params Element[] children)
		{
			return new Element(name, children).With(new TextRenderer(text, font));
		}

		public static Element Text(string name, string text, DFFont font, Color color, params Element[] children)
		{
			return new Element(name, children).With(new TextRenderer(text, font, color));
		}

		public static Element Tilemap(string name, VectorInt tileSize, params Element[] children)
		{
			return new Element(name, children).With(new TilemapRenderer(tileSize));
		}
	}
}
