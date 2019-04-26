using OpenTK.Audio.OpenAL;
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

		public override int GenerateHandle() => AL.GenBuffer();
		/// <summary>
		/// ハンドルを破棄します。
		/// </summary>
		public override void DisposeHandle() => AL.DeleteBuffer(Handle);
	}
}
