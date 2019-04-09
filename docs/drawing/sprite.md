# Sprite

Sprite is a object to render textures at a free position on the screen. It can be used for characters, bullets etc.

## Textures

Textures mean images loaded by DotFeather.

Textures are expressed as `Texture2D` structure, and you can load textures by calling a static method of `Texture2D` structure.

```cs
Texture2D texture = Texture2D.LoadFrom("./assets/title.png");
```

### Load and Split textures

DotFeather has a function to load and split textures so that you can load sprite sheet, in which a image for animation is arranged in a grid shape in one image.

```cs
Texture2D[] textures = Texture2D.LoadAndSplitFrom("./assets/zombie.png", 16, 2, new Size(16, 16));
```

This program reads the file in ./assets/zombie.png and cuts out as 16x16, 16 horizontal and 2 vertical, totally 32 textures.

## Sprites

After loading textures, create a instance of sprite and display it.

```cs
Sprite title = new Sprite(texture, 0, 32);
Sprite zombie = new Sprite(textures[0], 64, 16);
Root.Add(sprite);
```

Next: [Tilemap](tilemap.md)