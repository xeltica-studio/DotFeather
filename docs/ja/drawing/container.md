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

次: [3スライススプライト](./3slice.md)
