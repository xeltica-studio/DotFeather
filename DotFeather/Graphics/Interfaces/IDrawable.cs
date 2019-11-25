namespace DotFeather
{
	/// <summary>
	/// All classes that drawing something implement this interface.
	/// </summary>
	public interface IDrawable
	{
		/// <summary>
		/// Start drawing on the screen.
		/// </summary>
		/// <param name="game">Game.</param>
		/// <param name="location"></param>
		void Draw(GameBase game, Vector location);

		/// <summary>
		/// Get or set z order of this <see cref="IDrawable"/>. The higher the value, the object will be drawn in the foreground.
		/// </summary>
		int ZOrder { get; set; }

		/// <summary>
		/// Get or set name of this <see cref="IDrawable"/>.
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// Get or set location of this <see cref="IDrawable"/>.
		/// </summary>
		Vector Location { get; set; }

		/// <summary>
		/// Get or set angle of this <see cref="IDrawable"/>.
		/// </summary>
		float Angle { get; set; }

		/// <summary>
		/// Get or set scaling amount of this <see cref="IDrawable"/>.
		/// </summary>
		Vector Scale { get; set; }

		/// <summary>
		/// Destroy this <see cref="IDrawable"/>.
		/// </summary>
		void Destroy();
	}
}
