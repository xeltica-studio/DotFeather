# ルーター

ルーターは、DotFeather のためのシーン管理機能です。

ルーターを用いてシーンA, シーンB, シーンCを切り替える手順を示します。

## シーンを作成

シーンは、 `Scene` クラスを継承することで作成できます。

```cs
public class Root : Scene
{
	public override void OnStart(Dictionary<string, object> args)
	{
		Print("Commands: ");
		Print(" A: Go to the Scene A");
		Print(" B: Go to the Scene B");
		Print(" C: Go to the Scene C");
	}

	public override void OnUpdate()
	{
		if (DFKeyboard.A)
			Router.ChangeScene<SceneA>();
		if (DFKeyboard.B)
			Router.ChangeScene<SceneB>();
		if (DFKeyboard.C)
			Router.ChangeScene<SceneC>();
	}
}
```

```cs
public class SceneA : Scene
{
	public override void OnStart(Dictionary<string, object> args)
	{
		Print("A");
		Print("Press ESC to return");
	}

	public override void OnUpdate()
	{
		if (DFKeyboard.Escape) Router.ChangeScene<Root>();
	}
}
```

```cs
public class SceneB : Scene
{
	public override void OnStart(Dictionary<string, object> args)
	{
		Print("B");
		Print("Press ESC to return");
	}

	public override void OnUpdate()
	{
		if (DFKeyboard.Escape) Router.ChangeScene<Root>();
	}
}
```

```cs
public class SceneC : Scene
{
	public override void OnStart(Dictionary<string, object> args)
	{
		Print("C");
		Print("Press ESC to return");
	}

	public override void OnUpdate()
	{
		if (DFKeyboard.Escape) Router.ChangeScene<Root>();
	}
}
```

`DF.Router.ChangeScene<T>()` メソッドを実行すると、シーンを遷移できます。第1引数に辞書型変数を渡すことで、次のシーンの `OnStart()` に値を渡せます。

また、

```cs
DF.Router.ChangeScene(typeof(SceneA));
```
のように、`Type` 型を指定することもできます。

## シーンを登録

上記の例では、シーンの型を直接指定しましたが、シーンをあらかじめ登録し、パスを用いて呼び出すこともできます。

パスを指定して上記の3つのシーンを登録する例を示します。
```cs
DF.Router.RegisterScene<SceneA>("a");
DF.Router.RegisterScene<SceneB>("b");

// Type 型でも指定できる
DF.Router.RegisterScene(typeof(SceneC), "c");
```

登録したシーンへ遷移する例を示します。

```cs
DF.Router.ChangeScene("a");
```

シンプルに、型を直接指定していた部分を、パスに置き換えただけです。もちろん、第２引数に辞書を渡せます。

