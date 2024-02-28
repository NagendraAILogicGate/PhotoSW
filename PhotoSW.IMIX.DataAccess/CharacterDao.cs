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
	public class CharacterDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static GetString getCharacter;
        public CharacterDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public CharacterDao()
		{
		}

		public List<CharacterInfo> GetCharacter()
		{
			base.DBParameters.Clear();
			base.AddParameter(CharacterDao.getCharacter(1185), base.SetNullIntegerValue(new int?(1)));
			List<CharacterInfo> result;
			do
			{
				base.AddParameter(CharacterDao.getCharacter(8035), 0);
				IDataReader dataReader;
				if (!false)
				{
					base.AddParameter(CharacterDao.getCharacter(8060), 0);
					dataReader = base.ExecuteReader("");
				}
				result = this.characterInfo(dataReader);
				dataReader.Close();
			}
			while (3 == 0);
			return result;
		}

		public List<CharacterInfo> GetCharacter(CharacterInfo charinfo)
		{
			List<SqlParameter> expr_A2 = base.DBParameters;
			if (!false)
			{
				expr_A2.Clear();
			}
			if (7 != 0)
			{
				base.AddParameter(CharacterDao.getCharacter(1185), base.SetNullIntegerValue(new int?(1)));
			}
			base.AddParameter(CharacterDao.getCharacter(8035), charinfo.DG_Character_Pkey);
			List<CharacterInfo> result;
			if (!false)
			{
				base.AddParameter(CharacterDao.getCharacter(8060), charinfo.DG_Character_OperationType);
				IDataReader dataReader = base.ExecuteReader("");
				result = this.characterInfo(dataReader);
				dataReader.Close();
			}
			return result;
		}

		private List<CharacterInfo> characterInfo ( IDataReader dataReader)
		{
			List<CharacterInfo> list = new List<CharacterInfo>();
			while (dataReader.Read())
			{
				CharacterInfo item = new CharacterInfo
				{
					DG_Character_Pkey = base.GetFieldValue(dataReader, CharacterDao.getCharacter(8093), 0),
					DG_Character_Name = base.GetFieldValue(dataReader, CharacterDao.getCharacter(8118), string.Empty),
					DG_Character_IsActive = base.GetFieldValue(dataReader, CharacterDao.getCharacter(8143), 0),
					DG_Character_CreatedDate = base.GetFieldValue(dataReader, CharacterDao.getCharacter(8172), DateTime.MinValue)
				};
				list.Add(item);
			}
			return list;
		}

		public int? GetCharacterId(string PhotographerId)
		{
			int num = 0;
			base.DBParameters.Clear();
			base.AddParameter(CharacterDao.getCharacter(8205), PhotographerId);
			base.AddParameter(CharacterDao.getCharacter(8234), num, ParameterDirection.InputOutput);
			base.ExecuteNonQuery("");
			return (int?)base.GetOutParameterValue(CharacterDao.getCharacter(8234));
		}

		public bool InsertCharacter(CharacterInfo objCharInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(CharacterDao.getCharacter(8263), objCharInfo.DG_Character_Name);
			base.AddParameter(CharacterDao.getCharacter(8288), objCharInfo.DG_Character_IsActive);
			base.AddParameter(CharacterDao.getCharacter(8321), 0, ParameterDirection.InputOutput);
			base.ExecuteNonQuery("");
			return true;
		}

		static CharacterDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(CharacterDao));
		}
	}
}
