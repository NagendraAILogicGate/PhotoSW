using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using ErrorHandler;
using FrameworkHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PhotoSW
{
	public static class RobotImageLoader
	{
		public static LstMyItems curItem;

		public static bool IsLastPage;

		public static bool IsNextPage = false;

		public static int StartIndex = 0;

		public static long StartIndexRFID = 0L;

		public static long MaxPhotoId = 0L;

		public static long MinPhotoId = 0L;

		public static long MaxPhotoIdCriteria = 0L;

		public static long MinPhotoIdCriteria = 0L;

		public static long ImgCount = 0L;

		public static bool IsMorePrevImages = true;

		public static bool IsMoreNextImages = false;

		public static int? CharacterId = new int?(0);

		public static int StopIndex = 0;

		public static int BeforerPinterCount = 0;

		public static bool IsZeroSearchNeeded = false;

		public static System.Collections.Generic.List<string> ViewGroupedImagesCount;

		public static int NewRecord = 0;

		public static int _rfidSearch = 0;

		public static System.Collections.Generic.List<LstMyItems> NotPrintedImages;

		public static System.Collections.Generic.List<LstMyItems> PrintImages;

		public static System.Collections.Generic.List<string> LstUnlocknames;

		public static System.Collections.Generic.List<LstMyItems> robotImages;

		public static System.Collections.Generic.List<LstMyItems> GroupImages;

		public static string RFID = "1";

		public static string SearchCriteria;

		public static string FilePath;

		public static System.DateTime FromTime;

		public static System.DateTime ToTime;

		public static int UserId;

		public static string PageName;

		public static int LocationId;

		public static string PhotoId;

		public static string GroupId;

		public static int UniquePhotoId;

		public static string SearchedStoreId;

		public static string Code;

		public static int CodeType;

		public static bool IsAnonymousQrCodeEnabled;

		public static bool isGroup = false;

		public static int ListPosition;

		public static int totalCount = 0;

		public static int currentCount;

		public static int startLoad;

		public static System.Collections.Generic.List<LstMyItems> _objnewincrement = new System.Collections.Generic.List<LstMyItems>();

		public static int thumbSet = 20;

		public static int MediaTypes = 0;

		public static bool Is9ImgViewActive = false;

		public static bool Is16ImgViewActive = false;

		public static bool IsPreview9or16active = false;

		public static bool IsPreviewModeActive = false;

       
        public static System.Collections.Generic.List<LstMyItems> LoadImages()
		{
			System.Collections.Generic.List<LstMyItems> list = new System.Collections.Generic.List<LstMyItems>();
			SearchDetailInfo searchdetails = new SearchDetailInfo();
			SearchCriteriaInfo searchBiz = new SearchCriteriaInfo();
			System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(LoginUser.DigiFolderPath);
			string ssInfo = RobotImageLoader.GetShowAllSubstorePhotos() ? string.Empty : LoginUser.DefaultSubstores;
			System.Collections.Generic.List<ModratePhotoInfo> moderatePhotosList = new System.Collections.Generic.List<ModratePhotoInfo>();
			PhotoBusiness photoBusiness = new PhotoBusiness();
			moderatePhotosList = photoBusiness.GetModeratePhotos();
			System.Collections.Generic.List<LstMyItems> result;
			try
			{
				if (RobotImageLoader.SearchCriteria == "TimeWithQrcode")
				{
					Stopwatch stopwatch = CommonUtility.Watch();
					stopwatch.Start();
					list = RobotImageLoader.SelectPhotoByTimeAndQRCode(list, searchdetails, searchBiz, moderatePhotosList);
					if (stopwatch != null)
					{
						CommonUtility.WatchStop("Search TimeWithQrcode", stopwatch);
					}
				}
				else if (RobotImageLoader.SearchCriteria == "Time")
				{
					Stopwatch stopwatch = CommonUtility.Watch();
					stopwatch.Start();
					RobotImageLoader.SelectPhotoByTime(list, moderatePhotosList, photoBusiness);
					if (stopwatch != null)
					{
						CommonUtility.WatchStop("Search Time", stopwatch);
					}
				}
				else if (RobotImageLoader.SearchCriteria == "Group")
				{
					Stopwatch stopwatch = CommonUtility.Watch();
					stopwatch.Start();
					RobotImageLoader.SelectPhotoByGroup(list, moderatePhotosList, photoBusiness);
					if (stopwatch != null)
					{
						CommonUtility.WatchStop("Search Group", stopwatch);
					}
				}
				else if (RobotImageLoader.SearchCriteria == "QRCODE")
				{
					Stopwatch stopwatch = CommonUtility.Watch();
					stopwatch.Start();
					RobotImageLoader.SelectPhotoByQRCode(list, moderatePhotosList, photoBusiness);
					if (stopwatch != null)
					{
						CommonUtility.WatchStop("Search QRCODE", stopwatch);
					}
				}
				else if (RobotImageLoader.SearchCriteria == "QRCODEGROUP")
				{
					Stopwatch stopwatch = CommonUtility.Watch();
					stopwatch.Start();
					RobotImageLoader.SelectPhotoByQRCodeGroup(list, moderatePhotosList, photoBusiness);
					if (stopwatch != null)
					{
						CommonUtility.WatchStop("Search QRCODE GROUP", stopwatch);
					}
				}
				else if (RobotImageLoader.RFID == "0")
				{
					Stopwatch stopwatch = CommonUtility.Watch();
					stopwatch.Start();
					RobotImageLoader.SelectPhotoByZeroSearch(list, ssInfo, moderatePhotosList, photoBusiness, RobotImageLoader.MediaTypes);					
                    if (stopwatch != null)
					{
						CommonUtility.WatchStop("Search 0", stopwatch);
					}
				}
				else
				{
					Stopwatch stopwatch = CommonUtility.Watch();
					stopwatch.Start();
					RobotImageLoader.SelectPhotoByRFID(list, moderatePhotosList, photoBusiness);
					if (stopwatch != null)
					{
						CommonUtility.WatchStop("Search RFID", stopwatch);
					}
				}
				if (RobotImageLoader.SearchCriteria == "Group")
				{
					RobotImageLoader.GroupImages = list;
				}
				else if (RobotImageLoader.SearchCriteria == "Time")
				{
					RobotImageLoader.robotImages = list;
				}
				else if (RobotImageLoader.SearchCriteria == "TimeWithQrcode")
				{
					RobotImageLoader.robotImages = list;
				}
				else if (RobotImageLoader.SearchCriteria == "QRCODE")
				{
					RobotImageLoader.robotImages = list;
				}
				else if (RobotImageLoader._objnewincrement.Count == 0 && list.Count != 0)
				{
					RobotImageLoader.robotImages = list;
				}
				else
				{
					RobotImageLoader.robotImages = RobotImageLoader._objnewincrement;
				}
				result = RobotImageLoader.robotImages;
			}
			catch (System.Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
				result = RobotImageLoader.robotImages;
			}
			finally
			{
			}
			return result;
		}

		public static System.Collections.Generic.List<LstMyItems> LoadImages(SearchDetailInfo Searchdetails)
		{
			System.Collections.Generic.List<LstMyItems> list = new System.Collections.Generic.List<LstMyItems>();
			SearchCriteriaInfo searchBiz = new SearchCriteriaInfo();
			string ssInfo = RobotImageLoader.GetShowAllSubstorePhotos() ? string.Empty : LoginUser.DefaultSubstores;
			System.Collections.Generic.List<ModratePhotoInfo> moderatePhotosList = new System.Collections.Generic.List<ModratePhotoInfo>();
			PhotoBusiness photoBusiness = new PhotoBusiness();
			moderatePhotosList = photoBusiness.GetModeratePhotos();
			System.Collections.Generic.List<LstMyItems> result;
			try
			{
				if (RobotImageLoader.SearchCriteria == "TimeWithQrcode")
				{
					Stopwatch stopwatch = CommonUtility.Watch();
					stopwatch.Start();
					list = RobotImageLoader.SelectPhotoByTimeAndQRCode(list, Searchdetails, searchBiz, moderatePhotosList);
					if (stopwatch != null)
					{
						CommonUtility.WatchStop("Search TimeWithQrcode", stopwatch);
					}
				}
				else if (RobotImageLoader.SearchCriteria == "Time")
				{
					Stopwatch stopwatch = CommonUtility.Watch();
					stopwatch.Start();
					RobotImageLoader.SelectPhotoByTime(list, moderatePhotosList, photoBusiness);
					if (stopwatch != null)
					{
						CommonUtility.WatchStop("Search Time", stopwatch);
					}
				}
				else if (RobotImageLoader.SearchCriteria == "Group")
				{
					Stopwatch stopwatch = CommonUtility.Watch();
					stopwatch.Start();
					RobotImageLoader.SelectPhotoByGroup(list, moderatePhotosList, photoBusiness);
					if (stopwatch != null)
					{
						CommonUtility.WatchStop("Search Group", stopwatch);
					}
				}
				else if (RobotImageLoader.SearchCriteria == "QRCODE")
				{
					Stopwatch stopwatch = CommonUtility.Watch();
					stopwatch.Start();
					RobotImageLoader.SelectPhotoByQRCode(list, moderatePhotosList, photoBusiness);
					if (stopwatch != null)
					{
						CommonUtility.WatchStop("Search QRCODE", stopwatch);
					}
				}
				else if (RobotImageLoader.SearchCriteria == "QRCODEGROUP")
				{
					Stopwatch stopwatch = CommonUtility.Watch();
					stopwatch.Start();
					RobotImageLoader.SelectPhotoByQRCodeGroup(list, moderatePhotosList, photoBusiness);
					if (stopwatch != null)
					{
						CommonUtility.WatchStop("Search QRCODE GROUP", stopwatch);
					}
				}
				else if (RobotImageLoader.RFID == "0")
				{
					Stopwatch stopwatch = CommonUtility.Watch();
					stopwatch.Start();
					RobotImageLoader.SelectPhotoByZeroSearch(list, ssInfo, moderatePhotosList, photoBusiness, RobotImageLoader.MediaTypes);
					if (stopwatch != null)
					{
						CommonUtility.WatchStop("Search 0", stopwatch);
					}
				}
				else
				{
					Stopwatch stopwatch = CommonUtility.Watch();
					stopwatch.Start();
					RobotImageLoader.SelectPhotoByRFID(list, moderatePhotosList, photoBusiness);
					if (stopwatch != null)
					{
						CommonUtility.WatchStop("Search RFID", stopwatch);
					}
				}
				if (RobotImageLoader.SearchCriteria == "Group")
				{
					RobotImageLoader.GroupImages = list;
				}
				else if (RobotImageLoader.SearchCriteria == "Time")
				{
					RobotImageLoader.robotImages = list;
				}
				else if (RobotImageLoader.SearchCriteria == "TimeWithQrcode")
				{
					RobotImageLoader.robotImages = list;
				}
				else if (RobotImageLoader.SearchCriteria == "QRCODE")
				{
					RobotImageLoader.robotImages = list;
				}
				else if ((RobotImageLoader._objnewincrement == null || RobotImageLoader._objnewincrement.Count == 0) && list.Count != 0)
				{
					RobotImageLoader.robotImages = list;
				}
				else
				{
					RobotImageLoader.robotImages = RobotImageLoader._objnewincrement;
				}
				result = RobotImageLoader.robotImages;
			}
			catch (System.Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
				result = RobotImageLoader.robotImages;
			}
			finally
			{
				Searchdetails = null;
			}
			return result;
		}

		private static System.Collections.Generic.List<LstMyItems> SelectPhotoByTimeAndQRCode(System.Collections.Generic.List<LstMyItems> temprobotImages, SearchDetailInfo Searchdetails, SearchCriteriaInfo SearchBiz, System.Collections.Generic.List<ModratePhotoInfo> moderatePhotosList)
		{
			if (RobotImageLoader.robotImages == null)
			{
				RobotImageLoader.robotImages = new System.Collections.Generic.List<LstMyItems>();
			}
			if (RobotImageLoader.GroupImages == null)
			{
				RobotImageLoader.GroupImages = new System.Collections.Generic.List<LstMyItems>();
			}
			if (RobotImageLoader.PrintImages == null)
			{
				RobotImageLoader.PrintImages = new System.Collections.Generic.List<LstMyItems>();
			}
			RobotImageLoader.GroupId = "";
			RobotImageLoader.IsZeroSearchNeeded = false;
			RobotImageLoader.StartIndex = 0;
			RobotImageLoader.StopIndex = 0;
			Searchdetails.FromDate = RobotImageLoader.FromTime;
			Searchdetails.ToDate = RobotImageLoader.ToTime;
			Searchdetails.Locationid = RobotImageLoader.LocationId;
			Searchdetails.Userid = RobotImageLoader.UserId;
			Searchdetails.PageSize = RobotImageLoader.thumbSet;
			Searchdetails.SubstoreId = ((RobotImageLoader.SearchedStoreId == "0") ? null : RobotImageLoader.SearchedStoreId);
			Searchdetails.CharacterId = RobotImageLoader.CharacterId;
			Searchdetails.Qrcode = RobotImageLoader.Code;
			Searchdetails.IsAnonymousQrcodeEnabled = RobotImageLoader.IsAnonymousQrCodeEnabled;
			System.Collections.Generic.List<SearchDetailInfo> list = (from o in SearchBiz.GetSearchDetailWithQrcode(Searchdetails, out RobotImageLoader.MaxPhotoIdCriteria, out RobotImageLoader.MinPhotoIdCriteria, out RobotImageLoader.ImgCount, RobotImageLoader.MediaTypes)
			orderby o.PhotoId descending
			select o).ToList<SearchDetailInfo>();
			VideoProcessingClass videoProcessingClass = new VideoProcessingClass();
			if (list.Count > 0)
			{
				Searchdetails.TotalRecords = list.FirstOrDefault<SearchDetailInfo>().TotalRecords;
				using (System.Collections.Generic.List<SearchDetailInfo>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						SearchDetailInfo photoItem = enumerator.Current;
						LstMyItems lstMyItems = new LstMyItems();
						lstMyItems.OnlineQRCode = photoItem.OnlineQRCode;
						lstMyItems.Name = photoItem.Name;
						lstMyItems.PhotoId = photoItem.PhotoId;
						lstMyItems.FileName = photoItem.FileName;
						lstMyItems.HotFolderPath = photoItem.HotFolderPath;
						lstMyItems.MediaType = photoItem.MediaType;
						lstMyItems.VideoLength = photoItem.VideoLength;
						lstMyItems.CreatedOn = photoItem.CreatedOn;
						System.Collections.Generic.IEnumerable<ModratePhotoInfo> enumerable = from x in moderatePhotosList.AsEnumerable<ModratePhotoInfo>()
						where x.DG_Mod_Photo_ID == photoItem.PhotoId
						select x;
						if (enumerable != null && enumerable.Count<ModratePhotoInfo>() > 0)
						{
							lstMyItems.FilePath = lstMyItems.HotFolderPath + "/Locked.png";
							lstMyItems.IsLocked = Visibility.Collapsed;
							lstMyItems.IsPassKeyVisible = Visibility.Visible;
						}
						else
						{
							string path = photoItem.FileName.Replace(videoProcessingClass.SupportedVideoFormats["avi"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mp4"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["wmv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mov"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["3gp"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["3g2"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["m2v"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["m4v"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["flv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mpeg"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mkv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mts"].ToString(), ".jpg");
							lstMyItems.BigThumbnailPath = System.IO.Path.Combine(lstMyItems.BigDBThumnailPath, photoItem.CreatedOn.ToString("yyyyMMdd"), path);
							lstMyItems.FilePath = System.IO.Path.Combine(lstMyItems.ThumnailPath, photoItem.CreatedOn.ToString("yyyyMMdd"), path);
							lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
							lstMyItems.IsLocked = Visibility.Visible;
							lstMyItems.IsPassKeyVisible = Visibility.Collapsed;
						}
						if (RobotImageLoader.GroupImages != null)
						{
							LstMyItems lstMyItems2 = (from t in RobotImageLoader.GroupImages
							where t.PhotoId == photoItem.PhotoId
							select t).FirstOrDefault<LstMyItems>();
							if (lstMyItems2 != null)
							{
								lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
							}
							else
							{
								lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
							}
						}
						else
						{
							lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
						}
						if (RobotImageLoader.PrintImages != null)
						{
							LstMyItems lstMyItems3 = (from t in RobotImageLoader.PrintImages
							where t.PhotoId == photoItem.PhotoId
							select t).FirstOrDefault<LstMyItems>();
							if (lstMyItems3 != null)
							{
								lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
							}
							else
							{
								lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
							}
						}
						else
						{
							lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
						}
						if (RobotImageLoader.Is9ImgViewActive)
						{
							lstMyItems.GridMainHeight = 190;
							lstMyItems.GridMainWidth = 226;
							lstMyItems.GridMainRowHeight1 = 140;
							lstMyItems.GridMainRowHeight2 = 50;
						}
						else
						{
							lstMyItems.GridMainHeight = 140;
							lstMyItems.GridMainWidth = 170;
							lstMyItems.GridMainRowHeight1 = 90;
							lstMyItems.GridMainRowHeight2 = 60;
						}
						temprobotImages.Add(lstMyItems);
					}
				}
			}
			else
			{
				temprobotImages = new System.Collections.Generic.List<LstMyItems>();
			}
			return temprobotImages;
		}

		private static void SelectPhotoByTime(System.Collections.Generic.List<LstMyItems> temprobotImages, System.Collections.Generic.List<ModratePhotoInfo> moderatePhotosList, PhotoBusiness phBiz)
		{
			RobotImageLoader.GroupId = "";
			RobotImageLoader.IsZeroSearchNeeded = false;
			RobotImageLoader.StartIndex = 0;
			RobotImageLoader.StopIndex = 0;
			if (string.IsNullOrEmpty(RobotImageLoader.SearchedStoreId))
			{
				RobotImageLoader.SearchedStoreId = LoginUser.DefaultSubstores.Split(',').FirstOrDefault(); ;
			}
			System.Collections.Generic.List<PhotoInfo> searchedPhoto = phBiz.GetSearchedPhoto(new System.DateTime?(RobotImageLoader.FromTime), new System.DateTime?(RobotImageLoader.ToTime), new int?(RobotImageLoader.UserId), new int?(RobotImageLoader.LocationId), RobotImageLoader.SearchedStoreId);
			VideoProcessingClass videoProcessingClass = new VideoProcessingClass();
			using (System.Collections.Generic.List<PhotoInfo>.Enumerator enumerator = searchedPhoto.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PhotoInfo photoItem = enumerator.Current;
					LstMyItems lstMyItems = new LstMyItems();
					lstMyItems.Name = photoItem.DG_Photos_RFID;
					lstMyItems.PhotoId = photoItem.DG_Photos_pkey;
					lstMyItems.FileName = photoItem.DG_Photos_FileName;
					lstMyItems.HotFolderPath = photoItem.HotFolderPath;
					lstMyItems.MediaType = photoItem.DG_MediaType;
					lstMyItems.VideoLength = photoItem.DG_VideoLength;
					lstMyItems.CreatedOn = photoItem.DG_Photos_CreatedOn;
					lstMyItems.OnlineQRCode = photoItem.OnlineQRCode;
					System.Collections.Generic.IEnumerable<ModratePhotoInfo> enumerable = from x in moderatePhotosList.AsEnumerable<ModratePhotoInfo>()
					where x.DG_Mod_Photo_ID == photoItem.DG_Photos_pkey
					select x;
					if (enumerable != null && enumerable.Count<ModratePhotoInfo>() > 0)
					{
						lstMyItems.FilePath = lstMyItems.HotFolderPath + "/Locked.png";
						lstMyItems.IsLocked = Visibility.Collapsed;
						lstMyItems.IsPassKeyVisible = Visibility.Visible;
					}
					else
					{
						string path = photoItem.DG_Photos_FileName.Replace(videoProcessingClass.SupportedVideoFormats["avi"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mp4"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["wmv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mov"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["3gp"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["3g2"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["m2v"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["m4v"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["flv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mpeg"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mkv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mts"].ToString(), ".jpg");
						lstMyItems.BigThumbnailPath = System.IO.Path.Combine(lstMyItems.BigDBThumnailPath, photoItem.DG_Photos_CreatedOn.ToString("yyyyMMdd"), path);
						lstMyItems.FilePath = System.IO.Path.Combine(lstMyItems.ThumnailPath, photoItem.DG_Photos_CreatedOn.ToString("yyyyMMdd"), path);
						lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
						lstMyItems.IsLocked = Visibility.Visible;
						lstMyItems.IsPassKeyVisible = Visibility.Collapsed;
					}
					if (RobotImageLoader.GroupImages != null)
					{
						LstMyItems lstMyItems2 = (from t in RobotImageLoader.GroupImages
						where t.PhotoId == photoItem.DG_Photos_pkey
						select t).FirstOrDefault<LstMyItems>();
						if (lstMyItems2 != null)
						{
							lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
						}
						else
						{
							lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
						}
					}
					else
					{
						lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
					}
					if (RobotImageLoader.PrintImages != null)
					{
						LstMyItems lstMyItems3 = (from t in RobotImageLoader.PrintImages
						where t.PhotoId == photoItem.DG_Photos_pkey
						select t).FirstOrDefault<LstMyItems>();
						if (lstMyItems3 != null)
						{
							lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
						}
						else
						{
							lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
						}
					}
					else
					{
						lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
					}
					if (RobotImageLoader.Is9ImgViewActive)
					{
						lstMyItems.GridMainHeight = 190;
						lstMyItems.GridMainWidth = 226;
						lstMyItems.GridMainRowHeight1 = 140;
						lstMyItems.GridMainRowHeight2 = 50;
					}
					else
					{
						lstMyItems.GridMainHeight = 140;
						lstMyItems.GridMainWidth = 170;
						lstMyItems.GridMainRowHeight1 = 90;
						lstMyItems.GridMainRowHeight2 = 60;
					}
					temprobotImages.Add(lstMyItems);
				}
			}
		}

		private static void SelectPhotoByGroup(System.Collections.Generic.List<LstMyItems> temprobotImages, System.Collections.Generic.List<ModratePhotoInfo> moderatePhotosList, PhotoBusiness phBiz)
		{
			RobotImageLoader.IsZeroSearchNeeded = false;
			RobotImageLoader.StartIndex = 0;
			RobotImageLoader.StopIndex = 0;
			RobotImageLoader.RFID = "";
			System.Collections.Generic.List<PhotoInfo> savedGroupImages = phBiz.GetSavedGroupImages(RobotImageLoader.GroupId);
			VideoProcessingClass videoProcessingClass = new VideoProcessingClass();
			using (System.Collections.Generic.List<PhotoInfo>.Enumerator enumerator = savedGroupImages.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PhotoInfo item = enumerator.Current;
					LstMyItems lstMyItems = new LstMyItems();
					lstMyItems.Name = item.DG_Photos_RFID;
					lstMyItems.FileName = item.DG_Photos_FileName;
					lstMyItems.PhotoId = item.DG_Photos_pkey;
					lstMyItems.HotFolderPath = item.HotFolderPath;
					lstMyItems.MediaType = item.DG_MediaType;
					lstMyItems.VideoLength = item.DG_VideoLength;
					lstMyItems.CreatedOn = item.DG_Photos_CreatedOn;
					lstMyItems.OnlineQRCode = item.OnlineQRCode;
					System.Collections.Generic.IEnumerable<ModratePhotoInfo> enumerable = from x in moderatePhotosList.AsEnumerable<ModratePhotoInfo>()
					where x.DG_Mod_Photo_ID == item.DG_Photos_pkey
					select x;
					if (enumerable != null && enumerable.Count<ModratePhotoInfo>() > 0)
					{
						lstMyItems.BigThumbnailPath = System.IO.Path.Combine(lstMyItems.BigDBThumnailPath, item.DG_Photos_CreatedOn.ToString("yyyyMMdd"), item.DG_Photos_FileName);
						lstMyItems.FilePath = lstMyItems.HotFolderPath + "/Locked.png";
						lstMyItems.IsLocked = Visibility.Collapsed;
						lstMyItems.IsPassKeyVisible = Visibility.Visible;
					}
					else
					{
						string path = item.DG_Photos_FileName.Replace(videoProcessingClass.SupportedVideoFormats["avi"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mp4"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["wmv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mov"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["3gp"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["3g2"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["m2v"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["m4v"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["flv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mpeg"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mkv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mts"].ToString(), ".jpg");
						lstMyItems.BigThumbnailPath = System.IO.Path.Combine(lstMyItems.BigDBThumnailPath, item.DG_Photos_CreatedOn.ToString("yyyyMMdd"), path);
						lstMyItems.FilePath = System.IO.Path.Combine(lstMyItems.ThumnailPath, item.DG_Photos_CreatedOn.ToString("yyyyMMdd"), path);
						if (string.IsNullOrEmpty(item.DG_Photos_Layering))
						{
							if (!string.IsNullOrEmpty(LoginUser.DefaultBorderPath))
							{
								lstMyItems.FrameBrdr = LoginUser.DefaultBorderPath;
							}
						}
						lstMyItems.IsLocked = Visibility.Visible;
						lstMyItems.IsPassKeyVisible = Visibility.Collapsed;
					}
					LstMyItems lstMyItems2 = (from t in RobotImageLoader.GroupImages
					where t.PhotoId == item.DG_Photos_pkey
					select t).FirstOrDefault<LstMyItems>();
					if (lstMyItems2 == null)
					{
						lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
						RobotImageLoader.GroupImages.Add(lstMyItems);
					}
					lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
					if (RobotImageLoader.PrintImages != null)
					{
						LstMyItems lstMyItems3 = (from t in RobotImageLoader.PrintImages
						where t.PhotoId == item.DG_Photos_pkey
						select t).FirstOrDefault<LstMyItems>();
						if (lstMyItems3 != null)
						{
							lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
						}
						else
						{
							lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
						}
					}
					else
					{
						lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
					}
					if (RobotImageLoader.Is9ImgViewActive)
					{
						lstMyItems.GridMainHeight = 190;
						lstMyItems.GridMainWidth = 226;
						lstMyItems.GridMainRowHeight1 = 140;
						lstMyItems.GridMainRowHeight2 = 50;
					}
					else
					{
						lstMyItems.GridMainHeight = 140;
						lstMyItems.GridMainWidth = 170;
						lstMyItems.GridMainRowHeight1 = 90;
						lstMyItems.GridMainRowHeight2 = 60;
					}
					temprobotImages.Add(lstMyItems);
				}
			}
		}

		private static void SelectPhotoByQRCode(System.Collections.Generic.List<LstMyItems> temprobotImages, System.Collections.Generic.List<ModratePhotoInfo> moderatePhotosList, PhotoBusiness phBiz)
		{
			if (RobotImageLoader.robotImages == null)
			{
				RobotImageLoader.robotImages = new System.Collections.Generic.List<LstMyItems>();
			}
			if (RobotImageLoader.GroupImages == null)
			{
				RobotImageLoader.GroupImages = new System.Collections.Generic.List<LstMyItems>();
			}
			if (RobotImageLoader.PrintImages == null)
			{
				RobotImageLoader.PrintImages = new System.Collections.Generic.List<LstMyItems>();
			}
			VideoProcessingClass videoProcessingClass = new VideoProcessingClass();
			System.Collections.Generic.List<PhotoInfo> imagesBYQRCode = phBiz.GetImagesBYQRCode(RobotImageLoader.Code, RobotImageLoader.IsAnonymousQrCodeEnabled);
			using (System.Collections.Generic.List<PhotoInfo>.Enumerator enumerator = imagesBYQRCode.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PhotoInfo item = enumerator.Current;
					LstMyItems lstMyItems = new LstMyItems();
					lstMyItems.HotFolderPath = item.HotFolderPath;
					lstMyItems.OnlineQRCode = item.OnlineQRCode;
					System.Collections.Generic.IEnumerable<ModratePhotoInfo> enumerable = from x in moderatePhotosList.AsEnumerable<ModratePhotoInfo>()
					where x.DG_Mod_Photo_ID == item.DG_Photos_pkey
					select x;
					if (enumerable != null && enumerable.Count<ModratePhotoInfo>() > 0)
					{
						lstMyItems.PhotoId = item.DG_Photos_pkey;
						lstMyItems.Name = item.DG_Photos_RFID;
						lstMyItems.FileName = item.DG_Photos_FileName;
						lstMyItems.BmpImageGroup = null;
						lstMyItems.FilePath = lstMyItems.HotFolderPath + "/Locked.png";
						lstMyItems.IsLocked = Visibility.Collapsed;
						lstMyItems.IsPassKeyVisible = Visibility.Visible;
					}
					else
					{
						lstMyItems.PhotoId = item.DG_Photos_pkey;
						lstMyItems.Name = item.DG_Photos_RFID;
						lstMyItems.FileName = item.DG_Photos_FileName;
						string path = item.DG_Photos_FileName.Replace(videoProcessingClass.SupportedVideoFormats["avi"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mp4"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["wmv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mov"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["3gp"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["3g2"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["m2v"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["m4v"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["flv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mpeg"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mkv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mts"].ToString(), ".jpg");
						lstMyItems.BigThumbnailPath = System.IO.Path.Combine(lstMyItems.BigDBThumnailPath, item.DG_Photos_CreatedOn.ToString("yyyyMMdd"), path);
						lstMyItems.FilePath = System.IO.Path.Combine(lstMyItems.ThumnailPath, item.DG_Photos_CreatedOn.ToString("yyyyMMdd"), path);
						if (string.IsNullOrEmpty(item.DG_Photos_Layering))
						{
							if (!string.IsNullOrEmpty(LoginUser.DefaultBorderPath))
							{
								lstMyItems.FrameBrdr = LoginUser.DefaultBorderPath;
							}
						}
						lstMyItems.IsLocked = Visibility.Visible;
						lstMyItems.IsPassKeyVisible = Visibility.Collapsed;
					}
					if (RobotImageLoader.GroupImages != null)
					{
						LstMyItems lstMyItems2 = (from t in RobotImageLoader.GroupImages
						where t.PhotoId == item.DG_Photos_pkey
						select t).FirstOrDefault<LstMyItems>();
						if (lstMyItems2 != null)
						{
							lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
						}
						else
						{
							lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
						}
					}
					else
					{
						lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
					}
					if (RobotImageLoader.PrintImages != null)
					{
						LstMyItems lstMyItems3 = (from t in RobotImageLoader.PrintImages
						where t.PhotoId == item.DG_Photos_pkey
						select t).FirstOrDefault<LstMyItems>();
						if (lstMyItems3 != null)
						{
							lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
						}
						else
						{
							lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
						}
					}
					else
					{
						lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
					}
					LstMyItems lstMyItems4 = (from t in RobotImageLoader.robotImages
					where t.PhotoId == item.DG_Photos_pkey
					select t).FirstOrDefault<LstMyItems>();
					if (lstMyItems4 == null)
					{
						LstMyItems lstMyItems5 = (from gp1 in RobotImageLoader.GroupImages
						where gp1.PhotoId == item.DG_Photos_pkey
						select gp1).FirstOrDefault<LstMyItems>();
						if (lstMyItems5 != null)
						{
							lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
						}
						else
						{
							lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
						}
						LstMyItems lstMyItems6 = (from pr1 in RobotImageLoader.PrintImages
						where pr1.PhotoId == item.DG_Photos_pkey
						select pr1).FirstOrDefault<LstMyItems>();
						if (lstMyItems6 != null)
						{
							lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
						}
						else
						{
							lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
						}
						RobotImageLoader.robotImages.Add(lstMyItems);
					}
					if (RobotImageLoader.Is9ImgViewActive)
					{
						lstMyItems.GridMainHeight = 190;
						lstMyItems.GridMainWidth = 226;
						lstMyItems.GridMainRowHeight1 = 140;
						lstMyItems.GridMainRowHeight2 = 50;
					}
					else
					{
						lstMyItems.GridMainHeight = 140;
						lstMyItems.GridMainWidth = 170;
						lstMyItems.GridMainRowHeight1 = 90;
						lstMyItems.GridMainRowHeight2 = 60;
					}
					temprobotImages.Add(lstMyItems);
				}
			}
		}

		private static void SelectPhotoByQRCodeGroup(System.Collections.Generic.List<LstMyItems> temprobotImages, System.Collections.Generic.List<ModratePhotoInfo> moderatePhotosList, PhotoBusiness phBiz)
		{
			RobotImageLoader.IsZeroSearchNeeded = false;
			RobotImageLoader.StartIndex = 0;
			RobotImageLoader.StopIndex = 0;
			RobotImageLoader.RFID = "";
			if (RobotImageLoader.GroupImages == null)
			{
				RobotImageLoader.GroupImages = new System.Collections.Generic.List<LstMyItems>();
			}
			VideoProcessingClass videoProcessingClass = new VideoProcessingClass();
			System.Collections.Generic.List<PhotoInfo> imagesBYQRCode = phBiz.GetImagesBYQRCode(RobotImageLoader.Code, RobotImageLoader.IsAnonymousQrCodeEnabled);
			using (System.Collections.Generic.List<PhotoInfo>.Enumerator enumerator = imagesBYQRCode.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PhotoInfo item = enumerator.Current;
					LstMyItems lstMyItems = new LstMyItems();
					lstMyItems.Name = item.DG_Photos_RFID;
					lstMyItems.FileName = item.DG_Photos_FileName;
					lstMyItems.PhotoId = item.DG_Photos_pkey;
					lstMyItems.HotFolderPath = item.HotFolderPath;
					lstMyItems.MediaType = item.DG_MediaType;
					lstMyItems.VideoLength = item.DG_VideoLength;
					lstMyItems.CreatedOn = item.DG_Photos_CreatedOn;
					lstMyItems.OnlineQRCode = item.OnlineQRCode;
					System.Collections.Generic.IEnumerable<ModratePhotoInfo> enumerable = from x in moderatePhotosList.AsEnumerable<ModratePhotoInfo>()
					where x.DG_Mod_Photo_ID == item.DG_Photos_pkey
					select x;
					if (enumerable != null && enumerable.Count<ModratePhotoInfo>() > 0)
					{
						lstMyItems.FilePath = LoginUser.DigiFolderPath + "/Locked.png";
						lstMyItems.IsLocked = Visibility.Collapsed;
						lstMyItems.IsPassKeyVisible = Visibility.Visible;
					}
					else
					{
						string path = item.DG_Photos_FileName.Replace(videoProcessingClass.SupportedVideoFormats["avi"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mp4"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["wmv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mov"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["3gp"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["3g2"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["m2v"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["m4v"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["flv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mpeg"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mkv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mts"].ToString(), ".jpg");
						lstMyItems.BigThumbnailPath = System.IO.Path.Combine(lstMyItems.BigDBThumnailPath, item.DG_Photos_CreatedOn.ToString("yyyyMMdd"), path);
						lstMyItems.FilePath = System.IO.Path.Combine(lstMyItems.ThumnailPath, item.DG_Photos_CreatedOn.ToString("yyyyMMdd"), path);
						if (string.IsNullOrEmpty(item.DG_Photos_Layering))
						{
							if (!string.IsNullOrEmpty(LoginUser.DefaultBorderPath))
							{
								lstMyItems.FrameBrdr = LoginUser.DefaultBorderPath;
							}
						}
						lstMyItems.IsLocked = Visibility.Visible;
						lstMyItems.IsPassKeyVisible = Visibility.Collapsed;
					}
					LstMyItems lstMyItems2 = (from t in RobotImageLoader.GroupImages
					where t.PhotoId == item.DG_Photos_pkey
					select t).FirstOrDefault<LstMyItems>();
					if (lstMyItems2 == null)
					{
						lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
						RobotImageLoader.GroupImages.Add(lstMyItems);
					}
					lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
					if (RobotImageLoader.PrintImages != null)
					{
						LstMyItems lstMyItems3 = (from t in RobotImageLoader.PrintImages
						where t.PhotoId == item.DG_Photos_pkey
						select t).FirstOrDefault<LstMyItems>();
						if (lstMyItems3 != null)
						{
							lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
						}
						else
						{
							lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
						}
					}
					else
					{
						lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
					}
					if (RobotImageLoader.Is9ImgViewActive)
					{
						lstMyItems.GridMainHeight = 190;
						lstMyItems.GridMainWidth = 226;
						lstMyItems.GridMainRowHeight1 = 140;
						lstMyItems.GridMainRowHeight2 = 50;
					}
					else
					{
						lstMyItems.GridMainHeight = 140;
						lstMyItems.GridMainWidth = 170;
						lstMyItems.GridMainRowHeight1 = 90;
						lstMyItems.GridMainRowHeight2 = 60;
					}
					temprobotImages.Add(lstMyItems);
				}
			}
		}

		private static void SelectPhotoByZeroSearch(System.Collections.Generic.List<LstMyItems> temprobotImages, string ssInfo, System.Collections.Generic.List<ModratePhotoInfo> moderatePhotosList, PhotoBusiness phBiz, int mediaType)
		{
			RobotImageLoader.GroupId = "";
			int num;
			if (RobotImageLoader.currentCount == 0 && RobotImageLoader.IsZeroSearchNeeded)
			{
				num = -1;
			}
			else
			{
				if (RobotImageLoader._objnewincrement != null && RobotImageLoader._objnewincrement.Count > 0 && !RobotImageLoader.IsNextPage)
				{
					num = RobotImageLoader._objnewincrement[RobotImageLoader._objnewincrement.Count - 1].PhotoId;
				}
				else if (RobotImageLoader._objnewincrement != null && RobotImageLoader._objnewincrement.Count > 0 && RobotImageLoader.IsNextPage)
				{
					num = RobotImageLoader._objnewincrement[0].PhotoId;
				}
				else
				{
					num = -1;
				}
				if (!RobotImageLoader.IsZeroSearchNeeded && RobotImageLoader.currentCount == 0 && RobotImageLoader.StartIndex != 0)
				{
					if (!RobotImageLoader.IsNextPage)
					{
						num = RobotImageLoader.StartIndex;
					}
					else
					{
						num = RobotImageLoader.StopIndex;
					}
				}
				if (RobotImageLoader.IsPreview9or16active)
				{
					num = RobotImageLoader.StartIndex + 1;
					RobotImageLoader.IsPreview9or16active = false;
				}
			}
			RobotImageLoader.IsZeroSearchNeeded = false;
			RobotImageLoader.StartIndex = 0;
			RobotImageLoader.StopIndex = 0;
			System.Collections.Generic.List<PhotoInfo> list = new System.Collections.Generic.List<PhotoInfo>();
			if (RobotImageLoader._objnewincrement == null)
			{
				RobotImageLoader._objnewincrement = new System.Collections.Generic.List<LstMyItems>();
			}
			RobotImageLoader._objnewincrement.Clear();
			if (RobotImageLoader.IsNextPage)
			{
				list = (from x in phBiz.GetAllPhotosByPage(ssInfo, num, RobotImageLoader.thumbSet, RobotImageLoader.IsNextPage, out RobotImageLoader.MaxPhotoId, out RobotImageLoader.IsMoreNextImages, out RobotImageLoader.MinPhotoId, mediaType)
				orderby x.DG_Photos_pkey descending
				select x).ToList<PhotoInfo>();
				RobotImageLoader.IsMorePrevImages = true;
			}
			else
			{
				list = phBiz.GetAllPhotosByPage(ssInfo, num, RobotImageLoader.thumbSet, RobotImageLoader.IsNextPage, out RobotImageLoader.MaxPhotoId, out RobotImageLoader.IsMorePrevImages, out RobotImageLoader.MinPhotoId, mediaType).ToList<PhotoInfo>();				
                RobotImageLoader.IsMoreNextImages = (num != -1 && RobotImageLoader.MaxPhotoId + 1L != (long)num);
			}
			RobotImageLoader.IsNextPage = false;
			RobotImageLoader.totalCount = list.Count;
			RobotImageLoader.startLoad = 0;
			VideoProcessingClass videoProcessingClass = new VideoProcessingClass();
			for (int i = 0; i < RobotImageLoader.totalCount; i++)
			{
				PhotoInfo item = list[i];
				LstMyItems lstMyItems = new LstMyItems();
				System.Collections.Generic.IEnumerable<ModratePhotoInfo> enumerable = from x in moderatePhotosList.AsEnumerable<ModratePhotoInfo>()
				where x.DG_Mod_Photo_ID == item.DG_Photos_pkey
				select x;
				lstMyItems.Name = item.DG_Photos_RFID;
				lstMyItems.FileName = item.DG_Photos_FileName;
				lstMyItems.ListPosition = RobotImageLoader.currentCount;
				lstMyItems.PhotoId = item.DG_Photos_pkey;
				lstMyItems.HotFolderPath = item.HotFolderPath;
				lstMyItems.MediaType = item.DG_MediaType;
				lstMyItems.CreatedOn = item.DG_Photos_CreatedOn;
				lstMyItems.VideoLength = item.DG_VideoLength;
				lstMyItems.OnlineQRCode = item.OnlineQRCode;
				if (enumerable != null && enumerable.Count<ModratePhotoInfo>() > 0)
				{
					lstMyItems.FilePath = lstMyItems.HotFolderPath + "/Locked.png";
					lstMyItems.IsLocked = Visibility.Collapsed;
					lstMyItems.IsPassKeyVisible = Visibility.Visible;
				}
				else
				{
					string path = item.DG_Photos_FileName.Replace(videoProcessingClass.SupportedVideoFormats["avi"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mp4"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["wmv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mov"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["3gp"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["3g2"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["m2v"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["m4v"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["flv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mpeg"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mkv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mts"].ToString(), ".jpg");
					lstMyItems.BigThumbnailPath = System.IO.Path.Combine(lstMyItems.BigDBThumnailPath, item.DG_Photos_CreatedOn.ToString("yyyyMMdd"), path);
					lstMyItems.FilePath = System.IO.Path.Combine(lstMyItems.ThumnailPath, item.DG_Photos_CreatedOn.ToString("yyyyMMdd"), path);
					if (string.IsNullOrEmpty(item.DG_Photos_Layering))
					{
						if (!string.IsNullOrEmpty(LoginUser.DefaultBorderPath))
						{
							lstMyItems.FrameBrdr = LoginUser.DefaultBorderPath;
						}
					}
					lstMyItems.IsLocked = Visibility.Visible;
					lstMyItems.IsPassKeyVisible = Visibility.Collapsed;
				}
				if (RobotImageLoader.GroupImages != null)
				{
					LstMyItems lstMyItems2 = (from t in RobotImageLoader.GroupImages
					where t.PhotoId == item.DG_Photos_pkey
					select t).FirstOrDefault<LstMyItems>();
					if (lstMyItems2 != null)
					{
						lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
					}
					else
					{
						lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
					}
				}
				else
				{
					lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
				}
				if (RobotImageLoader.PrintImages != null)
				{
					LstMyItems lstMyItems3 = (from t in RobotImageLoader.PrintImages
					where t.PhotoId == item.DG_Photos_pkey
					select t).FirstOrDefault<LstMyItems>();
					if (lstMyItems3 != null)
					{
						lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
					}
					else
					{
						lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
					}
				}
				else
				{
					lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
				}
				if (!RobotImageLoader.IsPreviewModeActive && RobotImageLoader.Is9ImgViewActive)
				{
					lstMyItems.GridMainHeight = 190;
					lstMyItems.GridMainWidth = 226;
					lstMyItems.GridMainRowHeight1 = 140;
					lstMyItems.GridMainRowHeight2 = 50;
				}
				else if (!RobotImageLoader.IsPreviewModeActive && RobotImageLoader.Is16ImgViewActive)
				{
					lstMyItems.GridMainHeight = 140;
					lstMyItems.GridMainWidth = 170;
					lstMyItems.GridMainRowHeight1 = 90;
					lstMyItems.GridMainRowHeight2 = 60;
				}
				else
				{
					lstMyItems.GridMainHeight = 140;
					lstMyItems.GridMainWidth = 170;
					lstMyItems.GridMainRowHeight1 = 90;
					lstMyItems.GridMainRowHeight2 = 60;
				}
				temprobotImages.Add(lstMyItems);
				if (RobotImageLoader._objnewincrement == null)
				{
					RobotImageLoader._objnewincrement = new System.Collections.Generic.List<LstMyItems>();
				}
				RobotImageLoader._objnewincrement.Add(lstMyItems);
				RobotImageLoader.startLoad++;
				RobotImageLoader.currentCount++;
			}
		}

		private static void SelectPhotoByRFID(System.Collections.Generic.List<LstMyItems> temprobotImages, System.Collections.Generic.List<ModratePhotoInfo> moderatePhotosList, PhotoBusiness phBiz)
		{
			RobotImageLoader.GroupId = "";
			RobotImageLoader.IsZeroSearchNeeded = false;
			RobotImageLoader.StartIndex = 0;
			RobotImageLoader.StopIndex = 0;
			int num = RobotImageLoader.thumbSet;
			VideoProcessingClass videoProcessingClass = new VideoProcessingClass();
			System.Collections.Generic.List<PhotoInfo> source = new System.Collections.Generic.List<PhotoInfo>();
            string subStoreId = "0";
            if (LoginUser.DefaultSubstores.Contains(","))
                subStoreId = LoginUser.DefaultSubstores.Split(',')[0];
            source = (from t in phBiz.GetAllPhotosforSearch(subStoreId, System.Convert.ToInt64(RobotImageLoader.RFID), num, LoginUser.IsPhotographerSerailSearchActive, RobotImageLoader.StartIndexRFID, RobotImageLoader._rfidSearch, RobotImageLoader.NewRecord, out RobotImageLoader.MaxPhotoIdCriteria, out RobotImageLoader.MinPhotoIdCriteria,RobotImageLoader.MediaTypes)
			orderby t.DG_Photos_pkey descending
			select t).ToList<PhotoInfo>();
			System.Collections.Generic.List<PhotoInfo> list = new System.Collections.Generic.List<PhotoInfo>();
			if (!LoginUser.IsPhotographerSerailSearchActive)
			{
				if (RobotImageLoader._rfidSearch == 0)
				{
					list = (from T in source
					where T.DG_Photos_RFID == RobotImageLoader.RFID
					select T).ToList<PhotoInfo>();
				}
				else
				{
					list = source.ToList<PhotoInfo>();
				}
			}
			else
			{
				list = source.ToList<PhotoInfo>();
			}
			if (list.Count != 0)
			{
				int imageid = list.First<PhotoInfo>().DG_Photos_pkey;
                System.Collections.Generic.List<PhotoInfo> list2 = (from t in source
                                                                    where t.DG_Photos_pkey < imageid
                                                                    orderby t.DG_Photos_pkey descending
                                                                    select t).ToList<PhotoInfo>();

                if (list2.Count > num)
				{
                   // list2 = list2.Take(num).ToList<PhotoInfo>();
                    list2 = list2.Take(500).ToList<PhotoInfo>();
				}
				list2 = (from t in list2
				orderby t.DG_Photos_pkey
				select t).ToList<PhotoInfo>();
				list2 = list2.Union(list).ToList<PhotoInfo>();
				System.Collections.Generic.List<PhotoInfo> list3 = (from t in source
				where t.DG_Photos_pkey > imageid
				orderby t.DG_Photos_pkey
				select t).ToList<PhotoInfo>();
				if (list3.Count > num)
				{
					list3 = list3.Take(num).ToList<PhotoInfo>();
				}
				list2 = list2.Union(list3).ToList<PhotoInfo>();
				using (System.Collections.Generic.List<PhotoInfo>.Enumerator enumerator = list2.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						PhotoInfo item = enumerator.Current;
						LstMyItems lstMyItems = new LstMyItems();
                        lstMyItems.Name =Convert.ToString( item.DG_Photo_ID); //item.DG_Photos_RFID;
						lstMyItems.FileName = item.DG_Photos_FileName;
						lstMyItems.PhotoId = item.DG_Photos_pkey;
						lstMyItems.HotFolderPath = item.HotFolderPath;
						lstMyItems.MediaType = item.DG_MediaType;
						lstMyItems.CreatedOn = item.DG_Photos_CreatedOn;
						lstMyItems.VideoLength = item.DG_VideoLength;
						lstMyItems.OnlineQRCode = item.OnlineQRCode;
						System.Collections.Generic.IEnumerable<ModratePhotoInfo> enumerable = from x in moderatePhotosList.AsEnumerable<ModratePhotoInfo>()
						where x.DG_Mod_Photo_ID == item.DG_Photos_pkey
						select x;
						//if (enumerable != null && enumerable.Count<ModratePhotoInfo>() > 0)
						//{
						//	lstMyItems.FilePath = lstMyItems.HotFolderPath + "/Locked.png";
						//	lstMyItems.IsLocked = Visibility.Collapsed;
						//	lstMyItems.IsPassKeyVisible = Visibility.Visible;
						//}
						//else
						//{
							string path = item.DG_Photos_FileName.Replace(videoProcessingClass.SupportedVideoFormats["avi"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mp4"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["wmv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mov"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["3gp"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["3g2"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["m2v"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["m4v"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["flv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mpeg"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mkv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mts"].ToString(), ".jpg");
							lstMyItems.BigThumbnailPath = System.IO.Path.Combine(lstMyItems.BigDBThumnailPath, item.DG_Photos_CreatedOn.ToString("yyyyMMdd"), path);
							lstMyItems.FilePath = System.IO.Path.Combine(lstMyItems.ThumnailPath, item.DG_Photos_CreatedOn.ToString("yyyyMMdd"), path);
							lstMyItems.IsLocked = Visibility.Visible;
							if (string.IsNullOrEmpty(item.DG_Photos_Layering))
							{
								if (!string.IsNullOrEmpty(LoginUser.DefaultBorderPath))
								{
									lstMyItems.FrameBrdr = LoginUser.DefaultBorderPath;
								}
							}
							lstMyItems.IsPassKeyVisible = Visibility.Collapsed;
							lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
						//}
						if (RobotImageLoader.GroupImages != null)
						{
							LstMyItems lstMyItems2 = (from t in RobotImageLoader.GroupImages
							where t.PhotoId == item.DG_Photos_pkey
							select t).FirstOrDefault<LstMyItems>();
							if (lstMyItems2 != null)
							{
								lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
							}
							else
							{
								lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
							}
						}
						else
						{
							lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
						}
						if (RobotImageLoader.PrintImages != null)
						{
							LstMyItems lstMyItems3 = (from t in RobotImageLoader.PrintImages
							where t.PhotoId == item.DG_Photos_pkey
							select t).FirstOrDefault<LstMyItems>();
							if (lstMyItems3 != null)
							{
								lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
							}
							else
							{
								lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
							}
						}
						else
						{
							lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
						}
						if (RobotImageLoader.Is9ImgViewActive)
						{
							lstMyItems.GridMainHeight = 190;
							lstMyItems.GridMainWidth = 226;
							lstMyItems.GridMainRowHeight1 = 140;
							lstMyItems.GridMainRowHeight2 = 50;
						}
						else
						{
							lstMyItems.GridMainHeight = 140;
							lstMyItems.GridMainWidth = 170;
							lstMyItems.GridMainRowHeight1 = 90;
							lstMyItems.GridMainRowHeight2 = 60;
						}
						temprobotImages.Add(lstMyItems);
					}
				}
			}
		}

		public static void GetConfigData()
		{
			string text = "";
			string text2 = "";
			try
			{
				try
				{
					string baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
					if (System.IO.File.Exists(baseDirectory + "\\ss.dat"))
					{
						using (System.IO.StreamReader streamReader = new System.IO.StreamReader(baseDirectory + "\\ss.dat"))
						{
							string cipherString = streamReader.ReadLine();
							string text3 = CryptorEngine.Decrypt(cipherString, true);
							LoginUser.DefaultSubstores = text3;
					     	StoreSubStoreDataBusniess storeSubStoreDataBusniess = new StoreSubStoreDataBusniess();
							LoginUser.SubstoreName = storeSubStoreDataBusniess.GetSubstoreNameById(System.Convert.ToInt32(text3.Split(new char[]
							{
								','
							})[0]));
							LoginUser.SubStoreId = System.Convert.ToInt32(text3.Split(new char[]
							{
								','
							})[0]);
						}
					}
					if (System.IO.File.Exists(baseDirectory + "\\slipPrinter.dat"))
					{
						using (System.IO.StreamReader streamReader = new System.IO.StreamReader(baseDirectory + "\\slipPrinter.dat"))
						{
							string text4 = streamReader.ReadLine();
							text = text4.Split(new char[]
							{
								','
							}).ToArray<string>().First<string>().ToString();
							text2 = text4.Split(new char[]
							{
								','
							}).ToArray<string>().Last<string>().ToString();
						}
					}
				}
				catch (System.Exception serviceException)
				{
					string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
					ErrorHandler.ErrorHandler.LogFileWrite(message);
				}
                PhotoSW.IMIX.Business.ConfigBusiness configBusiness = new PhotoSW.IMIX.Business.ConfigBusiness();
			    PhotoSW.IMIX.Model.ConfigurationInfo configurationData = configBusiness.GetConfigurationData(LoginUser.SubStoreId);
				if (configurationData != null)
				{
					LoginUser.DigiFolderBackGroundPath = configurationData.DG_BG_Path;
					LoginUser.DigiFolderFramePath = configurationData.DG_Frame_Path;
					LoginUser.DigiFolderPath = configurationData.DG_Hot_Folder_Path;
					LoginUser.ModPassword = configurationData.DG_Mod_Password;
					LoginUser.DigiFolderGraphicsPath = configurationData.DG_Graphics_Path;
					LoginUser.DigiImagesCount = System.Convert.ToInt32(configurationData.DG_NoOfPhotos);
					LoginUser.IsWatermark = configurationData.DG_Watermark;
					LoginUser.IsHighResolution = configurationData.DG_HighResolution;
					LoginUser.IsSemiOrder = configurationData.DG_SemiOrderMain;
					LoginUser.DigiFolderBigThumbnailPath = configurationData.DG_Hot_Folder_Path + "Thumbnails_Big\\";
					LoginUser.DigiFolderCropedPath = configurationData.DG_Hot_Folder_Path + "Croped\\";
					LoginUser.DigiFolderThumbnailPath = configurationData.DG_Hot_Folder_Path + "Thumbnails\\";
					LoginUser.DigiFolderAudioPath = configurationData.DG_Hot_Folder_Path + "Audio\\";
					LoginUser.DigiFolderVideoTemplatePath = configurationData.DG_Hot_Folder_Path + "VideoTemplate\\";
					LoginUser.DigiFolderVideoBackGroundPath = configurationData.DG_Hot_Folder_Path + "VideoBackGround\\";
					LoginUser.DigiFolderProcessedVideosPath = configurationData.DG_Hot_Folder_Path + "ProcessedVideos\\";
					LoginUser.DigiFolderVideoOverlayPath = configurationData.DG_Hot_Folder_Path + "VideoOverlay\\";
					LoginUser.IsDiscountAllowed = configurationData.DG_AllowDiscount;
					LoginUser.IsDiscountAllowedonTotal = configurationData.DG_EnableDiscountOnTotal;
					LoginUser.DGNoOfPhotoIdSearch = configurationData.DG_NoOfPhotoIdSearch.Value;
					LoginUser.PageCountGrid = configurationData.DG_PageCountGrid.Value;
					LoginUser.DigiReportPath = configurationData.DG_Hot_Folder_Path + "Reports\\";
					LoginUser.ItemTemplatePath = configurationData.DG_Hot_Folder_Path + "ItemTemplate\\";
					LoginUser.ItemCalenderPath = configurationData.DG_Hot_Folder_Path + "ItemTemplate\\Calendar\\";
                    LoginUser.PhotoSWGeneralBackGroundPath = configurationData.DG_Hot_Folder_Path + "GeneralBG\\";
					if (!string.IsNullOrEmpty(text))
					{
						LoginUser.ReceiptPrinterPath = text;
					}
					else
					{
						LoginUser.ReceiptPrinterPath = "";
					}
					if (!string.IsNullOrEmpty(text2))
					{
						LoginUser.GroupValue = text2;
					}
					else
					{
						LoginUser.GroupValue = "";
					}
                    PhotoSW.IMIX.Business.SemiOrderBusiness semiOrderBusiness = new PhotoSW.IMIX.Business.SemiOrderBusiness();
					System.Collections.Generic.List<PhotoSW.IMIX.Model.SemiOrderSettings> lstSemiOrderSettings = semiOrderBusiness.GetLstSemiOrderSettings(null);
					if (lstSemiOrderSettings != null)
					{
						LoginUser.ListSemiOrderSettingsSubStoreWise = lstSemiOrderSettings;
					}
				}
			}
			catch (System.Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
		}

		public static System.Collections.Generic.Dictionary<string, string> GetReports()
		{
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			return new System.Collections.Generic.Dictionary<string, string>
			{
				{
					"Activity Reports",
					"0"
				},
				{
					"Production Summary Report",
					"1"
				},
				{
					"Operators Performance Report",
					"2"
				},
				{
					"Taking Reports",
					"3"
				},
				{
					"Operation Audit Trail",
					"4"
				},
				{
					"Photographer Performance",
					"5"
				},
				{
					"Site Performance Report",
					"6"
				},
				{
					"Financial Audit Report",
					"7"
				},
				{
					"Printing Report",
					"9"
				},
				{
					"Payment Summary Report",
					"10"
				},
				{
					"IP Print Tracking Report",
					"11"
				},
				{
					"IP Content Tracking Report",
					"12"
				}
			};
		}

		public static System.Collections.Generic.Dictionary<string, string> GetEmailType()
		{
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			return new System.Collections.Generic.Dictionary<string, string>
			{
				{
					"Select",
					"10"
				},
				{
					"Not Sent",
					"0"
				},
				{
					"Sent successfully",
					"1"
				},
				{
					"Error",
					"2"
				}
			};
		}

		public static bool GetShowAllSubstorePhotos()
		{
			bool flag = false;
			bool result;
			try
			{
				ConfigBusiness configBusiness = new ConfigBusiness();
				System.Collections.Generic.List<long> objList = new System.Collections.Generic.List<long>();
				objList.Add(74L);
				System.Collections.Generic.List<iMIXConfigurationInfo> list = (from o in configBusiness.GetNewConfigValues(LoginUser.SubStoreId)
				where objList.Contains(o.IMIXConfigurationMasterId)
				select o).ToList<iMIXConfigurationInfo>();
				if (list != null || list.Count > 0)
				{
					for (int i = 0; i < list.Count; i++)
					{
						long iMIXConfigurationMasterId = list[i].IMIXConfigurationMasterId;
						if (iMIXConfigurationMasterId == 74L)
						{
							flag = (list[i].ConfigurationValue != null && System.Convert.ToBoolean(list[i].ConfigurationValue));
						}
					}
				}
				result = flag;
			}
			catch (System.Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
				result = false;
			}
			return result;
		}
	}
}
