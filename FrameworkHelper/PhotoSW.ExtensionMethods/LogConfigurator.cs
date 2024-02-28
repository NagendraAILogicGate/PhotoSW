using log4net;
using log4net.Config;
using System;
using System.Reflection;

namespace PhotoSW.ExtensionMethods
{
	public class LogConfigurator
	{
		public static ILog log;

		static LogConfigurator()
		{
			LogConfigurator.log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
			XmlConfigurator.Configure();
		}
	}
}
