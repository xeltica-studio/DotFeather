using System;
namespace DotFeather.Helpers
{
    public abstract class OpenTKManagedHandleBase<THandle> : IDisposable
    {
        public THandle Handle { get; }

        public abstract THandle GenerateHandle();
        public abstract void DisposeHandle();

        protected OpenTKManagedHandleBase()
        {
            Handle = GenerateHandle();
        }

        public void Dispose()
        {
            if (!disposedValue)
            {
                DisposeHandle();
                disposedValue = true;
            }
        }

        private bool disposedValue;
    }
}
