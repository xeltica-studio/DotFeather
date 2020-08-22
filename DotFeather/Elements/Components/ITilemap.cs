using System.Collections.Generic;
using System.Drawing;

namespace DotFeather
{
	public interface ITilemap
	{
		ITile? this[VectorInt point] { get; set; }
		ITile? this[int x, int y] { get; set; }

		VectorInt TileSize { get; set; }
		Color? DefaultColor { get; set; }

		Vector Location { get; set; }
		float Angle { get; set; }
		Vector Scale { get; set; }

		void Clear();
		void Fill(int x1, int y1, int width, int height, ITile tile);
		void Fill(VectorInt position, VectorInt size, ITile tile);
		IEnumerator<(VectorInt loc, ITile tile, Color? color)> GetEnumerator();
		ITile? GetTileAt(VectorInt point);
		ITile? GetTileAt(int x, int y);
		Color? GetTileColorAt(VectorInt point);
		Color? GetTileColorAt(int x, int y);
		void Line(int x1, int y1, int x2, int y2, ITile tile);
		void Line(VectorInt start, VectorInt end, ITile tile);
		void OnDestroy();
		void OnRender();
		void SetTile(VectorInt point, ITile? tile, Color? color = null);
		void SetTile(int x, int y, ITile? tile, Color? color = null);
	}
}
