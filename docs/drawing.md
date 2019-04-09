# Drawing

DotFeather use a unit named **Object** to draw something on the screen.

There are some kinds of Object:

- Graphic
- Sprite
- Tilemap
- Container


All Objects implements `IDrawable` interface, and they will be rendered every frame.

To draw objects on the screen, run `Root.Add();` method on the game class.


Next: [Graphic](drawing/graphic.md)