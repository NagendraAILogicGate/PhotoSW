using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_Store"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_Store : EntityObject
        {
        private int _PS_Store_pkey;

        private string _PS_Store_Name;

        private string _Country;

        private string _PS_CentralServerIP;

        private Guid? _PS_StoreCode;

        private string _PS_CenetralServerUName;

        private string _PS_CenetralServerPassword;

        private decimal? _PS_PreferredTimeToSyncFrom;

        private decimal? _PS_PreferredTimeToSyncTo;

        private string _PS_QRCodeWebUrl;

        private string _CountryCode;

        private string _StoreCode;

        private string _BillReceiptTitle;

        private string _TaxRegistrationNumber;

        private string _TaxRegistrationText;

        private string _Address;

        private string _PhoneNo;

        private long? _TaxMinSequenceNo;

        private long? _TaxMaxSequenceNo;

        private bool? _IsSequenceNoRequired;

        private bool? _IsTaxEnabled;

        private string _WebsiteURL;

        private string _Email;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Store_pkey
            {
            get
                {
                return this._PS_Store_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Store_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(DG_Store.(16074));
                this._PS_Store_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
               // this.ReportPropertyChanged(DG_Store.(16074));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string PS_Store_Name
            {
            get
                {
                return this._PS_Store_Name;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_Store.(16095));
                    this._PS_Store_Name = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Store.(16095));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string Country
            {
            get
                {
                return this._Country;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_Store.(16116));
                    this._Country = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Store.(16116));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_CentralServerIP
            {
            get
                {
                return this._PS_CentralServerIP;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Store.(16129));
                    this._PS_CentralServerIP = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Store.(16129));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public Guid? PS_StoreCode
            {
            get
                {
                return this._PS_StoreCode;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Store.(16154));
                this._PS_StoreCode = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Store.(16154));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_CenetralServerUName
            {
            get
                {
                return this._PS_CenetralServerUName;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Store.(16171));
                    this._PS_CenetralServerUName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Store.(16171));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_CenetralServerPassword
            {
            get
                {
                return this._PS_CenetralServerPassword;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Store.(16204));
                    this._PS_CenetralServerPassword = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Store.(16204));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? PS_PreferredTimeToSyncFrom
            {
            get
                {
                return this._PS_PreferredTimeToSyncFrom;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_Store.(16241));
                this._PS_PreferredTimeToSyncFrom = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Store.(16241));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? PS_PreferredTimeToSyncTo
            {
            get
                {
                return this._PS_PreferredTimeToSyncTo;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_Store.(16278));
                this._PS_PreferredTimeToSyncTo = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(DG_Store.(16278));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_QRCodeWebUrl
            {
            get
                {
                return this._PS_QRCodeWebUrl;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(DG_Store.(16311));
                    this._PS_QRCodeWebUrl = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Store.(16311));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
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
                 //   this.ReportPropertyChanging(DG_Store.(16332));
                    this._CountryCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Store.(16332));
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
                 //   this.ReportPropertyChanging(DG_Store.(16349));
                    this._StoreCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Store.(16349));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string BillReceiptTitle
            {
            get
                {
                return this._BillReceiptTitle;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(DG_Store.(16362));
                    this._BillReceiptTitle = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Store.(16362));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string TaxRegistrationNumber
            {
            get
                {
                return this._TaxRegistrationNumber;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_Store.(16387));
                    this._TaxRegistrationNumber = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Store.(16387));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string TaxRegistrationText
            {
            get
                {
                return this._TaxRegistrationText;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Store.(16416));
                    this._TaxRegistrationText = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Store.(16416));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string Address
            {
            get
                {
                return this._Address;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_Store.(16445));
                    this._Address = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Store.(16445));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PhoneNo
            {
            get
                {
                return this._PhoneNo;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(DG_Store.(16458));
                    this._PhoneNo = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Store.(16458));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public long? TaxMinSequenceNo
            {
            get
                {
                return this._TaxMinSequenceNo;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Store.(16471));
                this._TaxMinSequenceNo = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Store.(16471));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public long? TaxMaxSequenceNo
            {
            get
                {
                return this._TaxMaxSequenceNo;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Store.(16496));
                this._TaxMaxSequenceNo = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Store.(16496));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? IsSequenceNoRequired
            {
            get
                {
                return this._IsSequenceNoRequired;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_Store.(16521));
                this._IsSequenceNoRequired = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Store.(16521));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? IsTaxEnabled
            {
            get
                {
                return this._IsTaxEnabled;
                }
            set
                {
            //    this.ReportPropertyChanging(DG_Store.(16550));
                this._IsTaxEnabled = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(DG_Store.(16550));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string WebsiteURL
            {
            get
                {
                return this._WebsiteURL;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(DG_Store.(16567));
                    this._WebsiteURL = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Store.(16567));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string Email
            {
            get
                {
                return this._Email;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(DG_Store.(16584));
                    this._Email = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Store.(16584));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static PS_Store CreateDG_Store ( int dG_Store_pkey, string dG_Store_Name, string country )
            {
            if(5 == 0)
                {
                goto IL_23;
                }
            PS_Store expr_28 = new PS_Store();
            PS_Store dG_Store;
            if(3 != 0)
                {
                dG_Store = expr_28;
                }
            dG_Store.PS_Store_pkey = dG_Store_pkey;
            IL_0F:
            PS_Store expr_3F = dG_Store;
            if(5 != 0)
                {
                expr_3F.PS_Store_Name = dG_Store_Name;
                }
            if(!false)
                {
                dG_Store.Country = country;
                }
            IL_23:
            if(5 != 0)
                {
                return dG_Store;
                }
            goto IL_0F;
            }

        static PS_Store ()
            {
            // Note: this type is marked as 'beforefieldinit'.
            //Strings.CreateGetStringDelegate(typeof(DG_Store));
            }


        }
    }
