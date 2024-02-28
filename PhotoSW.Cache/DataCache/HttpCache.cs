using PhotoSW.Cache.Data;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.Caching;

namespace PhotoSW.Cache.DataCache
    {
    public abstract class HttpCache<T> : CacheProvider<System.Web.Caching.Cache, T>
        {
        private TimeSpan timeSpan7k = default(TimeSpan);

		private static object obj8k = new object();

		public HttpCache ()
            {

            }

        protected override System.Web.Caching.Cache InitCache ()
            {
            this.timeSpan7k = TimeSpan.FromMinutes((double)RepositoryData.CacheExpirationInMinute);
			return HttpRuntime.Cache;
            }

        public override void AddToCache ( string key, T value )
            {
            do
                {
                bool flag = false;
                try
                    {
                    if(!false)
                        {
                        object obj;
                        Monitor.Enter(obj = HttpCache<T>.obj8k, ref flag);
						int arg_45_0 = RepositoryData.CacheExpirationInMinute;
                        int num;
                        int expr_22;
                        do
                            {
                            num = arg_45_0;
                            if(!false && num != 0)
                                {
                                goto IL_27;
                                }
                            expr_22 = (arg_45_0 = 30);
                            }
                        while(expr_22 == 0);
                        num = expr_22;
                        IL_27:
                        this.AddToCache(key, value, num);
                        }
                    }
                finally
                    {
                    //if(false || flag)
                    //    {
                    //    object obj;
                    //    Monitor.Exit(obj);
                    //    }
                    }
                }
            while(false);
            }

        public override void AddToCache ( string key, T value, int duration )
            {
            lock (HttpCache<T>.obj8k)
			{
                TimeSpan slidingExpiration = TimeSpan.FromMinutes((double)duration);
                this.Cache.Insert(key, value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, slidingExpiration, CacheItemPriority.Normal, new CacheItemRemovedCallback(this.Cache9k));
			}
            }

        private void Cache9k(string stral, object objbl, CacheItemRemovedReason cacheItem_cl)
		{
			this.RefreshCacheData ();
        }

    protected virtual void RefreshCacheData ()
        {
        }

    public override void RemoveFromCache ( string key )
        {
        this.Cache.Remove(key);
        }

    public override bool Contains ( string key )
        {
        return this.Cache.Get(key) != null;
        }

    public override int Count ()
        {
        return this.Cache.Count;
        }

    public override bool GetFromCache ( string key, out T value )
        {
        bool flag;
        try
            {
            do
                {
                if(this.Cache[key] != null)
                    {
                    value = (T)((object)this.Cache[key]);
                    if(!false)
                        {
                        goto Block_4;
                        }
                    }
                value = default(T);
                flag = false;
                }
            while(false);
            goto IL_73;
            Block_4:;
            }
        catch
            {
            do
                {
                value = default(T);
                flag = false;
                }
            while(false);
            goto IL_73;
            }
        int arg_74_0;
        if(4 != 0)
            {
            int expr_6F = arg_74_0 = 1;
            if(expr_6F != 0)
                {
                return expr_6F != 0;
                }
            return arg_74_0 != 0;
            }
        IL_73:
        arg_74_0 = (flag ? 1 : 0);
        return arg_74_0 != 0;
        }
        public override IEnumerable<KeyValuePair<string, object>> GetAll ()
            {
            HttpCache<T>.pm pm = new HttpCache<T>.pm(-2);
            pm.dm = this;
            ///////Need to implement
            yield return new KeyValuePair<string, object>("str_test_key", pm.dm);
            

            }

        private class pm
            {
            internal HttpCache<T> dm;
            private int v;

            public pm ( int v )
                {
                this.v = v;
                }
            }


        //      public override IEnumerable<KeyValuePair<string, object>> GetAll ()
        //          {
        //          HttpCache<T> tm = new HttpCache<T>();
        //	tm = this;
        //	return tm;
        //}
        }
}
