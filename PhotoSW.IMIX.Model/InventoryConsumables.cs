using System;
using System.Xml.Serialization;

namespace PhotoSW.IMIX.Model
{
	public class InventoryConsumables
	{
		[XmlIgnore]
		public long InventoryConsumablesID
		{
			get;
			set;
		}

		public long AccessoryID
		{
			get;
			set;
		}

		public long ConsumeValue
		{
			get;
			set;
		}

		[XmlIgnore]
		public string AccessoryName
		{
			get;
			set;
		}

		public string AccessorySyncCode
		{
			get;
			set;
		}

		public string AccessoryCode
		{
			get;
			set;
		}
	}
}
