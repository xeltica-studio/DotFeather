# Print "Hello world"

Let's graduate from the boring black screen and display some great ideas.

Write the following program:

```cs
DF.Window.Start += () =>
{
	DF.Console.Print("Hello, world!");
};

return DF.Run();
```

If the screen displays `Hello, world!`, you have succeeded.

Write the logic to be executed when the game starts in the `DF.Window.Start` event. If you write it outside of the event, it may cause unexpected behavior, so be sure to put it in there.

DotFeather includes a console layer for easy string output, and the DF.Console property contains the API to control this console layer.

The Print method automatically breaks the line after printing the value. To change the output position of the value, set the `DF.Console.Cursor` property.

```cs
DF.Console.Cursor = (4, 8);
DF.Console.Print("Good afternoon.");
```

In the example above, the string will be output at (4, 8).

You can also change the text size and color of the console layer.

```cs
// Change text size of console layer to 48px
DF.Console.FontSize = 48;

// Make the text displayed on the console layer red
DF.Console.TextColor = Red;
```

To clear the console layer, use the Cls method (short for Clear the Screen).

```cs
DF.Console.Cls();
```

