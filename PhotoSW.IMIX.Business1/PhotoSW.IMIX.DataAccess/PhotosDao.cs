
using PhotoSW.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace PhotoSW.IMIX.DataAccess
{
	public class PhotosDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getPhotosDao;

		public PhotosDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public PhotosDao()
		{
		}

		public bool DeletePhotoGroupBySubStoreIdAndDays(int days, int substoreID)
		{
			base.DBParameters.Clear();
			base.AddParameter(   PhotosDao.getPhotosDao (19999), days);
			do
			{
				base.AddParameter(PhotosDao.getPhotosDao (3794), substoreID);
			}
			while (4 == 0);
			//base.ExecuteNonQuery(#1j.#ri);
			return true;
		}

		public bool DelPhotoGroupBySubstoreId(int SubstoreId)
		{
			base.DBParameters.Clear();
			base.AddParameter(   PhotosDao.getPhotosDao(3794), SubstoreId);
			base.ExecuteNonQuery(PhotosDao.getPhotosDao(20016));
			return true;
		}

		public void UpdateArchiveByFileName(string PhotosFileName)
		{
			if (4 != 0)
			{
				base.DBParameters.Clear();
				base.AddParameter(PhotosDao.getPhotosDao(20049), PhotosFileName);
				//base.ExecuteNonQuery(#1j.#Ej);
			}
		}

		public int InsertPhotoDetails(int substoreId, int Locationid, int? RfidScanType, int DG_Photos_pkey, DateTime DG_Photos_CreatedOn, DateTime? DateTaken, string DG_Photos_RFID, string DG_Photos_FileName, string Userid, string Imgmetadata, string Photolayer, string DG_Photos_Effects, int? IsImageProcessed, int? CharacterID, long? VideoLength = null, bool? IsVideoProcessed = false, int? mediatype = 1, int? ParentImageId = 0, string OriginalFileName = null, int? SemiOrderProfileId = 0, bool isCroped = false)
		{
			base.DBParameters.Clear();
			base.AddParameter(PhotosDao.getPhotosDao(2332), substoreId);
			base.AddParameter(PhotosDao.getPhotosDao(20078), Locationid);
			base.AddParameter(PhotosDao.getPhotosDao(20103), RfidScanType);
			base.AddParameter(PhotosDao.getPhotosDao(20128), DG_Photos_pkey, ParameterDirection.Output);
			base.AddParameter(PhotosDao.getPhotosDao(20149), DG_Photos_CreatedOn);
			base.AddParameter(PhotosDao.getPhotosDao(20186), base.SetNullDateTimeValue(DateTaken));
			base.AddParameter(PhotosDao.getPhotosDao(20207), DG_Photos_RFID);
			base.AddParameter(PhotosDao.getPhotosDao(20236), DG_Photos_FileName);
			base.AddParameter(PhotosDao.getPhotosDao(20269), Userid);
			base.AddParameter(PhotosDao.getPhotosDao(20286), Imgmetadata);
			base.AddParameter(PhotosDao.getPhotosDao(20311), Photolayer);
			base.AddParameter(PhotosDao.getPhotosDao(20336), DG_Photos_Effects);
			base.AddParameter(PhotosDao.getPhotosDao(20369), IsImageProcessed ?? 0);
			base.AddParameter(PhotosDao.getPhotosDao(20402), base.SetNullIntegerValue(CharacterID));
			base.AddParameter(PhotosDao.getPhotosDao(20427), mediatype);
			base.AddParameter(PhotosDao.getPhotosDao(20452), VideoLength ?? 0L);
			base.AddParameter(PhotosDao.getPhotosDao(20477), IsVideoProcessed ?? false);
			base.AddParameter(PhotosDao.getPhotosDao(20510), OriginalFileName);
			base.AddParameter(PhotosDao.getPhotosDao(20535), ParentImageId);
			base.AddParameter(PhotosDao.getPhotosDao(20556), SemiOrderProfileId);
			base.AddParameter(PhotosDao.getPhotosDao(20589), isCroped);
			//base.ExecuteNonQuery(#1j.#tj);
			return (int)base.GetOutParameterValue(PhotosDao.getPhotosDao(20128));
		}

		public bool UpdateCropedPhotos(int Photos_pkey, bool Value, string Operation)
		{
			base.DBParameters.Clear();
			base.AddParameter(PhotosDao.getPhotosDao(20610), Photos_pkey);
			base.AddParameter(PhotosDao.getPhotosDao(15167), Value);
			base.AddParameter(PhotosDao.getPhotosDao(20635), Operation);
			//base.ExecuteNonQuery(#1j.#4i);
			return true;
		}

		public PhotoInfo GetPhotosByPkey(int Photoskey)
		{
			base.DBParameters.Clear();
			base.AddParameter(PhotosDao.getPhotosDao (20656), Photoskey);
			IDataReader dataReader=null;
            //if (true && !false)
            //{
            //    dataReader = base.ExecuteReader(#1j.#ai);
            //}
			List<PhotoInfo> source=null;
			do
			{
				source = this.PhotoInfo4b(dataReader);
			}
			while (false);
			dataReader.Close();
			return source.FirstOrDefault<PhotoInfo>();
		}

		private List<PhotoInfo> PhotoInfo4b(IDataReader IDataReader)
		{
			List<PhotoInfo> list = new List<PhotoInfo>();
			while (IDataReader.Read())
			{
				PhotoInfo item = new PhotoInfo
				{
					DG_Photos_pkey = base.GetFieldValue(IDataReader,                   PhotosDao.getPhotosDao(20677), 0),
					DG_Photos_FileName = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20698), string.Empty),
					DG_Photos_CreatedOn = base.GetFieldValue(IDataReader,              PhotosDao.getPhotosDao(20723), DateTime.Now),
					DG_Photos_RFID = base.GetFieldValue(IDataReader,                   PhotosDao.getPhotosDao(20752), string.Empty),
					DG_Photos_UserID = new int?(base.GetFieldValue(IDataReader,        PhotosDao.getPhotosDao(20773), 0)),
					DG_Photos_Background = base.GetFieldValue(IDataReader,             PhotosDao.getPhotosDao(20798), string.Empty),
					DG_Photos_Frame = base.GetFieldValue(IDataReader,                  PhotosDao.getPhotosDao(20827), string.Empty),
					DG_Photos_DateTime = new DateTime?(base.GetFieldValue(IDataReader, PhotosDao.getPhotosDao(20848), DateTime.Now)),
					DG_Photos_Layering = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20873), string.Empty),
					DG_Photos_Effects = base.GetFieldValue(IDataReader,                PhotosDao.getPhotosDao(20898), string.Empty),
					DG_Photos_IsCroped = new bool?(base.GetFieldValue(IDataReader,     PhotosDao.getPhotosDao(20923), false)),
					DG_Photos_IsRedEye = new bool?(base.GetFieldValue(IDataReader,     PhotosDao.getPhotosDao(20948), false)),
					DG_Photos_IsGreen = new bool?(base.GetFieldValue(IDataReader,      PhotosDao.getPhotosDao(20973), false)),
					DG_Photos_MetaData = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20998), string.Empty),
					DG_Photos_Sizes = base.GetFieldValue(IDataReader,                  PhotosDao.getPhotosDao(21023), string.Empty),
					DG_Photos_Archive = new bool?(base.GetFieldValue(IDataReader,      PhotosDao.getPhotosDao(21044), false)),
					DG_Location_Id = new int?(base.GetFieldValue(IDataReader,          PhotosDao.getPhotosDao(21069), 0)),
					DG_SubStoreId = new int?(base.GetFieldValue(IDataReader,           PhotosDao.getPhotosDao(21090), 0)),
					DG_IsCodeType = base.GetFieldValue(IDataReader,                    PhotosDao.getPhotosDao(21111), false),
					DateTaken = new DateTime?(base.GetFieldValue(IDataReader,          PhotosDao.getPhotosDao(21132), DateTime.Now)),
					RfidScanType = new int?(base.GetFieldValue(IDataReader,            PhotosDao.getPhotosDao(21145), 0)),
					HotFolderPath = base.GetFieldValue(IDataReader,                    PhotosDao.getPhotosDao(21162), string.Empty),
					DG_MediaType = base.GetFieldValue(IDataReader,                     PhotosDao.getPhotosDao(21183), 0),
					DG_VideoLength = new long?(base.GetFieldValue(IDataReader,         PhotosDao.getPhotosDao(21200), 0L)),
					SemiOrderProfileId = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(21221), 0),
					IsGumRideShow = base.GetFieldValue(IDataReader,                    PhotosDao.getPhotosDao(21246), false),
					OnlineQRCode = base.GetFieldValue(IDataReader,                     PhotosDao.getPhotosDao(21267), string.Empty)
				};
				list.Add(item);
			}
			return list;
		}

		public ModratePhotoInfo GetModeratePhotos(long ModPhotoID)
		{
			base.DBParameters.Clear();
			base.AddParameter(PhotosDao.getPhotosDao(21284), ModPhotoID);
			IDataReader dataReader=null;
			if (true && !false)
			{
				//dataReader = base.ExecuteReader(#1j.#Pi);
			}
			List<ModratePhotoInfo> source;
			do
			{
				source = this.ModratePhotoInfo5b(dataReader);
			}
			while (false);
			dataReader.Close();
			return source.FirstOrDefault<ModratePhotoInfo>();
		}

		private List<ModratePhotoInfo> ModratePhotoInfo5b(IDataReader IDataReader)
		{
			List<ModratePhotoInfo> list = new List<ModratePhotoInfo>();
			while (IDataReader.Read())
			{
				ModratePhotoInfo item = new ModratePhotoInfo
				{
					DG_Mod_Photo_pkey = base.GetFieldValue(IDataReader,    PhotosDao.getPhotosDao(21309), 0),
					DG_Mod_Photo_ID = base.GetFieldValue(IDataReader,      PhotosDao.getPhotosDao(21334), 0),
					DG_Mod_Date = base.GetFieldValue(IDataReader,          PhotosDao.getPhotosDao(21355), DateTime.Now),
					DG_Mod_User_ID = base.GetFieldValue(IDataReader,       PhotosDao.getPhotosDao(21372), 0)
				};
				list.Add(item);
			}
			return list;
		}

		public List<ModratePhotoInfo> GetModeratePhotos(long? ModPhotoID)
		{
			base.DBParameters.Clear();
			base.AddParameter(PhotosDao.getPhotosDao (21393), base.SetNullLongValue(ModPhotoID));
			IDataReader dataReader=null;
			List<ModratePhotoInfo> result;
			do
			{
				//dataReader = base.ExecuteReader(#1j.#Dh);
				result = this.ModratePhotoInfo5b(dataReader);
			}
			while (5 == 0);
			dataReader.Close();
			return result;
		}

		public void DeleteModeratePhotosById(long Mod_Photo_ID)
		{
			while (true)
			{
				base.DBParameters.Clear();
				while (8 != 0)
				{
					base.AddParameter(PhotosDao.getPhotosDao(21284), Mod_Photo_ID);
					if (7 != 0)
					{
						//base.ExecuteNonQuery(#1j.#Wi);
						if (!false)
						{
							return;
						}
						break;
					}
				}
			}
		}

		public List<PhotoInfo> SelectAllPhotosforSearch(string substoreId, long imgRfid, int noOfImg, bool isAnyRfidSearch, long StartIndex, int RfidSearch, int NewRecord, out long maxPhotoId, out long minPhotoId, int mediaType)
		{
			maxPhotoId = 0L;
			List<PhotoInfo> list;
			if (true)
			{
				minPhotoId = 0L;
				base.DBParameters.Clear();
				base.AddParameter(   PhotosDao.getPhotosDao(21422), StartIndex);
				base.AddParameter(   PhotosDao.getPhotosDao(21447), noOfImg);
				base.AddParameter(   PhotosDao.getPhotosDao(21468), isAnyRfidSearch);
				base.AddParameter(   PhotosDao.getPhotosDao(21497), imgRfid);
				base.AddParameter(   PhotosDao.getPhotosDao(3794), substoreId);
				base.AddParameter(   PhotosDao.getPhotosDao(21518), RfidSearch);
				base.AddParameter(   PhotosDao.getPhotosDao(21543), NewRecord);
				base.AddOutParameter(PhotosDao.getPhotosDao(21564), SqlDbType.Int);
				base.AddOutParameter(PhotosDao.getPhotosDao(21589), SqlDbType.Int);
				base.AddParameter(   PhotosDao.getPhotosDao(21618), mediaType);
				IDataReader dataReader =null; //base.ExecuteReader(#1j.#jj);
				list = this.PhotoInfo6b(dataReader);
				dataReader.Close();
				if (list.Count <= 0)
				{
					return list;
				}
			}
			minPhotoId = Convert.ToInt64(base.GetOutParameterValue(PhotosDao.getPhotosDao(21589)));
			maxPhotoId = Convert.ToInt64(base.GetOutParameterValue(PhotosDao.getPhotosDao(21564)));
			return list;
		}

		private List<PhotoInfo> PhotoInfo6b(IDataReader IDataReader)
		{
			List<PhotoInfo> list = new List<PhotoInfo>();
			while (IDataReader.Read())
			{
				PhotoInfo item = new PhotoInfo
				{
					DG_Photos_pkey = base.GetFieldValue(IDataReader,                    PhotosDao.getPhotosDao(20677), 0),
					DG_Photos_FileName = base.GetFieldValue(IDataReader,                PhotosDao.getPhotosDao(20698), string.Empty),
					DG_Photos_CreatedOn = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20723), DateTime.Now),
					DG_Photos_RFID = base.GetFieldValue(IDataReader,                    PhotosDao.getPhotosDao(20752), string.Empty),
					DG_Photos_UserID = new int?(base.GetFieldValue(IDataReader,         PhotosDao.getPhotosDao(20773), 0)),
					DG_Photos_Background = base.GetFieldValue(IDataReader,              PhotosDao.getPhotosDao(20798), string.Empty),
					DG_Photos_Frame = base.GetFieldValue(IDataReader,                   PhotosDao.getPhotosDao(20827), string.Empty),
					DG_Photos_DateTime = new DateTime?(base.GetFieldValue(IDataReader,  PhotosDao.getPhotosDao(20848), DateTime.Now)),
					DG_Photos_Layering = base.GetFieldValue(IDataReader,                PhotosDao.getPhotosDao(20873), string.Empty),
					DG_Photos_Effects = base.GetFieldValue(IDataReader,                 PhotosDao.getPhotosDao(20898), string.Empty),
					DG_Photos_IsCroped = new bool?(base.GetFieldValue(IDataReader,      PhotosDao.getPhotosDao(20923), false)),
					DG_Photos_IsRedEye = new bool?(base.GetFieldValue(IDataReader,      PhotosDao.getPhotosDao(20948), false)),
					DG_Photos_IsGreen = new bool?(base.GetFieldValue(IDataReader,       PhotosDao.getPhotosDao(20973), false)),
					DG_Photos_MetaData = base.GetFieldValue(IDataReader,                PhotosDao.getPhotosDao(20998), string.Empty),
					DG_Photos_Sizes = base.GetFieldValue(IDataReader,                   PhotosDao.getPhotosDao(21023), string.Empty),
					DG_Photos_Archive = new bool?(base.GetFieldValue(IDataReader,       PhotosDao.getPhotosDao(21044), false)),
					DG_Location_Id = new int?(base.GetFieldValue(IDataReader,           PhotosDao.getPhotosDao(21069), 0)),
					DG_SubStoreId = new int?(base.GetFieldValue(IDataReader,            PhotosDao.getPhotosDao(21090), 0)),
					DG_IsCodeType = base.GetFieldValue(IDataReader,                     PhotosDao.getPhotosDao(21111), false),
					DateTaken = new DateTime?(base.GetFieldValue(IDataReader,           PhotosDao.getPhotosDao(21132), DateTime.Now)),
					RfidScanType = new int?(base.GetFieldValue(IDataReader,             PhotosDao.getPhotosDao(21145), 0)),
					HotFolderPath = base.GetFieldValue(IDataReader,                     PhotosDao.getPhotosDao(21162), string.Empty),
					DG_MediaType = base.GetFieldValue(IDataReader,                      PhotosDao.getPhotosDao(21183), 0),
					DG_VideoLength = new long?(base.GetFieldValue(IDataReader,          PhotosDao.getPhotosDao(21200), 0L))
				};
				list.Add(item);
			}
			return list;
		}

		public PhotoInfo GetNextPreviousPhoto(int Photospkey, string Flag)
		{
			base.DBParameters.Clear();
			base.AddParameter(PhotosDao.getPhotosDao(20610), Photospkey);
			base.AddParameter(PhotosDao.getPhotosDao(21639), Flag);
			IDataReader dataReader =null; //base.ExecuteReader(#1j.#Ri);
			List<PhotoInfo> source = this.PhotoInfo7b(dataReader);
			dataReader.Close();
			return source.FirstOrDefault<PhotoInfo>();
		}

		private List<PhotoInfo> PhotoInfo7b(IDataReader IDataReader)
		{
			List<PhotoInfo> list = new List<PhotoInfo>();
			while (IDataReader.Read())
			{
				PhotoInfo item = new PhotoInfo
				{
					DG_Photos_pkey = base.GetFieldValue(IDataReader,                         PhotosDao.getPhotosDao(20677), 0),
					DG_Photos_FileName = base.GetFieldValue(IDataReader,                     PhotosDao.getPhotosDao(20698), string.Empty),
					DG_Photos_CreatedOn = base.GetFieldValue(IDataReader,                    PhotosDao.getPhotosDao(20723), DateTime.Now),
					DG_Photos_RFID = base.GetFieldValue(IDataReader,                         PhotosDao.getPhotosDao(20752), string.Empty),
					DG_Photos_UserID = new int?(base.GetFieldValue(IDataReader,              PhotosDao.getPhotosDao(20773), 0)),
					DG_Photos_Background = base.GetFieldValue(IDataReader,                   PhotosDao.getPhotosDao(20798), string.Empty),
					DG_Photos_Frame = base.GetFieldValue(IDataReader,                        PhotosDao.getPhotosDao(20827), string.Empty),
					DG_Photos_DateTime = new DateTime?(base.GetFieldValue(IDataReader,       PhotosDao.getPhotosDao(20848), DateTime.Now)),
					DG_Photos_Layering = base.GetFieldValue(IDataReader,                     PhotosDao.getPhotosDao(20873), string.Empty),
					DG_Photos_Effects = base.GetFieldValue(IDataReader,                      PhotosDao.getPhotosDao(20898), string.Empty),
					DG_Photos_IsCroped = new bool?(base.GetFieldValue(IDataReader,           PhotosDao.getPhotosDao(20923), false)),
					DG_Photos_IsRedEye = new bool?(base.GetFieldValue(IDataReader,           PhotosDao.getPhotosDao(20948), false)),
					DG_Photos_IsGreen = new bool?(base.GetFieldValue(IDataReader,            PhotosDao.getPhotosDao(20973), false)),
					DG_Photos_MetaData = base.GetFieldValue(IDataReader,                     PhotosDao.getPhotosDao(20998), string.Empty),
					DG_Photos_Sizes = base.GetFieldValue(IDataReader,                        PhotosDao.getPhotosDao(21023), string.Empty),
					DG_Photos_Archive = new bool?(base.GetFieldValue(IDataReader,            PhotosDao.getPhotosDao(21044), false)),
					DG_Location_Id = new int?(base.GetFieldValue(IDataReader,                PhotosDao.getPhotosDao(21069), 0)),
					DG_SubStoreId = new int?(base.GetFieldValue(IDataReader,                 PhotosDao.getPhotosDao(21090), 0)),
					DG_IsCodeType = base.GetFieldValue(IDataReader,                          PhotosDao.getPhotosDao(21111), false),
					DateTaken = new DateTime?(base.GetFieldValue(IDataReader,                PhotosDao.getPhotosDao(21132), DateTime.Now)),
					RfidScanType = new int?(base.GetFieldValue(IDataReader,                  PhotosDao.getPhotosDao(21145), 0))
				};
				list.Add(item);
			}
			return list;
		}

		public bool UpdGreenPhotos(long Photospkey, bool Value)
		{
			base.DBParameters.Clear();
			base.AddParameter(PhotosDao.getPhotosDao(20610), Photospkey);
			do
			{
				base.AddParameter(PhotosDao.getPhotosDao (15167), Value);
			}
			while (4 == 0);
			//base.ExecuteNonQuery(#1j.#5i);
			return true;
		}

		public void InsertModerateImage(int PhotoId, int Userid)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(PhotosDao.getPhotosDao(7502), PhotoId);
			}
			if (!false)
			{
				base.AddParameter(PhotosDao.getPhotosDao (20269), Userid);
			}
			//base.ExecuteNonQuery(#1j.#qj);
		}

		public bool UpdatePhotoEffects(PhotoInfo objectInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(PhotosDao.getPhotosDao(7502), objectInfo.DG_Photos_pkey);
			base.AddParameter(PhotosDao.getPhotosDao(21656), objectInfo.DG_Photos_IsCroped);
			base.AddParameter(PhotosDao.getPhotosDao(20336), objectInfo.DG_Photos_Effects);
			//base.ExecuteNonQuery(#1j.#Ah);
			return true;
		}

		public void InsertPreviewCounter(int PhotoId)
		{
			while (true)
			{
				base.DBParameters.Clear();
				while (8 != 0)
				{
					base.AddParameter(PhotosDao.getPhotosDao (7502), PhotoId);
					if (7 != 0)
					{
						//base.ExecuteNonQuery(#1j.#vj);
						if (!false)
						{
							return;
						}
						break;
					}
				}
			}
		}

		public bool UpdatePhotoLayering(PhotoInfo objectInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(PhotosDao.getPhotosDao(21689), objectInfo.DG_Photos_Layering);
			base.AddParameter(PhotosDao.getPhotosDao(7502), objectInfo.DG_Photos_pkey);
			base.AddParameter(PhotosDao.getPhotosDao(20369), objectInfo.IsImageProcessed);
			//base.ExecuteNonQuery(#1j.#Bh);
			return true;
		}

		public bool UpdatePhotoEffectsByPhotosId(PhotoInfo objectInfo)
		{
			List<SqlParameter> expr_4E = base.DBParameters;
			if (!false)
			{
				expr_4E.Clear();
			}
			base.AddParameter(PhotosDao.getPhotosDao(7502), objectInfo.DG_Photos_pkey);
			base.AddParameter(PhotosDao.getPhotosDao(20336), objectInfo.DG_Photos_Effects);
			//base.ExecuteNonQuery(#1j.#Nf);
			return true;
		}

		public bool UpdateEffectsonPhoto(string value, int photoId, bool isgumballshow)
		{
			base.DBParameters.Clear();
			base.AddParameter(PhotosDao.getPhotosDao(7502), photoId);
			base.AddParameter(PhotosDao.getPhotosDao(21718), value);
			base.AddParameter(PhotosDao.getPhotosDao(21747), isgumballshow);
			//base.ExecuteNonQuery(#1j.#Vf);
			return true;
		}

		public bool UpdateEffectsSpecPrint(int photoId, string layeringdata, string ImageEffect, bool isGreenSreen, bool isCrop, bool isgumballshow, string GumBallRidetxtContent, string _QRCode)
		{
			base.DBParameters.Clear();
			base.AddParameter(PhotosDao.getPhotosDao(7502), photoId);
			base.AddParameter(PhotosDao.getPhotosDao(21776), layeringdata);
			base.AddParameter(PhotosDao.getPhotosDao(21801), ImageEffect);
			base.AddParameter(PhotosDao.getPhotosDao(21826), isGreenSreen);
			base.AddParameter(PhotosDao.getPhotosDao(21851), isCrop);
			if (!false)
			{
				base.AddParameter(PhotosDao.getPhotosDao(21747), isgumballshow);
				base.AddParameter(PhotosDao.getPhotosDao(21872), GumBallRidetxtContent);
			}
			base.AddParameter(PhotosDao.getPhotosDao(21909), _QRCode);
			//base.ExecuteNonQuery(#1j.#Wf);
			return true;
		}

		public bool UpdateOnlineQRCodeForPhoto(int photoId, string OnlineQRCode)
		{
			do
			{
				base.DBParameters.Clear();
				do
				{
					if (!false)
					{
						base.AddParameter(PhotosDao.getPhotosDao(7502), photoId);
					}
					if (8 != 0)
					{
						base.AddParameter(PhotosDao.getPhotosDao(21909), OnlineQRCode);
					}
				}
				while (3 == 0);
			}
			while (2 == 0 || 6 == 0);
			//base.ExecuteNonQuery(#1j.#3yc);
			return true;
		}

		public List<PhotoInfo> GetPhotoDetailsbyPhotoId(int Photos_pkey)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(PhotosDao.getPhotosDao (20610), Photos_pkey);
			}
			IDataReader dataReader=null;
			List<PhotoInfo> result;
			if (!false)
			{
				//dataReader = base.ExecuteReader(#1j.#Uf);
                //if (3 != 0)
                //{
					result = this.PhotoInfo8b(dataReader);
				//}
			}
			dataReader.Close();
			return result;
		}

		private List<PhotoInfo> PhotoInfo8b(IDataReader IDataReader)
		{
			List<PhotoInfo> list = new List<PhotoInfo>();
			while (IDataReader.Read())
			{
				PhotoInfo item = new PhotoInfo
				{
					DG_Photos_pkey = base.GetFieldValue(IDataReader,                   PhotosDao.getPhotosDao(20677), 0),
					DG_Photos_FileName = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20698), string.Empty),
					DG_Photos_CreatedOn = base.GetFieldValue(IDataReader,              PhotosDao.getPhotosDao(20723), DateTime.Now),
					DG_Photos_RFID = base.GetFieldValue(IDataReader,                   PhotosDao.getPhotosDao(20752), string.Empty),
					DG_Photos_UserID = new int?(base.GetFieldValue(IDataReader,        PhotosDao.getPhotosDao(20773), 0)),
					DG_Photos_Background = base.GetFieldValue(IDataReader,             PhotosDao.getPhotosDao(20798), string.Empty),
					DG_Photos_Frame = base.GetFieldValue(IDataReader,                  PhotosDao.getPhotosDao(20827), string.Empty),
					DG_Photos_DateTime = new DateTime?(base.GetFieldValue(IDataReader, PhotosDao.getPhotosDao(20848), DateTime.Now)),
					DG_Photos_Layering = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20873), string.Empty),
					DG_Photos_Effects = base.GetFieldValue(IDataReader,                PhotosDao.getPhotosDao(20898), string.Empty),
					DG_Photos_IsCroped = new bool?(base.GetFieldValue(IDataReader,     PhotosDao.getPhotosDao(20923), false)),
					DG_Photos_IsRedEye = new bool?(base.GetFieldValue(IDataReader,     PhotosDao.getPhotosDao(20948), false)),
					DG_Photos_IsGreen = new bool?(base.GetFieldValue(IDataReader,      PhotosDao.getPhotosDao(20973), false)),
					DG_Photos_MetaData = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20998), string.Empty),
					DG_Photos_Sizes = base.GetFieldValue(IDataReader,                  PhotosDao.getPhotosDao(21023), string.Empty),
					DG_Photos_Archive = new bool?(base.GetFieldValue(IDataReader,      PhotosDao.getPhotosDao(21044), false)),
					DG_Location_Id = new int?(base.GetFieldValue(IDataReader,          PhotosDao.getPhotosDao(21069), 0)),
					DG_SubStoreId = new int?(base.GetFieldValue(IDataReader,           PhotosDao.getPhotosDao(21090), 0)),
					DG_IsCodeType = base.GetFieldValue(IDataReader,                    PhotosDao.getPhotosDao(21111), false),
					DateTaken = new DateTime?(base.GetFieldValue(IDataReader,          PhotosDao.getPhotosDao(21132), DateTime.Now)),
					RfidScanType = new int?(base.GetFieldValue(IDataReader,            PhotosDao.getPhotosDao(21145), 0))
				};
				list.Add(item);
			}
			return list;
		}

		public List<PhotoInfo> SelectMapImagesBYQRCode(bool IsAnonymousQrCodeEnabled, string QRCode)
		{
			if (7 != 0 && !false)
			{
				base.DBParameters.Clear();
				string expr_83 = PhotosDao.getPhotosDao(982);
				object expr_22 = IsAnonymousQrCodeEnabled;
				if (2 != 0)
				{
					base.AddParameter(expr_83, expr_22);
				}
				base.AddParameter(PhotosDao.getPhotosDao (21934), QRCode);
			}
			List<PhotoInfo> result;
			if (!false)
			{
				IDataReader dataReader=null;
				if (3 != 0)
				{
					//dataReader = base.ExecuteReader(#1j.#Rf);
				}
				if (3 != 0)
				{
					result = this.PhotoInfo9b(dataReader);
				}
				dataReader.Close();
			}
			return result;
		}

		private List<PhotoInfo> PhotoInfo9b(IDataReader IDataReader)
		{
			List<PhotoInfo> list = new List<PhotoInfo>();
			while (IDataReader.Read())
			{
				PhotoInfo item = new PhotoInfo
				{
					DG_Photos_pkey = base.GetFieldValue(IDataReader,                   PhotosDao.getPhotosDao(20677), 0),
					DG_Photos_FileName = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20698), string.Empty),
					DG_Photos_CreatedOn = base.GetFieldValue(IDataReader,              PhotosDao.getPhotosDao(20723), DateTime.Now),
					DG_Photos_RFID = base.GetFieldValue(IDataReader,                   PhotosDao.getPhotosDao(20752), string.Empty),
					DG_Photos_UserID = new int?(base.GetFieldValue(IDataReader,        PhotosDao.getPhotosDao(20773), 0)),
					DG_Photos_Background = base.GetFieldValue(IDataReader,             PhotosDao.getPhotosDao(20798), string.Empty),
					DG_Photos_Frame = base.GetFieldValue(IDataReader,                  PhotosDao.getPhotosDao(20827), string.Empty),
					DG_Photos_DateTime = new DateTime?(base.GetFieldValue(IDataReader, PhotosDao.getPhotosDao(20848), DateTime.Now)),
					DG_Photos_Layering = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20873), string.Empty),
					DG_Photos_Effects = base.GetFieldValue(IDataReader,                PhotosDao.getPhotosDao(20898), string.Empty),
					DG_Photos_IsCroped = new bool?(base.GetFieldValue(IDataReader,     PhotosDao.getPhotosDao(20923), false)),
					DG_Photos_IsRedEye = new bool?(base.GetFieldValue(IDataReader,     PhotosDao.getPhotosDao(20948), false)),
					DG_Photos_IsGreen = new bool?(base.GetFieldValue(IDataReader,      PhotosDao.getPhotosDao(20973), false)),
					DG_Photos_MetaData = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20998), string.Empty),
					DG_Photos_Sizes = base.GetFieldValue(IDataReader,                  PhotosDao.getPhotosDao(21023), string.Empty),
					DG_Photos_Archive = new bool?(base.GetFieldValue(IDataReader,      PhotosDao.getPhotosDao(21044), false)),
					DG_Location_Id = new int?(base.GetFieldValue(IDataReader,          PhotosDao.getPhotosDao(21069), 0)),
					DG_SubStoreId = new int?(base.GetFieldValue(IDataReader,           PhotosDao.getPhotosDao(21090), 0)),
					IMIXImageAssociationId = base.GetFieldValue(IDataReader,           PhotosDao.getPhotosDao(836), 0L),
					HotFolderPath = base.GetFieldValue(IDataReader,                    PhotosDao.getPhotosDao(21162), string.Empty),
					DG_MediaType = base.GetFieldValue(IDataReader,                     PhotosDao.getPhotosDao(21183), 0),
					DG_VideoLength = new long?(base.GetFieldValue(IDataReader,         PhotosDao.getPhotosDao(21200), 0L)),
					OnlineQRCode = base.GetFieldValue(IDataReader,                     PhotosDao.getPhotosDao(21267), string.Empty)
				};
				list.Add(item);
			}
			return list;
		}

		public List<PhotoInfo> SelectSavedGroupImages(string GroupName)
		{
			IDataReader dataReader=null;
			List<PhotoInfo> result;
			while (-1 != 0)
			{
				base.DBParameters.Clear();
				if (false)
				{
					break;
				}
				base.AddParameter(PhotosDao.getPhotosDao(21947), GroupName);
				if (8 != 0)
				{
					if (!false)
					{
						//dataReader = base.ExecuteReader(#1j.#Qf);
						result = this.PhotoInfoac(dataReader);
						break;
					}
					break;
				}
			}
			dataReader.Close();
			return result;
		}

		private List<PhotoInfo> PhotoInfoac(IDataReader IDataReader)
		{
			List<PhotoInfo> expr_340 = new List<PhotoInfo>();
			List<PhotoInfo> list;
			if (!false)
			{
				list = expr_340;
			}
			while (IDataReader.Read())
			{
				PhotoInfo photoInfo = new PhotoInfo();
				photoInfo.DG_Group_Name = base.GetFieldValue(IDataReader,                    PhotosDao.getPhotosDao(15975), string.Empty);
				photoInfo.DG_Group_pkey = base.GetFieldValue(IDataReader,                    PhotosDao.getPhotosDao(15954), 0L);
				photoInfo.DG_Photos_pkey = base.GetFieldValue(IDataReader,                   PhotosDao.getPhotosDao(20677), 0);
				photoInfo.DG_Photos_FileName = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20698), string.Empty);
				if (!false)
				{
					photoInfo.DG_Photos_CreatedOn = base.GetFieldValue(IDataReader,          PhotosDao.getPhotosDao(20723), DateTime.Now);
					photoInfo.DG_Photos_RFID = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20752), string.Empty);
					do
					{
						photoInfo.DG_Photos_UserID = new int?(base.GetFieldValue(IDataReader, PhotosDao.getPhotosDao (20773), 0));
					}
					while (!true);
					photoInfo.DG_Photos_Background = base.GetFieldValue(IDataReader,             PhotosDao.getPhotosDao(20798), string.Empty);
					photoInfo.DG_Photos_Frame = base.GetFieldValue(IDataReader,                  PhotosDao.getPhotosDao(20827), string.Empty);
					photoInfo.DG_Photos_DateTime = new DateTime?(base.GetFieldValue(IDataReader, PhotosDao.getPhotosDao(20848), DateTime.Now));
					photoInfo.DG_Photos_Layering = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20873), string.Empty);
					photoInfo.DG_Photos_Effects = base.GetFieldValue(IDataReader,                PhotosDao.getPhotosDao(20898), string.Empty);
					photoInfo.DG_Photos_IsCroped = new bool?(base.GetFieldValue(IDataReader,     PhotosDao.getPhotosDao(20923), false));
					photoInfo.DG_Photos_IsRedEye = new bool?(base.GetFieldValue(IDataReader,     PhotosDao.getPhotosDao(20948), false));
					photoInfo.DG_Photos_IsGreen = new bool?(base.GetFieldValue(IDataReader,      PhotosDao.getPhotosDao(20973), false));
					photoInfo.DG_Photos_MetaData = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20998), string.Empty);
				}
				photoInfo.DG_Photos_Sizes = base.GetFieldValue(IDataReader,                      PhotosDao.getPhotosDao(21023), string.Empty);
				photoInfo.DG_Photos_Archive = new bool?(base.GetFieldValue(IDataReader,          PhotosDao.getPhotosDao(21044), false));
				photoInfo.DG_Location_Id = new int?(base.GetFieldValue(IDataReader,              PhotosDao.getPhotosDao(21069), 0));
				photoInfo.DG_SubStoreId = new int?(base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(21090), 0));
				photoInfo.HotFolderPath = base.GetFieldValue(IDataReader,                        PhotosDao.getPhotosDao(21162), string.Empty);
				photoInfo.DG_MediaType = base.GetFieldValue(IDataReader,                         PhotosDao.getPhotosDao(21183), 0);
				photoInfo.DG_VideoLength = new long?(base.GetFieldValue(IDataReader,             PhotosDao.getPhotosDao(21200), 0L));
				PhotoInfo item = photoInfo;
				list.Add(item);
			}
			return list;
		}

		public bool IsCodeType(int Photos_pkey)
		{
			base.DBParameters.Clear();
			base.AddParameter(PhotosDao.getPhotosDao(20610), Photos_pkey);
			List<PhotoInfo> source;
			do
			{
				IDataReader dataReader =null; //base.ExecuteReader(#1j.#hj);
				source = this.PhotoInfobc(dataReader);
				dataReader.Close();
			}
			while (-1 == 0);
			return source.FirstOrDefault<PhotoInfo>().DG_IsCodeType;
		}

		private List<PhotoInfo> PhotoInfobc(IDataReader IDataReader)
		{
			List<PhotoInfo> list;
			while (true)
			{
				if (!false)
				{
					List<PhotoInfo> expr_48 = new List<PhotoInfo>();
					if (!false)
					{
						list = expr_48;
					}
				}
				while (true)
				{
					if (IDataReader.Read() && -1 != 0)
					{
						PhotoInfo item = new PhotoInfo
						{
							DG_IsCodeType = base.GetFieldValue(IDataReader, PhotosDao.getPhotosDao(21111), false)
						};
						if (5 == 0)
						{
							break;
						}
						list.Add(item);
					}
					else
					{
						if (!true)
						{
							break;
						}
						if (!false)
						{
							return list;
						}
					}
				}
			}
			return list;
		}

		public bool DeletePhotoByPhotoId(int PhotoId)
		{
			base.DBParameters.Clear();
			base.AddParameter(PhotosDao.getPhotosDao(7502), PhotoId);
			//base.ExecuteNonQuery(#1j.#Kf);
			return true;
		}

		public List<PhotoInfo> GetAllPhotosByPage(int? substoreId, int startIndex, int pazeSize, bool isNext, out long maxPhotoId, out bool IsMoreImages, out long minPhotoId, int mediaType)
		{
			maxPhotoId = 0L;
			minPhotoId = 0L;
			IsMoreImages = false;
			base.DBParameters.Clear();
			base.AddParameter(PhotosDao.getPhotosDao(21422), startIndex);
			base.AddParameter(PhotosDao.getPhotosDao(21968), pazeSize);
			base.AddParameter(PhotosDao.getPhotosDao(2332), base.SetNullIntegerValue(substoreId));
			base.AddParameter(PhotosDao.getPhotosDao(21543), isNext);
			base.AddOutParameter(PhotosDao.getPhotosDao(21564), SqlDbType.Int);
			base.AddOutParameter(PhotosDao.getPhotosDao(21589), SqlDbType.Int);
			base.AddOutParameter(PhotosDao.getPhotosDao(21989), SqlDbType.Bit);
			base.AddParameter(PhotosDao.getPhotosDao (22014), mediaType);
			IDataReader dataReader = null;//base.ExecuteReader(#1j.#Ij);
			List<PhotoInfo> list = this.PhotoInfocc(dataReader);
			dataReader.Close();
			if (list.Count > 0)
			{
				minPhotoId = Convert.ToInt64(base.GetOutParameterValue(    PhotosDao.getPhotosDao(21589)));
				maxPhotoId = Convert.ToInt64(base.GetOutParameterValue(    PhotosDao.getPhotosDao(21564)));
				IsMoreImages = Convert.ToBoolean(base.GetOutParameterValue(PhotosDao.getPhotosDao(21989)));
			}
			return list;
		}

		private List<PhotoInfo> PhotoInfocc(IDataReader IDataReader)
		{
			List<PhotoInfo> list = new List<PhotoInfo>();
			while (IDataReader.Read())
			{
				PhotoInfo item = new PhotoInfo
				{
					DG_Photos_pkey = base.GetFieldValue(IDataReader,                   PhotosDao.getPhotosDao(20677), 0),
					DG_Photos_FileName = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20698), string.Empty),
					DG_Photos_CreatedOn = base.GetFieldValue(IDataReader,              PhotosDao.getPhotosDao(20723), DateTime.Now),
					DG_Photos_RFID = base.GetFieldValue(IDataReader,                   PhotosDao.getPhotosDao(20752), string.Empty),
					DG_Photos_UserID = new int?(base.GetFieldValue(IDataReader,        PhotosDao.getPhotosDao(20773), 0)),
					DG_Photos_Background = base.GetFieldValue(IDataReader,             PhotosDao.getPhotosDao(20798), string.Empty),
					DG_Photos_Frame = base.GetFieldValue(IDataReader,                  PhotosDao.getPhotosDao(20827), string.Empty),
					DG_Photos_DateTime = new DateTime?(base.GetFieldValue(IDataReader, PhotosDao.getPhotosDao(20848), DateTime.Now)),
					DG_Photos_Layering = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20873), string.Empty),
					DG_Photos_Effects = base.GetFieldValue(IDataReader,                PhotosDao.getPhotosDao(20898), string.Empty),
					DG_Photos_IsCroped = new bool?(base.GetFieldValue(IDataReader,     PhotosDao.getPhotosDao(20923), false)),
					DG_Photos_IsRedEye = new bool?(base.GetFieldValue(IDataReader,     PhotosDao.getPhotosDao(20948), false)),
					DG_Photos_IsGreen = new bool?(base.GetFieldValue(IDataReader,      PhotosDao.getPhotosDao(20973), false)),
					DG_Photos_MetaData = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20998), string.Empty),
					DG_Photos_Sizes = base.GetFieldValue(IDataReader,                  PhotosDao.getPhotosDao(21023), string.Empty),
					DG_Photos_Archive = new bool?(base.GetFieldValue(IDataReader,      PhotosDao.getPhotosDao(21044), false)),
					DG_Location_Id = new int?(base.GetFieldValue(IDataReader,          PhotosDao.getPhotosDao(21069), 0)),
					DG_SubStoreId = new int?(base.GetFieldValue(IDataReader,           PhotosDao.getPhotosDao(21090), 0)),
					DG_IsCodeType = base.GetFieldValue(IDataReader,                    PhotosDao.getPhotosDao(21111), false),
					DateTaken = new DateTime?(base.GetFieldValue(IDataReader,          PhotosDao.getPhotosDao(21132), DateTime.Now)),
					RfidScanType = new int?(base.GetFieldValue(IDataReader,            PhotosDao.getPhotosDao(21145), 0)),
					HotFolderPath = base.GetFieldValue(IDataReader,                    PhotosDao.getPhotosDao(21162), string.Empty),
					DG_MediaType = base.GetFieldValue(IDataReader,                     PhotosDao.getPhotosDao(21183), 0),
					DG_VideoLength = new long?(base.GetFieldValue(IDataReader,         PhotosDao.getPhotosDao(21200), 0L)),
					OnlineQRCode = base.GetFieldValue(IDataReader,                     PhotosDao.getPhotosDao(21267), string.Empty)
				};
				list.Add(item);
			}
			return list;
		}

		public List<PhotoInfo> GetPhotoList(DateTime? FromTime, DateTime? ToTime, int? UserId, int? LocationId, string SubStoreIDs)
		{
			base.DBParameters.Clear();
			string expr_EF = PhotosDao.getPhotosDao(3514);
			object expr_105 = base.SetNullIntegerValue(UserId);
			if (5 != 0)
			{
				base.AddParameter(expr_EF, expr_105);
			}
			if (!false)
			{
				base.AddParameter(PhotosDao.getPhotosDao(3740), base.SetNullIntegerValue(LocationId));
			}
			base.AddParameter(PhotosDao.getPhotosDao(22031), base.SetNullDateTimeValue(FromTime));
			do
			{
				base.AddParameter(PhotosDao.getPhotosDao(22052), base.SetNullDateTimeValue(ToTime));
				base.AddParameter(PhotosDao.getPhotosDao(22069), base.SetNullStringValue(SubStoreIDs));
			}
			while (3 == 0);
			IDataReader dataReader =null; //base.ExecuteReader(#1j.#Gf);
			List<PhotoInfo> result = this.PhotoInfodc(dataReader);
			dataReader.Close();
			return result;
		}

		private List<PhotoInfo> PhotoInfodc(IDataReader IDataReader)
		{
			List<PhotoInfo> list;
			while (true)
			{
				IL_00:
				list = new List<PhotoInfo>();
				while (IDataReader.Read())
				{
					PhotoInfo photoInfo = new PhotoInfo();
					photoInfo.DG_Photos_UserID = new int?(base.GetFieldValue(IDataReader,          PhotosDao.getPhotosDao(20773), 0));
					photoInfo.DG_User_Name = base.GetFieldValue(IDataReader,                       PhotosDao.getPhotosDao(622), string.Empty);
					photoInfo.DG_Photos_FileName = base.GetFieldValue(IDataReader,                 PhotosDao.getPhotosDao(20698), string.Empty);
					photoInfo.DG_Photos_CreatedOn = base.GetFieldValue(IDataReader,                PhotosDao.getPhotosDao(20723), DateTime.Now);
					photoInfo.DG_Photos_RFID = base.GetFieldValue(IDataReader,                     PhotosDao.getPhotosDao(20752), string.Empty);
					photoInfo.DG_Photos_Background = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20798), string.Empty);
					photoInfo.DG_Photos_Frame = base.GetFieldValue(IDataReader,                    PhotosDao.getPhotosDao(20827), string.Empty);
					photoInfo.DG_Photos_DateTime = new DateTime?(base.GetFieldValue(IDataReader,   PhotosDao.getPhotosDao(20848), DateTime.Now));
					photoInfo.DG_Photos_pkey = base.GetFieldValue(IDataReader,                     PhotosDao.getPhotosDao(20677), 0);
					photoInfo.DG_Photos_Layering = base.GetFieldValue(IDataReader,                 PhotosDao.getPhotosDao(20873), string.Empty);
					photoInfo.DG_Photos_Effects = base.GetFieldValue(IDataReader,                  PhotosDao.getPhotosDao(20898), string.Empty);
					photoInfo.DG_Photos_IsCroped = new bool?(base.GetFieldValue(IDataReader,       PhotosDao.getPhotosDao(20923), false));
					if (false)
					{
						goto IL_00;
					}
					photoInfo.DG_Photos_IsRedEye = new bool?(base.GetFieldValue(IDataReader,       PhotosDao.getPhotosDao(20948), false));
					photoInfo.DG_Photos_Archive = new bool?(base.GetFieldValue(IDataReader,        PhotosDao.getPhotosDao(21044), false));
					photoInfo.DG_Location_Id = new int?(base.GetFieldValue(IDataReader,            PhotosDao.getPhotosDao(16290), 0));
					photoInfo.DG_SubStoreId = new int?(base.GetFieldValue(IDataReader,             PhotosDao.getPhotosDao(21090), 0));
					photoInfo.DG_IsCodeType = base.GetFieldValue(IDataReader,                      PhotosDao.getPhotosDao(21111), false);
					photoInfo.DateTaken = new DateTime?(base.GetFieldValue(IDataReader,            PhotosDao.getPhotosDao(21132), DateTime.Now));
					photoInfo.RfidScanType = new int?(base.GetFieldValue(IDataReader,              PhotosDao.getPhotosDao(21145), 0));
					PhotoInfo item = photoInfo;
					list.Add(item);
				}
				break;
			}
			return list;
		}

		public PhotoInfo GetLastGeneratedNumber(int UserID)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(PhotosDao.getPhotosDao (22094), UserID);
			}
			IDataReader dataReader=null;
			PhotoInfo result;
			if (!false)
			{
				//dataReader = base.ExecuteReader(#1j.#1h);
				if (3 != 0)
				{
					result = this.PhotoInfoec(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private PhotoInfo PhotoInfoec(IDataReader IDataReader)
		{
			PhotoInfo result;
			while (true)
			{
				IL_00:
				if (-1 != 0)
				{
					result = null;
				}
				while (IDataReader.Read())
				{
					PhotoInfo photoInfo = new PhotoInfo();
					photoInfo.DG_Photos_RFID = base.GetFieldValue(IDataReader, PhotosDao.getPhotosDao(22107), string.Empty);
					if (false || false)
					{
						break;
					}
					if (-1 == 0)
					{
						goto IL_00;
					}
					result = photoInfo;
				}
				break;
			}
			return result;
		}

		public PhotoInfo GetCheckPhotos(string Photono, int PhotographerID)
		{
			if (7 != 0 && !false)
			{
				base.DBParameters.Clear();
				string expr_83 = PhotosDao.getPhotosDao(22124);
				object expr_22 = PhotographerID;
				if (2 != 0)
				{
					base.AddParameter(expr_83, expr_22);
				}
				base.AddParameter(PhotosDao.getPhotosDao (20049), Photono);
			}
			PhotoInfo result;
			if (!false)
			{
				IDataReader dataReader=null;
				if (3 != 0)
				{
					//dataReader = base.ExecuteReader(#1j.#Df);
				}
				if (3 != 0)
				{
					result = this.PhotoInfofc(dataReader);
				}
				dataReader.Close();
			}
			return result;
		}

		private PhotoInfo PhotoInfofc(IDataReader IDataReader)
		{
			PhotoInfo photoInfo;
			if (true)
			{
				photoInfo = null;
			}
			IL_2C:
			while (IDataReader.Read())
			{
				if (!false)
				{
					photoInfo = new PhotoInfo();
					if (!false)
					{
						if (6 == 0)
						{
							break;
						}
						photoInfo.DG_Photos_pkey = base.GetFieldValue(IDataReader, PhotosDao.getPhotosDao(20677), 0);
					}
				}
			}
			return photoInfo;
			goto IL_2C;
		}

		public List<PhotoInfo> GetArchiveImages()
		{
			base.DBParameters.Clear();
			IDataReader dataReader=null;
			if (8 != 0)
			{
				//dataReader = base.ExecuteReader(#1j.#Pe);
			}
			List<PhotoInfo> result = this.PhotoInfogc(dataReader);
			dataReader.Close();
			return result;
		}

		private List<PhotoInfo> PhotoInfogc(IDataReader IDataReader)
		{
			if (3 == 0)
			{
				goto IL_21;
			}
			List<PhotoInfo> list = new List<PhotoInfo>();
			IL_0D:
			goto IL_BA;
			IL_21:
			PhotoInfo photoInfo;
			photoInfo.DG_Photos_pkey = base.GetFieldValue(IDataReader,                 PhotosDao.getPhotosDao(20677), 0);
			photoInfo.DG_Photos_FileName = base.GetFieldValue(IDataReader,             PhotosDao.getPhotosDao(20698), string.Empty);
			if (!false)
			{
				photoInfo.DG_Photos_CreatedOn = base.GetFieldValue(IDataReader,         PhotosDao.getPhotosDao(20723), DateTime.Now);
				photoInfo.DG_Photos_Archive = new bool?(base.GetFieldValue(IDataReader, PhotosDao.getPhotosDao(21044), false));
			}
			PhotoInfo item = photoInfo;
			list.Add(item);
			IL_BA:
			if (!IDataReader.Read())
			{
				return list;
			}
			if (6 == 0)
			{
				goto IL_0D;
			}
			PhotoInfo expr_D7 = new PhotoInfo();
			if (6 == 0)
			{
				goto IL_21;
			}
			photoInfo = expr_D7;
			goto IL_21;
		}

		public List<PhotoInfo> SetArchiveDetails(string imgname)
		{
			IDataReader dataReader=null;
			List<PhotoInfo> result;
			while (-1 != 0)
			{
				base.DBParameters.Clear();
				if (false)
				{
					break;
				}
				base.AddParameter(PhotosDao.getPhotosDao(20049), imgname);
				if (8 != 0)
				{
					if (!false)
					{
						//dataReader = base.ExecuteReader(#1j.#Oe);
						result = this.PhotoInfohc(dataReader);
						break;
					}
					break;
				}
			}
			dataReader.Close();
			return result;
		}

		private List<PhotoInfo> PhotoInfohc(IDataReader IDataReader)
		{
			List<PhotoInfo> list = new List<PhotoInfo>();
			while (IDataReader.Read())
			{
				PhotoInfo item = new PhotoInfo
				{
					DG_Photos_pkey = base.GetFieldValue(IDataReader,                   PhotosDao.getPhotosDao(20677), 0),
					DG_Photos_FileName = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20698), string.Empty),
					DG_Photos_CreatedOn = base.GetFieldValue(IDataReader,              PhotosDao.getPhotosDao(20723), DateTime.Now),
					DG_Photos_RFID = base.GetFieldValue(IDataReader,                   PhotosDao.getPhotosDao(20752), string.Empty),
					DG_Photos_UserID = new int?(base.GetFieldValue(IDataReader,        PhotosDao.getPhotosDao(20773), 0)),
					DG_Photos_Background = base.GetFieldValue(IDataReader,             PhotosDao.getPhotosDao(20798), string.Empty),
					DG_Photos_Frame = base.GetFieldValue(IDataReader,                  PhotosDao.getPhotosDao(20827), string.Empty),
					DG_Photos_DateTime = new DateTime?(base.GetFieldValue(IDataReader, PhotosDao.getPhotosDao(20848), DateTime.Now)),
					DG_Photos_Layering = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20873), string.Empty),
					DG_Photos_Effects = base.GetFieldValue(IDataReader,                PhotosDao.getPhotosDao(20898), string.Empty),
					DG_Photos_IsCroped = new bool?(base.GetFieldValue(IDataReader,     PhotosDao.getPhotosDao(20923), false)),
					DG_Photos_IsRedEye = new bool?(base.GetFieldValue(IDataReader,     PhotosDao.getPhotosDao(20948), false)),
					DG_Photos_IsGreen = new bool?(base.GetFieldValue(IDataReader,      PhotosDao.getPhotosDao(20973), false)),
					DG_Photos_MetaData = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20998), string.Empty),
					DG_Photos_Sizes = base.GetFieldValue(IDataReader,                  PhotosDao.getPhotosDao(21023), string.Empty),
					DG_Photos_Archive = new bool?(base.GetFieldValue(IDataReader,      PhotosDao.getPhotosDao(21044), false)),
					DG_Location_Id = new int?(base.GetFieldValue(IDataReader,          PhotosDao.getPhotosDao(21069), 0)),
					DG_SubStoreId = new int?(base.GetFieldValue(IDataReader,           PhotosDao.getPhotosDao(21090), 0)),
					DG_IsCodeType = base.GetFieldValue(IDataReader,                    PhotosDao.getPhotosDao(21111), false),
					DateTaken = new DateTime?(base.GetFieldValue(IDataReader,          PhotosDao.getPhotosDao(21132), DateTime.Now)),
					RfidScanType = new int?(base.GetFieldValue(IDataReader,            PhotosDao.getPhotosDao(21145), 0))
				};
				list.Add(item);
			}
			return list;
		}

		public PhotoInfo GetPhotoNameByPhotoID(long Photos_pkey)
		{
			base.DBParameters.Clear();
			base.AddParameter(PhotosDao.getPhotosDao(20610), Photos_pkey);
			IDataReader dataReader;
			if (true && !false)
			{
				dataReader =null; //base.ExecuteReader(#1j.#Si);
			}
			List<PhotoInfo> source;
			do
			{
				source = this.PhotoInfoic(dataReader);
			}
			while (false);
			dataReader.Close();
			return source.FirstOrDefault<PhotoInfo>();
		}

		private List<PhotoInfo> PhotoInfoic(IDataReader IDataReader)
		{
			List<PhotoInfo> list = new List<PhotoInfo>();
			while (true)
			{
				if (4 == 0)
				{
					goto IL_72;
				}
				IL_79:
				PhotoInfo photoInfo;
				if (!IDataReader.Read())
				{
					if (5 != 0)
					{
						break;
					}
				}
				else if (8 != 0)
				{
					if (5 == 0)
					{
						continue;
					}
					photoInfo = new PhotoInfo();
					photoInfo.DG_Photos_FileName = base.GetFieldValue(IDataReader, PhotosDao.getPhotosDao (20698), string.Empty);
				}
				if (!false)
				{
					photoInfo.DG_Photos_CreatedOn = base.GetFieldValue(IDataReader, PhotosDao.getPhotosDao (20723), DateTime.Now);
				}
				PhotoInfo item = photoInfo;
				IL_72:
				list.Add(item);
				goto IL_79;
			}
			return list;
		}

		public List<PhotoInfo> GetPhotoRFIDByPhotoIDList(string photoIdList)
		{
			IDataReader dataReader=null;
			List<PhotoInfo> result;
			while (-1 != 0)
			{
				base.DBParameters.Clear();
				if (false)
				{
					break;
				}
				base.AddParameter(PhotosDao.getPhotosDao(22149), photoIdList);
				if (8 != 0)
				{
					if (!false)
					{
						//dataReader = base.ExecuteReader(#1j.#ye);
						result = this.PhotoInfojc(dataReader);
						break;
					}
					break;
				}
			}
			dataReader.Close();
			return result;
		}

		private List<PhotoInfo> PhotoInfojc(IDataReader IDataReader)
		{
			List<PhotoInfo> list = new List<PhotoInfo>();
			while (IDataReader.Read())
			{
				PhotoInfo item = new PhotoInfo
				{
					DG_Photos_pkey = base.GetFieldValue(IDataReader,      PhotosDao.getPhotosDao(20677), 0),
					DG_Photos_RFID = base.GetFieldValue(IDataReader,      PhotosDao.getPhotosDao(20752), string.Empty),
					DG_Photos_FileName = base.GetFieldValue(IDataReader,  PhotosDao.getPhotosDao(20698), string.Empty),
					DG_Photos_CreatedOn = base.GetFieldValue(IDataReader, PhotosDao.getPhotosDao(20723), DateTime.Now),
					HotFolderPath = base.GetFieldValue(IDataReader,       PhotosDao.getPhotosDao(21162), string.Empty)
				};
				list.Add(item);
			}
			return list;
		}

		public PhotoInfo GetPhotoRFIDByPhotoID(long Photos_pkey)
		{
			base.DBParameters.Clear();
			base.AddParameter(PhotosDao.getPhotosDao(20610), Photos_pkey);
			IDataReader dataReader=null;
			if (true && !false)
			{
				//dataReader = base.ExecuteReader(#1j.#hj);
			}
			List<PhotoInfo> source;
			do
			{
				source = this.PhotoInfokc(dataReader);
			}
			while (false);
			dataReader.Close();
			return source.FirstOrDefault<PhotoInfo>();
		}

		private List<PhotoInfo> PhotoInfokc(IDataReader IDataReader)
		{
			List<PhotoInfo> list = new List<PhotoInfo>();
			while (true)
			{
				while (IDataReader.Read())
				{
					PhotoInfo photoInfo = new PhotoInfo();
					if (true)
					{
						photoInfo.DG_Photos_pkey = base.GetFieldValue(IDataReader,      PhotosDao.getPhotosDao(20677), 0);
						photoInfo.DG_Photos_RFID = base.GetFieldValue(IDataReader,      PhotosDao.getPhotosDao(20752), string.Empty);
						photoInfo.DG_Photos_CreatedOn = base.GetFieldValue(IDataReader, PhotosDao.getPhotosDao(20723), DateTime.Now);
						PhotoInfo item = photoInfo;
						list.Add(item);
					}
				}
				break;
			}
			return list;
		}

		public List<PhotoInfo> GetPhotosBasedonRFID(int SubstoreId, string RFID)
		{
			if (7 != 0 && !false)
			{
				base.DBParameters.Clear();
                string expr_83 = PhotosDao.getPhotosDao(3794);
				object expr_22 = SubstoreId;
				if (2 != 0)
				{
					base.AddParameter(expr_83, expr_22);
				}
				base.AddParameter(PhotosDao.getPhotosDao(22174), RFID);
			}
			List<PhotoInfo> result;
			if (!false)
			{
				IDataReader dataReader=null;
				if (3 != 0)
				{
					//dataReader = base.ExecuteReader(#1j.#gj);
				}
				if (3 != 0)
				{
					result = this.PhotoInfolc(dataReader);
				}
				dataReader.Close();
			}
			return result;
		}

		private List<PhotoInfo> PhotoInfolc(IDataReader IDataReader)
		{
			List<PhotoInfo> expr_357 = new List<PhotoInfo>();
			List<PhotoInfo> list;
			if (7 != 0)
			{
				list = expr_357;
			}
			while (IDataReader.Read())
			{
				PhotoInfo item = new PhotoInfo
				{
					DG_Photos_pkey = base.GetFieldValue(IDataReader,                   PhotosDao.getPhotosDao(20677), 0),
					DG_Photos_FileName = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20698), string.Empty),
					DG_Photos_CreatedOn = base.GetFieldValue(IDataReader,              PhotosDao.getPhotosDao(20723), DateTime.Now),
					DG_Photos_RFID = base.GetFieldValue(IDataReader,                   PhotosDao.getPhotosDao(20752), string.Empty),
					DG_Photos_UserID = new int?(base.GetFieldValue(IDataReader,        PhotosDao.getPhotosDao(20773), 0)),
					DG_Photos_Background = base.GetFieldValue(IDataReader,             PhotosDao.getPhotosDao(20798), string.Empty),
					DG_Photos_Frame = base.GetFieldValue(IDataReader,                  PhotosDao.getPhotosDao(20827), string.Empty),
					DG_Photos_DateTime = new DateTime?(base.GetFieldValue(IDataReader, PhotosDao.getPhotosDao(20848), DateTime.Now)),
					DG_Photos_Layering = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20873), string.Empty),
					DG_Photos_Effects = base.GetFieldValue(IDataReader,                PhotosDao.getPhotosDao(20898), string.Empty),
					DG_Photos_IsCroped = new bool?(base.GetFieldValue(IDataReader,     PhotosDao.getPhotosDao(20923), false)),
					DG_Photos_IsRedEye = new bool?(base.GetFieldValue(IDataReader,     PhotosDao.getPhotosDao(20948), false)),
					DG_Photos_IsGreen = new bool?(base.GetFieldValue(IDataReader,      PhotosDao.getPhotosDao(20973), false)),
					DG_Photos_MetaData = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(20998), string.Empty),
					DG_Photos_Sizes = base.GetFieldValue(IDataReader,                  PhotosDao.getPhotosDao(21023), string.Empty),
					DG_Photos_Archive = new bool?(base.GetFieldValue(IDataReader,      PhotosDao.getPhotosDao(21044), false)),
					DG_Location_Id = new int?(base.GetFieldValue(IDataReader,          PhotosDao.getPhotosDao(21069), 0)),
					DG_SubStoreId = new int?(base.GetFieldValue(IDataReader,           PhotosDao.getPhotosDao(21090), 0)),
					DG_IsCodeType = base.GetFieldValue(IDataReader,                    PhotosDao.getPhotosDao(21111), false),
					DateTaken = new DateTime?(base.GetFieldValue(IDataReader,          PhotosDao.getPhotosDao(21132), DateTime.Now)),
					RfidScanType = new int?(base.GetFieldValue(IDataReader,            PhotosDao.getPhotosDao(21145), 0)),
					DG_MediaType = base.GetFieldValue(IDataReader,                     PhotosDao.getPhotosDao(21183), 1),
					SemiOrderProfileId = base.GetFieldValue(IDataReader,               PhotosDao.getPhotosDao(21221), 0),
					OnlineQRCode = base.GetFieldValue(IDataReader,                     PhotosDao.getPhotosDao(21267), string.Empty)
				};
				list.Add(item);
			}
			return list;
		}

		public List<PhotoGraphersInfo> GetPhotoGrapher()
		{
			base.DBParameters.Clear();
			IDataReader dataReader=null;
			if (8 != 0)
			{
				//dataReader = base.ExecuteReader(#1j.#Ag);
			}
			List<PhotoGraphersInfo> result = this.PhotoGraphersInfomc(dataReader);
			dataReader.Close();
			return result;
		}

		private List<PhotoGraphersInfo> PhotoGraphersInfomc(IDataReader IDataReader)
		{
			List<PhotoGraphersInfo> list = new List<PhotoGraphersInfo>();
			while (true)
			{
				while (IDataReader.Read())
				{
					PhotoGraphersInfo photoGraphersInfo = new PhotoGraphersInfo();
					if (true)
					{
						photoGraphersInfo.DG_User_pkey = base.GetFieldValue(IDataReader,     PhotosDao.getPhotosDao(689), 0);
						photoGraphersInfo.DG_User_Roles_Id = base.GetFieldValue(IDataReader, PhotosDao.getPhotosDao(22191), 0);
						photoGraphersInfo.Photograper = base.GetFieldValue(IDataReader,      PhotosDao.getPhotosDao(22216), string.Empty);
						PhotoGraphersInfo item = photoGraphersInfo;
						list.Add(item);
					}
				}
				break;
			}
			return list;
		}

		public DG_PhotoGroupInfo GetGroupName(string Group_Name)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(PhotosDao.getPhotosDao(22233), Group_Name);
			}
			IDataReader dataReader =null;// base.ExecuteReader(#1j.#Li);
			List<DG_PhotoGroupInfo> source = this.DG_PhotoGroupInfonc(dataReader);
			dataReader.Close();
			return source.FirstOrDefault<DG_PhotoGroupInfo>();
		}

		private List<DG_PhotoGroupInfo> DG_PhotoGroupInfonc(IDataReader IDataReader)
		{
			List<DG_PhotoGroupInfo> list = new List<DG_PhotoGroupInfo>();
			while (true)
			{
				while (true)
				{
					DG_PhotoGroupInfo dG_PhotoGroupInfo;
					if (IDataReader.Read())
					{
						dG_PhotoGroupInfo = new DG_PhotoGroupInfo();
						goto IL_19;
					}
					if (!false)
					{
						return list;
					}
					goto IL_C9;
					IL_EC:
					if (7 != 0)
					{
						DG_PhotoGroupInfo item = dG_PhotoGroupInfo;
						list.Add(item);
						break;
					}
					break;
					IL_19:
					dG_PhotoGroupInfo.DG_Group_pkey = base.GetFieldValue(IDataReader, PhotosDao.getPhotosDao(15954), 0L);
					dG_PhotoGroupInfo.DG_Group_Name = base.GetFieldValue(IDataReader, PhotosDao.getPhotosDao(15975), string.Empty);
					if (false)
					{
						goto IL_EC;
					}
					dG_PhotoGroupInfo.DG_Photo_ID = base.GetFieldValue(IDataReader,    PhotosDao.getPhotosDao(22258), 0);
					dG_PhotoGroupInfo.DG_Photo_RFID = base.GetFieldValue(IDataReader,  PhotosDao.getPhotosDao(22275), string.Empty);
					dG_PhotoGroupInfo.DG_CreatedDate = base.GetFieldValue(IDataReader, PhotosDao.getPhotosDao(22296), DateTime.Now);
					IL_C9:
					if (5 != 0)
					{
						dG_PhotoGroupInfo.DG_SubstoreId = base.GetFieldValue(IDataReader, PhotosDao.getPhotosDao(22317), 0);
						goto IL_EC;
					}
					goto IL_19;
				}
			}
			return list;
		}

		public bool DeletePhotoByName(string name)
		{
			do
			{
				base.DBParameters.Clear();
			}
			while (8 == 0);
			base.AddParameter(PhotosDao.getPhotosDao(1180), name);
			if (7 != 0)
			{
				//base.ExecuteNonQuery(#1j.#pe);
			}
			return true;
		}

		public void SaveGroupData(DataTable udt_Group)
		{
			if (4 != 0)
			{
				base.DBParameters.Clear();
				base.AddParameter(PhotosDao.getPhotosDao (22338), udt_Group);
				//base.ExecuteReader(#1j.#le);
			}
		}

		public void GetMaxId(int? substoreId, out long maxPhotoId, int mediaType)
		{
			maxPhotoId = 0L;
			List<SqlParameter> expr_9A = base.DBParameters;
			if (!false)
			{
				expr_9A.Clear();
			}
			base.AddParameter(PhotosDao.getPhotosDao(2332), base.SetNullIntegerValue(substoreId));
			base.AddParameter(PhotosDao.getPhotosDao(21618), mediaType);
			IDataReader dataReader=null;
			if (!false)
			{
				//dataReader = base.ExecuteReader(#1j.#ke);
				if (!dataReader.Read())
				{
					return;
				}
			}
			maxPhotoId = base.GetFieldValue(dataReader, PhotosDao.getPhotosDao (20677), 0L);
		}

		public int GetMaxPhotoIdsequence()
		{
			int result;
			do
			{
				base.DBParameters.Clear();
				int num = 0;
				if (!false)
				{
					base.AddParameter(PhotosDao.getPhotosDao(22359), num, ParameterDirection.Output);
					if (!false)
					{
						//base.ExecuteNonQuery(#1j.#he);
						result = (int)base.GetOutParameterValue(PhotosDao.getPhotosDao(22359));
					}
				}
			}
			while (2 == 0);
			return result;
		}

		public int GetMaxUserIdsequence(long frmImgId, long toImgId, string PhotoGrapherID)
		{
			base.DBParameters.Clear();
			int num = 0;
			base.AddParameter(PhotosDao.getPhotosDao(22388), frmImgId);
			base.AddParameter(PhotosDao.getPhotosDao(22425), toImgId);
			base.AddParameter(PhotosDao.getPhotosDao(22462), Convert.ToInt32(PhotoGrapherID));
			base.AddParameter(PhotosDao.getPhotosDao(22503), num, ParameterDirection.Output);
			//base.ExecuteNonQuery(#1j.#ge);
			return (int)base.GetOutParameterValue(PhotosDao.getPhotosDao (22503));
		}

		public bool ResetImageProcessedStatus(int PhotoId, int SubStoreId)
		{
			while (true)
			{
				base.DBParameters.Clear();
				if (4 != 0)
				{
					base.AddParameter(PhotosDao.getPhotosDao(22536), PhotoId);
					if (-1 != 0)
					{
						break;
					}
				}
			}
			base.AddParameter(PhotosDao.getPhotosDao(22549), SubStoreId);
			if (4 != 0)
			{
				base.ExecuteNonQuery(PhotosDao.getPhotosDao(22566));
			}
			return true;
		}

		public string GetPhotoPlayerScore(string photoId)
		{
			base.DBParameters.Clear();
			do
			{
				string arg_0E_0 = string.Empty;
			}
			while (7 == 0);
			base.AddParameter(PhotosDao.getPhotosDao(22359), photoId);
			base.AddOutParameterString(PhotosDao.getPhotosDao(22611), SqlDbType.NVarChar, 350);
			//base.ExecuteNonQuery(#1j.#Sd);
			return (string)base.GetOutParameterValue(PhotosDao.getPhotosDao(22611));
		}

		public string GetVideoFrameCropRatio(int locationId)
		{
			if (true)
			{
				base.DBParameters.Clear();
				base.AddParameter(PhotosDao.getPhotosDao (22648), locationId);
			}
			return Convert.ToString(base.ExecuteScalar(PhotosDao.getPhotosDao(22673)));
		}

		static PhotosDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(PhotosDao));
		}
	}
}
