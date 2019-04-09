# <img src="docs/logo.svg"/> 
[![Build status](https://img.shields.io/appveyor/ci/xeltica/dotfeather.svg?style=for-the-badge)][ci]
[![GitHub issues](https://img.shields.io/github/issues/xeltica/dotfeather.svg?style=for-the-badge)][issues]
[![GitHub pull requests](https://img.shields.io/github/issues-pr/xeltica/dotfeather.svg?style=for-the-badge)][pulls]
[![GitHub Releases](https://img.shields.io/github/release-pre/xeltica/DotFeather.svg?style=for-the-badge)][releases]
[![License](https://img.shields.io/github/license/xeltica/dotfeather.svg?style=for-the-badge)](LICENSE)
[![Nuget](https://img.shields.io/nuget/vpre/DotFeather.svg?style=for-the-badge)](https://www.nuget.org/packages/DotFeather/)

[ci]: https://ci.appveyor.com/project/Xeltica/dotfeather
[issues]: //github.com/xeltica/dotfeather/issues
[pulls]: //github.com/xeltica/dotfeather/pulls
[releases]: //github.com/xeltica/dotfeather/releases

DotFeather (ドットフェザー)は、 C# と .NET Standard 2.0 のための、軽量で汎用的な2Dゲームエンジンです。

[English](README.md) ・ 日本語

## ビルドの仕方

```
git clone https://github.com/xeltica/DotFeather.git
cd DotFeather
nuget restore
dotnet build
```

## 機能

- 軽快な処理
    - 10000 スプライトを60fpsで表示可能 [<sup>*1</sup>](#f1)
- 2Dに特化したグラフィックシステム
    - スプライト - 画面上へのテクスチャ表示
    - タイルマップ - テクスチャを敷き詰めたマップ表示
    - グラフィック - 線分や矩形を1ピクセル単位で描画
- キーボード入力
- マウス入力
- 音楽再生
- 効果音再生
- 高い拡張性
    - 独自の描画機能の追加
    - オーディオ機能の拡張

----

<p id="f1">1: ユーザーのコンピュータースペックに依存します。</p>

## ドキュメント

[ドキュメント](docs/ja/index.md)

## コントリビュートの仕方

しばしお待ち下さい

## 寄付

寄付をしたい！という方、大変ありがとうございます。[このページ](//xeltica.work/donation.html)に私への寄付手段がまとまっているので、ご確認ください。

もしくは Patreon で私のパトロンになってください！

[![become_a_patron](https://c5.patreon.com/external/logo/become_a_patron_button@2x.png)](https://patreon.com/xeltica)

## ライセンス

[MIT](LICENSE)
