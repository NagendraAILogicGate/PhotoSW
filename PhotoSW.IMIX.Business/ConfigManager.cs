using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
     public class ConfigManager
     {
         public static string FolderPath { get; set; }
         public static Dictionary<long, string> IMIXConfigurations { get; set; }
         public static int SubStoreId { get; set; }
    }
}
