# テキスト

DotFeather ウィンドウ上に文字列を表示するためには、 `TextDrawable` クラスを使用します。

## 使い方

`TextDrawable` クラスは次のように初期化し、使用できます。

```cs
var text = new TextDrawable("Hello, DotFeather!");
Root.Add(text);
```

オプションで、文字の大きさやフォントスタイル、色も指定できます。

### 独自のフォントを使う

標準では、TextDrawable は、DotFeather のシステムに組み込まれたデフォルトフォントを使用します。必要に応じて、用意したフォントや OS が提供するフォントを使用することもできます。

フォントを変更するためには、`Font` クラスのインスタンスをまず初期化します。

```cs
// Specify the font by path
var font = new Font("./font.ttf", 32, FontStyle.Normal);

// Use system font
var sans = new Font("Comic Sans MS", 16);

// Initialize default font
var defaultFont = Font.GetDefault(24);
```

インスタンスを初期化したら、`TextDrawable` のコンストラクターに渡して初期化します。

```cs
var text = new TextDrawable("* do you wanna have a bad time?", sans, Color.White);
Root.add(text);
```

次: [コンテナー](container.md)
