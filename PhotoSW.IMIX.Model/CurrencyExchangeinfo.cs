using System;

namespace PhotoSW.IMIX.Model
{
	public class CurrencyExchangeinfo
	{
		public long ProfileAuditID
		{
			get;
			set;
		}

		public string ProfileName
		{
			get;
			set;
		}

		public DateTime startDate
		{
			get;
			set;
		}

		public DateTime? Enddate
		{
			get;
			set;
		}

		public bool IsActive
		{
			get;
			set;
		}

		public long CreatedBy
		{
			get;
			set;
		}

		public DateTime CreatedOn
		{
			get;
			set;
		}

		public long Updatedby
		{
			get;
			set;
		}

		public DateTime updatedon
		{
			get;
			set;
		}

		public DateTime PublishedOn
		{
			get;
			set;
		}

		public bool IsCurrent
		{
			get;
			set;
		}
	}
}
