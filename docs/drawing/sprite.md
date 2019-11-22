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

In addition, you can directly generate sprites by specifying path:

```cs
Sprite sprite = Sprite.LoadFrom("./assets/skeleton.png");
```

## Animating Sprite

`AnimatingSprite` class loads splitted textures array, and perform texture-animation.



Let's actually use `AnimatingSprite` as following example:

```cs
var zombieWalking = new AnimatingSprite(textures, -1, 4);
Root.Add(zombieWalking);

// Don't forget
zombieWalking.StartAnimating();
```

In the constructor of the `AnimatingSprite` class, you can specify the texture array as the first argument, the loop count as the second argument, and the time as the third argument.

If the number of loops is 1 or more, it loops that number of times. If 0, do not loop. And if it is -1, it loops infinitely.

Time is the frame time until switching to the next texture. For example, if it is 5, a single texture will be displayed in 5 frames.

Since `AnimatingSprite` does not animate automatically after initialization, be sure to call the` StartWalking` method.

Next: [Tilemap](tilemap.md)
