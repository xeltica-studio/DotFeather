# 独自レンダリング

**Note: この項目は DotFeather およびプログラミング上級者を対象としています。**

## ElementBaseを継承

`ElementBase` クラスを継承した新たなクラスを作成するだけで、DotFeather上で扱えるオブジェクトを実装できます。

`ElementBase` クラスの詳しい定義は、[API ドキュメント](https://dotfeather.netlify.com/api/dotfeather.elementbase) をご参照ください。

OnRender メソッドをオーバーライドして、実際の描画処理を記述します。描画以外の処理は OnUpdate メソッドをオーバーライドして記述してください。

## ITile の実装

`ITile` インターフェイスを実装するクラスを作成するだけで、タイルを自作できます。

最新版における `ITile` インターフェイスの定義を示します。

```cs
public interface ITile
{
	void Draw(Tilemap map, VectorInt tileLocation, Vector locationToDraw, Color? color);
	void Destroy();
}
```

Draw メソッドを実装し、実際の描画処理を記述します。タイルは1つのインスタンスを複数の位置に設置することが想定されている為、描画位置や色情報を適宜引数として受け取ります。 locationToDraw 仮引数に入る座標情報はタイルマップの座標ではなく、スクリーンのピクセル座標です。何も算出処理を行う必要なく、そのままの位置に描画を行って下さい。
