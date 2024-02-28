using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.BAL;

namespace PhotoSW.IMIX.Business
    {
   public class AssociateImageBusiness : BaseBusiness
	{
	

		public bool IsUniqueCodeExists(string QRCode, bool IsAnonymousQrCodeEnabled)
	    {
        return false;
        }

		public string AssociateImage(int CodeType, string QRCode, string PhotoIds, int OverWriteStatus, bool IsAnonymousEnabled)
		{
        return "";
		}

		public void AssociateMobileImage(string QRCode, int PhotoId)
		{
		
		}

		public void AssociateVideos(int PhotoId, int VideoId)
		{
		
		}

        public void SetAssociatedImage(string KeyGenerate, string KeyNumber, string QRCode, string PhotoName)
            {
            try
                {
                baAssociatedImageInfo obj = new baAssociatedImageInfo();
                obj.KeyGenerate = KeyGenerate;
                obj.KeyNumber = KeyNumber;
                obj.QRCode = QRCode;
                obj.PS_Photos_FileName = PhotoName;
                obj.IsActive = true;

                baAssociatedImageInfo.Insert(obj);
                }
            catch
                {
                
                }
            


            }
	}
    }
