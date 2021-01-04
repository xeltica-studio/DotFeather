# Graphic

Graphic elements can be used to draw elements such as points, lines, rectangles, and textures.

## Usage

Call the method corresponding to the graphic you want to draw in the generated instance as follows.

```cs
var graphic = new Graphic();

// Pixel
graphic.Pixel(32, 32, Color.Black);
// Line
graphic.Line(0, 0, 64, 64, Color.Red);
// Rectangle
graphic.Rect(0, 0, 64, 64, Color.Green);
```
