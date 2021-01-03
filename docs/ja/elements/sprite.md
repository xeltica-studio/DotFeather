# Sprite

Sprite を使うと、画面上の自由な位置にテクスチャを描画できます。ゲームキャラや弾丸の表示などに利用できます。

## スプライト

テクスチャを読み込んだら、スプライトのインスタンスを生成して表示させられます。

```cs
Sprite title = new Sprite(texture) { Location = (0, 32) };
Sprite zombie = new Sprite(textures[0]) { Location = (64, 16) };
DF.Root.Add(sprite);
```

また、ファイル名を指定して直接スプライトを生成することも出来ます。

```cs
Sprite sprite = new Sprite("./assets/skeleton.png");
```

## アニメーションするスプライト

スプライトをアニメーションさせたい場合は、`SpriteAnimator` コンポーネントを使用します。コンポーネントについて詳しくは[コンポーネント](../component.md) を参照。

`SpriteAnimator` コンポーネントをスプライトにアタッチすると、分割読み込みしたテクスチャ配列を読み込んで、自動的にテクスチャアニメーションを行うことができます。

実際に使ってみましょう。

```cs
var zombie = new Sprite();
DF.Root.Add(zombie);
var walker = zombie.AddComponent<SpriteAnimator>();
// テクスチャの配列
walker.Textures = textures;
// ループ回数。-1を指定すると無限ループし、0を指定するとループしません。
walker.LoopTimes = -1;
// 1枚の画像にかけるフレーム数。数値が小さいほど高速でアニメーションします。
walker.Duration = 4;
```
