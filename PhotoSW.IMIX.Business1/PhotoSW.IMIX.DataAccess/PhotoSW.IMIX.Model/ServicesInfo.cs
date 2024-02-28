using System;

namespace PhotoSW.IMIX.Model
{
	public class ServicesInfo
	{
		public int DG_Service_Id
		{
			get;
			set;
		}

		public string DG_Sevice_Name
		{
			get;
			set;
		}

		public string DG_Service_Display_Name
		{
			get;
			set;
		}

		public string DG_Service_Path
		{
			get;
			set;
		}

		public bool? IsInterface
		{
			get;
			set;
		}

		public long RunLevel
		{
			get;
			set;
		}

		public bool IsService
		{
			get;
			set;
		}
	}
}
