# Original Rendering

**Note: This article is for Advanced Programmers.**

## Implement IDrawable

You can implement the objects that can be handled on DotFeather simply by creating a class that implements the `IDrawable` interface.

Here is the definition of the `IDrawable` interface in the latest version.

```cs
public interface IDrawable
{
	void Draw(GameBase game, Vector location);
	int ZOrder { get; set; }
	string Name { get; set; }
	Vector Location { get; set; }
	float Angle { get; set; }
	Vector Scale { get; set; }
}
```

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

Next: [Original Audio Source](audiosource.md)
