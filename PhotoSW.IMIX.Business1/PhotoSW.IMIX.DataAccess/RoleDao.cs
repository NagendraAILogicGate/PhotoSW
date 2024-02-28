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
	public class RoleDao : BaseDataAccess
	{
        ////[NonSerialized]
        ////internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getReportAccess;
        public RoleDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public RoleDao()
		{
		}

		public List<RoleInfo> SelectRole(int RoleId, string RoleName)
		{
			base.DBParameters.Clear();
			base.AddParameter(RoleDao.getReportAccess(26746), base.SetNullIntegerValue(new int?(RoleId)));
			IDataReader dataReader;
			if (2 != 0)
			{
				base.AddParameter(RoleDao.getReportAccess(26763), base.SetNullStringValue(RoleName));
				dataReader = base.ExecuteReader("");
			}
			List<RoleInfo> result = this.RoleInfoPc(dataReader);
			dataReader.Close();
			return result;
		}

		private List<RoleInfo> RoleInfoPc ( IDataReader IDataReader )
		{
			List<RoleInfo> list = new List<RoleInfo>();
			while (IDataReader.Read())
			{
				RoleInfo item = new RoleInfo
				{
					DG_User_Roles_pkey = base.GetFieldValue(IDataReader, RoleDao.getReportAccess(26784), 0),
					DG_User_Role = base.GetFieldValue(IDataReader, RoleDao.getReportAccess(26809), string.Empty),
					SyncCode = base.GetFieldValue(IDataReader, RoleDao.getReportAccess(1994), string.Empty),
					IsSynced = base.GetFieldValue(IDataReader, RoleDao.getReportAccess(2007), false)
				};
				list.Add(item);
			}
			return list;
		}

		public int INS_RolePermission(int RoleId, bool IsSynced, string UserRole, string SyncCode)
		{
			base.DBParameters.Clear();
			base.AddParameter(RoleDao.getReportAccess(26746), RoleId);
			base.AddParameter(RoleDao.getReportAccess(423), IsSynced);
			base.AddParameter(RoleDao.getReportAccess(26826), UserRole);
			base.AddParameter(RoleDao.getReportAccess(402), SyncCode);
			base.ExecuteNonQuery("");
			return (int)base.GetOutParameterValue(RoleDao.getReportAccess(26746));
		}

		public List<RoleInfo> Get(int RolesId)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(RoleDao.getReportAccess(26851), RolesId);
			}
			IDataReader dataReader;
			List<RoleInfo> result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				if (3 != 0)
				{
					result = this.RoleInfoQc(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<RoleInfo> RoleInfoQc ( IDataReader IDataReader )
		{
			List<RoleInfo> list;
			while (true)
			{
				if (!false)
				{
					List<RoleInfo> expr_4C = new List<RoleInfo>();
					if (!false)
					{
						list = expr_4C;
					}
				}
				while (true)
				{
					if (IDataReader.Read() && -1 != 0)
					{
						RoleInfo item = new RoleInfo
						{
							DG_User_Role = base.GetFieldValue(IDataReader, RoleDao.getReportAccess(26809), string.Empty)
						};
						if (5 == 0)
						{
							break;
						}
						list.Add(item);
					}
					else
					{
						if (!true)
						{
							break;
						}
						if (!false)
						{
							return list;
						}
					}
				}
			}
			return list;
		}

		public void UPDANDINS_User_Roles(int DG_User_Roles_pkey, bool IsSynced, string DG_User_Role, string SyncCode, int ParentRoleId)
		{
			if (!false)
			{
				base.DBParameters.Clear();
			}
			string expr_D1 = RoleDao.getReportAccess(26872);
			object expr_2B = DG_User_Roles_pkey;
			if (7 != 0)
			{
				base.AddParameter(expr_D1, expr_2B);
			}
			do
			{
				base.AddParameter(RoleDao.getReportAccess(423), IsSynced);
			}
			while (3 == 0);
			base.AddParameter(RoleDao.getReportAccess(26826), DG_User_Role);
			base.AddParameter(RoleDao.getReportAccess(402), SyncCode);
			base.AddParameter(RoleDao.getReportAccess(26905), ParentRoleId);
			base.ExecuteNonQuery("");
		}

		public bool DeleteRoleData(int RoleId)
		{
			base.DBParameters.Clear();
			base.AddParameter(RoleDao.getReportAccess(26746), RoleId);
			base.ExecuteNonQuery("");
			return true;
		}

		static RoleDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(RoleDao));
		}
	}
}
