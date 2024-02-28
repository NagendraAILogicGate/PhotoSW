namespace DigiPhoto.Common
{
    using System;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Data;

    public class InstantiatePropertyAsyncConverter : IValueConverter
    {
        private System.Threading.Tasks.TaskScheduler _taskScheduler;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Task.Factory.StartNew(delegate (object context) {
                IInstantiateProperty property = value as IInstantiateProperty;
                if (property != null)
                {
                    property.InstantiateProperty((parameter as string) ?? this.PropertyName, culture, (SynchronizationContext) context);
                }
            }, SynchronizationContext.Current, CancellationToken.None, TaskCreationOptions.None, this.TaskScheduler);
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public int MaxConcurrentLevel { get; set; }

        public string PropertyName { get; set; }

        public System.Threading.Tasks.TaskScheduler TaskScheduler
        {
            get
            {
                return LazyInitializer.EnsureInitialized<System.Threading.Tasks.TaskScheduler>(ref this._taskScheduler, () => new QueuedTaskScheduler(System.Threading.Tasks.TaskScheduler.Default, this.MaxConcurrentLevel));
            }
        }

        public bool UseQueue { get; set; }
    }
}

