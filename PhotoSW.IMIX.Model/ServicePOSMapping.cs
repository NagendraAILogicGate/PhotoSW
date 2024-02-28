using System;

namespace PhotoSW.IMIX.Model
{
	public class ServicePOSMapping
	{
		public long ServicePOSMappingID
		{
			get;
			set;
		}

		public long ServiceID
		{
			get;
			set;
		}

		public long ImixPOSDetailID
		{
			get;
			set;
		}

		public string CreatedBy
		{
			get;
			set;
		}

		public DateTime CreatedOn
		{
			get;
			set;
		}

		public string UpdatedBy
		{
			get;
			set;
		}

		public DateTime UpdatedOn
		{
			get;
			set;
		}

		public bool Status
		{
			get;
			set;
		}
	}
}
