using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetBorderDetails"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetBorderDetails : EntityObject
        {
        private string _PS_Orders_ProductType_Name;

        private int _PS_Borders_pkey;

        private string _PS_Border;

        private int _PS_ProductTypeID;

        private bool _PS_IsActive;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_ProductType_Name
            {
            get
                {
                return this._PS_Orders_ProductType_Name;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(vw_GetBorderDetails.(11929));
                    this._PS_Orders_ProductType_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetBorderDetails.(11929));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Borders_pkey
            {
            get
                {
                return this._PS_Borders_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Borders_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(vw_GetBorderDetails.(7740));
                this._PS_Borders_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
             //   this.ReportPropertyChanged(vw_GetBorderDetails.(7740));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string PS_Border
            {
            get
                {
                return this._PS_Border;
                }
            set
                {
                if(!(this._PS_Border != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
             //   this.ReportPropertyChanging(vw_GetBorderDetails.(7761));
                IL_1D:
                this._PS_Border = StructuralObject.SetValidValue(value, false);
              //  this.ReportPropertyChanged(vw_GetBorderDetails.(7761));
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

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_ProductTypeID
            {
            get
                {
                return this._PS_ProductTypeID;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_ProductTypeID == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
             //   this.ReportPropertyChanging(vw_GetBorderDetails.(7774));
                this._PS_ProductTypeID = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
             //   this.ReportPropertyChanged(vw_GetBorderDetails.(7774));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public bool PS_IsActive
            {
            get
                {
                return this._PS_IsActive;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_IsActive == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
             //   this.ReportPropertyChanging(vw_GetBorderDetails.(7799));
                this._PS_IsActive = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
             //   this.ReportPropertyChanged(vw_GetBorderDetails.(7799));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        public static vw_GetBorderDetails Createvw_GetBorderDetails ( int dG_Borders_pkey, string dG_Border, int dG_ProductTypeID, bool dG_IsActive )
            {
            vw_GetBorderDetails vw_GetBorderDetails;
            while(true)
                {
                vw_GetBorderDetails = new vw_GetBorderDetails();
                if(5 != 0 && 8 != 0)
                    {
                    vw_GetBorderDetails.PS_Borders_pkey = dG_Borders_pkey;
                    vw_GetBorderDetails.PS_Border = dG_Border;
                    if(3 == 0)
                        {
                        return vw_GetBorderDetails;
                        }
                    if(!false)
                        {
                        break;
                        }
                    }
                }
            vw_GetBorderDetails.PS_ProductTypeID = dG_ProductTypeID;
            vw_GetBorderDetails.PS_IsActive = dG_IsActive;
            return vw_GetBorderDetails;
            }

        static vw_GetBorderDetails ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(vw_GetBorderDetails));
            }

        }
    }
