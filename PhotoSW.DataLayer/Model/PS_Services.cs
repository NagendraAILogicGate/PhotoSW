using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_Services"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_Services : EntityObject
        {
        private int _PS_Service_Id;

        private string _PS_Sevice_Name;

        private string _PS_Service_Display_Name;

        private string _PS_Service_Path;

        private bool? _IsInterface;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Service_Id
            {
            get
                {
                return this._PS_Service_Id;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Service_Id == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
                //this.ReportPropertyChanging(DG_Services.(15937));
                this._PS_Service_Id = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
                //this.ReportPropertyChanged(DG_Services.(15937));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string PS_Sevice_Name
            {
            get
                {
                return this._PS_Sevice_Name;
                }
            set
                {
                do
                    {
                    //this.ReportPropertyChanging(DG_Services.(15958));
                    this._PS_Sevice_Name = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Services.(15958));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string PS_Service_Display_Name
            {
            get
                {
                return this._PS_Service_Display_Name;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Services.(15979));
                    this._PS_Service_Display_Name = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Services.(15979));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Service_Path
            {
            get
                {
                return this._PS_Service_Path;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Services.(16012));
                    this._PS_Service_Path = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Services.(16012));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? IsInterface
            {
            get
                {
                return this._IsInterface;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Services.(16033));
                this._IsInterface = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Services.(16033));
                }
            }

        public static PS_Services CreateDG_Services ( int dG_Service_Id, string dG_Sevice_Name, string dG_Service_Display_Name )
            {
            if(5 == 0)
                {
                goto IL_23;
                }
            PS_Services expr_28 = new PS_Services();
            PS_Services dG_Services;
            if(3 != 0)
                {
                dG_Services = expr_28;
                }
            dG_Services.PS_Service_Id = dG_Service_Id;
            IL_0F:
            PS_Services expr_3F = dG_Services;
            if(5 != 0)
                {
                expr_3F.PS_Sevice_Name = dG_Sevice_Name;
                }
            if(!false)
                {
                dG_Services.PS_Service_Display_Name = dG_Service_Display_Name;
                }
            IL_23:
            if(5 != 0)
                {
                return dG_Services;
                }
            goto IL_0F;
            }

        static PS_Services ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_Services));
            }


        }
    }
