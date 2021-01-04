# Load Files

This article shows how to load audio files.

## WaveAudioSource Class

To load Wave files, use the `WaveAudioSource` class, which is an implementation of the` IAudioSource` interface. You can read a file simply by specifying the file path in the constructor.

The following is an example of actually loading a Wave file.

```cs
var source = new WaveAudioSource("./assets/voice/zombie/hurt.wav");
```

## VorbisAudioSource Class

To load Ogg Vorbis files, use the `VorbisAudioSource` class, which is an implementation of the` IAudioSource` interface. You can read a file simply by specifying the file path in the constructor.

The following is an example of actually loading an Ogg Vorbis file.

```cs
var source = new VorbisAudioSource("./assets/bgm/battle.ogg");
```

You can do only this.

----

Wave files are good for sound effects because they do not require decoding and can be played quickly. However, it loads all data into memory, so it is not suitable for long music.

Ogg Vorbis files take a while to decode, so they are inefficient for short sounds such as sound effects. However, it is suitable for long music because it can be played while loading data into memory little by little.

Next: [Play Files](play.md)
