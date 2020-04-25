# Audio

DotFeather has a feature to load sounds from sources such as files, and play them.

Audio data which DotFeather can handle is called **Audio Source**.

Audio Source is a class implemented `IAudioSource`.

DotFeather has some built-in AudioSources supports Microsoft WAV and Ogg Vorbis format, and [DelegateAudioSource](audio/delegate.md) to create waveform programmably with callback function. You can also [create original AudioSource](plugin/audiosource.md) to support any files.

`AudioPlayer` class can play Audio Sources.

Next: [Load Files](audio/load.md)
