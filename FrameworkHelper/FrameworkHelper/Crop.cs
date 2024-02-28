using System;
using System.ComponentModel;
using System.Windows.Data;

namespace FrameworkHelper
{
	public class Crop : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public BindingList<CropContraint> Constraints
		{
			get;
			private set;
		}

		public CropContraint Constraint
		{
			get
			{
				return CollectionViewSource.GetDefaultView(this.Constraints).CurrentItem as CropContraint;
			}
		}

		public Crop()
		{
			this.Constraints = new BindingList<CropContraint>
			{
				new CropContraint("4\" x 6\"", new double?(0.66666666666666663)),
				new CropContraint("8.5\" x 11\"", new double?(0.77272727272727271)),
				new CropContraint("Custom", null)
			};
		}

		protected void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
