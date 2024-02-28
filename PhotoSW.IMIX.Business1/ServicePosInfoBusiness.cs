using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using log4net;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.ServiceProcess;

namespace DigiPhoto.IMIX.Business
{
	public class ServicePosInfoBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public List<ServicePosInfo> ;

			public ServicePosInfoBusiness ;

			public void ()
			{
				ServicePosInfoAccess servicePosInfoAccess = new ServicePosInfoAccess(this..Transaction);
				this. = servicePosInfoAccess.GetServices();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ServicePosInfoBusiness ;

			public long ;

			public long ;

			public long ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ServicePosInfoBusiness. ;

			public List<SvcRunningInfo> ;

			public void ()
			{
				ServicePosInfoAccess servicePosInfoAccess = new ServicePosInfoAccess(this...Transaction);
				this. = servicePosInfoAccess.GetServiceInfoAccess(this.., this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ServicePosInfoBusiness ;

			public long ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ServicePosInfoBusiness. ;

			public List<ImixPOSDetail> ;

			public void ()
			{
				ServicePosInfoAccess servicePosInfoAccess = new ServicePosInfoAccess(this...Transaction);
				this. = servicePosInfoAccess.GetPOSDetailAccess(this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public long ;

			public long ;

			public long ;

			public bool ;

			public string ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ServicePosInfoBusiness. ;

			public int ;

			public void ()
			{
				ServicePosInfoAccess servicePosInfoAccess = new ServicePosInfoAccess();
				this. = servicePosInfoAccess.StartStopServiceByPosIdAccess(this.., this.., this.., this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ServicePosInfoBusiness ;

			public ImixPOSDetail ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ServicePosInfoBusiness. ;

			public int ;

			public void ()
			{
				if (4 != 0)
				{
					ServicePosInfoAccess servicePosInfoAccess = new ServicePosInfoAccess(this...Transaction);
					if (!false)
					{
						this. = servicePosInfoAccess.InsertImixPosAccess(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ServicePosInfoBusiness ;

			public long ;

			public long ;

			public int ;

			public string ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ServicePosInfoBusiness. ;

			public string ;

			public void ()
			{
				ServicePosInfoAccess servicePosInfoAccess = new ServicePosInfoAccess(this...Transaction);
				this. = servicePosInfoAccess.CheckRunnignServiceAccess(this.., this.., this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ServicePosInfoBusiness ;

			public string ;

			public string ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ServicePosInfoBusiness. ;

			public List<GetServiceStatus> ;

			public void ()
			{
				ServicePosInfoAccess servicePosInfoAccess = new ServicePosInfoAccess(this...Transaction);
				this. = servicePosInfoAccess.GetServiceStatusAccess(this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<SubStore> ;

			public ServicePosInfoBusiness ;

			public void ()
			{
				ServicePosInfoAccess servicePosInfoAccess = new ServicePosInfoAccess(this..Transaction);
				this. = servicePosInfoAccess.GetSubstoreDetailsAccess();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<ImixPOSDetail> ;

			public ServicePosInfoBusiness ;

			public void ()
			{
				ServicePosInfoAccess servicePosInfoAccess = new ServicePosInfoAccess(this..Transaction);
				this. = servicePosInfoAccess.GetPosDetailsAccess();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<MappedPos> ;

			public ServicePosInfoBusiness ;

			public void ()
			{
				ServicePosInfoAccess servicePosInfoAccess = new ServicePosInfoAccess(this..Transaction);
				this. = servicePosInfoAccess.MappedPosDetailAccess();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ServicePosInfoBusiness ;

			public long ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ServicePosInfoBusiness. ;

			public int ;

			public void ()
			{
				if (4 != 0)
				{
					ServicePosInfoAccess servicePosInfoAccess = new ServicePosInfoAccess(this...Transaction);
					if (!false)
					{
						this. = servicePosInfoAccess.GetAnyRunningServiceByPosIdAccess(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ServicePosInfoBusiness ;

			public string ;

			public string ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					ServicePosInfoAccess servicePosInfoAccess = new ServicePosInfoAccess(this..Transaction);
					servicePosInfoAccess.setPrintServer(this., this., this.);
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ServicePosInfoBusiness ;

			public int ;

			public int ;

			public bool ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ServicePosInfoBusiness. ;

			public int ;

			public void ()
			{
				ServicePosInfoAccess servicePosInfoAccess = new ServicePosInfoAccess(this...Transaction);
				this. = servicePosInfoAccess.UpdateServiceRunLevelAccess(this.., this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ServicePosInfoBusiness ;

			public string ;

			public string ;

			public string ;

			public int ;

			public void ()
			{
				while (true)
				{
					ServicePosInfoAccess servicePosInfoAccess;
					if (-1 != 0)
					{
						servicePosInfoAccess = new ServicePosInfoAccess(this..Transaction);
						goto IL_10;
					}
					IL_33:
					if (!false)
					{
						if (false)
						{
							continue;
						}
						if (5 != 0)
						{
							break;
						}
					}
					IL_10:
					servicePosInfoAccess.StartStopSystemlAccess(this., this., this., this.);
					goto IL_33;
				}
			}
		}

		[CompilerGenerated]
		private static Func<GetServiceStatus, int> ;

		[CompilerGenerated]
		private static Func<GetServiceStatus, long> ;

		[CompilerGenerated]
		private static Func<GetServiceStatus, int> ;

		[CompilerGenerated]
		private static Func<GetServiceStatus, long> ;

		[CompilerGenerated]
		private static Func<GetServiceStatus, int> ;

		[CompilerGenerated]
		private static Func<GetServiceStatus, long> ;

		[CompilerGenerated]
		private static Func<GetServiceStatus, int> ;

		[CompilerGenerated]
		private static Func<GetServiceStatus, long> ;

		[NonSerialized]
		internal static SmartAssembly.Delegates.GetString ;

		public List<ServicePosInfo> GetRunningServices()
		{
			List<ServicePosInfo> result;
			try
			{
				if (!false)
				{
					ServicePosInfoBusiness.  = new ServicePosInfoBusiness.();
					. = this;
					if (8 != 0)
					{
						if (false)
						{
							goto IL_3C;
						}
						. = new List<ServicePosInfo>();
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					base.Start(false);
					IL_3C:
					result = .;
				}
			}
			catch (Exception)
			{
				if (2 != 0)
				{
					result = null;
				}
			}
			return result;
		}

		public List<SvcRunningInfo> GetServiceInfoBusiness(long ServiceID, long ImixPOSDetailID, long SubStoreID)
		{
			List<SvcRunningInfo> result;
			do
			{
				if (false)
				{
					return result;
				}
				long  = ImixPOSDetailID;
				long  = SubStoreID;
			}
			while (false);
			. = this;
			try
			{
				ServicePosInfoBusiness. 2 = new ServicePosInfoBusiness.();
				2. = ;
				if (6 != 0)
				{
					2. = new List<SvcRunningInfo>();
					this.operation = new BaseBusiness.TransactionMethod(2.);
					base.Start(false);
				}
				result = 2.;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		public List<ImixPOSDetail> GetPOSDetailBusiness(long SubStoreID, int RunLevel)
		{
			ServicePosInfoBusiness.  = new ServicePosInfoBusiness.();
			List<ImixPOSDetail> result;
			do
			{
				. = SubStoreID;
				if (!false)
				{
					. = RunLevel;
					. = this;
					try
					{
						ServicePosInfoBusiness.  = new ServicePosInfoBusiness.();
						. = ;
						. = new List<ImixPOSDetail>();
						this.operation = new BaseBusiness.TransactionMethod(.);
						base.Start(false);
						if (6 != 0)
						{
							result = .;
						}
					}
					catch (Exception)
					{
						do
						{
							result = null;
						}
						while (2 == 0);
					}
				}
			}
			while (3 == 0);
			return result;
		}

		public int StartStopServiceByPosIdBusiness(long ServiceId, long SubstoreId, long ImixPosDetailId, bool Status, string CreatedBy)
		{
			ServicePosInfoBusiness.  = new ServicePosInfoBusiness.();
			. = ServiceId;
			. = SubstoreId;
			. = ImixPosDetailId;
			. = Status;
			. = CreatedBy;
			int result;
			try
			{
				ServicePosInfoBusiness.  = new ServicePosInfoBusiness.();
				. = ;
				if (!false && !false)
				{
					. = 0;
				}
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				int expr_80;
				do
				{
					expr_80 = .;
				}
				while (false);
				result = expr_80;
			}
			catch (Exception)
			{
				do
				{
					result = 0;
				}
				while (false);
			}
			return result;
		}

		public int InsertImixPosBusiness(ImixPOSDetail imixPosDetail)
		{
			if (!false && -1 != 0)
			{
			}
			. = imixPosDetail;
			. = this;
			int result;
			try
			{
				ServicePosInfoBusiness.  = new ServicePosInfoBusiness.();
				if (!false)
				{
					. = ;
				}
				. = 0;
				this.operation = new BaseBusiness.TransactionMethod(.);
				int arg_67_0 = base.Start(false) ? 1 : 0;
				if (!false && 4 != 0)
				{
					arg_67_0 = .;
				}
				result = arg_67_0;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}

		public string CheckRunnignServiceBusiness(long ServiceId, long SubStoreId, int Level, string SystemName)
		{
			ServicePosInfoBusiness.  = new ServicePosInfoBusiness.();
			. = ServiceId;
			. = SubStoreId;
			. = Level;
			. = SystemName;
			. = this;
			string result;
			try
			{
				ServicePosInfoBusiness.  = new ServicePosInfoBusiness.();
				. = ;
				if (!false)
				{
					. = string.Empty;
				}
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
				}
				while (false);
				result = .;
			}
			catch (Exception)
			{
				do
				{
					result = null;
				}
				while (false);
			}
			return result;
		}

		public List<GetServiceStatus> GetServiceStatusBusiness(string MachineName, string ServiceName)
		{
			ServicePosInfoBusiness.  = new ServicePosInfoBusiness.();
			List<GetServiceStatus> result;
			do
			{
				. = MachineName;
				if (!false)
				{
					. = ServiceName;
					. = this;
					try
					{
						ServicePosInfoBusiness.  = new ServicePosInfoBusiness.();
						. = ;
						. = new List<GetServiceStatus>();
						this.operation = new BaseBusiness.TransactionMethod(.);
						base.Start(false);
						if (6 != 0)
						{
							result = .;
						}
					}
					catch (Exception)
					{
						do
						{
							result = null;
						}
						while (2 == 0);
					}
				}
			}
			while (3 == 0);
			return result;
		}

		public List<SubStore> GetSubstoreDetailsBusiness()
		{
			List<SubStore> result;
			try
			{
				if (!false)
				{
					ServicePosInfoBusiness.  = new ServicePosInfoBusiness.();
					. = this;
					if (8 != 0)
					{
						if (false)
						{
							goto IL_3C;
						}
						. = new List<SubStore>();
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					base.Start(false);
					IL_3C:
					result = .;
				}
			}
			catch (Exception)
			{
				if (2 != 0)
				{
					result = null;
				}
			}
			return result;
		}

		public List<ImixPOSDetail> GetPosDetailsBusiness()
		{
			List<ImixPOSDetail> result;
			try
			{
				if (!false)
				{
					ServicePosInfoBusiness.  = new ServicePosInfoBusiness.();
					. = this;
					if (8 != 0)
					{
						if (false)
						{
							goto IL_3C;
						}
						. = new List<ImixPOSDetail>();
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					base.Start(false);
					IL_3C:
					result = .;
				}
			}
			catch (Exception)
			{
				if (2 != 0)
				{
					result = null;
				}
			}
			return result;
		}

		public List<MappedPos> MappedPosDetailBusiness()
		{
			List<MappedPos> result;
			try
			{
				if (!false)
				{
					ServicePosInfoBusiness.  = new ServicePosInfoBusiness.();
					. = this;
					if (8 != 0)
					{
						if (false)
						{
							goto IL_3C;
						}
						. = new List<MappedPos>();
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					base.Start(false);
					IL_3C:
					result = .;
				}
			}
			catch (Exception)
			{
				if (2 != 0)
				{
					result = null;
				}
			}
			return result;
		}

		public int GetAnyRunningServiceByPosIdBusiness(long imixId)
		{
			if (!false && -1 != 0)
			{
			}
			. = imixId;
			. = this;
			int result;
			try
			{
				ServicePosInfoBusiness.  = new ServicePosInfoBusiness.();
				if (!false)
				{
					. = ;
				}
				. = 0;
				this.operation = new BaseBusiness.TransactionMethod(.);
				int arg_67_0 = base.Start(false) ? 1 : 0;
				if (!false && 4 != 0)
				{
					arg_67_0 = .;
				}
				result = arg_67_0;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}

		public string ServiceStart(bool IsExe)
		{
			string result;
			try
			{
				LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
				string systemName = this.getSystemName();
				string serviceName = this.getServiceName(IsExe);
				bool status = true;
				string createdBy = ServicePosInfoBusiness.(4703);
				List<GetServiceStatus> list = new List<GetServiceStatus>();
				ServicePosInfoBusiness servicePosInfoBusiness = new ServicePosInfoBusiness();
				new ServiceController(serviceName, systemName);
				list = servicePosInfoBusiness.GetServiceStatusBusiness(systemName, serviceName);
				int num = 0;
				long num2 = 0L;
				int level = 0;
				long imixPosDetailId = 0L;
				if (list != null)
				{
					IEnumerable<GetServiceStatus> arg_96_0 = list;
					if (ServicePosInfoBusiness. == null)
					{
						ServicePosInfoBusiness. = new Func<GetServiceStatus, int>(ServicePosInfoBusiness.);
					}
					num = arg_96_0.Select(ServicePosInfoBusiness.).FirstOrDefault<int>();
					IEnumerable<GetServiceStatus> arg_C1_0 = list;
					if (ServicePosInfoBusiness. == null)
					{
						ServicePosInfoBusiness. = new Func<GetServiceStatus, long>(ServicePosInfoBusiness.);
					}
					num2 = arg_C1_0.Select(ServicePosInfoBusiness.).FirstOrDefault<long>();
					IEnumerable<GetServiceStatus> arg_EC_0 = list;
					if (ServicePosInfoBusiness. == null)
					{
						ServicePosInfoBusiness. = new Func<GetServiceStatus, int>(ServicePosInfoBusiness.);
					}
					level = arg_EC_0.Select(ServicePosInfoBusiness.).FirstOrDefault<int>();
					IEnumerable<GetServiceStatus> arg_117_0 = list;
					if (ServicePosInfoBusiness. == null)
					{
						ServicePosInfoBusiness. = new Func<GetServiceStatus, long>(ServicePosInfoBusiness.);
					}
					imixPosDetailId = arg_117_0.Select(ServicePosInfoBusiness.).FirstOrDefault<long>();
				}
				string text = servicePosInfoBusiness.CheckRunnignServiceBusiness((long)num, num2, level, systemName);
				if (text != ServicePosInfoBusiness.(1918))
				{
					result = text;
				}
				else
				{
					do
					{
						servicePosInfoBusiness.StartStopServiceByPosIdBusiness((long)num, num2, imixPosDetailId, status, createdBy);
					}
					while (4 == 0);
					result = text;
				}
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}

		public void setPrintServer(string mac, string SystemName, bool isStop)
		{
			BaseBusiness.TransactionMethod transactionMethod;
			while (true)
			{
				if (4 == 0)
				{
					goto IL_2E;
				}
				transactionMethod = null;
				if (4 != 0)
				{
					goto IL_2E;
				}
				IL_37:
				if (7 != 0)
				{
					break;
				}
				continue;
				IL_2E:
				. = isStop;
				goto IL_37;
			}
			. = this;
			try
			{
				try
				{
					if (transactionMethod == null)
					{
						transactionMethod = new BaseBusiness.TransactionMethod(.);
					}
					this.operation = transactionMethod;
					if (8 != 0)
					{
						base.Start(false);
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public string getServiceName(bool IsEXE)
		{
			string processName;
			ServiceController serviceController;
			while (true)
			{
				IL_00:
				processName = Process.GetCurrentProcess().ProcessName;
				bool arg_14_0 = IsEXE;
				while (!arg_14_0)
				{
					ServiceController[] expr_103 = ServiceController.GetServices();
					ServiceController[] array;
					if (6 != 0)
					{
						array = expr_103;
					}
					int arg_BC_0;
					int arg_A2_0;
					int arg_3A_0;
					int expr_11D = arg_3A_0 = (arg_A2_0 = (arg_BC_0 = Process.GetCurrentProcess().Id));
					if (-1 == 0)
					{
						goto IL_9C;
					}
					int num = expr_11D;
					ServiceController[] array2 = array;
					arg_3A_0 = 0;
					IL_3A:
					bool expr_3A = arg_14_0 = (arg_3A_0 != 0);
					int num2;
					if (!expr_3A)
					{
						num2 = (expr_3A ? 1 : 0);
						goto IL_BF;
					}
					continue;
					IL_9C:
					if (-1 != 0)
					{
						if (!false)
						{
							int num3 = arg_A2_0;
							if (num3 == num)
							{
								goto Block_6;
							}
							if (5 == 0)
							{
								goto IL_47;
							}
							arg_BC_0 = num2;
						}
						num2 = arg_BC_0 + 1;
						goto IL_BF;
					}
					goto IL_3A;
					IL_47:
					if (!false)
					{
						ManagementObject managementObject = new ManagementObject(ServicePosInfoBusiness.(4716) + serviceController.ServiceName + ServicePosInfoBusiness.(1913));
						managementObject.Get();
						arg_A2_0 = (arg_3A_0 = (arg_BC_0 = Convert.ToInt32(managementObject[ServicePosInfoBusiness.(4745)])));
						goto IL_9C;
					}
					goto IL_00;
					IL_BF:
					if (num2 >= array2.Length)
					{
						goto Block_8;
					}
					serviceController = array2[num2];
					goto IL_47;
				}
				break;
			}
			return processName;
			Block_6:
			return serviceController.ServiceName;
			Block_8:
			return ServicePosInfoBusiness.(4758);
		}

		public string getSystemName()
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(ServicePosInfoBusiness.(3686), ServicePosInfoBusiness.(3703));
			ManagementObjectCollection.ManagementObjectEnumerator expr_CD = managementObjectSearcher.Get().GetEnumerator();
			ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator;
			if (!false)
			{
				managementObjectEnumerator = expr_CD;
			}
			try
			{
				if (managementObjectEnumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
					string result;
					do
					{
						result = managementObject[ServicePosInfoBusiness.(3756)].ToString();
					}
					while (-1 == 0);
					return result;
				}
			}
			finally
			{
				if (managementObjectEnumerator == null)
				{
					goto IL_83;
				}
				IL_7D:
				((IDisposable)managementObjectEnumerator).Dispose();
				IL_83:
				if (-1 == 0)
				{
					goto IL_7D;
				}
			}
			return ServicePosInfoBusiness.(1918);
		}

		public void StopService(bool IsExe)
		{
			string arg_05_0 = string.Empty;
			string systemName = this.getSystemName();
			string serviceName = this.getServiceName(IsExe);
			bool expr_29 = false;
			bool status;
			if (5 != 0)
			{
				status = expr_29;
			}
			string createdBy = ServicePosInfoBusiness.(4703);
			List<GetServiceStatus> list = new List<GetServiceStatus>();
			ServicePosInfoBusiness servicePosInfoBusiness = new ServicePosInfoBusiness();
			new ServiceController(serviceName, systemName);
			list = servicePosInfoBusiness.GetServiceStatusBusiness(systemName, serviceName);
			int num = 0;
			long substoreId = 0L;
			long imixPosDetailId = 0L;
			if (list != null)
			{
				IEnumerable<GetServiceStatus> arg_9A_0 = list;
				if (ServicePosInfoBusiness. == null)
				{
					ServicePosInfoBusiness. = new Func<GetServiceStatus, int>(ServicePosInfoBusiness.);
				}
				num = arg_9A_0.Select(ServicePosInfoBusiness.).FirstOrDefault<int>();
				IEnumerable<GetServiceStatus> arg_C5_0 = list;
				if (ServicePosInfoBusiness. == null)
				{
					ServicePosInfoBusiness. = new Func<GetServiceStatus, long>(ServicePosInfoBusiness.);
				}
				substoreId = arg_C5_0.Select(ServicePosInfoBusiness.).FirstOrDefault<long>();
				IEnumerable<GetServiceStatus> arg_F0_0 = list;
				if (ServicePosInfoBusiness. == null)
				{
					ServicePosInfoBusiness. = new Func<GetServiceStatus, int>(ServicePosInfoBusiness.);
				}
				arg_F0_0.Select(ServicePosInfoBusiness.).FirstOrDefault<int>();
				IEnumerable<GetServiceStatus> arg_11A_0 = list;
				if (ServicePosInfoBusiness. == null)
				{
					ServicePosInfoBusiness. = new Func<GetServiceStatus, long>(ServicePosInfoBusiness.);
				}
				imixPosDetailId = arg_11A_0.Select(ServicePosInfoBusiness.).FirstOrDefault<long>();
			}
			if (-1 != 0)
			{
				int num2 = servicePosInfoBusiness.StartStopServiceByPosIdBusiness((long)num, substoreId, imixPosDetailId, status, createdBy);
			}
		}

		public int UpdateServiceRunLevelBusiness(int _serviceId, int RunLevel, bool isService)
		{
			int result;
			do
			{
				if (false)
				{
					return result;
				}
				int  = RunLevel;
				bool  = isService;
			}
			while (false);
			. = this;
			try
			{
				ServicePosInfoBusiness.  = new ServicePosInfoBusiness.();
				. = ;
				if (6 != 0)
				{
					. = 0;
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
				}
				result = .;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}

		public void StartStopSystemBusiness(string mac, string myIP, string SystemName, int Type)
		{
			BaseBusiness.TransactionMethod transactionMethod;
			while (true)
			{
				if (4 == 0)
				{
					goto IL_1F;
				}
				transactionMethod = null;
				if (4 != 0)
				{
					goto IL_1F;
				}
				IL_28:
				if (7 != 0)
				{
					break;
				}
				continue;
				IL_1F:
				. = SystemName;
				goto IL_28;
			}
			. = Type;
			. = this;
			try
			{
				if (transactionMethod == null)
				{
					transactionMethod = new BaseBusiness.TransactionMethod(.);
				}
				this.operation = transactionMethod;
				base.Start(false);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[CompilerGenerated]
		private static int (GetServiceStatus )
		{
			return .ServiceId;
		}

		[CompilerGenerated]
		private static long (GetServiceStatus )
		{
			return .SubStoreID;
		}

		[CompilerGenerated]
		private static int (GetServiceStatus )
		{
			return .Runlevel;
		}

		[CompilerGenerated]
		private static long (GetServiceStatus )
		{
			return .iMixPosId;
		}

		[CompilerGenerated]
		private static int (GetServiceStatus )
		{
			return .ServiceId;
		}

		[CompilerGenerated]
		private static long (GetServiceStatus )
		{
			return .SubStoreID;
		}

		[CompilerGenerated]
		private static int (GetServiceStatus )
		{
			return .Runlevel;
		}

		[CompilerGenerated]
		private static long (GetServiceStatus )
		{
			return .iMixPosId;
		}

		static ServicePosInfoBusiness()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(ServicePosInfoBusiness));
		}
	}
}
