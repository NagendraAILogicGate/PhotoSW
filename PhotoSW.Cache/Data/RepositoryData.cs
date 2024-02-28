using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System.Configuration;

namespace PhotoSW.Cache.Data
    {
    public sealed class RepositoryData
        {
        public delegate string GetString ( int i );

        private static int e;
		
        internal static GetString EOT;

		public static int CacheExpirationInMinute
            {
            get
                {
                int arg_3D_0;
                if(!false)
                    {
                    int arg_0D_0 = RepositoryData.e;
					while(arg_0D_0 == -32768)
                        {
                        if(7 != 0)
                            {
                            int num;
                            int.TryParse(ConfigurationManager.AppSettings[RepositoryData.EOT(663)], out num);
                            int expr_5A = arg_0D_0 = num;
                            if(false)
                                {
                                continue;
                                }
                            if(expr_5A > 0)
                                {
                                return num;
                                }
                            }
                        int expr_34 = arg_3D_0 = 10;
                        if(expr_34 != 0)
                            {
                            return expr_34;
                            }
                        return arg_3D_0;
                        }
                    }
                arg_3D_0 = RepositoryData.e;
				return arg_3D_0;
                }
            set
                {
                RepositoryData.e = value;
			}
            }

        private RepositoryData ()
            {
            }

  //      static RepositoryData ()
  //          {
  //          // Note: this type is marked as 'beforefieldinit'.
  //          SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(RepositoryData));
  //          RepositoryData.#e = -32768;
		//}
        }
    }
