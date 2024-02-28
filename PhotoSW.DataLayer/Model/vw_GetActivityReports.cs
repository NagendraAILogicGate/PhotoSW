using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetActivityReports"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetActivityReports : EntityObject
        {
        private string _DG_Actions_Name;

        private DateTime? _DG_Acitivity_Date;

        private string _DG_User_Name;

        private string _DG_User_First_Name;

        private string _DG_User_Last_Name;

        private string _Name;

        private string _DG_Acitivity_Descrption;

        private int _DG_Actions_pkey;

        private int _DG_User_pkey;

        private int _DG_Acitivity_Action_Pkey;

        private DateTime? _ActivityDate;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string DG_Actions_Name
            {
            get
                {
                return this._DG_Actions_Name;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(vw_GetActivityReports.(6792));
                    this._DG_Actions_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetActivityReports.(6792));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? DG_Acitivity_Date
            {
            get
                {
                return this._DG_Acitivity_Date;
                }
            set
                {
               // this.ReportPropertyChanging(vw_GetActivityReports.(6879));
                this._DG_Acitivity_Date = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(vw_GetActivityReports.(6879));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string DG_User_Name
            {
            get
                {
                return this._DG_User_Name;
                }
            set
                {
                if(!(this._DG_User_Name != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
              //  this.ReportPropertyChanging(vw_GetActivityReports.(17093));
                IL_1D:
                this._DG_User_Name = StructuralObject.SetValidValue(value, false);
              //  this.ReportPropertyChanged(vw_GetActivityReports.(17093));
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
        public string DG_User_First_Name
            {
            get
                {
                return this._DG_User_First_Name;
                }
            set
                {
                if(!(this._DG_User_First_Name != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
              //  this.ReportPropertyChanging(vw_GetActivityReports.(17110));
                IL_1D:
                this._DG_User_First_Name = StructuralObject.SetValidValue(value, false);
              //  this.ReportPropertyChanged(vw_GetActivityReports.(17110));
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
        public string DG_User_Last_Name
            {
            get
                {
                return this._DG_User_Last_Name;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(vw_GetActivityReports.(17135));
                    this._DG_User_Last_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetActivityReports.(17135));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string Name
            {
            get
                {
                return this._Name;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(vw_GetActivityReports.(17589));
                    this._Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetActivityReports.(17589));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string DG_Acitivity_Descrption
            {
            get
                {
                return this._DG_Acitivity_Descrption;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(vw_GetActivityReports.(6925));
                    this._DG_Acitivity_Descrption = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetActivityReports.(6925));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int DG_Actions_pkey
            {
            get
                {
                return this._DG_Actions_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._DG_Actions_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(vw_GetActivityReports.(6771));
                this._DG_Actions_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
             //   this.ReportPropertyChanged(vw_GetActivityReports.(6771));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int DG_User_pkey
            {
            get
                {
                return this._DG_User_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._DG_User_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(vw_GetActivityReports.(17076));
                this._DG_User_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(vw_GetActivityReports.(17076));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int DG_Acitivity_Action_Pkey
            {
            get
                {
                return this._DG_Acitivity_Action_Pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._DG_Acitivity_Action_Pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(vw_GetActivityReports.(6813));
                this._DG_Acitivity_Action_Pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
           //     this.ReportPropertyChanged(vw_GetActivityReports.(6813));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? ActivityDate
            {
            get
                {
                return this._ActivityDate;
                }
            set
                {
             //   this.ReportPropertyChanging(vw_GetActivityReports.(18470));
                this._ActivityDate = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(vw_GetActivityReports.(18470));
                }
            }

        public static vw_GetActivityReports Createvw_GetActivityReports ( string dG_User_Name, string dG_User_First_Name, int dG_Actions_pkey, int dG_User_pkey, int dG_Acitivity_Action_Pkey )
            {
            vw_GetActivityReports vw_GetActivityReports;
            if(true)
                {
                vw_GetActivityReports = new vw_GetActivityReports();
                do
                    {
                    vw_GetActivityReports.DG_User_Name = dG_User_Name;
                    }
                while(false);
                if(6 == 0)
                    {
                    return vw_GetActivityReports;
                    }
                vw_GetActivityReports.DG_User_First_Name = dG_User_First_Name;
                vw_GetActivityReports.DG_Actions_pkey = dG_Actions_pkey;
                }
            vw_GetActivityReports.DG_User_pkey = dG_User_pkey;
            vw_GetActivityReports.DG_Acitivity_Action_Pkey = dG_Acitivity_Action_Pkey;
            return vw_GetActivityReports;
            }

        static vw_GetActivityReports ()
            {
            // Note: this type is marked as 'beforefieldinit'.
         //   Strings.CreateGetStringDelegate(typeof(vw_GetActivityReports));
            }


        }
    }
