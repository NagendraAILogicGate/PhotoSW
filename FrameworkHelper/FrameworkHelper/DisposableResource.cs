using System;
using System.IO;

namespace FrameworkHelper
{
	public class DisposableResource : System.IDisposable
	{
		private System.IO.Stream _resource;

		private bool _disposed;

		public DisposableResource(System.IO.Stream stream)
		{
			if (stream == null)
			{
				throw new System.ArgumentNullException("Stream in null.");
			}
			if (!stream.CanRead)
			{
				throw new System.ArgumentException("Stream must be readable.");
			}
			this._resource = stream;
			this._disposed = false;
		}

		public void DoSomethingWithResource()
		{
			if (this._disposed)
			{
				throw new System.ObjectDisposedException("Resource was disposed.");
			}
		}

		public void Dispose()
		{
			this.Dispose(true);
			System.GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!this._disposed)
			{
				if (disposing)
				{
					if (this._resource != null)
					{
						this._resource.Dispose();
					}
				}
				this._resource = null;
				this._disposed = true;
			}
		}
	}
}
