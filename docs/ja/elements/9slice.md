# NineSliceSprite

NineSliceSpriteを使うと、1枚のテクスチャを9枚に分割することで、引き伸ばしをスムーズに行う機能である「9スライススプライト」を表現できます。

多くの他社製ゲームエンジンにも取り入れられている機能です。詳しくは [Unity の説明](https://docs.unity3d.com/ja/current/Manual/9SliceSprites.html)を参照。

```cs
// パスと、左上右下の辺からのピクセル数を指定して生成
var sprite = new NineSliceSprite("./path/to/sprite.png", 16, 16, 16, 16);

DF.Root.Add(sprite);

// サイズを変更すると、スムーズに画像のリサイズが行われます
sprite.Width = 256;
sprite.Height = 300;
```
