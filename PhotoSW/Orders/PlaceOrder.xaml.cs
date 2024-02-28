using PhotoSW.Calender;
using PhotoSW.Common;
using PhotoSW.DataLayer;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using FrameworkHelper;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using XPBurn;
using DigiPhoto;
using PhotoSW.Views;
using PhotoSW.PSControls;

namespace PhotoSW.Orders
{
	public partial class PlaceOrder : Window, IComponentConnector, IStyleConnector
	{
		private  List<Product> _productType;

		private bool _issemiorder = false;

		private ObservableCollection<LineItem> _objLineItem;

		private List<ProductPriceInfo> _lstPricing;

		private string _defaultEffect = "<image brightness=\"0\" contrast=\"1\" Crop=\"##\" colourvalue=\"##\" rotate=\"##\"><effects sharpen=\"##\" greyscale=\"0\" digimagic=\"0\" sepia=\"0\" defog=\"0\" underwater=\"0\" emboss=\"0\" invert=\"0\" granite=\"0\" hue=\"##\" cartoon=\"0\" /></image>";

		private string _defaultSpecPrintLayer = "<photo zoomfactor=\"1\" border=\"\" bg=\"\" canvasleft=\"-1\" canvastop=\"-1\" scalecentrex=\"-1\" scalecentrey=\"-1\" />";

		private LineItem _current = new LineItem();

		public bool isChkSpecOnlinePackage = false;

		

		public string DefaultCurrency
		{
			get;
			set;
		}

		public int id
		{
			get;
			set;
		}

		public PlaceOrder()
		{
			try
			{
				this.InitializeComponent();
				this._objLineItem = new ObservableCollection<LineItem>();
				this.dgOrder.ItemsSource = this._objLineItem;
				this._lstPricing = new List<ProductPriceInfo>();
				this._productType = new List<Product>();
				this.AddPricing();
				this.FillProductType();
				this.DefaultCurrency = this.GetDefaultCurrency();
				this.ShowTotalPrice();
				this.btnNextsimg.IsDefault = true;
                Test();
				this.CtrlSelectedCalenderList.IsVisibleChanged += new DependencyPropertyChangedEventHandler(this.CtrlSelectedCalenderList_IsVisibleChanged);
				this.AddPrintedImagesOnOff();
			}
			catch (Exception serviceException)
			{
				ErrorHandler.ErrorHandler.LogError(serviceException);
			}
		}
        private void Test ()
            {
            LineItem current;
            if(4 != 0)
                {
                bool arg_1A_0 = false;
                bool arg_29_0 = arg_1A_0 = (this.CtrlSelectedCalenderList.Visibility == Visibility.Collapsed);
                do
                    {
                    if(8 != 0)
                        {
                        bool flag = !arg_1A_0;
                        arg_29_0 = (arg_1A_0 = flag);
                        }
                    }
                while(false);
                if(arg_29_0)
                    {
                    return;
                    }
                current = this._current;
                this.btnNextsimg.IsDefault = true;
                this.CtrlSelectedCalenderList.btnSubmit.IsDefault = false;
                }
            IL_61:
            if(4 == 0)
                {
                goto IL_61;
                }
            if(!false)
                {
                current.PrintOrderPageList = this.CtrlSelectedCalenderList.PrintOrderPageList;
                current.GroupItems = this.CtrlSelectedCalenderList.SelectedImage;
                }
            current.GroupItems = this.CtrlSelectedCalenderList.SelectedImage = RobotImageLoader.PrintImages;
            this.BindMyListItems(current, current.GroupItems);
            }
		private void CtrlSelectedCalenderList_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			LineItem current;
			if (4 != 0)
			{
				bool arg_1A_0=false;
				bool arg_29_0 = arg_1A_0 = (this.CtrlSelectedCalenderList.Visibility == Visibility.Collapsed);
				do
				{
					if (8 != 0)
					{
						bool flag = !arg_1A_0;
						arg_29_0 = (arg_1A_0 = flag);
					}
				}
				while (false);
				if (arg_29_0)
				{
					return;
				}
				current = this._current;
				this.btnNextsimg.IsDefault = true;
				this.CtrlSelectedCalenderList.btnSubmit.IsDefault = false;
			}
			IL_61:
			if (4 == 0)
			{
				goto IL_61;
			}
			if (!false)
			{
				current.PrintOrderPageList = this.CtrlSelectedCalenderList.PrintOrderPageList;
				current.GroupItems = this.CtrlSelectedCalenderList.SelectedImage;
			}
			this.BindMyListItems(current, current.GroupItems);
		}

		private FrameworkElement FindByName(string name, FrameworkElement root)
		{
			Stack<FrameworkElement> stack;
			if (!false)
			{
				stack = new Stack<FrameworkElement>();
				stack.Push(root);
				goto IL_A3;
			}
			IL_24:
			FrameworkElement frameworkElement = stack.Pop();
			FrameworkElement result;
			if (-1 != 0 && frameworkElement.Name == name)
			{
				result = frameworkElement;
				return result;
			}
			int arg_5A_0 = VisualTreeHelper.GetChildrenCount(frameworkElement);
			IL_5A:
			int num = arg_5A_0;
			int num2 = 0;
			while (true)
			{
				bool flag = num2 < num;
				bool arg_79_0;
				bool expr_9B = arg_79_0 = flag;
				if (false)
				{
					goto IL_79;
				}
				if (!expr_9B)
				{
					break;
				}
				goto IL_5F;
				IL_93:
				int arg_93_0;
				int arg_93_1;
				num2 = arg_93_0 + arg_93_1;
				continue;
				IL_5F:
				DependencyObject child = VisualTreeHelper.GetChild(frameworkElement, num2);
				int expr_71 = arg_93_0 = ((child is FrameworkElement) ? 1 : 0);
				int expr_74 = arg_93_1 = 0;
				if (expr_74 != 0)
				{
					goto IL_93;
				}
				arg_79_0 = (expr_71 == expr_74);
				IL_79:
				flag = arg_79_0;
				if (2 != 0)
				{
					if (!flag)
					{
						stack.Push((FrameworkElement)child);
					}
					arg_93_0 = num2;
					arg_93_1 = 1;
					goto IL_93;
				}
				goto IL_5F;
			}
			IL_A3:
			int expr_A4 = arg_5A_0 = stack.Count;
			if (!true)
			{
				goto IL_5A;
			}
			if (expr_A4 > 0)
			{
				goto IL_24;
			}
			result = null;
			return result;
		}

