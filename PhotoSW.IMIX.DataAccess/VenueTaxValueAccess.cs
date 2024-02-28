using PhotoSW.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class VenueTaxValueAccess : BaseDataAccess
	{
		
        internal static SmartAssembly .Delegates .GetString getVenueTaxValueAccess;

		public VenueTaxValueAccess(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public VenueTaxValueAccess()
		{
		}

		public List<VenueTaxValueModel> GetVenueTaxValueDetail()
		{
			base.DBParameters.Clear();
            IDataReader dataReader = base.ExecuteReader(VenueTaxValueAccess.getVenueTaxValueAccess(59221));
			List<VenueTaxValueModel> result;
			do
			{
				result = this.VenueTaxValueModelXk(dataReader);
			}
			while (false);
			dataReader.Close();
			return result;
		}

		private List<VenueTaxValueModel> VenueTaxValueModelXk(IDataReader IDataReader)
		{
			List<VenueTaxValueModel> list = new List<VenueTaxValueModel>();
			while (IDataReader.Read() || 3 == 0)
			{
				VenueTaxValueModel venueTaxValueModel = new VenueTaxValueModel();
				if (!false)
				{
					venueTaxValueModel.TaxPercentage = base.GetFieldValue(IDataReader, VenueTaxValueAccess.getVenueTaxValueAccess (57732), 0.0m);
					VenueTaxValueModel item;
					if (!false)
					{
						venueTaxValueModel.IsActive = base.GetFieldValue(IDataReader, VenueTaxValueAccess.getVenueTaxValueAccess (3542), false);
						if (6 == 0)
						{
							continue;
						}
						item = venueTaxValueModel;
					}
					list.Add(item);
				}
			}
			return list;
		}

		static VenueTaxValueAccess()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(VenueTaxValueAccess));
		}
	}
}
