using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "GetLocationSubstoreWise_Result"), DataContract(IsReference = true)]
    [Serializable]
    public class GetLocationSubstoreWise_Result : ComplexObject
        {
        private int _PS_Location_pkey;

        private string _PS_Location_Name;

        private string _PS_Location_PhoneNumber;

        private bool? _PS_Location_IsActive;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_Location_pkey
            {
            get
                {
                return this._PS_Location_pkey;
                }
            set
                {
             //   this.ReportPropertyChanging(GetLocationSubstoreWise_Result.(10509));
                this._PS_Location_pkey = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(GetLocationSubstoreWise_Result.(10509));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string PS_Location_Name
            {
            get
                {
                return this._PS_Location_Name;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(GetLocationSubstoreWise_Result.(10534));
                    this._PS_Location_Name = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetLocationSubstoreWise_Result.(10534));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Location_PhoneNumber
            {
            get
                {
                return this._PS_Location_PhoneNumber;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(GetLocationSubstoreWise_Result.(10576));
                    this._PS_Location_PhoneNumber = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetLocationSubstoreWise_Result.(10576));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Location_IsActive
            {
            get
                {
                return this._PS_Location_IsActive;
                }
            set
                {
             //   this.ReportPropertyChanging(GetLocationSubstoreWise_Result.(10609));
                this._PS_Location_IsActive = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(GetLocationSubstoreWise_Result.(10609));
                }
            }

        public static GetLocationSubstoreWise_Result CreateGetLocationSubstoreWise_Result ( int dG_Location_pkey, string dG_Location_Name )
            {
            return new GetLocationSubstoreWise_Result
                {
                PS_Location_pkey = dG_Location_pkey,
                PS_Location_Name = dG_Location_Name
                };
            }

        static GetLocationSubstoreWise_Result ()
            {
            // Note: this type is marked as 'beforefieldinit'.
        //    Strings.CreateGetStringDelegate(typeof(GetLocationSubstoreWise_Result));
            }

        }
    }
