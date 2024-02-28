using PhotoSW.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;

namespace PhotoSW.IMIX.DataAccess
{
	public class UserAccess : BaseDataAccess
	{
		//[NonSerialized]
		//internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly .Delegates.GetString  getUserAccess;

		public UserAccess(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public UserAccess()
		{
		}

		public List<UserInfo> GetPhotoGraphersList()
		{
			base.DBParameters.Clear();
			IDataReader dataReader = base.ExecuteReader(UserAccess.getUserAccess(57960));
			List<UserInfo> result;
			do
			{
				result = this.UserInfoNk(dataReader);
			}
			while (false);
			dataReader.Close();
			return result;
		}

		private List<UserInfo> UserInfoNk(IDataReader IDataReader)
		{
			List<UserInfo> list = new List<UserInfo>();
			while (true)
			{
				while (IDataReader.Read())
				{
					UserInfo userInfo = new UserInfo();
					if (7 != 0)
					{
						userInfo.UserId = base.GetFieldValue(IDataReader, UserAccess.getUserAccess (1141), 0);
                        userInfo.Photographer = base.GetFieldValue(IDataReader, UserAccess.getUserAccess(57981), string.Empty);
						list.Add(userInfo);
					}
				}
				break;
			}
			return list;
		}

		static UserAccess()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(UserAccess));
		}
	}
}
