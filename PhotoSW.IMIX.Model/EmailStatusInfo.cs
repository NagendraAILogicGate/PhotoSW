using System;

namespace PhotoSW.IMIX.Model
{
	public class EmailStatusInfo
	{
		public int DG_Email_pkey
		{
			get;
			set;
		}

		public string OrderId
		{
			get;
			set;
		}

		public string EmailId
		{
			get;
			set;
		}

		public string PhotoId
		{
			get;
			set;
		}

		public int Status
		{
			get;
			set;
		}

		public DateTime EmailDateTime
		{
			get;
			set;
		}

		public string StatusDetail
		{
			get;
			set;
		}

		public DateTime StartDate
		{
			get;
			set;
		}

		public DateTime EndDate
		{
			get;
			set;
		}

		public bool? IsAvailable
		{
			get;
			set;
		}

		public string MediaName
		{
			get;
			set;
		}

		public string PhotoCount
		{
			get;
			set;
		}
	}
}
