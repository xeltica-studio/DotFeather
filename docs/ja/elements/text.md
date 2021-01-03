# TextElement

TextElement エレメントを用いると、文字列を描画できます。

## 使い方

`TextElement` クラスは次のように初期化し、使用できます。

```cs
var text = new TextElement("Hello, DotFeather!");
```

オプションで、文字の大きさやフォントスタイル、色も指定できます。

### 独自のフォントを使う

標準では、TextElementは DotFeather システムのデフォルトフォントを使用します。必要に応じて、用意したフォントや OS が提供するフォントを使用することもできます。

フォントを変更するためには、`DFFont` クラスのインスタンスをまず初期化します。

```cs
// Specify the font by path
var font = new DFFont("./font.ttf", 32, DFFontStyle.Normal);

// Use system font
var sans = new DFFont("Comic Sans MS", 16);

// Initialize default font
var defaultFont = DFFont.GetDefault(24);
```

インスタンスを初期化したら、`TextElement` のコンストラクターに渡して初期化します。

```cs
var text = new TextElement("* do you wanna have a bad time?", sans, Color.White);
DF.Root.add(text);
```