		protected void UpdatePricing(LineItem currentRecord)
		{
			try
			{
				List<PhotoPrintPositionDic> list;
				if (currentRecord.SelectedProductType_ID == 79 && currentRecord.GroupItems.Count<LstMyItems>() > 0)
				{
					list = new List<PhotoPrintPositionDic>();
					using (List<LstMyItems>.Enumerator enumerator = currentRecord.GroupItems.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							LstMyItems LstItm = enumerator.Current;
							if ((from p in list
							where p.PhotoId == LstItm.PhotoId
							select p).FirstOrDefault<PhotoPrintPositionDic>() == null)
							{
								foreach (PhotoPrintPosition current in LstItm.PhotoPrintPositionList)
								{
									list.Add(new PhotoPrintPositionDic(LstItm.PhotoId, current));
								}
							}
						}
					}
					currentRecord.PrintPhotoOrderPosition = list;
					foreach (LstMyItems current2 in RobotImageLoader.PrintImages)
					{
						current2.PhotoPrintPositionList.Clear();
					}
				}
				int arg_1C7_0;
				bool arg_4A8_0;
				if (currentRecord.SelectedProductType_ID == 100)
				{
					arg_4A8_0 = ((arg_1C7_0 = ((currentRecord.GroupItems.Count<LstMyItems>() <= 0) ? 1 : 0)) != 0);
					if (false)
					{
						goto IL_4A8;
					}
				}
				else
				{
					arg_1C7_0 = 1;
				}
				bool flag = arg_1C7_0 != 0;
				if (4 != 0)
				{
					if (flag)
					{
						goto IL_318;
					}
					list = new List<PhotoPrintPositionDic>();
					using (List<LstMyItems>.Enumerator enumerator = currentRecord.GroupItems.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							LstMyItems LstItm = enumerator.Current;
							if ((from p in list
							where p.PhotoId == LstItm.PhotoId
							select p).FirstOrDefault<PhotoPrintPositionDic>() == null)
							{
								foreach (PhotoPrintPosition current in LstItm.PhotoPrintPositionList)
								{
									list.Add(new PhotoPrintPositionDic(LstItm.PhotoId, current));
								}
							}
						}
					}
				}
				currentRecord.PrintPhotoOrderPosition = list;
				foreach (LstMyItems current2 in RobotImageLoader.PrintImages)
				{
					if (7 != 0)
					{
						current2.PhotoPrintPositionList.Clear();
					}
				}
				IL_318:
				if (!(currentRecord.ParentID == currentRecord.ItemNumber))
				{
					goto IL_61B;
				}
				int num = 0;
                double? num2 = (from result in this._lstPricing//.Where( 
                                select result.DG_Product_Pricing_ProductPrice).FirstOrDefault<double?>();
                //double? num2 = (from result in this._lstPricing.Where( delegate(ProductPriceInfo result)
                //{
                //    if (false)
                //    {
                //        goto IL_2F;
                //    }
                //    int? dG_Product_Pricing_ProductType;
                //    if (!false)
                //    {
                //        dG_Product_Pricing_ProductType = result.DG_Product_Pricing_ProductType;
                //    }
                //    if (7 == 0)
                //    {
                //        goto IL_2D;
                //    }
                //    int expr_44 = currentRecord.SelectedProductType_ID;
                //    int num4;
                //    if (6 != 0)
                //    {
                //        num4 = expr_44;
                //    }
                //    bool arg_2C_0 = dG_Product_Pricing_ProductType == num4;
                //    IL_2B:
                //    bool flag2 = arg_2C_0;
                //    IL_2D:
                //    IL_2F:
                //    bool expr_2F = arg_2C_0 = flag2;
                //    if (!false)
                //    {
                //        return expr_2F;
                //    }
                //    goto IL_2B;
                //})
                //select result.DG_Product_Pricing_ProductPrice).FirstOrDefault<double?>();
				double num3 = Convert.ToDouble(num2);
				currentRecord.UnitPrice = num3;
				if (currentRecord.IsBundled)
				{
					num = currentRecord.Quantity;
					currentRecord.TotalPrice = (num3 * (double)num).ToDouble(false);
					goto IL_581;
				}
				if (currentRecord.IsPackage)
				{
					num = currentRecord.Quantity;
					currentRecord.TotalPrice = (num3 * (double)num).ToDouble(false);
					goto IL_580;
				}
				int arg_5E0_0;
				bool arg_45B_0;
				if (currentRecord.SelectedProductType_ID != 35)
				{
					int expr_425 = arg_5E0_0 = currentRecord.SelectedProductType_ID;
					if (false)
					{
						goto IL_5D9;
					}
					if (expr_425 != 36 && currentRecord.SelectedProductType_ID != 78)
					{
						arg_45B_0 = (currentRecord.SelectedProductType_ID != 100);
						goto IL_45A;
					}
				}
				arg_45B_0 = false;
				IL_45A:
				if (!arg_45B_0)
				{
					currentRecord.TotalPrice = num3;
					goto IL_54F;
				}
				if (currentRecord.SelectedImages == null)
				{
					num = currentRecord.Quantity;
					goto IL_4F8;
				}
				int arg_50E_0;
				int expr_49A = arg_50E_0 = currentRecord.SelectedImages.Count;
				if (-1 == 0)
				{
					goto IL_50E;
				}
				arg_4A8_0 = (expr_49A <= 0);
				IL_4A8:
				if (!arg_4A8_0)
				{
					num = currentRecord.SelectedImages.Count * currentRecord.Quantity;
				}
				else if (!false)
				{
					num = currentRecord.Quantity;
				}
				IL_4F8:
				arg_50E_0 = ((currentRecord.SelectedProductType_ID != 1091) ? 1 : 0);
				IL_50E:
				if (arg_50E_0 == 0)
				{
					currentRecord.TotalPrice = 0.0;
				}
				else
				{
					currentRecord.TotalPrice = (num3 * (double)num).ToDouble(false);
				}
				IL_54F:
				IL_580:
				IL_581:
               int count= this._objLineItem.Where (p=>p.ParentID== currentRecord.ItemNumber).Count();
                if(count <= 0 || !this.CtrlSelectedQrCode.IsQrCodeUsed)
                    {
                    goto IL_601;
                    }
                //if (this._objLineItem.Where(delegate(LineItem o)
                //{
                //    if (o.SelectedProductType_ID == 84)
                //    {
                //        goto IL_08;
                //    }
                //    goto IL_1C;
                //    IL_1D:
                //    while (false)
                //    {
                //    }
                //    bool arg_53_0;
                //    bool flag2 = arg_53_0;
                //    bool arg_2D_0;
                //    if (8 != 0)
                //    {
                //        if (!false)
                //        {
                //            arg_2D_0 = flag2;
                //            return arg_2D_0;
                //        }
                //        goto IL_1C;
                //    }
                //    IL_08:
                //    arg_53_0 = (arg_2D_0 = (o.ParentID == currentRecord.ItemNumber));
                //    if (true)
                //    {
                //        goto IL_1D;
                //    }
                //    return arg_2D_0;
                //    IL_1C:
                //    arg_53_0 = false;
                //    goto IL_1D;
                //}).Count<LineItem>() <= 0 || !this.CtrlSelectedQrCode.IsQrCodeUsed)
                //{
                //    goto IL_601;
                //}
				num = currentRecord.Quantity;
				if (num <= 0)
				{
					arg_5E0_0 = num;
				}
				else
				{
					arg_5E0_0 = num - 1;
				}
				IL_5D9:
				num = arg_5E0_0;
				currentRecord.TotalPrice = (num3 * (double)num).ToDouble(false);
				IL_601:
				currentRecord.NetPrice = currentRecord.TotalPrice;
				IL_61B:
				this.ShowTotalPrice();
			}
			catch (Exception var_10_63D)
			{
			}
		}

		private void ShowTotalPrice()
		{
			if (false)
			{
				goto IL_6C;
			}
			if (false)
			{
				goto IL_70;
			}
			double num = 0.0;
			IL_12:
			if (2 != 0)
			{
				num = (from i in this._objLineItem
				select i.TotalPrice).Sum();
			}
			this.TxtAmounttobePaid.Text = this.DefaultCurrency.ToString() + "  " + num.ToString("N2");
			IL_6C:
			if (!false)
			{
			}
			IL_70:
			if (5 != 0)
			{
				return;
			}
			goto IL_12;
		}

		protected void AddPricing()
		{
			this._lstPricing = new ProductBusiness().GetProductPricingStoreWise(LoginUser.StoreId);
		}

		protected string AddNewRow(Product productId, string parentId, bool visible, int index)
		{
			string text = string.Empty;
			if (productId == null)
			{
				LineItem lineItem = new LineItem();
				string text2 = Guid.NewGuid().ToString();
				lineItem.ItemNumber = text2;
				lineItem.ParentID = text2;
				lineItem.IssemiOrder = false;
				lineItem.GroupItems = new List<LstMyItems>();
				foreach (LstMyItems current in this.GetGroupImages(text2, null))
				{
					lineItem.GroupItems.Add(current);
				}
				lineItem.CommandVisible = true;
				lineItem.ItemIndex = this._objLineItem.Count - 1 + 1;
				this._objLineItem.Add(lineItem);
				text = text2.ToString();
			}
			else
			{
				LineItem lineItem = new LineItem();
				string text2 = Guid.NewGuid().ToString();
				lineItem.ItemNumber = text2;
				lineItem.GroupItems = new List<LstMyItems>();
				foreach (LstMyItems current in this.GetGroupImages(text2, productId.IsPrintType))
				{
					lineItem.GroupItems.Add(current);
				}
				lineItem.ParentID = parentId;
				lineItem.SelectedProductType_ID = productId.ProductID;
				lineItem.SelectedProductType_Text = productId.ProductName;
				lineItem.SelectedProductType_Image = productId.ProductIcon;
				lineItem.IsAccessory = productId.IsAccessory;
				lineItem.IsWaterMarked = productId.IsWaterMarked;
				lineItem.IsBundled = productId.IsBundled;
				lineItem.CommandVisible = visible;
				IEnumerable<int> source = from i in this._objLineItem
				where i.ItemNumber == parentId
				select i.SelectedProductType_ID;
				int maxQuantityofIteminaPackage = new PackageBusniess().GetMaxQuantityofIteminaPackage(source.FirstOrDefault<int>().ToInt32(false), productId.ProductID);
				lineItem.TotalMaxSelectedPhotos = maxQuantityofIteminaPackage;
				lineItem.Quantity = new PackageBusniess().GetChildProductTypeQuantity(productId.ProductID, source.FirstOrDefault<int>().ToInt32(false)).ToInt32(false);
				lineItem.ItemIndex = this._objLineItem.Count - 1 + 1;
				this._objLineItem.Add(lineItem);
				if (text == string.Empty)
				{
					text = text2.ToString();
				}
				else
				{
					text = text + "," + text2.ToString();
				}
			}
			return text;
		}

		private void FillProductType()
		{
			if (!false)
			{
				try
				{
					SubStoresInfo substoreData = new StoreSubStoreDataBusniess().GetSubstoreData(LoginUser.SubStoreId);
					int subStoreID = 0;
					int arg_73_0;
					bool expr_28 = (arg_73_0 = ((substoreData == null) ? 1 : 0)) != 0;
					if (-1 != 0)
					{
						if (expr_28)
						{
							goto IL_74;
						}
						if (!(substoreData.LogicalSubStoreID == 0))
						{
							arg_73_0 = Convert.ToInt32(substoreData.LogicalSubStoreID);
						}
						else
						{
							arg_73_0 = LoginUser.SubStoreId;
						}
					}
					subStoreID = arg_73_0;
					IL_74:
					List<ProductTypeInfo> productTypeforOrder = new ProductBusiness().GetProductTypeforOrder(subStoreID);
                    IOrderedEnumerable<ProductTypeInfo> orderedEnumerable = from t in productTypeforOrder
                                                                            orderby t.DG_Orders_ProductNumber
                                                                            select t; //.FindAll(ProductTypeInfo)
                    //IOrderedEnumerable<ProductTypeInfo> orderedEnumerable = from t in productTypeforOrder.FindAll(delegate(ProductTypeInfo t)
                    //{
                    //    int? dG_Orders_ProductNumber = t.DG_Orders_ProductNumber;
                    //    if (dG_Orders_ProductNumber.GetValueOrDefault() == 0)
                    //    {
                    //        goto IL_0C;
                    //    }
                    //    goto IL_18;
                    //    IL_19:
                    //    while (false)
                    //    {
                    //    }
                    //    bool arg_45_0;
                    //    bool flag2 = arg_45_0;
                    //    bool arg_29_0;
                    //    if (8 != 0)
                    //    {
                    //        if (!false)
                    //        {
                    //            arg_29_0 = flag2;
                    //            return arg_29_0;
                    //        }
                    //        goto IL_18;
                    //    }
                    //    IL_0C:
                    //    arg_45_0 = (arg_29_0 = !dG_Orders_ProductNumber.HasValue);
                    //    if (true)
                    //    {
                    //        goto IL_19;
                    //    }
                    //    return arg_29_0;
                    //    IL_18:
                    //    arg_45_0 = true;
                    //    goto IL_19;
                    //})
                    //orderby t.DG_Orders_ProductNumber
                    //select t;
					IEnumerator<ProductTypeInfo> enumerator = orderedEnumerable.GetEnumerator();
					try
					{
						while (true)
						{
							while (true)
							{
								ProductTypeInfo current;
								Product product;
								bool isBundled;
								if (2 != 0)
								{
									if (!enumerator.MoveNext())
									{
										goto Block_13;
									}
									current = enumerator.Current;
									product = new Product();
									product.ProductID = current.DG_Orders_ProductType_pkey;
									product.ProductName = current.DG_Orders_ProductType_Name.ToString();
									if (7 == 0)
									{
										break;
									}
									isBundled = false;
								}
								if (current.DG_Orders_ProductType_IsBundled.HasValue)
								{
									isBundled = current.DG_Orders_ProductType_IsBundled.Value;
								}
								product.IsBundled = isBundled;
								product.ProductIcon = current.DG_Orders_ProductType_Image.ToString();
								product.DiscountOption = current.DG_Orders_ProductType_DiscountApplied.Value;
								product.IsPackage = current.DG_IsPackage;
								product.IsAccessory = current.DG_IsAccessory.Value;
								product.IsWaterMarked = current.DG_IsWaterMarkIncluded.Value;
								product.MaxQuantity = current.DG_MaxQuantity;
								product.IsPrintType = new int?(current.IsPrintType);
								this._productType.Add(product);
								if (!false)
								{
								}
							}
						}
						Block_13:;
					}
					finally
					{
						do
						{
							bool arg_20C_0 = enumerator == null;
							bool expr_20E;
							do
							{
								bool flag = arg_20C_0;
								expr_20E = (arg_20C_0 = flag);
							}
							while (false);
							if (!expr_20E)
							{
								enumerator.Dispose();
							}
						}
						while (3 == 0);
					}
				}
				catch
				{
				}
			}
		}

		private void dgOrder_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
		{
			e.Cancel = true;
		}

		private void btnAddMore_Click(object sender, RoutedEventArgs e)
		{
			int arg_6B_0;
			int arg_6B_1;
			if (this.dgOrder.Items.Count > 0)
			{
				bool arg_1B4_0 = this.SelectImageRequired();
				while (!arg_1B4_0)
				{
					if (false)
					{
						goto IL_B5;
					}
					this.AddNewRow(null, "", true, -1);
					arg_1B4_0 = ((arg_6B_0 = this.dgOrder.Items.Count) != 0);
					if (!false)
					{
						arg_6B_1 = 1;
						goto IL_6B;
					}
				}
				MessageBox.Show("Please select atleast one image per line item to continue..", "Spectra Photo");
				goto IL_E8;
			}
			this.AddNewRow(null, "", true, -1);
			int arg_70_0;
			int expr_109 = arg_6B_0 = (arg_70_0 = this.dgOrder.Items.Count);
			int arg_6D_0;
			int expr_10F = arg_6D_0 = 1;
			if (expr_10F != 0)
			{
				bool flag = expr_109 - expr_10F <= 0;
				if (-1 != 0)
				{
					if (!flag)
					{
						this.dgOrder.SelectedItem = this.dgOrder.Items[this.dgOrder.Items.Count - 1];
					}
					else
					{
						this.dgOrder.SelectedItem = this.dgOrder.Items[0];
					}
				}
				goto IL_175;
			}
			goto IL_6D;
			IL_6B:
			arg_70_0 = (arg_6B_0 -= arg_6B_1);
			arg_6D_0 = 0;
			IL_6D:
			int expr_6D = arg_6B_1 = arg_6D_0;
			if (expr_6D != 0)
			{
				goto IL_6B;
			}
			if (arg_70_0 > expr_6D)
			{
				if (4 != 0)
				{
					this.dgOrder.SelectedItem = this.dgOrder.Items[this.dgOrder.Items.Count - 1];
					goto IL_D3;
				}
				goto IL_175;
			}
			else if (false)
			{
				goto IL_D2;
			}
			IL_B5:
			this.dgOrder.SelectedItem = this.dgOrder.Items[0];
			IL_D2:
			IL_D3:
			IL_E8:
			IL_175:
			this.LoadProductTypeControl(sender);
		}

		public List<LstMyItems> GetGroupImages(string itemNumber, int? IsPrintType)
		{
			List<LstMyItems> list;
			List<LstMyItems> result;
			if (!false)
			{
				//string itemNumber;
				while (true)
				{
					//itemNumber = itemNumber2;
					int? num = IsPrintType;
					while (true)
					{
						bool flag = !(num == 0);
						if (!false)
						{
							if (!flag)
							{
								list = RobotImageLoader.GroupImages;
								goto IL_5D;
							}
							if (2 != 0)
							{
								break;
							}
							IL_7C:
							if (-1 == 0)
							{
								continue;
							}
							if (!false)
							{
								goto Block_7;
							}
							IL_5D:
							list.Select(delegate(LstMyItems c)
							{
								while (true)
								{
									if (!false)
									{
									}
									if (8 != 0)
									{
										c.FrameBrdr = itemNumber;
										while (!false)
										{
											if (8 != 0)
											{
												return c;
											}
										}
									}
								}
								return c;
							}).ToList<LstMyItems>();
							goto IL_7C;
						}
					}
					if (!false)
					{
						goto Block_9;
					}
				}
				Block_7:
				result = list;
				return result;
				Block_9:
				list = RobotImageLoader.PrintImages;
				list.Select(delegate(LstMyItems c)
				{
					while (true)
					{
						if (!false)
						{
						}
						if (8 != 0)
						{
							c.FrameBrdr = itemNumber;
							while (!false)
							{
								if (8 != 0)
								{
									return c;
								}
							}
						}
					}
					return c;
				}).ToList<LstMyItems>();
			}
			result = list;
			return result;
		}

		private void btndelete_Click(object sender, RoutedEventArgs e)
		{	LineItem ToBeDeleteditem = (LineItem)this.dgOrder.CurrentItem;
				Button source = (Button)sender;
			if (!false)
			{
			
				bool flag = source.Tag == null;
				if (false)
				{
					goto IL_16B;
				}
				if (flag)
				{
					goto IL_14E;
				}
				if (!(source.Tag.ToString() != "-1"))
				{
					goto IL_10C;
				}
			}
			IL_92:
			List<LineItem> list = this._objLineItem.Where(delegate(LineItem lineitem)
			{
				bool result;
				do
				{
					if (true && !false)
					{
						result = (lineitem.ParentID == source.Tag.ToString());
					}
					while (false)
					{
					}
				}
				while (8 == 0);
				return result;
			}).ToList<LineItem>();
			if (list != null)
			{
				using (List<LineItem>.Enumerator enumerator = list.GetEnumerator())
				{
					if (!false)
					{
						goto IL_EB;
					}
					IL_D9:
					if (8 != 0)
					{
						LineItem current=enumerator.Current;
						this._objLineItem.Remove(current);
					}
					IL_EB:
					if (enumerator.MoveNext())
					{
						LineItem current = enumerator.Current;
						//goto IL_D9;
					}
				}
			}
			IL_10C:
			LineItem lineItem = this._objLineItem.Where(delegate(LineItem lineitem)
			{
				bool result;
				do
				{
					if (true && !false)
					{
						result = (lineitem.ItemNumber == ToBeDeleteditem.ItemNumber.ToString());
					}
					while (false)
					{
					}
				}
				while (8 == 0);
				return result;
			}).FirstOrDefault<LineItem>();
			if (lineItem == null)
			{
				goto IL_14D;
			}
			IL_13F:
			this._objLineItem.Remove(lineItem);
			IL_14D:
			IL_14E:
			this.ShowTotalPrice();
			if (2 == 0)
			{
				goto IL_92;
			}
			this.CtrlSelectedQrCode.QRCode = string.Empty;
			IL_16B:
			if (false)
			{
				goto IL_13F;
			}
			if (!false)
			{
				return;
			}
			goto IL_10C;
		}

		private bool SelectImageRequired()
		{
			bool flag = false;
			int num = 0;
			using (IEnumerator<LineItem> enumerator = this._objLineItem.GetEnumerator())
			{
				while (true)
				{
					LineItem current;
					DataGridRow dataGridRow;
					Button button;
					if (!false)
					{
						if (!enumerator.MoveNext())
						{
							break;
						}
						current = enumerator.Current;
						dataGridRow = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(num);
						button = (this.FindByName("btnSelectImage", dataGridRow) as Button);
					}
					Button button2 = this.FindByName("btnAddSemiPrinted", dataGridRow) as Button;
					bool arg_93_0;
					if (button.Visibility != Visibility.Collapsed)
					{
						arg_93_0 = false;
						goto IL_92;
					}
					if (!false)
					{
						arg_93_0 = (button2.Visibility == Visibility.Collapsed);
						goto IL_92;
					}
					goto IL_FF;
					IL_112:
					num++;
					continue;
					IL_92:
					bool flag2 = arg_93_0;
					if (!false)
					{
						if (flag2)
						{
							goto IL_112;
						}
						if (current.IsAccessory)
						{
							goto IL_111;
						}
						if (current.SelectedImages == null)
						{
							flag2 = (dataGridRow == null);
							if (!false)
							{
								if (!flag2)
								{
									dataGridRow.Background = Brushes.LightYellow;
								}
								flag = true;
								goto IL_110;
							}
							goto IL_111;
						}
						else
						{
							if (current.SelectedImages.Count != 0)
							{
								goto IL_110;
							}
							flag2 = (dataGridRow == null);
						}
					}
					if (!flag2)
					{
						goto IL_FF;
					}
					goto IL_10D;
					IL_111:
					goto IL_112;
					IL_110:
					goto IL_111;
					IL_10D:
					flag = true;
					goto IL_110;
					IL_FF:
					dataGridRow.Background = Brushes.LightYellow;
					goto IL_10D;
				}
			}
			int arg_20C_0;
			if (3 != 0)
			{
				if (!flag)
				{
					goto IL_205;
				}
				bool flag2 = this._objLineItem == null || this._objLineItem.Count <= 1;
				bool arg_1E5_0;
				bool expr_197 = arg_1E5_0 = flag2;
				if (2 != 0)
				{
					if (expr_197)
					{
						goto IL_204;
					}
					int selectedProductType_ID = this._objLineItem[0].SelectedProductType_ID;
					int expr_1BE = arg_20C_0 = this._objLineItem[1].SelectedProductType_ID;
					if (false)
					{
						return arg_20C_0 != 0;
					}
					int num2 = expr_1BE;
					flag2 = (num2 != 84 || !new OrderBusiness().chKIsWaterMarkedOrNot(selectedProductType_ID));
					arg_1E5_0 = flag2;
				}
				if (arg_1E5_0)
				{
					goto IL_203;
				}
			}
			if (RobotImageLoader.GroupImages.Count<LstMyItems>() > 0)
			{
				flag = false;
			}
			IL_203:
			IL_204:
			IL_205:
			bool flag3 = flag;
			arg_20C_0 = (flag3 ? 1 : 0);
			return arg_20C_0 != 0;
		}

		private void SaveOrderDetails()
		{
			List<LstMyItems> arg_1111_0 = RobotImageLoader.GroupImages;
			Burningimage burningimage;
			string text5;
			List<int> list4;
			if (!false)
			{
				StringBuilder stringBuilder = new StringBuilder();
				string expr_1B = string.Empty;
				string text;
				if (!false)
				{
					text = expr_1B;
				}
				List<BurnImagesForCD> list = new List<BurnImagesForCD>();
				string text2 = string.Empty;
				int num = 0;
				List<LinetItemsDetails> list2 = new List<LinetItemsDetails>();
				int num2 = -1;
				IEnumerable<LineItem> enumerable = from result in this._objLineItem
				where result.ParentID == result.ItemNumber
				select result;
				using (IEnumerator<LineItem> enumerator = enumerable.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						LineItem item = enumerator.Current;
						text2 = string.Empty;
						int num3;
						int j;
						string text4;
						string uniqueSynccode;
						int arg_302_0;
						if (!item.IsPackage)
						{
							if (!item.IsBundled)
							{
								int quantity = item.Quantity;
								if (!item.IsAccessory)
								{
									foreach (string current in item.SelectedImages)
									{
										int i = 1;
										while (i <= quantity)
										{
											string text3 = string.Empty;
											num3 = num - item.SelectedProductType_Text.Length;
											num3 += 35;
											for (j = 1; j <= num3; j++)
											{
												text3 += " ";
											}
											i++;
											stringBuilder.AppendLine(item.SelectedProductType_Text + text3 + item.UnitPrice.ToString(".00"));
										}
										if (text2 == string.Empty)
										{
											text2 = current;
										}
										else
										{
											text2 = text2 + "," + current;
										}
									}
								}
								LinetItemsDetails linetItemsDetails = new LinetItemsDetails();
								linetItemsDetails.Productname = item.SelectedProductType_Text;
								linetItemsDetails.Productprice = item.UnitPrice.ToString(".00");
								if (!item.IsAccessory)
								{
									linetItemsDetails.Productquantity = (item.Quantity * item.SelectedImages.Count).ToString();
								}
								else
								{
									linetItemsDetails.Productquantity = item.Quantity.ToString();
								}
								list2.Add(linetItemsDetails);
								goto IL_44B;
							}
							text4 = string.Empty;
							num3 = num - item.SelectedProductType_Text.Length;
							num3 += 35;
							j = 1;
							goto IL_304;
						}
						else
						{
							IEnumerable<LineItem> enumerable2 = this._objLineItem.Where(delegate(LineItem result)
							{
								int arg_54_0;
								do
								{
									bool expr_43 = (arg_54_0 = ((result.ParentID == item.ItemNumber) ? 1 : 0)) != 0;
									if (false)
									{
										goto IL_24;
									}
									if (!expr_43)
									{
										goto IL_23;
									}
								}
								while (false);
								bool expr_4D = (arg_54_0 = (result.IsPackage ? 1 : 0)) != 0;
								if (!false)
								{
									arg_54_0 = ((!expr_4D) ? 1 : 0);
								}
								IL_21:
								goto IL_24;
								IL_23:
								arg_54_0 = 0;
								IL_24:
								bool flag3 = arg_54_0 != 0;
								bool expr_57 = (arg_54_0 = (flag3 ? 1 : 0)) != 0;
								if (!false)
								{
									return expr_57;
								}
								goto IL_21;
							});
							uniqueSynccode = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.OrderDetails).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, LoginUser.SubStoreId.ToString());
							num2 = new OrderBusiness().SaveOrderLineItems(item.SelectedProductType_ID, null, text2, item.Quantity, item.TotalDiscount, (decimal)item.TotalDiscountAmount, (decimal)item.UnitPrice, (decimal)item.TotalPrice, (decimal)item.NetPrice, -1, LoginUser.SubStoreId, item.CodeType, item.UniqueCode, uniqueSynccode, null, null, null, null);
							if (item.SelectedProductType_ID == 79 && num2 > 0 && !string.IsNullOrEmpty(text2) && item.GroupItems.Count<LstMyItems>() > 0)
							{
								new PrinterBusniess().SaveAlbumPrintPosition(num2, item.PrintPhotoOrderPosition);
							}
							text4 = string.Empty;
							num3 = num - item.SelectedProductType_Text.Length;
							num3 += 35;
							int expr_86D;
							for (j = 1; j <= num3; j = expr_86D + 1)
							{
								text4 += " ";
								expr_86D = (arg_302_0 = j);
								if (false)
								{
									goto IL_302;
								}
							}
							stringBuilder.AppendLine(item.SelectedProductType_Text + text4 + item.UnitPrice.ToString(".00"));
							LinetItemsDetails linetItemsDetails = new LinetItemsDetails();
							linetItemsDetails.Productname = item.SelectedProductType_Text;
							linetItemsDetails.Productprice = item.UnitPrice.ToString(".00");
							linetItemsDetails.Productquantity = item.Quantity.ToString();
							if (false)
							{
								goto IL_5B5;
							}
							list2.Add(linetItemsDetails);
							foreach (LineItem current2 in enumerable2)
							{
								text2 = string.Empty;
								if (!current2.IsAccessory)
								{
									foreach (string current in current2.SelectedImages)
									{
										if (text2 == string.Empty)
										{
											text2 = current;
										}
										else
										{
											text2 = text2 + "," + current;
										}
									}
								}
								int num4 = 0;
								if (!item.IssemiOrder)
								{
									new OrderBusiness().setSemiOrderImageOrderDetails(null, text2.ToString(), new int?(num2), LoginUser.SubStoreId, item.TotalDiscount, 0m, 0m, 0m);
								}
								else
								{
									int num5 = Convert.ToInt32(ApplicationObjectEnum.OrderDetails);
									string uniqueSynccode2;
									do
									{
										string arg_A57_0 = num5.ToString().PadLeft(2, '0');
										string arg_A57_1 = LoginUser.countrycode;
										string arg_A57_2 = LoginUser.Storecode;
										num5 = LoginUser.SubStoreId;
										uniqueSynccode2 = CommonUtility.GetUniqueSynccode(arg_A57_0, arg_A57_1, arg_A57_2, num5.ToString());
									}
									while (false);
									num4 = new OrderBusiness().SaveOrderLineItems(current2.SelectedProductType_ID, null, text2, current2.Quantity, item.TotalDiscount, 0m, 0m, 0m, 0m, num2, LoginUser.SubStoreId, item.CodeType, item.UniqueCode, uniqueSynccode2, null, null, null, null);
									if (current2.SelectedProductType_ID == 79 && num4 > 0 && !string.IsNullOrEmpty(text2) && current2.GroupItems.Count<LstMyItems>() > 0)
									{
										new PrinterBusniess().SaveAlbumPrintPosition(num4, current2.PrintPhotoOrderPosition);
									}
								}
								if (current2.SelectedProductType_ID == 35 || current2.SelectedProductType_ID == 36 || current2.SelectedProductType_ID == 78)
								{
									foreach (string current in current2.SelectedImages)
									{
										list.Add(new BurnImagesForCD
										{
											ImageID = current.ToInt32(false),
											Producttype = current2.SelectedProductType_ID
										});
									}
								}
								else if (!current2.IsAccessory && item.SelectedProductType_ID != 84)
								{
									this.AddToPrintQueue(current2, num4, current2.PrintPhotoOrderPosition);
								}
								text2 = string.Empty;
							}
						}
						continue;
						IL_5DB:
						bool arg_5DC_0;
						int num6;
						if (!arg_5DC_0)
						{
							foreach (string current in item.SelectedImages)
							{
								list.Add(new BurnImagesForCD
								{
									ImageID = current.ToInt32(false),
									Producttype = item.SelectedProductType_ID
								});
							}
						}
						else if (!item.IsAccessory && item.SelectedProductType_ID != 84)
						{
							if (!this._issemiorder)
							{
								this.AddToPrintQueue(item, num6, item.PrintPhotoOrderPosition);
							}
						}
						continue;
						IL_5B5:
						if (item.SelectedProductType_ID != 36)
						{
							arg_5DC_0 = (item.SelectedProductType_ID != 78);
							goto IL_5DB;
						}
						goto IL_5DA;
						IL_44B:
						uniqueSynccode = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.OrderDetails).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, LoginUser.SubStoreId.ToString());
						num6 = new OrderBusiness().SaveOrderLineItems(item.SelectedProductType_ID, null, text2, item.Quantity, item.TotalDiscount, (decimal)item.TotalDiscountAmount, (decimal)item.UnitPrice, (decimal)item.TotalPrice, (decimal)item.NetPrice, num2, LoginUser.SubStoreId, item.CodeType, item.UniqueCode, uniqueSynccode, null, null, null, null);
						if (item.SelectedProductType_ID == 79 && num6 > 0 && !string.IsNullOrEmpty(text2) && item.GroupItems.Count<LstMyItems>() > 0)
						{
							new PrinterBusniess().SaveAlbumPrintPosition(num6, item.PrintPhotoOrderPosition);
						}
						if (item.SelectedProductType_ID != 35)
						{
							goto IL_5B5;
						}
						IL_5DA:
						arg_5DC_0 = false;
						goto IL_5DB;
						IL_304:
						if (j > num3)
						{
							int quantity = item.Quantity;
							for (int i = 1; i <= quantity; i++)
							{
								stringBuilder.AppendLine(item.SelectedProductType_Text + text4 + item.UnitPrice.ToString(".00"));
							}
							foreach (string current in item.SelectedImages)
							{
								if (text2 == string.Empty)
								{
									text2 = current;
									if (false)
									{
										break;
									}
								}
								else
								{
									text2 = text2 + "," + current;
								}
							}
							LinetItemsDetails linetItemsDetails2;
							if (!false)
							{
								linetItemsDetails2 = new LinetItemsDetails();
								linetItemsDetails2.Productname = item.SelectedProductType_Text;
							}
							linetItemsDetails2.Productprice = item.UnitPrice.ToString(".00");
							linetItemsDetails2.Productquantity = item.Quantity.ToString();
							list2.Add(linetItemsDetails2);
							goto IL_44B;
						}
						text4 += " ";
						arg_302_0 = j + 1;
						IL_302:
						j = arg_302_0;
						goto IL_304;
					}
				}
				Thread.Sleep(500);
				burningimage = new Burningimage();
				if (list.Count <= 0)
				{
					return;
				}
				text5 = Environment.CurrentDirectory + "\\DigiOrderdImages\\";
				if (Directory.Exists(text5))
				{
					Directory.Delete(text5, true);
					Directory.CreateDirectory(text5);
				}
				burningimage.Show();
				foreach (BurnImagesForCD current3 in list)
				{
					this.StartEngine(current3.ImageID.ToInt32(false), burningimage);
					if (text == string.Empty)
					{
						text = current3.ImageID.ToString();
					}
					else
					{
						text = text + "," + current3.ImageID;
					}
				}
				bool flag = false;
				if (!Directory.Exists(text5))
				{
					return;
				}
				List<int> list3 = (from result in list
				where result.Producttype == 36
				select result.ImageID).ToList<int>();
				list4 = (from result in list
				where result.Producttype == 35
				select result.ImageID).ToList<int>();
				bool flag2 = list3.Count <= 0;
				if (flag2)
				{
					goto IL_FA2;
				}
				string str;
				DriveInfo[] array;
				int k;
				DriveInfo driveInfo;
				if (!false)
				{
					DriveInfo[] drives = DriveInfo.GetDrives();
					str = string.Empty;
					array = drives;
					k = 0;
					while (true)
					{
						IL_E7B:
						int arg_E81_0 = k;
						int arg_E80_0 = array.Length;
						while (arg_E81_0 < arg_E80_0)
						{
							driveInfo = array[k];
							if (driveInfo.DriveType == DriveType.Removable)
							{
								str = driveInfo.RootDirectory.ToString();
								flag = true;
							}
							int expr_E72 = arg_E81_0 = k;
							int expr_E75 = arg_E80_0 = 1;
							if (expr_E75 != 0)
							{
								k = expr_E72 + expr_E75;
								goto IL_E7B;
							}
						}
						break;
					}
					if (!flag)
					{
						MessageBox.Show("No USB Drive Found ,please reinsert usb or cd again and press OK then");
						drives = DriveInfo.GetDrives();
						array = drives;
						k = 0;
						goto IL_EE3;
					}
					goto IL_EF2;
				}
				IL_EC5:
				if (!flag2)
				{
					str = driveInfo.RootDirectory.ToString();
					flag = true;
				}
				k++;
				IL_EE3:
				if (k < array.Length)
				{
					driveInfo = array[k];
					flag2 = (driveInfo.DriveType != DriveType.Removable);
					goto IL_EC5;
				}
				IL_EF2:
				if (flag)
				{
					using (List<int>.Enumerator enumerator5 = list3.GetEnumerator())
					{
						while (true)
						{
							flag2 = enumerator5.MoveNext();
							int current4;
							if (!flag2)
							{
								if (6 != 0)
								{
									break;
								}
							}
							else
							{
								current4 = enumerator5.Current;
								flag2 = !File.Exists(text5 + current4.ToString() + ".jpg");
							}
							if (!flag2)
							{
								File.Copy(text5 + current4.ToString() + ".jpg", str + "\\" + current4.ToString() + ".jpg", true);
							}
						}
					}
					goto IL_FA1;
				}
			}
			MessageBox.Show("Sorry your order could not be processed.", "Spectra Photo");
			IL_FA1:
			IL_FA2:
			if (list4.Count > 0)
			{
				if (!Directory.Exists(text5 + "\\DigiCD"))
				{
					Directory.CreateDirectory(text5 + "\\DigiCD");
				}
				foreach (int current4 in list4)
				{
					bool flag2 = !File.Exists(text5 + current4.ToString() + ".jpg");
					if (false || !flag2)
					{
						File.Copy(text5 + current4.ToString() + ".jpg", text5 + "\\DigiCD\\" + current4.ToString() + ".jpg", true);
					}
				}
				XPBurnCD xPBurnCD = new XPBurnCD();
				DirectoryInfo directoryInfo = new DirectoryInfo(text5 + "\\DigiCD\\");
				FileInfo[] files = directoryInfo.GetFiles();
				for (int k = 0; k < files.Length; k++)
				{
					FileInfo fileInfo = files[k];
					xPBurnCD.AddFile(fileInfo.FullName, fileInfo.Name);
				}
				try
				{
					xPBurnCD.RecordDisc(false, false);
				}
				catch (Exception serviceException)
				{
					string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
					ErrorHandler.ErrorHandler.LogFileWrite(message);
				}
			}
			if (burningimage != null)
			{
				burningimage.Close();
			}
		}

		private void PrepareImage(PhotoInfo objphoto, string destinationPath, Burningimage mw)
		{
			do
			{
				if (objphoto != null)
				{
					bool arg_32_0;
					bool expr_EF = arg_32_0 = string.IsNullOrEmpty(objphoto.DG_Photos_Effects);
					if (2 != 0)
					{
						bool flag = expr_EF;
						arg_32_0 = flag;
					}
					if (!arg_32_0)
					{
						mw.ImageEffect = objphoto.DG_Photos_Effects;
					}
					else
					{
						if (3 == 0)
						{
							continue;
						}
						mw.ImageEffect = "<image brightness = '0' contrast = '1' Crop='##' colourvalue = '##' rotate='##' ><effects sharpen='##' greyscale='0' digimagic='0' sepia='0' defog='0' underwater='0' emboss='0' invert = '0' granite='0' hue ='##' cartoon = '0'></effects></image>";
					}
				}
			}
			while (7 == 0);
			mw.WindowStyle = WindowStyle.None;
			mw.ResetForm(objphoto);
			mw.UpdateLayout();
			RenderTargetBitmap source = mw.jCaptureScreen();
			FileStream fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.ReadWrite);
			try
			{
				JpegBitmapEncoder jpegBitmapEncoder;
				if (!false)
				{
					jpegBitmapEncoder = new JpegBitmapEncoder();
					jpegBitmapEncoder.QualityLevel = 94;
				}
				jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(source));
				jpegBitmapEncoder.Save(fileStream);
			}
			finally
			{
				bool flag = fileStream == null;
				if (false || !flag)
				{
					((IDisposable)fileStream).Dispose();
				}
			}
			while (3 == 0)
			{
			}
		}

		private bool IsEffectApplied(PhotoInfo _objphoto)
		{
			int arg_AD_0;
			int arg_4F_0;
			if (!string.IsNullOrEmpty(_objphoto.DG_Photos_Effects))
			{
				int expr_101 = arg_AD_0 = string.Compare(_objphoto.DG_Photos_Effects, this._defaultEffect.TrimStart(new char[0]).TrimEnd(new char[0]), true);
				if (false)
				{
					goto IL_AD;
				}
				arg_4F_0 = ((expr_101 != 0) ? 1 : 0);
			}
			else
			{
				arg_4F_0 = 0;
			}
			bool flag;
			bool expr_53;
			do
			{
				flag = (arg_4F_0 != 0);
				if (4 == 0)
				{
					goto IL_B7;
				}
				expr_53 = ((arg_4F_0 = (flag ? 1 : 0)) != 0);
			}
			while (false);
			if (expr_53)
			{
				goto IL_B7;
			}
			flag = (!string.IsNullOrEmpty(_objphoto.DG_Photos_Layering) && !(_objphoto.DG_Photos_Layering == "test") && string.Compare(_objphoto.DG_Photos_Layering, this._defaultSpecPrintLayer.TrimStart(new char[0]).TrimEnd(new char[0]), true) != 0);
			arg_AD_0 = (flag ? 1 : 0);
			IL_AD:
			bool result;
			if (arg_AD_0 == 0)
			{
				result = false;
				if (!false)
				{
					return result;
				}
				return result;
			}
			IL_B7:
			result = true;
			return result;
		}

		private void StartEngine(int imgID, Burningimage MW)
		{
			try
			{
				try
				{
					PhotoInfo photoDetailsbyPhotoId = new PhotoBusiness().GetPhotoDetailsbyPhotoId(imgID);
					MW.PhotoName = photoDetailsbyPhotoId.DG_Photos_RFID;
					MW.PhotoId = imgID;
					string text = Path.Combine(photoDetailsbyPhotoId.HotFolderPath, "EditedImages", photoDetailsbyPhotoId.DG_Photos_FileName);
					string text2 = Environment.CurrentDirectory + "\\DigiOrderdImages\\";
					if (!Directory.Exists(text2))
					{
						Directory.CreateDirectory(text2);
					}
					if (File.Exists(text))
					{
						File.Copy(text, Path.Combine(text2, text2 + imgID + ".jpg"), true);
					}
					else if (!this.IsEffectApplied(photoDetailsbyPhotoId))
					{
						File.Copy(Path.Combine(photoDetailsbyPhotoId.HotFolderPath, photoDetailsbyPhotoId.DG_Photos_CreatedOn.ToString("yyyyMMdd"), photoDetailsbyPhotoId.DG_Photos_FileName), Path.Combine(text2, text2 + imgID + ".jpg"), true);
					}
					else
					{
						this.PrepareImage(photoDetailsbyPhotoId, text2 + imgID + ".jpg", MW);
					}
				}
				catch (Exception serviceException)
				{
					if (!false)
					{
						string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
						ErrorHandler.ErrorHandler.LogFileWrite(message);
					}
				}
				if (2 != 0)
				{
				}
			}
			finally
			{
				MemoryManagement.FlushMemory();
			}
		}

		private void ChkSelected_Unchecked(object sender, RoutedEventArgs e)
		{
			PlaceOrder expr_235 = new PlaceOrder();
			//PlaceOrder.8 
            //if (-1 != 0)
            //{
            //    = expr_235;
            //}
			CheckBox checkbox = (e.OriginalSource as CheckBox);
			DependencyObject dependencyObject = checkbox;
			LineItem lineItem;
			DataGridRow parent;
			DataGridCellsPresenter visualChild;
			DataGridCell dataGridCell;
            string text = string.Empty;
			while (true)
			{
				bool arg_5D_0 = dependencyObject != null && !(dependencyObject is ComboBoxItem);
				bool expr_F1;
				while (true)
				{
					bool flag = arg_5D_0;
					if (!true)
					{
						return;
					}
					if (flag)
					{
						goto IL_3D;
					}
					ComboBoxItem comboBoxItem = (ComboBoxItem)dependencyObject;
					LstMyItems lstMyItems = (LstMyItems)comboBoxItem.Content;
					if (checkbox == null)
					{
						return;
					}
					lineItem = (LineItem)this.dgOrder.CurrentItem;
					
					if (lineItem.SelectedImages == null)
					{
						goto IL_19B;
					}
					text = (from lineitem in lineItem.SelectedImages
					where lineitem == checkbox.Uid.ToString()
					select lineitem).FirstOrDefault<string>();
					flag = (text == null);
					if (false)
					{
						goto IL_1AB;
					}
					expr_F1 = (arg_5D_0 = flag);
					if (!false)
					{
						goto Block_8;
					}
				}
				continue;
				IL_3D:
				dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
				continue;
				IL_190:
				if (true)
				{
					break;
				}
				continue;
				IL_19B:
				lineItem.SelectedImages = new List<string>();
				if (true)
				{
					goto IL_1AB;
				}
				goto IL_190;
				Block_8:
				if (!expr_F1)
				{
					
					bool flag = text.Count<char>() <= 0;
					bool arg_116_0 = flag;
					if (2 == 0)
					{
						goto IL_1C7;
					}
					if (!arg_116_0)
					{
						lineItem.SelectedImages.Remove(checkbox.Uid.ToString());
						parent = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(this.dgOrder.SelectedIndex);
						visualChild = PlaceOrder.GetVisualChild<DataGridCellsPresenter>(parent);
						dataGridCell = (DataGridCell)visualChild.ItemContainerGenerator.ContainerFromIndex(3);
						dataGridCell.Content = lineItem.SelectedImages.Count;
					}
				}
				goto IL_190;
			}
			return;
			IL_1AB:
			lineItem.SelectedImages.Remove(checkbox.Uid.ToString());
			IL_1C7:
			parent = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(this.dgOrder.SelectedIndex);
			visualChild = PlaceOrder.GetVisualChild<DataGridCellsPresenter>(parent);
			dataGridCell = (DataGridCell)visualChild.ItemContainerGenerator.ContainerFromIndex(3);
			do
			{
				dataGridCell.Content = lineItem.SelectedImages.Count;
			}
			while (-1 == 0);
			this.UpdatePricing(lineItem);
		}

		private void ChkSelected_Checked(object sender, RoutedEventArgs e)
		{
			Func<string, bool> expr_00 = null;
			if (-1 != 0)
			{
				Func<string, bool> predicate = expr_00;
			}
			CheckBox checkbox = e.OriginalSource as CheckBox;
			DependencyObject dependencyObject = checkbox;
			int arg_21E_0;
			bool flag;
			LineItem lineItem;
			DataGridRow parent;
			DataGridCellsPresenter visualChild;
			DataGridCell dataGridCell;
			while (true)
			{
				IL_4A:
				int arg_69_0;
				if (dependencyObject != null)
				{
					arg_21E_0 = (arg_69_0 = ((!(dependencyObject is ComboBoxItem)) ? 1 : 0));
				}
				else
				{
					if (false)
					{
						break;
					}
					arg_21E_0 = (arg_69_0 = 0);
				}
				IL_62:
				while (5 != 0)
				{
					flag = (arg_69_0 != 0);
					if (!true)
					{
						return;
					}
					if (flag)
					{
						dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
						goto IL_4A;
					}
					ComboBoxItem comboBoxItem = (ComboBoxItem)dependencyObject;
					LstMyItems lstMyItems = (LstMyItems)comboBoxItem.Content;
					if (checkbox != null)
					{
						lineItem = (LineItem)this.dgOrder.CurrentItem;
						IL_B4:
						while (lineItem.SelectedImages != null)
						{
							IEnumerable<string> arg_E4_0 = lineItem.SelectedImages;
							Func<string, bool> predicate = (string lineitem) => lineitem == checkbox.Uid.ToString();
							string text = arg_E4_0.Where(predicate).FirstOrDefault<string>();
							bool expr_F6 = (arg_69_0 = (arg_21E_0 = ((text != null) ? 1 : 0))) != 0;
							if (!false)
							{
								flag = expr_F6;
								while (!flag)
								{
									lineItem.SelectedImages.Add(checkbox.Uid.ToString());
									parent = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(this.dgOrder.SelectedIndex);
									visualChild = PlaceOrder.GetVisualChild<DataGridCellsPresenter>(parent);
									dataGridCell = (DataGridCell)visualChild.ItemContainerGenerator.ContainerFromIndex(3);
									dataGridCell.Content = lineItem.SelectedImages.Count;
									if (6 == 0)
									{
										goto IL_B4;
									}
									if (true)
									{
										break;
									}
								}
								goto IL_189;
							}
							goto IL_62;
						}
						goto IL_18F;
					}
					return;
				}
				goto IL_21E;
			}
			IL_189:
			goto IL_211;
			IL_18F:
			lineItem.SelectedImages = new List<string>();
			IL_19C:
			lineItem.SelectedImages.Add(checkbox.Uid.ToString());
			parent = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(this.dgOrder.SelectedIndex);
			visualChild = PlaceOrder.GetVisualChild<DataGridCellsPresenter>(parent);
			dataGridCell = (DataGridCell)visualChild.ItemContainerGenerator.ContainerFromIndex(3);
			dataGridCell.Content = lineItem.SelectedImages.Count;
			IL_211:
			flag = (lineItem.SelectedImages == null);
			arg_21E_0 = (flag ? 1 : 0);
			IL_21E:
			if (arg_21E_0 == 0)
			{
				if (false)
				{
					goto IL_19C;
				}
				this.UpdatePricing(lineItem);
			}
		}

		private static T GetVisualChild<T>(Visual parent) where T : Visual
		{
			if (false)
			{
				goto IL_94;
			}
			T t;
			int childrenCount;
			int num;
			if (5 != 0)
			{
				t = default(T);
				childrenCount = VisualTreeHelper.GetChildrenCount(parent);
				num = 0;
				goto IL_8B;
			}
			goto IL_84;
			IL_7A:
			int arg_7A_0;
			bool flag = arg_7A_0 != 0;
			if (!flag)
			{
				return t;
			}
			IL_84:
			int expr_84 = arg_7A_0 = num;
			if (false)
			{
				goto IL_7A;
			}
			int arg_8A_0 = expr_84 + 1;
			IL_8A:
			num = arg_8A_0;
			IL_8B:
			int expr_8B = arg_8A_0 = num;
			if (5 == 0)
			{
				goto IL_8A;
			}
			flag = (expr_8B < childrenCount);
			IL_94:
			if (false)
			{
				goto IL_6D;
			}
			if (!flag)
			{
				return t;
			}
			IL_29:
			Visual visual = (Visual)VisualTreeHelper.GetChild(parent, num);
			t = (visual as T);
			flag = (t != null);
			if (!flag)
			{
				t = PlaceOrder.GetVisualChild<T>(visual);
			}
			IL_6D:
			if (!false)
			{
				arg_7A_0 = ((t == null) ? 1 : 0);
				goto IL_7A;
			}
			goto IL_29;
		}

		private void ProductType_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			while (true)
			{
				ComboBox expr_06 = (ComboBox)sender;
				ComboBox comboBox;
				if (4 != 0)
				{
					comboBox = expr_06;
				}
				if (-1 == 0)
				{
					goto IL_7D;
				}
				LineItem lineItem;
				if (5 != 0)
				{
					lineItem = (LineItem)this.dgOrder.CurrentItem;
					lineItem.SelectedProductType_ID = comboBox.SelectedValue.ToInt32(false);
					goto IL_4B;
				}
				IL_8E:
				List<PrinterDetailsInfo> associatedPrinters = new PrinterBusniess().GetAssociatedPrinters(new int?(comboBox.SelectedValue.ToInt32(false)));
				lineItem.AssociatedPrinters = associatedPrinters;
				this.UpdatePricing(lineItem);
				if (false)
				{
					continue;
				}
				if (!false)
				{
					break;
				}
				goto IL_4B;
				IL_7D:
				Product product;
				lineItem.SelectedProductType_Image = product.ProductIcon.ToString();
				goto IL_8E;
				IL_4B:
				product = (Product)comboBox.SelectedItem;
				lineItem.AllowDiscount = product.DiscountOption;
				if (false)
				{
					goto IL_7D;
				}
				while (true)
				{
					lineItem.SelectedProductType_Text = product.ProductName.ToString();
					if (!false)
					{
						goto IL_7D;
					}
				}
			}
		}

		private void dgOrder_Loaded(object sender, RoutedEventArgs e)
		{
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			this.AddNewRow(null, "", true, -1);
		}

		private string GetDefaultCurrency()
		{
			if (7 == 0 || false)
			{
				goto IL_54;
			}
			IL_07:
            string text =new CurrencyBusiness().GetCurrencyList().Where (p=>p.DG_Currency_Default==true).FirstOrDefault().DG_Currency_Symbol.ToString();
            //string text = (from objcurrency in new CurrencyBusiness().GetCurrencyList().Where(delegate(CurrencyInfo objcurrency)
            //{
            //    bool? dG_Currency_Default = objcurrency.DG_Currency_Default;
            //    int arg_42_0;
            //    if (!dG_Currency_Default.GetValueOrDefault())
            //    {
            //        arg_42_0 = 0;
            //        goto IL_16;
            //    }
            //    arg_42_0 = (dG_Currency_Default.HasValue ? 1 : 0);
            //    IL_10:
            //    if (!false)
            //    {
            //    }
            //    IL_16:
            //    bool expr_45;
            //    do
            //    {
            //        bool flag = arg_42_0 != 0;
            //        if (!false)
            //        {
            //        }
            //        expr_45 = ((arg_42_0 = (flag ? 1 : 0)) != 0);
            //    }
            //    while (8 == 0);
            //    if (!false)
            //    {
            //        return expr_45;
            //    }
            //    goto IL_10;
            //})
            //select objcurrency.DG_Currency_Symbol.ToString()).FirstOrDefault<string>();
			IL_54:
			string result = text;
			if (-1 != 0)
			{
				return result;
			}
			goto IL_07;
		}

		private void btnNextsimg_Click(object sender, RoutedEventArgs e)
		{
			if (this._objLineItem.Count > 0)
			{
				if (!this.SelectImageRequired())
				{
					if (!this.CheckOnlineUploadQRCode())
					{
						MessageBox.Show("Please Enter QR/Bar code.", "Spectra Photo");
					}
					else
					{
						if (!(new ConfigBusiness().GetConfigurationData(LoginUser.SubStoreId).PosOnOff == true))
						{
							if (LoginUser.IsDiscountAllowed.Value)
							{
								SelectPrinter selectPrinter = new SelectPrinter();
								selectPrinter.ImagesToPrint = this._objLineItem;
								selectPrinter.SourceParent = this;
								using (IEnumerator<LineItem> enumerator = this._objLineItem.GetEnumerator())
								{
									while (true)
									{
										bool flag = enumerator.MoveNext();
										if (-1 != 0)
										{
											if (!flag)
											{
												break;
											}
											LineItem current = enumerator.Current;
											if (current.IsPackage)
											{
												current.TotalQty = current.Quantity;
											}
											else if (current.IsBundled)
											{
												current.TotalQty = current.Quantity;
											}
											else if (current.IsAccessory)
											{
												current.TotalQty = current.Quantity;
											}
											else if (current.SelectedImages != null)
											{
												current.TotalQty = current.Quantity * current.SelectedImages.Count;
											}
											else
											{
												current.TotalQty = current.Quantity;
											}
										}
									}
								}
								selectPrinter._issemiorder = this._issemiorder;
								selectPrinter.Show();
								goto IL_459;
							}
							double num = 0.0;
							IEnumerator<LineItem> enumerator1 = this._objLineItem.GetEnumerator();
							try
							{
								while (true)
								{
									while (enumerator1.MoveNext())
									{
										if (-1 != 0)
										{
											LineItem current = enumerator1.Current;
											if (current.IsPackage)
											{
												current.TotalQty = current.Quantity;
											}
											else if (!false)
											{
												if (current.IsBundled)
												{
													current.TotalQty = current.Quantity;
												}
												else if (current.SelectedImages != null)
												{
													current.TotalQty = current.Quantity * current.SelectedImages.Count;
												}
												else
												{
													current.TotalQty = current.Quantity;
												}
											}
										}
									}
									break;
								}
							}
							finally
							{
								bool flag = enumerator1 == null;
								while (!flag)
								{
									if (!false)
									{
										enumerator1.Dispose();
										break;
									}
								}
							}
							foreach (LineItem current in this._objLineItem)
							{
								//LineItem current;
								num += current.TotalPrice;
							}
							this.GetDefaultCurrency();
							if (true)
							{
								Payment payment = new Payment();
								payment.TotalBill = num;
								payment.SourceParent = this;
								payment.PaybleAmount = num.ToDouble(false);
								payment.ImagesToPrint = this._objLineItem;
								payment.DefaultCurrency = this.GetDefaultCurrency();
								payment.Show();
								base.Visibility = Visibility.Hidden;
								payment.ShowPopup();
								goto IL_459;
							}
						}
						this.SaveOrderDetails();
						SearchResult searchResult = null;
						IEnumerator enumerator2 = Application.Current.Windows.GetEnumerator();
						try
						{
							while (true)
							{
								bool arg_E1_0;
								bool expr_EF = arg_E1_0 = enumerator2.MoveNext();
								Window window;
								if (!false)
								{
									if (!expr_EF)
									{
										break;
									}
									window = (Window)enumerator2.Current;
									bool flag = !(window.Title == "View/Order Station");
									arg_E1_0 = flag;
								}
								if (!arg_E1_0)
								{
									searchResult = (SearchResult)window;
								}
							}
						}
						finally
						{
							IDisposable disposable;
							if (!false)
							{
								disposable = (enumerator2 as IDisposable);
							}
							if (disposable != null && !false)
							{
								disposable.Dispose();
							}
						}
						if (searchResult == null)
						{
							searchResult = new SearchResult();
						}
						RobotImageLoader.SearchCriteria = "PhotoId";
						searchResult.pagename = "";
						searchResult.Savebackpid = "";
						searchResult.Show();
						searchResult.LoadWindow();
						base.Close();
						IL_459:
						base.Visibility = Visibility.Hidden;
					}
				}
				else
				{
					MessageBox.Show("Please select atleast one image per line item to continue..", "Spectra Photo");
				}
			}
			else
			{
            MessageBox.Show("Please select atleast one line item to continue..", "Spectra Photo");
			}
		}

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			SearchResult searchResult;
			while (true)
			{
				searchResult = null;
				//using (IEnumerator enumerator = Application.Current.Windows.GetEnumerator())
                IEnumerator enumerator = Application.Current.Windows.GetEnumerator();
                try 
				{
					while (true)
					{
						Window window;
						if (!enumerator.MoveNext())
						{
							if (7 != 0)
							{
								break;
							}
						}
						else
						{
							window = (Window)enumerator.Current;
						}
						if (window.Title == "View/Order Station")
						{
							while (2 == 0)
							{
							}
							searchResult = (SearchResult)window;
						}
					}
				}catch{
                }
				while (true)
				{
					bool arg_99_0 = searchResult != null;
					bool flag;
					bool expr_9B;
					do
					{
						flag = arg_99_0;
						expr_9B = (arg_99_0 = flag);
					}
					while (false);
					if (!expr_9B)
					{
						searchResult = new SearchResult();
					}
					if (RobotImageLoader.GroupImages.Count > 0)
					{
						searchResult.pagename = "MainGroup";
						goto IL_11B;
					}
					int arg_187_0;
					int expr_D2 = arg_187_0 = RobotImageLoader.PrintImages.Count;
					if (8 != 0)
					{
						if (expr_D2 <= 0)
						{
							goto IL_11B;
						}
						if (true)
						{
							searchResult.pagename = "Placeback";
							searchResult.Savebackpid = RobotImageLoader.PrintImages[0].PhotoId.ToString();
							goto IL_11B;
						}
						break;
					}
					IL_187:
					if (arg_187_0 == 0)
					{
						goto Block_10;
					}
					List<LstMyItems> list;
					int num;
					while (!false)
					{
						list[num].PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
						if (!false)
						{
							num++;
							goto IL_17A;
						}
					}
					continue;
					IL_17A:
					flag = (num < list.Count);
					arg_187_0 = (flag ? 1 : 0);
					goto IL_187;
					IL_11B:
					list = (from pb in RobotImageLoader.GroupImages
					where pb.PrintGroup.UriSource.ToString() == "/images/print-accept.png"
					select pb).ToList<LstMyItems>();
					num = 0;
					goto IL_17A;
				}
			}
			Block_10:
			searchResult.Show();
			searchResult.flgViewScrl = true;
			searchResult.LoadWindow();
			base.Close();
		}

		public void LoadProductType(object sender)
		{
			this.LoadProductTypeControl(sender);
		}

		private void btnProductType_Click(object sender, RoutedEventArgs e)
		{
        this.LoadProductTypeControl(sender);
		}

		private void LoadProductTypeControl(object sender)
		{
			Button button = (Button)sender;
			bool flag = true;
			bool flag2 = false;
			if (button != null)
			{
				LineItem lineItem;
				if (button.Name == "btnProductType")
				{
					lineItem = (LineItem)this.dgOrder.CurrentItem;
				}
				else if (this.dgOrder.Items.Count - 1 > 0)
				{
					lineItem = (LineItem)this.dgOrder.Items[this.dgOrder.Items.Count - 1];
				}
				else
				{
					lineItem = (LineItem)this.dgOrder.Items[0];
				}
				if (lineItem.ParentID == lineItem.ItemNumber)
				{
					this.CtrlProductType._ProductType = this._productType;
					this.CtrlProductType.ItemNumber = lineItem.ItemNumber.ToString();
					this.CtrlProductType._SelectedProductID = lineItem.SelectedProductType_ID;
					this.CtrlProductType.SetParent(this);
					this.btnNextsimg.IsDefault = false;
					this.CtrlProductType.btnSubmit.IsDefault = true;
					int res = this.CtrlProductType.ShowHandlerDialog("ProductType");
					SelectedImagesQrCode.PackageCode = res;
					this._productType = this.CtrlProductType._ProductType;
					this.CtrlProductType.btnSubmit.IsDefault = false;
					this.btnNextsimg.IsDefault = true;
					bool flag3 = false;
					if (res != 0)
					{
						if (res != -2)
						{
							if (button.Name == "btnProductType")
							{
								button.IsEnabled = false;
							}
						}
					}
					Product product = (from ptype in this._productType
					where ptype.ProductID == res
					select ptype).FirstOrDefault<Product>();
					int num = this.dgOrder.Items.Count - 1;
					if (num < 0)
					{
						num = 0;
					}
					else
					{
						num = this.dgOrder.Items.IndexOf(lineItem);
					}
					DataGridRow dataGridRow = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(num);
					if (product != null)
					{
						List<AssociatedPrintersInfo> associatedPrintersforPrint = new PrinterBusniess().GetAssociatedPrintersforPrint(new int?(product.ProductID), LoginUser.SubStoreId);
						if (associatedPrintersforPrint.Count == 0 && !product.IsPackage)
						{
							MessageBox.Show("No Printer Association exists for that Product.");
							button.IsEnabled = true;
						}
						else
						{
							lineItem.SelectedProductType_ID = product.ProductID;
							lineItem.SelectedProductType_Image = product.ProductIcon.ToString();
							lineItem.SelectedProductType_Text = product.ProductName.ToString();
							lineItem.IsBundled = product.IsBundled;
							lineItem.AllowDiscount = product.DiscountOption;
							if (lineItem.SelectedProductType_ID == 35 || lineItem.SelectedProductType_ID == 36 || lineItem.SelectedProductType_ID == 78 || lineItem.SelectedProductType_ID == 96 || lineItem.SelectedProductType_ID == 97)
							{
								lineItem.TotalMaxSelectedPhotos = 1;
							}
							else
							{
								lineItem.TotalMaxSelectedPhotos = product.MaxQuantity;
							}
							lineItem.IsPackage = product.IsPackage;
							lineItem.IsAccessory = product.IsAccessory;
							lineItem.IsWaterMarked = product.IsWaterMarked;
							lineItem.Quantity = 1;
							if (dataGridRow != null)
							{
								TextBlock textBlock = this.FindByName("txtProductType", dataGridRow) as TextBlock;
								textBlock.Text = lineItem.SelectedProductType_Text;
								Image image = this.FindByName("ProductImage", dataGridRow) as Image;
								image.Source = new BitmapImage(new Uri(lineItem.SelectedProductType_Image.ToString()));
								lineItem.SelectedImages = new List<string>();
								ListBox listBox = this.FindByName("lstPrintImage", dataGridRow) as ListBox;
								listBox.ItemsSource = null;
								TextBlock textBlock2 = this.FindByName("TotalImageSelected", dataGridRow) as TextBlock;
								textBlock2.Text = "Total " + lineItem.SelectedImages.Count + " Items Selected";
								Button button2 = this.FindByName("btndelete", dataGridRow) as Button;
								button2.Tag = "-1";
							}
							this.UpdatePricing(lineItem);
							if (product.IsPackage)
							{
								try
								{
									Button button3 = this.FindByName("btnQtyUp", dataGridRow) as Button;
									button3.IsEnabled = true;
									Button button4 = this.FindByName("btnQtyDown", dataGridRow) as Button;
									button4.IsEnabled = true;
									Button button5 = this.FindByName("btnSelectImage", dataGridRow) as Button;
									button5.Visibility = Visibility.Collapsed;
									Button button2 = this.FindByName("btndelete", dataGridRow) as Button;
									button2.Tag = lineItem.ItemNumber.ToString();
									button2.Visibility = Visibility.Visible;
									TextBlock textBlock3 = this.FindByName("TotalQuantity", dataGridRow) as TextBlock;
									textBlock3.Text = "1";
									string childProductType = new PackageBusniess().GetChildProductType(product.ProductID);
									List<Product> list = new List<Product>();
									List<ProductTypeInfo> productTypeforOrder = new ProductBusiness().GetProductTypeforOrder(0);
									foreach (ProductTypeInfo current in productTypeforOrder)
									{
										list.Add(new Product
										{
											ProductID = current.DG_Orders_ProductType_pkey,
											ProductName = current.DG_Orders_ProductType_Name.ToString(),
											IsBundled = current.DG_Orders_ProductType_IsBundled.Value,
											ProductIcon = current.DG_Orders_ProductType_Image.ToString(),
											DiscountOption = current.DG_Orders_ProductType_DiscountApplied.Value,
											IsPackage = current.DG_IsPackage,
											IsAccessory = current.DG_IsAccessory.Value,
											IsWaterMarked = current.DG_IsWaterMarkIncluded.Value,
											MaxQuantity = current.DG_MaxQuantity,
											IsPrintType = new int?(current.IsPrintType)
										});
									}
									IEnumerable<int> ids = from str in childProductType.Split(new char[]
									{
										','
									})
									select int.Parse(str);
									IEnumerable<Product> enumerable = from rec in list
									where ids.Contains(rec.ProductID)
									select rec;
									string text = string.Empty;
									int num2 = 0;
									foreach (Product current2 in enumerable)
									{
										DataGridRow dataGridRow2 = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(num + 1);
										if (dataGridRow2 != null)
										{
											text = this.AddNewRow(current2, lineItem.ItemNumber.ToString(), false, num + 1);
										}
										else
										{
											text = this.AddNewRow(current2, lineItem.ItemNumber.ToString(), false, num + 1);
										}
										DataGridRow dataGridRow3 = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(this._objLineItem.Count - 1);
										if (dataGridRow3 == null)
										{
											this.dgOrder.UpdateLayout();
											dataGridRow3 = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(this._objLineItem.Count - 1);
										}
										if (dataGridRow3 != null)
										{
											TextBlock textBlock = this.FindByName("txtProductType", dataGridRow3) as TextBlock;
											textBlock.Text = current2.ProductName.ToString();
											Image image = this.FindByName("ProductImage", dataGridRow3) as Image;
											image.Source = new BitmapImage(new Uri(current2.ProductIcon.ToString(), UriKind.Relative));
											if (current2.IsPrintType == 0)
											{
												textBlock = (this.FindByName("TotalQuantity", dataGridRow3) as TextBlock);
												textBlock.Text = "1";
												if (current2.ProductID != 78)
												{
													flag2 = true;
												}
											}
											else if (current2.ProductID == 100)
											{
												textBlock = (this.FindByName("TotalQuantity", dataGridRow3) as TextBlock);
												textBlock.Text = "1";
											}
											else
											{
												textBlock = (this.FindByName("TotalQuantity", dataGridRow3) as TextBlock);
												textBlock.Text = this._objLineItem[this._objLineItem.Count - 1].Quantity.ToString();
											}
											if (current2.IsAccessory)
											{
												Button button6 = this.FindByName("btnSelectImage", dataGridRow3) as Button;
												button6.Visibility = Visibility.Collapsed;
												num2++;
											}
											if (current2.ProductID == 95)
											{
												Button button6 = this.FindByName("btnSelectImage", dataGridRow3) as Button;
												button6.Visibility = Visibility.Collapsed;
												flag3 = true;
											}
											image = (this.FindByName("ProductParent", dataGridRow3) as Image);
											image.Visibility = Visibility.Visible;
											Button button7 = this.FindByName("btndelete", dataGridRow3) as Button;
											button7.Visibility = Visibility.Collapsed;
											if (current2.ProductID == 1091)
											{
												Button button6 = this.FindByName("btnSelectImage", dataGridRow3) as Button;
												Button button8 = this.FindByName("btnAddSemiPrinted", dataGridRow3) as Button;
												button6.Visibility = Visibility.Collapsed;
												button8.Visibility = Visibility.Visible;
											}
											if (current2.ProductID == 84)
											{
												this.isChkSpecOnlinePackage = new ProductBusiness().IsChkSpecOnlinePackage(product.ProductID);
												if (this.isChkSpecOnlinePackage)
												{
													Button button9 = this.FindByName("btnSelectImage", dataGridRow3) as Button;
													Button button10 = this.FindByName("btnAddSemiPrinted", dataGridRow3) as Button;
													button9.Visibility = Visibility.Collapsed;
													button10.Visibility = Visibility.Collapsed;
												}
											}
										}
										num++;
									}
									if (ids.Count<int>() == 1 || ids.Count<int>() == num2 + 1 || (ids.Count<int>() == num2 + 2 && flag3))
									{
										int index = 1;
                                        //List<LineItem> list2 = this._objLineItem.Where(delegate(LineItem o)
                                        //{
                                        //    if (o.ParentID == this._objLineItem.LastOrDefault<LineItem>().ParentID)
                                        //    {
                                        //        goto IL_13;
                                        //    }
                                        //    goto IL_30;
                                        //    int arg_35_0;
                                        //    bool expr_38;
                                        //    do
                                        //    {
                                        //        IL_34:
                                        //        bool flag4 = arg_35_0 != 0;
                                        //        expr_38 = ((arg_35_0 = (flag4 ? 1 : 0)) != 0);
                                        //    }
                                        //    while (2 == 0);
                                        //    return expr_38;
                                        //    IL_13:
                                        //    int arg_1C_0;
                                        //    arg_35_0 = (arg_1C_0 = o.SelectedProductType_ID);
                                        //    if (false)
                                        //    {
                                        //        //goto IL_2E;
                                        //    }
                                        //    int arg_1C_1 = 95;
                                        //    IL_1C:
                                        //    if (arg_1C_0 == arg_1C_1)
                                        //    {
                                        //        goto IL_30;
                                        //    }
                                        //    IL_1E:
                                        //    if (false)
                                        //    {
                                        //        goto IL_13;
                                        //    }
                                        //    int expr_23 = arg_1C_0 = (o.IsAccessory ? 1 : 0);
                                        //    int expr_29 = arg_1C_1 = 0;
                                        //    if (expr_29 != 0)
                                        //    {
                                        //        goto IL_1C;
                                        //    }
                                        //    arg_35_0 = ((expr_23 == expr_29) ? 1 : 0);
                                        //    //IL_2E:
                                        //    //goto IL_34;
                                        //    IL_30:
                                        //    if (4 != 0)
                                        //    {
                                        //        arg_35_0 = 0;
                                        //        //goto IL_34;
                                        //    }
                                        //    goto IL_1E;
                                        //}).ToList<LineItem>();
                                        List<LineItem> list2 = this._objLineItem.ToList();
										LineItem lineItem2 = list2[index];
										int totalMaxSelectedPhotos = list2[index].TotalMaxSelectedPhotos;
										if (list2[index].SelectedProductType_ID == 4 || list2[index].SelectedProductType_ID == 101)
										{
											if (RobotImageLoader.PrintImages.Count == totalMaxSelectedPhotos)
											{
												flag = true;
											}
										}
										else if (RobotImageLoader.PrintImages.Count <= totalMaxSelectedPhotos)
										{
											flag = true;
										}
										if (flag2)
										{
											if (RobotImageLoader.GroupImages.Count > totalMaxSelectedPhotos)
											{
												flag = false;
											}
										}
									}
								}
								catch (Exception var_38_BE5)
								{
								}
								finally
								{
								}
							}
							else if (product.IsAccessory)
							{
								Button button6 = this.FindByName("btnSelectImage", dataGridRow) as Button;
								button6.Visibility = Visibility.Collapsed;
							}
						}
					}
					ProductTypeInfo productTypeListById = new ProductBusiness().GetProductTypeListById(lineItem.SelectedProductType_ID);
					this.CtrlSelectedQrCode.packageInfo.MaxImgQuantity = lineItem.TotalQty;
					this.CtrlSelectedQrCode.packageInfo.PackageCode = ((productTypeListById == null) ? string.Empty : productTypeListById.DG_Orders_ProductCode);
					this.CtrlSelectedQrCode.packageInfo.PackageName = lineItem.SelectedProductType_Text;
					this.CtrlSelectedQrCode.packageInfo.PackagePrice = lineItem.UnitPrice;
				}
				if (flag)
				{
					this.PreFillImageList(flag2);
				}
				else
				{
					foreach (LstMyItems current3 in RobotImageLoader.PrintImages)
					{
						current3.IsItemSelected = false;
					}
				}
			}
		}

		private void PreFillImageList(bool isUSBOrCD)
		{
            LineItem lineItem = null;
            List<string> list2 = null; 
            List<LstMyItems> list3 = null; 
            List<LineItem> list = null;
			bool flag;
			while (true)
			{
				int index = 0;
				if (!true)
				{
					return;
				}
                List<LineItem> source = this._objLineItem.ToList<LineItem>();
                list = source.ToList<LineItem>(); 
                //List<LineItem> source = this._objLineItem.Where(delegate(LineItem o)
                //{
                //    int arg_11_0 = (o.ParentID == this._objLineItem.LastOrDefault<LineItem>().ParentID) ? 1 : 0;
                //    int arg_56_0;
                //    do
                //    {
                //        if (arg_11_0 != 0)
                //        {
                //            int arg_18_0 = o.IsAccessory ? 1 : 0;
                //            do
                //            {
                //                arg_18_0 = (arg_11_0 = (arg_56_0 = ((arg_18_0 == 0) ? 1 : 0)));
                //            }
                //            while (false);
                //        }
                //        else
                //        {
                //            arg_56_0 = (arg_11_0 = 0);
                //        }
                //    }
                //    while (false);
                //    return arg_56_0 != 0;
                //}).ToList<LineItem>();
                // list = source.Where(delegate(LineItem o)
                //{
                //    int arg_3A_0;
                //    if (o.SelectedProductType_ID == 95)
                //    {
                //        arg_3A_0 = 0;
                //        //goto IL_15;
                //    }
                //    int arg_0D_0 = o.IsAccessory ? 1 : 0;
                //    do
                //    {
                //        IL_0C:
                //        arg_3A_0 = (arg_0D_0 = ((arg_0D_0 == 0) ? 1 : 0));
                //    }
                //    while (false);
                //    bool expr_3D;
                //    do
                //    {
                //        IL_15:
                //        bool flag2 = arg_3A_0 != 0;
                //        if (!false)
                //        {
                //        }
                //        expr_3D = ((arg_0D_0 = (arg_3A_0 = (flag2 ? 1 : 0))) != 0);
                //    }
                //    while (8 == 0);
                //    if (!false)
                //    {
                //        return expr_3D;
                //    }
                //    //goto IL_0C;
                //}).ToList<LineItem>();
				lineItem = list.ToArray()[index];
				list2 = new List<string>();
				list3 = new List<LstMyItems>();
				flag = isUSBOrCD;
				while (true)
				{
					if (!flag)
					{
						list3 = RobotImageLoader.PrintImages;
					}
					else
					{
						list3 = RobotImageLoader.GroupImages;
					}
					flag = (lineItem.SelectedProductType_ID != 84);
					if (flag)
					{
						break;
					}
					if (!false)
					{
						goto Block_4;
					}
				}
				flag = (lineItem.SelectedProductType_ID != 96 && lineItem.SelectedProductType_ID != 97);
				if (!false)
				{
					goto Block_7;
				}
			}
			Block_4:
			foreach (LstMyItems current in list3)
			{
				//LstMyItems current;
				list2.Add(current.PhotoId.ToString());
				current.IsItemSelected = true;
			}
			goto IL_2AC;
			Block_7:
			if (!flag)
			{
				//List<LineItem> list;
				int selectedProductType_ID = list[0].SelectedProductType_ID;
				list3 = (from o in RobotImageLoader.GroupImages
				where o.MediaType != 1
				select o).ToList<LstMyItems>();
				list3 = this.LoadProcessedVideos(selectedProductType_ID, list3);
				using (List<LstMyItems>.Enumerator enumerator = list3.GetEnumerator())
				{
					while (true)
					{
						IL_1D2:
						flag = enumerator.MoveNext();
						while (flag)
						{
							LstMyItems current = enumerator.Current;
							while (true)
							{
								flag = (current.MediaType == 1);
								if (!flag)
								{
									if (8 == 0)
									{
										break;
									}
									list2.Add(current.PhotoId.ToString());
									if (6 == 0)
									{
										break;
									}
									current.IsItemSelected = true;
								}
								if (!false)
								{
									goto IL_1D2;
								}
							}
						}
						break;
					}
				}
			}
			else
			{
				list3 = (from x in list3
				where x.MediaType == 1
				select x).ToList<LstMyItems>();
				using (IEnumerator<LstMyItems> enumerator2 = (from x in list3
				where x.MediaType == 1
				select x).GetEnumerator())
				{
					while (true)
					{
						IL_284:
						flag = enumerator2.MoveNext();
						while (flag)
						{
							if (!false)
							{
								LstMyItems current = enumerator2.Current;
								IL_262:
								list2.Add(current.PhotoId.ToString());
								current.IsItemSelected = true;
								goto IL_284;
							}
						}
						if (6 != 0)
						{
							break;
						}
						//goto IL_262;
					}
				}
			}
			IL_2AC:
			lineItem.SelectedImages = list2;
			int itemIndex = lineItem.ItemIndex;
			DataGridRow dataGridRow = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(itemIndex);
			if (dataGridRow != null)
			{
				TextBlock textBlock = this.FindByName("TotalImageSelected", dataGridRow) as TextBlock;
				textBlock.Text = "Total " + lineItem.SelectedImages.Count.ToString() + " Items Selected";
				textBlock = (this.FindByName("TotalQuantity", dataGridRow) as TextBlock);
				int num = textBlock.Text.ToInt32(false);
				ListBox listBox = this.FindByName("lstPrintImage", dataGridRow) as ListBox;
				listBox.ItemsSource = null;
				listBox.ItemsSource = list3;
				this.UpdatePricing(lineItem);
			}
		}

		private List<LstMyItems> LoadProcessedVideos(int PackageId, List<LstMyItems> lst)
		{
			List<LstMyItems> list;
			do
			{
				List<ProcessedVideoInfo> processedVideosByPackageId;
				if (!false)
				{
					List<LstMyItems> expr_D2 = new List<LstMyItems>();
					if (!false)
					{
						list = expr_D2;
					}
					ProcessedVideoBusiness processedVideoBusiness = new ProcessedVideoBusiness();
					processedVideosByPackageId = processedVideoBusiness.GetProcessedVideosByPackageId(PackageId);
				}
				using (List<LstMyItems>.Enumerator enumerator = lst.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						LstMyItems item;
						do
						{
							item = enumerator.Current;
							bool arg_7F_0 = (from o in processedVideosByPackageId
							where o.VideoId == item.PhotoId
							select o).ToList<ProcessedVideoInfo>().Count <= 0;
							while (true)
							{
								bool flag = arg_7F_0;
								while (true)
								{
									bool expr_81 = arg_7F_0 = flag;
									if (false)
									{
										break;
									}
									if (expr_81 || 2 == 0)
									{
										goto IL_A1;
									}
									list.Add(item);
									if (7 != 0)
									{
										goto Block_8;
									}
								}
							}
							Block_8:;
						}
						while (false);
						IL_A1:;
					}
				}
			}
			while (false);
			return list;
		}

		private void btnQtyUp_Click(object sender, RoutedEventArgs e)
		{
			int selectedIndex = this.dgOrder.SelectedIndex;
			DataGridRow dataGridRow = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(selectedIndex);
			if (dataGridRow != null)
			{
				TextBlock textBlock = this.FindByName("TotalQuantity", dataGridRow) as TextBlock;
				int quantity = textBlock.Text.ToInt32(false) + 1;
				textBlock.Text = quantity.ToString();
				LineItem lineItem = (LineItem)this.dgOrder.CurrentItem;
				lineItem.Quantity = quantity;
				ListBox listBox = this.FindByName("lstPrintImage", dataGridRow) as ListBox;
				int num = listBox.Items.Count.ToInt32(false);
				this.UpdatePricing(lineItem);
			}
		}

		private void btnQtyDown_Click(object sender, RoutedEventArgs e)
		{
			int selectedIndex = this.dgOrder.SelectedIndex;
			DataGridRow dataGridRow = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(selectedIndex);
			if (dataGridRow != null)
			{
				TextBlock textBlock = this.FindByName("TotalQuantity", dataGridRow) as TextBlock;
				bool arg_6B_0 = textBlock.Text.ToInt32(false) < 1;
				while (!arg_6B_0)
				{
					int num = textBlock.Text.ToInt32(false) - 1;
					bool flag = num == 0;
					bool expr_8A = arg_6B_0 = flag;
					if (2 != 0)
					{
						if (!expr_8A)
						{
							textBlock.Text = num.ToString();
							LineItem lineItem = (LineItem)this.dgOrder.CurrentItem;
							lineItem.Quantity = num;
							ListBox listBox = this.FindByName("lstPrintImage", dataGridRow) as ListBox;
							int num2 = listBox.Items.Count.ToInt32(false);
							this.UpdatePricing(lineItem);
						}
						else
						{
							textBlock.Text = "1";
						}
						break;
					}
				}
			}
		}

		private void btnSelectImage_Click(object sender, RoutedEventArgs e)
		{
			Button button = (Button)sender;
			bool flag = button == null;
            int prdId = 0;
			while (!flag)
			{
				PlaceOrder PlaceOrder = new PlaceOrder();
				var  current = (LineItem)this.dgOrder.CurrentItem;
				if (current.SelectedProductType_ID > 0 && current.SelectedProductType_ID != 1091)
				{
					List<LstMyItems> list = new List<LstMyItems>();
					LineItem lineItem = this._objLineItem.Where(delegate(LineItem l)
					{
						if (-1 == 0)
						{
							goto IL_21;
						}
						int arg_51_0;
						if (l.ItemNumber ==current.ParentID)
						{
							if (false)
							{
								goto IL_23;
							}
							arg_51_0 = (l.IsPackage ? 1 : 0);
						}
						else
						{
							arg_51_0 = 0;
						}
						IL_1E:
						IL_1F:
						bool flag4 = arg_51_0 != 0;
						IL_21:
						IL_23:
						bool expr_54 = (arg_51_0 = (flag4 ? 1 : 0)) != 0;
						if (false)
						{
							goto IL_1F;
						}
						if (true)
						{
							return expr_54;
						}
						goto IL_1E;
					}).FirstOrDefault<LineItem>();
					if (current.SelectedProductType_ID == 96 || current.SelectedProductType_ID == 97)
					{
						this.CtrlSelectedProcessedVideoslist.SetParent(this);
						this.CtrlSelectedProcessedVideoslist.PreviousImage = current.SelectedImages;
						this.CtrlSelectedProcessedVideoslist.ProductTypeID = current.SelectedProductType_ID;
						this.CtrlSelectedProcessedVideoslist.PackageId = lineItem.SelectedProductType_ID;
						this.CtrlSelectedProcessedVideoslist.maxSelectedPhotos = current.TotalMaxSelectedPhotos;
						this.CtrlSelectedProcessedVideoslist.IsBundled = current.IsBundled;
						if (current.ParentID == current.ItemNumber)
						{
							this.CtrlSelectedProcessedVideoslist.IsPackage = false;
						}
						else
						{
							this.CtrlSelectedProcessedVideoslist.IsPackage = true;
						}
						list = this.CtrlSelectedProcessedVideoslist.ShowHandlerDialog("Select Processed Video");
						this.btnNextsimg.IsDefault = true;
						this.CtrlSelectedProcessedVideoslist.btnSubmit.IsDefault = false;
					}
					else
					{
						if (current.SelectedProductType_ID == 79)
						{
							this.CtrlSelectedAlbumlist.SetParentAlbum(this);
							this.CtrlSelectedAlbumlist.PrintOrderPageList =current.PrintOrderPageList;
							this.CtrlSelectedAlbumlist.ProductTypeID =current.SelectedProductType_ID;
							this.CtrlSelectedAlbumlist.maxSelectedPhotos =current.TotalMaxSelectedPhotos;
							this.CtrlSelectedAlbumlist.IsBundled =current.IsBundled;
							if (current.ParentID ==current.ItemNumber)
							{
								this.CtrlSelectedAlbumlist.IsPackage = false;
							}
							else
							{
								this.CtrlSelectedAlbumlist.IsPackage = true;
							}
							IL_2B8:
							this.btnNextsimg.IsDefault = false;
							this.CtrlSelectedAlbumlist.btnSubmit.IsDefault = true;
							list = this.CtrlSelectedAlbumlist.ShowAlbumHandlerDialog("SelectImage");
							this.btnNextsimg.IsDefault = true;
							this.CtrlSelectedAlbumlist.btnSubmit.IsDefault = false;
							current.PrintOrderPageList = this.CtrlSelectedAlbumlist.PrintOrderPageList;
							current.GroupItems = list;
							if (8 != 0)
							{
								goto IL_8BD;
							}
							goto IL_2B8;
						}
						if (current.SelectedProductType_ID == 84 || current.SelectedProductType_ID == 85)
						{
							this.CtrlSelectedQrCode.SetParentQrCode(this);
							this.CtrlSelectedQrCode.PreviousImage = current.SelectedImages;
							this.CtrlSelectedQrCode.ProductTypeID = current.SelectedProductType_ID;
							this.CtrlSelectedQrCode.maxSelectedPhotos = current.TotalMaxSelectedPhotos;
							this.CtrlSelectedQrCode.QRCode = current.UniqueCode;
							this.CtrlSelectedQrCode.IsBundled = current.IsBundled;
							this.CtrlSelectedQrCode.lstQrCode.Clear();
							foreach (string current1 in (from o in this._objLineItem
							select o.UniqueCode).ToList<string>())
							{
								this.CtrlSelectedQrCode.lstQrCode.Add(current1);
							}
							if (current.ParentID == current.ItemNumber)
							{
								if (false)
								{
									goto IL_86C;
								}
								this.CtrlSelectedQrCode.IsPackage = false;
							}
							else
							{
								this.CtrlSelectedQrCode.IsPackage = true;
							}
							this.CtrlSelectedQrCode._lstSelectedImage = new List<LstMyItems>();
							foreach (LstMyItems current2 in current.GroupItems)
							{
								LstMyItems item = new LstMyItems();
								item = current2;
								this.CtrlSelectedQrCode._lstSelectedImage.Add(item);
							}
							list = this.CtrlSelectedQrCode.ShowQrCodeHandlerDialog("SelectImage");
							if (this.CtrlSelectedQrCode.lstQrCode.Where(delegate(string o)
							{
								if (false)
								{
									goto IL_1C;
								}
								int arg_12_0 = string.Compare(o,current.UniqueCode, true);
								bool expr_12;
								do
								{
									IL_11:
									expr_12 = ((arg_12_0 = ((arg_12_0 == 0) ? 1 : 0)) != 0);
								}
								while (7 == 0 || 8 == 0);
								bool flag4 = expr_12;
								IL_1C:
								bool expr_3B = (arg_12_0 = (flag4 ? 1 : 0)) != 0;
								if (!false)
								{
									return expr_3B;
								}
								//goto IL_11;
							}).Count<string>() > 0)
							{
								this.CtrlSelectedQrCode.lstQrCode.RemoveAll(delegate(string o)
								{
									if (false)
									{
										goto IL_1C;
									}
									int arg_12_0 = string.Compare(o,current.UniqueCode, true);
									bool expr_12;
									do
									{
										IL_11:
										expr_12 = ((arg_12_0 = ((arg_12_0 == 0) ? 1 : 0)) != 0);
									}
									while (7 == 0 || 8 == 0);
									bool flag4 = expr_12;
									IL_1C:
									bool expr_3B = (arg_12_0 = (flag4 ? 1 : 0)) != 0;
									if (!false)
									{
										return expr_3B;
									}
									//goto IL_11;
								});
							}
							this.CtrlSelectedQrCode.lstQrCode.Add(this.CtrlSelectedQrCode.QRCode);
							current.UniqueCode = this.CtrlSelectedQrCode.QRCode;
							current.CodeType = ((current.SelectedProductType_ID == 84) ? 401 : ((current.SelectedProductType_ID == 85) ? 402 : 0));
							goto IL_8BD;
						}
						if (current.SelectedProductType_ID == 100)
						{
							if (RobotImageLoader.PrintImages != null && RobotImageLoader.PrintImages.Count <= 0)
							{
								MessageBox.Show("Please Select Images while Placing order");
								break;
							}
							this.CtrlSelectedCalenderList.SetParentAlbum(this);
							this.CtrlSelectedCalenderList.PrintOrderPageList =current.PrintOrderPageList;
							this.CtrlSelectedCalenderList.ProductTypeID =current.SelectedProductType_ID;
							this.CtrlSelectedCalenderList.maxSelectedPhotos =current.TotalMaxSelectedPhotos;
							this.CtrlSelectedCalenderList.IsBundled =current.IsBundled;
							if (current.ParentID ==current.ItemNumber)
							{
								this.CtrlSelectedCalenderList.IsPackage = false;
							}
							else
							{
								this.CtrlSelectedCalenderList.IsPackage = true;
							}
							this.btnNextsimg.IsDefault = false;
							this.CtrlSelectedCalenderList.btnSubmit.IsDefault = true;
							list = this.CtrlSelectedCalenderList.ShowAlbumHandlerDialog("SelectImage");
							goto IL_8BD;
						}
						else
						{
							this.CtrlSelectedImageslist.SetParent(this);
							this.CtrlSelectedImageslist.PreviousImage =current.SelectedImages;
							this.CtrlSelectedImageslist.ProductTypeID =current.SelectedProductType_ID;
							this.CtrlSelectedImageslist.maxSelectedPhotos =current.TotalMaxSelectedPhotos;
							this.CtrlSelectedImageslist._lstSelectedImage = new List<LstMyItems>();
							foreach (LstMyItems current2 in current.GroupItems)
							{
								LstMyItems item = new LstMyItems();
								item = current2;
								this.CtrlSelectedImageslist._lstSelectedImage.Add(item);
							}
							this.CtrlSelectedImageslist.IsBundled =current.IsBundled;
							if (current.ParentID ==current.ItemNumber)
							{
								this.CtrlSelectedImageslist.IsPackage = false;
							}
							else
							{
								this.CtrlSelectedImageslist.IsPackage = true;
							}
						}
						IL_86D:
						this.btnNextsimg.IsDefault = false;
						this.CtrlSelectedImageslist.btnSubmit.IsDefault = true;
						list = this.CtrlSelectedImageslist.ShowHandlerDialog("SelectImage");
						this.btnNextsimg.IsDefault = true;
						this.CtrlSelectedImageslist.btnSubmit.IsDefault = false;
						goto IL_8BD;
						IL_86C:
						goto IL_86D;
					}
					IL_8BD:
					List<LstMyItems> list2 = list;
					if (list2 != null)
					{
						List<string> list3 = new List<string>();
						foreach (LstMyItems current3 in list2)
						{
							list3.Add(current3.PhotoId.ToString());
						}
						current.SelectedImages = list3;
						int selectedIndex = this.dgOrder.SelectedIndex;
						DataGridRow dataGridRow = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(selectedIndex);
						if (dataGridRow != null)
						{
							TextBlock textBlock = this.FindByName("TotalImageSelected", dataGridRow) as TextBlock;
							textBlock.Text = "Total " + list2.Count.ToString() + " Items Selected";
							textBlock = (this.FindByName("TotalQuantity", dataGridRow) as TextBlock);
							int num = textBlock.Text.ToInt32(false);
							ListBox listBox = this.FindByName("lstPrintImage", dataGridRow) as ListBox;
							listBox.ItemsSource = list2;
							this.UpdatePricing(current);
						}
						if (current.ItemNumber != current.ParentID)
						{
							LineItem parentLineItem1 = (from l in this._objLineItem
							where l.ItemNumber ==current.ParentID
							select l).FirstOrDefault<LineItem>();
							IEnumerable<LineItem> source = this._objLineItem.Where(delegate(LineItem result)
							{
								if (!(result.ParentID == parentLineItem1.ItemNumber))
								{
									goto IL_29;
								}
								int arg_2E_0;
								bool expr_57 = (arg_2E_0 = (result.IsPackage ? 1 : 0)) != 0;
								if (!false)
								{
									if (!false)
									{
										if (!expr_57)
										{
											goto IL_1D;
										}
										goto IL_29;
									}
								}
								bool expr_34;
								do
								{
									IL_2D:
									bool flag4 = arg_2E_0 != 0;
									if (-1 == 0)
									{
										goto IL_1D;
									}
									expr_34 = ((arg_2E_0 = (flag4 ? 1 : 0)) != 0);
								}
								while (2 == 0);
								return expr_34;
								IL_1D:
								arg_2E_0 = ((result.SelectedImages != null) ? 1 : 0);
								//goto IL_2D;
								IL_29:
								if (4 != 0)
								{
									arg_2E_0 = 0;
									//goto IL_2D;
								}
								goto IL_1D;
							});
							List<LineItem> list4 = (from p in source
							where p.SelectedImages.Count > p.TotalMaxSelectedPhotos
							select p).ToList<LineItem>();
							flag = (list4.Count <= 0);
							if (!flag)
							{
								int num2 = 0;
								foreach (LineItem current4 in list4)
								{
									int num3 = current4.SelectedImages.Count / current4.TotalMaxSelectedPhotos + ((current4.SelectedImages.Count % current4.TotalMaxSelectedPhotos > 0) ? 1 : 0);
									if (num3 > num2)
									{
										num2 = num3;
									}
								}
								int index = this.dgOrder.Items.IndexOf(parentLineItem1);
								DataGridRow dataGridRow2 = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(index);
								if (dataGridRow2 != null)
								{
									Button button2 = this.FindByName("btnQtyUp", dataGridRow2) as Button;
									button2.IsEnabled = false;
									Button button3 = this.FindByName("btnQtyDown", dataGridRow2) as Button;
									button3.IsEnabled = false;
									TextBlock textBlock2 = this.FindByName("TotalQuantity", dataGridRow2) as TextBlock;
									textBlock2.Text = num2.ToString();
									parentLineItem1.Quantity = num2;
								}
							}
							else
							{
								int index = this.dgOrder.Items.IndexOf(parentLineItem1);
								DataGridRow dataGridRow2 = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(index);
								if (false)
								{
									continue;
								}
								if (dataGridRow2 != null)
								{
									Button button2 = this.FindByName("btnQtyUp", dataGridRow2) as Button;
									button2.IsEnabled = true;
									Button button3 = this.FindByName("btnQtyDown", dataGridRow2) as Button;
									button3.IsEnabled = true;
									TextBlock textBlock2 = this.FindByName("TotalQuantity", dataGridRow2) as TextBlock;
									textBlock2.Text = "1";
									parentLineItem1.Quantity = 1;
								}
							}
							this.UpdatePricing(parentLineItem1);
						}
					}
				}
				else if (current.SelectedProductType_ID == 1091)
				{
					if (LoginUser.IsSemiOrder == true && LoginUser.ListSemiOrderSettingsSubStoreWise.Count > 0)
					{
						string text = "";
						string value = "";
						bool flag2 = false;
						bool flag3 = true;
                        PhotoInfo semiimg = null;
						if (button != null)
						{
							//PlaceOrder res = new PlaceOrder();
							
							this.CtrlImportSpecProductImages.SetParent(this);
							this.CtrlImportSpecProductImages.txtRFID.Focus();
							this.btnNextsimg.IsDefault = false;
							this.CtrlImportSpecProductImages.btnSearch.IsDefault = true;
						    var	res = this.CtrlImportSpecProductImages.ShowSpecImagesDialog("ImportSpecImages");
							this.btnNextsimg.IsDefault = true;
							this.CtrlImportSpecProductImages.btnSearch.IsDefault = false;
							if (res != null && res.Count > 0)
							{
								if (this._objLineItem.Count > 0)
								{
									int num4 = this._objLineItem[0].SelectedProductType_ID.ToInt32(false);
									if (num4 == 0)
									{
										this._objLineItem.RemoveAt(0);
									}
								}
								this._issemiorder = true;
								SemiOrderSettings semiOrderSettings = LoginUser.ListSemiOrderSettingsSubStoreWise.Where(delegate(SemiOrderSettings t)
								{
									bool result;
									while (true)
									{
										IL_00:
										int? dG_LocationId = t.PS_LocationId;
										int? dG_Location_Id;
										if (!false)
										{
											dG_Location_Id = res[0].DG_Location_Id;
										}
										while (dG_LocationId.GetValueOrDefault() == dG_Location_Id.GetValueOrDefault())
										{
											if (!false)
											{
												bool arg_3E_0 = dG_LocationId.HasValue == dG_Location_Id.HasValue;
												if (true)
												{
													IL_3D:;
												}
												result = arg_3E_0;
												if (2 != 0)
												{
													return result;
												}
												goto IL_00;
											}
										}
										if (!false)
										{
											bool arg_3E_0 = false;
											//goto IL_3D;
										}
									}
									return result;
								}).FirstOrDefault<SemiOrderSettings>();
								if (semiOrderSettings != null)
								{
									List<string> list5 = new List<string>();
                                    foreach (PhotoInfo current5 in res)
									{
										list5.Add(current5.DG_Photos_pkey.ToString());
									}
									if (current.TotalMaxSelectedPhotos == res.Count)
									{
										List<LstMyItems> list6 = new List<LstMyItems>();
										using (List<PhotoInfo>.Enumerator enumerator4 = res.GetEnumerator())
										{
											while (true)
											{
												bool arg_F95_0;
												bool expr_15E1 = arg_F95_0 = enumerator4.MoveNext();
												//PlaceOrder.4 ;
												if (!false)
												{
													if (!expr_15E1)
													{
														break;
													}
													
													 semiimg = enumerator4.Current;

                                                    semiOrderSettings = LoginUser.ListSemiOrderSettingsSubStoreWise.Where(p=>p.PS_LocationId==semiimg.DG_Location_Id).FirstOrDefault();
													
                                                    //semiOrderSettings = LoginUser.ListSemiOrderSettingsSubStoreWise.Where(delegate(SemiOrderSettings t)
                                                    //{////
                                                    //    int? dG_LocationId = t.DG_LocationId;
                                                    //    int? dG_Location_Id = semiimg.DG_Location_Id;
                                                    //    int arg_63_0;
                                                    //    int arg_41_0;
                                                    //    int arg_41_1;
                                                    //    int arg_63_1;
                                                    //    //while (dG_LocationId.GetValueOrDefault() != dG_Location_Id.GetValueOrDefault())
                                                    //    //{
                                                    //    //    if (!false)
                                                    //    //    {
                                                    //    //        bool arg_4D_0 = (arg_41_0 = (arg_63_0 = 0)) != 0;
                                                    //    //        IL_49:
                                                    //    //        int arg_6C_0;
                                                    //    //        //if (!false)
                                                    //    //        //{
                                                    //    //        //    if (!arg_4D_0)
                                                    //    //        //    {
                                                    //    //        //        arg_6C_0 = 0;
                                                    //    //        //        return arg_6C_0 != 0;
                                                    //    //        //    }
                                                    //    //        //    arg_63_0 = (arg_41_0 = t.DG_SemiOrder_Settings_Pkey);
                                                    //    //        //}
                                                    //    //        arg_63_1 = (arg_41_1 = semiimg.SemiOrderProfileId);
                                                    //    //        //IL_60:
                                                    //    //        //if (!false)
                                                    //    //        //{
                                                    //    //        //    arg_4D_0 = ((arg_41_0 = (arg_63_0 = (arg_6C_0 = ((arg_63_0 == arg_63_1) ? 1 : 0)))) != 0);
																	
                                                    //    //        //}
                                                    //    //        //else
                                                    //    //        //{
                                                    //    //        //    IL_3E:
                                                    //    //        //    if (7 != 0)
                                                    //    //        //    {
                                                    //    //        //        arg_4D_0 = ((arg_41_0 = (arg_63_0 = ((arg_41_0 == arg_41_1) ? 1 : 0))) != 0);
                                                    //    //        //        goto IL_49;
                                                    //    //        //    }
                                                    //    //        //    goto IL_60;
                                                    //    //        //}
                                                    //    //        return arg_6C_0 != 0;
                                                    //    //    }
                                                    //    //}
                                                    //    arg_63_0 = (arg_41_0 = (dG_LocationId.HasValue ? 1 : 0));
                                                    //    arg_63_1 = (arg_41_1 = (dG_Location_Id.HasValue ? 1 : 0));
														
                                                    //}).FirstOrDefault<SemiOrderSettings>();///////////////
													 prdId = 0;
													arg_F95_0 = semiOrderSettings.PS_SemiOrder_ProductTypeId.Contains(',');
												}
                                                //int prdId = 0;
												if (arg_F95_0)
												{
													prdId = 1;
												}
												else
												{
                                                    prdId = Convert.ToInt32(semiOrderSettings.PS_SemiOrder_ProductTypeId);
												}
												ProductTypeInfo productTypeInfo = (from f in new ProductBusiness().GetProductType()
												where f.DG_Orders_ProductType_pkey == prdId
												select f).FirstOrDefault<ProductTypeInfo>();
                                                OrderDetailInfo semiOrderImage = new PhotoSW.IMIX.Business.OrderBusiness().GetSemiOrderImage(semiimg.DG_Photos_pkey.ToString());
												if (semiimg.DG_Photos_pkey == 0)
												{
													flag3 = false;
												}
												bool arg_1087_0;
												bool expr_103B = arg_1087_0 = !new OrderBusiness().GetSemiOrderImageforValidation(semiimg.DG_Photos_pkey.ToString());
												VideoProcessingClass videoProcessingClass;
												if (!false)
												{
													if (!expr_103B)
													{
														flag2 = true;
													}
													if (flag2)
													{
														value = semiimg.DG_Photos_RFID + ",";
													}
													LstMyItems lstMyItems = new LstMyItems();
													videoProcessingClass = new VideoProcessingClass();
													flag = (semiOrderImage == null);
													arg_1087_0 = flag;
												}
												if (!arg_1087_0)
												{
													int photoId = semiimg.DG_Photos_pkey;
													LstMyItems lstMyItems = (from result in RobotImageLoader.robotImages
													where result.PhotoId == photoId
													select result).FirstOrDefault<LstMyItems>();
													if (lstMyItems == null)
													{
														PhotoInfo photoDetailsbyPhotoId = new PhotoBusiness().GetPhotoDetailsbyPhotoId(photoId);
														lstMyItems = new LstMyItems();
														lstMyItems.OnlineQRCode = photoDetailsbyPhotoId.OnlineQRCode;
														lstMyItems.Name = photoDetailsbyPhotoId.DG_Photos_RFID;
														lstMyItems.PhotoId = photoDetailsbyPhotoId.DG_Photos_pkey;
														lstMyItems.FileName = photoDetailsbyPhotoId.DG_Photos_RFID;
														lstMyItems.HotFolderPath = photoDetailsbyPhotoId.HotFolderPath;
														lstMyItems.MediaType = photoDetailsbyPhotoId.DG_MediaType;
														lstMyItems.VideoLength = photoDetailsbyPhotoId.DG_VideoLength;
														lstMyItems.CreatedOn = photoDetailsbyPhotoId.DG_Photos_CreatedOn;
														lstMyItems.OnlineQRCode = photoDetailsbyPhotoId.OnlineQRCode;
														lstMyItems.IsPassKeyVisible = Visibility.Collapsed;
														string path = photoDetailsbyPhotoId.DG_Photos_FileName.Replace(videoProcessingClass.SupportedVideoFormats["avi"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mp4"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["wmv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mov"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["3gp"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["3g2"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["m2v"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["m4v"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["flv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mpeg"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mkv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mts"].ToString(), ".jpg");
														lstMyItems.BigThumbnailPath = Path.Combine(lstMyItems.BigDBThumnailPath, photoDetailsbyPhotoId.DG_Photos_CreatedOn.ToString("yyyyMMdd"), path);
														lstMyItems.FilePath = Path.Combine(lstMyItems.ThumnailPath, photoDetailsbyPhotoId.DG_Photos_CreatedOn.ToString("yyyyMMdd"), path);
														lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
														lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
														RobotImageLoader.GroupImages.Add(lstMyItems);
													}
													list6.Add(lstMyItems);
													LstMyItems lstMyItems2 = new LstMyItems();
													current.SelectedProductType_ID = semiOrderImage.DG_Orders_Details_ProductType_pkey.ToInt32(false);
													if (productTypeInfo != null)
													{
														int selectedIndex2 = this.dgOrder.SelectedIndex;
														DataGridRow dataGridRow2 = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(selectedIndex2);
														if (dataGridRow2 != null)
														{
															TextBlock textBlock = this.FindByName("txtProductType", dataGridRow2) as TextBlock;
															textBlock.Text =current.SelectedProductType_Text;
															Image image = this.FindByName("ProductImage", dataGridRow2) as Image;
															image.Source = new BitmapImage(new Uri(current.SelectedProductType_Image.ToString(), UriKind.Relative));
															ListBox listBox2 = this.FindByName("lstPrintImage", dataGridRow2) as ListBox;
															current.SelectedImages = list5;
															current.IssemiOrder = true;
															listBox2.ItemsSource = null;
															listBox2.ItemsSource = list6;
															TextBlock textBlock3 = this.FindByName("TotalImageSelected", dataGridRow2) as TextBlock;
															textBlock3.Text = "Total " +current.SelectedImages.Count + " Images Selected";
															Button button4 = this.FindByName("btndelete", dataGridRow2) as Button;
															button4.Tag = "-1";
															Button button5 = this.FindByName("btnSelectImage", dataGridRow2) as Button;
															button5.Visibility = Visibility.Collapsed;
															Button button6 = this.FindByName("btnAddSemiPrinted", dataGridRow2) as Button;
															button6.Visibility = Visibility.Collapsed;
														}
														this.UpdatePricing(current);
													}
													if (this.isChkSpecOnlinePackage)
													{
														if (lstMyItems != null && !string.IsNullOrEmpty(lstMyItems.OnlineQRCode))
														{
															this.PreFillOnlieSpec(list6, lstMyItems.OnlineQRCode);
														}
													}
												}
												else
												{
													text = semiimg.DG_Photos_RFID + ",";
												}
											}
										}
									}
									else
									{
										MessageBox.Show("Please confirm the quantity from Package");
									}
								}
							}
							else
							{
								MessageBox.Show("Sorry No Images found.", "Spectra Photo");
							}
							if (!flag3)
							{
								MessageBox.Show("Image not found.Please check the image number", "Spectra Photo");
							}
							else if (!string.IsNullOrEmpty(value))
							{
								MessageBox.Show("You have already placed an order for the images (" + text.Trim(new char[]
								{
									','
								}) + ")");
							}
							else if (!string.IsNullOrEmpty(text))
							{
								MessageBox.Show("Image is not edited yet.");
							}
						}
					}
					else
					{
						MessageBox.Show("Spec print is not active on this substore", "Spectra Photo");
					}
				}
				else
				{
					MessageBox.Show("Please Select Product Type first.", "Spectra Photo");
				}
				break;
			}
		}

		private void PreFillOnlieSpec(List<LstMyItems> selectList, string OnlineQRCode)
		{
			int index = 1;
			List<LineItem> list = this._objLineItem.Where(delegate(LineItem o)
			{
				int arg_11_0 = (o.ParentID == this._objLineItem.LastOrDefault<LineItem>().ParentID) ? 1 : 0;
				int arg_56_0;
				do
				{
					if (arg_11_0 != 0)
					{
						int arg_18_0 = o.IsAccessory ? 1 : 0;
						do
						{
							arg_18_0 = (arg_11_0 = (arg_56_0 = ((arg_18_0 == 0) ? 1 : 0)));
						}
						while (false);
					}
					else
					{
						arg_56_0 = (arg_11_0 = 0);
					}
				}
				while (false);
				return arg_56_0 != 0;
			}).ToList<LineItem>();
			this._objLineItem.Where(delegate(LineItem o)
			{
				int arg_06_0 = o.SelectedProductType_ID;
				bool expr_3D;
				while (true)
				{
					int arg_3A_0;
					if (arg_06_0 == 84)
					{
						arg_3A_0 = (arg_06_0 = ((o.UniqueCode == null) ? 1 : 0));
						//goto IL_0F;
					}
					arg_3A_0 = 0;
					do
					{
						IL_15:
						bool flag = arg_3A_0 != 0;
						if (!false)
						{
						}
						expr_3D = ((arg_06_0 = (arg_3A_0 = (flag ? 1 : 0))) != 0);
					}
					while (8 == 0);
					if (!false)
					{
						break;
					}
                    //IL_0F:
                    //if (!false)
                    //{
                    //    goto IL_15;
                    //}
				}
				return expr_3D;
			}).FirstOrDefault<LineItem>().UniqueCode = OnlineQRCode;
			this._objLineItem.Where(delegate(LineItem o)
			{
				int arg_3A_0;
				if (o.SelectedProductType_ID != 84)
				{
					arg_3A_0 = 0;
					//goto IL_15;
				}
				int arg_0D_0 = o.CodeType;
				do
				{
					IL_0C:
					arg_3A_0 = (arg_0D_0 = ((arg_0D_0 == 0) ? 1 : 0));
				}
				while (false);
				bool expr_3D;
				do
				{
					IL_15:
					bool flag = arg_3A_0 != 0;
					if (!false)
					{
					}
					expr_3D = ((arg_0D_0 = (arg_3A_0 = (flag ? 1 : 0))) != 0);
				}
				while (8 == 0);
				if (!false)
				{
					return expr_3D;
				}
				//goto IL_0C;
			}).FirstOrDefault<LineItem>().CodeType = 401;
			List<LineItem> list2 = (from o in list
			where o.SelectedProductType_ID == 84
			select o).ToList<LineItem>();
			LineItem lineItem = list[index];
			List<string> list3 = new List<string>();
			if (lineItem.SelectedProductType_ID == 84)
			{
				if (5 == 0)
				{
					goto IL_1C6;
				}
				foreach (LstMyItems current in selectList)
				{
					list3.Add(current.PhotoId.ToString());
					current.IsItemSelected = true;
				}
			}
			lineItem.SelectedImages = list3;
			int itemIndex = lineItem.ItemIndex;
			DataGridRow dataGridRow = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(itemIndex);
			if (dataGridRow == null)
			{
				return;
			}
			TextBlock textBlock = this.FindByName("TotalImageSelected", dataGridRow) as TextBlock;
			textBlock.Text = "Total " + lineItem.SelectedImages.Count.ToString() + " Items Selected";
			IL_1C6:
			textBlock = (this.FindByName("TotalQuantity", dataGridRow) as TextBlock);
			int num = textBlock.Text.ToInt32(false);
			ListBox listBox = this.FindByName("lstPrintImage", dataGridRow) as ListBox;
			listBox.ItemsSource = null;
			listBox.ItemsSource = selectList;
			this.UpdatePricing(lineItem);
		}

		private void BindMyListItems(LineItem current, List<LstMyItems> res)
		{
			bool flag = res == null;
			bool arg_32_0 = flag;
			while (!arg_32_0)
			{
				List<string> list = new List<string>();
				foreach (LstMyItems current2 in res)
				{
					list.Add(current2.PhotoId.ToString());
				}
				current.SelectedImages = list;
				int index = this.dgOrder.SelectedIndex;
				DataGridRow dataGridRow = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(index);
				if (dataGridRow != null)
				{
					TextBlock textBlock = this.FindByName("TotalImageSelected", dataGridRow) as TextBlock;
					textBlock.Text = "Total " + res.Count.ToString() + " Images Selected";
					textBlock = (this.FindByName("TotalQuantity", dataGridRow) as TextBlock);
					int num = textBlock.Text.ToInt32(false);
					ListBox listBox = this.FindByName("lstPrintImage", dataGridRow) as ListBox;
					listBox.ItemsSource = res;
					LineItem lineItem = this._objLineItem.Where(delegate(LineItem o)
					{
						bool result;
						if (2 != 0)
						{
							int arg_23_0;
							int arg_16_0;
							bool expr_33 = (arg_16_0 = (arg_23_0 = (o.IsAccessory ? 1 : 0))) != 0;
							if (!false)
							{
								if (expr_33)
								{
									goto IL_27;
								}
								if (4 == 0)
								{
									return result;
								}
								arg_23_0 = (arg_16_0 = (o.IsPackage ? 1 : 0));
							}
							if (4 != 0)
							{
								if (arg_16_0 != 0)
								{
									goto IL_27;
								}
								arg_23_0 = o.ItemIndex;
							}
							bool arg_51_0 = arg_23_0 == index;
							goto IL_28;
							IL_27:
							arg_51_0 = false;
							IL_28:
							result = arg_51_0;
						}
						return result;
					}).FirstOrDefault<LineItem>();
					lineItem.SelectedImages = list;
					this.UpdatePricing(current);
				}
				bool expr_1B5 = arg_32_0 = (current.ItemNumber != current.ParentID);
				if (8 != 0)
				{
					if (expr_1B5)
					{
						LineItem parentLineItem = (from l in this._objLineItem
						where l.ItemNumber == current.ParentID
						select l).FirstOrDefault<LineItem>();
						IEnumerable<LineItem> source = this._objLineItem.Where(delegate(LineItem result)
						{
							if (!(result.ParentID == parentLineItem.ItemNumber))
							{
								goto IL_29;
							}
							int arg_2E_0;
							bool expr_57 = (arg_2E_0 = (result.IsPackage ? 1 : 0)) != 0;
							if (!false)
							{
								if (!false)
								{
									if (!expr_57)
									{
										goto IL_1D;
									}
									goto IL_29;
								}
							}
							bool expr_34;
							do
							{
								IL_2D:
								bool flag2 = arg_2E_0 != 0;
								if (-1 == 0)
								{
									goto IL_1D;
								}
								expr_34 = ((arg_2E_0 = (flag2 ? 1 : 0)) != 0);
							}
							while (2 == 0);
							return expr_34;
							IL_1D:
							arg_2E_0 = ((result.SelectedImages != null) ? 1 : 0);
							//goto IL_2D;
							IL_29:
							if (4 != 0)
							{
								arg_2E_0 = 0;
								//goto IL_2D;
							}
							goto IL_1D;
						});
						List<LineItem> list2 = (from p in source
						where p.SelectedImages.Count > p.TotalMaxSelectedPhotos
						select p).ToList<LineItem>();
						if (list2.Count > 0)
						{
							int num2 = 0;
							foreach (LineItem current3 in list2)
							{
								int num3 = current3.SelectedImages.Count / current3.TotalMaxSelectedPhotos + ((current3.SelectedImages.Count % current3.TotalMaxSelectedPhotos > 0) ? 1 : 0);
								if (num3 > num2)
								{
									num2 = num3;
								}
							}
							int index2 = this.dgOrder.Items.IndexOf(parentLineItem);
							DataGridRow dataGridRow2 = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(index2);
							if (dataGridRow2 != null)
							{
								Button button = this.FindByName("btnQtyUp", dataGridRow2) as Button;
								button.IsEnabled = false;
								Button button2 = this.FindByName("btnQtyDown", dataGridRow2) as Button;
								button2.IsEnabled = false;
								TextBlock textBlock2 = this.FindByName("TotalQuantity", dataGridRow2) as TextBlock;
								textBlock2.Text = num2.ToString();
								parentLineItem.Quantity = num2;
							}
						}
						else
						{
							int index2 = this.dgOrder.Items.IndexOf(parentLineItem);
							DataGridRow dataGridRow2 = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(index2);
							if (dataGridRow2 != null)
							{
								Button button = this.FindByName("btnQtyUp", dataGridRow2) as Button;
								button.IsEnabled = true;
								Button button2 = this.FindByName("btnQtyDown", dataGridRow2) as Button;
								button2.IsEnabled = true;
								TextBlock textBlock2 = this.FindByName("TotalQuantity", dataGridRow2) as TextBlock;
								textBlock2.Text = "1";
								parentLineItem.Quantity = 1;
							}
						}
						this.UpdatePricing(parentLineItem);
					}
					break;
				}
			}
		}

		private void btnAddSemiPrinted_Click(object sender, RoutedEventArgs e)
		{
			Button button = (Button)sender;
			string text = string.Empty;
            int prdId = 0;
			if (button != null)
			{
				bool? flag = LoginUser.IsSemiOrder;
				int arg_66_0 = (!(flag == true) || LoginUser.ListSemiOrderSettingsSubStoreWise.Count <= 0) ? 1 : 0;
				while (arg_66_0 == 0)
				{
					//PlaceOrder res = new PlaceOrder();
					this.CtrlImportSpecProductImages.SetParent(this);
					this.CtrlImportSpecProductImages.txtRFID.Focus();
					var res = this.CtrlImportSpecProductImages.ShowSpecImagesDialog("ImportSpecImages");
					if (res != null && res.Count > 0)
					{
						if (this._objLineItem.Count > 0)
						{
							int num = this._objLineItem[0].SelectedProductType_ID.ToInt32(false);
							int expr_10D = arg_66_0 = num;
							if (!true)
							{
								continue;
							}
							if (expr_10D == 0)
							{
								this._objLineItem.RemoveAt(0);
							}
						}
						this._issemiorder = true;
						SemiOrderSettings semiOrderSettings = LoginUser.ListSemiOrderSettingsSubStoreWise.Where(delegate(SemiOrderSettings t)
						{
							bool result;
							while (true)
							{
								IL_00:
								int? dG_LocationId = t.PS_LocationId;
								int? dG_Location_Id;
								if (!false)
								{
									dG_Location_Id = res[0].DG_Location_Id;
								}
								while (dG_LocationId.GetValueOrDefault() == dG_Location_Id.GetValueOrDefault())
								{
									if (!false)
									{
										bool arg_3E_0 = dG_LocationId.HasValue == dG_Location_Id.HasValue;
										if (true)
										{
											IL_3D:;
										}
										result = arg_3E_0;
										if (2 != 0)
										{
											return result;
										}
										goto IL_00;
									}
								}
								if (!false)
								{
									bool arg_3E_0 = false;
									//goto IL_3D;
								}
							}
							return result;
						}).FirstOrDefault<SemiOrderSettings>();
						if (semiOrderSettings != null)
						{
							using (List<PhotoInfo>.Enumerator enumerator = res.GetEnumerator())
							{
								while (true)
								{
									while (true)
									{
										bool flag2 = enumerator.MoveNext();
										if (!flag2)
										{
											goto Block_28;
										}
										//PlaceOrder semiimg;
										if (!false)
										{
										var semiimg = enumerator.Current;
                                        semiOrderSettings = LoginUser.ListSemiOrderSettingsSubStoreWise.Where(p => p.PS_LocationId == semiimg.DG_Location_Id).FirstOrDefault();
                                            //semiOrderSettings = LoginUser.ListSemiOrderSettingsSubStoreWise.Where(delegate(SemiOrderSettings t)
                                            //{
                                            //    int? dG_LocationId = t.DG_LocationId;
                                            //    int? dG_Location_Id = semiimg.DG_Location_Id;
                                            //    int arg_63_0;
                                            //    int arg_41_0;
                                            //    int arg_41_1;
                                            //    int arg_63_1;
                                            //    while (dG_LocationId.GetValueOrDefault() != dG_Location_Id.GetValueOrDefault())
                                            //    {
                                            //        if (!false)
                                            //        {
                                            //            bool arg_4D_0 = (arg_41_0 = (arg_63_0 = 0)) != 0;
                                            //            IL_49:
                                            //            int arg_6C_0;
                                            //            if (!false)
                                            //            {
                                            //                if (!arg_4D_0)
                                            //                {
                                            //                    arg_6C_0 = 0;
                                            //                    return arg_6C_0 != 0;
                                            //                }
                                            //                arg_63_0 = (arg_41_0 = t.DG_SemiOrder_Settings_Pkey);
                                            //            }
                                            //            arg_63_1 = (arg_41_1 = semiimg.SemiOrderProfileId);
                                            //            IL_60:
                                            //            if (!false)
                                            //            {
                                            //                arg_4D_0 = ((arg_41_0 = (arg_63_0 = (arg_6C_0 = ((arg_63_0 == arg_63_1) ? 1 : 0)))) != 0);
                                            //                if (false)
                                            //                {
                                            //                    goto IL_49;
                                            //                }
                                            //            }
                                            //            else
                                            //            {
                                            //                IL_3E:
                                            //                if (7 != 0)
                                            //                {
                                            //                    arg_4D_0 = ((arg_41_0 = (arg_63_0 = ((arg_41_0 == arg_41_1) ? 1 : 0))) != 0);
                                            //                    goto IL_49;
                                            //                }
                                            //                goto IL_60;
                                            //            }
                                            //            return arg_6C_0 != 0;
                                            //        }
                                            //    }
                                            //    arg_63_0 = (arg_41_0 = (dG_LocationId.HasValue ? 1 : 0));
                                            //    arg_63_1 = (arg_41_1 = (dG_Location_Id.HasValue ? 1 : 0));
                                            //    //goto IL_3E;
                                            //}).FirstOrDefault<SemiOrderSettings>();
											 prdId = 0;
											flag2 = !semiOrderSettings.PS_SemiOrder_ProductTypeId.Contains(',');
										}
										bool arg_4B2_0;
										bool expr_1FF = arg_4B2_0 = flag2;
										if (false)
										{
											goto IL_4B2;
										}
										if (!expr_1FF)
										{
											prdId = 1;
											goto IL_211;
										}
										prdId = Convert.ToInt32(semiOrderSettings.PS_SemiOrder_ProductTypeId);
										goto IL_225;
										break;
										IL_4B2:
										LineItem lineItem;
										if (!arg_4B2_0)
										{
											DataGridRow dataGridRow = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(this._objLineItem.Count - 1);
											if (dataGridRow != null)
											{
												TextBlock textBlock = this.FindByName("txtProductType", dataGridRow) as TextBlock;
												textBlock.Text = lineItem.SelectedProductType_Text;
												Image image = this.FindByName("ProductImage", dataGridRow) as Image;
												image.Source = new BitmapImage(new Uri(lineItem.SelectedProductType_Image.ToString(), UriKind.Relative));
												if (2 == 0)
												{
													goto IL_302;
												}
												ListBox listBox = this.FindByName("lstPrintImage", dataGridRow) as ListBox;
												List<LstMyItems> list=new List<LstMyItems> ();
												listBox.ItemsSource = list;
												while (false)
												{
												}
												TextBlock textBlock2 = this.FindByName("TotalImageSelected", dataGridRow) as TextBlock;
												textBlock2.Text = "Total " + lineItem.SelectedImages.Count + " Images Selected";
												Button button2 = this.FindByName("btndelete", dataGridRow) as Button;
												button2.Tag = "-1";
												Button button3 = this.FindByName("btnSelectImage", dataGridRow) as Button;
												if (5 != 0)
												{
													button3.Visibility = Visibility.Collapsed;
												}
												if (false)
												{
													break;
												}
											}
											this.UpdatePricing(lineItem);
										}
										break;
										IL_225:

										ProductTypeInfo productTypeInfo = (from f in new ProductBusiness().GetProductType()
										where f.DG_Orders_ProductType_pkey == prdId
										select f).FirstOrDefault<ProductTypeInfo>();
                                        var semiimg1 = enumerator.Current;
										OrderDetailInfo semiOrderImage = new OrderBusiness().GetSemiOrderImage(semiimg1.DG_Photos_pkey.ToString());
										string text2="";
                                        int PhotoID = 0;
										if (semiOrderImage != null)
										{
										 PhotoID = semiimg1.DG_Photos_pkey;
											LstMyItems item = (from result in RobotImageLoader.robotImages
											where result.PhotoId == PhotoID
											select result).FirstOrDefault<LstMyItems>();
											List<LstMyItems> list = new List<LstMyItems>();
											list.Add(item);
											lineItem = new LineItem();
											text2 = Guid.NewGuid().ToString();
											lineItem.ItemNumber = text2;
											goto IL_302;
										}
										if (6 != 0)
										{
											text = semiimg1.DG_Photos_RFID + ",";
											break;
										}
										goto IL_382;
										IL_211:
										goto IL_225;
										IL_302:
										lineItem.ParentID = text2;
										LstMyItems lstMyItems = new LstMyItems();
										lstMyItems.FilePath = semiimg1.HotFolderPath + "\\" + semiimg1.DG_Photos_FileName;
										lstMyItems.Name = Path.GetFileNameWithoutExtension(lstMyItems.FilePath);
										if (2 == 0)
										{
											goto IL_211;
										}
										lstMyItems.PhotoId =PhotoID;
										lineItem.GroupItems = new List<LstMyItems>();
										lineItem.GroupItems.Add(lstMyItems);
										IL_382:
										lineItem.OrderDetailsID = semiOrderImage.DG_Orders_LineItems_pkey;
										lineItem.SelectedProductType_ID = productTypeInfo.DG_Orders_ProductType_pkey;
										lineItem.SelectedProductType_Image = productTypeInfo.DG_Orders_ProductType_Image.ToString();
										lineItem.SelectedProductType_Text = productTypeInfo.DG_Orders_ProductType_Name.ToString();
										LineItem arg_3F3_0 = lineItem;
										flag = productTypeInfo.DG_Orders_ProductType_IsBundled;
										arg_3F3_0.IsBundled = (flag.HasValue && productTypeInfo.DG_Orders_ProductType_IsBundled.ToBoolean(false));
										LineItem arg_423_0 = lineItem;
										flag = productTypeInfo.DG_Orders_ProductType_DiscountApplied;
										arg_423_0.AllowDiscount = (flag.HasValue && productTypeInfo.DG_Orders_ProductType_DiscountApplied.ToBoolean(false));
										lineItem.TotalMaxSelectedPhotos = productTypeInfo.DG_MaxQuantity;
										lineItem.Quantity = 1;
										lineItem.SelectedImages = new List<string>
										{
											PhotoID.ToString()
										};
										lineItem.TotalMaxSelectedPhotos = 1;
										lineItem.IssemiOrder = true;
										lineItem.ItemIndex = this._objLineItem.Count - 1 + 1;
										this._objLineItem.Add(lineItem);
										this.dgOrder.UpdateLayout();
										flag2 = (productTypeInfo == null);
										arg_4B2_0 = flag2;
										goto IL_4B2;
									}
								}
								Block_28:;
							}
						}
					}
					else
					{
						MessageBox.Show("Sorry No Images found.", "Spectra Photo");
					}
					if (!string.IsNullOrEmpty(text))
					{
						MessageBox.Show("You have already placed an order for the images (" + text.Trim(new char[]
						{
							','
						}) + ")");
					}
					break;
				}
			}
		}

		private bool CheckOnlineUploadQRCode()
		{
			bool flag = true;
			bool flag2 = this._objLineItem == null || this._objLineItem.Count <= 0;
			if (!false)
			{
				if (flag2)
				{
					goto IL_A7;
				}
				LineItem lineItem = this._objLineItem.Where(delegate(LineItem o)
				{
					int selectedProductType_ID;
					if (true)
					{
						if (!false)
						{
							selectedProductType_ID = o.SelectedProductType_ID;
							goto IL_0C;
						}
						goto IL_0C;
					}
					IL_19:
					while (false)
					{
					}
					bool result2;
					if (8 != 0)
					{
						return result2;
					}
					IL_0C:
					result2 = (selectedProductType_ID.ToString() == "84");
					goto IL_19;
				}).FirstOrDefault<LineItem>();
				if (lineItem != null && string.IsNullOrEmpty(this.CtrlSelectedQrCode.QRCode))
				{
					flag = false;
				}
				if (!this.isChkSpecOnlinePackage)
				{
					goto IL_A6;
				}
			}
			flag = true;
			bool result;
			if (false)
			{
				return result;
			}
			IL_A6:
			IL_A7:
			result = flag;
			return result;
		}

		private int GetDefaultCurrencyID()
		{
			if (7 == 0 || false)
			{
				goto IL_54;
			}
			IL_07:
			int num = (from objcurrency in new CurrencyBusiness().GetCurrencyList().Where(delegate(CurrencyInfo objcurrency)
			{
				bool? dG_Currency_Default = objcurrency.DG_Currency_Default;
				int arg_42_0;
				if (!dG_Currency_Default.GetValueOrDefault())
				{
					arg_42_0 = 0;
					goto IL_16;
				}
				arg_42_0 = (dG_Currency_Default.HasValue ? 1 : 0);
				IL_10:
				if (!false)
				{
				}
				IL_16:
				bool expr_45;
				do
				{
					bool flag = arg_42_0 != 0;
					if (!false)
					{
					}
					expr_45 = ((arg_42_0 = (flag ? 1 : 0)) != 0);
				}
				while (8 == 0);
				if (!false)
				{
					return expr_45;
				}
				goto IL_10;
			})
			select objcurrency.DG_Currency_pkey).FirstOrDefault<int>();
			IL_54:
			int result = num;
			if (-1 != 0)
			{
				return result;
			}
			goto IL_07;
		}

		private string GenerateOrderNumber()
		{
			string text = LoginUser.OrderPrefix + "-";
			string str = string.Empty;
			try
			{
				RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
				try
				{
					byte[] array = new byte[4];
					rNGCryptoServiceProvider.GetBytes(array);
					int num = BitConverter.ToInt32(array, 0);
					bool flag = num >= 0;
					int arg_59_0 = flag ? 1 : 0;
					int expr_67;
					do
					{
						if (arg_59_0 == 0)
						{
							num = -num;
						}
						expr_67 = (arg_59_0 = num.ToString().Length);
					}
					while (5 == 0);
					if (expr_67 > 10)
					{
						str = num.ToString().Substring(0, 10);
						if (!false)
						{
						}
					}
					else
					{
						str = num.ToString();
					}
				}
				finally
				{
					bool arg_C1_0 = rNGCryptoServiceProvider == null;
					bool expr_C3;
					do
					{
						bool flag = arg_C1_0;
						expr_C3 = (arg_C1_0 = flag);
					}
					while (5 == 0 || 7 == 0);
					if (!expr_C3)
					{
						((IDisposable)rNGCryptoServiceProvider).Dispose();
					}
				}
				while (false)
				{
				}
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
				if (6 != 0)
				{
				}
			}
			text += str;
			return text;
		}

		protected void SaveOrder()
		{
			try
			{
				double num = 0.0;
				foreach (LineItem current in this._objLineItem)
				{
					num += (double)(current.Quantity * current.SelectedImages.Count) * current.UnitPrice;
				}
				string orderNumber = this.GenerateOrderNumber();
				string uniqueSynccode = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.Camera).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, "14");
				OrderInfo orderInfo = new OrderBusiness().GenerateOrder(orderNumber, (decimal)num, (decimal)num, string.Empty, 0, 0.0, string.Empty, LoginUser.UserId, this.GetDefaultCurrencyID(), "3", uniqueSynccode, LoginUser.Storecode);
				orderNumber = orderInfo.DG_Orders_Number;
				int dG_Orders_pkey = orderInfo.DG_Orders_pkey;
				TaxBusiness taxBusiness = new TaxBusiness();
				taxBusiness.SaveOrderTaxDetails(LoginUser.StoreId, dG_Orders_pkey, LoginUser.SubStoreId);
				if (dG_Orders_pkey > 0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					string text = string.Empty;
					int num2 = 0;
					foreach (LineItem current in this._objLineItem)
					{
						int arg_178_0 = num2;
						int arg_178_1 = current.SelectedProductType_Text.Length;
						int expr_178;
						int expr_17B;
						do
						{
							expr_178 = (arg_178_0 = ((arg_178_0 < arg_178_1) ? 1 : 0));
							expr_17B = (arg_178_1 = 0);
						}
						while (expr_17B != 0);
						if (expr_178 != expr_17B)
						{
							num2 = current.SelectedProductType_Text.Length;
						}
					}
					foreach (LineItem current in this._objLineItem)
					{
						string uniqueSynccode2 = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.OrderDetails).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, LoginUser.SubStoreId.ToString());
						List<string>.Enumerator enumerator2 = current.SelectedImages.GetEnumerator();
						try
						{
							while (true)
							{
								IL_2D6:
								bool arg_2DD_0 = enumerator2.MoveNext();
								while (arg_2DD_0)
								{
									string current2 = enumerator2.Current;
									string text2 = string.Empty;
                                    int num4 = 0;
									int num3 = num2 - current.SelectedProductType_Text.Length;
									num3 += 45;
									int arg_27B_0;
									int expr_24E = arg_27B_0 = 1;
									if (expr_24E == 0)
									{
										goto IL_27B;
									}
									 num4 = expr_24E;
									IL_26B:
									bool expr_26F = arg_2DD_0 = (num4 > num3);
									if (7 == 0)
									{
										continue;
									}
									bool flag = !expr_26F;
									arg_27B_0 = (flag ? 1 : 0);
									IL_27B:
									if (arg_27B_0 == 0)
									{
										stringBuilder.AppendLine(current.SelectedProductType_Text + text2 + current.UnitPrice.ToString(".00"));
										if (text == string.Empty)
										{
											text = current2;
										}
										else
										{
											text = text + "," + current2;
										}
										goto IL_2D6;
									}
									text2 += " ";
									num4++;
									goto IL_26B;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)enumerator2).Dispose();
							if (7 != 0)
							{
							}
						}
						int num5 = new OrderBusiness().SaveOrderLineItems(current.SelectedProductType_ID, new int?(dG_Orders_pkey), text, current.Quantity, current.TotalDiscount, (decimal)current.TotalDiscountAmount, (decimal)current.UnitPrice, (decimal)current.TotalPrice, (decimal)current.NetPrice, -1, LoginUser.SubStoreId, current.CodeType, current.UniqueCode, uniqueSynccode2, null, null, null, null);
						int arg_3F0_0;
						int expr_386 = arg_3F0_0 = current.SelectedProductType_ID;
						if (3 != 0)
						{
							bool flag = expr_386 != 79 || num5 <= 0 || string.IsNullOrEmpty(text) || current.GroupItems.Count<LstMyItems>() <= 0;
							if (-1 == 0 || !flag)
							{
								new PrinterBusniess().SaveAlbumPrintPosition(num5, current.PrintPhotoOrderPosition);
							}
							text = string.Empty;
							if (!current.IsAccessory)
							{
								arg_3F0_0 = ((current.SelectedProductType_ID == 84) ? 1 : 0);
							}
							else
							{
								arg_3F0_0 = 1;
							}
						}
						IL_3EF:
						if (arg_3F0_0 == 0)
						{
							if (!this._issemiorder)
							{
								this.AddToPrintQueue(current, num5, current.PrintPhotoOrderPosition);
							}
						}
						continue;
						goto IL_3EF;
					}
				}
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
			finally
			{
				if (4 != 0)
				{
					base.Close();
				}
				if (!false)
				{
				}
			}
		}

		protected void PrintSlip(string ordernumber, string ItemDetails, double TotalPercentage, double Discount, double NetPrice)
		{
			TextBlock textBlock = new TextBlock();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("                 DIGIPHOTO STUDIO        " + Environment.NewLine);
			stringBuilder.Append("              Welcome to " + LoginUser.StoreName.ToString() + "  " + Environment.NewLine);
			if (false)
			{
				goto IL_F3;
			}
			stringBuilder.Append(Environment.NewLine);
			IL_6A:
			stringBuilder.Append("------------------------------------------------" + Environment.NewLine);
			stringBuilder.Append("Operator: " + LoginUser.UserName + Environment.NewLine);
			stringBuilder.Append("Order No: " + ordernumber + Environment.NewLine);
			stringBuilder.Append("------------------------------------------------" + Environment.NewLine);
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.Append(ItemDetails);
			if (Discount == 0.0)
			{
				goto IL_226;
			}
			IL_F3:
			int length = (TotalPercentage.ToString(".00") + " %  Dis ").Length;
			string text = string.Empty;
			int num = 0;
			foreach (LineItem current in this._objLineItem)
			{
				if (num < current.SelectedProductType_Text.Length)
				{
					num = current.SelectedProductType_Text.Length;
				}
			}
			int num2 = num - length;
			if (-1 == 0)
			{
				goto IL_334;
			}
			num2 += 50;
			for (int i = 0; i < num2; i++)
			{
				text += " ";
			}
			textBlock.Inlines.Add(stringBuilder.ToString());
			stringBuilder.Clear();
			textBlock.Inlines.Add(new Run
			{
				Text = TotalPercentage.ToString(".00") + " %  Dis " + text + Discount.ToString(),
				FontWeight = FontWeights.Bold
			});
			stringBuilder.Append(Environment.NewLine);
			IL_226:
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.Append("SUBTOTAL                                    " + NetPrice.ToString(".00") + Environment.NewLine);
			stringBuilder.Append("TAX                                               0.00" + Environment.NewLine);
			stringBuilder.Append("AMOUNT DUE                              0.00" + Environment.NewLine);
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.Append("CASH                                            0.00" + Environment.NewLine);
			stringBuilder.AppendLine("CHANGE                                      0.00 " + Environment.NewLine);
			textBlock.Inlines.Add(stringBuilder.ToString());
			stringBuilder.Clear();
			textBlock.Inlines.Add(new Run
			{
				Text = "             THANK  you.         ",
				FontWeight = FontWeights.Bold
			});
			if (6 == 0)
			{
				goto IL_6A;
			}
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.Append("        Your Cashier Was: 1310" + Environment.NewLine);
			IL_334:
			stringBuilder.Append("        Your Terminal Was: 1310" + Environment.NewLine + Environment.NewLine);
			textBlock.Inlines.Add(stringBuilder.ToString());
			stringBuilder.Clear();
			textBlock.Inlines.Add(new Run
			{
				Text = "           NO REFUNDS",
				FontWeight = FontWeights.Bold
			});
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.Append("           GUEST COPY" + Environment.NewLine);
			stringBuilder.Append("------------------------------------------------" + Environment.NewLine);
			stringBuilder.Append(string.Concat(new string[]
			{
				"  ",
				new CustomBusineses().ServerDateTime().ToLongDateString(),
				" ",
				new CustomBusineses().ServerDateTime().ToLongTimeString(),
				"  ",
				Environment.NewLine
			}));
			stringBuilder.Append("------------------------------------------------" + Environment.NewLine);
			textBlock.Inlines.Add(stringBuilder.ToString());
			PrintDialog printDialog = new PrintDialog();
			textBlock.Margin = new Thickness(50.0);
			textBlock.TextWrapping = TextWrapping.Wrap;
			textBlock.LayoutTransform = new ScaleTransform(1.0, 1.0);
			Size availableSize = new Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight);
			textBlock.Measure(availableSize);
			textBlock.Arrange(new Rect(0.0, 0.0, availableSize.Width, availableSize.Height));
			printDialog.PrintVisual(textBlock, "Spectra Photo");
		}

		protected void AddToPrintQueue(LineItem liItem, int OrderDetailID, List<PhotoPrintPositionDic> PhotoPrintPositionDicList)
		{
			do
			{
				try
				{
					do
					{
						new PrinterBusniess().AddImageToPrinterQueue(liItem.SelectedProductType_ID, liItem.SelectedImages, OrderDetailID, liItem.IsBundled, false, PhotoPrintPositionDicList, 1);
					}
					while (false);
				}
				catch (Exception serviceException)
				{
					while (true)
					{
						string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
						ErrorHandler.ErrorHandler.LogFileWrite(message);
						while (!false)
						{
							if (5 != 0)
							{
								goto Block_5;
							}
						}
					}
					Block_5:;
				}
				while (false)
				{
				}
			}
			while (6 == 0);
		}

		private void AddPrintedImagesOnOff()
		{
        int num = new ConfigBusiness().GetConfigurationData().Count;
            //int num = new ConfigBusiness().GetConfigurationData().Where(delegate(ConfigurationInfo x)
            //{
            //    bool? posOnOff = x.PosOnOff;
            //    int arg_42_0;
            //    if (!posOnOff.GetValueOrDefault())
            //    {
            //        arg_42_0 = 0;
            //        goto IL_16;
            //    }
            //    arg_42_0 = (posOnOff.HasValue ? 1 : 0);
            //    IL_10:
            //    if (!false)
            //    {
            //    }
            //    IL_16:
            //    bool expr_45;
            //    do
            //    {
            //        bool flag2 = arg_42_0 != 0;
            //        if (!false)
            //        {
            //        }
            //        expr_45 = ((arg_42_0 = (flag2 ? 1 : 0)) != 0);
            //    }
            //    while (8 == 0);
            //    if (!false)
            //    {
            //        return expr_45;
            //    }
            //    goto IL_10;
            //}).Count<ConfigurationInfo>();
			int arg_3C_0;
			int arg_45_0 = arg_3C_0 = num;
			int arg_36_0 = 0;
			int expr_3F;
			while (true)
			{
				int arg_3F_0;
				int expr_36 = arg_3F_0 = arg_36_0;
				if (expr_36 == 0)
				{
					arg_3F_0 = expr_36;
					if (expr_36 == 0)
					{
						arg_45_0 = (arg_3C_0 = ((arg_3C_0 > expr_36) ? 1 : 0));
						arg_3F_0 = 0;
					}
				}
				expr_3F = (arg_36_0 = arg_3F_0);
				if (expr_3F == 0)
				{
					arg_36_0 = expr_3F;
					if (expr_3F == 0)
					{
						break;
					}
				}
			}
			bool flag = arg_45_0 == expr_3F;
			while (!flag)
			{
				this.btnAddSemiPrinted.Visibility = Visibility.Visible;
				if (!false)
				{
					return;
				}
			}
			this.btnAddSemiPrinted.Visibility = Visibility.Collapsed;
		}

        //void IStyleConnector.Connect(int connectionId, object target)
        //{
        //    int arg_11_0 = connectionId;
        //    int expr_11;
        //    do
        //    {
        //        expr_11 = (arg_11_0 -= 2);
        //    }
        //    while (4 == 0);
        //    switch (expr_11)
        //    {
        //    case 0:
        //        ((CheckBox)target).Unchecked += new RoutedEventHandler(this.ChkSelected_Unchecked);
        //        ((CheckBox)target).Checked += new RoutedEventHandler(this.ChkSelected_Checked);
        //        break;
        //    //case 7:
        //    //    ((Button)target).Click += new RoutedEventHandler(this.btnProductType_Click);
        //    //    break;
        //    case 8:
        //        ((Button)target).Click += new RoutedEventHandler(this.btnQtyUp_Click);
        //        break;
        //    case 9:
        //        ((Button)target).Click += new RoutedEventHandler(this.btnQtyDown_Click);
        //        break;
        //    case 10:
        //        ((Button)target).Click += new RoutedEventHandler(this.btnSelectImage_Click);
        //        break;
        //    case 11:
        //        ((Button)target).Click += new RoutedEventHandler(this.btnSelectImage_Click);
        //        break;
        //    case 12:
        //        if (!false)
        //        {
        //            ((Button)target).Click += new RoutedEventHandler(this.btndelete_Click);
        //        }
        //        break;
        //    }
        //    IL_4E:
        //    if (5 != 0)
        //    {
        //        return;
        //    }
        //    goto IL_4E;
        //}
	}
}
