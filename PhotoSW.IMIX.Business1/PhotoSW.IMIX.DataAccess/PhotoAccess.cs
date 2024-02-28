//using #2j;
//using DigiPhoto.IMIX.Model;
//using DigiPhoto.Utility.Repository.ValueType;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class PhotoAccess : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getPhotoAccess;
        public PhotoAccess(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public PhotoAccess()
		{
		}

		public List<PhotoDetail> GetPhotoDetailsByPhotoIds(string PhotoIds)
		{
			base.DBParameters.Clear();
			base.AddParameter(PhotoAccess.getPhotoAccess(1477), PhotoIds);
			IDataReader dataReader;
			List<PhotoDetail> photoDetailsByPhotoIds;
			do
			{
				dataReader = base.ExecuteReader(PhotoAccess.getPhotoAccess(49351));
				photoDetailsByPhotoIds = this.GetPhotoDetailsByPhotoIds(dataReader);
			}
			while (5 == 0);
			dataReader.Close();
			return photoDetailsByPhotoIds;
		}

		public List<PhotoDetail> GetImagesInfoForEditing(int SubStoreId, string PosName)
		{
			base.DBParameters.Clear();
			IDataReader dataReader;
			List<PhotoDetail> result;
			do
			{
				base.AddParameter(PhotoAccess.getPhotoAccess(13307), SubStoreId);
				do
				{
					if (3 != 0)
					{
						base.AddParameter(PhotoAccess.getPhotoAccess(49384), PosName);
					}
					dataReader = base.ExecuteReader(PhotoAccess.getPhotoAccess(49397));
					if (6 == 0)
					{
						return result;
					}
				}
				while (4 == 0);
				result = this.photoDetail(dataReader);
			}
			while (false);
			dataReader.Close();
			return result;
		}

		public bool UpdateImageProcessedStatus(int PhotoId, bool ProcessedStatus)
		{
			base.DBParameters.Clear();
			base.AddParameter(PhotoAccess.getPhotoAccess(1503), PhotoId);
			base.AddParameter(PhotoAccess.getPhotoAccess(19927), ProcessedStatus);
			int num = Convert.ToInt32(base.ExecuteNonQuery(PhotoAccess.getPhotoAccess(49430)));
			int arg_61_0;
			if (num > 0)
			{
				int expr_5C = arg_61_0 = 1;
				if (expr_5C != 0)
				{
					return expr_5C != 0;
				}
			}
			else
			{
				arg_61_0 = 0;
			}
			return arg_61_0 != 0;
		}

		public List<PhotoDetail> GetFilesForAutoVideoProcessing(int substoreID, string PosName)
		{
			base.DBParameters.Clear();
			IDataReader dataReader;
			List<PhotoDetail> result;
			do
			{
				base.AddParameter(PhotoAccess.getPhotoAccess(13307), substoreID);
				do
				{
					if (3 != 0)
					{
						base.AddParameter(PhotoAccess.getPhotoAccess(49384), PosName);
					}
					dataReader = base.ExecuteReader(PhotoAccess.getPhotoAccess(49467));
					if (6 == 0)
					{
						return result;
					}
				}
				while (4 == 0);
				result = this.photoDetail2(dataReader);
			}
			while (false);
			dataReader.Close();
			return result;
		}

		public bool UpdateVideoProcessedStatus(int PhotoId, bool ProcessedStatus)
		{
			base.DBParameters.Clear();
			base.AddParameter(PhotoAccess.getPhotoAccess(1503), PhotoId);
			base.AddParameter(PhotoAccess.getPhotoAccess(19927), ProcessedStatus);
			int num = Convert.ToInt32(base.ExecuteNonQuery(PhotoAccess.getPhotoAccess(49508)));
			int arg_61_0;
			if (num > 0)
			{
				int expr_5C = arg_61_0 = 1;
				if (expr_5C != 0)
				{
					return expr_5C != 0;
				}
			}
			else
			{
				arg_61_0 = 0;
			}
			return arg_61_0 != 0;
		}

		public bool UpdateImageProcessedStatus(int PhotoId, int ProcessedStatus)
		{
			base.DBParameters.Clear();
			base.AddParameter(PhotoAccess.getPhotoAccess(1503), PhotoId);
			base.AddParameter(PhotoAccess.getPhotoAccess(19927), ProcessedStatus);
			int num = (int)base.ExecuteNonQuery(PhotoAccess.getPhotoAccess(49430));
           // int num = base.ExecuteNonQuery(PhotoAccess.(49430)).ToInt32(false);
            return num > 0;
		}

		private List<PhotoDetail> GetPhotoDetailsByPhotoIds(IDataReader dataReader)
		{
			List<PhotoDetail> list = new List<PhotoDetail>();
			while (dataReader.Read())
			{
				list.Add(new PhotoDetail
				{
					PhotoId = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21118), 0),
					FileName = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21139), string.Empty),
					DG_Photos_CreatedOn = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21164), default(DateTime)),
					PhotoRFID = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21193), string.Empty),
					Layering = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21314), string.Empty),
					Effects = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21339), string.Empty),
					HotFolderPath = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21603), string.Empty),
					MediaType = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21624), 0)
				});
			}
			return list;
		}

		private List<PhotoDetail> photoDetail ( IDataReader dataReader)
		{
			List<PhotoDetail> list = new List<PhotoDetail>();
			while (dataReader.Read())
			{
				PhotoDetail photoDetail;
				if (4 != 0)
				{
					photoDetail = new PhotoDetail();
					photoDetail.PhotoId = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21118), 0);
				}
				photoDetail.FileName = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21139), string.Empty);
				photoDetail.DG_Photos_CreatedOn = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21164), default(DateTime));
				photoDetail.PhotoRFID = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21193), string.Empty);
				photoDetail.Layering = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21314), string.Empty);
				photoDetail.Effects = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21339), string.Empty);
				photoDetail.IsCropped = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21364), false);
				photoDetail.IsGreen = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21414), false);
				photoDetail.LocationId = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21510), 0);
				photoDetail.SubstoreId = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21531), 0);
				photoDetail.SemiOrderProfileId = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21662), 0);
				photoDetail.IsGumRideShow = new bool?(base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21687), false));
				list.Add(photoDetail);
			}
			return list;
		}

		private List<PhotoDetail> photoDetail2 ( IDataReader dataReader)
		{
			List<PhotoDetail> expr_151 = new List<PhotoDetail>();
			List<PhotoDetail> list;
			if (3 != 0)
			{
				list = expr_151;
			}
			while (dataReader.Read())
			{
				list.Add(new PhotoDetail
				{
					PhotoId = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21118), 0),
					FileName = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21139), string.Empty),
					DG_Photos_CreatedOn = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21164), default(DateTime)),
					PhotoRFID = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21193), string.Empty),
					LocationId = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21510), 0),
					SubstoreId = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21531), 0),
					PhotoGrapherId = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21214), 0),
					MediaType = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21624), 0),
					VideoLength = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21641), 0L)
				});
			}
			return list;
		}

		public List<PhotoDetail> GetPhotoDetailsByPhotoIds(PhotoDetail photoDetailObj)
		{
			do
			{
				base.DBParameters.Clear();
				if (4 != 0)
				{
					base.AddParameter(PhotoAccess.getPhotoAccess(1477), photoDetailObj.PhotoRFID);
				}
			}
			while (-1 == 0);
			IDataReader dataReader = base.ExecuteReader(PhotoAccess.getPhotoAccess(49351));
			List<PhotoDetail> photoDetailsByPhotoIds = this.GetPhotoDetailsByPhotoIds(dataReader, photoDetailObj);
			dataReader.Close();
			return photoDetailsByPhotoIds;
		}

		private List<PhotoDetail> GetPhotoDetailsByPhotoIds(IDataReader dataReader, PhotoDetail photodetail )
		{
			List<PhotoDetail> list = new List<PhotoDetail>();
			while (true)
			{
				PhotoDetail photoDetail;
				if (!false)
				{
					if (!dataReader.Read())
					{
						break;
					}
					do
					{
						photoDetail = new PhotoDetail();
						photoDetail.PhotoId = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21118), 0);
						photoDetail.DG_Photos_CreatedOn = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21164), default(DateTime));
						photoDetail.FileName = Path.Combine(base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21603), string.Empty), photoDetail.DG_Photos_CreatedOn.ToString(PhotoAccess.getPhotoAccess(49545)), base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21139), string.Empty));
						if (5 != 0)
						{
							photoDetail.DG_Photos_CreatedOn = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21164), default(DateTime));
						}
					}
					while (false);
					photoDetail.PhotoRFID = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21193), string.Empty);
					photoDetail.Layering = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21314), string.Empty);
					photoDetail.Effects = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21339), string.Empty);
					photoDetail.HotFolderPath = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(21603), string.Empty);
				}
				photoDetail.IsEnabled = photodetail.IsEnabled;
				list.Add(photoDetail);
			}
			return list;
		}

		public List<PhotoCaptureInfo> GetPhotoCapturedetails(int PhotoId)
		{
			if (false)
			{
				goto IL_40;
			}
			List<SqlParameter> expr_51 = base.DBParameters;
			if (!false)
			{
				expr_51.Clear();
			}
			if (-1 == 0)
			{
				goto IL_49;
			}
			base.AddParameter(PhotoAccess.getPhotoAccess(1503), base.SetNullIntegerValue(new int?(PhotoId)));
			IL_29:
			IDataReader dataReader;
			List<PhotoCaptureInfo> result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				result = this.photoCaptureInfo(dataReader);
			}
			IL_40:
			if (-1 == 0)
			{
				goto IL_29;
			}
			dataReader.Close();
			IL_49:
			if (!false)
			{
				return result;
			}
			goto IL_40;
		}

		private List<PhotoCaptureInfo> photoCaptureInfo(IDataReader dataReader)
		{
			List<PhotoCaptureInfo> list = new List<PhotoCaptureInfo>();
			while (dataReader.Read())
			{
				PhotoCaptureInfo item = new PhotoCaptureInfo
				{
					CaptureDate = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(49558), DateTime.Now),
					GroupName = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(49575), string.Empty),
					LocationName = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(29676), string.Empty),
					PhotoGrapherName = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(49588), string.Empty),
					PhotoName = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(49613), string.Empty),
					pkey = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(49626), 0),
					LocationId = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(12822), 0),
					PhotoGrapherId = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(49635), 0),
					RFIDNo = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(49656), string.Empty),
					SubstoreName = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(26984), string.Empty),
					SysDate = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(49665), DateTime.Now),
					CharacterId = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(3993), string.Empty),
					MetaData = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(49678), string.Empty),
					UniqueIdentifier = base.GetFieldValue(dataReader, PhotoAccess.getPhotoAccess(1344), string.Empty)
				};
				list.Add(item);
			}
			return list;
		}

		static PhotoAccess()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(PhotoAccess));
		}
	}
}
