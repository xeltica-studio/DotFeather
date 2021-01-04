# コンポーネント

コンポーネントを使うと、[エレメント](elements/index.md) の挙動を拡張できます。

DotFeather に内蔵されているコンポーネントは SpriteAnimator(詳しくは[Sprite](elements/sprite.md)を参照)のみですが、自作することもできます。

## コンポーネントを自作する

コンポーネントを作成するためには、`Component` クラスを継承します。

ここでは、例として「アタッチされたエレメントの型名をコンソールに出力するコンポーネント」を作ります。

```cs
public class ExampleComponent : Component
{
	public override void OnStart()
	{
		DF.Console.Print(Element.GetType().Name);
	}
}
```

`OnStart` 仮想メソッドをオーバーライドすると、コンポーネントが有効化された（=アタッチされた）瞬間の動作を記述できます。

他にも、毎フレーム呼び出される`OnUpdate`メソッド、コンポーネントが破棄される瞬間に呼び出される`OnDestroy`メソッド、レンダリング中に呼び出される`OnRender`メソッドがあります。

Component クラスの `Element` プロパティで、コンポーネントがアタッチされたエレメントを取得できます。

これらのAPIを使用して、エレメントの動作を拡張できます。

## コンポーネントをアタッチする

コンポーネントをアタッチする場合は、エレメントの `AddComponent<T>` メソッドを呼びます。

```cs
var container = new Container();

container.AddComponent<ExampleComponent>();
```

`AddComponent<T>` メソッドは生成されたコンポーネントのインスタンスを返します。

## コンポーネントを取得する

アタッチされたコンポーネントを取得する場合は、エレメントの `GetComponent<T>` メソッドを呼びます。

```cs
var comp = container.GetComponent<ExampleComponent>();
```


## コンポーネントを削除する

アタッチされたコンポーネントを削除する場合は、エレメントの `RemoveComponent<T>` メソッドを呼びます。

```cs
container.RemoveComponent(comp);
```
