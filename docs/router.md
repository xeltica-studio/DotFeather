# Router

Router is a scene manager for DotFeather.

This article shows how to change sceneA, sceneB, and sceneC by using router.

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

You can change scenes by executing the `DF.Router.ChangeScene<T>()` method. You can pass a value to `OnStart()` in the next scene by specifying a dictionary variable as the first argument.

Also like

```cs
Router.ChangeScene(typeof(SceneA));
```
, you can specify `Type` object.

## Register scenes

In the above example, the scene type was specified directly, but you can also register the scene in advance and call it using a path.

An example of registering the above three scenes by specifying the path:

```cs
Router.RegisterScene<SceneA>("a");
Router.RegisterScene<SceneB>("b");

// You can specify the type object.
Router.RegisterScene(typeof(SceneC), "c");
```

An example of transition to a registered scene:

```cs
Router.ChangeScene("a");
```

Simply replace the part that was directly specifying the type with a path. Of course, you can specify a dictionary variable as the second argument.
