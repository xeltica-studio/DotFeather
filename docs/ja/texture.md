# テクスチャ

テクスチャとは、 DotFeather で使用できる画像データを指します。

DotFeatherには、現在2種類のテクスチャフォーマットがあります。

## Texture2D

Texture2D は、2次元のビットマップ テクスチャを表す構造体です。DotFeather の多くの場面で用いられるテクスチャフォーマットです。

次に示すとおり `Texture2D` 構造体の静的メソッドを呼ぶことで読み込めます。

```cs
Texture2D texture = Texture2D.LoadFrom("./assets/title.png");
```

### テクスチャの分割読み込み

スプライトシートという、一枚の画像にアニメーション用の絵が格子状に配置されているような画像を簡単に読み込めるよう、 DotFeather には、テクスチャを分割して読み込む機能があります。

```cs
Texture2D[] textures = Texture2D.LoadAndSplitFrom("./assets/zombie.png", 16, 2, new Size(16, 16));
```

このプログラムは、 ./assets/zombie.png にあるファイルを読み込み、16x16のテクスチャとして、横16個、縦2個、合計32個切り出します。

## Texture9Sliced

Texture9Sliced は、9分割された2次元のビットマップ テクスチャを表す構造体です。
現在は NineSliceSprite エレメントで用いられることを想定しています。

詳しくは[NineSliceSprite](elements/9slice.md)を参照してください。
