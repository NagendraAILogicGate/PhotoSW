namespace DigiPhoto.Common
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class LoginUser
    {
        public const int Brightness = 2;
        public const int Contrast = 1;
        public static string DefaultBorderPath = "";
        public static int DGNoOfPhotoIdSearch;
        public static string DigiFolderAudioPath;
        public static string DigiFolderBackGroundPath;
        public static string DigiFolderBigThumbnailPath;
        public static string DigiFolderCropedPath;
        public static string DigiFolderFramePath;
        public static string DigiFolderGraphicsPath;
        public static string DigiFolderPath;
        public static string DigiFolderProcessedVideosPath;
        public static string DigiFolderThumbnailPath;
        public static string DigiFolderVideoBackGroundPath;
        public static string DigiFolderVideoOverlayPath;
        public static string DigiFolderVideoTemplatePath;
        public static int DigiImagesCount;
        public const int Flip = 5;
        public static bool? IsDiscountAllowed;
        public static bool? IsDiscountAllowedonTotal;
        public static bool? IsHighResolution;
        public static bool IsPhotographerSerailSearchActive = false;
        public static bool? IsSemiOrder;
        public static bool? IsWatermark;
        public static List<SemiOrderSettings> ListSemiOrderSettingsSubStoreWise;
        public static string ModPassword;
        private static LoginUser mySingleTonInstance = null;
        public static string OrderPrefix = "DG";
        public static int PageCountGrid;
        public static string ReceiptPrinterPath;
        public const int Rotate = 6;

        public static LoginUser GetInstace()
        {
            if (mySingleTonInstance == null)
            {
                mySingleTonInstance = new LoginUser();
            }
            return mySingleTonInstance;
        }

        public static string countrycode
        {
            [CompilerGenerated]
            get
            {
                return <countrycode>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                <countrycode>k__BackingField = value;
            }
        }

        public static string DefaultSubstores
        {
            [CompilerGenerated]
            get
            {
                return <DefaultSubstores>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                <DefaultSubstores>k__BackingField = value;
            }
        }

        public static string DigiReportPath
        {
            [CompilerGenerated]
            get
            {
                return <DigiReportPath>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                <DigiReportPath>k__BackingField = value;
            }
        }

        public static string GroupValue
        {
            [CompilerGenerated]
            get
            {
                return <GroupValue>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                <GroupValue>k__BackingField = value;
            }
        }

        public static string ItemCalenderPath
        {
            [CompilerGenerated]
            get
            {
                return <ItemCalenderPath>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                <ItemCalenderPath>k__BackingField = value;
            }
        }

        public static string ItemTemplatePath
        {
            [CompilerGenerated]
            get
            {
                return <ItemTemplatePath>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                <ItemTemplatePath>k__BackingField = value;
            }
        }

        public static int MasterTemplateId
        {
            [CompilerGenerated]
            get
            {
                return <MasterTemplateId>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                <MasterTemplateId>k__BackingField = value;
            }
        }

        public static int RoleId
        {
            [CompilerGenerated]
            get
            {
                return <RoleId>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                <RoleId>k__BackingField = value;
            }
        }

        public static string ServerHotFolderPath
        {
            [CompilerGenerated]
            get
            {
                return <ServerHotFolderPath>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                <ServerHotFolderPath>k__BackingField = value;
            }
        }

        public static string Storecode
        {
            [CompilerGenerated]
            get
            {
                return <Storecode>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                <Storecode>k__BackingField = value;
            }
        }

        public static int StoreId
        {
            [CompilerGenerated]
            get
            {
                return <StoreId>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                <StoreId>k__BackingField = value;
            }
        }

        public static string StoreName
        {
            [CompilerGenerated]
            get
            {
                return <StoreName>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                <StoreName>k__BackingField = value;
            }
        }

        public static int SubStoreId
        {
            [CompilerGenerated]
            get
            {
                return <SubStoreId>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                <SubStoreId>k__BackingField = value;
            }
        }

        public static string SubstoreName
        {
            [CompilerGenerated]
            get
            {
                return <SubstoreName>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                <SubstoreName>k__BackingField = value;
            }
        }

        public static int UserId
        {
            [CompilerGenerated]
            get
            {
                return <UserId>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                <UserId>k__BackingField = value;
            }
        }

        public static string UserName
        {
            [CompilerGenerated]
            get
            {
                return <UserName>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                <UserName>k__BackingField = value;
            }
        }
    }
}

