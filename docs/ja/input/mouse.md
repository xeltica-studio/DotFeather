# マウス入力

マウスからの入力を取得するには、 `Input` 静的クラスの `Mouse` プロパティを使用します。

マウス入力に関わる全ての例を述べます。

```cs
// マウスの座標
var pos = Input.Mouse.Position;
// スクロールの移動量
var (scrX, scrY) = Input.Mouse.Scroll;

// ボタン判定
if (Input.Mouse.IsLeftButtonClicked)
    Console.WriteLine("左クリック");
if (Input.Mouse.IsMiddleButtonClicked)
    Console.WriteLine("中クリック");
if (Input.Mouse.IsRightButtonClicked)
    Console.WriteLine("右クリック");
```

次: [キーボード入力](keyboard.md)