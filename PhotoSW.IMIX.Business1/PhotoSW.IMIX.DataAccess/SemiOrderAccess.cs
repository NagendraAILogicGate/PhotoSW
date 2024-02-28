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
	public class SemiOrderAccess : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getSemiOrderAccess;
        public SemiOrderAccess (BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public SemiOrderAccess()
		{
		}

		public List<SemiOrderSettingsInfo> GetSemiOrderSettings()
		{
			base.DBParameters.Clear();
			IDataReader dataReader = base.ExecuteReader(SemiOrderAccess.getSemiOrderAccess(56114));
			List<SemiOrderSettingsInfo> result;
			do
			{
				result = this.SemiOrderSettingsInfozk(dataReader);
			}
			while (false);
			dataReader.Close();
			return result;
		}

		public List<SpecProfileProductMappingInfo> GetSemiOrderProfileProductMapping(int ProfileId)
		{
			List<SpecProfileProductMappingInfo> result;
			while (true)
			{
				if (false)
				{
					goto IL_41;
				}
				List<SqlParameter> expr_55 = base.DBParameters;
				if (!false)
				{
					expr_55.Clear();
				}
				if (-1 != 0)
				{
					base.AddParameter(SemiOrderAccess.getSemiOrderAccess(56143), ProfileId);
					goto IL_25;
				}
				IL_4A:
				if (!true)
				{
					continue;
				}
				if (!false)
				{
					break;
				}
				IL_41:
				IDataReader dataReader;
				if (-1 != 0)
				{
					dataReader.Close();
					goto IL_4A;
				}
				IL_25:
				dataReader = base.ExecuteReader(SemiOrderAccess.getSemiOrderAccess(56164));
				result = this.SpecProfileProductMappingInfoAk(dataReader);
				//goto IL_41;
			}
			return result;
		}

		private List<SemiOrderSettingsInfo> SemiOrderSettingsInfozk ( IDataReader IDataReader )
		{
			List<SemiOrderSettingsInfo> list = new List<SemiOrderSettingsInfo>();
			while (IDataReader.Read())
			{
				SemiOrderSettingsInfo semiOrderSettingsInfo = new SemiOrderSettingsInfo();
				semiOrderSettingsInfo.Id = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(31324), 0);
				semiOrderSettingsInfo.IsBrightActive = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(56209), false);
				semiOrderSettingsInfo.BrightValue = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(56230), 0.0);
				semiOrderSettingsInfo.IsContrastActive = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(56247), false);
				semiOrderSettingsInfo.ContrastValue = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(56272), 0.0);
				semiOrderSettingsInfo.BorderName = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(27761), string.Empty);
				semiOrderSettingsInfo.IsBorderActive = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(56293), false);
				semiOrderSettingsInfo.ProductTypeId = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(56314), string.Empty);
				semiOrderSettingsInfo.VerticalBorderName = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(56335), string.Empty);
				semiOrderSettingsInfo.IsGreenScreenActive = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(56360), false);
				semiOrderSettingsInfo.BackgroundName = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(27727), string.Empty);
				do
				{
					semiOrderSettingsInfo.IsChromaActive = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(56389), false);
				}
				while (4 == 0);
				semiOrderSettingsInfo.GraphicsLayer = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(56410), string.Empty);
				semiOrderSettingsInfo.ZoomInfo = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(56431), string.Empty);
				semiOrderSettingsInfo.SubstoreId = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(10886), 0);
				semiOrderSettingsInfo.IsPrintActive = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(56444), false);
				semiOrderSettingsInfo.IsCropActive = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(56465), false);
				semiOrderSettingsInfo.VerticalCropValues = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(28649), string.Empty);
				semiOrderSettingsInfo.HorizontalCropValues = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(28674), string.Empty);
				semiOrderSettingsInfo.LocationId = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(12829), 0);
				semiOrderSettingsInfo.ChromaColor = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(28724), string.Empty);
				semiOrderSettingsInfo.ColorCode = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(28741), string.Empty);
				semiOrderSettingsInfo.ClrTolerance = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(28754), string.Empty);
				list.Add(semiOrderSettingsInfo);
			}
			return list;
		}

		private List<SpecProfileProductMappingInfo> SpecProfileProductMappingInfoAk ( IDataReader IDataReader)
		{
			List<SpecProfileProductMappingInfo> list = new List<SpecProfileProductMappingInfo>();
			while (true)
			{
				while (IDataReader.Read())
				{
					SpecProfileProductMappingInfo specProfileProductMappingInfo = new SpecProfileProductMappingInfo();
					if (7 != 0)
					{
						specProfileProductMappingInfo.SemiOrderProfileId = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(21669), 0);
						specProfileProductMappingInfo.ProductTypeId = base.GetFieldValue(IDataReader, SemiOrderAccess.getSemiOrderAccess(56314), 0);
						list.Add(specProfileProductMappingInfo);
					}
				}
				break;
			}
			return list;
		}

		static SemiOrderAccess()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(SemiOrderAccess));
		}
	}
}
