namespace DotFeather
{
	public abstract class Component
	{
		// ランタイムで必ず初期化するので null を初期値に（正攻法でnonnullにしたいけど方法がない）
		public ElementBase Element { get; internal set; } = null!;

		public virtual bool IsEnabled { get; set; } = true;

		public bool IsDestroyed => Element == null;

		public virtual void OnStart() { }
		public virtual void OnUpdate() { }
		public virtual void OnDestroy() { }

		public virtual void OnRender() { }
	}
}
