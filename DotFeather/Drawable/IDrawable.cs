namespace DotFeather.Drawable
{
	/// <summary>
	/// 描画処理を行うクラスはすべてこのインターフェイスを実装します。
	/// </summary>
	public interface IDrawable
	{
		/// <summary>
		/// 画面への描画を開始します。
		/// </summary>
		/// <param name="game">Game.</param>
		void Draw(GameBase game);
	}

}
