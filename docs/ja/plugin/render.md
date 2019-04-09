# 独自レンダリング

**Note: この項目は DotFeather およびプログラミング上級者を対象としています。**

## IDrawable の実装

`IDrawable` インターフェイスを実装するクラスを作成するだけで、DotFeather上で扱えるオブジェクトを実装できます。

最新版における `IDrawable` インターフェイスの定義を示します。

```cs
public interface IDrawable
{
    void Draw(GameBase game, Vector location);
    int ZOrder { get; set; }
    string Name { get; set; }
    Vector Location { get; set; }
    float Angle { get; set; }
    Vector Scale { get; set; }
}
```

ZOrder 以降は自動実装プロパティとして実装することをおすすめします。

Draw メソッドの中に実際の描画処理を記述します。引数のlocationとプロパティのLocationを加算した値の位置に描画を行って下さい。

## ITile の実装

`ITile` インターフェイスを実装するクラスを作成するだけで、タイルを自作できます。

最新版における `ITile` インターフェイスの定義を示します。

```cs
public interface ITile
{
    void Draw(GameBase game, Tilemap map, Vector location, Color? color);
}
```

Draw メソッドの中に実際の描画処理を記述します。タイルは1つのインスタンスを複数の位置に設置することが想定されている為、描画位置や色情報を適宜引数として受け取ります。 location 仮引数に入る座標情報はタイルマップの座標ではなく、スクリーンのピクセル座標です。何も算出処理を行う必要なく、そのままの位置に描画を行って下さい。

次: 工事中