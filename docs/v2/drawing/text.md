# Text

To display string on your DotFeather window, use `TextDrawable` class.

## Usage

To use `TextDrawable`, initialize like this:

```cs
var text = new TextDrawable("Hello, DotFeather!");
Root.Add(text);
```
Optinally, you can specify text size, font style and color.

### Use your own font

By default, TextDrawable uses the builtin font, but you can also use your own font or OS-provided fonts as needed.

To change the font, first initialize an instance of the `Font` class.

```cs
// Specify the font by path
var font = new Font("./font.ttf", 32, FontStyle.Normal);

// Use system font
var sans = new Font("Comic Sans MS", 16);

// Initialize default font
var defaultFont = Font.GetDefault(24);
```

After initializing the instance, provide it to `TextDrawable` constructor to initialize it.

```cs
var text = new TextDrawable("* do you wanna have a bad time?", sans, Color.White);
Root.add(text);
```
Next: [Container](container.md)
