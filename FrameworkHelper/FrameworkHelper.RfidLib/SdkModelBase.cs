using Baracoda.Cameleon.PC.Common;
using Baracoda.Cameleon.PC.Modularity.Models;
using Baracoda.Cameleon.PC.Readers;
using ErrorHandler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace FrameworkHelper.RfidLib
{
	public class SdkModelBase : DataModel
	{
		protected readonly Lazy<string> ReadersPathLazy = new Lazy<string>(() => SdkModelBase.ProgramFile(Build.SubFolder("Configuration").Path("readers.data")));

		private bool isBusy = true;

		private bool isBtAvailable = true;

		private readonly object locker = new object();

		private Queue<BtReaderCached> queue;

		private System.Collections.Generic.List<BaracodaReaderBase> readers;

		public event System.EventHandler CloseRequested;

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
					base.SendPropertyChanged<bool>(() => this.IsBusy);
				}
			}
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
					base.SendPropertyChanged<bool>(() => this.IsBtAvailable);
				}
			}
		}

		public System.Collections.Generic.List<BaracodaReaderBase> Readers
		{
			get
			{
				System.Collections.Generic.List<BaracodaReaderBase> arg_19_0;
				if ((arg_19_0 = this.readers) == null)
				{
					arg_19_0 = (this.readers = new System.Collections.Generic.List<BaracodaReaderBase>());
				}
				return arg_19_0;
			}
		}

		protected Queue<BtReaderCached> Queue
		{
			get
			{
				Queue<BtReaderCached> result;
				lock (this.locker)
				{
					Queue<BtReaderCached> arg_2B_0;
					if ((arg_2B_0 = this.queue) == null)
					{
						arg_2B_0 = (this.queue = new Queue<BtReaderCached>());
					}
					result = arg_2B_0;
				}
				return result;
			}
		}

		protected void OnException(System.Exception x)
		{
			string message = ErrorHandler.ErrorHandler.CreateErrorMessage(x);
			ErrorHandler.ErrorHandler.LogFileWrite(message);
		}

		protected static System.Collections.Generic.IEnumerable<string> SplitNum(string text)
		{
			return SdkModelBase.SplitNum(text, 80);
		}

		protected static System.Collections.Generic.IEnumerable<string> SplitNum(string text, int number)
		{
			System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
			int i = 0;
			while (i < text.Length)
			{
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
				int num = 0;
				while (num < number && i < text.Length)
				{
					stringBuilder.Append(text[i]);
					num++;
					i++;
				}
				list.Add(stringBuilder.ToString());
			}
			return list;
		}

		private static string ProgramFile(PathContainer p)
		{
			string item = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData), System.Reflection.Assembly.GetEntryAssembly().FullName);
			p.Parts.Insert(0, item);
			return p.Finalize();
		}

		public void CloseForced()
		{
			System.EventHandler closeRequested = this.CloseRequested;
			if (closeRequested != null)
			{
				closeRequested(this, System.EventArgs.Empty);
			}
		}
	}
}
