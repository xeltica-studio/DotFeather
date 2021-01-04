# Coroutines

A coroutine is a routine that runs asynchronously in the background.

## Overview

Normally, the logic of a game is written in the DF.Window.Update event. However, in cases that require asynchronous processing, such as particles or loading screens, this approach is inefficient. Coroutines solve this problem.

A coroutine can be written in the form of a method that returns a `System.Collections.IEnumerator`. An example of a coroutine definition is shown below.

```cs
// The following elements shall be defined
TextElement text;

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

The coroutine defined in this way is executed as follows.

```cs
var coroutine = CoroutineRunner.Start(CountDown));
```

Both methods return an instance of the [Coroutine class](https://dotfeather.netlify.com/api/dotfeather.coroutine). By manipulating this instance, the coroutine can be controlled.

## Stopping a Coroutine

To stop a coroutine in the middle, call the `CoroutineRunner.Stop` method.

```cs
CoroutineRunner.Stop(coroutine);
```

## Coroutine Callbacks

You can also specify a callback when the coroutine exits, or when an unhandled exception occurs inside the coroutine.

```cs
CoroutineRunner.Start(CountDown(false))
	.Then(_ =>
	{
		Console.WriteLine("Successfully finished!");
	});

CoroutineRunner.Start(CountDown(true))
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

