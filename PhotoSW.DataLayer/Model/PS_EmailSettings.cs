using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_EmailSettings"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_EmailSettings : EntityObject
        {

        private int _PS_EmailSettings_pkey;

        private string _PS_MailSendFrom;

        private string _PS_MailSubject;

        private string _PS_MailBody;

        private string _PS_SmtpServername;

        private string _PS_SmtpServerport;

        private bool? _PS_SmtpUserDefaultCredentials;

        private string _PS_SmtpServerUsername;

        private string _PS_SmtpServerPassword;

        private bool? _PS_SmtpServerEnableSSL;

        private string _PS_MailBCC;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_EmailSettings_pkey
            {
            get
                {
                return this._PS_EmailSettings_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_EmailSettings_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
                //this.ReportPropertyChanging(DG_EmailSettings.(9209));
                this._PS_EmailSettings_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(DG_EmailSettings.(9209));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_MailSendFrom
            {
            get
                {
                return this._PS_MailSendFrom;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_EmailSettings.(9238));
                    this._PS_MailSendFrom = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_EmailSettings.(9238));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_MailSubject
            {
            get
                {
                return this._PS_MailSubject;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_EmailSettings.(9259));
                    this._PS_MailSubject = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_EmailSettings.(9259));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_MailBody
            {
            get
                {
                return this._PS_MailBody;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_EmailSettings.(9280));
                    this._PS_MailBody = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_EmailSettings.(9280));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_SmtpServername
            {
            get
                {
                return this._PS_SmtpServername;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_EmailSettings.(9297));
                    this._PS_SmtpServername = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_EmailSettings.(9297));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_SmtpServerport
            {
            get
                {
                return this._PS_SmtpServerport;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_EmailSettings.(9322));
                    this._PS_SmtpServerport = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_EmailSettings.(9322));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_SmtpUserDefaultCredentials
            {
            get
                {
                return this._PS_SmtpUserDefaultCredentials;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_EmailSettings.(9347));
                this._PS_SmtpUserDefaultCredentials = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_EmailSettings.(9347));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_SmtpServerUsername
            {
            get
                {
                return this._PS_SmtpServerUsername;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_EmailSettings.(9388));
                    this.PS_SmtpServerUsername = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_EmailSettings.(9388));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_SmtpServerPassword
            {
            get
                {
                return this._PS_SmtpServerPassword;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_EmailSettings.(9417));
                    this._PS_SmtpServerPassword = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_EmailSettings.(9417));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_SmtpServerEnableSSL
            {
            get
                {
                return this._PS_SmtpServerEnableSSL;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_EmailSettings.(9446));
                this._PS_SmtpServerEnableSSL = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_EmailSettings.(9446));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_MailBCC
            {
            get
                {
                return this._PS_MailBCC;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_EmailSettings.(9479));
                    this._PS_MailBCC = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_EmailSettings.(9479));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static PS_EmailSettings CreateDG_EmailSettings ( int dG_EmailSettings_pkey )
            {
            return new PS_EmailSettings
                {
                PS_EmailSettings_pkey = dG_EmailSettings_pkey
                };
            }

        static PS_EmailSettings ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(DG_EmailSettings));
            }


        }
    }
