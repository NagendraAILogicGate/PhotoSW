using System;

namespace PhotoSW.IMIX.Model
{
	public class ValueTypeInfo
	{
		public int ValueTypeId
		{
			get;
			set;
		}

		public int ValueTypeGroupId
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public int DisplayOrder
		{
			get;
			set;
		}

		public int CreatedBy
		{
			get;
			set;
		}

		public DateTime CreatedDate
		{
			get;
			set;
		}

		public int? ModifiedBy
		{
			get;
			set;
		}

		public DateTime? ModifiedDate
		{
			get;
			set;
		}

		public bool IsActive
		{
			get;
			set;
		}
	}
}
