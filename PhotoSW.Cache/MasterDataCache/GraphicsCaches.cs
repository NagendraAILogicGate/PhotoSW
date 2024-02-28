using PhotoSW.Cache.DataCache;
using PhotoSW.Cache.Repository;
using PhotoSW.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;

namespace PhotoSW.Cache.MasterDataCache
    {
    public class GraphicsCaches : HashTableCache<List<GraphicsInfo>>, ICacheRepository
        {
        private string strPl = string.Empty;

        internal static GetString getSS;

		public GraphicsCaches ()
            {
            this.strPl = GraphicsCaches.getSS(488);
		}

        public object GetData ()
            {
            List<GraphicsInfo> list = null;
            if(this.Contains(this.strPl))
			{
                list = new List<GraphicsInfo>();
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

        //static GraphicsCaches ()
        //    {
        //    // Note: this type is marked as 'beforefieldinit'.
        //    SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(GraphicsCaches));
        //    }
        }
    }
