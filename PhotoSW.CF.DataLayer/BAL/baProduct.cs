using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baProduct
        {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductIcon { get; set; }
        public int ProductID { get; set; }
        public int MaxQuantity { get; set; }
        public bool DiscountOption { get; set; }
        public bool IsBundled { get; set; }
        public bool IsPackage { get; set; }
        public bool IsAccessory { get; set; }
        public bool IsWaterMarked { get; set; }
        public int? IsPrintType { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<product> lst_product = new List<product>();
             List<int> lst_str = new List<int>();
            lst_str.Add(1);
            lst_str.Add(2);
            lst_str.Add(3);
            lst_str.Add(4);
            lst_str.Add(5);
           
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    foreach(var item in lst_str)
                        {
                        product product = new product();

                        product.Id = item;
                        if(item == 1)
                            {
                            product.ProductName = "Test";
                            product.ProductIcon = "test1.jpg";
                            product.ProductID = 1;
                            }
                        if(item == 2)
                            {
                            product.ProductName = "Test1";
                            product.ProductIcon = "test2.jpg";
                            product.ProductID = 2;
                            }
                        if(item == 3)
                            {
                            product.ProductName = "Test2";
                            product.ProductIcon = "test3.jpg";
                            product.ProductID = 3;
                            }
                        if(item == 4)
                            {
                            product.ProductName = "Test3";
                            product.ProductIcon = "test4.jpg";
                            product.ProductID = 4;
                            }
                        if(item == 5)
                            {
                            product.ProductName = "Test4";
                            product.ProductIcon = "test5.jpg";
                            product.ProductID = 5;
                            }
                        
                        product.MaxQuantity = 3;
                        product.DiscountOption = false;
                        product.IsBundled = false;
                        product.IsPackage = false;
                        product.IsAccessory = false;
                        product.IsWaterMarked = false;
                        product.IsPrintType = 5;
                        product.IsActive = true;

                        lst_product.Add(product);
                        }
                    var Id = lst_product.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.Products.Where(p => lst_str.Contains(p.Id)).ToList();
                    if(IsExist == null)
                        {
                        db.Products.AddRange(lst_product);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.Products.AddRange(lst_product);
                        db.SaveChanges();
                        }
                    return true;
                    }
                }
            catch(Exception ex)
                {
                return false;
                }
            }

        public static baProduct GetProductDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.Products.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baProduct
                        {
                        Id = p.Id,
                        ProductName = p.ProductName,
                        ProductIcon = p.ProductIcon,
                        ProductID = p.ProductID,
                        MaxQuantity = p.MaxQuantity,
                        DiscountOption = p.DiscountOption,
                        IsBundled = p.IsBundled,
                        IsPackage = p.IsPackage,
                        IsAccessory = p.IsAccessory,
                        IsWaterMarked = p.IsWaterMarked,
                        IsPrintType = p.IsPrintType,
                        IsActive = p.IsActive,

                        }).FirstOrDefault();
                    return obj;
                    }
                }
            catch
                {
                return null; ;
                }
            }

        public static List<baProduct> GetProductData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.Products.Where(p => p.IsActive == true).Select(p => new baProduct
                        {
                        Id = p.Id,
                        ProductName = p.ProductName,
                        ProductIcon = p.ProductIcon,
                        ProductID = p.ProductID,
                        MaxQuantity = p.MaxQuantity,
                        DiscountOption = p.DiscountOption,
                        IsBundled = p.IsBundled,
                        IsPackage = p.IsPackage,
                        IsAccessory = p.IsAccessory,
                        IsWaterMarked = p.IsWaterMarked,
                        IsPrintType = p.IsPrintType,
                        IsActive = p.IsActive

                        }).ToList();
                    return obj;
                    }
                }
            catch
                {
                return null; ;
                }
            }

        public static bool Insert ( baProduct baProduct )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    product product = new product();

                    product.Id = baProduct.Id;
                    product.ProductName = baProduct.ProductName;
                    product.ProductIcon = baProduct.ProductIcon;
                    product.ProductID = baProduct.ProductID;
                    product.MaxQuantity = baProduct.MaxQuantity;
                    product.DiscountOption = baProduct.DiscountOption;
                    product.IsBundled = baProduct.IsBundled;
                    product.IsPackage = baProduct.IsPackage;
                    product.IsAccessory = baProduct.IsAccessory;
                    product.IsWaterMarked = baProduct.IsWaterMarked;
                    product.IsPrintType = baProduct.IsPrintType;
                    product.IsActive = baProduct.IsActive;

                    db.Products.Add(product);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baProduct baProduct )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.Products.Where(p => p.Id == baProduct.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        product product = new product();

                        product.Id = baProduct.Id;
                        product.ProductName = baProduct.ProductName;
                        product.ProductIcon = baProduct.ProductIcon;
                        product.ProductID = baProduct.ProductID;
                        product.MaxQuantity = baProduct.MaxQuantity;
                        product.DiscountOption = baProduct.DiscountOption;
                        product.IsBundled = baProduct.IsBundled;
                        product.IsPackage = baProduct.IsPackage;
                        product.IsAccessory = baProduct.IsAccessory;
                        product.IsWaterMarked = baProduct.IsWaterMarked;
                        product.IsPrintType = baProduct.IsPrintType;
                        product.IsActive = baProduct.IsActive;

                        db.SaveChanges();

                        return true;
                        }
                    else
                        {
                        return false;
                        }
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Delete ( int Id )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.Products.Where(p => p.Id == Id).FirstOrDefault();
                    if(obj != null)
                        {
                        obj.IsActive = false;
                        db.SaveChanges();

                        }
                    return true;

                    }
                }
            catch(Exception)
                {
                throw;
                }

            }


        }
    }
