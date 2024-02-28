//using #2j;
//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class CardTypeDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static GetString getCardType;
        public CardTypeDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public CardTypeDao()
		{
		}

		public ImageCardTypeInfo GetValidCodeType(int CardTypeId, string QRCode)
		{
			if (7 != 0 && !false)
			{
				base.DBParameters.Clear();
				string expr_83 = CardTypeDao.getCardType(7254);
				object expr_22 = CardTypeId;
				if (2 != 0)
				{
					base.AddParameter(expr_83, expr_22);
				}
				base.AddParameter(CardTypeDao.getCardType(7279), QRCode);
			}
			ImageCardTypeInfo result;
			if (!false)
			{
				IDataReader dataReader;
				if (3 != 0)
				{
					dataReader = base.ExecuteReader("");
				}
				if (3 != 0)
				{
					result = this.imageCardTypeInfo2(dataReader);
				}
				dataReader.Close();
			}
			return result;
		}

		public ImageCardTypeInfo IsValidPrepaidCodeType(int CardTypeId, string QRCode)
		{
			if (7 != 0 && !false)
			{
				base.DBParameters.Clear();
				string expr_83 = CardTypeDao.getCardType(7254);
				object expr_22 = CardTypeId;
				if (2 != 0)
				{
					base.AddParameter(expr_83, expr_22);
				}
				base.AddParameter(CardTypeDao.getCardType(7279), QRCode);
			}
			ImageCardTypeInfo result;
			if (!false)
			{
				IDataReader dataReader;
				if (3 != 0)
				{
					dataReader = base.ExecuteReader("");
				}
				if (3 != 0)
				{
					result = this.imageCardTypeInfo2(dataReader);
				}
				dataReader.Close();
			}
			return result;
		}

		public ImageCardTypeInfo GetCardImageLimitById(string Code)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(CardTypeDao.getCardType(7296), Code);
			}
			IDataReader dataReader = base.ExecuteReader("");
			List<ImageCardTypeInfo> source = this.imageCardTypeInfo1(dataReader);
			dataReader.Close();
			return source.FirstOrDefault<ImageCardTypeInfo>();
		}

		private List<ImageCardTypeInfo> imageCardTypeInfo1 ( IDataReader dataReader)
		{
			List<ImageCardTypeInfo> list = new List<ImageCardTypeInfo>();
			IL_04:
			while (!false)
			{
				while (dataReader.Read())
				{
					if (4 == 0)
					{
						goto IL_04;
					}
					ImageCardTypeInfo item = new ImageCardTypeInfo
					{
						MaxImages = new int?(base.GetFieldValue(dataReader, CardTypeDao.getCardType(7313), 0))
					};
					if (4 == 0)
					{
						break;
					}
					list.Add(item);
				}
				break;
			}
			return list;
		}

		private ImageCardTypeInfo imageCardTypeInfo2 ( IDataReader dataReader)
		{
			ImageCardTypeInfo result;
			while (true)
			{
				IL_00:
				if (-1 != 0)
				{
					result = null;
				}
				while (dataReader.Read())
				{
					ImageCardTypeInfo imageCardTypeInfo = new ImageCardTypeInfo();
					imageCardTypeInfo.IMIXImageCardTypeId = base.GetFieldValue(dataReader, CardTypeDao.getCardType(7326), 0);
					if (false || false)
					{
						break;
					}
					if (-1 == 0)
					{
						goto IL_00;
					}
					result = imageCardTypeInfo;
				}
				break;
			}
			return result;
		}

		public ImageCardTypeInfo GetImageIdentificationType(int ImageIdentificationType)
		{
			base.DBParameters.Clear();
			base.AddParameter(CardTypeDao.getCardType(7355), ImageIdentificationType);
			IDataReader dataReader;
			if (true && !false)
			{
				dataReader = base.ExecuteReader("");
			}
			List<ImageCardTypeInfo> source;
			do
			{
				source = this.imageCardTypeInfo3(dataReader);
			}
			while (false);
			dataReader.Close();
			return source.FirstOrDefault<ImageCardTypeInfo>();
		}

		private List<ImageCardTypeInfo> imageCardTypeInfo3(IDataReader dataReader)
		{
			List<ImageCardTypeInfo> list = new List<ImageCardTypeInfo>();
			while (dataReader.Read())
			{
				ImageCardTypeInfo item = new ImageCardTypeInfo
				{
					IMIXImageCardTypeId = base.GetFieldValue(dataReader, CardTypeDao.getCardType(7326), 0),
					Name = base.GetFieldValue(dataReader, CardTypeDao.getCardType(516), string.Empty),
					CardIdentificationDigit = base.GetFieldValue(dataReader, CardTypeDao.getCardType(7396), string.Empty),
					ImageIdentificationType = base.GetFieldValue(dataReader, CardTypeDao.getCardType(7429), 0),
					IsActive = new bool?(base.GetFieldValue(dataReader, CardTypeDao.getCardType(3074), false)),
					MaxImages = new int?(base.GetFieldValue(dataReader, CardTypeDao.getCardType(7313), 0)),
					Description = base.GetFieldValue(dataReader, CardTypeDao.getCardType(3100), string.Empty),
					CreatedOn = new DateTime?(base.GetFieldValue(dataReader, CardTypeDao.getCardType(3117), DateTime.Now)),
					IsPrepaid = new bool?(base.GetFieldValue(dataReader, CardTypeDao.getCardType(7462), false)),
					PackageId = new int?(base.GetFieldValue(dataReader, CardTypeDao.getCardType(7475), 0))
				};
				list.Add(item);
			}
			return list;
		}

		public long InsertImageAssociationInfo(int PhotoId, string Format, string Code, bool IsAnonymousCodeActive)
		{
			long num = 0L;
			base.DBParameters.Clear();
			base.AddParameter(CardTypeDao.getCardType(7488), PhotoId);
			if (5 != 0)
			{
				base.AddParameter(CardTypeDao.getCardType(7509), IsAnonymousCodeActive);
				if (-1 == 0)
				{
					goto IL_94;
				}
				base.AddParameter(CardTypeDao.getCardType(7546), num, ParameterDirection.Output);
			}
			long result;
			if (false)
			{
				return result;
			}
			base.AddParameter(CardTypeDao.getCardType(7296), Code);
			IL_94:
			base.ExecuteNonQuery("");
			result = (long)base.GetOutParameterValue(CardTypeDao.getCardType(7546));
			return result;
		}

		public List<iMixImageCardTypeInfo> SelectCardTypeList()
		{
			IDataReader dataReader;
			List<iMixImageCardTypeInfo> result;
			while (true)
			{
				if (!false)
				{
					dataReader = base.ExecuteReader("");
				}
				while (!false)
				{
					List<iMixImageCardTypeInfo> expr_3A = this.iMixImageCardTypeInfo1(dataReader);
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

		private List<iMixImageCardTypeInfo> iMixImageCardTypeInfo1 ( IDataReader dataReader)
		{
			List<iMixImageCardTypeInfo> list = new List<iMixImageCardTypeInfo>();
			while (true)
			{
				if (4 == 0)
				{
					goto IL_6B;
				}
				IL_72:
				iMixImageCardTypeInfo iMixImageCardTypeInfo;
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
					iMixImageCardTypeInfo = new iMixImageCardTypeInfo();
					iMixImageCardTypeInfo.IMIXImageCardTypeId = base.GetFieldValue(dataReader, CardTypeDao.getCardType(7326), 0);
				}
				if (!false)
				{
					iMixImageCardTypeInfo.Name = base.GetFieldValue(dataReader, CardTypeDao.getCardType(516), string.Empty);
				}
				iMixImageCardTypeInfo item = iMixImageCardTypeInfo;
				IL_6B:
				list.Add(item);
				goto IL_72;
			}
			return list;
		}

		public List<ImageCardTypeInfo> GetCardTypeList()
		{
			IDataReader dataReader;
			List<ImageCardTypeInfo> result;
			while (true)
			{
				if (!false)
				{
					dataReader = base.ExecuteReader("");
				}
				while (!false)
				{
					List<ImageCardTypeInfo> expr_3A = this.imageCardTypeInfo4(dataReader);
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

		private List<ImageCardTypeInfo> imageCardTypeInfo4 ( IDataReader dataReader)
		{
			List<ImageCardTypeInfo> list = new List<ImageCardTypeInfo>();
			while (dataReader.Read())
			{
				ImageCardTypeInfo item = new ImageCardTypeInfo
				{
					IMIXImageCardTypeId = base.GetFieldValue(dataReader, CardTypeDao.getCardType(7326), 0),
					Name = base.GetFieldValue(dataReader, CardTypeDao.getCardType(516), string.Empty),
					Status = base.GetFieldValue(dataReader, CardTypeDao.getCardType(2483), string.Empty),
					ImageIdentificationTypeName = base.GetFieldValue(dataReader, CardTypeDao.getCardType(7587), string.Empty),
					CardIdentificationDigit = base.GetFieldValue(dataReader, CardTypeDao.getCardType(7396), string.Empty),
					MaxImages = new int?(base.GetFieldValue(dataReader, CardTypeDao.getCardType(7313), 0))
				};
				list.Add(item);
			}
			return list;
		}

		public List<ImageCardTypeInfo> GetCardTypeDetails()
		{
			IDataReader dataReader;
			List<ImageCardTypeInfo> result;
			while (true)
			{
				if (!false)
				{
					dataReader = base.ExecuteReader("");
				}
				while (!false)
				{
					List<ImageCardTypeInfo> expr_3A = this.imageCardTypeInfo5(dataReader);
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

		private List<ImageCardTypeInfo> imageCardTypeInfo5 ( IDataReader dataReader)
		{
			List<ImageCardTypeInfo> list = new List<ImageCardTypeInfo>();
			while (dataReader.Read())
			{
				ImageCardTypeInfo item = new ImageCardTypeInfo
				{
					IMIXImageCardTypeId = base.GetFieldValue(dataReader, CardTypeDao.getCardType(7326), 0),
					Name = base.GetFieldValue(dataReader, CardTypeDao.getCardType(516), string.Empty),
					Status = base.GetFieldValue(dataReader, CardTypeDao.getCardType(2483), string.Empty),
					ImageIdentificationType = base.GetFieldValue(dataReader, CardTypeDao.getCardType(7429), 0),
					CardIdentificationDigit = base.GetFieldValue(dataReader, CardTypeDao.getCardType(7396), string.Empty),
					MaxImages = new int?(base.GetFieldValue(dataReader, CardTypeDao.getCardType(7313), 0))
				};
				list.Add(item);
			}
			return list;
		}

		public iMixImageCardTypeInfo GetCardTypeListDetails(int ID)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(CardTypeDao.getCardType(7624), ID);
			}
			IDataReader dataReader;
			iMixImageCardTypeInfo result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				if (3 != 0)
				{
					result = this.iMixImageCardTypeInfo2(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private iMixImageCardTypeInfo iMixImageCardTypeInfo2 ( IDataReader dataReader)
		{
			iMixImageCardTypeInfo iMixImageCardTypeInfo = new iMixImageCardTypeInfo();
			while (dataReader.Read())
			{
				iMixImageCardTypeInfo.IMIXImageCardTypeId = base.GetFieldValue(dataReader, CardTypeDao.getCardType(7326), 0);
				iMixImageCardTypeInfo.Name = base.GetFieldValue(dataReader, CardTypeDao.getCardType(516), string.Empty);
				iMixImageCardTypeInfo.IsActive = base.GetFieldValue(dataReader, CardTypeDao.getCardType(3074), true);
				iMixImageCardTypeInfo.ImageIdentificationType = base.GetFieldValue(dataReader, CardTypeDao.getCardType(7429), 0);
				iMixImageCardTypeInfo.CardIdentificationDigit = base.GetFieldValue(dataReader, CardTypeDao.getCardType(7396), string.Empty);
				iMixImageCardTypeInfo.MaxImages = base.GetFieldValue(dataReader, CardTypeDao.getCardType(7313), 0);
				iMixImageCardTypeInfo.Description = base.GetFieldValue(dataReader, CardTypeDao.getCardType(3100), string.Empty);
				iMixImageCardTypeInfo.CreatedOn = base.GetFieldValue(dataReader, CardTypeDao.getCardType(3117), DateTime.Now);
				iMixImageCardTypeInfo.IsPrepaid = base.GetFieldValue(dataReader, CardTypeDao.getCardType(7462), false);
				iMixImageCardTypeInfo.PackageId = base.GetFieldValue(dataReader, CardTypeDao.getCardType(7475), 0);
				iMixImageCardTypeInfo.IsWaterMark = new bool?(base.GetFieldValue(dataReader, CardTypeDao.getCardType(7653), false));
			}
			return iMixImageCardTypeInfo;
		}

		public bool UPD_iMixImageCardType(int IMIXImageCardTypeId)
		{
			base.DBParameters.Clear();
			base.AddParameter(CardTypeDao.getCardType(7670), IMIXImageCardTypeId);
			base.ExecuteNonQuery("");
			return true;
		}

		public List<ImageCardTypeInfo> GetCardSeries(string CardIdentificationDigit)
		{
			IDataReader dataReader;
			List<ImageCardTypeInfo> result;
			while (-1 != 0)
			{
				base.DBParameters.Clear();
				if (false)
				{
					break;
				}
				base.AddParameter(CardTypeDao.getCardType(7707), CardIdentificationDigit);
				if (8 != 0)
				{
					if (!false)
					{
						dataReader = base.ExecuteReader("");
						result = this.imageCardTypeInfo6(dataReader);
						break;
					}
					break;
				}
			}
			dataReader.Close();
			return result;
		}

		private List<ImageCardTypeInfo> imageCardTypeInfo6 ( IDataReader dataReader)
		{
			List<ImageCardTypeInfo> list = new List<ImageCardTypeInfo>();
			while (dataReader.Read())
			{
				ImageCardTypeInfo item = new ImageCardTypeInfo
				{
					IMIXImageCardTypeId = base.GetFieldValue(dataReader, CardTypeDao.getCardType(7326), 0),
					Name = base.GetFieldValue(dataReader, CardTypeDao.getCardType(516), string.Empty),
					CardIdentificationDigit = base.GetFieldValue(dataReader, CardTypeDao.getCardType(7396), string.Empty),
					ImageIdentificationType = base.GetFieldValue(dataReader, CardTypeDao.getCardType(7429), 0),
					IsActive = new bool?(base.GetFieldValue(dataReader, CardTypeDao.getCardType(3074), false)),
					MaxImages = new int?(base.GetFieldValue(dataReader, CardTypeDao.getCardType(7313), 0)),
					Description = base.GetFieldValue(dataReader, CardTypeDao.getCardType(3100), string.Empty),
					CreatedOn = new DateTime?(base.GetFieldValue(dataReader, CardTypeDao.getCardType(3117), DateTime.Now)),
					IsPrepaid = new bool?(base.GetFieldValue(dataReader, CardTypeDao.getCardType(7462), false)),
					PackageId = new int?(base.GetFieldValue(dataReader, CardTypeDao.getCardType(7475), 0))
				};
				list.Add(item);
			}
			return list;
		}

		public bool INS_iMixImageCardType(int cardId, string strCardTypeName, string strCardSeries, int strcodeType, bool? status, int maxImage, string strDescription, bool IsPrepaid, int PackageId, bool IsWaterMark)
		{
			base.DBParameters.Clear();
			base.AddParameter(CardTypeDao.getCardType(7748), cardId);
			base.AddParameter(CardTypeDao.getCardType(7765), strCardTypeName);
			base.AddParameter(CardTypeDao.getCardType(7790), strCardSeries);
			do
			{
				base.AddParameter(CardTypeDao.getCardType(7815), strcodeType);
				base.AddParameter(CardTypeDao.getCardType(2343), status);
				base.AddParameter(CardTypeDao.getCardType(7836), maxImage);
				base.AddParameter(CardTypeDao.getCardType(7857), strDescription);
				base.AddParameter(CardTypeDao.getCardType(7882), IsPrepaid);
				base.AddParameter(CardTypeDao.getCardType(7903), PackageId);
				base.AddParameter(CardTypeDao.getCardType(7924), IsWaterMark);
				base.AddParameter(CardTypeDao.getCardType(7949), cardId, ParameterDirection.InputOutput);
				base.ExecuteNonQuery("");
				int arg_163_0 = (int)base.GetOutParameterValue(CardTypeDao.getCardType(7949));
			}
			while (false);
			return true;
		}

		static CardTypeDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(CardTypeDao));
		}
	}
}
