# IUpdatable

**Note: This article is for Advanced Programmers.**

The `IDrawable` interface provides events for the renderer to draw objects, but it doesn't provide events for handling game logic. It is dangerous to write processing other than drawing in the `Draw ()` method. If custom drawables take user input and does something, this is inconvenient . The `IUpdatable` interface solves that.

Please refer to [API document] (https://dotfeather.netlify.com/api/dotfeather.iupdatable) for the detailed definition.

The `IUpdatable.OnUpdate(GameBase game);` event is fired at every frame update. Here is a sample that turns the game background color red when the sprite is clicked:

```cs
public class ClickableSprite : Sprite, IUpdatable
{
	public ClickableSprite(Texture2D texture) : base(texture) { }

	public void OnUpdate(GameBase game)
	{
		var (x, y) = (Input.Mouse.Position.X, Input.Mouse.Position.Y);

		if (Location.X < x && Location.Y < y && x < Location.X + Width && y < Location.Y + Height && Input.Mouse.IsLeftUp)
		{
			game.BackgroundColor = Color.Red;
		}
	}
}
```
