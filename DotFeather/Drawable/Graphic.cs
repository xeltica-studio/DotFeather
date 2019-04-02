using System;
using System.Collections.Generic;
using System.Drawing;
using DotFeather.Drawable;
using OpenTK.Graphics.OpenGL;

namespace DotFeather.Drawable
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

		/// <summary>
		/// 実際に画面へ描画を行います。
		/// </summary>
		/// <param name="game">Game.</param>
		public void Draw(GameBase game)
		{
			// Drawables を用いて毎フレーム描画を行う
			Drawables.ForEach(d => d.Draw(game));
		}

		public int ZOrder { get; set; }
		public string Name { get; set; }


		/// <summary>
		/// 点を描画します。
		/// </summary>
		/// <param name="pos">座標.</param>
		/// <param name="color">色.</param>
		public void Pixel(Point pos, Color color)
		{
			Drawables.Add(new PrimitiveDrawable(color.ToGL(), PrimitiveType.Points, ((PointF)pos).ToGL()));
		}

		/// <summary>
		/// 点を描画します。
		/// </summary>
		/// <param name="x">Z座標。</param>
		/// <param name="y">Y座標。</param>
		/// <param name="color">色.</param>
		public void Pixel(int x, int y, Color color)
		{
			Pixel(new Point(x, y), color);
		}

		/// <summary>
		/// 線を描画します。
		/// </summary>
		/// <param name="begin">始点の座標.</param>
		/// <param name="end">終点の座標.</param>
		/// <param name="color">色.</param>
		public void Line(Point begin, Point end, Color color)
		{
			Drawables.Add(new PrimitiveDrawable(color.ToGL(), PrimitiveType.Lines, ((PointF)begin).ToGL(), ((PointF)end).ToGL()));
		}

		/// <summary>
		/// 線を描画します。
		/// </summary>
		/// <param name="x1">始点のX座標。</param>
		/// <param name="y1">始点のY座標。</param>
		/// <param name="x2">終点のX座標。</param>
		/// <param name="y2">終点のX座標。</param>
		/// <param name="color">色.</param>
		public void Line(int x1, int y1, int x2, int y2, Color color)
		{
			Line(new Point(x1, y1), new Point(x2, y2), color);
		}

		/// <summary>
		/// 矩形を描画します。
		/// </summary>
		/// <param name="begin">始点の座標.</param>
		/// <param name="end">終点の座標.</param>
		/// <param name="color">色.</param>
		public void Rect(Point begin, Point end, Color color)
		{
			Rect(begin.X, begin.Y, end.X, end.Y, color);
		}

		/// <summary>
		/// 矩形を描画します。
		/// </summary>
		/// <param name="x1">始点のX座標。</param>
		/// <param name="y1">始点のY座標。</param>
		/// <param name="x2">終点のX座標。</param>
		/// <param name="y2">終点のX座標。</param>
		/// <param name="color">色.</param>
		public void Rect(int x1, int y1, int x2, int y2, Color color)
		{
			Drawables.Add(new PrimitiveDrawable(color.ToGL(), PrimitiveType.Quads,
				new OpenTK.PointF(x1, y1), 
				new OpenTK.PointF(x1, y2), 
				new OpenTK.PointF(x2, y2),
				new OpenTK.PointF(x2, y1)));
		}

		/// <summary>
		/// テクスチャを描画します。
		/// </summary>
		/// <param name="x">The first x value.</param>
		/// <param name="y">The first y value.</param>
		/// <param name="texture">テクスチャ。</param>
		public void Texture(int x, int y, Texture2D texture)
		{
			Drawables.Add(new Sprite(texture, x, y));
		}

		/// <summary>
		/// このグラフィックレイヤーを削除します。
		/// </summary>
		public void Clear()
		{
			Drawables.Clear();
		}

		public void Text(Rectangle range, string text, Color color, Font font = default)
		{
			//todo Implement this.
			// Use https://github.com/opcon/QuickFont

			throw new NotImplementedException("Wait!");
		}
	}
}
