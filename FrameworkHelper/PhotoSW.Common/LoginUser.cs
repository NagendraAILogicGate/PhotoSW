using PhotoSW.IMIX.Model;
using System;
using System.Collections.Generic;

namespace PhotoSW.Common
{
	public class LoginUser
	{
		public const int Rotate = 6;

		public const int Flip = 5;

		public const int Contrast = 1;

		public const int Brightness = 2;

		private static LoginUser mySingleTonInstance = null;

		public static string DigiFolderPath;

		public static int DigiImagesCount;

		public static string DigiFolderThumbnailPath;

		public static string DigiFolderBigThumbnailPath;

		public static string ReceiptPrinterPath;

		public static string OrderPrefix = "SP";

		public static bool? IsDiscountAllowed;

		public static bool? IsDiscountAllowedonTotal;

		public static bool? IsWatermark;

		public static bool? IsHighResolution;

		public static bool? IsSemiOrder;

		public static System.Collections.Generic.List<SemiOrderSettings> ListSemiOrderSettingsSubStoreWise;

		public static string DigiFolderFramePath;

		public static string DigiFolderBackGroundPath;

		public static string DigiFolderGraphicsPath;

		public static string DigiFolderCropedPath;

		public static string DigiFolderAudioPath;

		public static string DigiFolderVideoTemplatePath;

		public static string DigiFolderVideoBackGroundPath;

		public static string DigiFolderProcessedVideosPath;

		public static string DigiFolderVideoOverlayPath;

        public static string PhotoSWChromaKeyPath;

		public static string PhotoSWGeneralBackGroundPath;
		public static string ModPassword;

		public static string DefaultBorderPath = "";

		public static int DGNoOfPhotoIdSearch;

		public static bool IsPhotographerSerailSearchActive = false;

		public static int PageCountGrid;

		public static string UserName { get; set; }

		public static string Storecode { get; set; }

        public static string countrycode { get; set; }

        public static int UserId { get; set; }

        public static int RoleId { get; set; }

        public static int StoreId { get; set; }

        public static string StoreName { get; set; }

        public static int SubStoreId { get; set; }

        public static string DefaultSubstores { get; set; }

        public static string SubstoreName { get; set; }

        public static string ServerHotFolderPath { get; set; }

        public static string GroupValue { get; set; }

        public static string ItemTemplatePath { get; set; }

        public static string ItemCalenderPath { get; set; }

        public static int MasterTemplateId { get; set; }

        public static string DigiReportPath { get; set; }

       // public static string PhotoSWGeneralBackGroundPath { get; set; }

        public static LoginUser GetInstace()
		{
			if (LoginUser.mySingleTonInstance == null)
			{
				LoginUser.mySingleTonInstance = new LoginUser();
			}
			return LoginUser.mySingleTonInstance;
		}
	}
}
