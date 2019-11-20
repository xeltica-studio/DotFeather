# Hello!

さっそく、文字を描画してみます。`OnStart()` メソッドの中に次の行を書いてください。

```cs
Print("Hello, world!");
```

画面に `Hello, world!` と表示されていれば、成功です。Print メソッドは、値を **コンソールレイヤー** 上に表示します。

コンソールレイヤーは、常に最前面に表示されます。

Print メソッドは、値を出力した後、自動的に改行します。値の出力位置を変更するためには、 `ConsoleCursor` プロパティを設定します。

```cs
ConsoleCursor = new VectorInt(4, 8);
Print("Good afternoon.");
```

上の例では、座標 (4, 8) に文字列を出力しています。

コンソールの文字サイズや色も変更できます。

```cs
// コンソールの文字サイズを 48px に変更
ConsoleSize = 48;

// コンソールに表示する文字を赤くする
ForegroundColor = Red;
```

なお、この項目で登場した `Print` `ConsoleSize` `ConsoleCursor` `ForegroundColor` は全て `GameBase` クラスのメンバーです。

次: [描画](drawing.md)
