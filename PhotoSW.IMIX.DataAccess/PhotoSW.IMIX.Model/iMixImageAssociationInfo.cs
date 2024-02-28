using System;

namespace PhotoSW.IMIX.Model
{
	public class iMixImageAssociationInfo
	{
		public long IMIXImageAssociationId
		{
			get;
			set;
		}

		public int IMIXCardTypeId
		{
			get;
			set;
		}

		public int PhotoId
		{
			get;
			set;
		}

		public string CardUniqueIdentifier
		{
			get;
			set;
		}

		public string MappedIdentifier
		{
			get;
			set;
		}
	}
}
