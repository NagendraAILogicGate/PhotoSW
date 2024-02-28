namespace DigiPhoto.ImageGallery
{
    using System;
    using System.Collections.ObjectModel;

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

