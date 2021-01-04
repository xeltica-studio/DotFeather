# From Keyboard

To get the input from the keyboard, use the `DFKeyBoard` property.

The child elements of the Keyboard property have the names of any keys as properties.

Here is an example of its use in practice.

```cs
if (DFKeyBoard.A.IsPressed)
{
	Console.WriteLine("A is pressed");
}

if (DFKeyBoard.B.IsKeyDown)
{
	Console.WriteLine("B has just been pressed");
}

if (DFKeyBoard.B.IsKeyUp)
{
	Console.WriteLine("B has just been released");
}
```
