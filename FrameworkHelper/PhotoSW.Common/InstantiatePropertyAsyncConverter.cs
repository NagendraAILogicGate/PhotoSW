using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PhotoSW.Common
{
	public class InstantiatePropertyAsyncConverter : IValueConverter
	{
		private TaskScheduler _taskScheduler;

		public string PropertyName
		{
			get;
			set;
		}

		public int MaxConcurrentLevel
		{
			get;
			set;
		}

		public bool UseQueue
		{
			get;
			set;
		}

		public TaskScheduler TaskScheduler
		{
			get
			{
				return LazyInitializer.EnsureInitialized<TaskScheduler>(ref this._taskScheduler, () => new QueuedTaskScheduler(TaskScheduler.Default, this.MaxConcurrentLevel));
			}
		}

		public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			Task.Factory.StartNew(delegate(object context)
			{
				IInstantiateProperty instantiateProperty = value as IInstantiateProperty;
				if (instantiateProperty != null)
				{
					instantiateProperty.InstantiateProperty((parameter as string) ?? this.PropertyName, culture, (System.Threading.SynchronizationContext)context);
				}
			}, System.Threading.SynchronizationContext.Current, CancellationToken.None, TaskCreationOptions.None, this.TaskScheduler);
			return null;
		}

		public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new System.NotImplementedException();
		}
	}
}
