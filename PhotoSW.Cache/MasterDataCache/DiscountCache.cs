using PhotoSW.Cache.DataCache;
using PhotoSW.Cache.Repository;
using PhotoSW.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;


namespace PhotoSW.Cache.MasterDataCache
    {
    public class DiscountCache : HashTableCache<List<DiscountTypeInfo>>, ICacheRepository
        {
        private string strPl = string.Empty;

        [NonSerialized]
        internal static GetString getHTJ;

		public DiscountCache ()
            {
            this.strPl = DiscountCache.getHTJ(427);
		}

        public object GetData ()
            {
            List<DiscountTypeInfo> list = null;
            if(this.Contains(this.strPl))
			{
                list = new List<DiscountTypeInfo>();
                this.GetFromCache(this.strPl, out list);
			}
            else
                {
                this.AddToCache(this.strPl, list);
			}
            return list;
            }

        public void RemoveFromCache ()
            {
            this.RemoveFromCache(this.strPl);
		}

        public void CleanData ()
            {
            this.CleanData();
            }

        //static DiscountCache ()
        //    {
        //    // Note: this type is marked as 'beforefieldinit'.
        //    SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(DiscountCache));
        //    }
        }
    }
