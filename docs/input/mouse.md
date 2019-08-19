# Mouse Input

To get mouse input, use `Input.Mouse` property.

I'll show all examples related to mouse input.

```cs
// Mouse Position
var pos = Input.Mouse.Position;
// Scroll Displacement
var (scrX, scrY) = Input.Mouse.Scroll;

// Check Button

// -- Check whether mouse buttons are clicked
if (Input.Mouse.IsLeft)
	Console.WriteLine("Left Clicked");
if (Input.Mouse.IsMiddle)
	Console.WriteLine("Middle Clicked");
if (Input.Mouse.IsRight)
	Console.WriteLine("Right Clicked");

// -- Check whether mouse buttons are just pressed
if (Input.Mouse.IsLeftDown)
	Console.WriteLine("Left pressed");
if (Input.Mouse.IsMiddleDown)
	Console.WriteLine("Middle pressed");
if (Input.Mouse.IsRightDown)
	Console.WriteLine("Right pressed");

// -- Check whether mouse buttons are released
if (Input.Mouse.IsLeftUp)
	Console.WriteLine("Left released");
if (Input.Mouse.IsMiddleUp)
	Console.WriteLine("Middle released");
if (Input.Mouse.IsRightUp)
	Console.WriteLine("Right released");
```

Next: [Keyboard Input](keyboard.md)
