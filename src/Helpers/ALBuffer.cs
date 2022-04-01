namespace DotFeather
{
	/// <summary>
	/// OpenAl のバッファハンドルを <see cref="System.IDisposable"/> でラッピングします。
	/// </summary>
	public class ALBuffer : OpenTKManagedHandleBase<int>
	{
		/// <summary>
		/// ハンドルを生成します。
		/// </summary>

		public override int GenerateHandle() => 0;
		/// <summary>
		/// ハンドルを破棄します。
		/// </summary>
		public override void DisposeHandle()
		{

		}
	}
}
