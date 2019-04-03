using DotFeather.Drawable.Tiles;
using DotFeather.Helpers;

namespace DotFeather.Drawable
{
	public class Tilemap : IDrawable
	{
		public int ZOrder { get; set; }
		public string Name { get; set; }
		public Vector Location { get; set; }
		public float Angle { get; set; }
		public Vector Scale { get; set; }

		public ITile[,] Tiles { get; set; }
		public Vector TileSize { get; set; }

		public Tilemap(int x, int y, Vector tileSize)
		{
			TileSize = tileSize;
			Tiles = new ITile[x, y];
		}

		public void Draw(GameBase game, Vector location)
		{
			var xMax = Tiles.GetLength(0);
			var yMax = Tiles.GetLength(1);
			for (int y = 0; y < yMax; y++)
			{
				for (int x = 0; x < xMax; x++)
				{
					var loc = new Vector(x * TileSize.X, y * TileSize.Y);
					if (Tiles[x, y] == default)
						continue;
					Tiles[x, y].Draw(game, Location + location + loc, Tiles, x, y);
				}
			}
		}
	}
}
