using DotFeather;

/// <summary>
/// これを <see cref="IDrawable"/> インターフェイスと同時に実装することで、フレーム更新通知を受け取ることができます。
/// </summary>
public interface IUpdatable
{
	/// <summary>
	/// フレームが更新されたときに呼ばれます。
	/// </summary>
	void OnUpdate(GameBase game);
}
