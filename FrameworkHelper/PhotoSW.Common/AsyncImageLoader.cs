using PhotoSW.ImageGallery;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows.Threading;
using PhotoSW.ImageGallery;

namespace PhotoSW.Common
{
	public class AsyncImageLoader
	{
		public delegate void delegate_Void();

		public delegate void delegate_Void_ImageFile(ImageFile[] imageFile);

		private volatile bool _isCanceled;

		private BackgroundWorker _backgroundWorker;

		private Queue<ImageCollection> _tasks;

		private int _imageCount = 0;

		private bool _runDeep = false;

		private Dispatcher _dispather;

		private System.Collections.ObjectModel.Collection<ImageFile> _addImages = new System.Collections.ObjectModel.Collection<ImageFile>();

		private System.Collections.ObjectModel.Collection<ImageFile> _delImages = new System.Collections.ObjectModel.Collection<ImageFile>();

		private System.Collections.ObjectModel.Collection<string> PreviewImages;

		public System.Collections.ObjectModel.Collection<string> LoadImages
		{
			set
			{
				this.PreviewImages = value;
			}
		}

		public AsyncImageLoader(Queue<ImageCollection> tasks, int imageCount, bool runDeep, Dispatcher dispather)
		{
			this._tasks = tasks;
			this._imageCount = imageCount;
			this._runDeep = runDeep;
			this._dispather = dispather;
			this._isCanceled = false;
			this._backgroundWorker = new BackgroundWorker();
			this._backgroundWorker.DoWork += new DoWorkEventHandler(this._backgroundWorker_DoWork);
			this._backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this._backgroundWorker_RunWorkerCompleted);
		}

		public void CancelAsync()
		{
			this._isCanceled = true;
		}

		public void ClearQ()
		{
			lock (this._tasks)
			{
				this._tasks.Clear();
			}
		}

		public void RunAsync()
		{
			this.ProcessNextItem();
		}

		private void ProcessNextItem()
		{
			lock (this._tasks)
			{
				if (this._tasks.Count > 0)
				{
					this._backgroundWorker.RunWorkerAsync();
				}
				else
				{
					System.Threading.Thread.Sleep(1000);
				}
			}
		}

		private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			ImageCollection imageCollection;
			lock (this._tasks)
			{
				if (this._tasks.Count <= 0)
				{
					return;
				}
				imageCollection = this._tasks.Dequeue();
			}
			this._addImages.Clear();
			this._delImages.Clear();
			this.AutoAdd(imageCollection, this.PreviewImages);
			if (this._addImages.Count > 0)
			{
				ImageFile[] array = new ImageFile[this._addImages.Count];
				this._addImages.CopyTo(array, 0);
				AsyncImageLoader.delegate_Void_ImageFile method = new AsyncImageLoader.delegate_Void_ImageFile(imageCollection.Add);
				this._dispather.Invoke(method, new object[]
				{
					array
				});
			}
			if (this._delImages.Count > 0)
			{
				ImageFile[] array = new ImageFile[this._delImages.Count];
				this._delImages.CopyTo(array, 0);
				AsyncImageLoader.delegate_Void_ImageFile method = new AsyncImageLoader.delegate_Void_ImageFile(imageCollection.Remove);
				this._dispather.Invoke(method, new object[]
				{
					array
				});
			}
			e.Result = imageCollection;
		}

		private void AutoAdd(ImageCollection addTo, System.Collections.ObjectModel.Collection<string> ParentImages)
		{
			try
			{
				int count = ParentImages.Count;
				int count2 = ParentImages.Count;
				int num = this._imageCount;
				if (num > 10)
				{
					num = count * num / 100;
				}
				num = System.Math.Max(1, num);
				num = System.Math.Min(count, num);
				if (count2 < num)
				{
					for (int i = count2; i < num; i++)
					{
						this._addImages.Add(new ImageFile(ParentImages[i]));
					}
				}
				else if (count2 > num)
				{
					for (int i = num; i < count2; i++)
					{
						this._delImages.Add(new ImageFile(ParentImages[i]));
					}
				}
			}
			catch
			{
			}
		}

		private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (!this._isCanceled && e.Error == null)
			{
				this.ProcessNextItem();
			}
		}
	}
}
