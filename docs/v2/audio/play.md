# Play Files

Actually play the loaded audio source.

You can play Audio sources on the device using the `AudioPlayer` class.

Here is an example:

```cs
// Load Audio Sources
var bgm = new VorbisAudioSource("./assets/bgm/battle.ogg");
var sfx1 = new VorbisAudioSource("./assets/sfx/attack.wav");
var sfx2 = new VorbisAudioSource("./assets/sfx/hurt.wav");

// Instantiates
var player = new AudioPlayer();

// Playing BGM
player.Play(bgm);

// Playing SFX
player.PlayOneShot(sfx1);

// Playing SFX
player.PlayOneShot(sfx2);

// Fade out for 5s and stop
player.Stop(5);

// Stop soon
player.Stop();
```

Next: [Coroutine](../coroutine.md)
