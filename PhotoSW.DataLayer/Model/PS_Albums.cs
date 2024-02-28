using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_Albums"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_Albums : EntityObject
        {
        private int _PS_Albums_pkey;

		private int? _PS_Albums_Name;

		private DateTime? _PS_Albums_CreatedOn;

		private int? _PS_Albums_CreatedBy;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
		public int DG_Albums_pkey
		{
			get
			{
				return this._PS_Albums_pkey;
			}
			set
			{
				if (!true)
				{
					goto IL_29;
				}
				if (this._PS_Albums_pkey == value)
				{
					goto IL_42;
				}
				IL_0E:
				//this.ReportPropertyChanging(DG_Albums.(6401));
				this._PS_Albums_pkey = StructuralObject.SetValidValue(value);
				IL_29:
				if (false)
				{
					goto IL_0E;
				}
				//this.ReportPropertyChanged(DG_Albums.(6401));
				IL_42:
				if (!false)
				{
					return;
				}
				goto IL_0E;
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public int? DG_Albums_Name
		{
			get
			{
				return this._PS_Albums_Name;
			}
			set
			{
				//this.ReportPropertyChanging(DG_Albums.(6422));
				this._PS_Albums_Name = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(DG_Albums.(6422));
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public DateTime? DG_Albums_CreatedOn
		{
			get
			{
				return this._PS_Albums_CreatedOn;
			}
			set
			{
				//this.ReportPropertyChanging(DG_Albums.(6443));
				this._PS_Albums_CreatedOn = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(DG_Albums.(6443));
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public int? DG_Albums_CreatedBy
		{
			get
			{
				return this._PS_Albums_CreatedBy;
			}
			set
			{
				//this.ReportPropertyChanging(DG_Albums.(6472));
				this._PS_Albums_CreatedBy = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(DG_Albums.(6472));
			}
		}

		public static PS_Albums CreateDG_Albums(int dG_Albums_pkey)
		{
			return new PS_Albums
			{
				DG_Albums_pkey = dG_Albums_pkey
			};
		}

		static PS_Albums()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//Strings.CreateGetStringDelegate(typeof(DG_Albums));
		}

        }
    }
