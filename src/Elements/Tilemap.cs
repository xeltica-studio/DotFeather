using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using static DotFeather.MiscUtility;

namespace DotFeather
{
	public class Tilemap : ElementBase
	{
		/// <summary>
		/// Get or set size of grid.
		/// </summary>
		public VectorInt TileSize { get; set; }

		/// <summary>
		/// Get or set default tint color of tiles.
		/// </summary>
		public Color? DefaultColor { get; set; }

		public Tilemap(VectorInt tileSize)
		{
			TileSize = tileSize;
			tiles = new Dictionary<VectorInt, (ITile tile, Color? color)>();
		}

		/// <summary>
		/// Get or set the tile at the specified position.
		/// </summary>
		public ITile? this[int x, int y]
		{
			get => GetTileAt(x, y);
			set => SetTile(x, y, value);
		}

		/// <summary>
		/// Get or set the tile at the specified position.
		/// </summary>
		public ITile? this[VectorInt point]
		{
			get => GetTileAt(point);
			set => SetTile(point, value);
		}

		protected override void OnRender()
		{
			var gl = AbsoluteLocation;
			var gs = AbsoluteScale;
			// カリング
			bool filter(KeyValuePair<VectorInt, (ITile, Color?)> kv)
			{
				var (left, top) = gl + kv.Key * TileSize * gs;
				var right = left + TileSize.X * gs.X;
				var bottom = top + TileSize.Y * gs.Y;
				return left <= DF.Window.ActualWidth && top <= DF.Window.ActualHeight && right >= 0 && bottom >= 0;
			}

			foreach (var (tl, (tile, color)) in tiles.Where(filter))
			{
				var dest = gl + tl * TileSize * AbsoluteScale;
				tile.Draw(this, tl, dest, color);
			}
		}

		protected override void OnDestroy()
		{
			Clear();
		}

		/// <summary>
		///  Get the tile at the specified position.
		/// </summary>
		public ITile? GetTileAt(VectorInt point) => tiles.ContainsKey(point) ? tiles[point].tile : default;

		/// <summary>
		///  Get the tile at the specified position.
		/// </summary>
		public ITile? GetTileAt(int x, int y) => GetTileAt((x, y));

		/// <summary>
		/// Get color of the tile at the specified position.
		/// </summary>
		public Color? GetTileColorAt(VectorInt point) => tiles.ContainsKey(point) ? tiles[point].color : default;
		/// <summary>
		/// Get color of the tile at the specified position.
		/// </summary>
		public Color? GetTileColorAt(int x, int y) => GetTileColorAt((x, y));

		/// <summary>
		/// Set the tile at the specified position.
		/// </summary>
		public void SetTile(VectorInt point, ITile? tile, Color? color = null)
		{
			if (tile == null)
				tiles.Remove(point);
			else
				tiles[point] = (tile, color ?? DefaultColor);
		}

		/// <summary>
		/// Set the tile at the specified position.
		/// </summary>
		public void SetTile(int x, int y, ITile? tile, Color? color = null) => SetTile((x, y), tile, color);

		/// <summary>
		/// Remove all tiles.
		/// </summary>
		public void Clear()
		{
			tiles.Clear();
		}

		/// <summary>
		/// Draw a line with specified tile.
		/// </summary>
		public void Line(int x1, int y1, int x2, int y2, ITile tile)
		{
			var steep = Math.Abs(y2 - y1) > Math.Abs(x2 - x1);
			// 左上から右下に描くよう正規化する
			if (steep)
			{
				Swap(ref x1, ref y1);
				Swap(ref x2, ref y2);
			}
			if (x1 > x2)
			{
				Swap(ref x1, ref x2);
				Swap(ref y1, ref y2);
			}

			var deltaX = x2 - x1;
			var deltaY = Math.Abs(y2 - y1);
			var error = deltaX / 2;
			int ystep;
			var y = y1;
			if (y1 < y2)
				ystep = 1;
			else
				ystep = -1;

			for (var x = x1; x <= x2; x++)
			{
				if (steep)
					this[y, x] = tile;
				else
					this[x, y] = tile;

				error -= deltaY;
				if (error < 0)
				{
					y += ystep;
					error += deltaX;
				}
			}
		}

		/// <summary>
		/// Fill the specified rectangle with the specified tile.
		/// </summary>
		public void Fill(int x1, int y1, int width, int height, ITile tile)
		{
			for (var y = y1; y < y1 + height; y++)
				for (var x = x1; x < x1 + width; x++)
					this[x, y] = tile;
		}

		/// <summary>
		/// Draw a line with specified tile.
		/// </summary>
		public void Line(VectorInt start, VectorInt end, ITile tile)
			=> Line(start.X, start.Y, end.X, end.Y, tile);

		/// <summary>
		/// Fill the specified rectangle with the specified tile.
		/// </summary>
		public void Fill(VectorInt position, VectorInt size, ITile tile)
			=> Fill(position.X, position.Y, size.X, size.Y, tile);

		public IEnumerator<(VectorInt loc, ITile tile, Color? color)> GetEnumerator()
		{
			foreach (var t in tiles)
				yield return (t.Key, t.Value.tile, t.Value.color);
		}

		private readonly Dictionary<VectorInt, (ITile tile, Color? color)> tiles;
	}
}
