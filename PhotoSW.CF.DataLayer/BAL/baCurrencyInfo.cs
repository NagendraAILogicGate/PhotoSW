using PhotoSW.CF.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.BAL
    {
        public class baCurrencyInfo
            {
            public int Id { get; set; }
            public int PS_Currency_pkey { get; set; }

            public string PS_Currency_Name { get; set; }

            public float PS_Currency_Rate { get; set; }

            public string PS_Currency_Symbol { get; set; }

            public DateTime? PS_Currency_UpdatedDate { get; set; }

            public int? PS_Currency_ModifiedBy { get; set; }

            public bool? PS_Currency_Default { get; set; }

            public string PS_Currency_Icon { get; set; }

            public string PS_Currency_Code { get; set; }

            public bool? PS_Currency_IsActive { get; set; }

            public string SyncCode { get; set; }

            public bool IsSynced { get; set; }

            public bool? IsActive { get; set; }


            public static bool Marge ()
                {
                List<currencyinfo> lst_currencyinfo = new List<currencyinfo>();
              //  List<photoinfo> lst_photoinfo = new List<photoinfo>();
                List<int> lst_str = new List<int>();
                lst_str.Add(1);
                lst_str.Add(2);
                lst_str.Add(3);
                try
                    {
                    using(PhotoSWEntities db = new PhotoSWEntities())
                        {
                        foreach(var item in lst_str)
                            {
                           
                             currencyinfo currencyinfo = new currencyinfo();
                             if(item == 1)
                                {

                                currencyinfo.Id = item;
                                currencyinfo.PS_Currency_pkey = item;
                                currencyinfo.PS_Currency_Name = "Rupees";
                                currencyinfo.PS_Currency_Rate = 5;
                                currencyinfo.PS_Currency_Symbol = "Rs.";
                                currencyinfo.PS_Currency_UpdatedDate = DateTime.Now;
                                currencyinfo.PS_Currency_ModifiedBy = 1;
                                currencyinfo.PS_Currency_Default = true;
                                currencyinfo.PS_Currency_Icon = "";
                                currencyinfo.PS_Currency_Code = "001";
                                currencyinfo.PS_Currency_IsActive = true;
                                currencyinfo.SyncCode = "001";
                                currencyinfo.IsSynced = true;
                                currencyinfo.IsActive = true;
                                } 
                            if(item == 2)
                                {
                                currencyinfo.Id = item;
                                currencyinfo.PS_Currency_pkey = item;
                                currencyinfo.PS_Currency_Name = "Dollar";
                                currencyinfo.PS_Currency_Rate = 5;
                                currencyinfo.PS_Currency_Symbol = "$";
                                currencyinfo.PS_Currency_UpdatedDate = DateTime.Now;
                                currencyinfo.PS_Currency_ModifiedBy = 1;
                                currencyinfo.PS_Currency_Default = false;
                                currencyinfo.PS_Currency_Icon = "";
                                currencyinfo.PS_Currency_Code = "002";
                                currencyinfo.PS_Currency_IsActive = true;
                                currencyinfo.SyncCode = "002";
                                currencyinfo.IsSynced = true;
                                currencyinfo.IsActive = true;
                                } 
                            if(item == 3)
                                {
                                currencyinfo.Id = item;
                                currencyinfo.PS_Currency_pkey = item;
                                currencyinfo.PS_Currency_Name = "Dollar";
                                currencyinfo.PS_Currency_Rate = 5;
                                currencyinfo.PS_Currency_Symbol = "$";
                                currencyinfo.PS_Currency_UpdatedDate = DateTime.Now;
                                currencyinfo.PS_Currency_ModifiedBy = 1;
                                currencyinfo.PS_Currency_Default = false;
                                currencyinfo.PS_Currency_Icon = "";
                                currencyinfo.PS_Currency_Code = "003";
                                currencyinfo.PS_Currency_IsActive = true;
                                currencyinfo.SyncCode = "003";
                                currencyinfo.IsSynced = true;
                                currencyinfo.IsActive = true;
                                }

                            lst_currencyinfo.Add(currencyinfo);
                            }
                        var Id = lst_currencyinfo.Where(t => t.Id == 1).First().Id;
                        var IsExist = db.CurrencyInfos.Where(p => lst_str.Contains(p.Id)).ToList();
                        if(IsExist == null)
                            {
                            db.CurrencyInfos.AddRange(lst_currencyinfo);
                            db.SaveChanges();
                            }
                        else if(IsExist.Count == 0)
                            {
                            db.CurrencyInfos.AddRange(lst_currencyinfo);
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

            public static baCurrencyInfo GetCurrencyInfoDataById ( long Id )
                {
                try
                    {

                    using(PhotoSWEntities db = new PhotoSWEntities())
                        {

                        var obj = db.CurrencyInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baCurrencyInfo
                        {
                            Id = p.Id,
                            PS_Currency_pkey = p.PS_Currency_pkey,
                            PS_Currency_Name = p.PS_Currency_Name,
                            PS_Currency_Rate = p.PS_Currency_Rate,
                            PS_Currency_Symbol = p.PS_Currency_Symbol,
                            PS_Currency_UpdatedDate = p.PS_Currency_UpdatedDate,
                            PS_Currency_ModifiedBy = p.PS_Currency_ModifiedBy,
                            PS_Currency_Default =p.PS_Currency_Default,
                            PS_Currency_Icon = p.PS_Currency_Icon,
                            PS_Currency_Code = p.PS_Currency_Code,
                            PS_Currency_IsActive = p.PS_Currency_IsActive,
                            SyncCode = p.SyncCode,
                            IsSynced = p.IsSynced,
                            IsActive = p.IsActive
                        }).FirstOrDefault();
                        return obj;
                        }
                    }
                catch
                    {
                    return null; ;
                    }
                }

            public static List<baCurrencyInfo> GetCurrencyInfoData ()
                {
                try
                    {

                    using(PhotoSWEntities db = new PhotoSWEntities())
                        {
                        var obj = db.CurrencyInfos.Where(p => p.IsActive == true).Select(p => new baCurrencyInfo
                        {
                            Id = p.Id,
                            PS_Currency_pkey = p.PS_Currency_pkey,
                            PS_Currency_Name = p.PS_Currency_Name,
                            PS_Currency_Rate = p.PS_Currency_Rate,
                            PS_Currency_Symbol = p.PS_Currency_Symbol,
                            PS_Currency_UpdatedDate = p.PS_Currency_UpdatedDate,
                            PS_Currency_ModifiedBy = p.PS_Currency_ModifiedBy,
                            PS_Currency_Default = p.PS_Currency_Default,
                            PS_Currency_Icon = p.PS_Currency_Icon,
                            PS_Currency_Code = p.PS_Currency_Code,
                            PS_Currency_IsActive = p.PS_Currency_IsActive,
                            SyncCode = p.SyncCode,
                            IsSynced = p.IsSynced,
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

            public static bool Insert ( baCurrencyInfo baCurrencyInfo )
                {
                try
                    {
                    using(PhotoSWEntities db = new PhotoSWEntities())
                        {
                        currencyinfo currencyinfo = new currencyinfo();

                       // currencyinfo.Id = baCurrencyInfo.Id;
                        currencyinfo.PS_Currency_pkey = baCurrencyInfo.PS_Currency_pkey;
                        currencyinfo.PS_Currency_Name = baCurrencyInfo.PS_Currency_Name;
                        currencyinfo.PS_Currency_Rate = baCurrencyInfo.PS_Currency_Rate;
                        currencyinfo.PS_Currency_Symbol = baCurrencyInfo.PS_Currency_Symbol;
                        currencyinfo.PS_Currency_UpdatedDate = baCurrencyInfo.PS_Currency_UpdatedDate;
                        currencyinfo.PS_Currency_ModifiedBy = baCurrencyInfo.PS_Currency_ModifiedBy;
                        currencyinfo.PS_Currency_Default = baCurrencyInfo.PS_Currency_Default;
                        currencyinfo.PS_Currency_Icon = baCurrencyInfo.PS_Currency_Icon;
                        currencyinfo.PS_Currency_Code = baCurrencyInfo.PS_Currency_Code;
                        currencyinfo.PS_Currency_IsActive = baCurrencyInfo.PS_Currency_IsActive;
                        currencyinfo.SyncCode = baCurrencyInfo.SyncCode;
                        currencyinfo.IsSynced = baCurrencyInfo.IsSynced;

                        db.CurrencyInfos.Add(currencyinfo);
                        db.SaveChanges();

                        return true;
                        }
                    }
                catch(Exception)
                    {

                    throw;
                    }
                }

            public static bool Update ( baCurrencyInfo baCurrencyInfo )
                {
                try
                    {
                    using(PhotoSWEntities db = new PhotoSWEntities())
                        {
                        var obj = db.CurrencyInfos.Where(p => p.Id == baCurrencyInfo.Id).FirstOrDefault();
                        if(obj != null)
                            {
                            currencyinfo currencyinfo = new currencyinfo();

                            currencyinfo.Id = baCurrencyInfo.Id;
                            currencyinfo.PS_Currency_pkey = baCurrencyInfo.PS_Currency_pkey;
                            currencyinfo.PS_Currency_Name = baCurrencyInfo.PS_Currency_Name;
                            currencyinfo.PS_Currency_Rate = baCurrencyInfo.PS_Currency_Rate;
                            currencyinfo.PS_Currency_Symbol = baCurrencyInfo.PS_Currency_Symbol;
                            currencyinfo.PS_Currency_UpdatedDate = baCurrencyInfo.PS_Currency_UpdatedDate;
                            currencyinfo.PS_Currency_ModifiedBy = baCurrencyInfo.PS_Currency_ModifiedBy;
                            currencyinfo.PS_Currency_Default = baCurrencyInfo.PS_Currency_Default;
                            currencyinfo.PS_Currency_Icon = baCurrencyInfo.PS_Currency_Icon;
                            currencyinfo.PS_Currency_Code = baCurrencyInfo.PS_Currency_Code;
                            currencyinfo.PS_Currency_IsActive = baCurrencyInfo.PS_Currency_IsActive;
                            currencyinfo.SyncCode = baCurrencyInfo.SyncCode;
                            currencyinfo.IsSynced = baCurrencyInfo.IsSynced;

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
                        var obj = db.CurrencyInfos.Where(p => p.Id == Id).FirstOrDefault();
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
