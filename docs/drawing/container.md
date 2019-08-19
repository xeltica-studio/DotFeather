# Container

Container is a object like folders, which it can contain other objects as children.

Objects which owned by a container will be drawn at relative position from the container. It means that moving container is also moves all children.

By using this specification, for example, you can create articulated characters, layer system etc.

To tell you the truth, you used a container before you read this article. In fact, `Root` property is an instance of a container.

I'll show a example to create a container, have sprites, and display it.

```cs
var container = new Container();

// Generate Sprites
var left = new Sprite(Texture2D.LoadFrom("./left.png"), -16, 0);
var right = new Sprite(Texture2D.LoadFrom("./right.png"), 16, 0);
var top = new Sprite(Texture2D.LoadFrom("./top.png"), 0, -16);
var bottom = new Sprite(Texture2D.LoadFrom("./bottom.png"), 0, 16);

// Add sprites to the container
container.Add(left);
container.Add(right);
container.Add(top);
container.Add(bottom);

Root.Add(container);

// Move the container
container.X = 128;
container.Y = 96;
```

Next: [Mouse Input](../input/mouse.md)
