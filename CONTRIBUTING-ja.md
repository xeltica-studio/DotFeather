# コントリビューションの手引き

[English](CONTRIBUTING.md)

**コントリビュートにご協力いただきありがとうございます！その前に、このガイドをお読みいただければと思います。**

## 貢献者へ

あなたがこのプロジェクトに提供したソースコードには、他のコードと同様に LICENSE ファイルに記載されるライセンスが付与されることに同意してください。

## Issue

新機能の要望やバグ報告などは [GitHub Issues](https://github.com/Xeltica/DotFeather/Issues) にてお願いします。 Issue を作成する前に、重複を避けるため既に存在している同じような Issue が存在しないかどうか検索をしてください。もし存在するならば、リアクションやコメントを用いて upvote してください。

## 文書化

- 日本語版ドキュメントは `/docs/ja` にあります。
- 英語版ドキュメントは `/docs/` にあります。

## 継続的インテグレーション

DotFeather では、 AppVeyor を用いてデプロイの自動化を行っています。設定ファイルは  `/appveyor.yml` にあります。

## コーディング規則

基本的には [C# のコーディング規則(公式)](https://docs.microsoft.com/ja-jp/dotnet/csharp/programming-guide/inside-a-program/coding-conventions) に従います。その上で、次の規約に従うこと

- インデントは4文字タブ(ハードタブ)にすること。
- フィールドを `public` にしないこと。
- `private` を省略しないこと。
- クラスや構造体のメンバーは次の順番で定義すること。
	- プロパティ
	- コンストラクター
		- 複数存在する場合は、仮引数の少ない順に並べること。
	- メソッド
	- オーバーライドされたメソッド
	- フィールド
	- ネストされたクラス, 構造体, インターフェイス
	- デリゲート
- メソッドをオーバーロードする場合は連続して配置すること。
- エントリポイントは専用の `static` クラスに定義すること。
- 文字列変数は基本的に Null 非許容とし、初期値として空文字列を挿入すること。

## 設計上の規則

### 公開APIをSilk.NET等の外部ライブラリに依存させないこと

DotFeatherでは、Silk.NET等のバックエンドに依存しないようAPIを設計しています。

新しくAPIを追加する場合、このようなバックエンドにある型を引数や戻り値に使用しないでください。内部的に使う場合や、private、internalなメンバーの場合は使用しても良いです。

## デプロイ手順

デプロイはメイン開発者の @Xeltica が行います。従ってこの項目はフォークされたプロジェクトの管理者向けの情報となります。

1. 最新版の変更がビルドできて、サンプルコードに不具合が発生しないことを確認する
1. master に最新版をコミットする
1. DotFeather/DotFeather.nuspec 内のバージョン表記を書き換える
1. appveyor.yml 内のバージョン表記を書き換える
1. 上記の変更をコミットする
1. そのコミットにバージョン名のタグをつける
1. push する
1. :pray:

## デプロイに問題が起きた場合
