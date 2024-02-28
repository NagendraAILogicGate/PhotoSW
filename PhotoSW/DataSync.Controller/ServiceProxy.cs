using PhotoSW.Common;
using PhotoSW.DataLayer;
using PhotoSW.IMIX.Business;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.ServiceModel;

namespace PhotoSW.DataSync.Controller
{
	public class ServiceProxy<T>
	{
		
		private static class SiteContainer
		{
			public static CallSite<Func<CallSite, object, TransferMode, object>> Site1;

			public static CallSite<Func<CallSite, object, SecurityMode, object>> Site2;

			public static CallSite<Func<CallSite, object, object>> Site3;

			public static CallSite<Func<CallSite, object, long, object>> Site4;

			public static CallSite<Func<CallSite, object, int, object>> Site5;

			public static CallSite<Func<CallSite, object, object>> Site6;

			public static CallSite<Func<CallSite, object, int, object>> Site7;

			public static CallSite<Func<CallSite, object, object>> Site8;

			public static CallSite<Func<CallSite, object, int, object>> Site9;

			public static CallSite<Func<CallSite, object, TimeSpan, object>> Sitea;

			public static CallSite<Func<CallSite, object, TimeSpan, object>> Siteb;

			public static CallSite<Func<CallSite, object, TimeSpan, object>> Sitec;

			public static CallSite<Func<CallSite, object, TimeSpan, object>> Sited;

			public static CallSite<Func<CallSite, Type, object, EndpointAddress, ChannelFactory<T>>> Sitee;
		}

