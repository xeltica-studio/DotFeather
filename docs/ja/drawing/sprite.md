# スプライト

スプライトは、画面上の自由な位置にテクスチャを描画するためのオブジェクトです。ゲームキャラや弾丸の表示などに利用できます。

## テクスチャ

テクスチャとは、 DotFeather で読み込まれた画像データを指します。

テクスチャは `Texture2D` 構造体で表現され、次に示すとおり `Texture2D` 構造体の静的メソッドを呼ぶことで読み込めます。

```cs
Texture2D texture = Texture2D.LoadFrom("./assets/title.png");
```

### テクスチャの分割読み込み

スプライトシートという、一枚の画像にアニメーション用の絵が格子状に配置されているような画像を簡単に読み込めるよう、 DotFeather には、テクスチャを分割して読み込む機能があります。

```cs
Texture2D[] textures = Texture2D.LoadAndSplitFrom("./assets/zombie.png", 16, 2, new Size(16, 16));
```

このプログラムは、 ./assets/zombie.png にあるファイルを読み込み、16x16のテクスチャとして、横16個、縦2個、合計32個切り出します。 DXライブラリの「LoadDivGraph()」関数などに該当します。

## スプライト

テクスチャを読み込んだら、スプライトのインスタンスを生成して表示させられます。

```cs
Sprite title = new Sprite(texture, 0, 32);
Sprite zombie = new Sprite(textures[0], 64, 16);
Root.Add(sprite);
```

また、ファイル名を指定して直接スプライトを生成することも出来ます。

```cs
Sprite sprite = Sprite.LoadFrom("./assets/skeleton.png");
```

次: [タイルマップ](tilemap.md)
