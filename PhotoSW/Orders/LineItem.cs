using PhotoSW.DataLayer;
using PhotoSW.IMIX.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using DigiPhoto;

namespace PhotoSW.Orders
{
    public class LineItem
    {
        public List<PhotoPrintPositionDic> PrintPhotoOrderPosition = new List<PhotoPrintPositionDic>();

        public ObservableCollection<PrintOrderPage> PrintOrderPageList = new ObservableCollection<PrintOrderPage>();

        public int CodeType
        {
            get;
            set;
        }

        public string UniqueCode
        {
            get;
            set;
        }

        public int ItemSeqNumber
        {
            get;
            set;
        }

        public int OrderDetailsID
        {
            get;
            set;
        }

        public string ItemNumber
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

        public int TotalQty
        {
            get;
            set;
        }

        public int TotalMaxSelectedPhotos
        {
            get;
            set;
        }

        public int SelectedProductType_ID
        {
            get;
            set;
        }

        public string SelectedProductType_Text
        {
            get;
            set;
        }

        public string SelectedProductType_Image
        {
            get;
            set;
        }

        public int SelectedPrinterID
        {
            get;
            set;
        }

        public string ParentID
        {
            get;
            set;
        }

        public string SelectedPrinterText
        {
            get;
            set;
        }

        public bool AllowDiscount
        {
            get;
            set;
        }

        public bool IsBundled
        {
            get;
            set;
        }

        public bool CommandVisible
        {
            get;
            set;
        }

        public bool IsPackage
        {
            get;
            set;
        }

        public bool IsAccessory
        {
            get;
            set;
        }

        public bool IsWaterMarked
        {
            get;
            set;
        }

        public int? IsPrintType
        {
            get;
            set;
        }

        public double UnitPrice
        {
            get;
            set;
        }

        public double TotalPrice
        {
            get;
            set;
        }

        public string TotalDiscount
        {
            get;
            set;
        }

        public double TotalDiscountAmount
        {
            get;
            set;
        }

        public double NetPrice
        {
            get;
            set;
        }

        public bool IssemiOrder
        {
            get;
            set;
        }

        public int ItemTemplateHeaderId
        {
            get;
            set;
        }

        public int ItemTemplateDetailId
        {
            get;
            set;
        }

        public int ItemIndex
        {
            get;
            set;
        }

        public List<string> SelectedImages
        {
            get;
            set;
        }

        public List<PrinterDetailsInfo> AssociatedPrinters
        {
            get;
            set;
        }

        public List<LstMyItems> GroupItems
        {
            get;
            set;
        }

        public Visibility SemiVisible
        {
            get;
            set;
        }

        public string HotFolderPath
        {
            get;
            set;
        }

        public double? TaxPercent
        {
            get;
            set;
        }

        public double TaxAmount
        {
            get;
            set;
        }

        public bool? IsTaxIncluded
        {
            get;
            set;
        }
    }
}
