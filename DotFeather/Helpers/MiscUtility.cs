namespace DotFeather
{
	/// <summary>
	/// その他の便利な静的メソッドを提供します。
	/// </summary>
	public static class MiscUtility
	{
		/// <summary>
		/// 2つの変数をスワップします。
		/// </summary>
		/// <param name="var1">変数 1。</param>
		/// <param name="var2">変数 2。</param>
		/// <typeparam name="T">変数の型。</typeparam>
		public static void Swap<T>(ref T var1, ref T var2) => (var1, var2) = (var2, var1);
	}
}
