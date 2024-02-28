using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "PhotoSW", Name = "PS_BackGround"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_BackGround : EntityObject
        {

        private int _PS_Background_pkey;

        private int _PS_Product_Id;

        private string _PS_BackGround_Image_Name;

        private string _PS_BackGround_Image_Display_Name;

        private int? _PS_BackGround_Group_Id;

        private string _SyncCode;

        private bool _IsSynced;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Background_pkey
            {
            get
                {
                return this._PS_Background_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Background_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(DG_BackGround.(6924));
                this._PS_Background_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(DG_BackGround.(6924));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_Product_Id
            {
            get
                {
                return this._PS_Product_Id;
                }
            set
                {
               // this.ReportPropertyChanging(PS_BackGround.(6949));
                this._PS_Product_Id = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(PS_BackGround.(6949));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_BackGround_Image_Name
            {
            get
                {
                return this._PS_BackGround_Image_Name;
                }
            set
                {
                do
                    {
                    //this.ReportPropertyChanging(DG_BackGround.(6970));
                    this._PS_BackGround_Image_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(PS_BackGround.(6970));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_BackGround_Image_Display_Name
            {
            get
                {
                return this._PS_BackGround_Image_Display_Name;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(PS_BackGround.(7003));
                    this._PS_BackGround_Image_Display_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_BackGround.(7003));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_BackGround_Group_Id
            {
            get
                {
                return this._PS_BackGround_Group_Id;
                }
            set
                {
               // this.ReportPropertyChanging(DG_BackGround.(7048));
                this._PS_BackGround_Group_Id = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_BackGround.(7048));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string SyncCode
            {
            get
                {
                return this._SyncCode;
                }
            set
                {
                do
                    {
                    //this.ReportPropertyChanging(PS_BackGround.(6399));
                    this._SyncCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(PS_BackGround.(6399));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public bool IsSynced
            {
            get
                {
                return this._IsSynced;
                }
            set
                {
               //// this.ReportPropertyChanging(DG_BackGround.(6412));
                this._IsSynced = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_BackGround.(6412));
                }
            }

        public static PS_BackGround CreateDG_BackGround ( int dG_Background_pkey, int dG_Product_Id, bool isSynced )
            {
            if(5 == 0)
                {
                goto IL_23;
                }
            PS_BackGround expr_28 = new PS_BackGround();
            PS_BackGround dG_BackGround;
            if(3 != 0)
                {
                dG_BackGround = expr_28;
                }
            dG_BackGround.PS_Background_pkey = dG_Background_pkey;
            IL_0F:
            PS_BackGround expr_3F = dG_BackGround;
            if(5 != 0)
                {
                expr_3F.PS_Product_Id = dG_Product_Id;
                }
            if(!false)
                {
                dG_BackGround.IsSynced = isSynced;
                }
            IL_23:
            if(5 != 0)
                {
                return dG_BackGround;
                }
            goto IL_0F;
            }

        static PS_BackGround ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_BackGround));
            }

        }
    }
