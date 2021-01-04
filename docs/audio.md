# Audio

DotFeather has the ability to read and play audio from a file or other source.

The audio data that DotFeather can handle is represented as an **audio source**. An audio source is a class that inherits from the `IAudioSource` interface.

By default, DotFeather includes an audio source that can read Microsoft WAV and Ogg Vorbis formats, and a [DelegateAudioSource](audio/delegate.md) that can programmatically generate waveforms using callback functions. You can also [Create your own audio source](plugin/audiosource.md) to support any audio file.


The audio source can be played by using the `AudioPlayer` class.

