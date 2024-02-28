using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using ErrorHandler;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class ValueTypeBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public ValueTypeBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ValueTypeBusiness. ;

			public List<ValueTypeInfo> ;

			public void ()
			{
				if (4 != 0)
				{
					ValueTypeDao valueTypeDao = new ValueTypeDao(this...Transaction);
					if (!false)
					{
						this. = valueTypeDao.SelectValueTypeInfoList(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<ValueTypeInfo> ;

			public ValueTypeBusiness ;

			public void ()
			{
				ValueTypeDao valueTypeDao = new ValueTypeDao(this..Transaction);
				this. = valueTypeDao.GetScanTypes();
			}
		}

		public List<ValueTypeInfo> GetReasonType(int valueTypeGroupId)
		{
			ValueTypeBusiness.  = new ValueTypeBusiness.();
			. = valueTypeGroupId;
			. = this;
			List<ValueTypeInfo> result;
			try
			{
				ValueTypeBusiness.  = new ValueTypeBusiness.();
				do
				{
					. = ;
					if (4 != 0)
					{
						. = new List<ValueTypeInfo>();
						this.operation = new BaseBusiness.TransactionMethod(.);
						if (false)
						{
							goto IL_6C;
						}
						if (!false)
						{
							base.Start(false);
						}
					}
					if (false)
					{
						continue;
					}
					result = .;
					IL_6C:;
				}
				while (6 == 0);
			}
			catch (Exception serviceException)
			{
				ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(serviceException));
				result = null;
			}
			return result;
		}

		public List<ValueTypeInfo> GetScanTypes()
		{
			List<ValueTypeInfo> ;
			try
			{
				ValueTypeBusiness.  = new ValueTypeBusiness.();
				. = this;
				do
				{
					. = null;
				}
				while (-1 == 0);
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				 = .;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return ;
		}
	}
}
