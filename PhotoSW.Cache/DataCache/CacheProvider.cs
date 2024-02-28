using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace PhotoSW.Cache.DataCache
    {
    public abstract class CacheProvider<TCache, T> : ICacheProvider<string, T>
        {
       // private readonly int 3k = 30;
       private readonly int int3k = 30;

		protected TCache Cache;               

        private int int4k;

		public int CacheDuration
            {
            get;
            set;
            }

        public CacheProvider ()
            {
            this.CacheDuration = this.int3k;
			this.Cache = this.InitCache();
            }

        public CacheProvider ( int durationInMinutes )
            {
            this.CacheDuration = durationInMinutes;
            this.Cache = this.InitCache();
            }

        protected abstract TCache InitCache ();

        public abstract bool GetFromCache ( string key, out T value );

        public abstract void AddToCache ( string key, T value );

        public abstract void AddToCache ( string key, T value, int duration );

        public abstract void RemoveFromCache ( string key );

        public abstract bool Contains ( string key );

        public abstract int Count ();

        public abstract IEnumerable<KeyValuePair<string, object>> GetAll ();
        }
    }
