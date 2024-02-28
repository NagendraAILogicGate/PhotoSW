namespace DigiPhoto.Common
{
    using DigiPhoto.ImageGallery;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Threading;

    public class AsyncImageLoader
    {
        private Collection<ImageFile> _addImages = new Collection<ImageFile>();
        private BackgroundWorker _backgroundWorker;
        private Collection<ImageFile> _delImages = new Collection<ImageFile>();
        private Dispatcher _dispather;
        private int _imageCount = 0;
        private volatile bool _isCanceled;
        private bool _runDeep = false;
        private Queue<ImageCollection> _tasks;
        private Collection<string> PreviewImages;

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

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ImageCollection images;
            ImageFile[] fileArray;
            delegate_Void_ImageFile file;
            lock (this._tasks)
            {
                if (this._tasks.Count > 0)
                {
                    images = this._tasks.Dequeue();
                }
                else
                {
                    return;
                }
            }
            this._addImages.Clear();
            this._delImages.Clear();
            this.AutoAdd(images, this.PreviewImages);
            if (this._addImages.Count > 0)
            {
                fileArray = new ImageFile[this._addImages.Count];
                this._addImages.CopyTo(fileArray, 0);
                file = new delegate_Void_ImageFile(images.Add);
                this._dispather.Invoke(file, new object[] { fileArray });
            }
            if (this._delImages.Count > 0)
            {
                fileArray = new ImageFile[this._delImages.Count];
                this._delImages.CopyTo(fileArray, 0);
                file = new delegate_Void_ImageFile(images.Remove);
                this._dispather.Invoke(file, new object[] { fileArray });
            }
            e.Result = images;
        }

        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!(this._isCanceled || (e.Error != null)))
            {
                this.ProcessNextItem();
            }
        }

        private void AutoAdd(ImageCollection addTo, Collection<string> ParentImages)
        {
            try
            {
                int num4;
                Collection<string> collection = ParentImages;
                int count = collection.Count;
                int num2 = collection.Count;
                int num3 = this._imageCount;
                if (num3 > 10)
                {
                    num3 = (count * num3) / 100;
                }
                num3 = Math.Max(1, num3);
                num3 = Math.Min(count, num3);
                if (num2 < num3)
                {
                    for (num4 = num2; num4 < num3; num4++)
                    {
                        this._addImages.Add(new ImageFile(collection[num4]));
                    }
                }
                else if (num2 > num3)
                {
                    for (num4 = num3; num4 < num2; num4++)
                    {
                        this._delImages.Add(new ImageFile(collection[num4]));
                    }
                }
            }
            catch
            {
            }
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
                    Thread.Sleep(0x3e8);
                }
            }
        }

        public void RunAsync()
        {
            this.ProcessNextItem();
        }

        public Collection<string> LoadImages
        {
            set
            {
                this.PreviewImages = value;
            }
        }

        public delegate void delegate_Void();

        public delegate void delegate_Void_ImageFile(ImageFile[] imageFile);
    }
}

