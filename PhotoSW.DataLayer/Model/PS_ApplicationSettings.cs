using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "DG_ApplicationSettings"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_ApplicationSettings : EntityObject
        {
        private Guid _PS_ApplicationID;

        private DateTime? _PS_LastSync;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public Guid PS_ApplicationID
            {
            get
                {
                return this._PS_ApplicationID;
                }
            set
                {
                if(this._PS_ApplicationID != value)
                    {
                   // string expr_54 = PS_ApplicationSettings.(6613);
                    if(3 != 0)
                        {
                     //   this.ReportPropertyChanging(expr_54);
                        }
                    this._PS_ApplicationID = StructuralObject.SetValidValue(value);
                    if(!false)
                        {
                       // this.ReportPropertyChanged(DG_ApplicationSettings.(6613));
                        }
                    }
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? PS_LastSync
            {
            get
                {
                return this._PS_LastSync;
                }
            set
                {
               // this.ReportPropertyChanging(DG_ApplicationSettings.(6638));
                this._PS_LastSync = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_ApplicationSettings.(6638));
                }
            }

        public static PS_ApplicationSettings CreateDG_ApplicationSettings ( Guid dG_ApplicationID )
            {
            return new PS_ApplicationSettings
                {
                PS_ApplicationID = dG_ApplicationID
                };
            }

        static PS_ApplicationSettings ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_ApplicationSettings));
            }



        }
    }
