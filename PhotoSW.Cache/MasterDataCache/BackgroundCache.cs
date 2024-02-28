using PhotoSW.Cache.DataCache;
using PhotoSW.Cache.Repository;
using PhotoSW.IMIX.DataAccess;
using PhotoSW.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;

namespace PhotoSW.Cache.MasterDataCache
    {
    public delegate string GetString ( int i );
    public class BackgroundCache : HashTableCache<List<BackGroundInfo>>, ICacheRepository
        {
        private string str_Pl = string.Empty;

        internal static GetString DCS;
		public BackgroundCache ()
            {
            this.str_Pl = BackgroundCache.DCS(465);
		}

        public object GetData ()
            {
            List<BackGroundInfo> list;
            while(true)
                {
                list = null;
                while(true)
                    {
                    bool arg_11_0 = this.Contains(this.str_Pl);
					while(true)
                        {
                        if(!false)
                            {
                            if(arg_11_0)
                                {
                                list = new List<BackGroundInfo>();
                                }
                            else
                                {
                                list = new BackGroundDao().SelectBackground();
                                if(true)
                                    {
                                    goto Block_4;
                                    }
                                }
                            if(false)
                                {
                                break;
                                }
                            arg_11_0 = this.GetFromCache(this.str_Pl, out list);
						}
                        if(!false)
                            {
                            goto Block_3;
                            }
                        }
                    }
                IL_48:
                if(2 != 0)
                    {
                    break;
                    }
                continue;
                Block_3:
                goto IL_48;
                Block_4:
                this.AddToCache(this.str_Pl, list);
				goto IL_48;
                }
            return list;
            }

        public void RemoveFromCache ()
            {
            this.RemoveFromCache(this.str_Pl);
		}

        public void CleanData ()
            {
            this.CleanData();
            }

        //static BackgroundCache ()
        //    {
        //    // Note: this type is marked as 'beforefieldinit'.
        //    SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(BackgroundCache));
        //    }
        }
    }
