using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetUserDetails"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetUserDetails : EntityObject
        {
        private int _PS_User_pkey;

        private string _PS_User_Role;

        private string _PS_User_First_Name;

        private string _PS_User_Last_Name;

        private string _PS_User_Password;

        private string _PS_User_Name;

        private int _PS_User_Roles_Id;

        private string _PS_Location_Name;

        private int _PS_Store_ID;

        private int _PS_Location_pkey;

        private bool? _PS_User_Status;

        private string _PS_User_PhoneNo;

        private string _UserName;

        private string _StatusName;

        private string _PS_User_Email;

        private string _PS_Store_Name;

        private string _CountryCode;

        private string _StoreCode;

        private int _PS_Substore_ID;

        //[NonSerialized]
        //internal static GetString ;

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
             //   this.ReportPropertyChanging(vw_GetUserDetails.(17419));
                this._PS_User_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
            //    this.ReportPropertyChanged(vw_GetUserDetails.(17419));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string PS_User_Role
            {
            get
                {
                return this._PS_User_Role;
                }
            set
                {
                if(!(this._PS_User_Role != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
            //    this.ReportPropertyChanging(vw_GetUserDetails.(17402));
                IL_1D:
                this._PS_User_Role = StructuralObject.SetValidValue(value, false);
           //     this.ReportPropertyChanged(vw_GetUserDetails.(17402));
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
        public string PS_User_First_Name
            {
            get
                {
                return this._PS_User_First_Name;
                }
            set
                {
                if(!(this._PS_User_First_Name != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
           //     this.ReportPropertyChanging(vw_GetUserDetails.(17453));
                IL_1D:
                this._PS_User_First_Name = StructuralObject.SetValidValue(value, false);
          //      this.ReportPropertyChanged(vw_GetUserDetails.(17453));
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
              //      this.ReportPropertyChanging(vw_GetUserDetails.(17478));
                    this._PS_User_Last_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetUserDetails.(17478));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string PS_User_Password
            {
            get
                {
                return this._PS_User_Password;
                }
            set
                {
                if(!(this._PS_User_Password != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
           //     this.ReportPropertyChanging(vw_GetUserDetails.(17503));
                IL_1D:
                this._PS_User_Password = StructuralObject.SetValidValue(value, false);
           //     this.ReportPropertyChanged(vw_GetUserDetails.(17503));
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
        public string PS_User_Name
            {
            get
                {
                return this._PS_User_Name;
                }
            set
                {
                if(!(this._PS_User_Name != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
           //     this.ReportPropertyChanging(vw_GetUserDetails.(17436));
                IL_1D:
                this._PS_User_Name = StructuralObject.SetValidValue(value, false);
            //    this.ReportPropertyChanged(vw_GetUserDetails.(17436));
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
        public int PS_User_Roles_Id
            {
            get
                {
                return this._PS_User_Roles_Id;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_User_Roles_Id == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
           //     this.ReportPropertyChanging(vw_GetUserDetails.(12835));
                this._PS_User_Roles_Id = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
           //     this.ReportPropertyChanged(vw_GetUserDetails.(12835));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string PS_Location_Name
            {
            get
                {
                return this._PS_Location_Name;
                }
            set
                {
                if(!(this._PS_Location_Name != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
           //     this.ReportPropertyChanging(vw_GetUserDetails.(10433));
                IL_1D:
                this._PS_Location_Name = StructuralObject.SetValidValue(value, false);
           //     this.ReportPropertyChanged(vw_GetUserDetails.(10433));
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
        public int PS_Store_ID
            {
            get
                {
                return this._PS_Store_ID;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Store_ID == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
         //       this.ReportPropertyChanging(vw_GetUserDetails.(10458));
                this._PS_Store_ID = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
          //      this.ReportPropertyChanged(vw_GetUserDetails.(10458));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Location_pkey
            {
            get
                {
                return this._PS_Location_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Location_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
           //     this.ReportPropertyChanging(vw_GetUserDetails.(10408));
                this._PS_Location_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
         //       this.ReportPropertyChanged(vw_GetUserDetails.(10408));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
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
         //       this.ReportPropertyChanging(vw_GetUserDetails.(17528));
                this._PS_User_Status = StructuralObject.SetValidValue(value);
        //        this.ReportPropertyChanged(vw_GetUserDetails.(17528));
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
           //         this.ReportPropertyChanging(vw_GetUserDetails.(17549));
                    this._PS_User_PhoneNo = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetUserDetails.(17549));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string UserName
            {
            get
                {
                return this._UserName;
                }
            set
                {
                do
                    {
            //        this.ReportPropertyChanging(vw_GetUserDetails.(4392));
                    this._UserName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetUserDetails.(4392));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string StatusName
            {
            get
                {
                return this._StatusName;
                }
            set
                {
                if(!(this._StatusName != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
         //       this.ReportPropertyChanging(vw_GetUserDetails.(19021));
                IL_1D:
                this._StatusName = StructuralObject.SetValidValue(value, false);
          //      this.ReportPropertyChanged(vw_GetUserDetails.(19021));
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
            //        this.ReportPropertyChanging(vw_GetUserDetails.(17570));
                    this._PS_User_Email = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetUserDetails.(17570));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string PS_Store_Name
            {
            get
                {
                return this._PS_Store_Name;
                }
            set
                {
                if(!(this._PS_Store_Name != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
          //      this.ReportPropertyChanging(vw_GetUserDetails.(16583));
                IL_1D:
                this._PS_Store_Name = StructuralObject.SetValidValue(value, false);
           //     this.ReportPropertyChanged(vw_GetUserDetails.(16583));
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
        public string CountryCode
            {
            get
                {
                return this._CountryCode;
                }
            set
                {
                do
                    {
            //        this.ReportPropertyChanging(vw_GetUserDetails.(16820));
                    this._CountryCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetUserDetails.(16820));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string StoreCode
            {
            get
                {
                return this._StoreCode;
                }
            set
                {
                do
                    {
           //         this.ReportPropertyChanging(vw_GetUserDetails.(16837));
                    this._StoreCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetUserDetails.(16837));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Substore_ID
            {
            get
                {
                return this._PS_Substore_ID;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Substore_ID == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
           //     this.ReportPropertyChanging(vw_GetUserDetails.(17620));
                this._PS_Substore_ID = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
        //        this.ReportPropertyChanged(vw_GetUserDetails.(17620));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        public static vw_GetUserDetails Createvw_GetUserDetails ( int dG_User_pkey, string dG_User_Role, string dG_User_First_Name, string dG_User_Password, string dG_User_Name, int dG_User_Roles_Id, string dG_Location_Name, int dG_Store_ID, int dG_Location_pkey, string statusName, string dG_Store_Name, int dG_Substore_ID )
            {
            if(false)
                {
                goto IL_63;
                }
            vw_GetUserDetails vw_GetUserDetails = new vw_GetUserDetails();
            IL_0D:
            vw_GetUserDetails.PS_User_pkey = dG_User_pkey;
            if(-1 != 0)
                {
                vw_GetUserDetails.PS_User_Role = dG_User_Role;
                vw_GetUserDetails.PS_User_First_Name = dG_User_First_Name;
                }
            vw_GetUserDetails.PS_User_Password = dG_User_Password;
            vw_GetUserDetails.PS_User_Name = dG_User_Name;
            vw_GetUserDetails.PS_User_Roles_Id = dG_User_Roles_Id;
            if(false)
                {
                return vw_GetUserDetails;
                }
            vw_GetUserDetails.PS_Location_Name = dG_Location_Name;
            vw_GetUserDetails.PS_Store_ID = dG_Store_ID;
            IL_63:
            vw_GetUserDetails.PS_Location_pkey = dG_Location_pkey;
            if(false)
                {
                goto IL_0D;
                }
            vw_GetUserDetails.StatusName = statusName;
            if(6 == 0)
                {
                goto IL_0D;
                }
            vw_GetUserDetails.PS_Store_Name = dG_Store_Name;
            vw_GetUserDetails.PS_Substore_ID = dG_Substore_ID;
            return vw_GetUserDetails;
            }

        static vw_GetUserDetails ()
            {
            // Note: this type is marked as 'beforefieldinit'.
        //    Strings.CreateGetStringDelegate(typeof(vw_GetUserDetails));
            }

        }
    }
