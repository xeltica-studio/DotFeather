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

		/// <summary>
		/// この描画可能オブジェクトの描画優先順位を指定します。数値が低いほど奥に描画されます。
		/// </summary>
		int ZOrder { get; set; }

		string Name { get; set; }
	}

}
