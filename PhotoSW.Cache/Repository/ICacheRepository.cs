using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.Cache.Repository
    {
    public interface ICacheRepository
        {
        object GetData ();

        void CleanData ();

        void RemoveFromCache ();
        }
    }
