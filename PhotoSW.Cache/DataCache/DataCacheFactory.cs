//using #kl;
using PhotoSW.Cache.MasterDataCache;
using PhotoSW.Cache.Repository;
using System;
using System.Runtime.CompilerServices;


namespace PhotoSW.Cache.DataCache
    {
    public static class DataCacheFactory
        {
       
        private static Func<ICacheRepository> cache_ll;
		
         private static Func<ICacheRepository> cache_ml;
		
         private static Func<ICacheRepository> cache_nl;

         private static Func<ICacheRepository> cache_ol;

         private static Func<ICacheRepository> cache_pl;

         private static Func<ICacheRepository> cache_ql;

         private static Func<ICacheRepository> cache_rl;

         private static Func<ICacheRepository> cache_sl;

         private static Func<ICacheRepository> cache_tl;

         private static Func<ICacheRepository> cache_ul;

         private static Func<ICacheRepository> cache_vl;

         private static Func<ICacheRepository> cache_wl;

         private static Func<ICacheRepository> cache_xl;

         private static Func<ICacheRepository> cache_yl;

         private static Func<ICacheRepository> cache_zl;

		public static ICacheRepository GetFactory<T> ( string cacheType )
            {
            if(true)
                {
                string arg_0C_0 = typeof(T).FullName;
                }
            T t = jl<T>.fl(cacheType);
			return t as ICacheRepository;
            }

        public static void Register ()
            {
            string arg_2FD_0 = typeof(BackgroundCache).FullName;
            if(DataCacheFactory.cache_ll == null)
			{
                DataCacheFactory.cache_ll = new Func<ICacheRepository>(DataCacheFactory.cacheRep_Al);
			}

            jl<ICacheRepository>.Register(arg_2FD_0, DataCacheFactory.cache_ll);
            string expr_311 = typeof(BorderCaches).FullName;
            if(DataCacheFactory.cache_ml == null)
			{
                DataCacheFactory.cache_ml = new Func<ICacheRepository>(DataCacheFactory.cacheRep_Bl);
			}
            Func<ICacheRepository> expr_58 = DataCacheFactory.cache_ml;

			if(!false)
                {
                jl<ICacheRepository>.Register(expr_311, expr_58);
                }
            string arg_339_0 = typeof(CurrencyCache).FullName;
            if(DataCacheFactory.cache_nl == null)
			{
                DataCacheFactory.cache_nl = new Func<ICacheRepository>(DataCacheFactory.cacheRep_Cl);
			}

            jl<ICacheRepository>.Register(arg_339_0, DataCacheFactory.cache_nl);
            string arg_C2_0 = typeof(DiscountCache).FullName;
            if(DataCacheFactory.cache_ol == null)
			{
                DataCacheFactory.cache_ol = new Func<ICacheRepository>(DataCacheFactory.cacheRep_Dl);
			}

            jl<ICacheRepository>.Register(arg_C2_0, DataCacheFactory.cache_ol);
            string arg_F3_0 = typeof(GraphicsCaches).FullName;
            if(DataCacheFactory.cache_pl == null)
			{
                DataCacheFactory.cache_pl = new Func<ICacheRepository>(DataCacheFactory.cacheRep_El);
			}

            jl<ICacheRepository>.Register(arg_F3_0, DataCacheFactory.cache_pl);
            string arg_124_0 = typeof(SemiOrderSettingsCaches).FullName;
            if(DataCacheFactory.cache_ql == null)
			{
                DataCacheFactory.cache_ql = new Func<ICacheRepository>(DataCacheFactory.cacheRep_Fl);
			}

            jl<ICacheRepository>.Register(arg_124_0, DataCacheFactory.cache_ql);
            string arg_155_0 = typeof(StoreCaches).FullName;
            if(DataCacheFactory.cache_rl == null)
			{
                DataCacheFactory.cache_rl = new Func<ICacheRepository>(DataCacheFactory.cacheRep_Gl);
			}

            jl<ICacheRepository>.Register(arg_155_0, DataCacheFactory.cache_rl);
            string arg_186_0 = typeof(ValueTypeCache).FullName;
            if(DataCacheFactory.cache_sl == null)
			{
                DataCacheFactory.cache_sl = new Func<ICacheRepository>(DataCacheFactory.cacheRep_Hl);
			}

            jl<ICacheRepository>.Register(arg_186_0, DataCacheFactory.cache_sl);
            string arg_1B7_0 = typeof(ConfigCache).FullName;
            if(DataCacheFactory.cache_tl == null)
			{
                DataCacheFactory.cache_tl = new Func<ICacheRepository>(DataCacheFactory.cacheRep_Il);
			}

           jl<ICacheRepository>.Register(arg_1B7_0, DataCacheFactory.cache_tl);
            string arg_1E8_0 = typeof(ConfigurationCache).FullName;
            if(DataCacheFactory.cache_ul == null)
			{
                DataCacheFactory.cache_ul = new Func<ICacheRepository>(DataCacheFactory.cacheRep_Jl);
			}

            jl<ICacheRepository>.Register(arg_1E8_0, DataCacheFactory.cache_ul);
            string arg_219_0 = typeof(ImixConfigurationCache).FullName;
            if(DataCacheFactory.cache_vl == null)
			{
                DataCacheFactory.cache_vl = new Func<ICacheRepository>(DataCacheFactory.cacheRep_Kl);
			}

           jl<ICacheRepository>.Register(arg_219_0, DataCacheFactory.cache_vl);
            string arg_24A_0 = typeof(UserCache).FullName;
            if(DataCacheFactory.cache_wl == null)
			{
                DataCacheFactory.cache_wl = new Func<ICacheRepository>(DataCacheFactory.cacheRep_Ll);
			}

           jl<ICacheRepository>.Register(arg_24A_0, DataCacheFactory.cache_wl);
            if(!false)
                {
                string arg_281_0 = typeof(LocationCache).FullName;
                if(DataCacheFactory.cache_xl == null)
				{
                    DataCacheFactory.cache_xl = new Func<ICacheRepository>(DataCacheFactory.cacheRep_Ml);
				}
           jl<ICacheRepository>.Register(arg_281_0, DataCacheFactory.cache_xl);
                string arg_2B2_0 = typeof(SceneCache).FullName;
                if(DataCacheFactory.cache_yl == null)
				{
                    DataCacheFactory.cache_yl = new Func<ICacheRepository>(DataCacheFactory.cacheRep_Nl);
				}
             jl<ICacheRepository>.Register(arg_2B2_0, DataCacheFactory.cache_yl);
                string arg_2E3_0 = typeof(CharacterCache).FullName;
                if(DataCacheFactory.cache_zl == null)
				{
                    DataCacheFactory.cache_zl = new Func<ICacheRepository>(DataCacheFactory.cacheRep_Ol);
				}
             jl<ICacheRepository>.Register(arg_2E3_0, DataCacheFactory.cache_zl);
                }
            }


        private static ICacheRepository cacheRep_Al()
		{
			return new BackgroundCache ();
        }


        private static ICacheRepository cacheRep_Bl ()
		    {
			    return new BorderCaches ();
            }


        private static ICacheRepository cacheRep_Cl ()
		        {
			        return new CurrencyCache ();
		        }


        private static ICacheRepository cacheRep_Dl ()
		        {
			        return new DiscountCache ();
		        }


        private static ICacheRepository cacheRep_El ()
		        {
			        return new GraphicsCaches ();
		        }


        private static ICacheRepository cacheRep_Fl ()
		        {
			        return new SemiOrderSettingsCaches ();
		        }


        private static ICacheRepository cacheRep_Gl ()
		        {
			        return new StoreCaches ();
		        }


        private static ICacheRepository cacheRep_Hl ()
		        {
			        return new ValueTypeCache ();
		        }


        private static ICacheRepository cacheRep_Il ()
		        {
			        return new ConfigCache ();
		        }


        private static ICacheRepository cacheRep_Jl ()
		        {
			        return new ConfigurationCache ();
		        }

        private static ICacheRepository cacheRep_Kl ()
		        {
			        return new ImixConfigurationCache ();
		        }

        private static ICacheRepository cacheRep_Ll ()
		        {
			        return new UserCache ();
		        }

        private static ICacheRepository cacheRep_Ml ()
		        {
			        return new LocationCache ();
		        }


        private static ICacheRepository cacheRep_Nl ()
		        {
			        return new SceneCache ();
		        }


        private static ICacheRepository cacheRep_Ol ()
		        {
			        return new CharacterCache ();
		        }
	        }
    }
