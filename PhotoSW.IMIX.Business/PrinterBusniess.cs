using PhotoSW.CF.DataLayer.BAL;
using PhotoSW.DataLayer;
using PhotoSW.IMIX.DataAccess;
using PhotoSW.IMIX.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
    public class PrinterBusniess: BaseBusiness
    {
        private static Func<PrinterQueueforPrint, int>_SOH;
private static Func<PrinterQueueforPrint, int>_STX;
private static Func<PrinterQueueforPrint, int>_ETX;
private static Func<PrinterQueueforPrint, int>_EOT;
private static Func<PrinterQueueforPrint, int>_ENQ;
private static Func<PrinterQueueforPrint, int>_ACK;
private static Func<PrinterQueueforPrint, int>_BEL;
private static Func<PrinterQueueforPrint, int>_BS;
private static Func<PhotoPrintPositionDic, int>_SO;
private static Func<int, int>_SI;
private static Func<PhotoPrintPositionDic, int>_DEL;
private static Func<PhotoPrintPositionDic, int> _DC1;
private static Func<PhotoPrintPositionDic, int> _DC2;
private static Func<ItemTemplateDetailModel, bool>_DC3;
private static Func<PrinterQueueInfo, int?>_DC4;
        private sealed class csSOH
		{
			public PrinterBusniess SOH;

			public int STX;

			public void mSOH()
			{
				PrinterQueueDao printerQueueDao = new PrinterQueueDao(this.SOH.Transaction);
				printerQueueDao.UpdateReadyForPrint(this.STX);
			}
		}
        private sealed class csSTX
		{
			public PrinterBusniess SOH;

			public int STX;

			public void mSOH()
			{
				PrinterQueueDao printerQueueDao = new PrinterQueueDao(this.SOH.Transaction);
				printerQueueDao.UpdatePrinterQueue(this.STX);
			}
		}
        private sealed class csETX
		{
			public PrinterBusniess SOH;

			public int STX;
		}
        	private sealed class csEOT
		{
			public PrinterBusniess.csETX SOH;
			public PrinterQueueInfo STX;

			public void  mSOH()
			{
				PrinterQueueDao printerQueueDao = new PrinterQueueDao(this.SOH.SOH.Transaction);
				this.STX= printerQueueDao.GetPrinterQueueIsReadyForPrint(this.SOH.STX , false);
			}
		}
        	private sealed class csENQ
		{
			public PrinterBusniess SOH;

			public int?  STX;

			public int ETX;
		}
			private sealed class csACK
		{
			public PrinterBusniess.csENQ SOH;

			public List<AssociatedPrintersInfo> STX;

			public void  mSOH()
			{
				PrinterQueueDao printerQueueDao = new PrinterQueueDao(this.SOH.SOH.Transaction);
				this.STX= printerQueueDao.SelectAssociatedPrintersforPrint(this.SOH.STX, this.SOH.ETX);
			}
		}
        private sealed class csBEL
		{
			public PrinterBusniess SOH;

			public int STX;

			public bool mSOH(PrinterQueueforPrint STX)
			{
				return STX.DG_Order_SubStoreId == this.STX;
			}
		}
        private sealed class csBS
		{
			public PrinterBusniess.csBEL SOH;

			public string STX;

			public List<PrinterQueueforPrint> ETX;

			public void mSOH()
			{
				if (4 != 0)
				{
					PrinterQueueDao printerQueueDao = new PrinterQueueDao(this.SOH.SOH.Transaction);
					if (!false)
					{
						this.ETX= printerQueueDao.SelectPrinterQueue(this.SOH.STX);
					}
				}
			}

			public bool mSOH(PrinterQueueforPrint STX)
			{
				int arg_2F_0;
				int arg_2F_1;
				while (true)
				{
					if (!true)
					{
						goto IL_32;
					}
					int arg_16_0;
					arg_2F_0 = (arg_16_0 = STX.DG_Order_SubStoreId);
					IL_07:
					int expr_0E = arg_2F_1 = this.SOH.STX;
					if (false)
					{
						goto IL_2F;
					}
					if (arg_16_0 == expr_0E)
					{
						if (7 != 0)
						{
							break;
						}
						continue;
					}
					IL_32:
					int expr_33 = arg_16_0 = (arg_2F_0 = 0);
					if (expr_33 == 0)
					{
						return expr_33 != 0;
					}
					goto IL_07;
				}
				arg_2F_0 = (this.STX.Contains(STX.DG_Orders_ProductType_pkey.ToString()) ? 1 : 0);
				arg_2F_1 = 0;
				IL_2F:
				return arg_2F_0 == arg_2F_1;
			}
		}
        private sealed class csSO
		{
			public PrinterBusniess.csBS SOH;

			public PrinterBusniess.csBEL STX;

			public List<string> ETX;

			public bool mSOH(PrinterQueueforPrint STX)
			{
				int arg_2F_0;
				int arg_2F_1;
				while (true)
				{
					if (!true)
					{
						goto IL_32;
					}
					int arg_16_0;
					arg_2F_0 = (arg_16_0 =STX.DG_Order_SubStoreId);
					IL_07:
					int expr_0E = arg_2F_1 = this.STX.STX;
					if (false)
					{
						goto IL_2F;
					}
					if (arg_16_0 == expr_0E)
					{
						if (7 != 0)
						{
							break;
						}
						continue;
					}
					IL_32:
					int expr_33 = arg_16_0 = (arg_2F_0 = 0);
					if (expr_33 == 0)
					{
						return expr_33 != 0;
					}
					goto IL_07;
				}
				arg_2F_0 = (this.ETX.Contains(STX.DG_Orders_ProductType_pkey.ToString()) ? 1 : 0);
				arg_2F_1 = 0;
				IL_2F:
				return arg_2F_0 == arg_2F_1;
			}
         	
		}
        private sealed class csSI
		{
			public PrinterBusniess SOH;

			public int STX;

			public bool mSOH(PrinterQueueforPrint STX)
			{
				return  STX.DG_Order_SubStoreId == this.STX;
			}
		}

	
		private sealed class DEL
		{
			public PrinterBusniess.csSI SOH;

			public List<PrinterQueueforPrint> STX;

			public void mSOH()
			{
				if (4 != 0)
				{
					PrinterQueueDao printerQueueDao = new PrinterQueueDao(this.SOH.SOH.Transaction);
					if (!false)
					{
						this.STX= printerQueueDao.SelectFilteredPrinterQueueforPrint(this.SOH.STX);
					}
				}
			}
		}
        private sealed class DC1
		{
			public PrinterBusniess.csSI SOH;

			public List<PrinterQueueforPrint> STX;

			public List<int> ETX;

			public void mSOH()
			{
				if (4 != 0)
				{
					PrinterQueueDao printerQueueDao = new PrinterQueueDao(this.SOH.SOH.Transaction);
					if (!false)
					{
						this.STX= printerQueueDao.SelectFilteredPrinterQueueforPrint(this.SOH.STX);
					}
				}
			}

			public bool mSOH(PrinterQueueforPrint STX)
			{
				int arg_10_0 = STX.DG_Order_SubStoreId;
				bool arg_23_0;
				while (arg_10_0 != this.SOH.STX || false)
				{
					bool arg_25_0;
					bool expr_27 = arg_25_0 = false;
                    if(expr_27 == false)
					{
						//arg_10_0 = expr_27;
						if (expr_27)
						{
							continue;
						}
						arg_23_0 = expr_27;
						if (expr_27 == false)
						{
							return expr_27 != false;
						}
						IL_22:
						arg_25_0 = ((arg_23_0 == false) ? true: false);
					}
                    return arg_25_0 != false;
				}
              return   arg_23_0 = (this.ETX.Contains(STX.DG_Orders_ProductType_pkey) ? true : false);
				
			}
		}
		private sealed class DC2
		{
			public PrinterBusniess  SOH;

			public string STX;
		}
		private sealed class DC3
		{
			public PrinterBusniess.DC2 SOH;

			public List<PrinterQueueDetailsInfo> STX;

			public void  mSOH()
			{
				if (4 != 0)
				{
					PrinterQueueDao printerQueueDao = new PrinterQueueDao(this.SOH.SOH.Transaction);
					if (!false)
					{
						this.STX= printerQueueDao.GetPrinterQueueDetailsByOrderNo(this.SOH.STX);
					}
				}
			}
		}

	
		private sealed class DC4
		{
			public PrintLogInfo SOH;

			public PrinterBusniess STX;

			public void  mSOH()
			{
				PrinterQueueDao printerQueueDao = new PrinterQueueDao(this.STX.Transaction);
				printerQueueDao.InsertPrinterLog(this.SOH);
			}
		}
        private sealed class csNAK
		{
			public PrinterBusniess SOH;

			public string STX;

			public int? ETX;

			public int? EOT;

			public bool ENQ;

			public int ACK;
		}
		private sealed class csSYN
		{
			public PrinterBusniess.csNAK SOH;

			public bool STX;

			public void mSOH()
			{
				PrinterQueueDao printerQueueDao = new PrinterQueueDao(this.SOH.SOH.Transaction);
				this.STX= printerQueueDao.InsDataToPrinterQueue(this.SOH.STX, this.SOH.ETX, this.SOH.EOT, this.SOH.ENQ, this.SOH.ACK);
			}
		}

        private sealed class csETB
		{
			public PrinterBusniess SOH;

			public int? STX;
		}

		private sealed class csCAN
		{
			public PrinterBusniess.csETB SOH;

			public AssociatedPrintersInfo STX;

			public void mSOH()
			{
				if (4 != 0)
				{
					AssociatedPrintersDao associatedPrintersDao = new AssociatedPrintersDao(this.SOH.SOH.Transaction);
					if (!false)
					{
						this.STX= associatedPrintersDao.GetAssociatedPrinterIdFromPRoductTypeId(this.SOH.STX);
					}
				}
			}
		}
		private sealed class csEM
		{
			public PrinterBusniess SOH;

			public int STX;
		}
		private sealed class csSUB
		{
			public PrinterBusniess.csEM SOH;

			public List<AssociatedPrintersInfo> STX;

			public void mSOH()
			{
				AssociatedPrintersDao associatedPrintersDao = new AssociatedPrintersDao(this.SOH.SOH.Transaction);
				this.STX= associatedPrintersDao.Select(new int?(this.SOH.STX));
			}
		}
        private sealed class csESC
		{
			public AssociatedPrintersInfo SOH;

			public PrinterBusniess STX;

			public int ETX;

			public void mSOH()
			{
				do
				{
					AssociatedPrintersDao associatedPrintersDao;
					if (!false)
					{
						associatedPrintersDao = new AssociatedPrintersDao(this.STX.Transaction);
					}
					this.SOH = associatedPrintersDao.GetAssociatedPrintersByKey(this.ETX);
				}
				while (false);
			}
		}
        
		private sealed class csFS
		{
			public PrinterBusniess SOH;

			public int STX;

			public void mSOH()
			{
				while (true)
				{
					AssociatedPrintersDao associatedPrintersDao;
					if (!false)
					{
						associatedPrintersDao = new AssociatedPrintersDao(this.SOH.Transaction);
					}
					if (!false)
					{
						if (5 != 0)
						{
							associatedPrintersDao.Delete(this.STX);
						}
						if (!false)
						{
							break;
						}
					}
				}
			}
		}
        private sealed class csGS
		{
			public int SOH;

			public PrinterBusniess STX;
		}
		private sealed class csRS
		{
			public PrinterBusniess.csGS SOH;

			public PrinterQueueInfo STX;

			public PrinterQueueInfo ETX;

			public void mSOH()
			{
				while (true)
				{
					PrinterQueueDao printerQueueDao;
					if (true && !false)
					{
						printerQueueDao = new PrinterQueueDao(this.SOH.STX.Transaction);
					}
					while (true)
					{
						this.ETX = printerQueueDao.Get();
						if (false)
						{
							break;
						}
						if (!false)
						{
							return;
						}
					}
				}
			}

			public void mSTX()
			{
				if (4 != 0)
				{
					PrinterQueueDao printerQueueDao = new PrinterQueueDao(this.SOH.STX.Transaction);
					if (!false)
					{
						this.SOH.SOH= printerQueueDao.Add(this.STX);
					}
				}
			}
		}
		private sealed class csUS
		{
			private sealed class SOH
			{
				public PrinterBusniess.csUS US_SOH;

				public PrinterBusniess.csGS GS_STX;

				public PhotoPrintPositionDic ETX;

				public bool mSOH(int STX)
				{
					return STX== this.ETX.PhotoId;
				}
			}

			public PrinterBusniess.csGS GS_SOH;

			public List<int> STX;

			public bool mSOH(PhotoPrintPositionDic STX)
			{
				PrinterBusniess.csUS.SOH SOH;
				if (!false)
				{
					PrinterBusniess.csUS.SOH expr_4E = new 

PrinterBusniess.csUS.SOH();
					if (!false)
					{
				         SOH= expr_4E;
					}
				}
				SOH.US_SOH= this;
				SOH.GS_STX= this.GS_SOH;
				SOH.ETX=STX;
				bool arg_45_0;
				bool arg_4D_0 = arg_45_0 = this.STX.Any(new Func<int, bool>( SOH.mSOH));
				do
				{
					if (!false)
					{
						arg_4D_0 = (arg_45_0 = !

arg_45_0);
					}
				}
				while (false || false);
				return arg_4D_0;
			}
		}

       	public int AddImageToPrinterQueue(
            int ProductTypeId, 
            List<string> Images,
            int OrderDetailedKey,
            bool IsBundled, bool GreenSpecPrint, 
            List<PhotoPrintPositionDic> PhotoPrintPositionDicList, 
            int MasterTemplateId = 1)
		{
        return 0;
            //PrinterBusniess.csGS GS= new PrinterBusniess.csGS();
            //GS.STX= this;
            //ProductBusiness productBusiness = new ProductBusiness();
            //int associatedPrinterIdFromProductTypeId = this.GetAssociatedPrinterIdFromProductTypeId(new int?(ProductTypeId));
            //GS.SOH= -1;
            //if (!IsBundled)
            //{
            //    int num;
            //    int count;
            //    int arg_222_0;
            //    int arg_221_0;
            //    if (ProductTypeId == 98)
            //    {
            //        if (Images.Count % 2 == 1)
            //        {
            //            Images.Add(Images[Images.Count - 1]);
            //        }
            //        num = 0;
            //        count = Images.Count;
            //    }
            //    else
            //    {
            //        if (ProductTypeId == 79 && PhotoPrintPositionDicList != null)
            //        {
            //            Func<PhotoPrintPositionDic, bool> func = null;
            //            PrinterBusniess.csUS US= new PrinterBusniess.csUS();

            //          List<int> lstint= new List<int>();
            //            if (PrinterBusniess._SO == null)
            //            {
            //                PrinterBusniess. = new Func<PhotoPrintPositionDic, int>(PrinterBusniess.);
            //            }
            //            IEnumerable<int> arg_2A0_0 = PhotoPrintPositionDicList.Select(PrinterBusniess.).Distinct<int>();
            //            if (PrinterBusniess. == null)
            //            {
            //                PrinterBusniess. = new Func<int, int>(PrinterBusniess.);
            //            }
            //            using (List<int>.Enumerator enumerator = arg_2A0_0.OrderBy(PrinterBusniess.).ToList<int>().GetEnumerator())
            //            {
            //                while (enumerator.MoveNext())
            //                {
            //                    Func<PhotoPrintPositionDic, bool> func2 = null;
            //                    Func<PhotoPrintPositionDic, bool> func3 = null;
            //                    PrinterBusniess.  = new PrinterBusniess.();
            //                    . = ;
            //                    . = ;
            //                    . = enumerator.Current;
            //                    Action<PhotoPrintPositionDic> action = null;
            //                    Action<PhotoPrintPositionDic> action2 = null;
            //                    PrinterBusniess.  = new PrinterBusniess.();
            //                    . = ;
            //                    . = ;
            //                    . = ;
            //                    . = string.Empty;
            //                    ProductTypeInfo productType = productBusiness.GetProductType(ProductTypeId);
            //                    if (!Convert.ToBoolean(productType.DG_IsAccessory))
            //                    {
            //                        PrinterBusniess.  = new PrinterBusniess.();
            //                        . = ;
            //                        . = ;
            //                        . = ;
            //                        . = ;
            //                        if (func == null)
            //                        {
            //                            func = new Func<PhotoPrintPositionDic, bool>(.);
            //                        }
            //                        IEnumerable<PhotoPrintPositionDic> arg_39A_0 = PhotoPrintPositionDicList.Where(func);
            //                        if (PrinterBusniess. == null)
            //                        {
            //                            PrinterBusniess. = new Func<PhotoPrintPositionDic, int>(PrinterBusniess.);
            //                        }
            //                        arg_39A_0.Min(PrinterBusniess.);
            //                        string arg_3A5_0 = string.Empty;
            //                        if (func2 == null)
            //                        {
            //                            func2 = new Func<PhotoPrintPositionDic, bool>(.);
            //                        }
            //                        IEnumerable<PhotoPrintPositionDic> arg_3DF_0 = PhotoPrintPositionDicList.Where(func2);
            //                        if (PrinterBusniess. == null)
            //                        {
            //                            PrinterBusniess. = new Func<PhotoPrintPositionDic, int>(PrinterBusniess.);
            //                        }
            //                        List<PhotoPrintPositionDic> arg_3FE_0 = arg_3DF_0.OrderBy(PrinterBusniess.).ToList<PhotoPrintPositionDic>();
            //                        if (action == null)
            //                        {
            //                            action = new Action<PhotoPrintPositionDic>(.);
            //                        }
            //                        arg_3FE_0.ForEach(action);
            //                        . = string.Empty;
            //                        if (func3 == null)
            //                        {
            //                            func3 = new Func<PhotoPrintPositionDic, bool>(.);
            //                        }
            //                        IEnumerable<PhotoPrintPositionDic> arg_448_0 = PhotoPrintPositionDicList.Where(func3);
            //                        if (PrinterBusniess. == null)
            //                        {
            //                            PrinterBusniess. = new Func<PhotoPrintPositionDic, int>(PrinterBusniess.);
            //                        }
            //                        List<PhotoPrintPositionDic> arg_467_0 = arg_448_0.OrderBy(PrinterBusniess.).ToList<PhotoPrintPositionDic>();
            //                        if (action2 == null)
            //                        {
            //                            action2 = new Action<PhotoPrintPositionDic>(.);
            //                        }
            //                        arg_467_0.ForEach(action2);
            //                        . = new PrinterQueueInfo();
            //                        ..DG_Associated_PrinterId = new int?(associatedPrinterIdFromProductTypeId);
            //                        ..DG_PrinterQueue_Image_Pkey = ((..Length > 0) ? ..Substring(1) : string.Empty);
            //                        ..RotationAngle = ((..Length > 0) ? ..Substring(1) : string.Empty);
            //                        ..DG_PrinterQueue_ProductID = new int?(ProductTypeId);
            //                        ..DG_SentToPrinter = new bool?(false);
            //                        ..DG_Order_Details_Pkey = new int?(OrderDetailedKey);
            //                        ..is_Active = new bool?(true);
            //                        ..DG_IsSpecPrint = new bool?(GreenSpecPrint);
            //                        ..DG_Print_Date = new DateTime?(DateTime.Now);
            //                        . = new PrinterQueueInfo();
            //                        this.operation = new BaseBusiness.TransactionMethod(.);
            //                        base.Start(false);
            //                        if (. != null)
            //                        {
            //                            ..QueueIndex = ..QueueIndex + 1;
            //                        }
            //                        else
            //                        {
            //                            ..QueueIndex = new int?(1);
            //                        }
            //                        this.operation = new BaseBusiness.TransactionMethod(.);
            //                        base.Start(false);
            //                    }
            //                }
            //                goto IL_B81;
            //            }
            //        }
            //        arg_222_0 = ProductTypeId;
            //        int expr_617 = arg_221_0 = 100;
            //        if (expr_617 != 0)
            //        {
            //            if (ProductTypeId == expr_617)
            //            {
            //                int num2 = 1;
            //                using (List<string>.Enumerator enumerator2 = Images.GetEnumerator())
            //                {
            //                    while (enumerator2.MoveNext())
            //                    {
            //                        string current = enumerator2.Current;
            //                        ProductTypeInfo productType2 = productBusiness.GetProductType(ProductTypeId);
            //                        if (!Convert.ToBoolean(productType2.DG_IsAccessory))
            //                        {
            //                            PrinterBusniess.  = new PrinterBusniess.();
            //                            . = ;
            //                            . = new PrinterQueueInfo();
            //                            ..DG_Associated_PrinterId = new int?(associatedPrinterIdFromProductTypeId);
            //                            ..DG_PrinterQueue_Image_Pkey = current;
            //                            ..DG_PrinterQueue_ProductID = new int?(ProductTypeId);
            //                            ..DG_SentToPrinter = new bool?(false);
            //                            ..DG_Order_Details_Pkey = new int?(OrderDetailedKey);
            //                            ..is_Active = new bool?(true);
            //                            ..DG_IsSpecPrint = new bool?(GreenSpecPrint);
            //                            ..DG_Print_Date = new DateTime?(DateTime.Now);
            //                            . = new PrinterQueueInfo();
            //                            this.operation = new BaseBusiness.TransactionMethod(.);
            //                            base.Start(false);
            //                            if (. != null)
            //                            {
            //                                ..QueueIndex = ..QueueIndex + 1;
            //                            }
            //                            else
            //                            {
            //                                ..QueueIndex = new int?(1);
            //                            }
            //                            this.operation = new BaseBusiness.TransactionMethod(.);
            //                            base.Start(false);
            //                            CalenderBusiness calenderBusiness = new CalenderBusiness();
            //                            new List<ItemTemplateDetailModel>();
            //                            IEnumerable<ItemTemplateDetailModel> arg_7D4_0 = calenderBusiness.GetItemTemplateDetail();
            //                            if (PrinterBusniess. == null)
            //                            {
            //                                PrinterBusniess. = new Func<ItemTemplateDetailModel, bool>(PrinterBusniess.);
            //                            }
            //                            arg_7D4_0.Where(PrinterBusniess.).ToList<ItemTemplateDetailModel>();
            //                            calenderBusiness.AddItemTemplatePrintOrder(new ItemTemplatePrintOrderModel
            //                            {
            //                                MasterTemplateId = MasterTemplateId,
            //                                DetailTemplateId = num2,
            //                                OrderLineItemId = .,
            //                                PrinterQueueId = 0,
            //                                PageNo = 0,
            //                                PhotoId = 1,
            //                                Status = 0,
            //                                PrintTypeId = 0,
            //                                PrintPosition = 0,
            //                                RotationAngle = 0,
            //                                CreatedBy = PrinterBusniess.(3289)
            //                            });
            //                            num2++;
            //                        }
            //                    }
            //                    goto IL_B81;
            //                }
            //            }
            //            using (List<string>.Enumerator enumerator3 = Images.GetEnumerator())
            //            {
            //                while (enumerator3.MoveNext())
            //                {
            //                    string current2 = enumerator3.Current;
            //                    ProductTypeInfo productType3 = productBusiness.GetProductType(ProductTypeId);
            //                    if (!Convert.ToBoolean(productType3.DG_IsAccessory))
            //                    {
            //                        PrinterBusniess.  = new PrinterBusniess.();
            //                        . = ;
            //                        . = new PrinterQueueInfo();
            //                        ..DG_Associated_PrinterId = new int?(associatedPrinterIdFromProductTypeId);
            //                        ..DG_PrinterQueue_Image_Pkey = current2;
            //                        ..DG_PrinterQueue_ProductID = new int?(ProductTypeId);
            //                        ..DG_SentToPrinter = new bool?(false);
            //                        ..DG_Order_Details_Pkey = new int?(OrderDetailedKey);
            //                        ..is_Active = new bool?(true);
            //                        ..DG_IsSpecPrint = new bool?(GreenSpecPrint);
            //                        ..DG_Print_Date = new DateTime?(DateTime.Now);
            //                        . = new PrinterQueueInfo();
            //                        this.operation = new BaseBusiness.TransactionMethod(.);
            //                        base.Start(false);
            //                        if (. != null)
            //                        {
            //                            ..QueueIndex = ..QueueIndex + 1;
            //                        }
            //                        else
            //                        {
            //                            ..QueueIndex = new int?(1);
            //                        }
            //                        this.operation = new BaseBusiness.TransactionMethod(.);
            //                        base.Start(false);
            //                    }
            //                }
            //                goto IL_B81;
            //            }
            //            goto IL_A20;
            //        }
            //        goto IL_220;
            //    }
            //    IL_21E:
            //    arg_222_0 = num;
            //    arg_221_0 = count;
            //    IL_220:
            //    if (arg_222_0 > arg_221_0 / 2)
            //    {
            //        goto IL_B81;
            //    }
            //    PrinterBusniess.  = new PrinterBusniess.();
            //    . = ;
            //    Images.ToArray();
            //    string dG_PrinterQueue_Image_Pkey = Images.ToArray()[num] + PrinterBusniess.(1317) + Images.ToArray()[num + 1];
            //    . = new PrinterQueueInfo();
            //    ..DG_PrinterQueue_Image_Pkey = string.Join(PrinterBusniess.(1317), Images.ToArray());
            //    ..DG_PrinterQueue_Image_Pkey = dG_PrinterQueue_Image_Pkey;
            //    ..DG_Associated_PrinterId = new int?(associatedPrinterIdFromProductTypeId);
            //    ..DG_PrinterQueue_ProductID = new int?(ProductTypeId);
            //    ..is_Active = new bool?(true);
            //    ..DG_SentToPrinter = new bool?(false);
            //    ..DG_Order_Details_Pkey = new int?(OrderDetailedKey);
            //    ..DG_IsSpecPrint = new bool?(GreenSpecPrint);
            //    ..DG_Print_Date = new DateTime?(DateTime.Now);
            //    . = new PrinterQueueInfo();
            //    this.operation = new BaseBusiness.TransactionMethod(.);
            //    base.Start(false);
            //    if (. != null)
            //    {
            //        ..QueueIndex = ..QueueIndex + 1;
            //    }
            //    else
            //    {
            //        ..QueueIndex = new int?(1);
            //    }
            //    this.operation = new BaseBusiness.TransactionMethod(.);
            //    base.Start(false);
            //    num += 2;
            //    goto IL_21E;
            //}
            //IL_A20:
            //PrinterBusniess.  = new PrinterBusniess.();
            //. = ;
            //. = new PrinterQueueInfo();
            //..DG_Associated_PrinterId = new int?(associatedPrinterIdFromProductTypeId);
            //..DG_PrinterQueue_Image_Pkey = string.Join(PrinterBusniess.(1317), Images.ToArray());
            //..DG_PrinterQueue_ProductID = new int?(ProductTypeId);
            //..is_Active = new bool?(true);
            //..DG_SentToPrinter = new bool?(false);
            //..DG_Order_Details_Pkey = new int?(OrderDetailedKey);
            //..DG_IsSpecPrint = new bool?(GreenSpecPrint);
            //..DG_Print_Date = new DateTime?(DateTime.Now);
            //. = new PrinterQueueInfo();
            //this.operation = new BaseBusiness.TransactionMethod(.);
            //base.Start(false);
            //if (. != null)
            //{
            //    ..QueueIndex = ..QueueIndex + 1;
            //}
            //else
            //{
            //    ..QueueIndex = new int?(1);
            //}
            //this.operation = new BaseBusiness.TransactionMethod(.);
            //base.Start(false);
            //IL_B81:
            //return .;
		}
        public string CheckSpecSetting(int PrinterId)
        {
            return "";
        }
        public bool DeletePrinter ( int id )
            {
            bool result = baAssociatedPrintersInfo.Delete(id);
            return result;
            }
        public int GetAssociatedPrinterIdFromProductTypeId(int? ProductTypeId)
        {
            return 0;
        }
        public List<PhotoSW.IMIX.Model.PrinterDetailsInfo> GetAssociatedPrinters(int? productType)
        {
            try
                {
                var obj = baPrinterDetailsInfo.GetPrinterDetailsInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.PrinterDetailsInfo()
                        {
                        PrinterName = p.PrinterName,
                        PrinterID = p.PrinterID
                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.PrinterDetailsInfo>();
                }
            // return new List<PhotoSW.IMIX.Model.PrinterDetailsInfo>();
            }
        public List<PhotoSW.IMIX.Model.AssociatedPrintersInfo> GetAssociatedPrintersforPrint(int? ProductType, int SubStoreID)
        {
            try
                {
                var obj = baAssociatedPrintersInfo.GetAssociatedPrintersInfoData()
                    .Where(p=>p.PS_AssociatedPrinters_ProductType_ID == ProductType && p.PS_AssociatedPrinters_SubStoreID == SubStoreID)
                    .Select(p => new PhotoSW.IMIX.Model.AssociatedPrintersInfo()
                        {
                        DG_AssociatedPrinters_Pkey = p.PS_AssociatedPrinters_Pkey,
                        DG_AssociatedPrinters_Name = p.PS_AssociatedPrinters_Name,
                        DG_AssociatedPrinters_ProductType_ID = p.PS_AssociatedPrinters_ProductType_ID,
                        DG_AssociatedPrinters_IsActive = p.PS_AssociatedPrinters_IsActive,
                        DG_AssociatedPrinters_PaperSize = p.PS_AssociatedPrinters_PaperSize,
                        DG_AssociatedPrinters_SubStoreID = p.PS_AssociatedPrinters_SubStoreID,
                        DG_Orders_ProductType_Name = p.PS_Orders_ProductType_Name
                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.AssociatedPrintersInfo>();
                }
            // return new List<PhotoSW.IMIX.Model.AssociatedPrintersInfo>();
            }
        public List<PhotoSW.IMIX.Model.AssociatedPrintersInfo> GetAssociatedPrintersName(int substoreID)
        {
            try
                {
                var obj = baAssociatedPrintersInfo.GetAssociatedPrintersInfoData()
                    .Where(p => p.PS_AssociatedPrinters_SubStoreID == substoreID)
                    .Select(p => new PhotoSW.IMIX.Model.AssociatedPrintersInfo()
                        {
                        DG_AssociatedPrinters_Pkey = p.PS_AssociatedPrinters_Pkey,
                        DG_AssociatedPrinters_Name = p.PS_AssociatedPrinters_Name,
                        DG_AssociatedPrinters_ProductType_ID = p.PS_AssociatedPrinters_ProductType_ID,
                        DG_AssociatedPrinters_IsActive = p.PS_AssociatedPrinters_IsActive,
                        DG_AssociatedPrinters_PaperSize = p.PS_AssociatedPrinters_PaperSize,
                        DG_AssociatedPrinters_SubStoreID = p.PS_AssociatedPrinters_SubStoreID,
                        DG_Orders_ProductType_Name = p.PS_Orders_ProductType_Name
                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.AssociatedPrintersInfo>();
                }
            // return new List<PhotoSW.IMIX.Model.AssociatedPrintersInfo>();
            }
        public List<PhotoSW.IMIX.Model.AssociatedPrintersInfo> GetPrinterDetails(int substoreID)
        {
            try
                {
                var obj = baAssociatedPrintersInfo.GetAssociatedPrintersInfoData()
                    .Where(p => p.PS_AssociatedPrinters_SubStoreID == substoreID)
                    .Select(p => new PhotoSW.IMIX.Model.AssociatedPrintersInfo()
                        {
                        DG_AssociatedPrinters_Pkey =(int) p.Id,
                        DG_AssociatedPrinters_Name = p.PS_AssociatedPrinters_Name,
                        DG_AssociatedPrinters_ProductType_ID = p.PS_AssociatedPrinters_ProductType_ID,
                        DG_AssociatedPrinters_IsActive = p.PS_AssociatedPrinters_IsActive,
                        DG_AssociatedPrinters_PaperSize = p.PS_AssociatedPrinters_PaperSize,
                        DG_AssociatedPrinters_SubStoreID = p.PS_AssociatedPrinters_SubStoreID,
                        DG_Orders_ProductType_Name = p.PS_Orders_ProductType_Name
                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.AssociatedPrintersInfo>();
                }
            }
        public ObservableCollection<PhotoSW.IMIX.Model.PrinterJobInfo> GetPrinterJobInfo(DataTable Dudt_PrintJobInfot,
            string PrinterName, string DigiFolderThumbnailPath)
        {
            return new ObservableCollection<PhotoSW.IMIX.Model.PrinterJobInfo>();
        }
        public string GetPrinterNameFromID(int id)
        {
            try
                {
                //var obj = baPrinterQueueDetailsInfo.GetPrinterQueueDetailsInfoData()
                //    .Where(p => p.Id == id).FirstOrDefault();
                //      return obj.PS_AssociatedPrinters_Name;

                var obj = baAssociatedPrintersInfo.GetAssociatedPrintersInfoDataById(id);
                return obj.PS_AssociatedPrinters_Name + "#" + obj.PS_AssociatedPrinters_ProductType_ID + "#" + obj.PS_Orders_ProductType_Name;
                }
            catch
                {
                return "";
                }
            }
        public List<PhotoSW.IMIX.Model.PrinterQueueforPrint> GetPrinterQueue(int substoreID, ref string productypeId)
        {            
             return new List<PhotoSW.IMIX.Model.PrinterQueueforPrint>();
        }
        public List<PhotoSW.IMIX.Model.PrinterQueueDetailsInfo> GetPrinterQueueDetails(string ordernumer)
        {
            try
                {
                var obj = baPrinterQueueDetailsInfo.GetPrinterQueueDetailsInfoData()
                    .Where(p => p.PS_Orders_Number == ordernumer)
                    .Select(p => new PhotoSW.IMIX.Model.PrinterQueueDetailsInfo()
                        {
                        DG_AssociatedPrinters_Pkey = p.PS_AssociatedPrinters_Pkey,
                        DG_AssociatedPrinters_Name = p.PS_AssociatedPrinters_Name,
                        DG_Orders_pkey = p.PS_Orders_pkey,
                        DG_Orders_Number = p.PS_Orders_Number,
                        DG_Order_SubStoreId = p.PS_Order_SubStoreId,
                        DG_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        DG_Orders_ProductType_pkey = p.PS_Orders_ProductType_pkey,
                        DG_PrinterQueue_Pkey = p.PS_PrinterQueue_Pkey,
                        DG_PrinterQueue_ProductID = p.PS_PrinterQueue_ProductID,
                        DG_PrinterQueue_Image_Pkey = p.PS_PrinterQueue_Image_Pkey,
                        DG_Associated_PrinterId = p.PS_Associated_PrinterId,
                        DG_Order_Details_Pkey = p.PS_Order_Details_Pkey,
                        DG_SentToPrinter = p.PS_SentToPrinter,
                        is_Active = p.is_Active,
                        QueueIndex = p.QueueIndex,
                        DG_Photos_RFID = p.PS_Photos_RFID,
                        DG_Photos_pKey = p.PS_Photos_pKey
                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.PrinterQueueDetailsInfo>();
                }
            // return new List<PhotoSW.IMIX.Model.PrinterQueueDetailsInfo>();
            }
        public PhotoSW.IMIX.Model.PrinterQueueforPrint GetPrinterQueueforPrint(int SubStoreID, ref List<int> ProducttypeId)
        {
            return new PhotoSW.IMIX.Model.PrinterQueueforPrint();
        }
        public List<PhotoSW.IMIX.Model.PrinterQueueInfo> GetPrinterQueueForUpdown(int substoreID)
        {
            return new List<Model.PrinterQueueInfo>();
        }
        public List<PhotoSW.IMIX.Model.PrinterQueueInfo> GetPrintLogDetails()
        {
            return new List<Model.PrinterQueueInfo> ();
        }
        public PhotoSW.IMIX.Model.PrinterQueueInfo GetQueueDetail(int Name)
        {
            return new Model.PrinterQueueInfo ();
        }
        public bool IsReadyForPrint(int QueueID)
        {
            return false;
        }
        public void ReadyForPrint(int QueueId)
        {
        }
        public void SaveAlbumPrintPosition(int OrderLineItemId, List<PhotoSW.DataLayer.PhotoPrintPositionDic> PrintPhotoOrderIds)
        {
        }
        public string SelectQRCode(int productId)
        {
            return "";
        }
        public bool SetDataToPrinterQueue(string PhotoId, int? ProductTypeId, int? DG_AssocatedPrinterId,
            bool DG_SentToPrinter, int orderDetailID)
        {
            return false;
        }
        public void SetPrinterDetails (int ID, string PrinterName, int productType, bool isactive, string productName, string Papersize, int SubStoreId )
            {
            if(ID == 0)
                {
                baAssociatedPrintersInfo obj = new baAssociatedPrintersInfo();

                obj.PS_AssociatedPrinters_Name = PrinterName;
                obj.PS_AssociatedPrinters_ProductType_ID = productType;
                obj.PS_AssociatedPrinters_PaperSize = Papersize;
                obj.PS_AssociatedPrinters_SubStoreID = SubStoreId;
                obj.PS_Orders_ProductType_Name = productName;
                obj.IsActive = isactive;
                obj.PS_AssociatedPrinters_IsActive = isactive;

                baAssociatedPrintersInfo.Insert(obj);
                }
            else
                {
                baAssociatedPrintersInfo obj = new baAssociatedPrintersInfo();
                obj.Id = ID;
                obj.PS_AssociatedPrinters_Name = PrinterName;
                obj.PS_AssociatedPrinters_ProductType_ID = productType;
                obj.PS_AssociatedPrinters_PaperSize = Papersize;
                obj.PS_AssociatedPrinters_SubStoreID = SubStoreId;               
                obj.PS_Orders_ProductType_Name = productName;
                obj.IsActive = isactive;
                obj.PS_AssociatedPrinters_IsActive = isactive;
                baAssociatedPrintersInfo.Update(obj);
                }

            }
      
        public void SetPrinterLog(int PhotoId, int UserId, int ProductTypeId)
        {
        }
        public void SetPrinterQueue(int QueueId)
        {
        }
        public void SetPrinterQueueForReprint(int QueueId)
        {
        }
        public void SetPrintQueueIndex(int pkey, string flag)
        {
        }
        public void UpdatePrintCountForReprint(int QueueId)
        {
        }
    }
}
