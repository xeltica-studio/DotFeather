using System;
namespace DotFeather.Helpers
{
    public abstract class OpenTKManagedHandleBase<THandle> : IDisposable
    {
        public THandle Handle { get; }

        public OpenTKManagedHandleBase()
        {
            Handle = GenerateHandle();
        }

        public abstract THandle GenerateHandle();
        public abstract void DisposeHandle();

        #region IDisposable Support
        private bool disposedValue;

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                DisposeHandle();
                disposedValue = true;
            }
        }

        ~OpenTKManagedHandleBase()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
