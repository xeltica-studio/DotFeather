# ルーター

ルーターは、DotFeather のためのシーン管理機能です。

以前は DotFeather.Router という別パッケージで提供されていましたが、 v2 より統合されました。

ルーターを用いてシーンA, シーンB, シーンCを切り替える手順を示します。

## ルーターを使用する

ルーターを使用するためには、`GameBase` を継承したクラスに特別な設定が必要です。具体的には次のように行います。

### クイックスタート

`GameBase` クラスを継承して新たにゲームクラスを作成する代わりに、 `RoutingGameBase` クラスのインスタンスを初期化することで素早く始めることができます。

エントリーポイントを次のように記述します。

```cs
static void Main()
{
	using (var g = new RoutingGameBase<Root>(320, 240))
	{
		// 必要であれば、ここでフレーム更新のイベントをハンドリングします。
		g.Update += (s, e) =>
		{
			Console.WriteLine(e.DeltaTime);
		};

		g.Run();
	}
}
```

RoutingGameBase クラスの型引数には、最初に読み込まれるシーンの型を記述します。



### マニュアルスタート

これまで通りのゲームクラスに新しくルーターをセットアップするためには、次のように設定します。

```cs
class Game : GameBase
{
	public Game(int width, int height, string title = "", int refreshRate = 60) : base(width, height, title, refreshRate)
	{
		// ルーターを、ゲームのインスタンスを渡して初期化する
		router = new Router(this);
	}

	protected override void OnLoad(object sender, EventArgs e)
	{
		// 初期シーンをここで読み込む
		router.ChangeScene<Root>();
	}

	protected override void OnUpdate(object sender, DFEventArgs e)
	{
		// ルーターにアップデートさせる
		router.Update(e);
	}

	private Router router;
}
```

## シーンを作成

シーンは、 `Scene` クラスを継承することで作成できます。 `GameBase` の継承と似た感覚で作れます。

```cs
public class Root : Scene
{
	public override void OnStart(Router router, GameBase game, Dictionary<string, object> args)
	{
		Print("Commands: ");
		Print(" A: Go to the Scene A");
		Print(" B: Go to the Scene B");
		Print(" C: Go to the Scene C");
	}

	public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
	{
		if (DFKeyboard.A)
			router.ChangeScene<SceneA>();
		if (DFKeyboard.B)
			router.ChangeScene<SceneB>();
		if (DFKeyboard.C)
			router.ChangeScene<SceneC>();
	}
}
```

```cs
public class SceneA : Scene
{
	public override void OnStart(Router router, GameBase game, Dictionary<string, object> args)
	{
		Print("A");
		Print("Press ESC to return");
	}

	public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
	{
		if (DFKeyboard.Escape) router.ChangeScene<Root>();
	}
}
```

```cs
public class SceneB : Scene
{
	public override void OnStart(Router router, GameBase game, Dictionary<string, object> args)
	{
		Print("B");
		Print("Press ESC to return");
	}

	public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
	{
		if (DFKeyboard.Escape) router.ChangeScene<Root>();
	}
}
```

```cs
public class SceneC : Scene
{
	public override void OnStart(Router router, GameBase game, Dictionary<string, object> args)
	{
		Print("C");
		Print("Press ESC to return");
	}

	public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
	{
		if (DFKeyboard.Escape) router.ChangeScene<Root>();
	}
}
```

`Router.ChangeScene<T>()` メソッドを実行すると、シーンを遷移できます。第2引数に辞書型変数を渡すことで、次のシーンの `OnStart()` に値を渡せます。

また、

```cs
router.ChangeScene(typeof(SceneA));
```
のように、`Type` 型を指定することもできます。

## シーンを登録

上記の例では、シーンの型を直接指定しましたが、シーンをあらかじめ登録し、パスを用いて呼び出すこともできます。

パスを指定して上記の3つのシーンを登録する例を示します。
```cs
router.RegisterScene<SceneA>("a");
router.RegisterScene<SceneB>("b");

// Type 型でも指定できる
router.RegisterScene(typeof(SceneC), "c");
```

登録したシーンへ遷移する例を示します。

```cs
router.ChangeScene("a");
```

シンプルに、型を直接指定していた部分を、パスに置き換えただけです。もちろん、第２引数に辞書を渡せます。

次: [独自レンダリング](plugin/render.md)
