﻿using PhotoSW.Cache.DataCache;
using PhotoSW.Cache.Repository;
using PhotoSW.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;

namespace PhotoSW.Cache.MasterDataCache
    {
    public class LocationCache : HashTableCache<List<LocationInfo>>, ICacheRepository
        {
        private string strPl = string.Empty;

        internal static GetString getSOH;

		public LocationCache ()
            {
            this.strPl = LocationCache.getSOH(576);
		}

        public object GetData ()
            {
            List<LocationInfo> list = null;
            if(this.Contains(this.strPl))
			{
                list = new List<LocationInfo>();
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

        //static LocationCache ()
        //    {
        //    // Note: this type is marked as 'beforefieldinit'.
        //    SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(LocationCache));
        //    }
        }
    }
