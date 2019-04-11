using System;
using OpenTK;
using System.Linq;
using OpenTK.Graphics.OpenGL;
using DotFeather.Helpers;

namespace DotFeather.Drawable
{
	/// <summary>
	/// <see cref="Graphic"/> クラスで内部的に使用されるオブジェクトです。
	/// </summary>
	internal class PrimitiveDrawable : IDrawable
	{
		/// <summary>
		/// 頂点のバッファーを取得します。
		/// </summary>
		public Vector2[] Buffer { get; }

		/// <summary>
		/// この <see cref="PrimitiveDrawable"/> のプリミティブタイプを取得します。
		/// </summary>
		public PrimitiveType Primitive { get; }
		
		public int ZOrder { get; set; }
		public string Name { get; set; }
		public Vector Location { get; set; }
		public float Angle { get; set; }
		public Vector Scale { get; set; }

		public PrimitiveDrawable(Color c, PrimitiveType primitive, params PointF[] vertexs)
		{
			color = c;

			Buffer = vertexs.Select(v => new Vector2(v.X, v.Y)).ToArray();
			Primitive = primitive;
		}

		public virtual void Draw(GameBase game, Vector location)
		{
			if (Buffer == null)
				throw new InvalidOperationException("Buffer is null(It seems be a bug.)");

			var hw = game.Width / 2;
			var hh = game.Height / 2;

			using (new GLContext(Primitive))
			{
				foreach (var dp in Buffer)
				{
					var vec = dp + new Vector2(Location.X + location.X, Location.Y + location.Y);
					// Convert device point to viewport point
					var vp = vec.ToViewportPoint(hw, hh);
					GL.Color4(color);
					GL.Vertex2(vp);
				}
			}
        }

        private readonly Color color;

		public void Destroy() { }
    }

}
