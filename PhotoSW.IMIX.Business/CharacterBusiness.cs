using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.BAL;
//using PhotoSW.CF.DataLayer.Entity;
//using PhotoSW.CF.DataLayer.BAL;
using PhotoSW.IMIX.Model;
namespace PhotoSW.IMIX.Business
{
    public class CharacterBusiness
    {
        public List<PhotoSW.IMIX.Model.CharacterInfo> GetCharacter()
        {
            try
            {
                return baCharacterInfo.GetCharacterInfoData().Select(p => new PhotoSW.IMIX.Model.CharacterInfo
                {
                    DG_Character_Pkey = p.Id,
                    DG_Character_Name = p.PS_Character_Name,
                    DG_Character_IsActive = p.PS_Character_IsActive,
                    DG_Character_CreatedDate = p.PS_Character_CreatedDate,
                    DG_Character_OperationType = p.PS_Character_OperationType,
                }).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<PhotoSW.IMIX.Model.CharacterInfo> GetCharacter(PhotoSW.IMIX.Model.CharacterInfo obj)
        {
            try
            {
                var obj1 = baCharacterInfo.GetCharacterInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.CharacterInfo
                    {
                        // Id = p.Id,
                        DG_Character_Pkey = p.PS_Character_Pkey,
                        DG_Character_Name = p.PS_Character_Name,
                        DG_Character_IsActive = p.PS_Character_IsActive,
                        DG_Character_CreatedDate = p.PS_Character_CreatedDate,
                        DG_Character_OperationType = p.PS_Character_OperationType,
                        //    IsActive = p.IsActive

                    }).ToList();
                return obj1;
            }
            catch
            {
                return new List<PhotoSW.IMIX.Model.CharacterInfo>();
            }
            // return new List<PhotoSW.IMIX.Model.CharacterInfo>();
        }
        public int? GetCharacterId(string PhotographerId)
        {
            return 0;
        }
        public bool InsertCharacter(PhotoSW.IMIX.Model.CharacterInfo charInfo)
        {
            baCharacterInfo baCharacterInfo = new baCharacterInfo();
            baCharacterInfo.PS_Character_Pkey = charInfo.DG_Character_Pkey;
            baCharacterInfo.PS_Character_Name = charInfo.DG_Character_Name;
            baCharacterInfo.PS_Character_IsActive = charInfo.DG_Character_IsActive;
            baCharacterInfo.PS_Character_CreatedDate = DateTime.Now;
            baCharacterInfo.PS_Character_OperationType = charInfo.DG_Character_OperationType;
            baCharacterInfo.IsActive = Convert.ToBoolean(charInfo.DG_Character_IsActive);

            return baCharacterInfo.Insert(baCharacterInfo);
        }
        public bool UpdateCharacter(PhotoSW.IMIX.Model.CharacterInfo charInfo)
        {
            baCharacterInfo baCharacterInfo = new baCharacterInfo();
            baCharacterInfo.PS_Character_Pkey= charInfo.DG_Character_Pkey;
            baCharacterInfo.PS_Character_Name = charInfo.DG_Character_Name;
            baCharacterInfo.IsActive = Convert.ToBoolean(charInfo.DG_Character_IsActive);
            return baCharacterInfo.Update(baCharacterInfo);
        }
        public bool DeleteCharacter(PhotoSW.IMIX.Model.CharacterInfo charInfo)
        {
            return baCharacterInfo.Delete(charInfo.DG_Character_Pkey);
        }
    }
}
