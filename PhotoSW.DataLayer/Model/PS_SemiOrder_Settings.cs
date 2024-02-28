using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_SemiOrder_Settings"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_SemiOrder_Settings : EntityObject
        {

        private int _PS_SemiOrder_Settings_Pkey;

        private bool? _PS_SemiOrder_Settings_AutoBright;

        private double? _PS_SemiOrder_Settings_AutoBright_Value;

        private bool? _PS_SemiOrder_Settings_AutoContrast;

        private double? _PS_SemiOrder_Settings_AutoContrast_Value;

        private string _PS_SemiOrder_Settings_ImageFrame;

        private bool? _PS_SemiOrder_Settings_IsImageFrame;

        private int? _PS_SemiOrder_ProductTypeId;

        private string _PS_SemiOrder_Settings_ImageFrame_Vertical;

        private bool? _PS_SemiOrder_Environment;

        private string _PS_SemiOrder_BG;

        private bool? _PS_SemiOrder_Settings_IsImageBG;

        private string _PS_SemiOrder_Graphics_layer;

        private string _PS_SemiOrder_Image_ZoomInfo;

        private int? _PS_SubStoreId;

        private bool? _PS_SemiOrder_IsPrintActive;

        private bool? _PS_SemiOrder_IsCropActive;

        private string _VerticalCropValues;

        private string _HorizontalCropValues;

        private int? _PS_LocationId;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_SemiOrder_Settings_Pkey
            {
            get
                {
                return this._PS_SemiOrder_Settings_Pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_SemiOrder_Settings_Pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(DG_SemiOrder_Settings.(15180));
                this._PS_SemiOrder_Settings_Pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
               // this.ReportPropertyChanged(DG_SemiOrder_Settings.(15180));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_SemiOrder_Settings_AutoBright
            {
            get
                {
                return this._PS_SemiOrder_Settings_AutoBright;
                }
            set
                {
               // this.ReportPropertyChanging(DG_SemiOrder_Settings.(15217));
                this._PS_SemiOrder_Settings_AutoBright = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_SemiOrder_Settings.(15217));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public double? PS_SemiOrder_Settings_AutoBright_Value
            {
            get
                {
                return this._PS_SemiOrder_Settings_AutoBright_Value;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_SemiOrder_Settings.(15262));
                this._PS_SemiOrder_Settings_AutoBright_Value = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_SemiOrder_Settings.(15262));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_SemiOrder_Settings_AutoContrast
            {
            get
                {
                return this._PS_SemiOrder_Settings_AutoContrast;
                }
            set
                {
               // this.ReportPropertyChanging(DG_SemiOrder_Settings.(15315));
                this._PS_SemiOrder_Settings_AutoContrast = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_SemiOrder_Settings.(15315));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public double? PS_SemiOrder_Settings_AutoContrast_Value
            {
            get
                {
                return this._PS_SemiOrder_Settings_AutoContrast_Value;
                }
            set
                {
               // this.ReportPropertyChanging(DG_SemiOrder_Settings.(15364));
                this._PS_SemiOrder_Settings_AutoContrast_Value = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_SemiOrder_Settings.(15364));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_SemiOrder_Settings_ImageFrame
            {
            get
                {
                return this._PS_SemiOrder_Settings_ImageFrame;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_SemiOrder_Settings.(15421));
                    this._PS_SemiOrder_Settings_ImageFrame = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_SemiOrder_Settings.(15421));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_SemiOrder_Settings_IsImageFrame
            {
            get
                {
                return this._PS_SemiOrder_Settings_IsImageFrame;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_SemiOrder_Settings.(15466));
                this._PS_SemiOrder_Settings_IsImageFrame = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_SemiOrder_Settings.(15466));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_SemiOrder_ProductTypeId
            {
            get
                {
                return this._PS_SemiOrder_ProductTypeId;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_SemiOrder_Settings.(15515));
                this._PS_SemiOrder_ProductTypeId = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_SemiOrder_Settings.(15515));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_SemiOrder_Settings_ImageFrame_Vertical
            {
            get
                {
                return this._PS_SemiOrder_Settings_ImageFrame_Vertical;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_SemiOrder_Settings.(15552));
                    this._PS_SemiOrder_Settings_ImageFrame_Vertical = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_SemiOrder_Settings.(15552));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_SemiOrder_Environment
            {
            get
                {
                return this._PS_SemiOrder_Environment;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_SemiOrder_Settings.(15609));
                this._PS_SemiOrder_Environment = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_SemiOrder_Settings.(15609));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_SemiOrder_BG
            {
            get
                {
                return this._PS_SemiOrder_BG;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_SemiOrder_Settings.(15642));
                    this._PS_SemiOrder_BG = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_SemiOrder_Settings.(15642));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_SemiOrder_Settings_IsImageBG
            {
            get
                {
                return this._PS_SemiOrder_Settings_IsImageBG;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_SemiOrder_Settings.(15663));
                this._PS_SemiOrder_Settings_IsImageBG = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_SemiOrder_Settings.(15663));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_SemiOrder_Graphics_layer
            {
            get
                {
                return this._PS_SemiOrder_Graphics_layer;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_SemiOrder_Settings.(15708));
                    this._PS_SemiOrder_Graphics_layer = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_SemiOrder_Settings.(15708));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_SemiOrder_Image_ZoomInfo
            {
            get
                {
                return this._PS_SemiOrder_Image_ZoomInfo;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_SemiOrder_Settings.(15745));
                    this._PS_SemiOrder_Image_ZoomInfo = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_SemiOrder_Settings.(15745));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_SubStoreId
            {
            get
                {
                return this._PS_SubStoreId;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_SemiOrder_Settings.(6137));
                this._PS_SubStoreId = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_SemiOrder_Settings.(6137));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_SemiOrder_IsPrintActive
            {
            get
                {
                return this._PS_SemiOrder_IsPrintActive;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_SemiOrder_Settings.(15782));
                this._PS_SemiOrder_IsPrintActive = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_SemiOrder_Settings.(15782));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_SemiOrder_IsCropActive
            {
            get
                {
                return this._PS_SemiOrder_IsCropActive;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_SemiOrder_Settings.(15819));
                this._PS_SemiOrder_IsCropActive = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_SemiOrder_Settings.(15819));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string VerticalCropValues
            {
            get
                {
                return this._VerticalCropValues;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(DG_SemiOrder_Settings.(15856));
                    this._VerticalCropValues = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_SemiOrder_Settings.(15856));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string HorizontalCropValues
            {
            get
                {
                return this._HorizontalCropValues;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(DG_SemiOrder_Settings.(15881));
                    this._HorizontalCropValues = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_SemiOrder_Settings.(15881));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_LocationId
            {
            get
                {
                return this._PS_LocationId;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_SemiOrder_Settings.(15910));
                this._PS_LocationId = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_SemiOrder_Settings.(15910));
                }
            }

        public static PS_SemiOrder_Settings CreateDG_SemiOrder_Settings ( int dG_SemiOrder_Settings_Pkey )
            {
            return new PS_SemiOrder_Settings
                {
                PS_SemiOrder_Settings_Pkey = dG_SemiOrder_Settings_Pkey
                };
            }

        static PS_SemiOrder_Settings ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(DG_SemiOrder_Settings));
            }

        }
    }
