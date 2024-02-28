using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    public class PS_Actions_Type : EntityObject
        {

        private int _PS_Actions_pkey;

		private string _PS_Actions_Name;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
		public int PS_Actions_pkey
		{
			get
			{
				return this._PS_Actions_pkey;
			}
			set
			{
				if (!true)
				{
					goto IL_29;
				}
				if (this._PS_Actions_pkey == value)
				{
					goto IL_42;
				}
				IL_0E:
				//this.ReportPropertyChanging(DG_Actions_Type.(6153));
				this._PS_Actions_pkey = StructuralObject.SetValidValue(value);
				IL_29:
				if (false)
				{
					goto IL_0E;
				}
				//this.ReportPropertyChanged(DG_Actions_Type.(6153));
				IL_42:
				if (!false)
				{
					return;
				}
				goto IL_0E;
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public string DG_Actions_Name
		{
			get
			{
				return this._PS_Actions_Name;
			}
			set
			{
				do
				{
					//this.ReportPropertyChanging(DG_Actions_Type.(6174));
					this._PS_Actions_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //{
                    //    if (!false)
                    //    {
                    //        this.ReportPropertyChanged(DG_Actions_Type.(6174));
                    //    }
                    //}
                    //while (false);
				}
				while (false);
			}
		}

        public static PS_Actions_Type CreateDG_Actions_Type ( int dG_Actions_pkey )
            {
            return new PS_Actions_Type
            {
                PS_Actions_pkey = dG_Actions_pkey
            };
            }

		static PS_Actions_Type()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//Strings.CreateGetStringDelegate(typeof(DG_Actions_Type));
		}

        
        }
    }
