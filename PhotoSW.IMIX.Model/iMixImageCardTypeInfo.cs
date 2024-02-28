using System;

namespace PhotoSW.IMIX.Model
{
	public class iMixImageCardTypeInfo
	{
		public int IMIXImageCardTypeId
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string CardIdentificationDigit
		{
			get;
			set;
		}

		public int ImageIdentificationType
		{
			get;
			set;
		}

		public bool IsActive
		{
			get;
			set;
		}

		public int MaxImages
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public DateTime CreatedOn
		{
			get;
			set;
		}

		public bool? IsWaterMark
		{
			get;
			set;
		}

		public bool IsPrepaid
		{
			get;
			set;
		}

		public int PackageId
		{
			get;
			set;
		}
	}
}
