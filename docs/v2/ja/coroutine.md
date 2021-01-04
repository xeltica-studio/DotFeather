# コルーチン

コルーチンは、バックグラウンドで非同期的に動作するルーチンです。

## 概要

通常、ゲームのロジックは、 GameBase.OnUpdate() の中に記述します。しかしながら、パーティクルやローディング画面のように、非同期的な処理を必要とするケースにおいて、このアプローチは非効率です。コルーチンはこの問題を解決します。

コルーチンは、 `System.Collecitons.IEnumerator` インターフェイスを返すメソッドの形で記述します。コルーチンの定義例を次に示します。

```cs
// あらかじめ次に示す Drawables が定義されているものとする
TextDrawable text;

IEnumerator CountDown()
{
	text = "Are you ready?";
	yield return new WaitForSeconds(2);
	for (var i = 3; i > 0; i--)
	{
		text = i.ToString();
		yield return new WaitForSeconds(1);
	}
	text = "GO!";
}
```

このようにして定義したコルーチンは、次のようにして実行します。

```cs
// ゲームクラス内からは次のようにして呼び出せます。
var coroutine = StartCoroutine(CountDown());

// その他のコンテキストからは次のようにして呼び出せます。
var coroutine = CoroutineRunner.Start(CountDown));
```

どちらのメソッドも、 [Coroutine クラス](https://dotfeather.netlify.com/api/dotfeather.coroutine) のインスタンスを返します。このインスタンスを操作することでコルーチンの制御ができます。

## コルーチンの停止

例えば、コルーチンを途中で停止する場合は `StopCoroutine` メソッドを呼び出します。

```cs
// ゲームクラス内からは次のようにして呼び出せます。
StopCoroutine(coroutine);

// その他のコンテキストからは次のようにして呼び出せます。
CoroutineRunner.Stop(coroutine);
```

## コルーチンコールバック

コルーチンが終了したとき、またコルーチン内部でハンドルされていない例外が発生した場合にコールバックを指定することもできます。 JavaScript の Promise API に似た記法で書けます。

```cs
StartCoroutine(CountDown(false))
	.Then(_ =>
	{
		Console.WriteLine("Successfully finished!");
	});

StartCoroutine(CountDown(true))
	.Error(e =>
	{
		Console.WriteLine($"Something happened!!!\n{e.GetType().Name}: {e.Message}\n{e.StackTrace}");
	});

IEnumerator CountDown(bool error)
{
	text = "Are you ready?";
	yield return new WaitForSeconds(2);
	for (var i = 3; i > 0; i--)
	{
		text = i.ToString();
		yield return new WaitForSeconds(1);
		if (error && i == 1) throw new Exception("Error");
	}
	text = "GO!";
}
```

## イールド命令

コルーチンは C# の `yield` パターンを応用しています。特定のオブジェクトを返すことでコルーチンの実行を中断し、また再開できます。このときに渡すオブジェクトのことをイールド命令と呼びます。例えば、 `WaitForSeconds` イールド命令は指定した秒数だけコルーチンの実行を中断します。

### 使い方

イールド命令をコルーチン内で使用する方法を次に示します。

```cs
// 3秒待機します。
yield return new WaitForSeconds(3);

// コルーチンの実行が終わるまで待機します。
yield return TheCoroutine();
```

### ビルトイン

DotFeather には、あらかじめ次のイールド命令がビルトインされています。また、いくつかのオブジェクトも特別にイールド命令として扱われます。

|定義|概要|
|---|---|
|`WaitForSeconds(float seconds);`|seconds 秒だけ待機します。|
|`WaitUntil(Func<bool> conditions);`|デリゲートで条件を渡して、満たされるまで待機します。|
|`WaitWhile(Func<bool> conditions);`|WaitUntil の逆で、条件が満たされている間だけ待機します。|
|`WaitUntilNextFrame();`|次のフレームまで待機します。|
|`WaitForTask`|指定したタスクの実行が終わるまで待機します。|
|`Task` および `ValueTask`|タスクが完了するまで待機します。|
|`Coroutine`|コルーチンが終わるまで待機します。|
|`IEnumerator`|コルーチンとして実行し、実行が終わるまで待機します。|
|その他の Object 派生型および `null`|`WaitUntilNextFrame` として振る舞います。|

次: [ルーター](./router.md)
