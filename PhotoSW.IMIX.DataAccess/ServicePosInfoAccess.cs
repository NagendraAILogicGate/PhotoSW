
using PhotoSW.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PhotoSW.IMIX.DataAccess
{
	public class ServicePosInfoAccess : BaseDataAccess
	{
        internal static SmartAssembly.Delegates.GetString getServicePosInfoAccess;

		public ServicePosInfoAccess(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public ServicePosInfoAccess()
		{
		}

		public List<ServicePosInfo> GetServices()
		{
			base.DBParameters.Clear();
			IDataReader dataReader=null;
			if (8 != 0)
			{
				//dataReader = base.ExecuteReader(#1j.#5d);
			}
			List<ServicePosInfo> result = this.ServicePosInfoVc(dataReader);
			dataReader.Close();
			return result;
		}

		private List<ServicePosInfo> ServicePosInfoVc(IDataReader IDataReader)
		{
			List<ServicePosInfo> list = new List<ServicePosInfo>();
			while (IDataReader.Read())
			{
				ServicePosInfo item = new ServicePosInfo
				{
					ServiceId = base.GetFieldValue(IDataReader,     ServicePosInfoAccess.getServicePosInfoAccess(56483), 0),
					ImixPosId = base.GetFieldValue(IDataReader,     ServicePosInfoAccess.getServicePosInfoAccess(55922), 0L),
					SubstoreId = base.GetFieldValue(IDataReader,    ServicePosInfoAccess.getServicePosInfoAccess(25017), 0),
					ServiceName = base.GetFieldValue(IDataReader,   ServicePosInfoAccess.getServicePosInfoAccess(56496), string.Empty),
					SystemName = base.GetFieldValue(IDataReader,    ServicePosInfoAccess.getServicePosInfoAccess(55943), string.Empty),
					SubStoremName = base.GetFieldValue(IDataReader, ServicePosInfoAccess.getServicePosInfoAccess(56525), string.Empty),
					RunLevel = base.GetFieldValue(IDataReader,      ServicePosInfoAccess.getServicePosInfoAccess(56546), 0),
					Status = base.GetFieldValue(IDataReader,        ServicePosInfoAccess.getServicePosInfoAccess(2946), string.Empty),
					UniqueCode = string.Concat(new object[]
					{
						base.GetFieldValue(IDataReader, ServicePosInfoAccess.getServicePosInfoAccess(56483), 0).ToString(),
						                                ServicePosInfoAccess.getServicePosInfoAccess(56559),
						base.GetFieldValue(IDataReader, ServicePosInfoAccess.getServicePosInfoAccess(55922), 0L).ToString(),
						                                ServicePosInfoAccess.getServicePosInfoAccess(56559),
						base.GetFieldValue(IDataReader, ServicePosInfoAccess.getServicePosInfoAccess(25017), 0),
						                                ServicePosInfoAccess.getServicePosInfoAccess(56559),
						base.GetFieldValue(IDataReader, ServicePosInfoAccess.getServicePosInfoAccess(56496), string.Empty),
						                                ServicePosInfoAccess.getServicePosInfoAccess(56559),
						base.GetFieldValue(IDataReader, ServicePosInfoAccess.getServicePosInfoAccess(56525), string.Empty),
						                                ServicePosInfoAccess.getServicePosInfoAccess(56559),
						base.GetFieldValue(IDataReader, ServicePosInfoAccess.getServicePosInfoAccess(56546), 0).ToString(),
						                                ServicePosInfoAccess.getServicePosInfoAccess(56559),
						base.GetFieldValue(IDataReader, ServicePosInfoAccess.getServicePosInfoAccess(56564), false).ToString(),
						                                ServicePosInfoAccess.getServicePosInfoAccess(56559),
						base.GetFieldValue(IDataReader, ServicePosInfoAccess.getServicePosInfoAccess(28901), string.Empty).ToString()
					})
				};
				list.Add(item);
			}
			return list;
		}

		public List<SvcRunningInfo> GetServiceInfoAccess(long ServiceID, long ImixPOSDetailID, long SubStoreID)
		{
			base.DBParameters.Clear();
            string expr_AC = ServicePosInfoAccess.getServicePosInfoAccess(56577);
			object expr_28 = ServiceID;
			if (4 != 0)
			{
				base.AddParameter(expr_AC, expr_28);
			}
			base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(56594), ImixPOSDetailID);
			base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(25528), SubStoreID);
			IDataReader dataReader =null; //base.ExecuteReader(#1j.#0d);
			List<SvcRunningInfo> result = this.SvcRunningInfoBk(dataReader);
			dataReader.Close();
			return result;
		}

		private List<SvcRunningInfo> SvcRunningInfoBk(IDataReader IDataReader)
		{
			List<SvcRunningInfo> list = new List<SvcRunningInfo>();
			while (IDataReader.Read())
			{
				SvcRunningInfo item = new SvcRunningInfo
				{
					LastStatusOnDate = base.GetFieldValue(IDataReader,    ServicePosInfoAccess.getServicePosInfoAccess(56619), DateTime.Now),
					Status = base.GetFieldValue(IDataReader,              ServicePosInfoAccess.getServicePosInfoAccess(2946), string.Empty),
					ServicePOSMappingID = base.GetFieldValue(IDataReader, ServicePosInfoAccess.getServicePosInfoAccess(56644), 0L),
					SubStoreName = base.GetFieldValue(IDataReader,        ServicePosInfoAccess.getServicePosInfoAccess(29667), string.Empty),
					ServiceName = base.GetFieldValue(IDataReader,         ServicePosInfoAccess.getServicePosInfoAccess(56673), string.Empty),
					SystemName = base.GetFieldValue(IDataReader,          ServicePosInfoAccess.getServicePosInfoAccess(55943), string.Empty)
				};
				list.Add(item);
			}
			return list;
		}

		public List<ImixPOSDetail> GetPOSDetailAccess(long SubStoreID, int RunLevel)
		{
			base.DBParameters.Clear();
			IDataReader dataReader=null;
			List<ImixPOSDetail> result;
			do
			{
				base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(25528), SubStoreID);
				base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(29080), RunLevel);
				//dataReader = base.ExecuteReader(#1j.#4d);
				result = this.ImixPOSDetailCk(dataReader);
			}
			while (false);
			dataReader.Close();
			return result;
		}

		private List<ImixPOSDetail> ImixPOSDetailCk(IDataReader IDataReader)
		{
			List<ImixPOSDetail> list = new List<ImixPOSDetail>();
			while (IDataReader.Read())
			{
				ImixPOSDetail imixPOSDetail = new ImixPOSDetail();
				imixPOSDetail.SystemName = base.GetFieldValue(IDataReader, ServicePosInfoAccess.getServicePosInfoAccess(55943), string.Empty);
				ImixPOSDetail item;
				do
				{
					imixPOSDetail.ImixPOSDetailID = base.GetFieldValue(IDataReader, ServicePosInfoAccess.getServicePosInfoAccess (55922), 0L);
					item = imixPOSDetail;
				}
				while (5 == 0);
				list.Add(item);
			}
			return list;
		}

		public int StartStopServiceByPosIdAccess(long ServiceId, long SubstoreId, long ImixPosDetailId, bool Status, string CreatedBy)
		{
			base.DBParameters.Clear();
			base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(56690), ServiceId);
			base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(13315), SubstoreId);
			base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(56707), ImixPosDetailId);
			base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(19935), Status);
			base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(31762), CreatedBy);
			base.OpenConnection();
			return 0;//(int)base.ExecuteNonQuery(#1j.#3d);
		}

		public int InsertImixPosAccess(ImixPOSDetail imixposdetail)
		{
			int expr_13D;
			do
			{
				List<SqlParameter> expr_151 = base.DBParameters;
				if (!false)
				{
					expr_151.Clear();
				}
				if (!false)
				{
					base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(56732), imixposdetail.ImixPOSDetailID);
					base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(56757), imixposdetail.SystemName);
					base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(56774), imixposdetail.IPAddress);
					base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(56791), imixposdetail.MacAddress);
					base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(25528), imixposdetail.SubStoreID);
					base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(27906), imixposdetail.IsActive);
					base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(31762), imixposdetail.CreatedBy);
					base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(56808), imixposdetail.IsStart);
				}
				base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess (27880), imixposdetail.SyncCode);
				int num =0; //(int)base.ExecuteNonQuery(#1j.#2d);
				int arg_145_0;
				expr_13D = (arg_145_0 = num);
			}
			while (3 == 0);
			return expr_13D;
		}

		public string CheckRunnignServiceAccess(long ServiceId, long SubStoreId, int Level, string SystemName)
		{
			string result;
			do
			{
				result = string.Empty;
			}
			while (false);
			base.DBParameters.Clear();
			if (7 == 0)
			{
				goto IL_D0;
			}
			base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(56690), ServiceId);
			base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(34110), SubStoreId);
			if (!true)
			{
				goto IL_B4;
			}
			base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess (56821), Level);
			if (!false)
			{
				base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess (56757), SystemName);
			}
			bool arg_D9_0 = base.OpenConnection();
			IL_A2:
			IDataReader dataReader=null;
			if (7 != 0)
			{
                //dataReader = base.ExecuteReader(#1j.#1d);
                //goto IL_D0;
			}
			goto IL_D6;
			IL_B4:
			result = base.GetFieldValue(dataReader, ServicePosInfoAccess.getServicePosInfoAccess (55943), string.Empty);
			IL_D0:
			arg_D9_0 = dataReader.Read();
			IL_D6:
			if (5 == 0)
			{
				goto IL_A2;
			}
			if (!arg_D9_0)
			{
				return result;
			}
			goto IL_B4;
		}

		public List<SubStore> GetSubstoreDetailsAccess()
		{
			base.DBParameters.Clear();
			IDataReader dataReader=null;
			if (8 != 0)
			{
				//dataReader = base.ExecuteReader(#1j.#Zd);
			}
			List<SubStore> result = this.SubStoreDk(dataReader);
			dataReader.Close();
			return result;
		}

		private List<SubStore> SubStoreDk(IDataReader IDataReader)
		{
			List<SubStore> list = new List<SubStore>();
			while (true)
			{
				if (4 == 0)
				{
					goto IL_6B;
				}
				IL_72:
				SubStore subStore;
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
					subStore = new SubStore();
					subStore.DG_SubStore_pkey = base.GetFieldValue(IDataReader, ServicePosInfoAccess.getServicePosInfoAccess(25017), 0);
				}
				if (!false)
				{
					subStore.DG_SubStore_Name = base.GetFieldValue(IDataReader, ServicePosInfoAccess.getServicePosInfoAccess (13332), string.Empty);
				}
				SubStore item = subStore;
				IL_6B:
				list.Add(item);
				goto IL_72;
			}
			return list;
		}

		public List<ImixPOSDetail> GetPosDetailsAccess()
		{
			base.DBParameters.Clear();
			IDataReader dataReader=null;
			if (8 != 0)
			{
				//dataReader = base.ExecuteReader(#1j.#Yd);
			}
			List<ImixPOSDetail> result = this.ImixPOSDetailEk(dataReader);
			dataReader.Close();
			return result;
		}

		private List<ImixPOSDetail> ImixPOSDetailEk(IDataReader IDataReader)
		{
			List<ImixPOSDetail> list = new List<ImixPOSDetail>();
			while (IDataReader.Read())
			{
				ImixPOSDetail imixPOSDetail = new ImixPOSDetail();
				imixPOSDetail.SystemName = base.GetFieldValue(IDataReader, ServicePosInfoAccess.getServicePosInfoAccess (55943), string.Empty);
				ImixPOSDetail item;
				do
				{
					imixPOSDetail.ImixPOSDetailID = base.GetFieldValue(IDataReader, ServicePosInfoAccess.getServicePosInfoAccess(55922), 0L);
					item = imixPOSDetail;
				}
				while (5 == 0);
				list.Add(item);
			}
			return list;
		}

		public List<MappedPos> MappedPosDetailAccess()
		{
			base.DBParameters.Clear();
			IDataReader dataReader=null;
			if (8 != 0)
			{
				//dataReader = base.ExecuteReader(#1j.#Xd);
			}
			List<MappedPos> result = this.MappedPosFk(dataReader);
			dataReader.Close();
			return result;
		}

		private List<MappedPos> MappedPosFk(IDataReader IDataReader)
		{
			List<MappedPos> expr_188 = new List<MappedPos>();
			List<MappedPos> list;
			if (!false)
			{
				list = expr_188;
			}
			while (IDataReader.Read())
			{
				MappedPos item = new MappedPos
				{
					SystemName = base.GetFieldValue(IDataReader,       ServicePosInfoAccess.getServicePosInfoAccess(55943), string.Empty),
					ImixPOSDetailID = base.GetFieldValue(IDataReader,  ServicePosInfoAccess.getServicePosInfoAccess(55922), 0L),
					SubStoreID = base.GetFieldValue(IDataReader,       ServicePosInfoAccess.getServicePosInfoAccess(10983), 0L),
					SubStoreName = base.GetFieldValue(IDataReader,     ServicePosInfoAccess.getServicePosInfoAccess(13332), string.Empty),
					UniqueCode = string.Concat(new string[]
					{
						base.GetFieldValue(IDataReader, ServicePosInfoAccess.getServicePosInfoAccess(55922), 0L).ToString(),
						                                ServicePosInfoAccess.getServicePosInfoAccess(56559),
						base.GetFieldValue(IDataReader, ServicePosInfoAccess.getServicePosInfoAccess(55943), string.Empty),
						                                ServicePosInfoAccess.getServicePosInfoAccess(56559),
						base.GetFieldValue(IDataReader, ServicePosInfoAccess.getServicePosInfoAccess(13332), string.Empty),
						                                ServicePosInfoAccess.getServicePosInfoAccess(56559),
						base.GetFieldValue(IDataReader, ServicePosInfoAccess.getServicePosInfoAccess(10983), 0L).ToString()
					})
				};
				list.Add(item);
			}
			return list;
		}

		public int GetAnyRunningServiceByPosIdAccess(long imixposdetailId)
		{
			int expr_3B;
			do
			{
				int num;
				while (true)
				{
					base.DBParameters.Clear();
					if (!false)
					{
						base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess (56732), imixposdetailId);
					}
					while (!false)
					{
						num =0;// (int)base.ExecuteScalar(#1j.#Wd);
						if (true)
						{
							goto Block_3;
						}
					}
				}
				Block_3:
				int arg_40_0;
				expr_3B = (arg_40_0 = num);
			}
			while (false);
			return expr_3B;
		}

		public List<GetServiceStatus> GetServiceStatusAccess(string MachineName, string ServiceName)
		{
			base.DBParameters.Clear();
			base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(56830), MachineName);
			base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(56847), ServiceName);
			base.OpenConnection();
			IDataReader dataReader=null;
			List<GetServiceStatus> result;
			if (6 != 0)
			{
				//dataReader = base.ExecuteReader(#1j.#Vd);
				result = this.GetServiceStatusGk(dataReader);
			}
			dataReader.Close();
			return result;
		}

		private List<GetServiceStatus> GetServiceStatusGk(IDataReader IDataReader)
		{
			List<GetServiceStatus> list;
			while (true)
			{
				list = new List<GetServiceStatus>();
				IL_0A:
				while (!false)
				{
					IL_B9:
					while (IDataReader.Read())
					{
						GetServiceStatus getServiceStatus = new GetServiceStatus();
						do
						{
							getServiceStatus.ServiceId = base.GetFieldValue(IDataReader,  ServicePosInfoAccess.getServicePosInfoAccess(28826), 0);
							getServiceStatus.Runlevel = base.GetFieldValue(IDataReader,   ServicePosInfoAccess.getServicePosInfoAccess(56864), 0);
							getServiceStatus.SubStoreID = base.GetFieldValue(IDataReader, ServicePosInfoAccess.getServicePosInfoAccess(10983), 0L);
							getServiceStatus.iMixPosId = base.GetFieldValue(IDataReader,  ServicePosInfoAccess.getServicePosInfoAccess(55922), 0L);
							if (false)
							{
								goto IL_B9;
							}
						}
						while (-1 == 0);
						GetServiceStatus item = getServiceStatus;
						if (7 == 0)
						{
							goto IL_0A;
						}
						if (8 == 0)
						{
							break;
						}
						list.Add(item);
					}
					return list;
				}
			}
			return list;
		}

		public int UpdateServiceRunLevelAccess(int _serviceId, int RunLevel, bool isService)
		{
			base.DBParameters.Clear();
			base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(56690), _serviceId);
			base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(29080), RunLevel);
			base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(56877), isService);
			return 0;//(int)base.ExecuteNonQuery(#1j.#Ud);
		}

		public void StartStopSystemlAccess(string mac, string myIP, string SystemName, int Type)
		{
			base.DBParameters.Clear();
			base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(56894), mac);
			base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(56903), myIP);
			base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(56757), SystemName);
			base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(56912), Type);
			//base.ExecuteNonQuery(#1j.#Td);
		}

		public void setPrintServer(string mac, string SystemName, bool isStop)
		{
			if (!false)
			{
				base.DBParameters.Clear();
				base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(56791), mac);
				base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess(56757), SystemName);
				do
				{
					base.AddParameter(ServicePosInfoAccess.getServicePosInfoAccess (56921), isStop);
				}
				while (2 == 0);
				//base.ExecuteNonQuery(#1j.#0j);
			}
		}

		static ServicePosInfoAccess()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(ServicePosInfoAccess));
		}
	}
}
