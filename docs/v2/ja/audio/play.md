# ファイルの再生

読み込んだオーディオソースを実際に再生します。

オーディオソースは、 `AudioPlayer` クラスを使用することでデバイス上で再生できます。

その例を次に示します。

```cs
// オーディオソースを読み込む
var bgm = new VorbisAudioSource("./assets/bgm/battle.ogg");
var sfx1 = new VorbisAudioSource("./assets/sfx/attack.wav");
var sfx2 = new VorbisAudioSource("./assets/sfx/hurt.wav");

// インスタンスを初期化する
var player = new AudioPlayer();

// BGMの再生
player.Play(bgm);

// 効果音を再生する
player.PlayOneShot(sfx1);

// 効果音を再生する
player.PlayOneShot(sfx2);

// 5秒フェードアウトして停止する
player.Stop(5);

// すぐに停止する
player.Stop();
```


次: [コルーチン](../coroutine.md)
