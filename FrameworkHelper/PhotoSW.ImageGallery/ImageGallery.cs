using System;
using System.Collections.ObjectModel;

namespace PhotoSW.ImageGallery
{
	public class ImageGallery
	{
		private ObservableCollection<ImageCollection> _collections = new ObservableCollection<ImageCollection>();

		public ObservableCollection<ImageCollection> Collections
		{
			get
			{
				return this._collections;
			}
		}
	}
}
