# グラフィック

グラフィックスクリーンは、点、線、矩形、テクスチャといったグラフィックを描画できるオブジェクトです。

## 使い方


グラフィックオブジェクトを使うためには、まず `Graphic` クラスのインスタンスを生成します。その後、生成したインスタンスをゲームの Root プロパティに追加します。

```cs
var graphic = new Graphic();
Root.Add(graphic);
```

次のように、描画したい図形に対応するメソッドを呼び出します。

```cs
// 点
graphic.Pixel(32, 32, Color.Black);
// 線
graphic.Line(0, 0, 64, 64, Color.Red);
// 矩形
graphic.Rect(0, 0, 64, 64, Color.Green);
```

次: [スプライト](sprite.md)