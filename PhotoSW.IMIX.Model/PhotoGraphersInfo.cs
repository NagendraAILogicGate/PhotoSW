using System;

namespace PhotoSW.IMIX.Model
{
	public class PhotoGraphersInfo
	{
		public int DG_User_pkey
		{
			get;
			set;
		}

		public string DG_User_Role
		{
			get;
			set;
		}

		public string DG_User_Name
		{
			get;
			set;
		}

		public string DG_User_First_Name
		{
			get;
			set;
		}

		public string DG_User_Last_Name
		{
			get;
			set;
		}

		public string DG_User_Password
		{
			get;
			set;
		}

		public int DG_User_Roles_Id
		{
			get;
			set;
		}

		public bool? DG_User_Status
		{
			get;
			set;
		}

		public string DG_User_PhoneNo
		{
			get;
			set;
		}

		public string DG_User_Email
		{
			get;
			set;
		}

		public int DG_Location_pkey
		{
			get;
			set;
		}

		public string DG_Location_Name
		{
			get;
			set;
		}

		public int DG_Store_ID
		{
			get;
			set;
		}

		public string DG_Store_Name
		{
			get;
			set;
		}

		public string CountryCode
		{
			get;
			set;
		}

		public string StoreCode
		{
			get;
			set;
		}

		public string UserName
		{
			get;
			set;
		}

		public string StatusName
		{
			get;
			set;
		}

		public string FullName
		{
			get
			{
				return this.DG_User_First_Name + " " + this.DG_User_Last_Name;
			}
		}

		public string Photograper
		{
			get;
			set;
		}

		public int DG_Substore_ID
		{
			get;
			set;
		}
	}
}
