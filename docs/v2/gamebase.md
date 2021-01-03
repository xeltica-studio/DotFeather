# Inherit GameBase

In DotFeather, you define a inherited class from GameBase and write main loop into it.

```cs
public class Game : GameBase
{
	public Game(int width, int height, string title = null, int refreshRate = 60)
		: base(width, height, title, refreshRate) { }
}
```

**Hereafter, the class you defined will be called "Game" in this document.**

## Entrypoint

Same as other C# program, your code will be begin from the `Main()` method. Write the following statement into `Main()` to run the game class.

```cs
static void Main()
{
	using (var g = new Game(320, 240))
	{
		g.Run();
	}
}
```

## Event Hook

You should override virtual methods from GameBase and write main loop, loading assets etc into it. I will describe virtual methods from GameBase:

|Method|Description|
|---|---|
|OnLoad()|will be called when the game begin. Load resources and savedata here.|
|OnUpdate()|will be called every frame update. Write main loop.|
|OnResize()|will be called when size of the game window is changed.|
|OnUnload()|will be called when the game is ended. Use for auto-saving or disposing any resources.|
|OnDragDrop()|will be called when a file is dragged and dropped.|


## Properties

You can set properties to customize the game window etc.

|Property|Description|
|---|---|
|Title|A title of the window|
|X|X-coord of the window|
|Y|Y-coord of the window|
|Width|width of the window|
|Height|height of the window|
|Visible|visiblity of the window|
|BackgroundColor|background color of the window|
|Dpi|DPI of current display|
|RefreshRate|refresh rate of current display|
|Root|A top-level container. Put drawable objects into that.|

## Other features

### Randomize() Method

Initialize a random generator. You can specify seed value. If omitted, the current time is used as the random generator's seed value.

### Random Property

Get a instance of the `Random` class of .NET Standard BCL.

### Exit() Method

End the game. You can specify an exit status.

There are many other features. See [API document] (https://dotfeather.netlify.com/api/dotfeather.gamebase) to find more details.

Next: [Hello!](hello.md)
