using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "sp_GetActivityReport"), DataContract(IsReference = true)]
    [Serializable]
    public class sp_GetActivityReport : ComplexObject
        {
        

        }
    }
