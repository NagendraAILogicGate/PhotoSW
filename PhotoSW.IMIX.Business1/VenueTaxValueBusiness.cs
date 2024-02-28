using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class VenueTaxValueBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public List<VenueTaxValueModel> ;

			public VenueTaxValueBusiness ;

			public void ()
			{
				VenueTaxValueAccess venueTaxValueAccess = new VenueTaxValueAccess(this..Transaction);
				this. = venueTaxValueAccess.GetVenueTaxValueDetail();
			}
		}

		public List<VenueTaxValueModel> GetVenueTaxValue()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					2. = this;
				}
				while (false);
				2. = new List<VenueTaxValueModel>();
				do
				{
					base.Operation = new BaseBusiness.TransactionMethod(2.2);
				}
				while (2 == 0);
				base.Start(false);
			}
			return 2.;
		}
	}
}
