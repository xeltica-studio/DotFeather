using System;
namespace DotFeather
{
    public abstract class OpenTKManagedHandleBase<T> : IDisposable
    {
        public T Handle { get; }

        public abstract T GenerateHandle();
        public abstract void DisposeHandle();

        protected OpenTKManagedHandleBase()
		{
            Handle = GenerateHandle();
		}

		private OpenTKManagedHandleBase(T handle)
		{
			Handle = handle;
		}

        public void Dispose()
        {
            if (!disposedValue)
            {
                DisposeHandle();
                disposedValue = true;
            }
        }

		public static implicit operator T(OpenTKManagedHandleBase<T> handle) => handle.Handle;

        public static implicit operator OpenTKManagedHandleBase<T>(T handle) => handle;

        private bool disposedValue;
    }
}
