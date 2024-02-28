using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_Emails"), DataContract(IsReference = true)]
    [Serializable]
     public class PS_Emails : EntityObject
        {
        private int _PS_Email_pkey;

        private string _PS_OrderId;

        private string _PS_Email_To;

        private string _PS_Email_Bcc;

        private string _PS_EmailSender;

        private string _PS_Message;

        private bool? _PS_Email_IsSent;

        private DateTime? _PS_DateTime;

        private string _PS_MediaName;

        private string _PS_OtherMessage;

        private string _PS_MessageType;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Email_pkey
            {
            get
                {
                return this._PS_Email_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Email_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(DG_Emails.(8990));
                this._PS_Email_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(DG_Emails.(8990));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_OrderId
            {
            get
                {
                return this._PS_OrderId;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Emails.(9011));
                    this._PS_OrderId = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Emails.(9011));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Email_To
            {
            get
                {
                return this._PS_Email_To;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_Emails.(9028));
                    this._PS_Email_To = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Emails.(9028));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Email_Bcc
            {
            get
                {
                return this._PS_Email_Bcc;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Emails.(9045));
                    this._PS_Email_Bcc = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Emails.(9045));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_EmailSender
            {
            get
                {
                return this._PS_EmailSender;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Emails.(9062));
                    this._PS_EmailSender = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Emails.(9062));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Message
            {
            get
                {
                return this._PS_Message;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(DG_Emails.(9083));
                    this._PS_Message = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Emails.(9083));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Email_IsSent
            {
            get
                {
                return this._PS_Email_IsSent;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Emails.(9100));
                this._PS_Email_IsSent = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Emails.(9100));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? PS_DateTime
            {
            get
                {
                return this._PS_DateTime;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Emails.(9121));
                this._PS_DateTime = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Emails.(9121));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_MediaName
            {
            get
                {
                return this._PS_MediaName;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(DG_Emails.(9138));
                    this._PS_MediaName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Emails.(9138));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_OtherMessage
            {
            get
                {
                return this._PS_OtherMessage;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Emails.(9155));
                    this._PS_OtherMessage = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Emails.(9155));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_MessageType
            {
            get
                {
                return this._PS_MessageType;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Emails.(9176));
                    this._PS_MessageType = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Emails.(9176));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static PS_Emails CreateDG_Emails ( int dG_Email_pkey )
            {
            return new PS_Emails
                {
                PS_Email_pkey = dG_Email_pkey
                };
            }

        static PS_Emails ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(PS_Emails));
            }


        }
    }
