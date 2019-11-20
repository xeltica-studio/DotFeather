# マウス入力

マウスからの入力を取得するには、 `DFMouse` プロパティを使用します。

マウス入力に関わる全ての例を述べます。

```cs
// マウスの座標
var (px, py) = DFMouse.Position;
// スクロールの移動量
var (scrX, scrY) = DFMouse.Scroll;

// ボタン判定

// -- クリックしているかどうか
if (DFMouse.IsLeft)
	Console.WriteLine("左クリック");
if (DFMouse.IsMiddle)
	Console.WriteLine("中クリック");
if (DFMouse.IsRight)
	Console.WriteLine("右クリック");

// -- たった今クリックしたかどうか
if (DFMouse.IsLeftDown)
	Console.WriteLine("左が今押された");
if (DFMouse.IsMiddleDown)
	Console.WriteLine("中が今押された");
if (DFMouse.IsRightDown)
	Console.WriteLine("右が今押された");

// -- たった今クリックしたかどうか
if (DFMouse.IsLeftUp)
	Console.WriteLine("左が今離された");
if (DFMouse.IsMiddleUp)
	Console.WriteLine("中が今離された");
if (DFMouse.IsRightUp)
	Console.WriteLine("右が今離された");
```

次: [キーボード入力](keyboard.md)
