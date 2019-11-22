# Mouse Input

To get mouse input, use `DFMouse` property.

I'll show all examples related to mouse input.

```cs
// Mouse Position
var (px, py) = DFMouse.Position;
// Scroll Displacement
var (scrX, scrY) = DFMouse.Scroll;

// Check Button

// -- Check whether mouse buttons are clicked
if (DFMouse.IsLeft)
	Console.WriteLine("Left Clicked");
if (DFMouse.IsMiddle)
	Console.WriteLine("Middle Clicked");
if (DFMouse.IsRight)
	Console.WriteLine("Right Clicked");

// -- Check whether mouse buttons are just pressed
if (DFMouse.IsLeftDown)
	Console.WriteLine("Left pressed");
if (DFMouse.IsMiddleDown)
	Console.WriteLine("Middle pressed");
if (DFMouse.IsRightDown)
	Console.WriteLine("Right pressed");

// -- Check whether mouse buttons are released
if (DFMouse.IsLeftUp)
	Console.WriteLine("Left released");
if (DFMouse.IsMiddleUp)
	Console.WriteLine("Middle released");
if (DFMouse.IsRightUp)
	Console.WriteLine("Right released");
```

Next: [Keyboard Input](keyboard.md)
