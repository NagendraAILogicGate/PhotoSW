using System;

namespace PhotoSW.IMIX.Model
{
	public class BackGroundInfo : BaseDataModel, ICloneable
	{
		private int backgroundId;

		private int productId;

		private string backgroundImageName;

		private string backgroundImageDisplayName;

		private int? backgroundGroupId;

		private string syncCode;

		private bool isSynced;

		private string backgroundPath;

		private bool? backgroundIsActive;

		private int? createdBy;

		private int? modifiedBy;

		private DateTime? createdDate;

		private DateTime? modifiedDate;

		public int DG_Background_pkey
		{
			get
			{
				return this.backgroundId;
			}
			set
			{
				this.backgroundId = value;
				this.PropertyModified("DG_Background_pkey");
			}
		}

		public int DG_Product_Id
		{
			get
			{
				return this.productId;
			}
			set
			{
				this.productId = value;
				this.PropertyModified("DG_Product_Id");
			}
		}

		public string DG_BackGround_Image_Name
		{
			get
			{
				return this.backgroundImageName;
			}
			set
			{
				this.backgroundImageName = value;
				this.PropertyModified("DG_BackGround_Image_Name");
			}
		}

		public string DG_BackGround_Image_Display_Name
		{
			get
			{
				return this.backgroundImageDisplayName;
			}
			set
			{
				this.backgroundImageDisplayName = value;
				this.PropertyModified("DG_BackGround_Image_Display_Name");
			}
		}

		public int? DG_BackGround_Group_Id
		{
			get
			{
				return this.backgroundGroupId;
			}
			set
			{
				this.backgroundGroupId = value;
				this.PropertyModified("DG_BackGround_Group_Id");
			}
		}

		public string SyncCode
		{
			get
			{
				return this.syncCode;
			}
			set
			{
				this.syncCode = value;
				this.PropertyModified("SyncCode");
			}
		}

		public bool IsSynced
		{
			get
			{
				return this.isSynced;
			}
			set
			{
				this.isSynced = value;
				this.PropertyModified("IsSynced");
			}
		}

		public string DG_BackgroundPath
		{
			get
			{
				return this.backgroundPath;
			}
			set
			{
				this.backgroundPath = value;
				this.PropertyModified("DG_BackgroundPath");
			}
		}

		public bool? DG_Background_IsActive
		{
			get
			{
				return this.backgroundIsActive;
			}
			set
			{
				this.backgroundIsActive = value;
				this.PropertyModified("DG_Background_IsActive");
			}
		}

		public int? CreatedBy
		{
			get
			{
				return this.createdBy;
			}
			set
			{
				this.createdBy = value;
				this.PropertyModified("CreatedBy");
			}
		}

		public int? ModifiedBy
		{
			get
			{
				return this.modifiedBy;
			}
			set
			{
				this.modifiedBy = value;
				this.PropertyModified("ModifiedBy");
			}
		}

		public DateTime? CreatedDate
		{
			get
			{
				return this.createdDate;
			}
			set
			{
				this.createdDate = value;
				this.PropertyModified("CreatedDate");
			}
		}

		public DateTime? ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}
			set
			{
				this.modifiedDate = value;
				this.PropertyModified("ModifiedDate");
			}
		}

		public string IsActiveLabel
		{
			get
			{
				string result;
				if (this.DG_Background_IsActive.HasValue && this.DG_Background_IsActive.Value)
				{
					result = "Active";
				}
				else
				{
					result = "InActive";
				}
				return result;
			}
		}

		public object Clone()
		{
			return base.MemberwiseClone();
		}
	}
}
