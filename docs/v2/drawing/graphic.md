# Graphic

Graphic screen is a object to render primitive shapes such as pixels, lines, rectangles and textures.

## Usage

To use graphic objects, first you initialize an instance of `Graphic` class. After that, add it to the Root property.

```cs
var graphic = new Graphic();
Root.Add(graphic);
```

Like the below, call methods related to the shape you want to draw.

```cs
// Pixel
graphic.Pixel(32, 32, Color.Black);
// Line
graphic.Line(0, 0, 64, 64, Color.Red);
// Rectangle
graphic.Rect(0, 0, 64, 64, Color.Green);
```

Next: [Sprite](sprite.md)