		public static void Use(Action<T> action)
		{
			if (string.IsNullOrEmpty(App.DataSyncServiceURl))
			{
				App.DataSyncServiceURl = new ConfigBusiness().GetOnlineConfigData(ConfigParams.DgServiceURL, LoginUser.SubStoreId);
				if (App.DataSyncServiceURl != null)
				{
					App.DataSyncServiceURl = App.DataSyncServiceURl.Trim();
				}
			}
			string text = App.DataSyncServiceURl;
			object obj;
			if (text.ToLower().Contains("net.tcp"))
			{
				obj = new NetTcpBinding();
				if (false)
				{
					goto IL_5A2;
				}
				if (ServiceProxy<T>.SiteContainer.Site1 == null)
				{
					ServiceProxy<T>.SiteContainer.Site1 = CallSite<Func<CallSite, object, TransferMode, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "TransferMode", typeof(ServiceProxy<T>), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				ServiceProxy<T>.SiteContainer.Site1.Target(ServiceProxy<T>.SiteContainer.Site1, obj, TransferMode.StreamedResponse);
				if (ServiceProxy<T>.SiteContainer.Site2 == null)
				{
					ServiceProxy<T>.SiteContainer.Site2 = CallSite<Func<CallSite, object, SecurityMode, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Mode", typeof(ServiceProxy<T>), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Func<CallSite, object, SecurityMode, object> arg_18C_0 = ServiceProxy<T>.SiteContainer.Site2.Target;
				CallSite arg_18C_1 = ServiceProxy<T>.SiteContainer.Site2;
				if (ServiceProxy<T>.SiteContainer.Site3 == null)
				{
					ServiceProxy<T>.SiteContainer.Site3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Security", typeof(ServiceProxy<T>), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				arg_18C_0(arg_18C_1, ServiceProxy<T>.SiteContainer.Site3.Target(ServiceProxy<T>.SiteContainer.Site3, obj), SecurityMode.None);
			}
			else
			{
				obj = new BasicHttpBinding();
			}
			if (typeof(T).Name.StartsWith("I"))
			{
				text = text + "/" + typeof(T).Name.Substring(1) + ".svc";
			}
			else
			{
				text = text + "/" + typeof(T).Name + ".svc";
			}
			EndpointAddress arg = new EndpointAddress(text);
			string value = string.Empty;
			if (ConfigurationManager.AppSettings["ServiceDataSize"] == null)
			{
				value = Convert.ToString(67107840);
			}
			else
			{
				value = ConfigurationManager.AppSettings["ServiceDataSize"];
			}
			if (ServiceProxy<T>.SiteContainer.Site4 == null)
			{
				ServiceProxy<T>.SiteContainer.Site4 = CallSite<Func<CallSite, object, long, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "MaxReceivedMessageSize", typeof(ServiceProxy<T>), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			ServiceProxy<T>.SiteContainer.Site4.Target(ServiceProxy<T>.SiteContainer.Site4, obj, Convert.ToInt64(value));
			if (ServiceProxy<T>.SiteContainer.Site5 == null)
			{
				ServiceProxy<T>.SiteContainer.Site5 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "MaxArrayLength", typeof(ServiceProxy<T>), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			Func<CallSite, object, int, object> arg_367_0 = ServiceProxy<T>.SiteContainer.Site5.Target;
			CallSite arg_367_1 = ServiceProxy<T>.SiteContainer.Site5;
			if (ServiceProxy<T>.SiteContainer.Site6 == null)
			{
				ServiceProxy<T>.SiteContainer.Site6 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "ReaderQuotas", typeof(ServiceProxy<T>), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			arg_367_0(arg_367_1, ServiceProxy<T>.SiteContainer.Site6.Target(ServiceProxy<T>.SiteContainer.Site6, obj), Convert.ToInt32(value));
			if (ServiceProxy<T>.SiteContainer.Site7 == null)
			{
				if (false)
				{
					goto IL_5C7;
				}
				ServiceProxy<T>.SiteContainer.Site7 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "MaxStringContentLength", typeof(ServiceProxy<T>), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			Func<CallSite, object, int, object> arg_422_0 = ServiceProxy<T>.SiteContainer.Site7.Target;
			CallSite arg_422_1 = ServiceProxy<T>.SiteContainer.Site7;
			if (ServiceProxy<T>.SiteContainer.Site8 == null)
			{
				ServiceProxy<T>.SiteContainer.Site8 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "ReaderQuotas", typeof(ServiceProxy<T>), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			arg_422_0(arg_422_1, ServiceProxy<T>.SiteContainer.Site8.Target(ServiceProxy<T>.SiteContainer.Site8, obj), Convert.ToInt32(value));
			if (ServiceProxy<T>.SiteContainer.Site9 == null)
			{
				ServiceProxy<T>.SiteContainer.Site9 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "MaxBufferSize", typeof(ServiceProxy<T>), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			ServiceProxy<T>.SiteContainer.Site9.Target(ServiceProxy<T>.SiteContainer.Site9, obj, Convert.ToInt32(value));
			if (ServiceProxy<T>.SiteContainer.Sitea != null)
			{
				goto IL_4D4;
			}
			IL_493:
			ServiceProxy<T>.SiteContainer.Sitea = CallSite<Func<CallSite, object, TimeSpan, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "OpenTimeout", typeof(ServiceProxy<T>), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
			}));
			IL_4D4:
			ServiceProxy<T>.SiteContainer.Sitea.Target(ServiceProxy<T>.SiteContainer.Sitea, obj, new TimeSpan(0, 0, 10));
			if (ServiceProxy<T>.SiteContainer.Siteb != null)
			{
				goto IL_53B;
			}
			int arg_52A_0 = 0;
			IL_4FB:
			ServiceProxy<T>.SiteContainer.Siteb = CallSite<Func<CallSite, object, TimeSpan, object>>.Create(Binder.SetMember((CSharpBinderFlags)arg_52A_0, "CloseTimeout", typeof(ServiceProxy<T>), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
			}));
			IL_53B:
			ServiceProxy<T>.SiteContainer.Siteb.Target(ServiceProxy<T>.SiteContainer.Siteb, obj, new TimeSpan(0, 0, 10));
			if (ServiceProxy<T>.SiteContainer.Sitec == null)
			{
				ServiceProxy<T>.SiteContainer.Sitec = CallSite<Func<CallSite, object, TimeSpan, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "SendTimeout", typeof(ServiceProxy<T>), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			IL_5A2:
			if (false)
			{
				goto IL_493;
			}
			ServiceProxy<T>.SiteContainer.Sitec.Target(ServiceProxy<T>.SiteContainer.Sitec, obj, new TimeSpan(0, 0, 90));
			IL_5C7:
			if (ServiceProxy<T>.SiteContainer.Sited == null)
			{
				int expr_5CF = arg_52A_0 = 0;
				if (expr_5CF != 0)
				{
					goto IL_4FB;
				}
				ServiceProxy<T>.SiteContainer.Sited = CallSite<Func<CallSite, object, TimeSpan, object>>.Create(Binder.SetMember((CSharpBinderFlags)expr_5CF, "ReceiveTimeout", typeof(ServiceProxy<T>), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			ServiceProxy<T>.SiteContainer.Sited.Target(ServiceProxy<T>.SiteContainer.Sited, obj, new TimeSpan(0, 0, 10));
			if (ServiceProxy<T>.SiteContainer.Sitee == null)
			{
				ServiceProxy<T>.SiteContainer.Sitee = CallSite<Func<CallSite, Type, object, EndpointAddress, ChannelFactory<T>>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof(ServiceProxy<T>), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			ChannelFactory<T> channelFactory = ServiceProxy<T>.SiteContainer.Sitee.Target(ServiceProxy<T>.SiteContainer.Sitee, typeof(ChannelFactory<T>), obj, arg);
			T t = channelFactory.CreateChannel();
			bool flag = false;
			try
			{
				action(t);
				((IClientChannel)((object)t)).Close();
				channelFactory.Close();
				flag = true;
			}
			catch (CommunicationException ex)
			{
				throw ex;
			}
			catch (TimeoutException ex2)
			{
				throw ex2;
			}
			catch (Exception ex3)
			{
				throw ex3;
			}
			finally
			{
				if (!flag)
				{
					((IClientChannel)((object)t)).Abort();
					channelFactory.Abort();
				}
			}
		}
	}
}
