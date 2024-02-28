using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetPrintDetails"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetPrintDetails : EntityObject
        {
        private string _PS_Orders_ProductType_Name;

        private string _PS_Photos_FileName;

        private DateTime _PS_Photos_CreatedOn;

        private DateTime? _PrintTime;

        private string _PrintedBy;

        private string _TakenBy;

        private int _ID;

        //[NonSerialized]
        //internal static GetString ;

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
                 //   this.ReportPropertyChanging(vw_GetPrintDetails.(12157));
                    this._PS_Orders_ProductType_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPrintDetails.(12157));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string PS_Photos_FileName
            {
            get
                {
                return this._PS_Photos_FileName;
                }
            set
                {
                if(!(this._PS_Photos_FileName != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
             //   this.ReportPropertyChanging(vw_GetPrintDetails.(6156));
                IL_1D:
                this._PS_Photos_FileName = StructuralObject.SetValidValue(value, false);
           //     this.ReportPropertyChanged(vw_GetPrintDetails.(6156));
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
        public DateTime PS_Photos_CreatedOn
            {
            get
                {
                return this._PS_Photos_CreatedOn;
                }
            set
                {
                if(this._PS_Photos_CreatedOn != value)
                    {
                    //string expr_54 = vw_GetPrintDetails.(6181);
                    //if(3 != 0)
                    //    {
                    //    this.ReportPropertyChanging(expr_54);
                    //    }
                    this._PS_Photos_CreatedOn = StructuralObject.SetValidValue(value);
                    //if(!false)
                    //    {
                    //    this.ReportPropertyChanged(vw_GetPrintDetails.(6181));
                    //    }
                    }
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? PrintTime
            {
            get
                {
                return this._PrintTime;
                }
            set
                {
             //   this.ReportPropertyChanging(vw_GetPrintDetails.(13765));
                this._PrintTime = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(vw_GetPrintDetails.(13765));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PrintedBy
            {
            get
                {
                return this._PrintedBy;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(vw_GetPrintDetails.(18858));
                    this._PrintedBy = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPrintDetails.(18858));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string TakenBy
            {
            get
                {
                return this._TakenBy;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(vw_GetPrintDetails.(18871));
                    this._TakenBy = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPrintDetails.(18871));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int ID
            {
            get
                {
                return this._ID;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._ID == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
             //   this.ReportPropertyChanging(vw_GetPrintDetails.(13344));
                this._ID = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
            //    this.ReportPropertyChanged(vw_GetPrintDetails.(13344));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        public static vw_GetPrintDetails Createvw_GetPrintDetails ( string dG_Photos_FileName, DateTime dG_Photos_CreatedOn, int id )
            {
            if(5 == 0)
                {
                goto IL_23;
                }
            vw_GetPrintDetails expr_28 = new vw_GetPrintDetails();
            vw_GetPrintDetails vw_GetPrintDetails;
            if(3 != 0)
                {
                vw_GetPrintDetails = expr_28;
                }
            vw_GetPrintDetails.PS_Photos_FileName = dG_Photos_FileName;
            IL_0F:
            vw_GetPrintDetails expr_3F = vw_GetPrintDetails;
            if(5 != 0)
                {
                expr_3F.PS_Photos_CreatedOn = dG_Photos_CreatedOn;
                }
            if(!false)
                {
                vw_GetPrintDetails.ID = id;
                }
            IL_23:
            if(5 != 0)
                {
                return vw_GetPrintDetails;
                }
            goto IL_0F;
            }

        static vw_GetPrintDetails ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(vw_GetPrintDetails));
            }

        }
    }
