using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class GroupBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public GroupBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public GroupBusiness. ;

			public List<GroupDetails> ;

			public void ()
			{
				if (4 != 0)
				{
					GroupDao groupDao = new GroupDao(this...Transaction);
					if (!false)
					{
						this. = groupDao.GetGroupDetails(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public GroupBusiness ;

			public GroupDetails ;

			public void ()
			{
				do
				{
					GroupDao groupDao;
					if (!false)
					{
						groupDao = new GroupDao(this..Transaction);
					}
					this. = groupDao.AddGroup(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public GroupBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public GroupBusiness. ;

			public List<GroupDetails> ;

			public void ()
			{
				if (4 != 0)
				{
					GroupDao groupDao = new GroupDao(this...Transaction);
					if (!false)
					{
						this. = groupDao.GetGroupProductDetails(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public GroupBusiness ;

			public GroupDetails ;

			public void ()
			{
				do
				{
					GroupDao groupDao;
					if (!false)
					{
						groupDao = new GroupDao(this..Transaction);
					}
					this. = groupDao.AddGroupProduct(this.);
				}
				while (false);
			}
		}

		public List<GroupDetails> GetGroupDetails(int GroupPkey)
		{
			if (!false && -1 != 0)
			{
			}
			2. = GroupPkey;
			2. = this;
			List<GroupDetails> result;
			try
			{
				GroupBusiness. 2 = new GroupBusiness.();
				if (!false)
				{
					2. = 2;
				}
				2. = new List<GroupDetails>();
				if (6 != 0)
				{
					this.operation = new BaseBusiness.TransactionMethod(2.2);
					if (!false)
					{
						base.Start(false);
						result = 2.;
					}
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		public bool SetGroupDetails(GroupDetails groupInfo)
		{
			GroupBusiness.  = new GroupBusiness.();
			. = groupInfo;
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

		public List<GroupDetails> GetGroupproductDetails(int GroupPkey)
		{
			if (!false && -1 != 0)
			{
			}
			. = GroupPkey;
			. = this;
			List<GroupDetails> result;
			try
			{
				GroupBusiness.  = new GroupBusiness.();
				if (!false)
				{
					. = ;
				}
				. = new List<GroupDetails>();
				if (6 != 0)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					if (!false)
					{
						base.Start(false);
						result = .;
					}
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		public bool SetGroupProductDetails(GroupDetails groupInfo)
		{
			GroupBusiness.  = new GroupBusiness.();
			. = groupInfo;
			. = this;
			. = false;
			this.operation = new BaseBusiness.TransactionMethod(.);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 = .;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}
	}
}
