using System;
using OpenTK;
using System.Linq;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace DotFeather
{
	/// <summary>
	/// <see cref="Graphic"/> クラスで内部的に使用されるオブジェクトです。
	/// </summary>
	internal class PrimitiveDrawable : IDrawable
	{
		/// <summary>
		/// 頂点のバッファーを取得します。
		/// </summary>
		public Vector[] Buffer { get; }

		/// <summary>
		/// この <see cref="PrimitiveDrawable"/> のプリミティブタイプを取得します。
		/// </summary>
		public PrimitiveType Primitive { get; }

		public int ZOrder { get; set; }
		public string Name { get; set; } = "";
		public Vector Location { get; set; }
		public float Angle { get; set; }
		public Vector Scale { get; set; }

		public PrimitiveDrawable(Color c, PrimitiveType primitive, int lineWidth, Color? lineColor, params Vector[] vertexes)
		{
			color = c;
			this.lineWidth = lineWidth;
			this.lineColor = lineColor;

			Buffer = vertexes;
			Primitive = primitive;
		}

		public virtual void Draw(GameBase game, Vector location)
		{
			if (Buffer == null)
				throw new InvalidOperationException("Buffer is null(It seems be a bug.)");
			if (Buffer.Length == 0)
				return;

			var hw = game.Width / 2;
			var hh = game.Height / 2;

			GL.Enable(EnableCap.Blend);
			GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

			if (color.A > 0)
			{
				using (new GLContext(Primitive))
				{
					foreach (var dp in Buffer)
					{
						var vec = dp + Location + location;
						vec *= new Vector(Scale.X, Scale.Y);
						// Convert device point to viewport point
						var vp = vec.ToViewportPoint(hw, hh);
						Vertex(color, vp);
					}
				}
			}

			if (lineWidth > 0 && lineColor is Color lc)
			{
				GL.LineWidth(lineWidth);
				using (new GLContext(PrimitiveType.Lines))
				{
					Vector? prevVertex = null;
					Vector? first = null;
					foreach (var dp in Buffer)
					{
						var vec = dp + Location + location;
						vec *= new Vector(Scale.X, Scale.Y);
						// Convert device point to viewport point
						var vp = vec.ToViewportPoint(hw, hh);
						if (first == null)
							first = vp;

						if (prevVertex is Vector pv)
						{
							var pVp = pv;
							Vertex(lc, pVp);
							Vertex(lc, vp);
						}
						prevVertex = vp;
					}
					Vertex(lc, prevVertex ?? Vector.One);
					Vertex(lc, first ?? Vector.One);
				}
			}

			GL.Disable(EnableCap.Blend);
		}

		public void Destroy() { }

		private void Vertex(Color col, Vector vec)
		{
			GL.Color4(col);
			GL.Vertex2(vec.X, vec.Y);
		}

		private readonly Color color;
		private readonly int lineWidth;
		private readonly Color? lineColor;
	}

}
