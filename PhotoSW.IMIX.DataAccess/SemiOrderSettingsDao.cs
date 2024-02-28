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
	public class SemiOrderSettingsDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getSemiOrderSettings;
        public SemiOrderSettingsDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public SemiOrderSettingsDao()
		{
		}

		public List<SemiOrderSettings> GetSemiOrderSettings()
		{
			base.DBParameters.Clear();
			base.OpenConnection();
			List<SemiOrderSettings> result;
			do
			{
				base.AddParameter(SemiOrderSettingsDao.getSemiOrderSettings(2341), base.SetNullIntegerValue(null));
				base.AddParameter(SemiOrderSettingsDao.getSemiOrderSettings(3749), base.SetNullIntegerValue(null));
				IDataReader dataReader = base.ExecuteReader("");
				result = this.SemiOrderSettingsUc(dataReader);
				dataReader.Close();
			}
			while (3 == 0);
			return result;
		}

		public List<SemiOrderSettings> GetSemiOrderSettings(int? subStoreId, int? locationId)
		{
			base.DBParameters.Clear();
			base.AddParameter(SemiOrderSettingsDao.getSemiOrderSettings(2341), base.SetNullIntegerValue(subStoreId));
			base.AddParameter(SemiOrderSettingsDao.getSemiOrderSettings(3749), base.SetNullIntegerValue(locationId));
			IDataReader dataReader = base.ExecuteReader("");
			List<SemiOrderSettings> result = this.SemiOrderSettingsUc(dataReader);
			dataReader.Close();
			return result;
		}

		private List<SemiOrderSettings> SemiOrderSettingsUc ( IDataReader IDataReader )
		{
			List<SemiOrderSettings> list = new List<SemiOrderSettings>();
			while (IDataReader.Read())
			{
				SemiOrderSettings item = new SemiOrderSettings
				{
					PS_SemiOrder_Settings_Pkey = base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(27534), 0),
					PS_SemiOrder_Settings_AutoBright = new bool?(base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(27571), false)),
					PS_SemiOrder_Settings_AutoBright_Value = new double?((double)base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(27616), 0f)),
					PS_SemiOrder_Settings_AutoContrast = new bool?(base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(27669), false)),
					PS_SemiOrder_Settings_AutoContrast_Value = new double?((double)base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(27718), 0f)),
					PS_SemiOrder_Settings_ImageFrame = base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(27775), string.Empty),
					PS_SemiOrder_Settings_IsImageFrame = new bool?(base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(27820), false)),
					PS_SemiOrder_ProductTypeId = base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(27869), string.Empty),
					PS_SemiOrder_Settings_ImageFrame_Vertical = base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(27906), string.Empty),
					PS_SemiOrder_Environment = new bool?(base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(27963), false)),
					PS_SemiOrder_BG = base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(27996), string.Empty),
					PS_SemiOrder_Settings_IsImageBG = new bool?(base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(28017), false)),
					PS_SemiOrder_Graphics_layer = base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(28062), string.Empty),
					PS_SemiOrder_Image_ZoomInfo = base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(28099), string.Empty),
					PS_SubStoreId = new int?(base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(21099), 0)),
					PS_SemiOrder_IsPrintActive = new bool?(base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(28136), false)),
					PS_SemiOrder_IsCropActive = new bool?(base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(28173), false)),
					VerticalCropValues = base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(28210), string.Empty),
					HorizontalCropValues = base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(28235), string.Empty),
					PS_LocationId = new int?(base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(28264), 0)),
					ChromaColor = base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(28285), string.Empty),
					ColorCode = base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(28302), string.Empty),
					ClrTolerance = base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(28315), string.Empty),
					ProductName = base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(27254), string.Empty),
					TextLogos = base.GetFieldValue(IDataReader, SemiOrderSettingsDao.getSemiOrderSettings(28332), string.Empty)
				};
				list.Add(item);
			}
			return list;
		}

		public bool DeleteSpecSetting(int objectvalueId)
		{
			base.DBParameters.Clear();
			base.AddParameter(SemiOrderSettingsDao.getSemiOrderSettings(28361), objectvalueId);
			base.ExecuteNonQuery("");
			return true;
		}

		static SemiOrderSettingsDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(SemiOrderSettingsDao));
		}
	}
}
