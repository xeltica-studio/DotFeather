# Tilemap

Tilemap allows you to draw a grid of tiles generated from a texture.
Although other methods can be used to draw textures in a grid, Tilemap is optimized and should usually be used.

## Tile

Tile is the smallest unit of drawing in Tilemap. A tile is represented by a class that implements the `ITile` interface. Currently, the `Tile` class, which creates tiles from textures, is built in, but you can create your own tiles that implement the `ITile` interface to achieve complex rendering.

The following shows how to load the `Tile` class and paste it into a tile map.

```cs
// Create a map
var map = new Tilemap((16, 16));
// Loading textures
var texture = Texture2D.LoadFrom("./grass.png");
// Generate tiles
var tile = new Tile(texture);

// Place tiles at positions 2 and 4
map[2, 4] = tile;

// Draw a line from (1, 4) to (8, 8)
map.Line(1, 4, 8, 8, tile);

// Draw a rectangle of size (16, 16) at (2, 16)
map.Rect(2, 16, 16, 16, tile);
```

You can also generate tiles directly by specifying a file name.

```cs
Tile sprite = Tile.LoadFrom("./assets/castle.png");
```

## Rendering modes

Tile maps can use two different rendering modes depending on the situation.

### RenderAll mode

RenderAll mode draws all tiles attached to the tilemap that exist in the screen.

### Scan mode

Scan mode scans the screen from top-left to bottom-right to find tiles and draws them.

### Auto mode

Auto mode dynamically switches between the above two modes according to the following conditions.
- Number of tiles that can exist on the screen > Actual number of tiles
	- RenderAll mode
- Not so.
	- Scan mode

**This mode is the default. **

### Switching modes

Normally, we recommend using Auto mode, but if you have problems in one mode or the other, switching may help.

```cs
map.Renderingmode = TilemapRenderingMode.RenderAll;
```

You can also get the actual rendering mode used in Auto mode via the `PreferredRenderingMode` property.
