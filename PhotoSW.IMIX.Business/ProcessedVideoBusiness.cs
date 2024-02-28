using PhotoSW.CF.DataLayer.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
    public class ProcessedVideoBusiness// : BaseBusiness
    {

        public PhotoSW.IMIX.Model.FilePhotoInfo GetFileInfo(int photos_Key)
        {
            try
                {
                var obj = baFilePhotoInfo.GetFilePhotoInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.FilePhotoInfo()
                        {
                        Photo_RFID = p.Photo_RFID,
                        FileName = p.FileName,
                        CreatedOn = p.CreatedOn,
                        HotFolderPath = p.HotFolderPath
                        }).FirstOrDefault();
                return obj;
                }
            catch
                {
                return new PhotoSW.IMIX.Model.FilePhotoInfo();
                }
          //  return new Model.FilePhotoInfo();
        }
        public PhotoSW.IMIX.Model.ProcessedVideoInfo GetProcessedVideoDetails(int VideoId)
        {         
            return new Model.ProcessedVideoInfo();
        }
        public List<PhotoSW.IMIX.Model.ProcessedVideoInfo> GetProcessedVideosByPackageId(int packageID)
        {
            return new List<Model.ProcessedVideoInfo>();
        }
        public List<PhotoSW.IMIX.Model.VideoProducts> GetVideoPackages()
        {
            return new List<Model.VideoProducts>();
        }
        public int SaveProcessedVideoAndDetails(PhotoSW.IMIX.Model.ProcessedVideoInfo processedVideo,
            List<PhotoSW.IMIX.Model.ProcessedVideoDetailsInfo> lstPVDetails)
        {
            return 0;
        }
    }
}
