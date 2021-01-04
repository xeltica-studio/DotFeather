# Components

Using components, you can extend the behavior of [elements](elements/index.md).

The only component built into DotFeather is SpriteAnimator (see [Sprite](elements/sprite.md) for details), but you can also create your own.

## Creating your own components

In order to create a component, inherit from the `Component` class.

Here, as an example, we will create a component that outputs the type name of the attached element to the console:

```cs
public class ExampleComponent : Component
{
	public override void OnStart()
	{
		DF.Console.Print(Element.GetType().Name);
	}
}
```

By overriding the `OnStart` virtual method, you can describe the behavior at the moment the component is activated (=attached).

Other methods include the `OnUpdate` method, which is called every frame, the `OnDestroy` method, which is called the moment the component is destroyed, and the `OnRender` method, which is called during rendering.

The `Element` property of the Component class allows you to retrieve the element to which the component is attached.

You can use these APIs to extend the behavior of elements.

## Attaching a component

To attach a component, call the `AddComponent<T>` method of the element.

```cs
var container = new Container();

container.AddComponent<ExampleComponent>();
```

The `AddComponent<T>` method returns an instance of the generated component.

## Get a component

To get an attached component, call the element's `GetComponent<T>` method.

```cs
var comp = container.GetComponent<ExampleComponent>();
```

## Remove a component

To remove an attached component, call the element's `RemoveComponent<T>` method.

```cs
container.RemoveComponent(comp);
```
