# Tilemap

Tilemap is a object to draw tiles matrix. It can be used for RPG field etc.

## Tile

Tile is a object for tilemap. Tile must implement `ITile` interface. Now `Tile` class, a tile which can be created from textures, is embedded. You can originally create a tile by creating `ITile` based class.


I'll show how to load a tile and put it on a tilemap.

```cs
// Create a map
var map = new Tilemap(new Vector(16, 16));
// Load a texture
var texture = Texture2D.LoadFrom("./grass.png");
// Generate a tile
var tile = new Tile(texture);

// Place a tile at (2, 4)
map[2, 4] = tile;

// Line from (1, 4) to (8, 8)
map.Line(1, 4, 8, 8, tile);

// Make a (16, 16) sized rectangle at (2, 16)
map.Rect(2, 16, 16, 16, tile);
```

In addition, you can directly generate tiles by specifying path:

```cs
Tile tile = Tile.LoadFrom("./assets/skeleton.png");
```

Next: [Container](container.md)
