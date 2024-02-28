//using #2j;
using PhotoSW.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;

namespace PhotoSW.IMIX.DataAccess
{
	public class ServicesDao : BaseDataAccess
	{
		 internal static SmartAssembly .Delegates .GetString getServicesDao;

		public ServicesDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public ServicesDao()
		{
		}

		public List<ServicesInfo> GetServices()
		{
			base.DBParameters.Clear();
			IDataReader dataReader=null;
			if (8 != 0)
			{
				//dataReader = base.ExecuteReader(#1j.#Vh);
			}
			List<ServicesInfo> result = this.ServicesInfoVc(dataReader);
			dataReader.Close();
			return result;
		}

		private List<ServicesInfo> ServicesInfoVc(IDataReader IDataReader)
		{
			List<ServicesInfo> list = new List<ServicesInfo>();
			while (IDataReader.Read())
			{
				ServicesInfo item = new ServicesInfo
				{
					DG_Service_Id = base.GetFieldValue(IDataReader,           ServicesDao.getServicesDao(28387), 0),
					DG_Sevice_Name = base.GetFieldValue(IDataReader,          ServicesDao.getServicesDao(28408), string.Empty),
					DG_Service_Display_Name = base.GetFieldValue(IDataReader, ServicesDao.getServicesDao(28429), string.Empty),
					DG_Service_Path = base.GetFieldValue(IDataReader,         ServicesDao.getServicesDao(28462), string.Empty),
					IsInterface = new bool?(base.GetFieldValue(IDataReader,   ServicesDao.getServicesDao(28483), false))
				};
				list.Add(item);
			}
			return list;
		}

		public bool AddServices(ServicesInfo objectInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(ServicesDao.getServicesDao(28500), objectInfo.IsInterface);
			base.AddParameter(ServicesDao.getServicesDao(28525), objectInfo.DG_Sevice_Name);
			base.AddParameter(ServicesDao.getServicesDao(28554), objectInfo.DG_Service_Display_Name);
			base.AddParameter(ServicesDao.getServicesDao(28595), objectInfo.DG_Service_Path);
			base.AddParameter(ServicesDao.getServicesDao(28624), objectInfo.IsService);
			base.AddParameter(ServicesDao.getServicesDao(28641), objectInfo.RunLevel);
			//base.ExecuteNonQuery(#1j.#oi);
			return true;
		}

		static ServicesDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(ServicesDao));
		}
	}
}
