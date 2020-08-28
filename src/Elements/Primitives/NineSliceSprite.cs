using System.IO;

namespace DotFeather
{
	public class NineSliceSprite : PrimitiveElement<NineSliceSpriteRenderer>
	{
		public Texture9Sliced Texture { get => component.Texture; set => component.Texture = value; }

		public int Width { get => component.Width; set => component.Width = value; }

		public int Height { get => component.Height; set => component.Height = value; }

		public VectorInt Size { get => component.Size; set => component.Size = value; }

		public NineSliceSprite(Texture9Sliced texture) : base("")
		{
			AddComponent(component = new NineSliceSpriteRenderer(texture));
		}

		public NineSliceSprite(string path, int left, int top, int right, int bottom) : base("")
		{
			AddComponent(component = new NineSliceSpriteRenderer(path, left, top, right, bottom));
		}

		public NineSliceSprite(Stream stream, int left, int top, int right, int bottom, params Element[] children) : base("", children)
		{
			AddComponent(component = new NineSliceSpriteRenderer(stream, left, top, right, bottom));
		}
	}
}
