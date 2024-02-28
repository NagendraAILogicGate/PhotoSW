using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
{
    public class baCharacterInfo
    {
        public int Id { get; set; }
        public int PS_Character_Pkey { get; set; }
        public string PS_Character_Name { get; set; }
        public int PS_Character_IsActive { get; set; }

        public DateTime PS_Character_CreatedDate { get; set; }

        public int PS_Character_OperationType { get; set; }

        public bool? IsActive { get; set; }

        public static bool Marge()
        {
            List<characterinfo> lst_characterinfo = new List<characterinfo>();

            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    //foreach (var item in lst_str)
                    //{
                    characterinfo characterinfo = new characterinfo();

                    characterinfo.Id = 1;
                    characterinfo.PS_Character_Pkey = 1;
                    characterinfo.PS_Character_Name = "test";
                    characterinfo.PS_Character_IsActive = 1;
                    characterinfo.PS_Character_CreatedDate = DateTime.Now;
                    characterinfo.PS_Character_OperationType = 1;
                    characterinfo.IsActive = true;


                    lst_characterinfo.Add(characterinfo);
                    // }
                    var Id = lst_characterinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.CharacterInfos.Where(p => p.Id == Id).ToList();
                    if (IsExist == null)
                    {
                        db.CharacterInfos.AddRange(lst_characterinfo);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.CharacterInfos.AddRange(lst_characterinfo);
                        db.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static baCharacterInfo GetCharacterInfoDataById(int Id)
        {
            try
            {


                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.CharacterInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baCharacterInfo
                    {
                        Id = p.Id,
                        PS_Character_Pkey = p.PS_Character_Pkey,
                        PS_Character_Name = p.PS_Character_Name,
                        PS_Character_IsActive = p.PS_Character_IsActive,
                        PS_Character_CreatedDate = p.PS_Character_CreatedDate,
                        PS_Character_OperationType = p.PS_Character_OperationType,
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
        public static List<baCharacterInfo> GetCharacterInfoData()
        {
            try
            {

                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.CharacterInfos.Where(p => p.IsActive == true).Select(p => new baCharacterInfo
                    {

                        Id = p.Id,
                        PS_Character_Pkey = p.PS_Character_Pkey,
                        PS_Character_Name = p.PS_Character_Name,
                        PS_Character_IsActive = p.PS_Character_IsActive,
                        PS_Character_CreatedDate = p.PS_Character_CreatedDate,
                        PS_Character_OperationType = p.PS_Character_OperationType,
                        IsActive = p.IsActive


                    }).ToList();
                    return obj;
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool Insert(baCharacterInfo baCharacterInfo)
        {
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    characterinfo characterinfo = new characterinfo();

                    characterinfo.Id = baCharacterInfo.Id;
                    characterinfo.PS_Character_Name = baCharacterInfo.PS_Character_Name;
                    characterinfo.PS_Character_IsActive = baCharacterInfo.PS_Character_IsActive;
                    characterinfo.PS_Character_CreatedDate = baCharacterInfo.PS_Character_CreatedDate;
                    characterinfo.PS_Character_OperationType = baCharacterInfo.PS_Character_OperationType;
                    characterinfo.IsActive = baCharacterInfo.IsActive;

                    db.CharacterInfos.Add(characterinfo);
                    db.SaveChanges();

                    characterinfo.PS_Character_Pkey = GetCharacterInfoData().OrderByDescending(m => m.Id).FirstOrDefault().Id;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool Update(baCharacterInfo baCharacterInfo)
        {
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.CharacterInfos.Where(p => p.PS_Character_Pkey == baCharacterInfo.PS_Character_Pkey).FirstOrDefault();
                    if (obj != null)
                    {
                        //characterinfo characterinfo = new characterinfo();
                        //characterinfo.Id = baCharacterInfo.Id;
                        //characterinfo.PS_Character_Pkey = baCharacterInfo.PS_Character_Pkey;
                        //characterinfo.PS_Character_Name = baCharacterInfo.PS_Character_Name;
                        //characterinfo.PS_Character_IsActive = baCharacterInfo.PS_Character_IsActive;
                        //characterinfo.PS_Character_CreatedDate = baCharacterInfo.PS_Character_CreatedDate;
                        //characterinfo.PS_Character_OperationType = baCharacterInfo.PS_Character_OperationType;
                        //characterinfo.IsActive = baCharacterInfo.IsActive;
                        obj.PS_Character_Name = baCharacterInfo.PS_Character_Name;
                        obj.IsActive = baCharacterInfo.IsActive;
                        db.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool Delete(int Id)
        {
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.CharacterInfos.Where(p => p.PS_Character_Pkey == Id).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.IsActive = false;
                        db.SaveChanges();

                    }
                    return true;

                }
            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}
