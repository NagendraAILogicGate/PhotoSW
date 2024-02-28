using System;

namespace PhotoSW.IMIX.Model
{
	public class DG_PhotoGroupInfo
	{
		public long DG_Group_pkey
		{
			get;
			set;
		}

		public string DG_Group_Name
		{
			get;
			set;
		}

		public int DG_Photo_ID
		{
			get;
			set;
		}

		public string DG_Photo_RFID
		{
			get;
			set;
		}

		public DateTime DG_CreatedDate
		{
			get;
			set;
		}

		public int DG_SubstoreId
		{
			get;
			set;
		}
	}
}
