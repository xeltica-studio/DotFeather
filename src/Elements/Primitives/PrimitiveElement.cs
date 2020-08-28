using System;

namespace DotFeather
{
	public abstract class PrimitiveElement : Element
	{
		[Obsolete("Use `Key`.")]
		public string Name
		{
			get => Key;
			set => Key = value;
		}

		protected PrimitiveElement() { }

		protected PrimitiveElement(string key) : base(key) { }

		protected PrimitiveElement(string key, params Element[] children) : base(key, children) { }
	}

	public abstract class PrimitiveElement<T> : PrimitiveElement where T : Component
	{
		public T Component => component;

		protected PrimitiveElement() { }

		protected PrimitiveElement(string key) : base(key) { }

		protected PrimitiveElement(string key, params Element[] children) : base(key, children) { }

		public override void AddComponent(Component component)
		{
			if (component is T newer && component.GetComponent<T>() is T elder)
			{
				base.RemoveComponent(elder);
				this.component = newer;
			}
			base.AddComponent(component);
		}

		public override void RemoveComponent(Component com)
		{
			if (component is T && !IsDestroyed) throw new ArgumentException("");
			base.RemoveComponent(component);
		}

		protected T component = null!;
	}
}
