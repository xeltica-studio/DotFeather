# ファイルの読み込み

この記事では、音声ファイルを読み込む手順を示します。

## WaveAudioSource クラス

Wave ファイルを読み込むためには、 `IAudioSource` インターフェイスの実装である `WaveAudioSource` クラスを使用します。コンストラクターにファイルパスを指定するだけでファイルを読み込むことが出来ます。

実際に Wave ファイルを読み込む例を次に示します。

```cs
var source = new WaveAudioSource("./assets/voice/zombie/hurt.wav");
```

## VorbisAudioSource クラス

Ogg Vorbis ファイルを読み込むためには、 `IAudioSource` インターフェイスの実装である `VorbisAudioSource` クラスを使用します。コンストラクターにファイルパスを指定するだけでファイルを読み込むことが出来ます。

実際に Ogg Vorbis ファイルを読み込む例を次に示します。

```cs
var source = new VorbisAudioSource("./assets/bgm/battle.ogg");
```

これだけでファイルを読み込むことが出来ます。

----

Wave ファイルはデコードが不要ですばやく再生できるため、効果音に向いています。一方で、全データをメモリにロードするため、長い音楽には向きません。

Ogg Vorbis ファイルはデコードに少し時間がかかるため、効果音などの短い音にとっては非効率です。一方で、データを少しずつメモリにロードしながら再生できるため、長い音楽に向いています。
