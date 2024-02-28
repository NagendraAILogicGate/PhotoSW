using System;

namespace PhotoSW.IMIX.Model
{
	public class ItemTemplatePrintOrderModel
	{
		public int Id
		{
			get;
			set;
		}

		public int OrderLineItemId
		{
			get;
			set;
		}

		public int MasterTemplateId
		{
			get;
			set;
		}

		public int DetailTemplateId
		{
			get;
			set;
		}

		public int PrintTypeId
		{
			get;
			set;
		}

		public int PhotoId
		{
			get;
			set;
		}

		public int PageNo
		{
			get;
			set;
		}

		public int PrintPosition
		{
			get;
			set;
		}

		public int RotationAngle
		{
			get;
			set;
		}

		public int Status
		{
			get;
			set;
		}

		public int PrinterQueueId
		{
			get;
			set;
		}

		public string CreatedBy
		{
			get;
			set;
		}
	}
}
