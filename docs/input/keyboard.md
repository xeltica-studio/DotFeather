# Keyboard Input


To get keyboard input, use `Input.Keyboard` property.

It has all well-known keys as children.

I'll show actual examples.

```cs
// Check whether the user pressed A key
if (Input.Keyboard.A.IsPressed)
{
    Console.WriteLine("A is pressed");
}

if (Input.Keyboard.B.IsKeyDown)
{
	Console.WriteLine("Aが押された");
}

if (Input.Keyboard.B.IsKeyUp)
{
	Console.WriteLine("Bが離された");
}
```

Next: [Audio](../audio.md)
