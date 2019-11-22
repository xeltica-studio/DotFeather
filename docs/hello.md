# Hello!

Well, let's draw text! Write the following line in the `OnStart()` method:

```cs
Print("Hello, world!");
```

Is `Hello, world!` on the screen? It's success! Print method shows the spcified value on the **console layer**.

Console layer is always displayed on top.

Print methods automatically breaks line after outputting the value. To change output position, set the `ConsoleCursor` property:

```cs
ConsoleCursor = new VectorInt(4, 8);
Print("Good afternoon.");
```

In the above example, output the string at coordinates (4, 8).

You can also change the console font size and color:

```cs
// Change console text size to 48px
ConsoleSize = 48;

// Make the characters red
ForegroundColor = Red;
```

Items appeared in this article such as `Print` `ConsoleSize` `ConsoleCursor` and `ForegroundColor` are all members of the `GameBase` class.

Next: [Drawing](drawing.md)
