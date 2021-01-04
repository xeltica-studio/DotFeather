# Original Audio Source

**Note: This article is for Advanced Programmers.**

You can play audio of any format by creating a class that implements the `IAudioSource` interface.

Here is the definition of the latest version of `IAudioSource`:

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

The `EnumerateSamples` method is an iterator that returns samples of audio data in the form of a tuple. Even if it is mono or 8 bit PCM, you have to convert it to 16 bit stereo.

The `Samples` property is the number of samples in the audio source. Returns null if the number of samples is unknown, such as live streaming.

The `Channels` property is the number of channels in the audio source.

The `Bits` property is the number of quantization bits in the audio source.

The `SampleRate` property is the sampling frequency of the audio source.


After creating that, you can play the audio source by using the `AudioPlayer` class.

Next: [IUpdatable](updatable.md)
