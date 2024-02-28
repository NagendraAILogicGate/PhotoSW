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
    public class ValueTypeCache : HashTableCache<List<ValueTypeInfo>>, ICacheRepository
        {
        private string strPl = string.Empty;

        [NonSerialized]
        internal static GetString getACK;

		public ValueTypeCache ()
            {
            this.strPl = ValueTypeCache.getACK(377);
		}

        public object GetData ()
            {
            List<ValueTypeInfo> list;
            while(true)
                {
                list = null;
                while(true)
                    {
                    bool arg_11_0 = this.Contains(this.strPl);
					while(true)
                        {
                        if(!false)
                            {
                            if(arg_11_0)
                                {
                                list = new List<ValueTypeInfo>();
                                }
                            else
                                {
                             //   list = new ValueTypeDao().SelectValueTypeList();
                                if(true)
                                    {
                                    goto Block_4;
                                    }
                                }
                            if(false)
                                {
                                break;
                                }
                            arg_11_0 = this.GetFromCache(this.strPl, out list);
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
                this.AddToCache(this.strPl, list);
				goto IL_48;
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

        //static ValueTypeCache ()
        //    {
        //    // Note: this type is marked as 'beforefieldinit'.
        //    SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(ValueTypeCache));
        //    }
        }
    }
