# Textures

Texture refers to the image data that can be used in DotFeather.

DotFeather currently has two different texture formats.

## Texture2D

Texture2D is a structure that represents a 2D bitmap texture, a texture format used in many aspects of DotFeather.

It can be loaded by calling the static method of the `Texture2D` structure as shown below.

```cs
Texture2D texture = Texture2D.LoadFrom("./assets/title.png");
```

### Split Texture Import

DotFeather has the ability to import textures in separate sections so that you can easily import sprite sheets, which are images that contain a grid of pictures for animation.

```cs
Texture2D[] textures = Texture2D.LoadAndSplitFrom("./assets/zombie.png", 16, 2, new Size(16, 16));
```

This program reads the file in ./assets/zombie.png and cuts out 32 16x16 textures, 16 horizontal and 2 vertical, for a total of 32.

## Texture9Sliced

Texture9Sliced is a structure that represents a two-dimensional bitmap texture that is divided into nine segments.
It is currently intended to be used with the NineSliceSprite element.

See [NineSliceSprite](elements/9slice.md) for details.
