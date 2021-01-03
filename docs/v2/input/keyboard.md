# Keyboard Input


To get keyboard input, use `DFKeyboard` class.

It has all well-known keys as children.

I'll show actual examples.

```cs
// Check whether the user pressed A key
if (DFKeyBoard.A.IsPressed)
{
	Console.WriteLine("A is pressed");
}

if (DFKeyBoard.B.IsKeyDown)
{
	Console.WriteLine("B key is down");
}

if (DFKeyBoard.B.IsKeyUp)
{
	Console.WriteLine("B key is up");
}
```

Next: [Audio](../audio.md)
