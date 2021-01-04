# Original Rendering

**Note: この項目は DotFeather およびプログラミング上級者を対象としています。**

## Inheriting from ElementBase

You can implement objects that can be handled on DotFeather by simply creating a new class that inherits from the `ElementBase` class.

For a detailed definition of the `ElementBase` class, please refer to the [API documentation](https://dotfeather.netlify.com/api/dotfeather.elementbase).

The `OnRender` method is overridden to do the actual drawing. Override the OnUpdate method to do anything other than drawing.

## Implementation of ITile

You can create your own tiles by simply creating a class that implements the `ITile` interface.

Here is the definition of the `ITile` interface in the latest version.

```cs
public interface ITile
{
	void Draw(Tilemap map, VectorInt tileLocation, Vector locationToDraw, Color? color);
	void Destroy();
}
```

Implement the Draw method and describe the actual drawing process. Since a single instance of a tile is supposed to be placed in multiple locations, it receives the drawing location and color information as arguments. The coordinate information in the locationToDraw temporary argument is not the coordinates of the tile map, but the pixel coordinates of the screen. There is no need to perform any calculation, just draw at the original location.
