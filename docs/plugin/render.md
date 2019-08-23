# Original Rendering

**Note: This article is for Advanced Programmers.**

## Implement IDrawable

You can implement the objects that can be handled on DotFeather simply by creating a class that implements the `IDrawable` interface.

See [API document] (https://dotfeather.netlify.com/api/dotfeather.idrawable) for the detailed definition.

We recommend that you implement properties under ZOrder as auto-implemented properties.

Write the actual drawing process in the Draw method. Please draw in the location of the value which added location of argument and Location of property.

## Implements ITile

You can create your own tiles simply by creating a class that implements the `ITile` interface.

Here is the definition of the `ITile` interface in the latest version.

```cs
public interface ITile
{
	void Draw(GameBase game, Tilemap map, Vector location, Color? color);
}
```

Write the actual drawing process in the Draw method. Because tile instances are reused, it receives drawing position and color information as arguments for drawing. Coordinate information of `location` argument is not tile map coordinates, but screen pixel coordinates. Please draw at the same position.

Drawables can receive draw-calls, but processing, which is not related to drawing such as collision detection, should not be written in the `Draw ()` method. If such processing is required, implement [IUpdatable interface](updatable.md) additionally.

Next: [Original Audio Source](audiosource.md)
