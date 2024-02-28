using System;
using System.Xml.Serialization;

namespace PhotoSW.IMIX.Model
{
	public class SubStoresInfo
	{
		[XmlElement("SiteID")]
		public int DG_SubStore_pkey
		{
			get;
			set;
		}

		[XmlElement("SiteName")]
		public string DG_SubStore_Name
		{
			get;
			set;
		}

		[XmlIgnore]
		public string DG_SubStore_Description
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool DG_SubStore_IsActive
		{
			get;
			set;
		}

		public string SyncCode
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool IsSynced
		{
			get;
			set;
		}

		[XmlIgnore]
		public string DG_SubStore_Locations
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool IsLogicalSubStore
		{
			get;
			set;
		}

		[XmlIgnore]
		public int? LogicalSubStoreID
		{
			get;
			set;
		}

		[XmlElement("SiteCode")]
		public string DG_SubStore_Code
		{
			get;
			set;
		}

		[XmlIgnore]
		public int SiteID
		{
			get;
			set;
		}
	}
}
