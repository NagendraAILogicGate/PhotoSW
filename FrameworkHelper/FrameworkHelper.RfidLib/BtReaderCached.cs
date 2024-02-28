using Baracoda.Cameleon.PC.Modularity.Models;
using System;

namespace FrameworkHelper.RfidLib
{
	public class BtReaderCached : DataModel
	{
		private string id;

		private string name;

		public string Id
		{
			get
			{
				return this.id;
			}
			set
			{
				if (!string.Equals(this.id, value))
				{
					this.id = value;
					base.SendPropertyChanged<string>(() => this.Id);
				}
			}
		}

		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				if (!string.Equals(this.name, value))
				{
					this.name = value;
					base.SendPropertyChanged<string>(() => this.Name);
				}
			}
		}
	}
}
