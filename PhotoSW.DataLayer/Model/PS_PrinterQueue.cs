using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "DG_PrinterQueue"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_PrinterQueue : EntityObject
        {
        private int _PS_PrinterQueue_Pkey;

        private int? _PS_PrinterQueue_ProductID;

        private string _PS_PrinterQueue_Image_Pkey;

        private int? _PS_Associated_PrinterId;

        private int? _PS_Order_Details_Pkey;

        private bool? _PS_SentToPrinter;

        private bool? _is_Active;

        private int? _QueueIndex;

        private bool? _PS_IsSpecPrint;

        private DateTime? _PS_Print_Date;

        private string _RotationAngle;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_PrinterQueue_Pkey
            {
            get
                {
                return this._PS_PrinterQueue_Pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_PrinterQueue_Pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(DG_PrinterQueue.(12840));
                this._PS_PrinterQueue_Pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
                //this.ReportPropertyChanged(DG_PrinterQueue.(12840));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_PrinterQueue_ProductID
            {
            get
                {
                return this._PS_PrinterQueue_ProductID;
                }
            set
                {
               // this.ReportPropertyChanging(DG_PrinterQueue.(12869));
                this._PS_PrinterQueue_ProductID = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_PrinterQueue.(12869));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_PrinterQueue_Image_Pkey
            {
            get
                {
                return this._PS_PrinterQueue_Image_Pkey;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(PS_PrinterQueue.(12906));
                    this._PS_PrinterQueue_Image_Pkey = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_PrinterQueue.(12906));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Associated_PrinterId
            {
            get
                {
                return this._PS_Associated_PrinterId;
                }
            set
                {
               // this.ReportPropertyChanging(DG_PrinterQueue.(12943));
                this._PS_Associated_PrinterId = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_PrinterQueue.(12943));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Order_Details_Pkey
            {
            get
                {
                return this._PS_Order_Details_Pkey;
                }
            set
                {
               // this.ReportPropertyChanging(DG_PrinterQueue.(12976));
                this._PS_Order_Details_Pkey = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_PrinterQueue.(12976));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_SentToPrinter
            {
            get
                {
                return this._PS_SentToPrinter;
                }
            set
                {
               // this.ReportPropertyChanging(DG_PrinterQueue.(13005));
                this._PS_SentToPrinter = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_PrinterQueue.(13005));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? is_Active
            {
            get
                {
                return this._is_Active;
                }
            set
                {
                //this.ReportPropertyChanging(DG_PrinterQueue.(13030));
                this._is_Active = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_PrinterQueue.(13030));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? QueueIndex
            {
            get
                {
                return this._QueueIndex;
                }
            set
                {
               // this.ReportPropertyChanging(DG_PrinterQueue.(13043));
                this._QueueIndex = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_PrinterQueue.(13043));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_IsSpecPrint
            {
            get
                {
                return this._PS_IsSpecPrint;
                }
            set
                {
               // this.ReportPropertyChanging(DG_PrinterQueue.(13060));
                this._PS_IsSpecPrint = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_PrinterQueue.(13060));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? PS_Print_Date
            {
            get
                {
                return this._PS_Print_Date;
                }
            set
                {
               // this.ReportPropertyChanging(DG_PrinterQueue.(13081));
                this._PS_Print_Date = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_PrinterQueue.(13081));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string RotationAngle
            {
            get
                {
                return this._RotationAngle;
                }
            set
                {
                do
                    {
                    //this.ReportPropertyChanging(DG_PrinterQueue.(13102));
                    this._RotationAngle = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_PrinterQueue.(13102));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static PS_PrinterQueue CreateDG_PrinterQueue ( int dG_PrinterQueue_Pkey )
            {
            return new PS_PrinterQueue
                {
                PS_PrinterQueue_Pkey = dG_PrinterQueue_Pkey
                };
            }

        static PS_PrinterQueue ()
            {
            // Note: this type is marked as 'beforefieldinit'.
            //Strings.CreateGetStringDelegate(typeof(DG_PrinterQueue));
            }

        }
    }
