# Container

Container を使用すると、他のエレメントを子要素としてグループ化できます。

コンテナーの子要素は、コンテナーの座標を基準とした相対位置に描画されます。つまり、コンテナーを移動させることで、内包する全てのエレメントも同時に移動するということです。

この仕組みを利用して、多関節キャラクターを作ったり、レイヤーのような仕組みを作ったりすることができます。

また、`DF.Root` プロパティの中身はContainerです。

コンテナーを生成し、スプライトを持たせて表示する例を次に示します。

```cs
var container = new Container();

// スプライト生成
var left = new Sprite("./left.png") { Location = (-16, 0) };
var right = new Sprite("./right.png") { Location = (16, 0) };
var top = new Sprite("./top.png") { Location = (0, -16) };
var bottom = new Sprite("./bottom.png") { Location = (0, 16) };

// コンテナーへのスプライト追加
container.Add(left);
container.Add(right);
container.Add(top);
container.Add(bottom);

DF.Root.Add(container);

// コンテナーを動かす
container.X = 128;
container.Y = 96;
```

子要素の、コンテナー領域からはみ出た部分をクリッピングするよう設定することもできます。次のように書くだけです。

```cs
container.IsTrimmable = true;

// 幅、高さの指定を忘れずに
container.Width = 128;
container.Height = 128;
```

これにより、コンテナーの領域からはみ出たエレメントは、その部分がクリッピングされます。
