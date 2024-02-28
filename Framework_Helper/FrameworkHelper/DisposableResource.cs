namespace FrameworkHelper
{
    using System;
    using System.IO;

    public class DisposableResource : IDisposable
    {
        private bool _disposed;
        private Stream _resource;

        public DisposableResource(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("Stream in null.");
            }
            if (!stream.CanRead)
            {
                throw new ArgumentException("Stream must be readable.");
            }
            this._resource = stream;
            this._disposed = false;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing && (this._resource != null))
                {
                    this._resource.Dispose();
                }
                this._resource = null;
                this._disposed = true;
            }
        }

        public void DoSomethingWithResource()
        {
            if (this._disposed)
            {
                throw new ObjectDisposedException("Resource was disposed.");
            }
        }
    }
}

