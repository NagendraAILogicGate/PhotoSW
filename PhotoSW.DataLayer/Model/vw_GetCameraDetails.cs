using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetCameraDetails"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetCameraDetails : EntityObject
        {
        private string _PhotographerName;

        private string _PS_Camera_Name;

        private string _PS_Camera_Make;

        private string _PS_Camera_Model;

        private int? _PS_AssignTo;

        private string _PS_Camera_Start_Series;

        private int _PS_Updatedby;

        private DateTime _PS_UpdatedDate;

        private int _PS_Camera_pkey;

        private string _PS_CameraFolder;

        private bool? _PS_Camera_IsDeleted;

        private int? _PS_Camera_ID;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PhotographerName
            {
            get
                {
                return this._PhotographerName;
                }
            set
                {
                do
                    {
                  // this.ReportPropertyChanging(vw_GetCameraDetails.(18517));
                    this._PhotographerName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetCameraDetails.(18517));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string PS_Camera_Name
            {
            get
                {
                return this._PS_Camera_Name;
                }
            set
                {
                if(!(this._PS_Camera_Name != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
               // this.ReportPropertyChanging(vw_GetCameraDetails.(7850));
                IL_1D:
                this._PS_Camera_Name = StructuralObject.SetValidValue(value, false);
              //  this.ReportPropertyChanged(vw_GetCameraDetails.(7850));
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
        public string PS_Camera_Make
            {
            get
                {
                return this._PS_Camera_Make;
                }
            set
                {
                if(!(this._PS_Camera_Make != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
              //  this.ReportPropertyChanging(vw_GetCameraDetails.(7871));
                IL_1D:
                this._PS_Camera_Make = StructuralObject.SetValidValue(value, false);
              //  this.ReportPropertyChanged(vw_GetCameraDetails.(7871));
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
        public string PS_Camera_Model
            {
            get
                {
                return this._PS_Camera_Model;
                }
            set
                {
                if(!(this._PS_Camera_Model != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
              //  this.ReportPropertyChanging(vw_GetCameraDetails.(7892));
                IL_1D:
                this._PS_Camera_Model = StructuralObject.SetValidValue(value, false);
             //   this.ReportPropertyChanged(vw_GetCameraDetails.(7892));
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

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_AssignTo
            {
            get
                {
                return this._PS_AssignTo;
                }
            set
                {
              //  this.ReportPropertyChanging(vw_GetCameraDetails.(7913));
                this._PS_AssignTo = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(vw_GetCameraDetails.(7913));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string PS_Camera_Start_Series
            {
            get
                {
                return this._PS_Camera_Start_Series;
                }
            set
                {
                if(!(this._PS_Camera_Start_Series != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
             //   this.ReportPropertyChanging(vw_GetCameraDetails.(7930));
                IL_1D:
                this._PS_Camera_Start_Series = StructuralObject.SetValidValue(value, false);
             //   this.ReportPropertyChanged(vw_GetCameraDetails.(7930));
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
        public int PS_Updatedby
            {
            get
                {
                return this._PS_Updatedby;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Updatedby == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(vw_GetCameraDetails.(7963));
                this._PS_Updatedby = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
             //   this.ReportPropertyChanged(vw_GetCameraDetails.(7963));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public DateTime PS_UpdatedDate
            {
            get
                {
                return this._PS_UpdatedDate;
                }
            set
                {
                if(this._PS_UpdatedDate != value)
                    {
                    //     string expr_54 = vw_GetCameraDetails.(7980);
                    //if(3 != 0)
                    //    {
                    //    this.ReportPropertyChanging(expr_54);
                    //    }
                    this._PS_UpdatedDate = StructuralObject.SetValidValue(value);
                    //if(!false)
                    //    {
                    //    this.ReportPropertyChanged(vw_GetCameraDetails.(7980));
                    //    }
                    //}
                    }
                }
            }
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
             //   this.ReportPropertyChanging(vw_GetCameraDetails.(7829));
                this._PS_Camera_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
            //    this.ReportPropertyChanged(vw_GetCameraDetails.(7829));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_CameraFolder
            {
            get
                {
                return this._PS_CameraFolder;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(vw_GetCameraDetails.(18542));
                    this._PS_CameraFolder = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetCameraDetails.(18542));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
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
              //  this.ReportPropertyChanging(vw_GetCameraDetails.(8001));
                this._PS_Camera_IsDeleted = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(vw_GetCameraDetails.(8001));
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
              //  this.ReportPropertyChanging(vw_GetCameraDetails.(8030));
                this._PS_Camera_ID = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(vw_GetCameraDetails.(8030));
                }
            }

        public static vw_GetCameraDetails Createvw_GetCameraDetails ( string dG_Camera_Name, string dG_Camera_Make, string dG_Camera_Model, string dG_Camera_Start_Series, int dG_Updatedby, DateTime dG_UpdatedDate, int dG_Camera_pkey )
            {
            return new vw_GetCameraDetails
                {
                PS_Camera_Name = dG_Camera_Name,
                PS_Camera_Make = dG_Camera_Make,
                PS_Camera_Model = dG_Camera_Model,
                PS_Camera_Start_Series = dG_Camera_Start_Series,
                PS_Updatedby = dG_Updatedby,
                PS_UpdatedDate = dG_UpdatedDate,
                PS_Camera_pkey = dG_Camera_pkey
                };
            }

        static vw_GetCameraDetails ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(vw_GetCameraDetails));
            }

        }
    }
