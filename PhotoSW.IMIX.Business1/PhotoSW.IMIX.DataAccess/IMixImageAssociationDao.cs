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
	public class IMixImageAssociationDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static GetString getMixImage;
        public IMixImageAssociationDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public IMixImageAssociationDao()
		{
		}

		public List<iMixImageAssociationInfo> Get(string PhotoId)
		{
			IDataReader dataReader;
			List<iMixImageAssociationInfo> result;
			while (-1 != 0)
			{
				base.DBParameters.Clear();
				if (false)
				{
					break;
				}
				base.AddParameter(IMixImageAssociationDao.getMixImage(1058), PhotoId);
				if (8 != 0)
				{
					if (!false)
					{
						dataReader = base.ExecuteReader("");
						result = this.iMixImageAssociationInfo1(dataReader);
						break;
					}
					break;
				}
			}
			dataReader.Close();
			return result;
		}

		private List<iMixImageAssociationInfo> iMixImageAssociationInfo1 ( IDataReader dataReader)
		{
			List<iMixImageAssociationInfo> list;
			while (true)
			{
				if (!false)
				{
					List<iMixImageAssociationInfo> expr_4C = new List<iMixImageAssociationInfo>();
					if (!false)
					{
						list = expr_4C;
					}
				}
				while (true)
				{
					if (dataReader.Read() && -1 != 0)
					{
						iMixImageAssociationInfo item = new iMixImageAssociationInfo
						{
							CardUniqueIdentifier = base.GetFieldValue(dataReader, IMixImageAssociationDao.getMixImage(899), string.Empty)
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

		public List<string> GetQrOrBarCodeByPhotoID(string PhotoId)
		{
			IDataReader dataReader;
			List<string> result;
			while (-1 != 0)
			{
				base.DBParameters.Clear();
				if (false)
				{
					break;
				}
				base.AddParameter(IMixImageAssociationDao.getMixImage(1058), PhotoId);
				if (8 != 0)
				{
					if (!false)
					{
						dataReader = base.ExecuteReader("");
						result = this.stringList(dataReader);
						break;
					}
					break;
				}
			}
			dataReader.Close();
			return result;
		}

		private List<string> stringList(IDataReader dataReader)
		{
			List<string> list;
			if (true)
			{
				list = new List<string>();
			}
			while (dataReader.Read())
			{
				string fieldValue = base.GetFieldValue(dataReader, IMixImageAssociationDao.getMixImage(899), string.Empty);
				list.Add(fieldValue);
			}
			return list;
		}

		public List<iMixImageAssociationInfo> GetUniqueCodeExists(bool IsAnonymousQrCodeEnabled, string QRCode)
		{
			if (7 != 0 && !false)
			{
				base.DBParameters.Clear();
				string expr_83 = IMixImageAssociationDao.getMixImage(16067);
				object expr_22 = IsAnonymousQrCodeEnabled;
				if (2 != 0)
				{
					base.AddParameter(expr_83, expr_22);
				}
				base.AddParameter(IMixImageAssociationDao.getMixImage(7289), QRCode);
			}
			List<iMixImageAssociationInfo> result;
			if (!false)
			{
				IDataReader dataReader;
				if (3 != 0)
				{
					dataReader = base.ExecuteReader("");
				}
				if (3 != 0)
				{
					result = this.iMixImageAssociationInfo2(dataReader);
				}
				dataReader.Close();
			}
			return result;
		}

		private List<iMixImageAssociationInfo> iMixImageAssociationInfo2 ( IDataReader dataReader)
		{
			List<iMixImageAssociationInfo> list;
			while (true)
			{
				if (!false)
				{
					List<iMixImageAssociationInfo> expr_48 = new List<iMixImageAssociationInfo>();
					if (!false)
					{
						list = expr_48;
					}
				}
				while (true)
				{
					if (dataReader.Read() && -1 != 0)
					{
						iMixImageAssociationInfo item = new iMixImageAssociationInfo
						{
							IMIXCardTypeId = base.GetFieldValue(dataReader, IMixImageAssociationDao.getMixImage(865), 0)
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

		static IMixImageAssociationDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(IMixImageAssociationDao));
		}
	}
}
