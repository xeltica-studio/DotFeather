# Sprite

Sprite allows you to draw a texture at any position on the screen. This can be used to display game characters, bullets, etc.

## Sprite

Once a texture has been loaded, a Sprite instance is created and displayed.

```cs
Sprite title = new Sprite(texture) { Location = (0, 32) };
Sprite zombie = new Sprite(textures[0]) { Location = (64, 16) };
DF.Root.Add(sprite);
```

You can also generate a sprite directly by specifying a file name.

```cs
Sprite sprite = new Sprite("./assets/skeleton.png");
```

## Animating Sprites

If you want to animate a sprite, use the `SpriteAnimator` component. For more information about the component, see [Component](./component.md).

If you attach the `SpriteAnimator` component to a sprite, you can read a texture array that has been split-loaded and automatically animate the texture.

Let's try to use it in practice.

```cs
var zombie = new Sprite();
DF.Root.Add(zombie);
var walker = zombie.AddComponent<SpriteAnimator>();
// Array of textures
walker.Textures = textures;
// Loop count. -1 means infinite looping, 0 means no looping
walker.LoopTimes = -1;
// Number of frames per image. The lower the number, the faster the animation
walker.Duration = 4;
```
