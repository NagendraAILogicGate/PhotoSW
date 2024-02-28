using PhotoSW.Cache.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;


namespace PhotoSW.Cache.Cache
    {
    public class CacheHelper
        {
       
        private static Func<Type, bool> cacheYk;

		
        private static Func<Type, ICacheRepository> cacheZk;

		public static void ClearAllCache ()
            {
            IEnumerable<Type> arg_AD_0 = Assembly.GetExecutingAssembly().GetTypes();
            if(CacheHelper.cacheYk == null)
			{
                CacheHelper.cacheYk = new Func<Type, bool>(CacheHelper.Cache0k);
			}
            IEnumerable<Type> arg_B7_0 = arg_AD_0.Where(CacheHelper.cacheYk);
			if(CacheHelper.cacheZk == null)
			{
                CacheHelper.cacheZk = new Func<Type, ICacheRepository>(CacheHelper.Cache2k);
			}
            IEnumerable<ICacheRepository> enumerable = arg_B7_0.Select(CacheHelper.cacheZk);
			if(!false)
                {
                IEnumerator<ICacheRepository> enumerator = enumerable.GetEnumerator();
              //  goto IL_65;
                try
                    {
                    while(true)
                        {
                        IL_65:
                        while(6 != 0)
                            {
                            ICacheRepository current;
                            if(!enumerator.MoveNext())
                                {
                                if(-1 != 0)
                                    {
                                    goto Block_7;
                                    }
                                }
                            else
                                {
                                current = enumerator.Current;
                                }
                            current.RemoveFromCache();
                            }
                        }
                    Block_7:;
                    }
                finally
                    {
                    do
                        {
                        if(false || enumerator != null)
                            {
                            enumerator.Dispose();
                            }
                        }
                    while(3 == 0);
                    }
                }
            }

        [CompilerGenerated]
        private static bool Cache0k(Type type)
		{
			if (4 != 0)
			{
				bool arg_10_0 = type.GetInterfaces().Contains(typeof(ICacheRepository));
				while (arg_10_0 && !false)
				{
					bool expr_49 = arg_10_0 = (type.GetConstructor(Type.EmptyTypes) != null);
					if (!false)
					{
						return expr_49;
					}
    }
			}
			return false;
		}

		[CompilerGenerated]
        private static ICacheRepository Cache2k(Type type)
		        {
			        return Activator.CreateInstance(type) as ICacheRepository;
		        }
	       }
    }
