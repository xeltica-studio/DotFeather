using System;
namespace DotFeather
{
	/// <summary>
	/// OpenTK のハンドルをラップするための抽象クラスです。
	/// </summary>
	public abstract class OpenTKManagedHandleBase<T> : IDisposable
	{
		/// <summary>
		/// ネイティブ ハンドルを取得します。
		/// </summary>
		/// <value></value>
		public T Handle { get; }

		/// <summary>
		/// コンストラクターから呼び出されます。ここでハンドルを取得します。
		/// </summary>
		public abstract T GenerateHandle();
		/// <summary>
		/// <see cref="Dispose"/> メソッドから呼ばれます。ここでハンドルを破棄します。
		/// </summary>
		public abstract void DisposeHandle();

		/// <summary>
		/// <see cref="OpenTKManagedHandleBase{T}"/> クラスの新しいインスタンスを初期化します。
		/// </summary>
		protected OpenTKManagedHandleBase()
		{
			Handle = GenerateHandle();
		}

		/// <summary>
		/// <see cref="OpenTKManagedHandleBase{T}"/> クラスの新しいインスタンスを初期化します。
		/// </summary>
		private OpenTKManagedHandleBase(T handle)
		{
			Handle = handle;
		}

		/// <summary>
		/// この <see cref="OpenTKManagedHandleBase{T}"/> を破棄します。
		/// </summary>
		public void Dispose()
		{
			if (!disposedValue)
			{
				DisposeHandle();
				disposedValue = true;
			}
		}

		/// <summary>
		/// ハンドルを整数に暗黙変換します。
		/// </summary>
		public static implicit operator T(OpenTKManagedHandleBase<T> handle) => handle.Handle;

		/// <summary>
		/// 整数をハンドルに暗黙変換します。
		/// </summary>
		public static implicit operator OpenTKManagedHandleBase<T>(T handle) => handle;

		private bool disposedValue;
	}
}
