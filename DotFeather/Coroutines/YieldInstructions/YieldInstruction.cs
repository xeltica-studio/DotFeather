namespace DotFeather
{
	/// <summary>
	/// コルーチンの待機を制御する、イールド命令を表す抽象クラスです。
	/// </summary>
	public abstract class YieldInstruction
	{
		/// <summary>
		/// 待機中であるかどうかを取得します。
		/// </summary>
		public abstract bool KeepWaiting { get; }
	}
}
