using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_CameraDetails"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_CameraDetails : EntityObject
        {
        private int _PS_Camera_pkey;

        private string _PS_Camera_Name;

        private string _PS_Camera_Make;

        private string _PS_Camera_Model;

        private int? _PS_AssignTo;

        private string _PS_Camera_Start_Series;

        private int _PS_Updatedby;

        private DateTime _PS_UpdatedDate;

        private bool? _PS_Camera_IsDeleted;

        private int? _PS_Camera_ID;

        private string _SyncCode;

        private bool _IsSynced;

        private bool? _Is_ChromaColor;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Camera_pkey
            {
            get
                {
                return this._PS_Camera_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Camera_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(DG_CameraDetails.(7253));
                this._PS_Camera_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(DG_CameraDetails.(7253));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string PS_Camera_Name
            {
            get
                {
                return this._PS_Camera_Name;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_CameraDetails.(7274));
                    this._PS_Camera_Name = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_CameraDetails.(7274));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string PS_Camera_Make
            {
            get
                {
                return this._PS_Camera_Make;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_CameraDetails.(7295));
                    this._PS_Camera_Make = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_CameraDetails.(7295));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string PS_Camera_Model
            {
            get
                {
                return this._PS_Camera_Model;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_CameraDetails.(7316));
                    this._PS_Camera_Model = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_CameraDetails.(7316));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_AssignTo
            {
            get
                {
                return this._PS_AssignTo;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_CameraDetails.(7337));
                this._PS_AssignTo = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_CameraDetails.(7337));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string PS_Camera_Start_Series
            {
            get
                {
                return this._PS_Camera_Start_Series;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_CameraDetails.(7354));
                    this._PS_Camera_Start_Series = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_CameraDetails.(7354));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_Updatedby
            {
            get
                {
                return this._PS_Updatedby;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_CameraDetails.(7387));
                this._PS_Updatedby = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_CameraDetails.(7387));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public DateTime PS_UpdatedDate
            {
            get
                {
                return this._PS_UpdatedDate;
                }
            set
                {
               // this.ReportPropertyChanging(DG_CameraDetails.(7404));
                this._PS_UpdatedDate = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_CameraDetails.(7404));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Camera_IsDeleted
            {
            get
                {
                return this._PS_Camera_IsDeleted;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_CameraDetails.(7425));
                this._PS_Camera_IsDeleted = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_CameraDetails.(7425));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Camera_ID
            {
            get
                {
                return this._PS_Camera_ID;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_CameraDetails.(7454));
                this._PS_Camera_ID = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_CameraDetails.(7454));
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
                 //   this.ReportPropertyChanging(DG_CameraDetails.(6424));
                    this._SyncCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_CameraDetails.(6424));
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
               // this.ReportPropertyChanging(DG_CameraDetails.(6437));
                this._IsSynced = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_CameraDetails.(6437));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? Is_ChromaColor
            {
            get
                {
                return this._Is_ChromaColor;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_CameraDetails.(7471));
                this._Is_ChromaColor = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_CameraDetails.(7471));
                }
            }

        public static PS_CameraDetails CreateDG_CameraDetails ( int dG_Camera_pkey, string dG_Camera_Name, string dG_Camera_Make, string dG_Camera_Model, string dG_Camera_Start_Series, int dG_Updatedby, DateTime dG_UpdatedDate, bool isSynced )
            {
            PS_CameraDetails dG_CameraDetails;
            if(7 != 0)
                {
                if(false)
                    {
                    goto IL_27;
                    }
                PS_CameraDetails expr_49 = new PS_CameraDetails();
                if(!false)
                    {
                    dG_CameraDetails = expr_49;
                    }
                dG_CameraDetails.PS_Camera_pkey = dG_Camera_pkey;
                dG_CameraDetails.PS_Camera_Name = dG_Camera_Name;
                dG_CameraDetails.PS_Camera_Make = dG_Camera_Make;
                }
            dG_CameraDetails.PS_Camera_Model = dG_Camera_Model;
            IL_27:
            dG_CameraDetails.PS_Camera_Start_Series = dG_Camera_Start_Series;
            dG_CameraDetails.PS_Updatedby = dG_Updatedby;
            dG_CameraDetails.PS_UpdatedDate = dG_UpdatedDate;
            dG_CameraDetails.IsSynced = isSynced;
            return dG_CameraDetails;
            }

        static PS_CameraDetails ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_CameraDetails));
            }

        }
    }
