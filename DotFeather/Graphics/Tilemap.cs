using System;
using System.Collections.Generic;
using System.Drawing;
using static DotFeather.MiscUtility;

namespace DotFeather
{
	/// <summary>
	/// A <see cref="IDrawable"/> object to render <see cref="ITile"/> objects in a lattice.
	/// </summary>
	public class Tilemap : IContainable
	{
		public int ZOrder { get; set; }

		public string Name { get; set; } = "";

		public Vector Location { get; set; }

		public float Angle { get; set; }

		public Vector Scale { get; set; } = Vector.One;

		public Color? DefaultColor { get; set; }

		/// <summary>
		/// Get current drawing position. <c>null</c> when not in ITile.Draw()
		/// </summary>
		/// <value></value>
		public VectorInt? CurrentDrawingPosition { get; set; }

		/// <summary>
		/// Get a parent of this drawable.
		/// </summary>
		public IContainable? Parent { get; internal set; }

		IContainable? IContainable.Parent
		{
			get => Parent;
			set => Parent = value;
		}

		/// <summary>
		/// Get absolute location.
		/// </summary>
		public Vector AbsoluteLocation => Location + (Parent?.AbsoluteLocation ?? Vector.Zero);

		/// <summary>
		/// Get or set the size in pixels per tile.
		/// </summary>
		public Vector TileSize { get; set; }

		/// <summary>
		/// Initialize a new instance of <see cref="Tilemap"/> class.
		/// </summary>
		/// <param name="tileSize">Size per the tile.</param>
		public Tilemap(Vector tileSize)
		{
			TileSize = tileSize;
			tiles = new Dictionary<(int, int), (ITile, Color?)>();
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
		public ITile? this[Vector point]
		{
			get => GetTileAt(point);
			set => SetTile(point, value);
		}

		public void Draw(GameBase game, Vector location)
		{
			foreach (var kv in tiles)
			{
				var (x, y) = kv.Key;
				var loc = new Vector(x, y) * TileSize * Scale;
				CurrentDrawingPosition = new VectorInt(x, y);
				kv.Value.tile.Draw(game, this, Location + location + loc, kv.Value.color);
			}
			CurrentDrawingPosition = null;
		}

		/// <summary>
		///  Get the tile at the specified position.
		/// </summary>
		public ITile? GetTileAt(Vector point) => GetTileAt((int)point.X, (int)point.Y);
		/// <summary>
		///  Get the tile at the specified position.
		/// </summary>
		public ITile? GetTileAt(int x, int y) => tiles.ContainsKey((x, y)) ? tiles[(x, y)].tile : default;

		/// <summary>
		/// Get color of the tile at the specified position.
		/// </summary>
		public Color? GetTileColorAt(Vector point) => GetTileColorAt((int)point.X, (int)point.Y);
		/// <summary>
		/// Get color of the tile at the specified position.
		/// </summary>
		public Color? GetTileColorAt(int x, int y) => tiles.ContainsKey((x, y)) ? tiles[(x, y)].color : default;

		/// <summary>
		/// Set the tile at the specified position.
		/// </summary>
		public void SetTile(Vector point, ITile? tile, Color? color = null) => SetTile((int)point.X, (int)point.Y, tile, color);

		/// <summary>
		/// Set the tile at the specified position.
		/// </summary>
		public void SetTile(int x, int y, ITile? tile, Color? color = null)
		{
			if (tile == null)
				tiles.Remove((x, y));
			else
				tiles[(x, y)] = (tile, color ?? DefaultColor);
		}

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
		public void Line(Vector start, Vector end, ITile tile)
			=> Line((int)start.X, (int)start.Y, (int)end.X, (int)end.Y, tile);

		/// <summary>
		/// Fill the specified rectangle with the specified tile.
		/// </summary>
		public void Fill(Vector position, Vector size, ITile tile)
			=> Line((int)position.X, (int)position.Y, (int)size.X, (int)size.Y, tile);

		/// <summary>
		/// Destroy this <see cref="Tilemap"/>.
		/// </summary>
		public virtual void Destroy()
		{
			foreach (var kv in tiles)
			{
				kv.Value.tile.Destroy();
			}
			tiles.Clear();
		}

		public IEnumerator<(int x, int y, ITile tile, Color? color)> GetEnumerator()
		{
			foreach (var t in tiles)
				yield return (t.Key.x, t.Key.y, t.Value.tile, t.Value.color);
		}

		private Dictionary<(int x, int y), (ITile tile, Color? color)> tiles;
	}
}
