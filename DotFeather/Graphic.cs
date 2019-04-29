using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using static DotFeather.MiscUtility;

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

		/// <summary></summary>
		public Vector Location { get; set; }
		/// <summary></summary>
		public float Angle { get; set; }
		/// <summary></summary>
		public Vector Scale { get; set; }
		/// <summary></summary>
		public int ZOrder { get; set; }
		/// <summary></summary>
		public string Name { get; set; }

		/// <summary>
		/// 実際に画面へ描画を行います。
		/// </summary>
		public void Draw(GameBase game, Vector location)
		{
			// Drawables を用いて毎フレーム描画を行う
			for (var i = Drawables.Count - 1; i >= 0; i--)
				Drawables[i].Draw(game, Location + location);
		}

		/// <summary>
		/// 点を描画します。
		/// </summary>
		/// <param name="pos">座標.</param>
		/// <param name="color">色.</param>
		public Graphic Pixel(Point pos, Color color)
		{
			Drawables.Add(new PrimitiveDrawable(color.ToGL(), PrimitiveType.Points, 0, null, ((PointF)pos).ToGL()));
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
			Drawables.Add(new PrimitiveDrawable(color.ToGL(), PrimitiveType.Lines, 0, null, ((PointF)begin).ToGL(), ((PointF)end).ToGL()));
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
		/// <param name="lineWidth">線の幅。</param>
		/// <param name="lineColor">線の色。</param>
		public Graphic Rect(Point begin, Point end, Color color, int lineWidth = 0, Color? lineColor = default)
		{
			return Rect(begin.X, begin.Y, end.X, end.Y, color, lineWidth, lineColor);
		}

		/// <summary>
		/// 矩形を描画します。
		/// </summary>
		/// <param name="x1">始点のX座標。</param>
		/// <param name="y1">始点のY座標。</param>
		/// <param name="x2">終点のX座標。</param>
		/// <param name="y2">終点のX座標。</param>
		/// <param name="color">色.</param>
		/// <param name="lineWidth">線の幅。</param>
		/// <param name="lineColor">線の色。</param>
		public Graphic Rect(int x1, int y1, int x2, int y2, Color color, int lineWidth = 0, Color? lineColor = default)
		{
			Drawables.Add(new PrimitiveDrawable(color.ToGL(), PrimitiveType.Quads, lineWidth, lineColor?.ToGL(),
				new OpenTK.PointF(x1, y1),
				new OpenTK.PointF(x1, y2),
				new OpenTK.PointF(x2, y2),
				new OpenTK.PointF(x2, y1)));
			return this;
		}

		/// <summary>
		/// 三角形を描画します。
		/// </summary>
		public Graphic Triangle(int x1, int y1, int x2, int y2, int x3, int y3, Color color, int lineWidth = 0, Color? lineColor = default)
		{
			Drawables.Add(new PrimitiveDrawable(color.ToGL(), PrimitiveType.Triangles,lineWidth, lineColor?.ToGL(),
				new OpenTK.PointF(x1, y1),
				new OpenTK.PointF(x2, y2),
				new OpenTK.PointF(x3, y3)));
			return this;
		}

		/// <summary>
		/// 三角形を描画します。
		/// </summary>
		public Graphic Triangle(Point p1, Point p2, Point p3, Color color, int lineWidth = 0, Color? lineColor = default)
		{
			return Triangle(p1.X, p1.Y, p2.X, p2.Y, p3.X, p3.Y, color, lineWidth, lineColor);
		}

		/// <summary>
		/// 楕円を描画します。
		/// </summary>
		public Graphic Ellipse(int x1, int y1, int x2, int y2, Color color, int lineWidth = 0, Color? lineColor = default)
		{
			var list = new List<OpenTK.PointF>();

			if (x1 > x2) Swap(ref x1, ref x2);
			if (y1 > y2) Swap(ref y1, ref y2);

			var (width, height) = (x2 - x1, y2 - y1);

			// 大きさに応じて頂点数いじる
			var verts = Math.Min(360, (width + height) / 10);

			for (int i = 0; i < 360; i += 360 / verts)
			{
				var (rw, rh) = (width / 2, height / 2);
				var (ox, oy) = (x1 + rw, y1 + rh);

				list.Add(new OpenTK.PointF(
					(float)(Math.Cos(DFMath.ToRadian(i)) * rw + ox),
					(float)(Math.Sin(DFMath.ToRadian(i)) * rh + oy)
				));

			}

			Drawables.Add(new PrimitiveDrawable(color.ToGL(), PrimitiveType.Polygon, lineWidth, lineColor?.ToGL(), list.ToArray()));
			return this;
		}

		/// <summary>
		/// 楕円を描画します。
		/// </summary>
		public Graphic Ellipse(Point p1, Point p2, Color color, int lineWidth = 0, Color? lineColor = default)
		{
			return Ellipse(p1.X, p1.Y, p2.X, p2.Y, color, lineWidth, lineColor);
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
            Drawables.ForEach(d => d.Destroy());
			Drawables.Clear();
			return this;
		}

		/// <summary>
		/// この <see cref="Graphic"/> を削除します。
		/// </summary>
		public void Destroy() => Clear();
	}
}
