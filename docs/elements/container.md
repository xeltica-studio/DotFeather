# Container

Containers can be used to group other elements as child elements.

The children of a container are drawn relative to the coordinates of the container. This means that when you move a container, all the elements it contains will move at the same time.

This mechanism can be used to create articulated objects, or to create a layer-like structure.

Also, the `DF.Root` property is a Container.

The following is an example of creating a container and displaying it with a sprite:

```cs
var container = new Container();

// Generate sprites
var left = new Sprite("./left.png") { Location = (-16, 0) };
var right = new Sprite("./right.png") { Location = (16, 0) };
var top = new Sprite("./top.png") { Location = (0, -16) };
var bottom = new Sprite("./bottom.png") { Location = (0, 16) };

// Add them to the container
container.Add(left);
container.Add(right);
container.Add(top);
container.Add(bottom);

DF.Root.Add(container);

// Move it
container.X = 128;
container.Y = 96;
```

It is also possible to set the clipping of child elements that extend beyond the container area. Just write the following:

```cs
container.IsTrimmable = true;

// Don't forget to specify the width and height
container.Width = 128;
container.Height = 128;
```

This will cause any elements that extend beyond the container's area to be clipped.
