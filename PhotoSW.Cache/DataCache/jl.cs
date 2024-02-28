using System;
using PhotoSW.Cache.Repository;
using System.Collections.Generic;

namespace PhotoSW.Cache.DataCache
    {
    internal class jl<T>
        {
       // private static int 1k;
            private static Dictionary<string, Func<T>> dl = new Dictionary<string, Func<T>>();
       // private static string gl;

        public static object R { get; private set; }

        internal static void Register ( string arg_F3_0, Func<T> cache_pl )
            {
            jl < T>.dl.Add(arg_F3_0, cache_pl);
            // throw new NotImplementedException();
            }

        //internal static T fl ( string cacheType )
        //    {
        //    throw new NotImplementedException();
        //    }
        public static T fl(string gl)
		{
			if (4 == 0)
			{
				goto IL_1E;
			}
    Func<T> func = null;
			int arg_42_0;
			bool expr_31 = (arg_42_0 = (jl<T>.dl.TryGetValue(gl, out func) ? 1 : 0)) != 0;
			if (false)
			{
				goto IL_26;
			}
			if (!expr_31)
			{
				goto IL_1E;
			}
			IL_16:
			if (!false)
			{
				return func ();
			}
			IL_1E:
			if (6 == 0)
			{
				goto IL_16;
			}
			arg_42_0 = 242;
            IL_26:
            throw new ArgumentException();//(R.P(arg_42_0));
		}
        }
    }