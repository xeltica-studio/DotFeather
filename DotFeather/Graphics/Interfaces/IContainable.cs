namespace DotFeather
{
	public interface IContainable : IDrawable
	{
		IContainable? Parent { get; internal set; }
		Vector AbsoluteLocation => Location + (Parent?.AbsoluteLocation ?? Vector.Zero);
	}
}
