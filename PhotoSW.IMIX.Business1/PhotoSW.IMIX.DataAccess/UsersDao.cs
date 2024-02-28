//using #2j;
using PhotoSW.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace PhotoSW.IMIX.DataAccess
{
	public class UsersDao : BaseDataAccess
	{
		
		//internal static SmartAssembly.Delegates.GetString getUsersDao;
       internal static SmartAssembly.Delegates.GetString getUsersDao;
		public UsersDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public UsersDao()
		{
		}

		public bool UPD_UserLocation(UsersInfo objectInfo)
		{
			do
			{
				List<SqlParameter> expr_56 = base.DBParameters;
				if (6 != 0)
				{
					expr_56.Clear();
				}
				base.AddParameter(UsersDao.getUsersDao (29674), objectInfo.DG_User_pkey);
				base.AddParameter(UsersDao.getUsersDao (29295), objectInfo.DG_Location_ID);
			}
			while (false);
			//base.ExecuteNonQuery(#1j.#pg);
			return true;
		}

		public bool UPD_User(UsersInfo objectInfo)
		{
			while (true)
			{
				IL_00:
				base.DBParameters.Clear();
				while (true)
				{
					base.AddParameter(UsersDao.getUsersDao(29674), objectInfo.DG_User_pkey);
					while (true)
					{
						base.AddParameter(UsersDao.getUsersDao (29699), objectInfo.DG_User_Roles_Id);
						if (false)
						{
							goto IL_00;
						}
						base.AddParameter(UsersDao.getUsersDao (29295), objectInfo.DG_Location_ID);
						base.AddParameter(UsersDao.getUsersDao (29732), objectInfo.DG_User_CreatedDate);
						base.AddParameter(UsersDao.getUsersDao (29769), objectInfo.DG_User_Status);
						base.AddParameter(UsersDao.getUsersDao (431), objectInfo.IsSynced);
						base.AddParameter(UsersDao.getUsersDao (29798), objectInfo.DG_User_Name);
						base.AddParameter(UsersDao.getUsersDao (29823), objectInfo.DG_User_First_Name);
						if (false)
						{
							break;
						}
						if (!false)
						{
							goto Block_2;
						}
					}
				}
			}
			Block_2:
			base.AddParameter(UsersDao.getUsersDao (29856), objectInfo.DG_User_Last_Name);
			base.AddParameter(UsersDao.getUsersDao (29889), objectInfo.DG_User_PhoneNo);
			base.AddParameter(UsersDao.getUsersDao (29918), objectInfo.DG_User_Email);
			base.AddParameter(UsersDao.getUsersDao (410), objectInfo.SyncCode);
			base.AddParameter(UsersDao.getUsersDao (29947), objectInfo.DG_User_Password);
			//base.ExecuteNonQuery(#1j.#zg);
			return true;
		}

		public List<UsersInfo> GetUsersInfo(int Userkey, int StoreID, int UserRolesId, int UserStatus, string UserName, string UserFirstName)
		{
			List<SqlParameter> expr_DE = base.DBParameters;
			if (!false)
			{
				expr_DE.Clear();
			}
			string expr_F8 = UsersDao.getUsersDao(29674);
			object expr_2A = Userkey;
			if (!false)
			{
				base.AddParameter(expr_F8, expr_2A);
			}
			base.AddParameter(UsersDao.getUsersDao (16159), StoreID);
			base.AddParameter(UsersDao.getUsersDao (29699), UserRolesId);
			base.AddParameter(UsersDao.getUsersDao (29769), UserStatus);
			base.AddParameter(UsersDao.getUsersDao (29798), UserName);
			base.AddParameter(UsersDao.getUsersDao (29823), UserFirstName);
			IDataReader dataReader =null; //base.ExecuteReader(#1j.#wg);
			List<UsersInfo> result = this.UsersInfo8c(dataReader);
			dataReader.Close();
			return result;
		}

		private List<UsersInfo> UsersInfo8c(IDataReader IDataReader)
		{
			List<UsersInfo> list = new List<UsersInfo>();
			while (IDataReader.Read())
			{
				UsersInfo item = new UsersInfo
				{
					DG_User_pkey = base.GetFieldValue(IDataReader, UsersDao.getUsersDao(703), 0),
					DG_User_Role = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (26817), string.Empty),
					DG_User_First_Name = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (653), string.Empty),
					DG_User_Last_Name = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (678), string.Empty),
					DG_User_Password = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (29980), string.Empty),
					DG_User_Name = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (636), string.Empty),
					DG_User_Roles_Id = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (22205), 0),
					DG_Location_Name = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (16381), string.Empty),
					DG_Store_ID = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (16485), 0),
					DG_Location_pkey = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (16406), 0),
					DG_User_Status = new bool?(base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30005), false)),
					DG_User_PhoneNo = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30026), string.Empty),
					UserName = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (25889), string.Empty),
					StatusName = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30047), string.Empty),
					DG_User_Email = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30064), string.Empty),
					DG_Store_Name = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30085), string.Empty),
					CountryCode = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30106), string.Empty),
					StoreCode = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30123), string.Empty),
					DG_Substore_ID = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30136), 0)
				};
				list.Add(item);
			}
			return list;
		}

		public UsersInfo GetUserDetails(string userName, string password, bool userStatus)
		{
			base.DBParameters.Clear();
			while (true)
			{
				if (!false)
				{
					base.AddParameter(UsersDao.getUsersDao (29798), userName);
				}
				base.AddParameter(UsersDao.getUsersDao (29947), password);
				while (!false)
				{
					base.AddParameter(UsersDao.getUsersDao (29769), userStatus);
					if (5 != 0)
					{
						goto Block_3;
					}
				}
			}
			Block_3:
			IDataReader dataReader =null; //base.ExecuteReader(#1j.#vg);
			List<UsersInfo> source;
			try
			{
				source = this.UsersInfo4(dataReader);
			}
			finally
			{
				if (!false && !false && dataReader != null)
				{
					dataReader.Dispose();
				}
			}
			return source.FirstOrDefault<UsersInfo>();
		}

		private List<UsersInfo> UsersInfo4(IDataReader IDataReader)
		{
			List<UsersInfo> list = new List<UsersInfo>();
			while (IDataReader.Read())
			{
				UsersInfo item = new UsersInfo
				{
					DG_User_pkey = base.GetFieldValue(IDataReader, UsersDao.getUsersDao(703), 0),
					DG_User_Role = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (26817), string.Empty),
					DG_User_First_Name = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (653), string.Empty),
					DG_User_Last_Name = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (678), string.Empty),
					DG_User_Password = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (29980), string.Empty),
					DG_User_Name = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (636), string.Empty),
					DG_User_Roles_Id = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (22205), 0),
					DG_Location_Name = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (16381), string.Empty),
					DG_Store_ID = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (16485), 0),
					DG_Location_pkey = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (16406), 0),
					DG_User_Status = new bool?(base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30005), false)),
					DG_User_PhoneNo = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30026), string.Empty),
					UserName = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (25889), string.Empty),
					StatusName = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30047), string.Empty),
					DG_User_Email = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30064), string.Empty),
					DG_Store_Name = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30085), string.Empty),
					CountryCode = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30106), string.Empty),
					StoreCode = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30123), string.Empty),
					ServerHotFolderPath = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30157), string.Empty)
				};
				list.Add(item);
			}
			return list;
		}

		public UsersInfo GetLocationIdbyUserId(int UserId)
		{
			List<UsersInfo> source;
			do
			{
				if (!false)
				{
					base.DBParameters.Clear();
					do
					{
						base.AddParameter(UsersDao.getUsersDao (3528), UserId);
					}
					while (4 == 0);
					IDataReader dataReader = null;//base.ExecuteReader(#1j.#ui);
					try
					{
						if (7 != 0)
						{
							source = this.UsersInfo9c(dataReader);
						}
					}
					finally
					{
						if (!false && dataReader != null)
						{
							dataReader.Dispose();
						}
					}
				}
			}
			while (3 == 0);
			return source.FirstOrDefault<UsersInfo>();
		}

		private List<UsersInfo> UsersInfo9c(IDataReader IDataReader)
		{
			List<UsersInfo> list;
			while (true)
			{
				if (!false)
				{
					List<UsersInfo> expr_48 = new List<UsersInfo>();
					if (!false)
					{
						list = expr_48;
					}
				}
				while (true)
				{
					if (IDataReader.Read() && -1 != 0)
					{
						UsersInfo item = new UsersInfo
						{
							DG_Location_ID = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (16304), 0)
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

		public bool UPD_EncryptUsersPwd(int UserKey, string UserValue)
		{
			do
			{
				base.DBParameters.Clear();
				do
				{
					if (!false)
					{
						base.AddParameter(UsersDao.getUsersDao (29674), UserKey);
					}
					if (8 != 0)
					{
						base.AddParameter(UsersDao.getUsersDao (29947), UserValue);
					}
				}
				while (3 == 0);
			}
			while (2 == 0 || 6 == 0);
			//base.ExecuteNonQuery(#1j.#zi);
			return true;
		}

		public bool UPD_INS_UserDetails(int DG_User_pkey, int DG_User_Roles_Id, int DG_Location_ID, bool? DG_User_Status, string DG_User_Name, string DG_User_First_Name, string DG_User_Last_Name, string DG_User_PhoneNo, string DG_User_Email, string SyncCode, string DG_User_Password)
		{
			do
			{
				base.DBParameters.Clear();
				string expr_17F = UsersDao.getUsersDao (29674);
				object expr_28 = DG_User_pkey;
				if (-1 != 0)
				{
					base.AddParameter(expr_17F, expr_28);
				}
				base.AddParameter(UsersDao.getUsersDao (29699), DG_User_Roles_Id);
				base.AddParameter(UsersDao.getUsersDao (29295), DG_Location_ID);
				base.AddParameter(UsersDao.getUsersDao (29769), DG_User_Status);
				base.AddParameter(UsersDao.getUsersDao (431), false);
				base.AddParameter(UsersDao.getUsersDao (29798), DG_User_Name);
				base.AddParameter(UsersDao.getUsersDao (29823), DG_User_First_Name);
				if (5 != 0)
				{
					base.AddParameter(UsersDao.getUsersDao (29856), DG_User_Last_Name);
				}
			}
			while (8 == 0);
			base.AddParameter(UsersDao.getUsersDao (29889), DG_User_PhoneNo);
			base.AddParameter(UsersDao.getUsersDao (29918), DG_User_Email);
			base.AddParameter(UsersDao.getUsersDao (410), SyncCode);
			base.AddParameter(UsersDao.getUsersDao (29947), DG_User_Password);
			//base.ExecuteNonQuery(#1j.#Ci);
			return true;
		}

		public int UpdAndInsCameraDetails(int CameraId, int PhotoGrapherId, int LoginId, int LocationId, string CameraName, string CameraMake, string CameraModel, string PhotoSeries, string SyncCode)
		{
			base.DBParameters.Clear();
			if (5 != 0)
			{
				string expr_133 = UsersDao.getUsersDao (3583);
				object expr_2B = CameraId;
				if (!false)
				{
					base.AddParameter(expr_133, expr_2B);
				}
				base.AddParameter(UsersDao.getUsersDao (3704), PhotoGrapherId);
			}
			base.AddParameter(UsersDao.getUsersDao (3733), LoginId);
			base.AddParameter(UsersDao.getUsersDao (3754), LocationId);
			if (4 != 0)
			{
				base.AddParameter(UsersDao.getUsersDao (3604), CameraName);
				base.AddParameter(UsersDao.getUsersDao (3629), CameraMake);
			}
			base.AddParameter(UsersDao.getUsersDao(3654), CameraModel);
			base.AddParameter(UsersDao.getUsersDao(3679), PhotoSeries);
			base.AddParameter(UsersDao.getUsersDao(410), SyncCode);
			//base.ExecuteNonQuery(#1j.#5e);
			return 0;
		}

		public List<UsersInfo> GetUsersPwdDetails()
		{
			base.DBParameters.Clear();
			IDataReader dataReader=null;
            //if (8 != 0)
            //{
            //    dataReader = base.ExecuteReader(#1j.#fj);
            //}
            List<UsersInfo> result = this.UsersInfoad(dataReader);
			dataReader.Close();
			return result;
		}

		private List<UsersInfo> UsersInfoad(IDataReader IDataReader)
		{
			List<UsersInfo> list = new List<UsersInfo>();
			while (true)
			{
                //if (4 == 0)
                //{
                //    goto IL_6B;
                //}
				IL_72:
				UsersInfo usersInfo;
				if (!IDataReader.Read())
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
					usersInfo = new UsersInfo();
					usersInfo.DG_User_pkey = base.GetFieldValue(IDataReader, UsersDao.getUsersDao(703), 0);
				}
				if (!false)
				{
					usersInfo.DG_User_Password = base.GetFieldValue(IDataReader, UsersDao.getUsersDao(29980) ,string.Empty);
				}
				UsersInfo item = usersInfo;
				IL_6B:
				list.Add(item);
				goto IL_72;
			}
			return list;
		}

		public Dictionary<string, int> SelUserDetailsByUserId(int userId)
		{
			if (false)
			{
				goto IL_40;
			}
			List<SqlParameter> expr_51 = base.DBParameters;
			if (!false)
			{
				expr_51.Clear();
			}
			if (-1 == 0)
			{
				goto IL_49;
			}
			base.AddParameter(UsersDao.getUsersDao (30186), base.SetNullIntegerValue(new int?(userId)));
			IL_29:
			IDataReader dataReader=null;
			Dictionary<string, int> result;
			if (!false)
			{
				//dataReader = base.ExecuteReader(#1j.#Re);
				result = this.Dictionarybd(dataReader);
			}
			IL_40:
			if (-1 == 0)
			{
				goto IL_29;
			}
			dataReader.Close();
			IL_49:
			if (!false)
			{
				return result;
			}
			goto IL_40;
		}

		private Dictionary<string, int> Dictionarybd(IDataReader IDataReader)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			dictionary.Add(UsersDao.getUsersDao (16359), 0);
			while (IDataReader.Read())
			{
				dictionary.Add(string.Concat(new string[]
				{
					base.GetFieldValue(IDataReader, UsersDao.getUsersDao (653), string.Empty),
					base.GetFieldValue(IDataReader, UsersDao.getUsersDao (678), string.Empty),
					UsersDao.getUsersDao (30207),
					base.GetFieldValue(IDataReader, UsersDao.getUsersDao (636), string.Empty),
					UsersDao.getUsersDao (30212)
				}), base.GetFieldValue(IDataReader, UsersDao.getUsersDao (703), 0));
			}
			return dictionary;
		}

		public List<UsersInfo> SelUserDetailByUserId(int userId, string userName, int roleId)
		{
			if (!false)
			{
				base.DBParameters.Clear();
			}
			if (true)
			{
				base.AddParameter(UsersDao.getUsersDao (30186), base.SetNullIntegerValue(new int?(userId)));
				if (false)
				{
					goto IL_99;
				}
				base.AddParameter(UsersDao.getUsersDao (25822), base.SetNullStringValue(userName));
			}
			base.AddParameter(UsersDao.getUsersDao (26754), base.SetNullIntegerValue(new int?(roleId)));
			IDataReader dataReader =null; //base.ExecuteReader(#1j.#Re);
			List<UsersInfo> result;
			if (5 != 0)
			{
				result = this.UsersInfocd(dataReader);
			}
			IL_99:
			if (!false)
			{
				dataReader.Close();
			}
			return result;
		}

		public List<UsersInfo> GetChildUserDetailByUserId(int roleId)
		{
			if (false)
			{
				goto IL_40;
			}
			List<SqlParameter> expr_51 = base.DBParameters;
			if (!false)
			{
				expr_51.Clear();
			}
			if (-1 == 0)
			{
				goto IL_49;
			}
			base.AddParameter(UsersDao.getUsersDao(26754), base.SetNullIntegerValue(new int?(roleId)));
			IL_29:
			IDataReader dataReader=null;
			List<UsersInfo> result;
			if (!false)
			{
				//dataReader = base.ExecuteReader(#1j.#Se);
				result = this.UsersInfocd(dataReader);
			}
			IL_40:
			if (-1 == 0)
			{
				goto IL_29;
			}
			dataReader.Close();
			IL_49:
			if (!false)
			{
				return result;
			}
			goto IL_40;
		}

		private List<UsersInfo> UsersInfocd(IDataReader IDataReader)
		{
			List<UsersInfo> list = new List<UsersInfo>();
			while (IDataReader.Read())
			{
				UsersInfo item = new UsersInfo
				{
						DG_User_pkey = base.GetFieldValue(IDataReader, UsersDao.getUsersDao(703), 0),
					DG_User_Role = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (26817), string.Empty),
					DG_User_First_Name = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (653), string.Empty),
					DG_User_Last_Name = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (678), string.Empty),
					DG_User_Password = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (29980), string.Empty),
					DG_User_Name = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (636), string.Empty),
					DG_User_Roles_Id = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (22205), 0),
					DG_Location_Name = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (16381), string.Empty),
					DG_Store_ID = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (16485), 0),
					DG_Location_pkey = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (16406), 0),
					DG_User_Status = new bool?(base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30005), false)),
					DG_User_PhoneNo = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30026), string.Empty),
					UserName = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (25889), string.Empty),
					StatusName = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30047), string.Empty),
					DG_User_Email = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30064), string.Empty),
					DG_Store_Name = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30085), string.Empty),
					CountryCode = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30106), string.Empty),
					StoreCode = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30123), string.Empty),
					DG_Substore_ID = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30136), 0)
				};
				list.Add(item);
			}
			return list;
		}

		public List<UserInfo> GetPhotoGrapherList()
		{
			IDataReader dataReader=null;
			List<UserInfo> result;
			while (true)
			{
				if (!false)
				{
					//dataReader = base.ExecuteReader(#1j.#3e);
				}
				while (!false)
				{
					List<UserInfo> expr_3A = this.UsersInfodd(dataReader);
					if (!false)
					{
						result = expr_3A;
					}
					if (7 == 0)
					{
						break;
					}
					if (8 != 0)
					{
						goto Block_3;
					}
				}
			}
			Block_3:
			dataReader.Close();
			return result;
		}

		private List<UserInfo> UsersInfodd(IDataReader IDataReader)
		{
			List<UserInfo> list = new List<UserInfo>();
			while (IDataReader.Read())
			{
				UserInfo item = new UserInfo
				{
					UserId = base.GetFieldValue(IDataReader, UsersDao.getUsersDao(703), 0),
					UserName = base.GetFieldValue(IDataReader, UsersDao.getUsersDao(636), string.Empty),
					Role_ID = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (22205), 0),
					Photographer = base.GetFieldValue(IDataReader, UsersDao.getUsersDao(22230), string.Empty)
				};
				list.Add(item);
			}
			return list;
		}

		public List<UsersInfo> GetUserByUserId(int Userid)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(UsersDao.getUsersDao (29674), Userid);
			}
			IDataReader dataReader=null;
			List<UsersInfo> result;
			if (!false)
			{
				//dataReader = base.ExecuteReader(#1j.#4e);
				if (3 != 0)
				{
					result = this.UsersInfo8c(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		public bool DeleteUsersbyId(int userID)
		{
			base.DBParameters.Clear();
			base.AddParameter(UsersDao.getUsersDao (23834), userID);
			//base.ExecuteNonQuery(#1j.#Le);
			return true;
		}

		public List<UsersInfo> SearchUserDetails(string FName, string LName, int StoreId, string Status, int RoleId, string MobileNumber, string EmailId, int locationId, string UserName)
		{
			bool? nullBoolValue = null;
			if (Status == UsersDao.getUsersDao(30217))
			{
				nullBoolValue = new bool?(true);
			}
			else if (Status == UsersDao.getUsersDao (30222))
			{
				nullBoolValue = new bool?(false);
			}
			base.DBParameters.Clear();
			base.AddParameter(UsersDao.getUsersDao (30227), base.SetNullStringValue(FName));
			base.AddParameter(UsersDao.getUsersDao (30248), base.SetNullStringValue(LName));
			base.AddParameter(UsersDao.getUsersDao (24831), base.SetNullIntegerValue(new int?(StoreId)));
			base.AddParameter(UsersDao.getUsersDao (30269), base.SetNullBoolValue(nullBoolValue));
			base.AddParameter(UsersDao.getUsersDao (26754), base.SetNullIntegerValue(new int?(RoleId)));
			base.AddParameter(UsersDao.getUsersDao (30294), base.SetNullStringValue(MobileNumber));
			base.AddParameter(UsersDao.getUsersDao (15139), base.SetNullStringValue(EmailId));
			base.AddParameter(UsersDao.getUsersDao (3754), base.SetNullIntegerValue(new int?(locationId)));
			base.AddParameter(UsersDao.getUsersDao (25822), base.SetNullStringValue(UserName));
			IDataReader dataReader =null; //base.ExecuteReader(#1j.#Je);
			List<UsersInfo> result = this.UsersInfoed(dataReader);
			dataReader.Close();
			return result;
		}

		private List<UsersInfo> UsersInfoed(IDataReader IDataReader)
		{
			List<UsersInfo> list = new List<UsersInfo>();
			while (true)
			{
				if (false)
				{
					goto IL_1F2;
				}
				if (!IDataReader.Read())
				{
					break;
				}
				UsersInfo usersInfo = new UsersInfo();
				usersInfo.DG_User_Role = base.GetFieldValue(IDataReader, UsersDao.getUsersDao(26817), string.Empty);
				usersInfo.DG_User_First_Name = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (653), string.Empty);
				usersInfo.DG_User_Last_Name = base.GetFieldValue(IDataReader, UsersDao.getUsersDao(678), string.Empty);
				usersInfo.DG_User_Password = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (29980), string.Empty);
				usersInfo.DG_Location_Name = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (16381), string.Empty);
				usersInfo.DG_Store_ID = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (16485), 0);
				usersInfo.DG_Location_pkey = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (16406), 0);
				usersInfo.DG_User_Status = new bool?(base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30005), false));
				if (!false)
				{
					usersInfo.DG_User_PhoneNo = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30026), string.Empty);
					usersInfo.StatusName = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30047), string.Empty);
					usersInfo.DG_User_Email = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30064), string.Empty);
					usersInfo.DG_Store_Name = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30085), string.Empty);
					usersInfo.CountryCode = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30106), string.Empty);
					usersInfo.StoreCode = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30123), string.Empty);
					goto IL_1F2;
				}
				IL_20F:
				usersInfo.DG_User_pkey = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (703), 0);
				usersInfo.DG_User_Name = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (636), string.Empty);
				usersInfo.DG_User_Roles_Id = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (22205), 0);
				usersInfo.UserName = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (25889), string.Empty);
				UsersInfo item = usersInfo;
				list.Add(item);
				continue;
				IL_1F2:
				usersInfo.DG_Substore_ID = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (30136), 0);
				goto IL_20F;
			}
			return list;
		}

		public List<PermissionInfo> SelectPermission(int PermissionId, string PermissionName)
		{
			base.DBParameters.Clear();
			base.AddParameter(UsersDao.getUsersDao (27000), base.SetNullIntegerValue(new int?(PermissionId)));
			IDataReader dataReader=null;
			if (2 != 0)
			{
				base.AddParameter(UsersDao.getUsersDao (27025), base.SetNullStringValue(PermissionName));
				//dataReader = base.ExecuteReader(#1j.#Eg);
			}
			List<PermissionInfo> result = this.PermissionInfoSc(dataReader);
			dataReader.Close();
			return result;
		}

		private List<PermissionInfo> PermissionInfoSc(IDataReader IDataReader)
		{
			List<PermissionInfo> list = new List<PermissionInfo>();
			while (IDataReader.Read())
			{
				PermissionInfo item = new PermissionInfo
				{
					DG_Permission_pkey = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (27054), 0),
					DG_Permission_Name = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (27079), string.Empty),
					SyncCode = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (2002), string.Empty),
					IsSynced = base.GetFieldValue(IDataReader, UsersDao.getUsersDao (2015), false)
				};
				list.Add(item);
			}
			return list;
		}

		static UsersDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(UsersDao));
		}
	}
}
