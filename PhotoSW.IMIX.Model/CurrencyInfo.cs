using System;

namespace PhotoSW.IMIX.Model
{
	public class CurrencyInfo
	{
		public int DG_Currency_pkey
		{
			get;
			set;
		}

		public string DG_Currency_Name
		{
			get;
			set;
		}

		public float DG_Currency_Rate
		{
			get;
			set;
		}

		public string DG_Currency_Symbol
		{
			get;
			set;
		}

		public DateTime? DG_Currency_UpdatedDate
		{
			get;
			set;
		}

		public int? DG_Currency_ModifiedBy
		{
			get;
			set;
		}

		public bool? DG_Currency_Default
		{
			get;
			set;
		}

		public string DG_Currency_Icon
		{
			get;
			set;
		}

		public string DG_Currency_Code
		{
			get;
			set;
		}

		public bool? DG_Currency_IsActive
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
