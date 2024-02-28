using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "GetPhotoToUpload_Result"), DataContract(IsReference = true)]
    [Serializable]
    public class GetPhotoToUpload_Result : ComplexObject
        {
        private string _PS_Orders_Number;

        private int? _PS_Order_SubStoreId;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_Number
            {
            get
                {
                return this._PS_Orders_Number;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(GetPhotoToUpload_Result.(10780));
                    this._PS_Orders_Number = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPhotoToUpload_Result.(10780));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Order_SubStoreId
            {
            get
                {
                return this._PS_Order_SubStoreId;
                }
            set
                {
              //  this.ReportPropertyChanging(GetPhotoToUpload_Result.(11827));
                this._PS_Order_SubStoreId = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(GetPhotoToUpload_Result.(11827));
                }
            }

        static GetPhotoToUpload_Result ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(GetPhotoToUpload_Result));
            }


        }
    }
