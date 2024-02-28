using PhotoSW.Cache.DataCache;
using PhotoSW.Cache.Repository;
using PhotoSW.IMIX.Model;
////using SmartAssembly.Delegates;
////using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;

namespace PhotoSW.Cache.MasterDataCache
    {
    public class UserCache : HashTableCache<List<UserInfo>>, ICacheRepository
        {
        private string strPl = string.Empty;

        internal static GetString getSSA;

		public UserCache ()
            {
            this.strPl = UserCache.getSSA(595);
		}

        public object GetData ()
            {
            List<UserInfo> list = null;
            if(this.Contains(this.strPl))
			{
                list = new List<UserInfo>();
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

        //static UserCache ()
        //    {
        //    // Note: this type is marked as 'beforefieldinit'.
        //    SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(UserCache));
        //    }
        }
    }
