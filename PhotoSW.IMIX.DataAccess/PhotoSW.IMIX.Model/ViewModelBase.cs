using System;
using System.ComponentModel;

namespace PhotoSW.IMIX.Model
{
	public class ViewModelBase : INotifyPropertyChanged, INotifyPropertyChanging
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public event PropertyChangingEventHandler PropertyChanging;

		protected void NotifyPropertyChanged(string info)
		{
			info = info.Replace("get_", "").Replace("set_", "");
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}

		protected void NotifyPropertyChanging(string info)
		{
			info = info.Replace("get_", "").Replace("set_", "");
			if (this.PropertyChanging != null)
			{
				this.PropertyChanging(this, new PropertyChangingEventArgs(info));
			}
		}
	}
}
