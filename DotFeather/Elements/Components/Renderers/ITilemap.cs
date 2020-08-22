using System.Collections.Generic;
using System.Drawing;

namespace DotFeather
{
	/// <summary>
	/// Provides a common Tilemap API.
	/// </summary>
	public interface ITilemap
	{
		/// <summary>
		/// Get or set the tile at the specified position.
		/// </summary>
		ITile? this[VectorInt point] { get; set; }

		/// <summary>
		/// Get or set the tile at the specified position.
		/// </summary>
		ITile? this[int x, int y] { get; set; }

		/// <summary>
		/// Get or set size of grid.
		/// </summary>
		VectorInt TileSize { get; set; }

		/// <summary>
		/// Get or set default tint color of tiles.
		/// </summary>
		Color? DefaultColor { get; set; }

		Vector Location { get; set; }

		float Angle { get; set; }

		Vector Scale { get; set; }

		/// <summary>
		/// Remove all tiles.
		/// </summary>
		void Clear();

		/// <summary>
		/// Fill the specified rectangle with the specified tile.
		/// </summary>
		void Fill(int x1, int y1, int width, int height, ITile tile);

		/// <summary>
		/// Fill the specified rectangle with the specified tile.
		/// </summary>
		void Fill(VectorInt position, VectorInt size, ITile tile);

		IEnumerator<(VectorInt loc, ITile tile, Color? color)> GetEnumerator();

		/// <summary>
		///  Get the tile at the specified position.
		/// </summary>
		ITile? GetTileAt(VectorInt point);

		/// <summary>
		///  Get the tile at the specified position.
		/// </summary>
		ITile? GetTileAt(int x, int y);

		/// <summary>
		/// Get color of the tile at the specified position.
		/// </summary>
		Color? GetTileColorAt(VectorInt point);

		/// <summary>
		/// Get color of the tile at the specified position.
		/// </summary>
		Color? GetTileColorAt(int x, int y);

		/// <summary>
		/// Draw a line with specified tile.
		/// </summary>
		void Line(int x1, int y1, int x2, int y2, ITile tile);

		/// <summary>
		/// Draw a line with specified tile.
		/// </summary>
		void Line(VectorInt start, VectorInt end, ITile tile);

		/// <summary>
		/// Set the tile at the specified position.
		/// </summary>
		void SetTile(VectorInt point, ITile? tile, Color? color = null);

		/// <summary>
		/// Set the tile at the specified position.
		/// </summary>
		void SetTile(int x, int y, ITile? tile, Color? color = null);
	}
}
