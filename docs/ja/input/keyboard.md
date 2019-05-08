# キーボード入力

キーボードからの入力を取得するには、 `Input.Keyboard` プロパティを使用します。

Keyboard プロパティの子要素には、あらゆるキーの名前がプロパティとしてあります。

実際の使用例を述べます。

```cs
// A を押したか判定する
if (Input.Keyboard.A.IsPressed)
{
	Console.WriteLine("Aが押されている");
}


if (Input.Keyboard.B.IsKeyDown)
{
	Console.WriteLine("Bが押された");
}

if (Input.Keyboard.B.IsKeyUp)
{
	Console.WriteLine("Bが離された");
}
```

次: [オーディオ](../audio.md)
