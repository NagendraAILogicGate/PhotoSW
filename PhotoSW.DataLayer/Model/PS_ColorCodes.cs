using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "DG_ColorCodes"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_ColorCodes : EntityObject
        {
       
            private int _PS_ID;

            private string _PS_ColorCode;

            //[NonSerialized]
            //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
            public int PS_ID
                {
                get
                    {
                    return this._PS_ID;
                    }
                set
                    {
                    if(!true)
                        {
                        goto IL_29;
                        }
                    if(this._PS_ID == value)
                        {
                        goto IL_42;
                        }
                    IL_0E:
                   // this.ReportPropertyChanging(DG_ColorCodes.(7531));
                    this._PS_ID = StructuralObject.SetValidValue(value);
                    IL_29:
                    if(false)
                        {
                        goto IL_0E;
                        }
                   // this.ReportPropertyChanged(DG_ColorCodes.(7531));
                    IL_42:
                    if(!false)
                        {
                        return;
                        }
                    goto IL_0E;
                    }
                }

            [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
            public string PS_ColorCode
                {
                get
                    {
                    return this._PS_ColorCode;
                    }
                set
                    {
                    if(!(this._PS_ColorCode != value))
                        {
                        goto IL_3E;
                        }
                    IL_0D:
                   // this.ReportPropertyChanging(DG_ColorCodes.(7540));
                    IL_1D:
                    this._PS_ColorCode = StructuralObject.SetValidValue(value, false);
                    //this.ReportPropertyChanged(DG_ColorCodes.(7540));
                    IL_3E:
                    if(false)
                        {
                        goto IL_0D;
                        }
                    if(!false)
                        {
                        return;
                        }
                    goto IL_1D;
                    }
                }

            public static PS_ColorCodes CreateDG_ColorCodes ( int dG_ID, string dG_ColorCode )
                {
                return new PS_ColorCodes
                    {
                    PS_ID = dG_ID,
                    PS_ColorCode = dG_ColorCode
                    };
                }

            static PS_ColorCodes ()
                {
                // Note: this type is marked as 'beforefieldinit'.
               // Strings.CreateGetStringDelegate(typeof(DG_ColorCodes));
                }



            }
    }
