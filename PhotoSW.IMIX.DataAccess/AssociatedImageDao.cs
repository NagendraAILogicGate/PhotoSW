//using #2j;
//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
   // public delegate string GetString  ( int i );
    public class AssociatedImageDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;

        internal static GetString getStr;
        public AssociatedImageDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public AssociatedImageDao()
		{
		}

		public List<iMixImageAssociationInfo> SelectAssociatedImage(string CardUniqueIdentifier)
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
				base.AddParameter(AssociatedImageDao.getStr(778), CardUniqueIdentifier);
				if (8 != 0)
				{
					if (!false)
					{
                        //dataReader = base.ExecuteReader(#1j.#zh);
                        dataReader = base.ExecuteReader("");
						result = this.iMixImageAssociation(dataReader);
						break;
					}
					break;
				}
			}
			dataReader.Close();
			return result;
		}

		private List<iMixImageAssociationInfo> iMixImageAssociation(IDataReader dataReader)
		{
			List<iMixImageAssociationInfo> list = new List<iMixImageAssociationInfo>();
			if (2 != 0)
			{
				goto IL_D4;
			}
			IL_89:
			iMixImageAssociationInfo iMixImageAssociationInfo;
			iMixImageAssociationInfo.CardUniqueIdentifier = base.GetFieldValue(dataReader, AssociatedImageDao.getStr(882), string.Empty);
			IL_AA:
			iMixImageAssociationInfo.MappedIdentifier = base.GetFieldValue(dataReader, AssociatedImageDao.getStr(911), string.Empty);
			iMixImageAssociationInfo item = iMixImageAssociationInfo;
			list.Add(item);
			IL_D4:
			if (!dataReader.Read())
			{
				return list;
			}
			iMixImageAssociationInfo = new iMixImageAssociationInfo();
			if (false)
			{
				goto IL_AA;
			}
			iMixImageAssociationInfo.IMIXImageAssociationId = (long)base.GetFieldValue(dataReader, AssociatedImageDao.getStr(815), 0);
			iMixImageAssociationInfo.IMIXCardTypeId = base.GetFieldValue(dataReader, AssociatedImageDao.getStr(848), 0);
			if (7 != 0)
			{
				iMixImageAssociationInfo.PhotoId = base.GetFieldValue(dataReader, AssociatedImageDao.getStr(869), 0);
				goto IL_89;
			}
			goto IL_AA;
		}

		public string AssociateImage(int OverWriteStatus, bool IsAnonymousQrCodeEnabled, string UniqueCode, string PhotoIds)
		{
			string empty = string.Empty;
			base.DBParameters.Clear();
			base.AddParameter(AssociatedImageDao.getStr(936), OverWriteStatus);
			base.AddParameter(AssociatedImageDao.getStr(961), IsAnonymousQrCodeEnabled);
			base.AddParameter(AssociatedImageDao.getStr(998), UniqueCode);
			base.AddParameter(AssociatedImageDao.getStr(1015), PhotoIds);
			base.AddParameter(AssociatedImageDao.getStr(1028), empty, ParameterDirection.Output);
            //	base.ExecuteNonQuery(#1j.#kj);
            base.ExecuteNonQuery("");
			object outParameterValue = base.GetOutParameterValue(AssociatedImageDao.getStr(1028));
			return outParameterValue.ToString();
		}

		public void AssociateMobileImage(string UniqueCode, int PhotoId)
		{
			string arg_05_0 = string.Empty;
			base.DBParameters.Clear();
			base.AddParameter(AssociatedImageDao.getStr(998), UniqueCode);
			base.AddParameter(AssociatedImageDao.getStr(1041), PhotoId);
            //base.ExecuteNonQuery(#1j.#lj);
            base.ExecuteNonQuery("");
		}

		public void AssociateVideos(int PhotoId, int VideoId)
		{
			string arg_05_0 = string.Empty;
			List<SqlParameter> expr_4E = base.DBParameters;
			if (!false)
			{
				expr_4E.Clear();
			}
			base.AddParameter(AssociatedImageDao.getStr(1041), PhotoId);
			base.AddParameter(AssociatedImageDao.getStr(1054), VideoId);
            //base.ExecuteNonQuery(#1j.#Aj);
            base.ExecuteNonQuery("");
		}

		static AssociatedImageDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
		//	SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(AssociatedImageDao));
		}
	}
}
