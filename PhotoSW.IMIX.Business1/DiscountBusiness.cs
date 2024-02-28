using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class DiscountBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public DiscountTypeInfo ;

			public DiscountTypeInfo ;

			public DiscountBusiness ;

			public string ;

			public void ()
			{
				DiscountTypeDao discountTypeDao = new DiscountTypeDao(this..Transaction);
				this. = discountTypeDao.Get(null, this.);
			}

			public void ()
			{
				while (true)
				{
					DiscountTypeDao discountTypeDao;
					if (!false)
					{
						discountTypeDao = new DiscountTypeDao(this..Transaction);
					}
					if (!false)
					{
						if (5 != 0)
						{
							discountTypeDao.Add(this.);
						}
						if (!false)
						{
							break;
						}
					}
				}
			}

			public void ()
			{
				while (true)
				{
					this..DG_Orders_DiscountType_Pkey = this..DG_Orders_DiscountType_Pkey;
					DiscountTypeDao expr_54 = new DiscountTypeDao(this..Transaction);
					DiscountTypeDao discountTypeDao;
					if (!false)
					{
						discountTypeDao = expr_54;
					}
					if (3 != 0)
					{
						discountTypeDao.Update(this.);
						if (7 != 0)
						{
							break;
						}
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<DiscountTypeInfo> ;

			public DiscountBusiness ;

			public void ()
			{
				if (4 != 0)
				{
					DiscountTypeDao discountTypeDao = new DiscountTypeDao(this..Transaction);
					this. = discountTypeDao.Select(null, string.Empty);
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public DiscountBusiness ;

			public int ;

			public void ()
			{
				do
				{
					DiscountTypeDao discountTypeDao;
					if (!false)
					{
						discountTypeDao = new DiscountTypeDao(this..Transaction);
					}
					this. = discountTypeDao.Delete(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DiscountTypeInfo ;

			public DiscountBusiness ;

			public int ;

			public void ()
			{
				if (4 != 0)
				{
					DiscountTypeDao discountTypeDao = new DiscountTypeDao(this..Transaction);
					this. = discountTypeDao.Get(new int?(this.), string.Empty);
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<DiscountTypeInfo> ;

			public DiscountBusiness ;

			public void ()
			{
				if (4 != 0)
				{
					DiscountTypeDao discountTypeDao = new DiscountTypeDao(this..Transaction);
					this. = discountTypeDao.Select(null, string.Empty);
				}
			}
		}

		[NonSerialized]
		internal static SmartAssembly.Delegates.GetString ;

		public void SetDiscountDetails(string DiscountName, string DiscountDesc, bool isactive, bool issecure, bool isitemlevel, bool isaspercentage, string Discountcode, string SyncCode)
		{
			BaseBusiness.TransactionMethod transactionMethod = null;
			BaseBusiness.TransactionMethod transactionMethod2 = null;
			DiscountBusiness.  = new DiscountBusiness.();
			. = DiscountName;
			. = this;
			. = new DiscountTypeInfo();
			. = new DiscountTypeInfo();
			..DG_Orders_DiscountType_Name = .;
			..DG_Orders_DiscountType_Desc = DiscountDesc;
			..DG_Orders_DiscountType_Active = new bool?(isactive);
			..DG_Orders_DiscountType_Secure = new bool?(issecure);
			..DG_Orders_DiscountType_ItemLevel = new bool?(isitemlevel);
			..DG_Orders_DiscountType_AsPercentage = new bool?(isaspercentage);
			..DG_Orders_DiscountType_Code = Discountcode;
			..SyncCode = SyncCode;
			..IsSynced = false;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			if (. == null)
			{
				if (transactionMethod == null)
				{
					transactionMethod = new BaseBusiness.TransactionMethod(.);
				}
				this.operation = transactionMethod;
				base.Start(false);
				return;
			}
			if (8 != 0)
			{
				if (transactionMethod2 == null)
				{
					transactionMethod2 = new BaseBusiness.TransactionMethod(.);
				}
				this.operation = transactionMethod2;
				base.Start(false);
			}
		}

		public List<DiscountTypeInfo> GetDiscountDetails()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					2. = this;
				}
				while (false);
				2. = new List<DiscountTypeInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(2.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return 2.;
		}

		public bool DeleteDiscount(int id)
		{
			DiscountBusiness.  = new DiscountBusiness.();
			. = id;
			. = this;
			. = false;
			this.operation = new BaseBusiness.TransactionMethod(.);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 = .;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}

		public string GetDiscountDetailsFromID(int id)
		{
			DiscountBusiness.  = new DiscountBusiness.();
			object[] array;
			while (true)
			{
				. = id;
				. = this;
				if (!false)
				{
					. = new DiscountTypeInfo();
					goto IL_3D;
				}
				goto IL_DC;
				IL_EF:
				array[7] = DiscountBusiness.(1558);
				if (!false)
				{
					array[8] = ..DG_Orders_DiscountType_ItemLevel;
					if (5 != 0)
					{
						array[9] = DiscountBusiness.(1558);
						goto IL_133;
					}
					continue;
				}
				IL_3D:
				if (3 == 0)
				{
					goto IL_EF;
				}
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				if (. == null)
				{
					goto IL_179;
				}
				array = new object[13];
				array[0] = ..DG_Orders_DiscountType_Name;
				array[1] = DiscountBusiness.(1558);
				array[2] = ..DG_Orders_DiscountType_Desc;
				array[3] = DiscountBusiness.(1558);
				array[4] = ..DG_Orders_DiscountType_Active;
				if (false)
				{
					goto IL_133;
				}
				array[5] = DiscountBusiness.(1558);
				IL_DC:
				array[6] = ..DG_Orders_DiscountType_Secure;
				goto IL_EF;
				IL_133:
				array[10] = ..DG_Orders_DiscountType_AsPercentage;
				array[11] = DiscountBusiness.(1558);
				while (7 != 0)
				{
					array[12] = ..DG_Orders_DiscountType_Code;
					if (6 != 0)
					{
						goto Block_8;
					}
				}
				goto IL_3D;
			}
			Block_8:
			return string.Concat(array);
			IL_179:
			return null;
		}

		public List<DiscountTypeInfo> GetDiscountType()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = new List<DiscountTypeInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		static DiscountBusiness()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(DiscountBusiness));
		}
	}
}
