# DotFeather [![GitHub issues](https://img.shields.io/github/issues/badges/shields.svg?style=flat-square)][issues] [![GitHub pull requests](https://img.shields.io/github/issues-pr/cdnjs/cdnjs.svg?style=flat-square)][pulls] [![GitHub Releases](https://img.shields.io/github/release/xeltica/DotFeather.svg?style=flat-square)][releases] [![License](https://img.shields.io/github/license/xeltica/dotfeather.svg?style=flat-square)](LICENSE)

[issues]: /xeltica/dotfeather/issues
[pulls]: /xeltica/dotfeather/pulls
[releases]: /xeltica/dotfeather/releases

DotFeather (ドットフェザー)は、C#と.NET Standard 2.0のための、軽量で汎用的な2Dゲームエンジンです。

[English](README.md) ・ 日本語

## ビルドの仕方

```
git clone https://github.com/xeltica/DotFeather.git
cd DotFeather
nuget restore
dotnet build
```

## 使用例

### 図形の書き方

```cs
// クラス Game : GameBase 内部
var g = new GraphicLayer();
this.Layers.Add(g);

g.Line(0, 0, 400, 400, Color.Red);
g.Line(0, 400, 0, 400, Color.Blue);
g.Circle(0, 0, 400, 400, Color.Green);
```

[詳しいサンプルソース](DotFeather.Test.NetCore)

## コントリビュートの仕方

しばしお待ち下さい

## 寄付

寄付をしたい！という方、大変ありがとうございます。[このページ](//citringo.net/en/donation.html)に私への寄付手段がまとまっているので、ご確認ください。

## ライセンス

[MIT](LICENSE)
