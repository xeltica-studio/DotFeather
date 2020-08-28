using System.Collections.Generic;
using System.Drawing;

namespace DotFeather
{
	public class Tilemap : PrimitiveElement<TilemapRenderer>, ITilemap
	{
		public Tilemap(VectorInt tileSize) : base("")
		{
			AddComponent(component = new TilemapRenderer(tileSize));
		}

		public Tilemap(VectorInt tileSize, params Element[] children) : base("", children)
		{
			AddComponent(component = new TilemapRenderer(tileSize));
		}

		public ITile? this[VectorInt point]
		{
			get => component[point];
			set => component[point] = value;
		}
		public ITile? this[int x, int y]
		{
			get => component[x, y];
			set => component[x, y] = value;
		}

		public VectorInt TileSize
		{
			get => component.TileSize;
			set => component.TileSize = value;
		}
		public Color? DefaultColor
		{
			get => component.DefaultColor;
			set => component.DefaultColor = value;
		}

		float ITilemap.Angle { get => (component as ITilemap).Angle; set => (component as ITilemap).Angle = value; }

		public void Fill(int x1, int y1, int width, int height, ITile tile)
		{
			component.Fill(x1, y1, width, height, tile);
		}

		public void Fill(VectorInt position, VectorInt size, ITile tile)
		{
			component.Fill(position, size, tile);
		}

		public ITile? GetTileAt(VectorInt point)
		{
			return component.GetTileAt(point);
		}

		public ITile? GetTileAt(int x, int y)
		{
			return component.GetTileAt(x, y);
		}

		public Color? GetTileColorAt(VectorInt point)
		{
			return component.GetTileColorAt(point);
		}

		public Color? GetTileColorAt(int x, int y)
		{
			return component.GetTileColorAt(x, y);
		}

		public void Line(int x1, int y1, int x2, int y2, ITile tile)
		{
			component.Line(x1, y1, x2, y2, tile);
		}

		public void Line(VectorInt start, VectorInt end, ITile tile)
		{
			component.Line(start, end, tile);
		}

		public void SetTile(VectorInt point, ITile? tile, Color? color = null)
		{
			component.SetTile(point, tile, color);
		}

		public void SetTile(int x, int y, ITile? tile, Color? color = null)
		{
			component.SetTile(x, y, tile, color);
		}

		public new void Clear()
		{
			component.Clear();
		}

		void ITilemap.Clear()
		{
			component.Clear();
		}

		IEnumerator<(VectorInt loc, ITile tile, Color? color)> ITilemap.GetEnumerator()
		{
			return component.GetEnumerator();
		}
	}
}
