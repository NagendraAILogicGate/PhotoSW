using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "ErrorLog"), DataContract(IsReference = true)]
    [Serializable]
    public class ErrorLog : EntityObject
        {
        private int _ErrorLogID;

        private DateTime _ErrorTime;

        private string _UserName;

        private int _ErrorNumber;

        private int? _ErrorSeverity;

        private int? _ErrorState;

        private string _ErrorProcedure;

        private int? _ErrorLine;

        private string _ErrorMessage;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int ErrorLogID
            {
            get
                {
                return this._ErrorLogID;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._ErrorLogID == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(ErrorLog.(17309));
                this._ErrorLogID = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
             //   this.ReportPropertyChanged(ErrorLog.(17309));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public DateTime ErrorTime
            {
            get
                {
                return this._ErrorTime;
                }
            set
                {
                if(this._ErrorTime != value)
                    {
                  //  string expr_54 = ErrorLog.(17326);
                    //if(3 != 0)
                    //    {
                    //    this.ReportPropertyChanging(expr_54);
                    //    }
                    this._ErrorTime = StructuralObject.SetValidValue(value);
                    //if(!false)
                    //    {
                    //    this.ReportPropertyChanged(ErrorLog.(17326));
                    //    }
                    }
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string UserName
            {
            get
                {
                return this._UserName;
                }
            set
                {
                if(!(this._UserName != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
              //  this.ReportPropertyChanging(ErrorLog.(3959));
                IL_1D:
                this._UserName = StructuralObject.SetValidValue(value, false);
              //  this.ReportPropertyChanged(ErrorLog.(3959));
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
        public int ErrorNumber
            {
            get
                {
                return this._ErrorNumber;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._ErrorNumber == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(ErrorLog.(17339));
                this._ErrorNumber = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(ErrorLog.(17339));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? ErrorSeverity
            {
            get
                {
                return this._ErrorSeverity;
                }
            set
                {
              //  this.ReportPropertyChanging(ErrorLog.(17356));
                this._ErrorSeverity = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(ErrorLog.(17356));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? ErrorState
            {
            get
                {
                return this._ErrorState;
                }
            set
                {
             //   this.ReportPropertyChanging(ErrorLog.(17377));
                this._ErrorState = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(ErrorLog.(17377));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string ErrorProcedure
            {
            get
                {
                return this._ErrorProcedure;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(ErrorLog.(17394));
                    this._ErrorProcedure = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(ErrorLog.(17394));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? ErrorLine
            {
            get
                {
                return this._ErrorLine;
                }
            set
                {
              //  this.ReportPropertyChanging(ErrorLog.(17415));
                this._ErrorLine = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(ErrorLog.(17415));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string ErrorMessage
            {
            get
                {
                return this._ErrorMessage;
                }
            set
                {
                if(!(this._ErrorMessage != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
             //   this.ReportPropertyChanging(ErrorLog.(6324));
                IL_1D:
                this._ErrorMessage = StructuralObject.SetValidValue(value, false);
             //   this.ReportPropertyChanged(ErrorLog.(6324));
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

        public static ErrorLog CreateErrorLog ( int errorLogID, DateTime errorTime, string userName, int errorNumber, string errorMessage )
            {
            ErrorLog errorLog;
            if(true)
                {
                errorLog = new ErrorLog();
                do
                    {
                    errorLog.ErrorLogID = errorLogID;
                    }
                while(false);
                if(6 == 0)
                    {
                    return errorLog;
                    }
                errorLog.ErrorTime = errorTime;
                errorLog.UserName = userName;
                }
            errorLog.ErrorNumber = errorNumber;
            errorLog.ErrorMessage = errorMessage;
            return errorLog;
            }

        static ErrorLog ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(ErrorLog));
            }


        }
    }
