using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_CashBox"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_CashBox : EntityObject
        {

        private int _Id;

        private string _Reason;

        private int _UserId;

        private DateTime _CreatedDate;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int Id
            {
            get
                {
                return this._Id;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._Id == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(DG_CashBox.(7497));
                this._Id = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
                //this.ReportPropertyChanged(DG_CashBox.(7497));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string Reason
            {
            get
                {
                return this._Reason;
                }
            set
                {
                do
                    {
                    //this.ReportPropertyChanging(DG_CashBox.(7502));
                    this._Reason = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_CashBox.(7502));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int UserId
            {
            get
                {
                return this._UserId;
                }
            set
                {
               // this.ReportPropertyChanging(DG_CashBox.(3258));
                this._UserId = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_CashBox.(3258));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public DateTime CreatedDate
            {
            get
                {
                return this._CreatedDate;
                }
            set
                {
               // this.ReportPropertyChanging(DG_CashBox.(7511));
                this._CreatedDate = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_CashBox.(7511));
                }
            }

        public static PS_CashBox CreateDG_CashBox ( int id, string reason, int userId, DateTime createdDate )
            {
            PS_CashBox dG_CashBox;
            while(true)
                {
                dG_CashBox = new PS_CashBox();
                if(5 != 0 && 8 != 0)
                    {
                    dG_CashBox.Id = id;
                    dG_CashBox.Reason = reason;
                    if(3 == 0)
                        {
                        return dG_CashBox;
                        }
                    if(!false)
                        {
                        break;
                        }
                    }
                }
            dG_CashBox.UserId = userId;
            dG_CashBox.CreatedDate = createdDate;
            return dG_CashBox;
            }

        static PS_CashBox ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_CashBox));
            }


        }
    }
