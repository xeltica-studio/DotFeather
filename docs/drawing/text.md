# Text

To display string on your DotFeather window, use `TextDrawable` class.

## Usage

To use `TextDrawable`, you have to load fonts before that. Initialize `System.Drawing.Font` to load a font.

```cs
var font = new Font("Arial", 24);
```

I won't describe more usage of `System.Drawing.Font` class, but it can also load original fonts, so let's search more information.

Initialize an object with fonts.

```cs
var text = new TextDrawable("Hello, DotFeather!", font, Color.White);
Root.Add(text);
```

次: [Container](container.md)
