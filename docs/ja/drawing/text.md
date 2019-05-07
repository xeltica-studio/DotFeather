# テキスト

DotFeather ウィンドウ上に文字列を表示するためには、 `TextDrawable` クラスを使用します。

## 使い方

`TextDrawable` クラスを用いる為には、まずフォントを読み込む必要があります。フォントは、 `System.Drawing.Font` を介して読み込みます。

```cs
var font = new Font("Arial", 24);
```

System.Drawing.Font クラスの詳しい使い方はここでは解説しませんが、システムフォントだけでなく、独自のフォントを読み込むことも出来るので、調べてみてください。

読み込んだフォントを使って、オブジェクトを初期化します。

```cs
var text = new TextDrawable("Hello, DotFeather!", font, Color.White);
Root.Add(text);
```

次: [コンテナー](container.md)
