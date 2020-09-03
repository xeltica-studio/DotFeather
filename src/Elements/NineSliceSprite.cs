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

		protected override void OnRender()
		{
			var left = Texture.TopLeft.Size.X;
			var right = Texture.TopRight.Size.X;
			var top = Texture.TopLeft.Size.Y;
			var bottom = Texture.BottomLeft.Size.Y;

			var xSpan = Width - left - right;
			var ySpan = Height - top - bottom;
			var loc = AbsoluteLocation;
			var scale = AbsoluteScale;

			void Draw(Texture2D tex, Vector location, float? width = null, float? height = null)
			{
				DF.TextureDrawer.Draw(tex, loc + location * scale, scale, TintColor, width, height);
			}

			// 9枚を全て描画する
			Draw(Texture.TopLeft, (0, 0));
			Draw(Texture.TopCenter, Vector.Right * left, xSpan);
			Draw(Texture.TopRight, Vector.Right * (left + xSpan));
			Draw(Texture.MiddleLeft, Vector.Down * top, null, ySpan);
			Draw(Texture.MiddleCenter, (left, top), xSpan, ySpan);
			Draw(Texture.MiddleRight, (left + xSpan, top), null, ySpan);
			Draw(Texture.BottomLeft, (0, top + ySpan), null);
			Draw(Texture.BottomCenter, (left, top + ySpan), xSpan);
			Draw(Texture.BottomRight, (left + xSpan, top + ySpan), null);
		}

		protected override void OnDestroy()
		{
			generatedTexture?.Dispose();
		}

		private readonly Texture9Sliced? generatedTexture;
	}
}
