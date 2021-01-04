# TextElement

The TextElement element can be used to draw text strings.

## Usage

The `TextElement` class can be initialized and used as follows:

```cs
var text = new TextElement("Hello, DotFeather!");
```

Optionally, you can specify the size, font style, and color of the text.

### Bring your own fonts

By default, TextElement uses the default font of the DotFeather system. You can use a prepared font or a font provided by your operating system if needed.

To change the font, you must first initialize an instance of the `DFFont` class.

```cs
// Specify the font by path
var font = new DFFont("./font.ttf", 32, DFFontStyle.Normal);

// Use system font
var sans = new DFFont("Comic Sans MS", 16);

// Initialize default font
var defaultFont = DFFont.GetDefault(24);
```

Once the instance is initialized, pass it to the constructor of `TextElement` to initialize it.

```cs
var text = new TextElement("* do you wanna have a bad time?", sans, Color.White);
DF.Root.add(text);
```
