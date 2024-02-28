using System;

namespace PhotoSW.IMIX.Model
{
	public class PhotoInfo
	{
		public int DG_Photos_pkey
		{
			get;
			set;
		}

		public string DG_Photos_FileName
		{
			get;
			set;
		}

		public DateTime DG_Photos_CreatedOn
		{
			get;
			set;
		}

		public string DG_Photos_RFID
		{
			get;
			set;
		}

		public int? DG_Photos_UserID
		{
			get;
			set;
		}

		public string DG_Photos_Background
		{
			get;
			set;
		}

		public string DG_Photos_Frame
		{
			get;
			set;
		}

		public DateTime? DG_Photos_DateTime
		{
			get;
			set;
		}

		public string DG_Photos_Layering
		{
			get;
			set;
		}

		public string DG_Photos_Effects
		{
			get;
			set;
		}

		public bool? DG_Photos_IsCroped
		{
			get;
			set;
		}

		public bool? DG_Photos_IsRedEye
		{
			get;
			set;
		}

		public bool? DG_Photos_IsGreen
		{
			get;
			set;
		}

		public string DG_Photos_MetaData
		{
			get;
			set;
		}

		public string DG_Photos_Sizes
		{
			get;
			set;
		}

		public bool? DG_Photos_Archive
		{
			get;
			set;
		}

		public int? DG_Location_Id
		{
			get;
			set;
		}

		public int? DG_SubStoreId
		{
			get;
			set;
		}

		public bool DG_IsCodeType
		{
			get;
			set;
		}

		public DateTime? DateTaken
		{
			get;
			set;
		}

		public int? RfidScanType
		{
			get;
			set;
		}

		public string DG_Orders_Number
		{
			get;
			set;
		}

		public int DG_Order_SubStoreId
		{
			get;
			set;
		}

		public long IMIXImageAssociationId
		{
			get;
			set;
		}

		public long DG_Group_pkey
		{
			get;
			set;
		}

		public string DG_Group_Name
		{
			get;
			set;
		}

		public int DG_Photo_ID
		{
			get;
			set;
		}

		public int? IsImageProcessed
		{
			get;
			set;
		}

		public string DG_User_Name
		{
			get;
			set;
		}

		public string HotFolderPath
		{
			get;
			set;
		}

		public string DG_Photos_CharacterID
		{
			get;
			set;
		}

		public int DG_MediaType
		{
			get;
			set;
		}

		public long? DG_VideoLength
		{
			get;
			set;
		}

		public int SemiOrderProfileId
		{
			get;
			set;
		}

		public bool IsGumRideShow
		{
			get;
			set;
		}

        public bool IsCollageShow
            {
            get;
            set;
            }

        public string OnlineQRCode
		{
			get;
			set;
		}
	}
}
