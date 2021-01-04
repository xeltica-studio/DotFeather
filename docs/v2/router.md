# Router

Router is a scene manager for DotFeather.

It was provided at the external package named DotFeather.Router, but integrated from v2.

This article shows how to change sceneA, sceneB, and sceneC by using router.

## Using router

To use router, you need some special settings for the game-class.

### Start Quickly

You can start quickly by initializing a new instance of `RoutingGameBase` class, instead of generating a new game-class by extending `GameBase` class.

Describe your entry point as follows:

```cs
static void Main()
{
	using (var g = new RoutingGameBase<Root>(320, 240))
	{
		// If needed, handle frame-updated event here.
		g.Update += (s, e) =>
		{
			Console.WriteLine(e.DeltaTime);
		};

		g.Run();
	}
}
```

Specify a type of the scene you want to load first as the type parameter of the RoutingGameBase class.

### Start Manually

To set up a new router in the old game class, set as follows:

```cs
class Game : GameBase
{
	public Game(int width, int height, string title = "", int refreshRate = 60) : base(width, height, title, refreshRate)
	{
		// Initialize the router with the game instance
		router = new Router(this);
	}

	protected override void OnLoad(object sender, EventArgs e)
	{
		// Load the first scene here
		router.ChangeScene<Root>();
	}

	protected override void OnUpdate(object sender, DFEventArgs e)
	{
		// Let the router update
		router.Update(e);
	}

	private Router router;
}
```

## Generate scenes

A scene can be created by inheriting the `Scene` class. It's similar to the inheritance of `GameBase`.

```cs
public class Root : Scene
{
	public override void OnStart(Router router, GameBase game, Dictionary<string, object> args)
	{
		Print("Commands: ");
		Print(" A: Go to the Scene A");
		Print(" B: Go to the Scene B");
		Print(" C: Go to the Scene C");
	}

	public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
	{
		if (DFKeyboard.A)
			router.ChangeScene<SceneA>();
		if (DFKeyboard.B)
			router.ChangeScene<SceneB>();
		if (DFKeyboard.C)
			router.ChangeScene<SceneC>();
	}
}
```

```cs
public class SceneA : Scene
{
	public override void OnStart(Router router, GameBase game, Dictionary<string, object> args)
	{
		Print("A");
		Print("Press ESC to return");
	}

	public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
	{
		if (DFKeyboard.Escape) router.ChangeScene<Root>();
	}
}
```

```cs
public class SceneB : Scene
{
	public override void OnStart(Router router, GameBase game, Dictionary<string, object> args)
	{
		Print("B");
		Print("Press ESC to return");
	}

	public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
	{
		if (DFKeyboard.Escape) router.ChangeScene<Root>();
	}
}
```

```cs
public class SceneC : Scene
{
	public override void OnStart(Router router, GameBase game, Dictionary<string, object> args)
	{
		Print("C");
		Print("Press ESC to return");
	}

	public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
	{
		if (DFKeyboard.Escape) router.ChangeScene<Root>();
	}
}
```

`Router.ChangeScene<T>()` メソッドを実行すると、シーンを遷移できます。第2引数に辞書型変数を渡すことで、次のシーンの `OnStart()` に値を渡せます。

You can change scenes by executing the `Router.ChangeScene<T>()` method. You can pass a value to `OnStart()` in the next scene by specifying a dictionary variable as the second argument.

Also like

```cs
router.ChangeScene(typeof(SceneA));
```
, you can specify `Type` object.

## Register scenes

In the above example, the scene type was specified directly, but you can also register the scene in advance and call it using a path.

An example of registering the above three scenes by specifying the path:

```cs
router.RegisterScene<SceneA>("a");
router.RegisterScene<SceneB>("b");

// You can specify the type object.
router.RegisterScene(typeof(SceneC), "c");
```

An example of transition to a registered scene:

```cs
router.ChangeScene("a");
```

Simply replace the part that was directly specifying the type with a path. Of course, you can specify a dictionary variable as the second argument.

Next: [Original Rendering](plugin/render.md)
