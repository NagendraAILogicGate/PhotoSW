using System;

namespace PhotoSW.IMIX.Model
{
	public class ReportTypeDetails : BaseDataModel
	{
		private int id;

		private string reportTypeName;

		private bool isActive;

		private string reportLabel;

		public int Id
		{
			get
			{
				return this.id;
			}
			set
			{
				this.id = value;
				this.PropertyModified("Id");
			}
		}

		public string ReportTypeName
		{
			get
			{
				return this.reportTypeName;
			}
			set
			{
				this.reportTypeName = value;
				this.PropertyModified("ReportTypeName");
			}
		}

		public bool IsActive
		{
			get
			{
				return this.isActive;
			}
			set
			{
				this.isActive = value;
				this.PropertyModified("IsActive");
			}
		}

		public string ReportLabel
		{
			get
			{
				return this.reportLabel;
			}
			set
			{
				this.reportLabel = value;
				this.PropertyModified("ReportLabel");
			}
		}
	}
}
