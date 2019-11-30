# Coroutine

Coroutine is a routine works asynchronously in background.

## Summary

Usually, the game logic is written in GameBase.OnUpdate(). However, this approach is inefficient for cases that require asynchronous processing, such as particles and loading screens. Coroutines solve this problem.

Coroutines are written in as methods that return the `System.Collecitons.IEnumerator` interface. See the following example of coroutine definition:

```cs
// The following drawables are defined
TextDrawable text;

IEnumerator CountDown()
{
	text = "Are you ready?";
	yield return new WaitForSeconds(2);
	for (var i = 3; i > 0; i--)
	{
		text = i.ToString();
		yield return new WaitForSeconds(1);
	}
	text = "GO!";
}
```

The defined coroutines are executed as follows:

```cs
// Call from the game-class
var coroutine = StartCoroutine(CountDown());

// Call from other contexts
var coroutine = CoroutineRunner.Start(CountDown));
```

Both `StartCoroutine ()` methods return an instance of the [Coroutine class](https://dotfeather.netlify.com/api/dotfeather.coroutine). You can control the coroutine by manipulating this instance.

## Stop Coroutine

For example, to interrupt the coroutine, call `StopCoroutine` method.

```cs
// Call from the game-class
StopCoroutine(coroutine);

// Call from other contexts
CoroutineRunner.Stop(coroutine);
```

## Callbacks

You can also specify a callback when the coroutine exits, and when an unhandled exception occurs inside the coroutine. It's similar to JavaScript Promise API.

```cs
StartCoroutine(CountDown(false))
	.Then(_ =>
	{
		Console.WriteLine("Successfully finished!");
	});

StartCoroutine(CountDown(true))
	.Error(e =>
	{
		Console.WriteLine($"Something happened!!!\n{e.GetType().Name}: {e.Message}\n{e.StackTrace}");
	});

IEnumerator CountDown(bool error)
{
	text = "Are you ready?";
	yield return new WaitForSeconds(2);
	for (var i = 3; i > 0; i--)
	{
		text = i.ToString();
		yield return new WaitForSeconds(1);
		if (error && i == 1) throw new Exception("Error");
	}
	text = "GO!";
}
```

## Yield Instructions

Coroutines apply C#'s `yield` pattern. You can suspend and resume coroutine execution by returning a specific object. The object passed at this time is called yield instructions. For example, the `WaitForSeconds` yield instruction suspends coroutine for a specified number of seconds.

### Usage

The following shows how to use a yield instruction in a coroutine:

```cs
// Wait for 3 seconds.
yield return new WaitForSeconds(3);

// Wait while the coroutine is running.
yield return TheCoroutine();
```

### Builtins

DotFeather has some builtin yield instructions, and some objects are also specially treated as yield instructions.


|Definitions|Summary|
|---|---|
|`WaitForSeconds(float seconds);`|Wait for `seconds` seconds.|
|`WaitUntil(Func<bool> conditions);`|Wait until the condition is met.|
|`WaitWhile(Func<bool> conditions);`|It's an opposite of WaitUntil. Wait while the condition is met.|
|`WaitUntilNextFrame();`|Wait until the next frame is started.|
|`WaitForTask`|Wait until the specified task finishes executing.|
|`Task` and `ValueTask`|Wait for the task to complete.|
|`Coroutine`|Wait until the coroutine is finished.|
|`IEnumerator`|Run as a coroutine, and wail until the coroutine is finished.|
|Other Object-inherited types and `null`|Work as a `WaitUntilNextFrame`.|

Next: [Router](router.md)
