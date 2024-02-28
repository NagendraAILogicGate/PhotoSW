using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.Cache.DataCache
    {
    public interface ICacheProvider<TKey, TValue>
        {
        void AddToCache ( TKey key, TValue value );

        void AddToCache ( TKey key, TValue value, int duration );

        void RemoveFromCache ( TKey key );

        bool Contains ( TKey key );

        int Count ();

        bool GetFromCache ( TKey key, out TValue value );

        }
    }
