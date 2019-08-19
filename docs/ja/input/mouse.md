# マウス入力

マウスからの入力を取得するには、 `Input.Mouse` プロパティを使用します。

マウス入力に関わる全ての例を述べます。

```cs
// マウスの座標
var pos = Input.Mouse.Position;
// スクロールの移動量
var (scrX, scrY) = Input.Mouse.Scroll;

// ボタン判定

// -- クリックしているかどうか
if (Input.Mouse.IsLeft)
	Console.WriteLine("左クリック");
if (Input.Mouse.IsMiddle)
	Console.WriteLine("中クリック");
if (Input.Mouse.IsRight)
	Console.WriteLine("右クリック");

// -- たった今クリックしたかどうか
if (Input.Mouse.IsLeftDown)
	Console.WriteLine("左が今押された");
if (Input.Mouse.IsMiddleDown)
	Console.WriteLine("中が今押された");
if (Input.Mouse.IsRightDown)
	Console.WriteLine("右が今押された");

// -- たった今クリックしたかどうか
if (Input.Mouse.IsLeftUp)
	Console.WriteLine("左が今離された");
if (Input.Mouse.IsMiddleUp)
	Console.WriteLine("中が今離された");
if (Input.Mouse.IsRightUp)
	Console.WriteLine("右が今離された");
```

次: [キーボード入力](keyboard.md)
