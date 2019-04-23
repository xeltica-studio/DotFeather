# Mouse Input

To get mouse input, use `Input.Mouse` property.

I'll show all examples related to mouse input.

```cs
// Mouse Position
var pos = Input.Mouse.Position;
// Scroll Displacement
var (scrX, scrY) = Input.Mouse.Scroll;

// Check Button
if (Input.Mouse.IsLeftButtonClicked)
    Console.WriteLine("Left Clicked");
if (Input.Mouse.IsMiddleButtonClicked)
    Console.WriteLine("Middle Clicked");
if (Input.Mouse.IsRightButtonClicked)
    Console.WriteLine("Right Clicked");
```

Next: [Keyboard Input](keyboard.md)
