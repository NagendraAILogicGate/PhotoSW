namespace DigiPhoto.ExtensionMethods
{
    using log4net;
    using log4net.Config;
    using System;

    public class LogConfigurator
    {
        public static ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static LogConfigurator()
        {
            XmlConfigurator.Configure();
        }
    }
}

