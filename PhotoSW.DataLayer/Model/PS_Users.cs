using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "DG_Users"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_Users : EntityObject
        {
        private int _PS_User_pkey;

        private string _PS_User_Name;

        private string _PS_User_First_Name;

        private string _PS_User_Last_Name;

        private string _PS_User_Password;

        private int _PS_User_Roles_Id;

        private int _PS_Location_ID;

        private bool? _PS_User_Status;

        private string _PS_User_PhoneNo;

        private string _PS_User_Email;

        private DateTime? _PS_User_CreatedDate;

        private string _SyncCode;

        private bool _IsSynced;

        private int _PS_Substore_ID;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_User_pkey
            {
            get
                {
                return this._PS_User_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_User_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(DG_Users.(16970));
                this._PS_User_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(DG_Users.(16970));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string PS_User_Name
            {
            get
                {
                return this._PS_User_Name;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Users.(16987));
                    this._PS_User_Name = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Users.(16987));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string PS_User_First_Name
            {
            get
                {
                return this._PS_User_First_Name;
                }
            set
                {
                do
                    {
                    //this.ReportPropertyChanging(DG_Users.(17004));
                    this._PS_User_First_Name = StructuralObject.SetValidValue(value, false);
                    ////do
                    ////    {
                    ////    if(!false)
                    ////        {
                    ////        this.ReportPropertyChanged(DG_Users.(17004));
                    ////        }
                    ////    }
                    ////while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_User_Last_Name
            {
            get
                {
                return this._PS_User_Last_Name;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Users.(17029));
                    this._PS_User_Last_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Users.(17029));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string PS_User_Password
            {
            get
                {
                return this._PS_User_Password;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_Users.(17054));
                    this._PS_User_Password = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Users.(17054));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_User_Roles_Id
            {
            get
                {
                return this._PS_User_Roles_Id;
                }
            set
                {
            //    this.ReportPropertyChanging(DG_Users.(12386));
                this._PS_User_Roles_Id = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(DG_Users.(12386));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_Location_ID
            {
            get
                {
                return this._PS_Location_ID;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_Users.(16740));
                this._PS_Location_ID = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(DG_Users.(16740));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_User_Status
            {
            get
                {
                return this._PS_User_Status;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_Users.(17079));
                this._PS_User_Status = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Users.(17079));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_User_PhoneNo
            {
            get
                {
                return this._PS_User_PhoneNo;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(DG_Users.(17100));
                    this._PS_User_PhoneNo = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Users.(17100));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_User_Email
            {
            get
                {
                return this._PS_User_Email;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(DG_Users.(17121));
                    this._PS_User_Email = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Users.(17121));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? PS_User_CreatedDate
            {
            get
                {
                return this._PS_User_CreatedDate;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Users.(17142));
                this._PS_User_CreatedDate = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Users.(17142));
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
                //    this.ReportPropertyChanging(DG_Users.(6873));
                    this._SyncCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Users.(6873));
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
             //   this.ReportPropertyChanging(DG_Users.(6886));
                this._IsSynced = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(DG_Users.(6886));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_Substore_ID
            {
            get
                {
                return this._PS_Substore_ID;
                }
            set
                {
           //     this.ReportPropertyChanging(DG_Users.(17171));
                this._PS_Substore_ID = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(DG_Users.(17171));
                }
            }

        public static PS_Users CreateDG_Users ( int dG_User_pkey, string dG_User_Name, string dG_User_First_Name, string dG_User_Password, int dG_User_Roles_Id, int dG_Location_ID, bool isSynced, int dG_Substore_ID )
            {
            PS_Users dG_Users;
            if(7 != 0)
                {
                if(false)
                    {
                    goto IL_27;
                    }
                PS_Users expr_49 = new PS_Users();
                if(!false)
                    {
                    dG_Users = expr_49;
                    }
                dG_Users.PS_User_pkey = dG_User_pkey;
                dG_Users.PS_User_Name = dG_User_Name;
                dG_Users.PS_User_First_Name = dG_User_First_Name;
                }
            dG_Users.PS_User_Password = dG_User_Password;
            IL_27:
            dG_Users.PS_User_Roles_Id = dG_User_Roles_Id;
            dG_Users.PS_Location_ID = dG_Location_ID;
            dG_Users.IsSynced = isSynced;
            dG_Users.PS_Substore_ID = dG_Substore_ID;
            return dG_Users;
            }

        static PS_Users ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_Users));
            }

        }
    }
