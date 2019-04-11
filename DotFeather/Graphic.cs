using System;
using System.Collections.Generic;
using System.Drawing;
using DotFeather.Drawable;
using DotFeather.Models;
using OpenTK.Graphics.OpenGL;

namespace DotFeather
{
	/// <summary>
	/// 図形描画を行える、グラフィック用のレイヤーです。
	/// </summary>
	public class Graphic : IDrawable
	{
		/// <summary>
		/// 現在の <see cref="Graphic"/> が持つ描画オブジェクトのリストを取得します。
		/// </summary>
		/// <value>描画可能オブジェクトのリスト。</value>
		public List<IDrawable> Drawables { get; } = new List<IDrawable>();

		public Vector Location { get; set; }
		public float Angle { get; set; }
		public Vector Scale { get; set; }
		public int ZOrder { get; set; }
		public string Name { get; set; }

		/// <summary>
		/// 実際に画面へ描画を行います。
		/// </summary>
		/// <param name="game">Game.</param>
		public void Draw(GameBase game, Vector location)
		{
			// Drawables を用いて毎フレーム描画を行う
			Drawables.ForEach(d => d.Draw(game, Location + location));
		}

		/// <summary>
		/// 点を描画します。
		/// </summary>
		/// <param name="pos">座標.</param>
		/// <param name="color">色.</param>
		public Graphic Pixel(Point pos, Color color)
		{
			Drawables.Add(new PrimitiveDrawable(color.ToGL(), PrimitiveType.Points, ((PointF)pos).ToGL()));
			return this;
		}

		/// <summary>
		/// 点を描画します。
		/// </summary>
		/// <param name="x">Z座標。</param>
		/// <param name="y">Y座標。</param>
		/// <param name="color">色.</param>
		public Graphic Pixel(int x, int y, Color color)
		{
			return Pixel(new Point(x, y), color);
		}

		/// <summary>
		/// 線を描画します。
		/// </summary>
		/// <param name="begin">始点の座標.</param>
		/// <param name="end">終点の座標.</param>
		/// <param name="color">色.</param>
		public Graphic Line(Point begin, Point end, Color color)
		{
			Drawables.Add(new PrimitiveDrawable(color.ToGL(), PrimitiveType.Lines, ((PointF)begin).ToGL(), ((PointF)end).ToGL()));
            return this;
		}

		/// <summary>
		/// 線を描画します。
		/// </summary>
		/// <param name="x1">始点のX座標。</param>
		/// <param name="y1">始点のY座標。</param>
		/// <param name="x2">終点のX座標。</param>
		/// <param name="y2">終点のX座標。</param>
		/// <param name="color">色.</param>
		public Graphic Line(int x1, int y1, int x2, int y2, Color color)
		{
			return Line(new Point(x1, y1), new Point(x2, y2), color);
		}

		/// <summary>
		/// 矩形を描画します。
		/// </summary>
		/// <param name="begin">始点の座標.</param>
		/// <param name="end">終点の座標.</param>
		/// <param name="color">色.</param>
		public Graphic Rect(Point begin, Point end, Color color)
		{
			return Rect(begin.X, begin.Y, end.X, end.Y, color);
		}

		/// <summary>
		/// 矩形を描画します。
		/// </summary>
		/// <param name="x1">始点のX座標。</param>
		/// <param name="y1">始点のY座標。</param>
		/// <param name="x2">終点のX座標。</param>
		/// <param name="y2">終点のX座標。</param>
		/// <param name="color">色.</param>
		public Graphic Rect(int x1, int y1, int x2, int y2, Color color)
		{
			Drawables.Add(new PrimitiveDrawable(color.ToGL(), PrimitiveType.Quads,
				new OpenTK.PointF(x1, y1), 
				new OpenTK.PointF(x1, y2), 
				new OpenTK.PointF(x2, y2),
				new OpenTK.PointF(x2, y1)));
            return this;
		}

        public Graphic Polygon(int x1, int y1, int x2, int y2, Color color)
        {
            Drawables.Add(new PrimitiveDrawable(color.ToGL(), PrimitiveType.Quads,
                new OpenTK.PointF(x1, y1),
                new OpenTK.PointF(x1, y2),
                new OpenTK.PointF(x2, y2),
                new OpenTK.PointF(x2, y1)));
            return this;
        }

		/// <summary>
		/// テクスチャを描画します。
		/// </summary>
		/// <param name="x">The first x value.</param>
		/// <param name="y">The first y value.</param>
		/// <param name="texture">テクスチャ。</param>
		public Graphic Texture(int x, int y, Texture2D texture)
		{
			Drawables.Add(new Sprite(texture, x, y));
            return this;
		}

		/// <summary>
		/// このグラフィックレイヤーを削除します。
		/// </summary>
		public Graphic Clear()
		{
			Drawables.Clear();
			return this;
		}

		public void Destroy() => Drawables.ForEach(d => d.Destroy());

		public class PolygonContext
		{
			List<OpenTK.PointF> list;
			Graphic ctx;
			OpenTK.Color? color;
			internal PolygonContext(Graphic ctx, Color? color)
			{
				list = new List<OpenTK.PointF>();
				this.ctx = ctx;
				this.color = color?.ToGL();
			}

			public PolygonContext Add(Point vertex)
			{
				list.Add(((PointF)vertex).ToGL());
				return this;
			}

			public Graphic Commit()
			{
				ctx.Drawables.Add(new PrimitiveDrawable(color ?? OpenTK.Color.Black, PrimitiveType.Polygon, list.ToArray()));
				return ctx;
			}
		}
	}
}
