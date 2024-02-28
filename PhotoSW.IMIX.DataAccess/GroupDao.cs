//using #2j;
//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class GroupDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static GetString getGroupDao;
        public GroupDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public GroupDao()
		{
		}

		public bool AddGroup(GroupDetails groupInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(GroupDao.getGroupDao(15870), groupInfo.DG_Group_pkey);
			base.AddParameter(GroupDao.getGroupDao(15899), groupInfo.DG_Group_Name);
			base.AddParameter(GroupDao.getGroupDao(391), groupInfo.SyncCode);
			base.AddParameter(GroupDao.getGroupDao(412), groupInfo.IsSynced);
			base.AddParameter(GroupDao.getGroupDao(15928), groupInfo.OperationType);
			base.ExecuteNonQuery("");
			return true;
		}

		public List<GroupDetails> GetGroupDetails(int GroupPkey)
		{
			base.DBParameters.Clear();
			base.AddParameter(GroupDao.getGroupDao(15870), GroupPkey);
			base.OpenConnection();
			List<GroupDetails> result;
			using (IDataReader dataReader = base.ExecuteReader(""))
			{
				do
				{
					result = this.groupDetails(dataReader);
				}
				while (8 == 0);
			}
			return result;
		}

		private List<GroupDetails> groupDetails ( IDataReader dataReader)
		{
			List<GroupDetails> list = new List<GroupDetails>();
			while (true)
			{
				if (4 == 0)
				{
					goto IL_6B;
				}
				IL_72:
				GroupDetails groupDetails;
				if (!dataReader.Read())
				{
					if (5 != 0)
					{
						break;
					}
				}
				else if (8 != 0)
				{
					if (5 == 0)
					{
						continue;
					}
					groupDetails = new GroupDetails();
					groupDetails.DG_Group_pkey = base.GetFieldValue(dataReader, GroupDao.getGroupDao(15949), 0);
				}
				if (!false)
				{
					groupDetails.DG_Group_Name = base.GetFieldValue(dataReader, GroupDao.getGroupDao(15970), string.Empty);
				}
				GroupDetails item = groupDetails;
				IL_6B:
				list.Add(item);
				goto IL_72;
			}
			return list;
		}

		public bool AddGroupProduct(GroupDetails groupInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(GroupDao.getGroupDao(15870), groupInfo.DG_Group_pkey);
			base.AddParameter(GroupDao.getGroupDao(15991), groupInfo.DG_ProductCode);
			base.AddParameter(GroupDao.getGroupDao(15928), groupInfo.OperationType);
			base.ExecuteNonQuery("");
			return true;
		}

		public List<GroupDetails> GetGroupProductDetails(int GroupPkey)
		{
			base.DBParameters.Clear();
			base.AddParameter(GroupDao.getGroupDao(15870), GroupPkey);
			base.OpenConnection();
			List<GroupDetails> result;
			using (IDataReader dataReader = base.ExecuteReader(""))
			{
				do
				{
					result = this.groupDetails2(dataReader);
				}
				while (8 == 0);
			}
			return result;
		}

		private List<GroupDetails> groupDetails2 ( IDataReader dataReader)
		{
			List<GroupDetails> list = new List<GroupDetails>();
			while (true)
			{
				while (dataReader.Read())
				{
					GroupDetails groupDetails = new GroupDetails();
					if (true)
					{
						groupDetails.DG_Group_pkey = base.GetFieldValue(dataReader, GroupDao.getGroupDao(16020), 0);
						groupDetails.DG_ProductCode = base.GetFieldValue(dataReader, GroupDao.getGroupDao(16041), string.Empty);
						groupDetails.DG_Group_Name = base.GetFieldValue(dataReader, GroupDao.getGroupDao(15970), string.Empty);
						GroupDetails item = groupDetails;
						list.Add(item);
					}
				}
				break;
			}
			return list;
		}

		static GroupDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
		//	SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(GroupDao));
		}
	}
}
