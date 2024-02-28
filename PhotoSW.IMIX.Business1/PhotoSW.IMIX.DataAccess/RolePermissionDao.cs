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
	public class RolePermissionDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getRolePermission;
        public RolePermissionDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public RolePermissionDao()
		{
		}

		public List<PermissionRoleInfo> SelectRolePermissions(int RoleId)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(RolePermissionDao.getRolePermission(26747), RoleId);
			}
			IDataReader dataReader;
			List<PermissionRoleInfo> result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				if (3 != 0)
				{
					result = this.PermissionRoleInfoRc(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<PermissionRoleInfo> PermissionRoleInfoRc ( IDataReader IDataReader )
		{
			List<PermissionRoleInfo> list = new List<PermissionRoleInfo>();
			while (true)
			{
				while (IDataReader.Read())
				{
					PermissionRoleInfo permissionRoleInfo = new PermissionRoleInfo();
					if (true)
					{
						permissionRoleInfo.DG_Permission_Role_pkey = base.GetFieldValue(IDataReader, RolePermissionDao.getRolePermission(26935), 0);
						permissionRoleInfo.DG_User_Roles_Id = base.GetFieldValue(IDataReader, RolePermissionDao.getRolePermission(22198), 0);
						permissionRoleInfo.DG_Permission_Id = base.GetFieldValue(IDataReader, RolePermissionDao.getRolePermission(26968), 0);
						PermissionRoleInfo item = permissionRoleInfo;
						list.Add(item);
					}
				}
				break;
			}
			return list;
		}

		public List<PermissionInfo> SelectPermission(string PermissionId, string PermissionName)
		{
			base.DBParameters.Clear();
			base.AddParameter(RolePermissionDao.getRolePermission(26993), base.SetNullStringValue(PermissionId));
			base.AddParameter(RolePermissionDao.getRolePermission(27018), base.SetNullStringValue(PermissionName));
			IDataReader dataReader = base.ExecuteReader("");
			List<PermissionInfo> result = this.PermissionInfoSc(dataReader);
			dataReader.Close();
			return result;
		}

		private List<PermissionInfo> PermissionInfoSc ( IDataReader IDataReader )
		{
			List<PermissionInfo> list = new List<PermissionInfo>();
			while (IDataReader.Read())
			{
				PermissionInfo item = new PermissionInfo
				{
					DG_Permission_pkey = base.GetFieldValue(IDataReader, RolePermissionDao.getRolePermission(27047), 0),
					DG_Permission_Name = base.GetFieldValue(IDataReader, RolePermissionDao.getRolePermission(27072), string.Empty),
					SyncCode = base.GetFieldValue(IDataReader, RolePermissionDao.getRolePermission(1995), string.Empty),
					IsSynced = base.GetFieldValue(IDataReader, RolePermissionDao.getRolePermission(2008), false)
				};
				list.Add(item);
			}
			return list;
		}

		public bool InsertPermissionData(int RoleId, int PermissonId, bool Retvalue)
		{
			base.DBParameters.Clear();
			bool result;
			while (true)
			{
				base.AddParameter(RolePermissionDao.getRolePermission(26747), RoleId);
				if (!false)
				{
					base.AddParameter(RolePermissionDao.getRolePermission(27097), PermissonId);
					base.AddParameter(RolePermissionDao.getRolePermission(27122), Retvalue, ParameterDirection.Output);
					base.ExecuteNonQuery("");
					if (6 != 0)
					{
						result = (bool)base.GetOutParameterValue(RolePermissionDao.getRolePermission(27122));
					}
					if (3 != 0)
					{
						break;
					}
				}
			}
			return result;
		}

		public bool RemovePermissionData(int User_Roles_Id, int Permission_Id)
		{
			base.DBParameters.Clear();
			base.AddParameter(RolePermissionDao.getRolePermission(27135), User_Roles_Id);
			do
			{
				base.AddParameter(RolePermissionDao.getRolePermission(27164), Permission_Id);
			}
			while (4 == 0);
			base.ExecuteReader("");
			return true;
		}

		public List<PermissionRoleInfo> SelectRolePermissionsWithFlag(int RoleId, bool Flag)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(RolePermissionDao.getRolePermission(26747), RoleId);
			}
			IDataReader dataReader;
			List<PermissionRoleInfo> result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				if (3 != 0)
				{
					result = this.PermissionRoleInfoRc(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		public bool SetremovePermissionData(DataTable udt_Permission, bool Retvalue)
		{
			base.DBParameters.Clear();
			base.AddParameter(RolePermissionDao.getRolePermission(27193), udt_Permission);
			base.AddParameter(RolePermissionDao.getRolePermission(27122), Retvalue, ParameterDirection.Output);
			bool result;
			do
			{
				base.ExecuteReader("");
				result = (bool)base.GetOutParameterValue(RolePermissionDao.getRolePermission(27122));
			}
			while (3 == 0);
			return result;
		}

		public List<RoleInfo> GetChildUserData(int RoleId)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(RolePermissionDao.getRolePermission(26747), RoleId);
			}
			IDataReader dataReader;
			List<RoleInfo> result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				if (3 != 0)
				{
					result = this.RoleInfoTc(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<RoleInfo> RoleInfoTc ( IDataReader IDataReader)
		{
			List<RoleInfo> list = new List<RoleInfo>();
			while (IDataReader.Read())
			{
				RoleInfo item = new RoleInfo
				{
					DG_User_Roles_pkey = base.GetFieldValue(IDataReader, RolePermissionDao.getRolePermission(26785), 0),
					DG_User_Role = base.GetFieldValue(IDataReader, RolePermissionDao.getRolePermission(26810), string.Empty),
					SyncCode = base.GetFieldValue(IDataReader, RolePermissionDao.getRolePermission(1995), string.Empty),
					IsSynced = base.GetFieldValue(IDataReader, RolePermissionDao.getRolePermission(2008), false)
				};
				list.Add(item);
			}
			return list;
		}

		static RolePermissionDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(RolePermissionDao));
		}
	}
}
