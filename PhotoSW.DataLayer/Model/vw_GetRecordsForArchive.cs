using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetRecordsForArchive"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetRecordsForArchive : EntityObject
        {
        private int _PS_Photos_pkey;

        private string _PS_Photos_FileName;

        private DateTime _PS_Photos_CreatedOn;

        private bool? _PS_Photos_Archive;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Photos_pkey
            {
            get
                {
                return this._PS_Photos_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Photos_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
             //   this.ReportPropertyChanging(vw_GetRecordsForArchive.(6209));
                this._PS_Photos_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
            //    this.ReportPropertyChanged(vw_GetRecordsForArchive.(6209));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string PS_Photos_FileName
            {
            get
                {
                return this._PS_Photos_FileName;
                }
            set
                {
                if(!(this._PS_Photos_FileName != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
            //    this.ReportPropertyChanging(vw_GetRecordsForArchive.(6230));
                IL_1D:
                this._PS_Photos_FileName = StructuralObject.SetValidValue(value, false);
            //    this.ReportPropertyChanged(vw_GetRecordsForArchive.(6230));
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
        public DateTime PS_Photos_CreatedOn
            {
            get
                {
                return this._PS_Photos_CreatedOn;
                }
            set
                {
                if(this._PS_Photos_CreatedOn != value)
                    {
                    //string expr_54 = vw_GetRecordsForArchive.(6255);
                    //if(3 != 0)
                    //    {
                    //    this.ReportPropertyChanging(expr_54);
                    //    }
                    this._PS_Photos_CreatedOn = StructuralObject.SetValidValue(value);
                    //if(!false)
                    //    {
                    //    this.ReportPropertyChanged(vw_GetRecordsForArchive.(6255));
                    //    }
                    }
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Photos_Archive
            {
            get
                {
                return this._PS_Photos_Archive;
                }
            set
                {
            //    this.ReportPropertyChanging(vw_GetRecordsForArchive.(6576));
                this._PS_Photos_Archive = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(vw_GetRecordsForArchive.(6576));
                }
            }

        public static vw_GetRecordsForArchive Createvw_GetRecordsForArchive ( int dG_Photos_pkey, string dG_Photos_FileName, DateTime dG_Photos_CreatedOn )
            {
            if(5 == 0)
                {
                goto IL_23;
                }
            vw_GetRecordsForArchive expr_28 = new vw_GetRecordsForArchive();
            vw_GetRecordsForArchive vw_GetRecordsForArchive;
            if(3 != 0)
                {
                vw_GetRecordsForArchive = expr_28;
                }
            vw_GetRecordsForArchive.PS_Photos_pkey = dG_Photos_pkey;
            IL_0F:
            vw_GetRecordsForArchive expr_3F = vw_GetRecordsForArchive;
            if(5 != 0)
                {
                expr_3F.PS_Photos_FileName = dG_Photos_FileName;
                }
            if(!false)
                {
                vw_GetRecordsForArchive.PS_Photos_CreatedOn = dG_Photos_CreatedOn;
                }
            IL_23:
            if(5 != 0)
                {
                return vw_GetRecordsForArchive;
                }
            goto IL_0F;
            }

        static vw_GetRecordsForArchive ()
            {
            // Note: this type is marked as 'beforefieldinit'.
         //   Strings.CreateGetStringDelegate(typeof(vw_GetRecordsForArchive));
            }


        }
    }
