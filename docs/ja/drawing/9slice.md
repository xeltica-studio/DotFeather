# 9スライススプライト

9スライススプライトとは、1枚のテクスチャを9枚に分割することで、引き伸ばしをスムーズに行えるスプライトです。

多くの他社製ゲームエンジンにも取り入れられている機能です。詳しくは [Unity の説明](https://docs.unity3d.com/ja/current/Manual/9SliceSprites.html)が詳しいです。

```cs
// パスと、左上右下の辺からのピクセル数を指定して生成
var sprite = NineSliceSprite.LoadFrom("./path/to/sprite.png", 16, 16, 16, 16);

Root.Add(sprite);

// サイズを変更すると、スムーズに画像のリサイズが行われます
sprite.Width = 256;
sprite.Height = 300;
```

次: [マウス入力](../input/mouse.md)
