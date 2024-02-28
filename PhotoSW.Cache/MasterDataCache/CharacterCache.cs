using PhotoSW.Cache.DataCache;
using PhotoSW.Cache.Repository;
using PhotoSW.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;

namespace PhotoSW.Cache.MasterDataCache
    {
    public class CharacterCache : HashTableCache<List<CharacterInfo>>, ICacheRepository
        {
        private string strPl = string.Empty;

        internal static GetString SYN;

		public CharacterCache ()
            {
            this.strPl = CharacterCache.SYN(324);
		}

        public object GetData ()
            {
            List<CharacterInfo> list = null;
            if(this.Contains(this.strPl))
			{
                list = new List<CharacterInfo>();
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

        //static CharacterCache ()
        //    {
        //    // Note: this type is marked as 'beforefieldinit'.
        //    SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(CharacterCache));
        //    }
        }
    }
