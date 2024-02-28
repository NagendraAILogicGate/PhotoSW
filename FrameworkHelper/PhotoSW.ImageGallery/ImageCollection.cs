using PhotoSW.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace PhotoSW.ImageGallery
{
	public class ImageCollection
	{
		private string _collectionPath = "";

		private ObservableCollection<ImageFile> _flattenCollection;

		private ObservableCollection2D<string, string, ImageFile> _collection;

		private System.Random r = new System.Random();

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

		public ImageCollection()
		{
		}

		public ImageCollection(string folderPath, ObservableCollection<ImageFile> linkedCollection)
		{
			this._collectionPath = folderPath;
			this._flattenCollection = linkedCollection;
			this._collection = new ObservableCollection2D<string, string, ImageFile>(this._flattenCollection);
		}

		public void Add(ImageFile imageFile)
		{
			if (this._collection.HasKey(imageFile.ParentPath))
			{
				using (System.Collections.Generic.Dictionary<string, ImageFile>.ValueCollection.Enumerator enumerator = this._collection.Get(imageFile.ParentPath).Values.GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						ImageFile current = enumerator.Current;
						imageFile.ColorCode = current.ColorCode;
					}
				}
			}
			else
			{
				imageFile.ColorCode = new SolidColorBrush(Color.FromArgb(150, (byte)this.r.Next(255), (byte)this.r.Next(255), (byte)this.r.Next(255)));
			}
			this._collection.Set(imageFile.ParentPath, imageFile.FilePath, imageFile);
		}

		public void Add(ImageFile[] imageFile)
		{
			for (int i = 0; i < imageFile.Length; i++)
			{
				ImageFile imageFile2 = imageFile[i];
				this.Add(imageFile2);
			}
		}

		public void Remove(ImageFile imageFile)
		{
			this._collection.Remove(imageFile.ParentPath, imageFile.FilePath);
		}

		public void Remove(ImageFile[] imageFile)
		{
			for (int i = 0; i < imageFile.Length; i++)
			{
				ImageFile imageFile2 = imageFile[i];
				this.Remove(imageFile2);
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
	}
}
