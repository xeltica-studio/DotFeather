# キーボード入力

キーボードからの入力を取得するには、 `DFKeyBoard` プロパティを使用します。

Keyboard プロパティの子要素には、あらゆるキーの名前がプロパティとしてあります。

実際の使用例を述べます。

```cs
// A を押したか判定する
if (DFKeyBoard.A.IsPressed)
{
	Console.WriteLine("Aが押されている");
}


if (DFKeyBoard.B.IsKeyDown)
{
	Console.WriteLine("Bが押された");
}

if (DFKeyBoard.B.IsKeyUp)
{
	Console.WriteLine("Bが離された");
}
```

次: [オーディオ](../audio.md)
