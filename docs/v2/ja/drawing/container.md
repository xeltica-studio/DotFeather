# コンテナー

コンテナーは、他のオブジェクトを子要素として持つことのできる、フォルダのようなオブジェクトです。

コンテナーに所有されているオブジェクトは、コンテナーの座標を基準とした相対位置に描画されます。つまり、コンテナーを移動させることで、内包する全てのオブジェクトも同時に移動するということです。

この仕組みを利用して、多関節キャラクターを作ったり、レイヤーのような仕組みを作ったりすることができます。

実はここで教えるよりもずっと前から、あなたはコンテナーを使用しています。それは、ゲームの `Root` プロパティです。

コンテナーを生成してスプライトを持たせて表示する例を次に示します。

```cs
var container = new Container();

// スプライト生成
var left = new Sprite(Texture2D.LoadFrom("./left.png"), -16, 0);
var right = new Sprite(Texture2D.LoadFrom("./right.png"), 16, 0);
var top = new Sprite(Texture2D.LoadFrom("./top.png"), 0, -16);
var bottom = new Sprite(Texture2D.LoadFrom("./bottom.png"), 0, 16);

// コンテナーへのスプライト追加
container.Add(left);
container.Add(right);
container.Add(top);
container.Add(bottom);

Root.Add(container);

// コンテナーを動かす
container.X = 128;
container.Y = 96;
```

コンテナーは通常、コンテナー自身の領域からはみ出た子オブジェクトも関係なく描画しますが、はみ出た領域をクリッピングするよう設定することもできます。次のように書くだけです。

```cs
container.IsTrimmable = true;

// 幅、高さの指定を忘れずに
container.Width = 128;
container.Height = 128;
```

これにより、コンテナーの領域を表す四辺形からはみ出た子オブジェクトは、その部分がクリッピングされます。

次: [9スライススプライト](./9slice.md)
