using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetPhotoEffects"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetPhotoEffects : EntityObject
        {
        private string _PS_Photo_Effects_Name;

        private string _PS_Photos_Changes_Value;

        private DateTime? _PS_Photos_Changes_CreatedON;

        private int _PS_Photos_Changes_pkey;

        private int? _PS_Photos_ID;

        private int? _PS_Photos_Changes_TypeID;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Photo_Effects_Name
            {
            get
                {
                return this._PS_Photo_Effects_Name;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(vw_GetPhotoEffects.(12824));
                    this._PS_Photo_Effects_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPhotoEffects.(12824));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Photos_Changes_Value
            {
            get
                {
                return this._PS_Photos_Changes_Value;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(vw_GetPhotoEffects.(13241));
                    this._PS_Photos_Changes_Value = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPhotoEffects.(13241));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? PS_Photos_Changes_CreatedON
            {
            get
                {
                return this._PS_Photos_Changes_CreatedON;
                }
            set
                {
            //    this.ReportPropertyChanging(vw_GetPhotoEffects.(13274));
                this._PS_Photos_Changes_CreatedON = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetPhotoEffects.(13274));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Photos_Changes_pkey
            {
            get
                {
                return this._PS_Photos_Changes_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Photos_Changes_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
           //     this.ReportPropertyChanging(vw_GetPhotoEffects.(13175));
                this._PS_Photos_Changes_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
            //    this.ReportPropertyChanged(vw_GetPhotoEffects.(13175));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Photos_ID
            {
            get
                {
                return this._PS_Photos_ID;
                }
            set
                {
            //    this.ReportPropertyChanging(vw_GetPhotoEffects.(11041));
                this._PS_Photos_ID = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetPhotoEffects.(11041));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Photos_Changes_TypeID
            {
            get
                {
                return this._PS_Photos_Changes_TypeID;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetPhotoEffects.(13208));
                this._PS_Photos_Changes_TypeID = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetPhotoEffects.(13208));
                }
            }

        public static vw_GetPhotoEffects Createvw_GetPhotoEffects ( int dG_Photos_Changes_pkey )
            {
            return new vw_GetPhotoEffects
                {
                PS_Photos_Changes_pkey = dG_Photos_Changes_pkey
                };
            }

        static vw_GetPhotoEffects ()
            {
            // Note: this type is marked as 'beforefieldinit'.
        //    Strings.CreateGetStringDelegate(typeof(vw_GetPhotoEffects));
            }

        }
    }
