using DotFeather;

/// <summary>
/// By implementing this at the same time as the <see cref="IDrawable"/> interface, you can receive frame update notifications.
/// </summary>
public interface IUpdatable
{
	/// <summary>
	/// Called when the frame has been updated.
	/// </summary>
	void OnUpdate(GameBase game);
}
