using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_Photos_Changes"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_Photos_Changes : EntityObject
        {
        private int _PS_Photos_Changes_pkey;

        private int? _PS_Photos_ID;

        private int? _PS_Photos_Changes_TypeID;

        private string _PS_Photos_Changes_Value;

        private DateTime? _PS_Photos_Changes_CreatedON;

        //[NonSerialized]
        //internal static GetString ;

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
               // this.ReportPropertyChanging(DG_Photos_Changes.(12666));
                this._PS_Photos_Changes_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
                //this.ReportPropertyChanged(DG_Photos_Changes.(12666));
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
              ///  this.ReportPropertyChanging(DG_Photos_Changes.(10532));
                this._PS_Photos_ID = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Photos_Changes.(10532));
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
               // this.ReportPropertyChanging(DG_Photos_Changes.(12699));
                this._PS_Photos_Changes_TypeID = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Photos_Changes.(12699));
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
                  //  this.ReportPropertyChanging(DG_Photos_Changes.(12732));
                    this._PS_Photos_Changes_Value = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Photos_Changes.(12732));
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
               // this.ReportPropertyChanging(DG_Photos_Changes.(12765));
                this._PS_Photos_Changes_CreatedON = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Photos_Changes.(12765));
                }
            }

        public static PS_Photos_Changes CreateDG_Photos_Changes ( int dG_Photos_Changes_pkey )
            {
            return new PS_Photos_Changes
                {
                PS_Photos_Changes_pkey = dG_Photos_Changes_pkey
                };
            }

        static PS_Photos_Changes ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_Photos_Changes));
            }


        }
    }
