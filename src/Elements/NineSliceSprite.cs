using System.Drawing;
using System.IO;

namespace DotFeather
{
	public class NineSliceSprite : ElementBase
	{
		/// <summary>
		/// Get or set the texture.
		/// </summary>
		/// <value></value>
		public Texture9Sliced Texture { get; set; }

		/// <summary>
		/// Get or set the tint color.
		/// </summary>
		/// <value></value>
		public Color TintColor { get; set; } = Color.White;

		public NineSliceSprite(Texture9Sliced texture)
		{
			Texture = texture;
			Size = Texture.Size;
		}

		public NineSliceSprite(string path, int left, int top, int right, int bottom)
		{
			generatedTexture = Texture = Texture9Sliced.LoadFrom(path, left, top, right, bottom);
			Size = Texture.Size;
		}

		public NineSliceSprite(Stream stream, int left, int top, int right, int bottom)
		{
			generatedTexture = Texture = Texture9Sliced.LoadFrom(stream, left, top, right, bottom);
			Size = Texture.Size;
		}

		protected override void OnDestroy()
		{
			generatedTexture?.Dispose();
		}

		private readonly Texture9Sliced? generatedTexture;
	}
}
