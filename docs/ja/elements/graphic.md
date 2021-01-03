# Graphic

Graphic エレメントを使うと、点、線、矩形、テクスチャといった要素を描画できます。

## 使い方

次のように、生成したインスタンスの、描画したい図形に対応するメソッドを呼び出します。

```cs
var graphic = new Graphic();

// 点
graphic.Pixel(32, 32, Color.Black);
// 線
graphic.Line(0, 0, 64, 64, Color.Red);
// 矩形
graphic.Rect(0, 0, 64, 64, Color.Green);
```
