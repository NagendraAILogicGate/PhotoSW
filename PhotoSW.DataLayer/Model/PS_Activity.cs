using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_Activity"), DataContract(IsReference = true)]
	[Serializable]
    public class PS_Activity : EntityObject
        {
        private int _PS_Acitivity_Action_Pkey;

		private int? _PS_Acitivity_ActionType;

		private DateTime? _PS_Acitivity_Date;

		private int _PS_Acitivity_By;

		private string _PS_Acitivity_Descrption;

		private int? _PS_Reference_ID;

		private string _SyncCode;

		private bool? _IsSynced;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
		public int PS_Acitivity_Action_Pkey
		{
			get
			{
				return this._PS_Acitivity_Action_Pkey;
			}
			set
			{
				if (!true)
				{
					goto IL_29;
				}
				if (this._PS_Acitivity_Action_Pkey == value)
				{
					goto IL_42;
				}
				IL_0E:
				//this.ReportPropertyChanging(DG_Activity.(6204));
				this._PS_Acitivity_Action_Pkey = StructuralObject.SetValidValue(value);
				IL_29:
				if (false)
				{
					goto IL_0E;
				}
				//this.ReportPropertyChanged(DG_Activity.(6204));
				IL_42:
				if (!false)
				{
					return;
				}
				goto IL_0E;
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public int? PS_Acitivity_ActionType
		{
			get
			{
				return this._PS_Acitivity_ActionType;
			}
			set
			{
				//this.ReportPropertyChanging(DG_Activity.(6237));
				this._PS_Acitivity_ActionType = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(DG_Activity.(6237));
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public DateTime? PS_Acitivity_Date
		{
			get
			{
				return this._PS_Acitivity_Date;
			}
			set
			{
				//this.ReportPropertyChanging(DG_Activity.(6270));
				this._PS_Acitivity_Date = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(DG_Activity.(6270));
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public int PS_Acitivity_By
		{
			get
			{
				return this._PS_Acitivity_By;
			}
			set
			{
				//this.ReportPropertyChanging(DG_Activity.(6295));
				this._PS_Acitivity_By = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(DG_Activity.(6295));
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public string PS_Acitivity_Descrption
		{
			get
			{
				return this._PS_Acitivity_Descrption;
			}
			set
			{
				do
				{
					//this.ReportPropertyChanging(DG_Activity.(6316));
					this._PS_Acitivity_Descrption = StructuralObject.SetValidValue(value, true);
                    //do
                    //{
                    //    if (!false)
                    //    {
                    //        this.ReportPropertyChanged(DG_Activity.(6316));
                    //    }
                    //}
                    //while (false);
				}
				while (false);
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public int? PS_Reference_ID
		{
			get
			{
				return this._PS_Reference_ID;
			}
			set
			{
				//this.ReportPropertyChanging(DG_Activity.(6349));
				this._PS_Reference_ID = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(DG_Activity.(6349));
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public string SyncCode
		{
			get
			{
				return this._SyncCode;
			}
			set
			{
				do
				{
					//this.ReportPropertyChanging(DG_Activity.(6370));
					this._SyncCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //{
                    //    if (!false)
                    //    {
                    //        this.ReportPropertyChanged(DG_Activity.(6370));
                    //    }
                    //}
                    //while (false);
				}
				while (false);
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public bool? IsSynced
		{
			get
			{
				return this._IsSynced;
			}
			set
			{
				//this.ReportPropertyChanging(DG_Activity.(6383));
				this._IsSynced = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(DG_Activity.(6383));
			}
		}

        public static PS_Activity CreateDG_Activity ( int dG_Acitivity_Action_Pkey, int dG_Acitivity_By )
            {
            return new PS_Activity
            {
                PS_Acitivity_Action_Pkey = dG_Acitivity_Action_Pkey,
                PS_Acitivity_By = dG_Acitivity_By
            };
            }

		static PS_Activity()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//Strings.CreateGetStringDelegate(typeof(DG_Activity));
		}



        }
    }
