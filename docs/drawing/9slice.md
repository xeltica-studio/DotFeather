# 9-slice Sprites

9-slice Sprite is a sprite which can be resized smoothly by splitting a texture into 9 sheets.

It's available on other game-engines. See [Unity's description](https://docs.unity3d.com/2018.3/Documentation/Manual/9SliceSprites.html)

```cs
// Generate a sprite with file path and pixels from left, up, right and down.
var sprite = NineSliceSprite.LoadFrom("./path/to/sprite.png", 16, 16, 16, 16);

Root.Add(sprite);

// When the size is changed, the image will resized smoothly
sprite.Width = 256;
sprite.Height = 300;
```

Next: [Mouse Input](../input/mouse.md)
