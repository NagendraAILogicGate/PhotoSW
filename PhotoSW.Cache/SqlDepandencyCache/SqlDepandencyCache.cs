using PhotoSW.IMIX.DataAccess;
using PhotoSW.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.Caching;
using System.Threading;

namespace PhotoSW.Cache.SqlDepandencyCache
    {
    public class SqlDepandencyCache
        {
        private const string Ql = "ConfigurationCache";


        private const string Rl = "NewConfigCache";


        private static ObjectCache objSl;

        private static SqlDependency sqlDependencyTl;

        private static SqlDependency sqlDependencyUl;

        private static SqlChangeMonitor sqlChangeVl;

        private static SqlChangeMonitor sqlChangeWl;

        private static CacheItemPolicy cacheXl;

        private static CacheItemPolicy cacheYl;

        private static object objZl;

        private static object obj0l;

        internal static GetString getHOP;

        private static int RefreshCacheTimeInMinitues
            {
            get
                {
                int result;
                try
                    {
                    do
                        {
                        result = Convert.ToInt32(ConfigurationManager.AppSettings[SqlDepandencyCache.getHOP(708)].ToString());
                        }
                    while(false);
                    }
                catch(Exception)
                    {
                    do
                        {
                        if(7 != 0)
                            {
                            result = 10;
                            }
                        }
                    while(false);
                    }
                return result;
                }
            }

        private SqlDepandencyCache ()
            {
            }

        private static void getCache_1l ()
            {
            try
                {
                if(SqlDepandencyCache.objSl == null)
                    {
                    SqlDepandencyCache.objSl = MemoryCache.Default;
                    }
                }
            catch(Exception)
                {

                }
            }

        private static CacheItemPolicy cacheItemPolicy_3l ( SqlChangeMonitor Vl )
            {
            if(4 != 0)
                {
                if(SqlDepandencyCache.cacheXl == null && 3 != 0)
                    {
                    SqlDepandencyCache.cacheXl = new CacheItemPolicy();
                    }
                SqlDepandencyCache.cacheXl.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes((double)SqlDepandencyCache.RefreshCacheTimeInMinitues);
                }
            return SqlDepandencyCache.cacheXl;
            }

        private static CacheItemPolicy cacheItemPolicy_4l ( SqlChangeMonitor Vl )
            {
            if(4 != 0)
                {
                if(SqlDepandencyCache.cacheYl == null && 3 != 0)
                    {
                    SqlDepandencyCache.cacheYl = new CacheItemPolicy();
                    }
                SqlDepandencyCache.cacheYl.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes((double)SqlDepandencyCache.RefreshCacheTimeInMinitues);
                }
            return SqlDepandencyCache.cacheYl;
            }

        private static void cache_5l ( CacheEntryUpdateArguments CacheEntryUpdateArguments_6l )
            {
            try
                {
                string expr_45 = CacheEntryUpdateArguments_6l.Key;
                string key;
                if(!false)
                    {
                    key = expr_45;
                    }
                if(-1 == 0)
                    {
                    goto IL_3D;
                    }
                SqlDepandencyCache.objSl.Remove(key, null);
                IL_16:
                //List<iMIXConfigurationInfo> allNewConfigValues = new ConfigurationDao().GetAllNewConfigValues();
                if(!false)
                    {
                    //  CacheEntryUpdateArguments_6l.UpdatedCacheItem = new CacheItem(key, allNewConfigValues);
                    CacheEntryUpdateArguments_6l.UpdatedCacheItemPolicy = SqlDepandencyCache.cacheItemPolicy_4l(SqlDepandencyCache.sqlChangeVl);
                    }
                IL_3D:
                if(-1 == 0)
                    {
                    goto IL_16;
                    }
                }
            catch(Exception)
                {
                }
            }

        private static void RefreshCacheData ( CacheEntryUpdateArguments CacheEntryUpdateArguments_6l )
            {
            string key;
            if(!false)
                {
                string expr_47 = CacheEntryUpdateArguments_6l.Key;
                if(!false)
                    {
                    key = expr_47;
                    }
                SqlDepandencyCache.objSl.Remove(key, null);
                }
            do
                {
                if(!false)
                    {
                    // List<ConfigurationInfo> allConfigurationSetting = new ConfigurationDao().GetAllConfigurationSetting();
                    //  CacheEntryUpdateArguments_6l.UpdatedCacheItem = new CacheItem(key, allConfigurationSetting);
                    }
                CacheEntryUpdateArguments_6l.UpdatedCacheItemPolicy = SqlDepandencyCache.cacheItemPolicy_3l(SqlDepandencyCache.sqlChangeVl);
                }
            while(false || false);
            }

        private static void cache_7l ( object obj_8l, SqlNotificationEventArgs SqlNotificationEventArgs_6l )
            {
            SqlDependency sqlDependency = obj_8l as SqlDependency;
            sqlDependency.OnChange -= new OnChangeEventHandler(SqlDepandencyCache.cache_7l);
            }

        private static void cache_9l ( object obj_8l, SqlNotificationEventArgs SqlNotificationEventArgs_6l )
            {
            SqlDependency sqlDependency = obj_8l as SqlDependency;
            sqlDependency.OnChange -= new OnChangeEventHandler(SqlDepandencyCache.cache_9l);
            }

        public static List<ConfigurationInfo> GetAllConfigurationSetting ()
            {
            List<ConfigurationInfo> result;
            if(true)
                {
                bool expr_06 = false;
                bool flag;
                if(!false)
                    {
                    flag = expr_06;
                    }
                try
                    {
                    List<ConfigurationInfo> allConfigurationSetting;
                    if(!false)
                        {
                        object obj;
                        Monitor.Enter(obj = SqlDepandencyCache.objZl, ref flag);
                        SqlDepandencyCache.getCache_1l();
                        while(!SqlDepandencyCache.objSl.Contains(SqlDepandencyCache.getHOP(745), null))
                            {
                            //  allConfigurationSetting = new ConfigurationDao().GetAllConfigurationSetting();
                            SqlDepandencyCache.cacheXl = SqlDepandencyCache.cacheItemPolicy_3l(SqlDepandencyCache.sqlChangeVl);
                            do
                                {
                                if(SqlDepandencyCache.objSl.Contains(SqlDepandencyCache.getHOP(745), null))
                                    {
                                    SqlDepandencyCache.objSl.Remove(SqlDepandencyCache.getHOP(745), null);
                                    }
                                }
                            while(2 == 0);
                            //    if(!false)
                            //                {
                            //                SqlDepandencyCache.objSl.Add(SqlDepandencyCache.getHOP(745), allConfigurationSetting, SqlDepandencyCache.cacheXl, null);
                            //goto IL_EE;
                            //                }
                            }
                        do
                            {
                            result = (SqlDepandencyCache.objSl.Get(SqlDepandencyCache.getHOP(745), null) as List<ConfigurationInfo>);
                            }
                        while(false);
                        return result;
                        }
                    // IL_EE:
                    //  result = allConfigurationSetting;
                    }
                finally
                    {
                    //if(flag)
                    //    {
                    //    object obj;
                    //    Monitor.Exit(obj);
                    //    }
                    }
                }
            // return result;
            }

        public static void ClearCacheAllConfigurationSetting ()
            {
            if(SqlDepandencyCache.objSl.Contains(SqlDepandencyCache.getHOP(745), null))
                {
                SqlDepandencyCache.objSl.Remove(SqlDepandencyCache.getHOP(745), null);
                }
            }

        public static void ClearCacheNewConfigValues ()
            {
            if(SqlDepandencyCache.objSl.Contains(SqlDepandencyCache.getHOP(770), null))
                {
                SqlDepandencyCache.objSl.Remove(SqlDepandencyCache.getHOP(770), null);
                }
            }

        public static List<iMIXConfigurationInfo> GetNewConfigValues ()
            {
            List<iMIXConfigurationInfo> result;
            if(true)
                {
                bool expr_06 = false;
                bool flag;
                if(!false)
                    {
                    flag = expr_06;
                    }
                try
                    {
                    List<iMIXConfigurationInfo> allNewConfigValues;
                    if(!false)
                        {
                        object obj;
                        Monitor.Enter(obj = SqlDepandencyCache.obj0l, ref flag);
                        SqlDepandencyCache.getCache_1l();
                        while(!SqlDepandencyCache.objSl.Contains(SqlDepandencyCache.getHOP(770), null))
                            {
                            //    allNewConfigValues = new ConfigurationDao().GetAllNewConfigValues();
                            SqlDepandencyCache.cacheYl = SqlDepandencyCache.cacheItemPolicy_4l(SqlDepandencyCache.sqlChangeWl);
                            do
                                {
                                if(SqlDepandencyCache.objSl.Contains(SqlDepandencyCache.getHOP(770), null))
                                    {
                                    SqlDepandencyCache.objSl.Remove(SqlDepandencyCache.getHOP(770), null);
                                    }
                                }
                            while(2 == 0);
                            //            if(!false)
                            //                {
                            //                SqlDepandencyCache.objSl.Add(SqlDepandencyCache.getHOP(770), allNewConfigValues, SqlDepandencyCache.cacheYl, null);
                            //goto IL_EE;
                            //                }
                            }
                        do
                            {
                            result = (SqlDepandencyCache.objSl.Get(SqlDepandencyCache.getHOP(770), null) as List<iMIXConfigurationInfo>);
                            }
                        while(false);
                        return result;
                        }
                    // IL_EE:
                    // result = allNewConfigValues;
                    }
                finally
                    {
                    //if(flag)
                    //    {
                    //    object obj;
                    //    Monitor.Exit(obj);
                    //    }
                    }
                }
            //   return result;

            }

        public static void UpdateCacheAllConfigurationSetting ()
            {
            if(SqlDepandencyCache.objSl.Contains(SqlDepandencyCache.getHOP(745), null))
                {
                SqlDepandencyCache.objSl.Remove(SqlDepandencyCache.getHOP(745), null);
                }
            }

        public static void UpdateCacheNewConfigValues ()
            {
            if(SqlDepandencyCache.objSl.Contains(SqlDepandencyCache.getHOP(770), null))
                {
                SqlDepandencyCache.objSl.Remove(SqlDepandencyCache.getHOP(770), null);
                }
            }

        public static List<iMIXStoreConfigurationInfo> GetAllReportConfiguration ()
            {
            List<iMIXStoreConfigurationInfo> result;
            if(-1 != 0)
                {
                bool expr_03 = false;
                bool flag;
                if(4 != 0)
                    {
                    flag = expr_03;
                    }
                try
                    {
                    object obj;
                    object expr_0D = obj = SqlDepandencyCache.objZl;
                    if(!false)
                        {
                        Monitor.Enter(expr_0D, ref flag);
                        }
                    SqlDepandencyCache.getCache_1l();
                    List<iMIXStoreConfigurationInfo> list;
                    if(!false)
                        {
                        List<iMIXStoreConfigurationInfo> expr_42 = null; //new ConfigurationDao().GetAllReportConfiguration();
                        if(!false)
                            {
                            list = expr_42;
                            }
                        }
                    result = list;
                    }
                finally
                    {
                    //if(!false && !false && flag)
                    //    {
                    //    object obj;
                    //    Monitor.Exit(obj);
                    //    }
                    //}
                    }
                return result;
                }

            //static SqlDepandencyCache ()
            //    {
            //    // Note: this type is marked as 'beforefieldinit'.
            //    SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(SqlDepandencyCache));
            //    SqlDepandencyCache.#Zl = new object();
            //   SqlDepandencyCache.#0l = new object();
            //  }

            }

        }
    }
