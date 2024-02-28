using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using DigiPhoto.Utility.Repository.ValueType;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class PhotoBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness ;

			public string ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness. ;

			public List<PhotoDetail> ;

			public void ()
			{
				if (4 != 0)
				{
					PhotoAccess photoAccess = new PhotoAccess(this...Transaction);
					if (!false)
					{
						this. = photoAccess.GetPhotoDetailsByPhotoIds(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<PhotoDetail> ;

			public PhotoBusiness ;

			public int ;

			public string ;

			public void ()
			{
				if (4 != 0)
				{
					PhotoAccess photoAccess = new PhotoAccess(this..Transaction);
					this. = photoAccess.GetImagesInfoForEditing(this., this.);
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public PhotoBusiness ;

			public int ;

			public int ;

			public void ()
			{
				if (4 != 0)
				{
					PhotoAccess photoAccess = new PhotoAccess(this..Transaction);
					this. = photoAccess.UpdateImageProcessedStatus(this., this.);
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness ;

			public int ;

			public string ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness. ;

			public List<PhotoDetail> ;

			public void ()
			{
				PhotoAccess photoAccess = new PhotoAccess(this...Transaction);
				this. = photoAccess.GetFilesForAutoVideoProcessing(this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public PhotoBusiness ;

			public int ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					PhotoAccess photoAccess = new PhotoAccess(this..Transaction);
					this. = photoAccess.UpdateVideoProcessedStatus(this., this.);
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness ;

			public int ;

			public int ;

			public void ()
			{
				PhotosDao expr_2D = new PhotosDao(this..Transaction);
				PhotosDao photosDao;
				if (!false)
				{
					photosDao = expr_2D;
				}
				photosDao.DeletePhotoGroupBySubStoreIdAndDays(this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public PhotoBusiness ;

			public int ;

			public void ()
			{
				do
				{
					PhotosDao photosDao;
					if (!false)
					{
						photosDao = new PhotosDao(this..Transaction);
					}
					this. = photosDao.DelPhotoGroupBySubstoreId(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness ;

			public string ;

			public void ()
			{
				PhotosDao photosDao = new PhotosDao(this..Transaction);
				photosDao.UpdateArchiveByFileName(this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public int ;

			public PhotoBusiness ;

			public int ;

			public string ;

			public string ;

			public DateTime ;

			public string ;

			public string ;

			public int ;

			public string ;

			public string ;

			public DateTime? ;

			public int? ;

			public int ;

			public int? ;

			public void ()
			{
				PhotosDao photosDao = new PhotosDao(this..Transaction);
				this. = photosDao.InsertPhotoDetails(this., this., this., this., this., this., this., this., this., this., this., this., new int?(this.), this., null, new bool?(false), new int?(1), new int?(0), null, new int?(0), false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotosDao ;

			public int ;

			public int ;

			public string ;

			public string ;

			public DateTime ;

			public string ;

			public string ;

			public int ;

			public string ;

			public string ;

			public DateTime? ;

			public int? ;

			public int? ;

			public void ()
			{
				this. = this..InsertPhotoDetails(this., this., this., this., this., this., this., this., this., this., this., this., new int?(0), this., null, new bool?(false), new int?(1), new int?(0), null, new int?(0), false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public int ;

			public PhotoBusiness ;

			public int ;

			public string ;

			public string ;

			public DateTime ;

			public string ;

			public string ;

			public int ;

			public string ;

			public string ;

			public DateTime? ;

			public int? ;

			public int ;

			public int? ;

			public long? ;

			public bool ;

			public int? ;

			public int? ;

			public string ;

			public int ;

			public bool ;

			public void ()
			{
				PhotosDao expr_D9 = new PhotosDao(this..Transaction);
				PhotosDao photosDao;
				if (!false)
				{
					photosDao = expr_D9;
				}
				this. = photosDao.InsertPhotoDetails(this., this., this., this., this., this., this., this., this., this., this., this., new int?(this.), this., this., new bool?(this.), this., this., this., new int?(this.), this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness ;

			public long ;

			public object ;

			public string ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness. ;

			public bool ;

			public void ()
			{
				PhotosDao photosDao = new PhotosDao(this...Transaction);
				if (6 != 0)
				{
					this. = photosDao.UpdateCropedPhotos(this...ToInt32(false), this...ToBoolean(false), this..);
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness. ;

			public PhotoInfo ;

			public void ()
			{
				if (4 != 0)
				{
					PhotosDao photosDao = new PhotosDao(this...Transaction);
					if (!false)
					{
						this. = photosDao.GetPhotosByPkey(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoInfo ;

			public PhotoBusiness ;

			public string ;

			public void ()
			{
				if (4 != 0)
				{
					PhotosDao photosDao = new PhotosDao(this..Transaction);
					this. = photosDao.GetPhotosByPkey(this..ToInt32(false));
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoInfo ;

			public PhotoBusiness ;

			public string ;

			public void ()
			{
				if (4 != 0)
				{
					PhotosDao photosDao = new PhotosDao(this..Transaction);
					this. = photosDao.GetPhotosByPkey(this..ToInt32(false));
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ModratePhotoInfo ;

			public PhotoBusiness ;

			public long ;

			public void ()
			{
				do
				{
					PhotosDao photosDao;
					if (!false)
					{
						photosDao = new PhotosDao(this..Transaction);
					}
					this. = photosDao.GetModeratePhotos(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<ModratePhotoInfo> ;

			public PhotoBusiness ;

			public void ()
			{
				PhotosDao expr_2F = new PhotosDao(this..Transaction);
				PhotosDao photosDao;
				if (!false)
				{
					photosDao = expr_2F;
				}
				this. = photosDao.GetModeratePhotos(null);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness ;

			public long ;

			public void ()
			{
				PhotosDao photosDao = new PhotosDao(this..Transaction);
				photosDao.DeleteModeratePhotosById(this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public long ;

			public long ;

			public List<PhotoInfo> ;

			public PhotoBusiness ;

			public string ;

			public long ;

			public int ;

			public bool ;

			public long ;

			public int ;

			public int ;

			public int ;

			public void ()
			{
				PhotosDao photosDao = new PhotosDao(this..Transaction);
				this. = photosDao.SelectAllPhotosforSearch(this., this., this., this., this., this., this., out this., out this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness ;

			public long ;

			public bool ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness. ;

			public bool ;

			public void ()
			{
				PhotosDao photosDao = new PhotosDao(this...Transaction);
				this. = photosDao.UpdGreenPhotos(this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness ;

			public int ;

			public int ;

			public void ()
			{
				do
				{
					PhotosDao photosDao;
					if (!false)
					{
						photosDao = new PhotosDao(this..Transaction);
					}
					photosDao.InsertModerateImage(this., this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public PhotoInfo ;

			public PhotoBusiness ;

			public void ()
			{
				do
				{
					PhotosDao photosDao;
					if (!false)
					{
						photosDao = new PhotosDao(this..Transaction);
					}
					this. = photosDao.UpdatePhotoEffects(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness ;

			public int ;

			public void ()
			{
				PhotosDao photosDao = new PhotosDao(this..Transaction);
				photosDao.InsertPreviewCounter(this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoInfo ;

			public bool ;

			public PhotoBusiness ;

			public void ()
			{
				do
				{
					PhotosDao photosDao;
					if (!false)
					{
						photosDao = new PhotosDao(this..Transaction);
					}
					this. = photosDao.UpdatePhotoLayering(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoInfo ;

			public PhotoBusiness ;

			public int ;

			public void ()
			{
				do
				{
					PhotosDao photosDao;
					if (!false)
					{
						photosDao = new PhotosDao(this..Transaction);
					}
					this. = photosDao.GetPhotosByPkey(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoInfo ;

			public bool ;

			public PhotoBusiness ;

			public void ()
			{
				do
				{
					PhotosDao photosDao;
					if (!false)
					{
						photosDao = new PhotosDao(this..Transaction);
					}
					this. = photosDao.UpdatePhotoLayering(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness ;

			public string ;

			public int ;

			public bool ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness. ;

			public bool ;

			public void ()
			{
				PhotosDao photosDao = new PhotosDao(this...Transaction);
				this. = photosDao.UpdateEffectsonPhoto(this.., this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness ;

			public int ;

			public string ;

			public string ;

			public bool ;

			public bool ;

			public bool ;

			public string ;

			public string ;

			public void ()
			{
				PhotosDao photosDao = new PhotosDao(this..Transaction);
				photosDao.UpdateEffectsSpecPrint(this., this., this., this., this., this., this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness ;

			public int ;

			public string ;

			public void ()
			{
				PhotosDao expr_2D = new PhotosDao(this..Transaction);
				PhotosDao photosDao;
				if (!false)
				{
					photosDao = expr_2D;
				}
				photosDao.UpdateOnlineQRCodeForPhoto(this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					PhotosDao photosDao = new PhotosDao(this...Transaction);
					if (!false)
					{
						this. = photosDao.DeletePhotoByPhotoId(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness ;

			public string ;

			public string ;

			public bool ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness. ;

			public PhotoBusiness. ;

			public long ;

			public void ()
			{
				CardTypeDao cardTypeDao = new CardTypeDao(this...Transaction);
				this. = cardTypeDao.InsertImageAssociationInfo(this.., this.., this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness. ;

			public PhotoBusiness. ;

			public long ;

			public void ()
			{
				CardTypeDao cardTypeDao = new CardTypeDao(this...Transaction);
				this. = cardTypeDao.InsertImageAssociationInfo(this.., this.., this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness ;

			public int ;

			public string ;

			public string ;

			public bool ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness. ;

			public long ;

			public void ()
			{
				CardTypeDao cardTypeDao = new CardTypeDao(this...Transaction);
				this. = cardTypeDao.InsertImageAssociationInfo(this.., this.., this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness ;

			public string ;

			public bool ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness. ;

			public List<PhotoInfo> ;

			public void ()
			{
				PhotosDao photosDao = new PhotosDao(this...Transaction);
				this. = photosDao.SelectMapImagesBYQRCode(this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness ;

			public string ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness. ;

			public List<PhotoInfo> ;

			public void ()
			{
				if (4 != 0)
				{
					PhotosDao photosDao = new PhotosDao(this...Transaction);
					if (!false)
					{
						this. = photosDao.SelectSavedGroupImages(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<PhotoInfo> ;

			public PhotoBusiness ;

			public DateTime? ;

			public DateTime? ;

			public int? ;

			public int? ;

			public string ;

			public void ()
			{
				PhotosDao photosDao = new PhotosDao(this..Transaction);
				this. = photosDao.GetPhotoList(this., this., this., this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public int? ;

			public long ;

			public long ;

			public bool ;

			public List<PhotoInfo> ;

			public PhotoBusiness ;

			public int ;

			public int ;

			public bool ;

			public int ;

			public void ()
			{
				PhotosDao photosDao = new PhotosDao(this..Transaction);
				this. = photosDao.GetAllPhotosByPage(this., this., this., this., out this., out this., out this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public int? ;

			public long ;

			public PhotoBusiness ;

			public int ;

			public void ()
			{
				if (4 != 0)
				{
					PhotosDao photosDao = new PhotosDao(this..Transaction);
					photosDao.GetMaxId(this., out this., this.);
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoInfo ;

			public PhotoBusiness ;

			public string ;

			public int ;

			public void ()
			{
				if (4 != 0)
				{
					PhotosDao photosDao = new PhotosDao(this..Transaction);
					this. = photosDao.GetCheckPhotos(this., this.);
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoInfo ;

			public PhotoBusiness ;

			public int ;

			public void ()
			{
				do
				{
					PhotosDao photosDao;
					if (!false)
					{
						photosDao = new PhotosDao(this..Transaction);
					}
					this. = photosDao.GetLastGeneratedNumber(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness ;

			public int ;

			public string ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness. ;

			public PhotoInfo ;

			public void ()
			{
				PhotosDao photosDao = new PhotosDao(this...Transaction);
				this. = photosDao.GetNextPreviousPhoto(this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<PhotoInfo> ;

			public PhotoBusiness ;

			public void ()
			{
				PhotosDao photosDao = new PhotosDao(this..Transaction);
				this. = photosDao.GetArchiveImages();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoInfo ;

			public PhotoBusiness ;

			public long ;

			public void ()
			{
				do
				{
					PhotosDao photosDao;
					if (!false)
					{
						photosDao = new PhotosDao(this..Transaction);
					}
					this. = photosDao.GetPhotoNameByPhotoID(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<PhotoDetail> ;

			public PhotoBusiness ;

			public PhotoDetail ;

			public void ()
			{
				do
				{
					PhotoAccess photoAccess;
					if (!false)
					{
						photoAccess = new PhotoAccess(this..Transaction);
					}
					this. = photoAccess.GetPhotoDetailsByPhotoIds(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoInfo ;

			public PhotoBusiness ;

			public long ;

			public void ()
			{
				do
				{
					PhotosDao photosDao;
					if (!false)
					{
						photosDao = new PhotosDao(this..Transaction);
					}
					this. = photosDao.GetPhotoRFIDByPhotoID(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<PhotoInfo> ;

			public PhotoBusiness ;

			public string ;

			public void ()
			{
				do
				{
					PhotosDao photosDao;
					if (!false)
					{
						photosDao = new PhotosDao(this..Transaction);
					}
					this. = photosDao.GetPhotoRFIDByPhotoIDList(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<PhotoInfo> ;

			public PhotoBusiness ;

			public int ;

			public string ;

			public void ()
			{
				if (4 != 0)
				{
					PhotosDao photosDao = new PhotosDao(this..Transaction);
					this. = photosDao.GetPhotosBasedonRFID(this., this.);
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<PhotoGraphersInfo> ;

			public PhotoBusiness ;

			public void ()
			{
				PhotosDao photosDao = new PhotosDao(this..Transaction);
				this. = photosDao.GetPhotoGrapher();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DG_PhotoGroupInfo ;

			public PhotoBusiness ;

			public string ;

			public void ()
			{
				do
				{
					PhotosDao photosDao;
					if (!false)
					{
						photosDao = new PhotosDao(this..Transaction);
					}
					this. = photosDao.GetGroupName(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness ;

			public string ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PhotoBusiness. ;

			public List<string> ;

			public void ()
			{
				if (4 != 0)
				{
					IMixImageAssociationDao mixImageAssociationDao = new IMixImageAssociationDao(this...Transaction);
					if (!false)
					{
						this. = mixImageAssociationDao.GetQrOrBarCodeByPhotoID(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public PhotoBusiness ;

			public string ;

			public void ()
			{
				do
				{
					PhotosDao photosDao;
					if (!false)
					{
						photosDao = new PhotosDao(this..Transaction);
					}
					this. = photosDao.DeletePhotoByName(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DataTable ;

			public PhotoBusiness ;

			public void ()
			{
				PhotosDao photosDao = new PhotosDao(this..Transaction);
				photosDao.SaveGroupData(this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public int ;

			public PhotoBusiness ;

			public void ()
			{
				PhotosDao photosDao = new PhotosDao(this..Transaction);
				this. = photosDao.GetMaxPhotoIdsequence();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public int ;

			public PhotoBusiness ;

			public long ;

			public long ;

			public string ;

			public void ()
			{
				while (true)
				{
					PhotosDao photosDao;
					if (-1 != 0)
					{
						photosDao = new PhotosDao(this..Transaction);
						goto IL_10;
					}
					IL_33:
					if (!false)
					{
						if (false)
						{
							continue;
						}
						if (5 != 0)
						{
							break;
						}
					}
					IL_10:
					this. = photosDao.GetMaxUserIdsequence(this., this., this.);
					goto IL_33;
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<PhotoCaptureInfo> ;

			public PhotoBusiness ;

			public int ;

			public void ()
			{
				do
				{
					PhotoAccess photoAccess;
					if (!false)
					{
						photoAccess = new PhotoAccess(this..Transaction);
					}
					this. = photoAccess.GetPhotoCapturedetails(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public PhotoBusiness ;

			public int ;

			public int ;

			public void ()
			{
				if (4 != 0)
				{
					PhotosDao photosDao = new PhotosDao(this..Transaction);
					this. = photosDao.ResetImageProcessedStatus(this., this.);
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public string ;

			public PhotoBusiness ;

			public string ;

			public void ()
			{
				do
				{
					PhotosDao photosDao;
					if (!false)
					{
						photosDao = new PhotosDao(this..Transaction);
					}
					this. = photosDao.GetPhotoPlayerScore(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public string ;

			public PhotoBusiness ;

			public int ;

			public void ()
			{
				do
				{
					PhotosDao photosDao;
					if (!false)
					{
						photosDao = new PhotosDao(this..Transaction);
					}
					this. = photosDao.GetVideoFrameCropRatio(this.);
				}
				while (false);
			}
		}

		[NonSerialized]
		internal static SmartAssembly.Delegates.GetString ;

		public List<PhotoDetail> GetPhotoDetailsByPhotoIds(string PhotoIds)
		{
			if (!false && -1 != 0)
			{
			}
			2. = PhotoIds;
			2. = this;
			List<PhotoDetail> result;
			try
			{
				PhotoBusiness. 2 = new PhotoBusiness.();
				if (!false)
				{
					2. = 2;
				}
				2. = new List<PhotoDetail>();
				if (6 != 0)
				{
					this.operation = new BaseBusiness.TransactionMethod(2.2);
					if (!false)
					{
						base.Start(false);
						result = 2.;
					}
				}
			}
			catch
			{
				result = null;
			}
			return result;
		}

		public List<PhotoDetail> GetImagesInfoForEditing(int SubStoreId, string PosName)
		{
			BaseBusiness.TransactionMethod transactionMethod = null;
			PhotoBusiness.  = new PhotoBusiness.();
			. = SubStoreId;
			. = PosName;
			. = this;
			. = null;
			List<PhotoDetail> ;
			try
			{
				. = new List<PhotoDetail>();
				if (transactionMethod == null)
				{
					transactionMethod = new BaseBusiness.TransactionMethod(.);
				}
				this.operation = transactionMethod;
				base.Start(false);
				 = .;
			}
			catch
			{
				. = new List<PhotoDetail>();
				 = .;
			}
			return ;
		}

		public bool UpdateImageProcessedStatus(int PhotoId, int ProcessedStatus)
		{
			BaseBusiness.TransactionMethod transactionMethod;
			if (6 != 0)
			{
				if (!false)
				{
					transactionMethod = null;
				}
				. = this;
			}
			. = false;
			bool 2;
			try
			{
				while (true)
				{
					if (transactionMethod == null)
					{
						transactionMethod = new BaseBusiness.TransactionMethod(.2);
					}
					this.operation = transactionMethod;
					base.Start(false);
					if (!false)
					{
						2 = .;
						if (6 != 0)
						{
							break;
						}
					}
				}
			}
			catch
			{
				do
				{
					2 = .;
				}
				while (6 == 0);
			}
			return 2;
		}

		public List<PhotoDetail> GetFilesForAutoVideoProcessing(int substoreID, string PosName)
		{
			PhotoBusiness.  = new PhotoBusiness.();
			List<PhotoDetail> result;
			do
			{
				. = substoreID;
				if (!false)
				{
					. = PosName;
					. = this;
					try
					{
						PhotoBusiness.  = new PhotoBusiness.();
						. = ;
						. = new List<PhotoDetail>();
						this.operation = new BaseBusiness.TransactionMethod(.);
						base.Start(false);
						if (6 != 0)
						{
							result = .;
						}
					}
					catch
					{
						do
						{
							result = null;
						}
						while (2 == 0);
					}
				}
			}
			while (3 == 0);
			return result;
		}

		public bool UpdateVideoProcessedStatus(int PhotoId, bool ProcessedStatus)
		{
			BaseBusiness.TransactionMethod transactionMethod;
			if (6 != 0)
			{
				if (!false)
				{
					transactionMethod = null;
				}
				. = this;
			}
			. = false;
			bool 2;
			try
			{
				while (true)
				{
					if (transactionMethod == null)
					{
						transactionMethod = new BaseBusiness.TransactionMethod(.2);
					}
					this.operation = transactionMethod;
					base.Start(false);
					if (!false)
					{
						2 = .;
						if (6 != 0)
						{
							break;
						}
					}
				}
			}
			catch
			{
				do
				{
					2 = .;
				}
				while (6 == 0);
			}
			return 2;
		}

		public bool TruncatePhotoGroupTablefordate(int days, int substoreID)
		{
			BaseBusiness.TransactionMethod transactionMethod = null;
			PhotoBusiness.  = new PhotoBusiness.();
			if (5 != 0)
			{
				. = days;
				. = substoreID;
			}
			. = this;
			bool result;
			try
			{
				if (transactionMethod == null)
				{
					transactionMethod = new BaseBusiness.TransactionMethod(.);
				}
				this.operation = transactionMethod;
				do
				{
					result = true;
				}
				while (6 == 0);
			}
			catch (Exception)
			{
				do
				{
					result = false;
				}
				while (false);
			}
			return result;
		}

		public bool TruncatePhotoGroupTable(int days, int substoreID)
		{
			BaseBusiness.TransactionMethod transactionMethod;
			do
			{
				if (4 != 0)
				{
					transactionMethod = null;
				}
				. = this;
			}
			while (false);
			. = false;
			try
			{
				PhotoInfo photoInfo = new PhotoInfo();
				if (transactionMethod == null)
				{
					transactionMethod = new BaseBusiness.TransactionMethod(.);
				}
				this.operation = transactionMethod;
				base.Start(false);
				if (photoInfo != null && photoInfo.DG_IsCodeType)
				{
					. = true;
				}
			}
			catch
			{
				. = false;
			}
			return .;
		}

		public void SetArchiveDetails(string imgname)
		{
			PhotoBusiness. ;
			while (true)
			{
				PhotoBusiness. expr_3C = new PhotoBusiness.();
				if (!false)
				{
					 = expr_3C;
				}
				while (!false)
				{
					. = imgname;
					if (4 != 0)
					{
						goto Block_1;
					}
				}
			}
			Block_1:
			. = this;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
		}

		public int SetPhotoDetails(int subStoreId, string DG_Photos_RFID, string DG_Photos_FileName, DateTime DG_Photos_CreatedOn, string userid, string imgmetadata, int locationid, string photolayer, string DG_Photos_Effects, DateTime? DateTaken, int? RfidScanType, int IsImageProcessed, int? CharacterID)
		{
			while (true)
			{
				PhotoBusiness ;
				string ;
				string ;
				DateTime ;
				string ;
				string ;
				int ;
				string ;
				string ;
				DateTime? ;
				int? ;
				int ;
				int? ;
				while (true)
				{
					 = DG_Photos_RFID;
					 = DG_Photos_FileName;
					 = DG_Photos_CreatedOn;
					 = userid;
					 = imgmetadata;
					if (false)
					{
						break;
					}
					 = locationid;
					 = photolayer;
					while (true)
					{
						 = DG_Photos_Effects;
						 = DateTaken;
						if (false)
						{
							break;
						}
						 = RfidScanType;
						 = IsImageProcessed;
						 = CharacterID;
						 = this;
						if (!false)
						{
							goto Block_2;
						}
					}
				}
			}
			Block_2:
			2. = 0;
			this.operation = new BaseBusiness.TransactionMethod(2.);
			base.Start(false);
			return 2.;
		}

		public int SetPhotoDetails(int subStoreId, string DG_Photos_RFID, string DG_Photos_FileName, DateTime DG_Photos_CreatedOn, string userid, string imgmetadata, int locationid, string photolayer, string DG_Photos_Effects, DateTime? DateTaken, int? RfidScanType, int? CharacterID)
		{
			PhotoBusiness.  = new PhotoBusiness.();
			. = subStoreId;
			. = DG_Photos_RFID;
			. = DG_Photos_FileName;
			while (true)
			{
				. = DG_Photos_CreatedOn;
				IL_43:
				while (2 != 0)
				{
					. = userid;
					if (!false)
					{
						. = imgmetadata;
						. = locationid;
						goto IL_61;
					}
					goto IL_BC;
					IL_69:
					. = DG_Photos_Effects;
					do
					{
						. = DateTaken;
						. = RfidScanType;
						. = CharacterID;
						. = new PhotosDao(base.Transaction);
						if (5 == 0)
						{
							goto IL_61;
						}
						. = 0;
						if (false)
						{
							goto IL_43;
						}
					}
					while (7 == 0);
					this.operation = new BaseBusiness.TransactionMethod(.);
					goto IL_BC;
					IL_61:
					. = photolayer;
					goto IL_69;
					IL_BC:
					if (!false)
					{
						goto Block_6;
					}
					goto IL_69;
				}
			}
			Block_6:
			base.Start(false);
			return .;
		}

		public int SetPhotoDetails(int subStoreId, string DG_Photos_RFID, string DG_Photos_FileName, DateTime DG_Photos_CreatedOn, string userid, string imgmetadata, int locationid, string photolayer, string DG_Photos_Effects, DateTime? DateTaken, int? RfidScanType, int IsImageProcessed, int? CharacterID, long? VideoLength, bool IsVideoProcessed, int? mediatype = 1, int? ParentImageId = 0, string OriginalFileName = null, int SemiOrderProfileId = 0, bool IsCroped = false)
		{
			PhotoBusiness.  = new PhotoBusiness.();
			. = subStoreId;
			. = DG_Photos_RFID;
			. = DG_Photos_FileName;
			. = DG_Photos_CreatedOn;
			. = userid;
			. = imgmetadata;
			do
			{
				. = locationid;
				. = photolayer;
				. = DG_Photos_Effects;
				. = DateTaken;
				. = RfidScanType;
				. = IsImageProcessed;
				. = CharacterID;
			}
			while (5 == 0);
			. = VideoLength;
			. = IsVideoProcessed;
			. = mediatype;
			. = ParentImageId;
			. = OriginalFileName;
			. = SemiOrderProfileId;
			. = IsCroped;
			. = this;
			. = 0;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool SaveIsCropedPhotos(long PhotoId, object value, string operation)
		{
			bool result;
			do
			{
				if (false)
				{
					return result;
				}
				object  = value;
				string  = operation;
			}
			while (false);
			. = this;
			try
			{
				PhotoBusiness.  = new PhotoBusiness.();
				. = ;
				if (6 != 0)
				{
					. = false;
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
				}
				result = .;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public PhotoInfo GetPhotoDetailsbyPhotoId(int PhotoId)
		{
			if (!false)
			{
			}
			. = PhotoId;
			. = this;
			PhotoInfo 2;
			try
			{
				PhotoBusiness. ;
				if (!false)
				{
					PhotoBusiness. expr_70 = new PhotoBusiness.();
					if (true)
					{
						 = expr_70;
					}
				}
				while (true)
				{
					. = ;
					while (true)
					{
						. = new PhotoInfo();
						if (7 == 0)
						{
							goto IL_67;
						}
						if (3 == 0)
						{
							break;
						}
						if (!false)
						{
							goto Block_7;
						}
					}
				}
				Block_7:
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				IL_67:
				2 = .;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return 2;
		}

		public string GetFileNameByPhotoID(string PhotoID)
		{
			PhotoBusiness.  = new PhotoBusiness.();
			while (true)
			{
				. = PhotoID;
				if (!false)
				{
					. = this;
					goto IL_2B;
				}
				IL_75:
				if (6 != 0 && . != null)
				{
					if (!false)
					{
						goto Block_5;
					}
					continue;
				}
				else if (3 != 0)
				{
					goto Block_6;
				}
				IL_2B:
				bool arg_49_0 = ..Contains(PhotoBusiness.(981));
				while (!arg_49_0)
				{
					. = new PhotoInfo();
					this.operation = new BaseBusiness.TransactionMethod(.);
					arg_49_0 = base.Start(false);
					if (6 != 0)
					{
						goto IL_75;
					}
				}
				break;
			}
			return null;
			Block_5:
			return ..DG_Photos_FileName;
			Block_6:
			return null;
		}

		public PhotoInfo GetPhotoByPhotoID(string PhotoID)
		{
			PhotoBusiness. ;
			while (true)
			{
				 = new PhotoBusiness.();
				. = PhotoID;
				. = this;
				bool arg_49_0 = ..Contains(PhotoBusiness.(981));
				if (!false)
				{
					if (arg_49_0)
					{
						break;
					}
					if (!false)
					{
						. = new PhotoInfo();
					}
					if (false)
					{
						break;
					}
					if (false)
					{
						continue;
					}
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
				}
				if (4 != 0)
				{
					goto Block_4;
				}
			}
			return null;
			Block_4:
			return .;
		}

		public bool GetModeratePhotos(long PhotoId)
		{
			int arg_51_0;
			if (!false)
			{
				PhotoBusiness.  = new PhotoBusiness.();
				. = PhotoId;
				if (8 != 0)
				{
					if (false)
					{
						goto IL_46;
					}
					. = this;
					. = new ModratePhotoInfo();
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				arg_51_0 = (base.Start(false) ? 1 : 0);
				if (false)
				{
					return arg_51_0 != 0;
				}
				IL_46:
				if (. != null)
				{
					return true;
				}
			}
			arg_51_0 = 0;
			return arg_51_0 != 0;
		}

		public List<ModratePhotoInfo> GetModeratePhotos()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = new List<ModratePhotoInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public void immoderate(long PhotoId)
		{
			PhotoBusiness. ;
			while (true)
			{
				PhotoBusiness. expr_3C = new PhotoBusiness.();
				if (!false)
				{
					 = expr_3C;
				}
				while (!false)
				{
					. = PhotoId;
					if (4 != 0)
					{
						goto Block_1;
					}
				}
			}
			Block_1:
			. = this;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
		}

		public List<PhotoInfo> GetAllPhotosforSearch(string substoreId, long imgRfid, int NoOfImg, bool isAnyRfidSearch, long StartIndex, int RfidSearch, int NewRecord, out long maxPhotoId, out long minPhotoId, int mediaType)
		{
			PhotoBusiness.  = new PhotoBusiness.();
			do
			{
				. = substoreId;
			}
			while (-1 == 0);
			. = imgRfid;
			. = NoOfImg;
			. = isAnyRfidSearch;
			. = StartIndex;
			. = RfidSearch;
			. = NewRecord;
			. = mediaType;
			. = this;
			. = 0L;
			. = 0L;
			. = new List<PhotoInfo>();
			new List<string>();
			..Split(new char[]
			{
				','
			}).ToList<string>();
			do
			{
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				maxPhotoId = .;
			}
			while (false);
			minPhotoId = .;
			return .;
		}

		public bool SaveIsGreenPhotos(long PhotoId, bool value)
		{
			PhotoBusiness.  = new PhotoBusiness.();
			bool result;
			do
			{
				. = PhotoId;
				if (!false)
				{
					. = value;
					. = this;
					try
					{
						PhotoBusiness.  = new PhotoBusiness.();
						. = ;
						. = false;
						this.operation = new BaseBusiness.TransactionMethod(.);
						base.Start(false);
						if (6 != 0)
						{
							result = .;
						}
					}
					catch (Exception)
					{
						do
						{
							result = false;
						}
						while (2 == 0);
					}
				}
			}
			while (3 == 0);
			return result;
		}

		public bool SetModerateImage(int PhotoId, int userid)
		{
			BaseBusiness.TransactionMethod transactionMethod;
			do
			{
				if (!false && -1 != 0)
				{
					transactionMethod = null;
				}
			}
			while (false);
			. = this;
			bool result;
			try
			{
				if (transactionMethod == null)
				{
					transactionMethod = new BaseBusiness.TransactionMethod(.);
				}
				this.operation = transactionMethod;
				base.Start(false);
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public bool SaveCroppedPhotoInfo(long PhotoId, object value, string effects)
		{
			bool result;
			try
			{
				while (true)
				{
					if (!false)
					{
					}
					if (!false)
					{
						. = this;
						. = false;
						while (true)
						{
							. = new PhotoInfo();
							..DG_Photos_pkey = PhotoId.ToInt32(false);
							while (true)
							{
								if (value == null)
								{
									goto IL_74;
								}
								if (!false)
								{
									..DG_Photos_IsCroped = new bool?(bool.Parse(value.ToString()));
									goto IL_74;
								}
								IL_80:
								if (!false)
								{
									break;
								}
								continue;
								IL_74:
								..DG_Photos_Effects = effects;
								goto IL_80;
							}
							this.operation = new BaseBusiness.TransactionMethod(.);
							base.Start(false);
							result = .;
							if (false)
							{
								break;
							}
							if (!false)
							{
								goto Block_7;
							}
						}
					}
				}
				Block_7:;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public void SetPreviewCounter(int PhotoId)
		{
			if (4 != 0)
			{
				PhotoBusiness. expr_36 = new PhotoBusiness.();
				PhotoBusiness. ;
				if (!false)
				{
					 = expr_36;
				}
				do
				{
					if (3 != 0)
					{
						. = PhotoId;
					}
					. = this;
				}
				while (false);
				this.operation = new BaseBusiness.TransactionMethod(.);
			}
		}

		public bool UpdateLayering(int PhotoId, string value)
		{
			bool result;
			try
			{
				PhotoBusiness.  = new PhotoBusiness.();
				. = this;
				. = new PhotoInfo();
				..DG_Photos_pkey = PhotoId.ToInt32(false);
				..DG_Photos_Layering = value;
				..IsImageProcessed = null;
				while (true)
				{
					. = false;
					if (3 != 0)
					{
						this.operation = new BaseBusiness.TransactionMethod(.);
						base.Start(false);
						if (true)
						{
							break;
						}
					}
				}
				result = .;
			}
			catch (Exception)
			{
				do
				{
					result = false;
				}
				while (3 == 0 || false);
			}
			return result;
		}

		public int GetLocationIdByPhotoId(int PhotoId)
		{
			PhotoBusiness.  = new PhotoBusiness.();
			. = PhotoId;
			. = this;
			. = new PhotoInfo();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			int arg_A7_0;
			int num;
			while (true)
			{
				while (. != null)
				{
					while (true)
					{
						bool expr_6B = ..DG_Location_Id.HasValue;
						if (3 == 0)
						{
							break;
						}
						int arg_97_0;
						if (expr_6B)
						{
							if (-1 == 0)
							{
								break;
							}
							arg_A7_0 = (arg_97_0 = ..DG_Location_Id.ToInt32(false));
							if (!true)
							{
								return arg_A7_0;
							}
						}
						else
						{
							arg_A7_0 = (arg_97_0 = 0);
						}
						if (false)
						{
							return arg_A7_0;
						}
						num = arg_97_0;
						if (num <= 0)
						{
							return 0;
						}
						if (!false)
						{
							goto Block_7;
						}
					}
				}
				goto IL_A6;
			}
			Block_7:
			int expr_9F = arg_A7_0 = num;
			if (8 != 0)
			{
				return expr_9F;
			}
			return arg_A7_0;
			IL_A6:
			arg_A7_0 = 0;
			return arg_A7_0;
		}

		public bool UpdateLayeringForSpecPrint(int PhotoId, string value)
		{
			bool result;
			try
			{
				try
				{
					if (2 != 0)
					{
						PhotoInfo  = new PhotoInfo();
						.DG_Photos_pkey = PhotoId.ToInt32(false);
						if (false)
						{
							goto IL_6A;
						}
						.DG_Photos_Layering = value;
					}
					..IsImageProcessed = new int?(0);
					IL_6A:
					if (!false)
					{
						. = false;
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					base.Start(false);
					result = .;
				}
				catch (Exception)
				{
					result = false;
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public bool SetEffectsonPhoto(string value, int photoId, bool isgumballshow)
		{
			bool result;
			do
			{
				if (false)
				{
					return result;
				}
				int  = photoId;
				bool  = isgumballshow;
			}
			while (false);
			. = this;
			try
			{
				PhotoBusiness.  = new PhotoBusiness.();
				. = ;
				if (6 != 0)
				{
					. = false;
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
				}
				result = .;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public void UpdateEffectsSpecPrint(int photoId, string layeringdata, string ImageEffect, bool isGreenSreen, bool isCrop, bool isgumballshow, string GumBallRidetxtContent, string _qrCode)
		{
			if (-1 == 0)
			{
				goto IL_70;
			}
			PhotoBusiness.  = new PhotoBusiness.();
			. = photoId;
			. = layeringdata;
			. = ImageEffect;
			. = isGreenSreen;
			. = isCrop;
			if (false)
			{
				goto IL_70;
			}
			. = isgumballshow;
			. = GumBallRidetxtContent;
			. = _qrCode;
			IL_69:
			. = this;
			IL_70:
			this.operation = new BaseBusiness.TransactionMethod(.);
			if (3 != 0)
			{
				base.Start(false);
				return;
			}
			goto IL_69;
		}

		public void UpdateOnlineQRCodeForPhoto(int photoId, string OnlineQRCode)
		{
			PhotoBusiness. ;
			if (!false)
			{
				PhotoBusiness. expr_49 = new PhotoBusiness.();
				if (!false)
				{
					 = expr_49;
				}
				. = photoId;
			}
			while (true)
			{
				. = OnlineQRCode;
				while (true)
				{
					if (!false)
					{
						. = this;
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					base.Start(false);
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

		public bool CheckIsCodeType(int PhotoId)
		{
			int arg_4C_0;
			bool flag;
			if (!false)
			{
				int expr_04 = arg_4C_0 = 0;
				if (expr_04 != 0)
				{
					return arg_4C_0 != 0;
				}
				flag = (expr_04 != 0);
				try
				{
					PhotoInfo photoDetailsbyPhotoId = this.GetPhotoDetailsbyPhotoId(PhotoId);
					if (photoDetailsbyPhotoId == null)
					{
						goto IL_21;
					}
					IL_15:
					int arg_19_0 = photoDetailsbyPhotoId.DG_IsCodeType ? 1 : 0;
					while (arg_19_0 != 0)
					{
						int expr_1C = arg_19_0 = 1;
						if (expr_1C != 0)
						{
							flag = (expr_1C != 0);
							break;
						}
					}
					IL_21:
					if (2 == 0)
					{
						goto IL_15;
					}
				}
				catch
				{
					flag = false;
				}
			}
			arg_4C_0 = (flag ? 1 : 0);
			return arg_4C_0 != 0;
		}

		public bool DeletePhotoByPhotoId(int PhotoId)
		{
			if (!false && -1 != 0)
			{
			}
			. = PhotoId;
			. = this;
			bool result;
			try
			{
				PhotoBusiness.  = new PhotoBusiness.();
				if (!false)
				{
					. = ;
				}
				. = false;
				this.operation = new BaseBusiness.TransactionMethod(.);
				bool arg_67_0 = base.Start(false);
				if (!false && 4 != 0)
				{
					arg_67_0 = .;
				}
				result = arg_67_0;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public bool SetImageAssociationInfoForPostScan(List<int> PhotoIdList, string Format, string Code, bool IsAnonymousCodeActive)
		{
			PhotoBusiness.  = new PhotoBusiness.();
			. = Format;
			. = Code;
			. = IsAnonymousCodeActive;
			. = this;
			bool result;
			try
			{
				int arg_49_0 = . ? 1 : 0;
				int expr_FD;
				do
				{
					if (arg_49_0 != 0)
					{
						while (!false && (!. || !(. == PhotoBusiness.(2843))))
						{
							if (. && . != PhotoBusiness.(2843))
							{
								goto Block_8;
							}
							result = false;
							if (3 != 0)
							{
								goto Block_10;
							}
						}
					}
					..Substring(0, 4);
					using (List<int>.Enumerator enumerator = PhotoIdList.GetEnumerator())
					{
						while (enumerator.MoveNext() && !false)
						{
							PhotoBusiness.  = new PhotoBusiness.();
							. = enumerator.Current;
							PhotoBusiness.  = new PhotoBusiness.();
							. = ;
							if (!true)
							{
								break;
							}
							. = ;
							. = 0L;
							this.operation = new BaseBusiness.TransactionMethod(.);
							base.Start(false);
						}
					}
					expr_FD = (arg_49_0 = 1);
				}
				while (expr_FD == 0);
				result = (expr_FD != 0);
				return result;
				Block_8:
				using (List<int>.Enumerator enumerator2 = PhotoIdList.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						PhotoBusiness.  = new PhotoBusiness.();
						if (!false)
						{
							. = enumerator2.Current;
							PhotoBusiness.  = new PhotoBusiness.();
							. = ;
							do
							{
								. = ;
								. = 0L;
								this.operation = new BaseBusiness.TransactionMethod(.);
							}
							while (3 == 0);
							base.Start(false);
						}
					}
				}
				result = true;
				Block_10:;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public long SetImageAssociationInfo(int PhotoId, string Format, string Code, bool IsAnonymousCodeActive)
		{
			PhotoBusiness.  = new PhotoBusiness.();
			. = PhotoId;
			. = Format;
			. = Code;
			. = IsAnonymousCodeActive;
			long result;
			if (!false)
			{
				. = this;
				try
				{
					PhotoBusiness.  = new PhotoBusiness.();
					. = ;
					. = 0L;
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
					result = .;
				}
				catch
				{
					result = 0L;
				}
			}
			return result;
		}

		public List<PhotoInfo> GetImagesBYQRCode(string QRCode, bool IsAnonymousQrCodeEnabled)
		{
			if (4 != 0)
			{
				string ;
				bool ;
				while (4 != 0)
				{
					 = QRCode;
					if (6 != 0)
					{
						 = IsAnonymousQrCodeEnabled;
						break;
					}
				}
			}
			. = this;
			List<PhotoInfo> 2;
			try
			{
				do
				{
				}
				while (7 == 0);
				. = ;
				. = new List<PhotoInfo>();
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				2 = .;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return 2;
		}

		public List<PhotoInfo> GetSavedGroupImages(string GroupName)
		{
			if (!false && -1 != 0)
			{
			}
			. = GroupName;
			. = this;
			List<PhotoInfo> result;
			try
			{
				PhotoBusiness.  = new PhotoBusiness.();
				if (!false)
				{
					. = ;
				}
				. = new List<PhotoInfo>();
				if (6 != 0)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					if (!false)
					{
						base.Start(false);
						result = .;
					}
				}
			}
			catch (Exception)
			{
				result = new List<PhotoInfo>();
			}
			return result;
		}

		public List<PhotoInfo> GetSearchedPhoto(DateTime? fromTime, DateTime? ToTime, int? UserId, int? LocationId, string substoreId)
		{
			if (!false)
			{
				if (-1 == 0)
				{
					goto IL_1F;
				}
			}
			if (6 == 0)
			{
				goto IL_60;
			}
			. = fromTime;
			IL_1F:
			. = ToTime;
			. = UserId;
			. = LocationId;
			. = substoreId;
			do
			{
				. = this;
			}
			while (7 == 0);
			. = new List<PhotoInfo>();
			IL_60:
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public List<PhotoInfo> GetAllPhotosByPage(string substoreId, int startIndex, int pazeSize, bool isNext, out long maxPhotoId, out bool IsMoreImages, out long minPhotoId, int mediaType)
		{
			PhotoBusiness.  = new PhotoBusiness.();
			. = startIndex;
			. = pazeSize;
			. = isNext;
			do
			{
				. = mediaType;
				. = this;
				if (!. && (. == 1 || . == 0))
				{
					. = -1;
				}
				new List<PhotoInfo>();
				List<string> list = new List<string>();
				if (!string.IsNullOrEmpty(substoreId))
				{
					list = substoreId.Split(new char[]
					{
						','
					}).ToList<string>();
				}
				else
				{
					list = null;
				}
				. = null;
				. = ((list == null) ? . : new int?(list[0].ToInt32(false)));
				. = 0L;
				. = 0L;
				. = false;
				. = new List<PhotoInfo>();
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
			}
			while (false);
			maxPhotoId = .;
			minPhotoId = .;
			IsMoreImages = .;
			return .;
		}

		public void GetMaxId(string substoreId, out long maxPhotoId, int mediaType)
		{
			PhotoBusiness.  = new PhotoBusiness.();
			if (!false)
			{
				. = mediaType;
				. = this;
			}
			new List<PhotoInfo>();
			new List<string>();
			if (-1 != 0)
			{
				bool arg_47_0 = string.IsNullOrEmpty(substoreId);
				do
				{
					List<string> list;
					if (!arg_47_0 && true)
					{
						list = substoreId.Split(new char[]
						{
							','
						}).ToList<string>();
					}
					else
					{
						list = null;
					}
					. = null;
					. = ((list == null) ? . : new int?(list[0].ToInt32(false)));
					. = 0L;
					new List<PhotoInfo>();
					this.operation = new BaseBusiness.TransactionMethod(.);
					arg_47_0 = base.Start(false);
				}
				while (false || 5 == 0);
			}
			maxPhotoId = .;
		}

		public bool CheckPhotos(string Photono, int PhotographerID)
		{
			PhotoBusiness. ;
			if (!false)
			{
				if (-1 == 0)
				{
					goto IL_24;
				}
				PhotoBusiness. expr_8B = new PhotoBusiness.();
				if (true)
				{
					 = expr_8B;
				}
			}
			if (6 == 0)
			{
				goto IL_73;
			}
			. = Photono;
			IL_24:
			. = PhotographerID;
			. = this;
			. = new PhotoInfo();
			IL_51:
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			if (. == null)
			{
				return true;
			}
			IL_73:
			if (..DG_Photos_pkey > 0)
			{
				if (5 == 0)
				{
					goto IL_51;
				}
				if (!false)
				{
					return false;
				}
				goto IL_24;
			}
			return true;
		}

		public string GetPhotoGrapherLastImageId(int photographerid)
		{
			PhotoBusiness. expr_4E = new PhotoBusiness.();
			PhotoBusiness. ;
			if (!false)
			{
				 = expr_4E;
			}
			. = photographerid;
			. = this;
			do
			{
				. = new PhotoInfo();
				if (!false)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
				}
			}
			while (-1 == 0);
			return ..DG_Photos_RFID;
		}

		public PhotoInfo GetNextPreviousPhoto(int PhotoId, string Flag)
		{
			if (3 != 0)
			{
			}
			. = this;
			PhotoInfo result;
			try
			{
				PhotoBusiness.  = new PhotoBusiness.();
				. = ;
				. = new PhotoInfo();
				while (true)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					while (true)
					{
						base.Start(false);
						if (false)
						{
							break;
						}
						if (. == null)
						{
							goto IL_86;
						}
						if (8 != 0)
						{
							if (3 == 0)
							{
								goto IL_86;
							}
							result = .;
						}
						if (!false)
						{
							goto Block_8;
						}
					}
				}
				Block_8:
				return result;
				IL_86:
				result = null;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		public List<PhotoInfo> GetArchiveImages()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = new List<PhotoInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public PhotoInfo GetPhotoNameByPhotoID(long PhotoId)
		{
			PhotoBusiness.  = new PhotoBusiness.();
			. = PhotoId;
			. = this;
			do
			{
				string arg_1B_0 = string.Empty;
				. = new PhotoInfo();
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
			}
			while (false);
			return .;
		}

		public List<PhotoDetail> GetPhotoDetailsByPhotoIds(PhotoDetail photoDetailObj)
		{
			PhotoBusiness.  = new PhotoBusiness.();
			. = photoDetailObj;
			. = this;
			. = new List<PhotoDetail>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public PhotoInfo GetPhotoRFIDByPhotoID(long PhotoId)
		{
			PhotoBusiness.  = new PhotoBusiness.();
			. = PhotoId;
			. = this;
			. = new PhotoInfo();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public List<PhotoInfo> GetPhotoRFIDByPhotoIDList(string photoIdList)
		{
			PhotoBusiness.  = new PhotoBusiness.();
			. = photoIdList;
			. = this;
			. = new List<PhotoInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public List<PhotoInfo> GetPhotosBasedonRFID(int substoreId, string RFID)
		{
			PhotoBusiness. expr_92 = new PhotoBusiness.();
			PhotoBusiness. ;
			if (7 != 0)
			{
				 = expr_92;
			}
			if (false)
			{
				goto IL_3F;
			}
			. = substoreId;
			if (false)
			{
				goto IL_83;
			}
			. = RFID;
			IL_30:
			. = this;
			IL_3F:
			new List<string>();
			. = new List<PhotoInfo>();
			..Split(new char[]
			{
				','
			}).ToList<string>();
			if (false)
			{
				goto IL_30;
			}
			this.operation = new BaseBusiness.TransactionMethod(.);
			IL_83:
			base.Start(false);
			return .;
		}

		public List<PhotoGraphersInfo> GetPhotoGrapher()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = new List<PhotoGraphersInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public DG_PhotoGroupInfo GetGroupName(string groupname)
		{
			PhotoBusiness.  = new PhotoBusiness.();
			. = groupname;
			. = this;
			. = new DG_PhotoGroupInfo();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public List<string> GetQRCodeBYImages(string PhotoId)
		{
			if (!false && -1 != 0)
			{
			}
			. = PhotoId;
			. = this;
			List<string> result;
			try
			{
				PhotoBusiness.  = new PhotoBusiness.();
				if (!false)
				{
					. = ;
				}
				. = new List<string>();
				if (6 != 0)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					if (!false)
					{
						base.Start(false);
						result = .;
					}
				}
			}
			catch
			{
				result = null;
			}
			return result;
		}

		public bool DeletePhotoGroupByName(string name)
		{
			PhotoBusiness.  = new PhotoBusiness.();
			. = name;
			. = this;
			. = false;
			this.operation = new BaseBusiness.TransactionMethod(.);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 = .;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}

		public void SaveGroupData(Dictionary<string, string> _objPhotoDetails, string groupname, int SubStoreId)
		{
			PhotoBusiness. ;
			if (true)
			{
				PhotoBusiness. expr_20C = new PhotoBusiness.();
				if (!false)
				{
					 = expr_20C;
				}
				. = this;
			}
			. = new DataTable();
			..Columns.Add(PhotoBusiness.(2852), typeof(string));
			..Columns.Add(PhotoBusiness.(2873), typeof(int));
			..Columns.Add(PhotoBusiness.(2890), typeof(string));
			..Columns.Add(PhotoBusiness.(2911), typeof(DateTime));
			do
			{
				..Columns.Add(PhotoBusiness.(2932), typeof(int));
				using (Dictionary<string, string>.Enumerator enumerator = _objPhotoDetails.GetEnumerator())
				{
					while (true)
					{
						while (enumerator.MoveNext())
						{
							KeyValuePair<string, string> current = enumerator.Current;
							DataRow dataRow = ..NewRow();
							dataRow[PhotoBusiness.(2852)] = groupname;
							dataRow[PhotoBusiness.(2873)] = current.Key.ToInt32(false);
							if (!false)
							{
								dataRow[PhotoBusiness.(2890)] = current.Value;
								dataRow[PhotoBusiness.(2911)] = new CustomBusineses().ServerDateTime();
								dataRow[PhotoBusiness.(2932)] = SubStoreId;
								..Rows.Add(dataRow);
							}
						}
						break;
					}
				}
				this.operation = new BaseBusiness.TransactionMethod(.);
			}
			while (false);
			base.Start(false);
		}

		public int GetMaxPhotoIdsequence()
		{
			if (!false)
			{
				if (!false)
				{
				}
				. = this;
				. = 0;
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			IL_37:
			int expr_39 = .;
			if (!false)
			{
				return expr_39;
			}
			goto IL_37;
		}

		public int GetMaxUserIdsequence(long frmImgId, long toImgId, string PhotoGrapherID)
		{
			PhotoBusiness.  = new PhotoBusiness.();
			do
			{
				. = frmImgId;
				. = toImgId;
				if (8 == 0)
				{
					goto IL_60;
				}
			}
			while (false);
			. = PhotoGrapherID;
			. = this;
			. = 0;
			this.operation = new BaseBusiness.TransactionMethod(.);
			int arg_69_0 = base.Start(false) ? 1 : 0;
			IL_5C:
			if (false)
			{
				goto IL_66;
			}
			IL_60:
			arg_69_0 = .;
			IL_66:
			if (!false)
			{
				return arg_69_0;
			}
			goto IL_5C;
		}

		public List<PhotoCaptureInfo> GetphotoCapturedetails(int pkey)
		{
			PhotoBusiness.  = new PhotoBusiness.();
			. = pkey;
			. = this;
			. = new List<PhotoCaptureInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool ResetImageProcessedStatus(int PhotoId, int SubStoreId)
		{
			PhotoBusiness.  = new PhotoBusiness.();
			if (!false)
			{
				. = PhotoId;
				if (!false)
				{
					. = SubStoreId;
				}
			}
			do
			{
				if (-1 != 0)
				{
					. = this;
				}
				if (8 == 0)
				{
					goto IL_4B;
				}
				. = false;
			}
			while (false);
			this.operation = new BaseBusiness.TransactionMethod(.);
			IL_4B:
			base.Start(false);
			return .;
		}

		public string GetPhotoPlayerScore(string photoId)
		{
			PhotoBusiness.  = new PhotoBusiness.();
			. = photoId;
			. = this;
			. = string.Empty;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public string GetVideoFrameCropRatio(int locationid)
		{
			PhotoBusiness.  = new PhotoBusiness.();
			. = locationid;
			. = this;
			. = string.Empty;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		static PhotoBusiness()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(PhotoBusiness));
		}
	}
}
