# From Mouse

To get the input from the mouse, use the `DFMouse` property.

All examples related to mouse input are described below.

```cs
// Mouse coordinates
var (px, py) = DFMouse.Position;
// Scroll movement amount
var (scrX, scrY) = DFMouse.Scroll;

// Button judgment

// -- Whether the button is clicked or not
if (DFMouse.IsLeft)
	Console.WriteLine("Left click");
if (DFMouse.IsMiddle)
	Console.WriteLine("Middle click");
if (DFMouse.IsRight)
	Console.WriteLine("Right click");

// -- Whether the button was pressed or not
if (DFMouse.IsLeftDown)
	Console.WriteLine("Left is pressed");
if (DFMouse.IsMiddleDown)
	Console.WriteLine("Middle is pressed");
if (DFMouse.IsRightDown)
	Console.WriteLine("Right is pressed");

// -- Whether the button was released or not
if (DFMouse.IsLeftUp)
	Console.WriteLine("Left released now");
if (DFMouse.IsMiddleUp)
	Console.WriteLine("Middle released now");
if (DFMouse.IsRightUp)
	Console.WriteLine("Right released now");
```
