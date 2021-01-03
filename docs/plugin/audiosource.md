# 独自オーディオソース

**Note: この項目は DotFeather およびプログラミング上級者を対象としています。**

`IAudioSource` インターフェイスを実装するクラスを作成することで、あらゆるフォーマットの音声を再生できます。


最新版の `IAudioSource` の定義を次に示します:

```cs
public interface IAudioSource
{
	IEnumerable<(short left, short right)> EnumerateSamples(int? loopStart);
	int? Samples { get; }
	int Channels { get; }
	int Bits { get; }
	int SampleRate { get; }
}
```

`EnumerateSamples` メソッドは、音声データのサンプルをタプル形式で返すイテレーターです。モノラルであっても、8bitPCMであっても、16bitのステレオに変換する必要があります。

`Samples` プロパティはオーディオソースのサンプル数です。ライブストリーミングなどのように、サンプル数が定かでない場合は null を返します。

`Channels` プロパティ、はオーディオソースのチャンネル数です。

`Bits` プロパティは、オーディオソースの量子化ビット数です。

`SampleRate` プロパティは、オーディオソースのサンプリング周波数です。


これらを実装したオーディオソースは、実際に `AudioPlayer` クラスを用いて再生することが出来ます。
