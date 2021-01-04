# Elements

In DotFeather, all drawable objects are represented as **Elements**.

There are two types of Elements:
- **Layer Elements**: which are used to draw multiple elements
- **Primitive Elements**: which are used to draw a single element

- **Layer Elements**
	- [Graphic](graphic.md)
	- [Tilemap](tilemap.md)
	- [Container](container.md)
- **Primitive Elements**
	- [Shape](shape.md)
	- [Sprite](sprite.md)
	- [TextElement](text.md)
	- [NineSliceSprite](9slice.md)

All elements are derived from the `ElementBase` class and will be rendered on every frame update.

To draw an element to the screen, use the `DF.Root.Add()` method.

```cs
var cont = new Container();
DF.Root.Add(cont);

// To stop drawing the screen, use the Remove method.
DF.Root.Remove(cont);
```
