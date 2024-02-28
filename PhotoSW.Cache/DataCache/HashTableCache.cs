
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace PhotoSW.Cache.DataCache
    {
    public class HashTableCache<T> : CacheProvider<Hashtable, T>
        {
        private static object obj5k = new object();

		private static Hashtable hashtable6k = null;

		protected override Hashtable InitCache ()
            {
            do
                {
                bool flag = false;
                try
                    {
                    object obj;
                    Monitor.Enter(obj = HashTableCache<T>.obj5k, ref flag);
					if(HashTableCache<T>.hashtable6k == null)
					{
                        HashTableCache<T>.hashtable6k = new Hashtable();
						if(8 != 0)
                            {
                            if(!false)
                                {
                                this.Cache = HashTableCache<T>.hashtable6k;
								goto IL_49;
                                }
                            goto IL_49;
                            }
                        }
                    if(this.Cache == null)
                        {
                        this.Cache = HashTableCache<T>.hashtable6k;
					}
                    IL_49:;
                    }
                finally
                    {
                    if(!false && (4 == 0 || flag))
                        {
                        //object obj;
                        //Monitor.Exit(obj);
                        }
                    }
                }
            while(false);
            return this.Cache;
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

        public override void AddToCache ( string key, T value )
            {
            do
                {
                bool flag = false;
                try
                    {
                    object obj;
                    Monitor.Enter(obj = HashTableCache<T>.obj5k, ref flag);
					while(!this.Cache.ContainsKey(key))
                        {
                        if(!false)
                            {
                            if(7 == 0)
                                {
                                break;
                                }
                            if(!false)
                                {
                                this.Cache.Add(key, value);
                                break;
                                }
                            }
                        }
                    }
                finally
                    {
                    if(false || flag)
                        {
                        //object obj;
                        //Monitor.Exit(obj);
                        }
                    }
                }
            while(!true);
            }

        public override void AddToCache ( string key, T value, int duration )
            {
            do
                {
                bool flag = false;
                try
                    {
                    object obj;
                    Monitor.Enter(obj = HashTableCache<T>.obj5k, ref flag);
					if(!this.Cache.ContainsKey(key))
                        {
                        do
                            {
                            TimeSpan.FromMinutes((double)duration);
                            }
                        while(false);
                        this.Cache.Add(key, value);
                        }
                    }
                finally
                    {
                    while(true)
                        {
                        if(!flag)
                            {
                            goto IL_6D;
                            }
                        IL_64:
                        if(false)
                            {
                            continue;
                            }
                        ////object obj;
                        ////Monitor.Exit(obj);
                        IL_6D:
                        if(!false)
                            {
                            break;
                            }
                        goto IL_64;
                        }
                    }
                }
            while(5 == 0 || 6 == 0);
            }

        public override void RemoveFromCache ( string key )
            {
            this.Cache.Remove(key);
            }

        public override bool Contains ( string key )
            {
            return this.Cache.ContainsKey(key);
            }

        public override int Count ()
            {
            return this.Cache.Count;
            }

        public override IEnumerable<KeyValuePair<string, object>> GetAll ()
            {
            HashTableCache<T>.pm pm = new HashTableCache<T>.pm(-2);
            pm.dm = this;
            ///////Need to implement
            yield return new KeyValuePair<string, object>("str_test_key", pm.dm);
        
            }

        public class pm
            {
            internal HashTableCache<T> dm;
            private int v;

            public pm ( int v )
                {
                this.v = v;
                }
            }

       
        }
    }
