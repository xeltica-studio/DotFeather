namespace DotFeather
{
	/// <summary>
	/// AL のソースハンドルを <see cref="System.IDisposable"/> でラッピングします。
	/// </summary>
	public class ALSource : OpenTKManagedHandleBase<int>
	{
		/// <summary>
		/// ハンドルを生成します。
		/// </summary>
		public override int GenerateHandle() => 0;

		/// <summary>
		/// ハンドルを削除します。
		/// </summary>
		public override void DisposeHandle()
		{

		}
	}
}
