# ハローワールドを出力する

真っ黒な画面ではつまらないので、とりあえず何かを表示したいところです。

エントリーポイントをベースに、プログラムを足していきます。

```cs
DF.Window.Start += () =>
{
	DF.Console.Print("Hello, world!");
};

return DF.Run();
```

画面に `Hello, world!` と表示されていれば、成功です。

`DF.Window.Start` イベントの中に、ゲーム起動時に実行するロジックを記述します。イベントの外に書くと、予期しない動作の原因となるので、必ずこの中に記載します。

DotFeatherには、コンソールレイヤーという、簡単に文字列を出力するための機能が搭載されています。DF.Console プロパティはこのコンソールレイヤーを制御するためのAPIを含みます。

Print メソッドは、値を出力した後、自動的に改行します。値の出力位置を変更するためには、 `ConsoleCursor` プロパティを設定します。

```cs
DF.Console.Cursor = (4, 8);
DF.Console.Print("Good afternoon.");
```

上の例では、座標 (4, 8) に文字列を出力しています。

コンソールレイヤーの文字サイズや色も変更できます。

```cs
// コンソールレイヤーの文字サイズを 48px に変更
DF.Console.FontSize = 48;

// コンソールレイヤーに表示する文字を赤くする
DF.Console.TextColor = Red;
```

コンソールレイヤーを消去する場合は、Clsメソッド(Clear the Screen の略)を使用します。

```cs
DF.Console.Cls();
```

