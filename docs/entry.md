# Entry Point

Let's start creating a game using DotFeather.

As with any other C# program, the program will start from the Main method. First, write a program like the following:

```cs
using DotFeather;
class Program
{
	static void Main()
	{
		return DF.Run();
	}
}
```

In C# 9, the Main() method can be omitted. Therefore, the following program is acceptable:

```cs
using DotFeather;

return DF.Run();
```

This document omits the description of the Main method and the class that contains it.
Please read them appropriately depending on the environment you use.

Now, if you run the above program normally, you will see a black screen. We will now use this as a **base** to create the game.
