using System.Drawing;
using System.IO;

namespace DotFeather
{
	/// <summary>
	/// Provide rendering 9-sliced texture.
	/// </summary>
	public class NineSliceSpriteRenderer : Component
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

		/// <summary>
		/// Get or set size.
		/// </summary>
		/// <value></value>
		public VectorInt Size
		{
			get => (Width is int w && Height is int h) ? (w, h) : default;
			set => (Width, Height) = (value.X, value.Y);
		}

		public int Width { get; set; }
		public int Height { get; set; }

		public NineSliceSpriteRenderer(Texture9Sliced texture)
		{
			Texture = texture;
			Size = Texture.Size;
		}

		public NineSliceSpriteRenderer(string path, int left, int top, int right, int bottom)
		{
			Texture = Texture9Sliced.LoadFrom(path, left, top, right, bottom);
			hasGeneratedTexture = true;
			Size = Texture.Size;
		}

		public NineSliceSpriteRenderer(Stream stream, int left, int top, int right, int bottom)
		{
			Texture = Texture9Sliced.LoadFrom(stream, left, top, right, bottom);
			hasGeneratedTexture = true;
			Size = Texture.Size;
		}

		public override void OnRender()
		{
			if (Transform == null) return;

			var left = Texture.TopLeft.Size.X;
			var right = Texture.TopRight.Size.X;
			var top = Texture.TopLeft.Size.Y;
			var bottom = Texture.BottomLeft.Size.Y;

			var xSpan = Width - left - right;
			var ySpan = Height - top - bottom;
			var loc = Transform.GlobalLocation;
			var scale = Transform.GlobalScale;

			void Draw(Texture2D tex, Vector location, float? width = null, float? height = null)
			{
				TextureDrawer.Draw(tex, loc + location * scale, scale, TintColor, width, height);
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

		public override void OnDestroy()
		{
			if (hasGeneratedTexture)
				Texture.Dispose();
		}

		private readonly bool hasGeneratedTexture;
	}
}
