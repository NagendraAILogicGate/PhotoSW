using System;

namespace PhotoSW.IMIX.Model
{
	public class vw_GetActivityReports
	{
		public int DG_Acitivity_Action_Pkey
		{
			get;
			set;
		}

		public int DG_Acitivity_ActionType
		{
			get;
			set;
		}

		public DateTime DG_Acitivity_Date
		{
			get;
			set;
		}

		public int DG_Acitivity_By
		{
			get;
			set;
		}

		public string DG_Acitivity_Descrption
		{
			get;
			set;
		}

		public int DG_Reference_ID
		{
			get;
			set;
		}

		public int DG_User_pkey
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

		public int DG_Actions_pkey
		{
			get;
			set;
		}

		public string DG_Actions_Name
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public DateTime ActivityDate
		{
			get;
			set;
		}

		public string SyncCode
		{
			get;
			set;
		}

		public bool IsSynced
		{
			get;
			set;
		}
	}
}