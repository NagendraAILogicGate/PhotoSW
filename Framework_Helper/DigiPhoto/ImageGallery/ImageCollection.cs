namespace DigiPhoto.ImageGallery
{
    using DigiPhoto.Common;
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Media;

    public class ImageCollection
    {
        private ObservableCollection2D<string, string, ImageFile> _collection;
        private string _collectionPath;
        private ObservableCollection<ImageFile> _flattenCollection;
        private Random r;

        public ImageCollection()
        {
            this._collectionPath = "";
            this.r = new Random();
        }

        public ImageCollection(string folderPath, ObservableCollection<ImageFile> linkedCollection)
        {
            this._collectionPath = "";
            this.r = new Random();
            this._collectionPath = folderPath;
            this._flattenCollection = linkedCollection;
            this._collection = new ObservableCollection2D<string, string, ImageFile>(this._flattenCollection);
        }

        public void Add(ImageFile imageFile)
        {
            if (this._collection.HasKey(imageFile.ParentPath))
            {
                foreach (ImageFile file in this._collection.Get(imageFile.ParentPath).Values)
                {
                    imageFile.ColorCode = file.ColorCode;
                    break;
                }
            }
            else
            {
                imageFile.ColorCode = new SolidColorBrush(Color.FromArgb(150, (byte) this.r.Next(0xff), (byte) this.r.Next(0xff), (byte) this.r.Next(0xff)));
            }
            this._collection.Set(imageFile.ParentPath, imageFile.FilePath, imageFile);
        }

        public void Add(ImageFile[] imageFile)
        {
            foreach (ImageFile file in imageFile)
            {
                this.Add(file);
            }
        }

        public bool Contains(ImageFile imageFile)
        {
            return this._collection.HasKey(imageFile.ParentPath, imageFile.FilePath);
        }

        public int CountInDir(string path)
        {
            return this._collection.CountIn(path);
        }

        public void Remove(ImageFile imageFile)
        {
            this._collection.Remove(imageFile.ParentPath, imageFile.FilePath);
        }

        public void Remove(ImageFile[] imageFile)
        {
            foreach (ImageFile file in imageFile)
            {
                this.Remove(file);
            }
        }

        public string CollectionPath
        {
            get
            {
                return this._collectionPath;
            }
        }

        public ObservableCollection<ImageFile> FlattenCollection
        {
            get
            {
                return this._flattenCollection;
            }
        }
    }
}

