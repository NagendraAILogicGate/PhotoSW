using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "GetRefundedItems_Result"), DataContract(IsReference = true)]
    [Serializable]
    public class GetRefundedItems_Result : ComplexObject
        {

        private int _LineitemID;

        private int _PhotoID;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int LineitemID
            {
            get
                {
                return this._LineitemID;
                }
            set
                {
              //  this.ReportPropertyChanging(GetRefundedItems_Result.(19884));
                this._LineitemID = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(GetRefundedItems_Result.(19884));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PhotoID
            {
            get
                {
                return this._PhotoID;
                }
            set
                {
            //    this.ReportPropertyChanging(GetRefundedItems_Result.(19850));
                this._PhotoID = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(GetRefundedItems_Result.(19850));
                }
            }

        public static GetRefundedItems_Result CreateGetRefundedItems_Result ( int lineitemID, int photoID )
            {
            return new GetRefundedItems_Result
                {
                LineitemID = lineitemID,
                PhotoID = photoID
                };
            }

        static GetRefundedItems_Result ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(GetRefundedItems_Result));
            }

        }
    }
