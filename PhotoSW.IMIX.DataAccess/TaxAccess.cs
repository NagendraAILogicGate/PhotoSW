using PhotoSW.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace PhotoSW.IMIX.DataAccess
{
	public class TaxAccess : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getTaxAccess;

		public TaxAccess(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public TaxAccess()
		{
		}

		public bool SaveOrderTaxDetails(int StoreId, int OrderId, int SubStoreId)
		{
			base.DBParameters.Clear();
			base.AddParameter(TaxAccess.getTaxAccess(16783), StoreId);
			base.AddParameter(TaxAccess.getTaxAccess(15635), OrderId);
			base.AddParameter(TaxAccess.getTaxAccess(2783), SubStoreId);
			base.ExecuteNonQuery(TaxAccess.getTaxAccess (57249));
			return true;
		}

		public bool SaveTaxDetails(int VenueId, int TaxId, decimal TaxPercentage, bool Status, DateTime modifiedate)
		{
			base.DBParameters.Clear();
			do
			{
				base.AddParameter(TaxAccess.getTaxAccess (57278), VenueId);
			}
			while (false);
			base.AddParameter(TaxAccess.getTaxAccess (57291), TaxId);
			if (4 != 0)
			{
				base.AddParameter(TaxAccess.getTaxAccess(57300), TaxPercentage);
				base.AddParameter(TaxAccess.getTaxAccess(27908), Status);
				base.AddParameter(TaxAccess.getTaxAccess(57321), modifiedate);
				base.ExecuteNonQuery(TaxAccess.getTaxAccess (57342));
			}
			return true;
		}

		public ObservableCollection<TaxDetailInfo> GetTaxDetail()
		{
			base.DBParameters.Clear();
			IDataReader dataReader = base.ExecuteReader(TaxAccess.getTaxAccess (57375));
			ObservableCollection<TaxDetailInfo> result;
			do
			{
				result = this.TaxDetailInfoLk(dataReader);
			}
			while (false);
			dataReader.Close();
			return result;
		}

		public List<TaxDetailInfo> GetTaxDetail(int? orderId)
		{
			List<TaxDetailInfo> result;
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
					base.AddParameter(TaxAccess.getTaxAccess (15635), orderId);
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
				dataReader = base.ExecuteReader(TaxAccess.getTaxAccess (57400));
				result = this.TaxDetailInfoKk(dataReader);
				goto IL_41;
			}
			return result;
		}

		public List<TaxDetailInfo> GetReportTaxDetail(DateTime FromDate, DateTime ToDate, int SubStoreID)
		{
			base.DBParameters.Clear();
			base.AddParameter(TaxAccess.getTaxAccess (57429), FromDate);
			List<TaxDetailInfo> result;
			do
			{
				base.AddParameter(TaxAccess.getTaxAccess(55641), ToDate);
				base.AddParameter(TaxAccess.getTaxAccess(25530), SubStoreID);
				IDataReader dataReader = base.ExecuteReader(TaxAccess.getTaxAccess (57442));
				result = this.TaxDetailInfoKk(dataReader);
				dataReader.Close();
			}
			while (3 == 0);
			return result;
		}

		public bool UpdateStoreTaxData(StoreInfo store)
		{
			base.AddParameter(TaxAccess.getTaxAccess(33590), store.BillReceiptTitle);
			if (6 == 0)
			{
				goto IL_138;
			}
			base.AddParameter(TaxAccess.getTaxAccess(33615), store.TaxRegistrationNumber);
			base.AddParameter(TaxAccess.getTaxAccess(33648), store.TaxRegistrationText);
			base.AddParameter(TaxAccess.getTaxAccess(33677), store.Address);
			base.AddParameter(TaxAccess.getTaxAccess(33690), store.PhoneNo);
			base.AddParameter(TaxAccess.getTaxAccess(33703), store.TaxMinSequenceNo);
			base.AddParameter(TaxAccess.getTaxAccess(33728), store.TaxMaxSequenceNo);
			base.AddParameter(TaxAccess.getTaxAccess(33753), store.IsSequenceNoRequired);
			IL_FD:
			base.AddParameter(TaxAccess.getTaxAccess(33782), store.IsTaxEnabled);
			base.AddParameter(TaxAccess.getTaxAccess(57467), store.WebsiteURL);
			IL_138:
			base.AddParameter(TaxAccess.getTaxAccess(57484), store.EmailID);
			base.AddParameter(TaxAccess.getTaxAccess(57497), store.ServerHotFolderPath);
			base.AddParameter(TaxAccess.getTaxAccess(57526), store.IsActiveStockShot);
			base.AddParameter(TaxAccess.getTaxAccess(57551), store.RunImageProcessingEngineLocationWise);
			while (3 != 0)
			{
				base.AddParameter(TaxAccess.getTaxAccess(57604), store.RunVideoProcessingEngineLocationWise);
				if (!false)
				{
					if (false)
					{
						continue;
					}
					base.AddParameter(TaxAccess.getTaxAccess (57657), store.IsTaxIncluded);
					base.ExecuteNonQuery(TaxAccess.getTaxAccess (33803));
				}
				return true;
			}
			goto IL_FD;
		}

		public StoreInfo getTaxConfigData()
		{
			StoreInfo result;
			IDataReader dataReader;
			while (true)
			{
				result = new StoreInfo();
				if (5 != 0)
				{
					dataReader = base.ExecuteReader(TaxAccess.getTaxAccess (33836));
					if (3 == 0)
					{
						return result;
					}
					if (!false)
					{
                        result = this.StoreInfozd(dataReader);
						if (!false)
						{
							break;
						}
					}
				}
			}
			dataReader.Close();
			return result;
		}

		public List<TaxDetailInfo> GetApplicableTaxes(int taxID)
		{
			List<TaxDetailInfo> result;
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
					base.AddParameter(TaxAccess.getTaxAccess(57678), taxID);
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
				dataReader = base.ExecuteReader(TaxAccess.getTaxAccess(57695));
				result = this.TaxDetailInfoMk(dataReader);
				goto IL_41;
			}
			return result;
		}

		private List<TaxDetailInfo> TaxDetailInfoKk(IDataReader IDataReader)
		{
			List<TaxDetailInfo> list;
			if (true)
			{
				list = new List<TaxDetailInfo>();
				if (!false)
				{
					goto IL_C0;
				}
				goto IL_1F;
			}
			IL_15:
			TaxDetailInfo taxDetailInfo = new TaxDetailInfo();
			IL_1F:
			taxDetailInfo.TaxAmount = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess(57716), 0.0m);
			taxDetailInfo.TaxPercentage = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess (57729), 0.0m);
			taxDetailInfo.TaxName = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess (57750), string.Empty);
			taxDetailInfo.CurrencyName = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess (57763), string.Empty);
			list.Add(taxDetailInfo);
			IL_C0:
			if (!IDataReader.Read())
			{
				return list;
			}
			goto IL_15;
		}

		private ObservableCollection<TaxDetailInfo> TaxDetailInfoLk(IDataReader IDataReader)
		{
			ObservableCollection<TaxDetailInfo> observableCollection = new ObservableCollection<TaxDetailInfo>();
			while (true)
			{
			
				IL_72:
				TaxDetailInfo taxDetailInfo;
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
					taxDetailInfo = new TaxDetailInfo();
					taxDetailInfo.TaxId = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess(57780), 1);
				}
				if (!false)
				{
					taxDetailInfo.TaxName = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess (57750), string.Empty);
				}
				TaxDetailInfo item = taxDetailInfo;
				IL_6B:
				observableCollection.Add(item);
				goto IL_72;
			}
			return observableCollection;
		}

		private List<TaxDetailInfo> TaxDetailInfoMk(IDataReader IDataReader)
		{
			List<TaxDetailInfo> list;
			while (true)
			{
				if (!false)
				{
					list = new List<TaxDetailInfo>();
					goto IL_96;
				}
				IL_12:
				if (7 == 0)
				{
					continue;
				}
				list.Add(new TaxDetailInfo
				{
					TaxId = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess(57780), 0),
					TaxPercentage = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess(57729), 0.0m),
					TaxName = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess (57750), string.Empty)
				});
				IL_96:
				if (!IDataReader.Read())
				{
					break;
				}
				goto IL_12;
			}
			return list;
		}

		private StoreInfo StoreInfozd(IDataReader IDataReader)
		{
          
			StoreInfo storeInfo = new StoreInfo();
			while (IDataReader.Read())
			{
				StoreInfo expr_236 = storeInfo;
				string expr_252 = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess (33861), string.Empty);
				if (true)
				{
					expr_236.BillReceiptTitle = expr_252;
				}
				storeInfo.Address = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess(33886), string.Empty);
				storeInfo.PhoneNo = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess(33899), string.Empty);
				storeInfo.TaxRegistrationNumber = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess(33912), string.Empty);
				storeInfo.TaxRegistrationText = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess (33941), string.Empty);
				storeInfo.IsSequenceNoRequired = new bool?(base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess (33970), false));
				storeInfo.IsTaxEnabled = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess (24977), false);
				storeInfo.TaxMinSequenceNo = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess (33999), 0L);
				storeInfo.TaxMaxSequenceNo = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess (34024), 0L);
				storeInfo.WebsiteURL = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess (57789), string.Empty);
				storeInfo.EmailID = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess (57806), string.Empty);
				storeInfo.ServerHotFolderPath = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess (30594), string.Empty);
				storeInfo.IsActiveStockShot = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess (57815), false);
				storeInfo.RunImageProcessingEngineLocationWise = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess(57840), false);
				storeInfo.RunVideoProcessingEngineLocationWise = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess(57889), false);
				storeInfo.IsTaxIncluded = base.GetFieldValue(IDataReader, TaxAccess.getTaxAccess (57938), false);
			}
			return storeInfo;
		}

		static TaxAccess()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(TaxAccess));
		}
	}
}
