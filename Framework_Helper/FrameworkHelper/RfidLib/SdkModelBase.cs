namespace FrameworkHelper.RfidLib
{
    using Baracoda.Cameleon.PC.Common;
    using Baracoda.Cameleon.PC.Modularity.Models;
    using ErrorHandler;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading;

    public class SdkModelBase : DataModel
    {
        private bool isBtAvailable = true;
        private bool isBusy = true;
        private readonly object locker = new object();
        private Queue<BtReaderCached> queue;
        private List<BaracodaReaderBase> readers;
        protected readonly Lazy<string> ReadersPathLazy = new Lazy<string>(() => ProgramFile(Build.SubFolder("Configuration").Path("readers.data")));

        public event EventHandler CloseRequested;

        [CompilerGenerated]
        private static string <.ctor>b__1()
        {
            return ProgramFile(Build.SubFolder("Configuration").Path("readers.data"));
        }

        public void CloseForced()
        {
            EventHandler closeRequested = this.CloseRequested;
            if (closeRequested != null)
            {
                closeRequested(this, EventArgs.Empty);
            }
        }

        protected void OnException(Exception x)
        {
            ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(x));
        }

        private static string ProgramFile(PathContainer p)
        {
            string item = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), Assembly.GetEntryAssembly().FullName);
            p.Parts.Insert(0, item);
            return p.Finalize();
        }

        protected static IEnumerable<string> SplitNum(string text)
        {
            return SplitNum(text, 80);
        }

        protected static IEnumerable<string> SplitNum(string text, int number)
        {
            List<string> list = new List<string>();
            int num = 0;
            while (num < text.Length)
            {
                StringBuilder builder = new StringBuilder();
                int num2 = 0;
                while ((num2 < number) && (num < text.Length))
                {
                    builder.Append(text[num]);
                    num2++;
                    num++;
                }
                list.Add(builder.ToString());
            }
            return list;
        }

        public bool IsBtAvailable
        {
            get
            {
                return this.isBtAvailable;
            }
            protected set
            {
                if (this.isBtAvailable != value)
                {
                    this.isBtAvailable = value;
                    base.SendPropertyChanged<bool>(Expression.Lambda<Func<bool>>(Expression.Property(Expression.Constant(this, typeof(SdkModelBase)), (MethodInfo) methodof(SdkModelBase.get_IsBtAvailable)), new ParameterExpression[0]));
                }
            }
        }

        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }
            set
            {
                if (this.isBusy != value)
                {
                    this.isBusy = value;
                    base.SendPropertyChanged<bool>(Expression.Lambda<Func<bool>>(Expression.Property(Expression.Constant(this, typeof(SdkModelBase)), (MethodInfo) methodof(SdkModelBase.get_IsBusy)), new ParameterExpression[0]));
                }
            }
        }

        protected Queue<BtReaderCached> Queue
        {
            get
            {
                lock (this.locker)
                {
                    return (this.queue ?? (this.queue = new Queue<BtReaderCached>()));
                }
            }
        }

        public List<BaracodaReaderBase> Readers
        {
            get
            {
                return (this.readers ?? (this.readers = new List<BaracodaReaderBase>()));
            }
        }
    }
}

