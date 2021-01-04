# エレメント

DotFeather において、描画する要素は全て **エレメント** という単位で表現されます。

エレメントには、複数の要素を描画する**レイヤーエレメント**と、単一の要素を描画する**プリミティブエレメント**があり、それぞれ次のものがあります。

- **レイヤーエレメント**
	- [Graphic](graphic.md)
	- [Tilemap](tilemap.md)
	- [Container](container.md)
- **プリミティブエレメント**
	- [Shape](shape.md)
	- [Sprite](sprite.md)
	- [TextElement](text.md)
	- [NineSliceSprite](9slice.md)

エレメントは全て、 `ElementBase` クラスの派生クラスであり、フレーム更新毎にレンダリングされます。

エレメントを画面に描画する場合は、 `DF.Root.Add()` メソッドを用います。

```cs
var cont = new Container();
DF.Root.Add(cont);

// 画面の描画をやめる場合は、Removeメソッドを用います
DF.Root.Remove(cont);
```
