using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.BAL;
namespace PhotoSW.IMIX.Business
{
   public class BackgroundBusiness
   {
       public bool DeleteBackGround(int bgID)
       { 
           return false; 
       }
       public List<PhotoSW.IMIX.Model.BackGroundInfo> GetBackgoundDetails()
       {
           try
           {
               var obj = baBackGroundInfo.GetBackGroundInfoData().Select(p => new PhotoSW.IMIX.Model.BackGroundInfo
               {
                   DG_Background_pkey = (int)p.Id,
                   DG_Product_Id = p.ProductId,
                   DG_BackGround_Image_Name = p.BackgroundImageName,
                   DG_BackGround_Image_Display_Name = p.BackgroundImageDisplayName,
                   DG_BackGround_Group_Id = p.BackgroundGroupId,
                   SyncCode = p.SyncCode,
                   IsSynced = p.IsSynced,
                   DG_BackgroundPath = p.BackgroundPath,
                   DG_Background_IsActive = p.BackgroundIsActive,
                   CreatedBy = p.CreatedBy,
                   ModifiedBy = p.ModifiedBy,
                   CreatedDate = p.CreatedDate,
                   ModifiedDate = p.ModifiedDate,
               }).ToList();
               return obj;
           }
           catch (Exception)
           {

               return new List<Model.BackGroundInfo>();
           }
       }
       public List<PhotoSW.IMIX.Model.BackGroundInfo> GetBackgoundDetails(int productId)
       {
           try
           {
               var obj = baBackGroundInfo.GetBackGroundInfoData().Where(p => p.ProductId == productId).Select(p => new PhotoSW.IMIX.Model.BackGroundInfo
               {
                   DG_Background_pkey = (int)p.Id,
                   DG_Product_Id = p.ProductId,
                   DG_BackGround_Image_Name = p.BackgroundImageName,
                   DG_BackGround_Image_Display_Name = p.BackgroundImageDisplayName,
                   DG_BackGround_Group_Id = p.BackgroundGroupId,
                   SyncCode = p.SyncCode,
                   IsSynced = p.IsSynced,
                   DG_BackgroundPath = p.BackgroundPath,
                   DG_Background_IsActive = p.BackgroundIsActive,
                   CreatedBy = p.CreatedBy,
                   ModifiedBy = p.ModifiedBy,
                   CreatedDate = p.CreatedDate,
                   ModifiedDate = p.ModifiedDate,
               }).ToList();
               return obj;
           }
           catch (Exception)
           {

               return new List<Model.BackGroundInfo>();
           }
       }
       public List<PhotoSW.IMIX.Model.BackGroundInfo> GetBackgoundDetailsALL()
       {
           try
           {
              var obj= baBackGroundInfo.GetBackGroundInfoData().Select(p => new PhotoSW.IMIX.Model.BackGroundInfo
               {
                   DG_Background_pkey =(int) p.Id,
                   DG_Product_Id = p.ProductId,
                   DG_BackGround_Image_Name = p.BackgroundImageName,
                   DG_BackGround_Image_Display_Name = p.BackgroundImageDisplayName,
                   DG_BackGround_Group_Id = p.BackgroundGroupId,
                   SyncCode = p.SyncCode,
                   IsSynced = p.IsSynced,
                   DG_BackgroundPath = p.BackgroundPath,
                   DG_Background_IsActive = p.BackgroundIsActive,
                   CreatedBy = p.CreatedBy,
                   ModifiedBy = p.ModifiedBy,
                   CreatedDate = p.CreatedDate,
                   ModifiedDate = p.ModifiedDate,
               }).ToList();
              return obj;
           }
           catch (Exception)
           {
               
               return new List<Model.BackGroundInfo>();
           }
           //List<PhotoSW.IMIX.Model.BackGroundInfo> obj = new List<Model.BackGroundInfo>();
           //return obj;
       }
       public string GetBackGroundFileName(int productId, int BgGroupId)
       {
           try
           {
               var obj = baBackGroundInfo.GetBackGroundInfoData().Where(p => p.ProductId == productId && p.BackgroundGroupId == BgGroupId).FirstOrDefault();

               return obj.BackgroundImageName;
           }
           catch (Exception)
           {

               return "";
           }
       }
       public int GetProductTypeforBackgorund(string bakgroundName)
       {
           try
           {
               var obj = baBackGroundInfo.GetBackGroundInfoData().Where(p => p.BackgroundImageName == bakgroundName).FirstOrDefault();

               return obj.ProductId;
           }
           catch (Exception)
           {

               return 0;
           }
       }
       public int SetBackGroundDetails(int productid, string backgroundname,
           string backgrounddisplayname, string SyncCode, bool isActive, int loggedinUser)
       { return 0; }
       public void SetBackGroundDetails(int productid, string backgroundname,
           string backgrounddisplayname, int bgid,
           string SyncCode, bool? isActive, int loggedinuser)
       {
       }
       public void UpdateBackgroundDetails(int productid, string syncCode, PhotoSW.IMIX.Model.BackGroundInfo backgroundInfo) 
       { }
  
    }
}
