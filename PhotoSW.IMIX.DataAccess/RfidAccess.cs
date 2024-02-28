//using DigiPhoto.IMIX.Model;
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
	public class RfidAccess : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getReportAccess;
        public RfidAccess(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public RfidAccess()
		{
		}

		public bool SaveRfidTag(RFIDTagInfo rfidTag)
		{
			do
			{
				if (true && 6 != 0)
				{
					if (!false)
					{
						base.DBParameters.Clear();
						if (7 != 0)
						{
							base.AddParameter(RfidAccess.getReportAccess(52835), rfidTag.SerialNo);
						}
						base.AddParameter(RfidAccess.getReportAccess(52848), rfidTag.TagId);
						base.AddParameter(RfidAccess.getReportAccess(52857), rfidTag.ScanningTime);
					}
					base.AddParameter(RfidAccess.getReportAccess(52878), rfidTag.RawData);
				}
			}
			while (6 == 0);
			base.ExecuteNonQuery(RfidAccess.getReportAccess(52891));
			return true;
		}

		public bool AssociateRFIDtoPhotosAdvance(DataTable dt_Rfid, string SerailNo)
		{
			base.DBParameters.Clear();
			base.AddParameter(RfidAccess.getReportAccess(52908), dt_Rfid);
			base.AddParameter(RfidAccess.getReportAccess(52917), SerailNo);
			base.ExecuteNonQuery(RfidAccess.getReportAccess(52930));
			return true;
		}

		public List<RFIDField> GetSubStoreList()
		{
			base.DBParameters.Clear();
			IDataReader dataReader = base.ExecuteReader(RfidAccess.getReportAccess(52955));
			List<RFIDField> result;
			do
			{
				result = this.RFIDFieldqk(dataReader);
			}
			while (false);
			dataReader.Close();
			return result;
		}

		private List<RFIDField> RFIDFieldqk ( IDataReader IDataReader )
		{
			List<RFIDField> list;
			if (!false)
			{
				list = new List<RFIDField>();
			}
			while (IDataReader.Read())
			{
				list.Add(new RFIDField
				{
					DeviceID = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(48727), 0),
					SerialNo = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(3917), string.Empty),
					SubStoreID = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(30567), 0),
					HotFolderpath = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(8889), string.Empty)
				});
			}
			return list;
		}

		public bool AssociateRFIDtoPhotos()
		{
			do
			{
				if (true && !false)
				{
					base.DBParameters.Clear();
				}
				do
				{
					base.ExecuteNonQuery(RfidAccess.getReportAccess(52976));
				}
				while (false);
			}
			while (8 == 0);
			return true;
		}

		public bool ArchiveRFIDTags(int subStoreId)
		{
			base.DBParameters.Clear();
			base.AddParameter(RfidAccess.getReportAccess(34106), subStoreId);
			base.ExecuteNonQuery(RfidAccess.getReportAccess(53013));
			return true;
		}

		public List<RFIDImageAssociationInfo> GetRFIDAssociationSearch(int photoGrapherId, int deviceId, DateTime dtFrom, DateTime dtTo)
		{
			while (true)
			{
				base.DBParameters.Clear();
				if (7 != 0)
				{
					base.AddParameter(RfidAccess.getReportAccess(48825), photoGrapherId);
					if (!false)
					{
						break;
					}
				}
			}
			base.AddParameter(RfidAccess.getReportAccess(48701), deviceId);
			base.AddParameter(RfidAccess.getReportAccess(53046), dtFrom);
			base.AddParameter(RfidAccess.getReportAccess(53059), dtTo);
			IDataReader dataReader = base.ExecuteReader(RfidAccess.getReportAccess(53068));
			List<RFIDImageAssociationInfo> result = this.RFIDImageAssociationInfouk(dataReader);
			dataReader.Close();
			return result;
		}

		public List<PhotoDetail> GetRFIDNotAssociatedPhotos(int photoGrapherId, DateTime dtFrom, DateTime dtTo)
		{
			base.DBParameters.Clear();
			base.AddParameter(RfidAccess.getReportAccess(48825), photoGrapherId);
			List<PhotoDetail> result;
			do
			{
				base.AddParameter(RfidAccess.getReportAccess(53046), dtFrom);
				base.AddParameter(RfidAccess.getReportAccess(53059), dtTo);
				IDataReader dataReader = base.ExecuteReader(RfidAccess.getReportAccess(53105));
				result = this.PhotoDetailsk(dataReader);
				dataReader.Close();
			}
			while (3 == 0);
			return result;
		}

		public List<PhotoDetail> GetRFIDNotAssociatedPhotos(RFIDPhotoDetails RFIDPhotoObj)
		{
			base.DBParameters.Clear();
			base.AddParameter(RfidAccess.getReportAccess(48825), RFIDPhotoObj.PhotoGrapherId);
			base.AddParameter(RfidAccess.getReportAccess(53046), RFIDPhotoObj.StartDate);
			base.AddParameter(RfidAccess.getReportAccess(53059), RFIDPhotoObj.EndDate);
			IDataReader dataReader = base.ExecuteReader(RfidAccess.getReportAccess(53105));
			List<PhotoDetail> result = this.PhotoDetailvk(dataReader, RFIDPhotoObj.FileName);
			dataReader.Close();
			return result;
		}

		private List<PhotoDetail> PhotoDetailsk ( IDataReader IDataReader )
		{
			List<PhotoDetail> list = new List<PhotoDetail>();
			while (IDataReader.Read())
			{
				list.Add(new PhotoDetail
				{
					PhotoId = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(1335), 0),
					FileName = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(31368), string.Empty),
					DG_Photos_CreatedOn = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(3328), default(DateTime)),
					PhotoRFID = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(53142), string.Empty)
				});
			}
			return list;
		}

		public bool SaveDummyRFIDTagsInfo(RFIDTagInfo rfidTag)
		{
			base.DBParameters.Clear();
			base.AddParameter(RfidAccess.getReportAccess(53155), rfidTag.DummyRFIDTagID);
			do
			{
				base.AddParameter(RfidAccess.getReportAccess(53176), rfidTag.TagId);
				base.AddParameter(RfidAccess.getReportAccess(27902), rfidTag.IsActive);
			}
			while (5 == 0);
			base.ExecuteNonQuery(RfidAccess.getReportAccess(53185));
			return true;
		}

		public List<RFIDTagInfo> GetDummyRFIDTagsInfo(int dummyRFIDTagID)
		{
			List<RFIDTagInfo> result;
			while (true)
			{
				if (false)
				{
					goto IL_41;
				}
				List<SqlParameter> expr_55 = base.DBParameters;
				if (!false)
				{
					expr_55.Clear();
				}
				if (-1 != 0)
				{
					base.AddParameter(RfidAccess.getReportAccess(53155), dummyRFIDTagID);
					goto IL_25;
				}
				IL_4A:
				if (!true)
				{
					continue;
				}
				if (!false)
				{
					break;
				}
				IL_41:
				IDataReader dataReader;
				if (-1 != 0)
				{
					dataReader.Close();
					goto IL_4A;
				}
				IL_25:
				dataReader = base.ExecuteReader(RfidAccess.getReportAccess(53218));
				result = this.RFIDTagInfoxk(dataReader);
				// IL_41;
			}
			return result;
		}

		public bool DeleteDummyRFIDTagsInfo(int dummyRFIDTagID)
		{
			base.DBParameters.Clear();
			base.AddParameter(RfidAccess.getReportAccess(53155), dummyRFIDTagID);
			base.ExecuteNonQuery(RfidAccess.getReportAccess(53247));
			return true;
		}

		public bool MapNonAssociatedImages(string cardUniqueIdentifier, string photoIDS)
		{
			base.DBParameters.Clear();
			base.AddParameter(RfidAccess.getReportAccess(53280), cardUniqueIdentifier);
			base.AddParameter(RfidAccess.getReportAccess(53309), photoIDS);
			base.ExecuteNonQuery(RfidAccess.getReportAccess(53322));
			return true;
		}

		public int? GetPhotographerRFIDEnabledLocation(int photographerID)
		{
			int? result;
			do
			{
				result = null;
				if (false)
				{
					return result;
				}
				if (false)
				{
					goto IL_5C;
				}
				base.DBParameters.Clear();
				base.AddParameter(RfidAccess.getReportAccess(53359), photographerID);
				if (2 == 0)
				{
					goto IL_54;
				}
			}
			while (false);
			IDataReader dataReader = base.ExecuteReader(RfidAccess.getReportAccess(53380));
			IL_54:
			if (!dataReader.Read())
			{
				return result;
			}
			IL_5C:
			result = new int?(base.GetFieldValue(dataReader, RfidAccess.getReportAccess(53433), 0));
			return result;
		}

		public List<RfidFlushHistotyInfo> GetFlushHistoryData(int SubStoreId, DateTime fromDate, DateTime toDate)
		{
			base.DBParameters.Clear();
			base.AddParameter(RfidAccess.getReportAccess(34106), SubStoreId);
			List<RfidFlushHistotyInfo> result;
			do
			{
				base.AddParameter(RfidAccess.getReportAccess(53462), fromDate);
				base.AddParameter(RfidAccess.getReportAccess(53475), toDate);
				IDataReader dataReader = base.ExecuteReader(RfidAccess.getReportAccess(53488));
				result = this.RfidFlushHistotyInfoyk(dataReader);
				dataReader.Close();
			}
			while (3 == 0);
			return result;
		}

		public List<LocationInfo> GetAllLocations()
		{
			base.DBParameters.Clear();
			IDataReader dataReader = base.ExecuteReader(RfidAccess.getReportAccess(53517));
			List<LocationInfo> result;
			do
			{
				result = this.PopulateLocationList(dataReader);
			}
			while (false);
			dataReader.Close();
			return result;
		}

		public List<LocationInfo> PopulateLocationList(IDataReader sqlReader)
		{
			List<LocationInfo> expr_73 = new List<LocationInfo>();
			List<LocationInfo> list;
			if (5 != 0)
			{
				list = expr_73;
			}
			LocationInfo locationInfo = null;
			while (true)
			{
				if (!sqlReader.Read())
				{
					if (5 != 0)
					{
						break;
					}
				}
				else
				{
					locationInfo = new LocationInfo();
				}
				locationInfo.DG_Location_ID = base.GetFieldValue(sqlReader, RfidAccess.getReportAccess(53546), 0);
				locationInfo.DG_Location_Name = base.GetFieldValue(sqlReader, RfidAccess.getReportAccess(29680), string.Empty);
				list.Add(locationInfo);
			}
			return list;
		}

		public bool SaveSeperatorRFIDTagsInfo(SeperatorTagInfo seperatorTagInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(RfidAccess.getReportAccess(53563), seperatorTagInfo.SeparatorRFIDTagID);
			base.AddParameter(RfidAccess.getReportAccess(53176), seperatorTagInfo.TagID);
			base.AddParameter(RfidAccess.getReportAccess(12809), seperatorTagInfo.LocationId);
			base.AddParameter(RfidAccess.getReportAccess(27902), seperatorTagInfo.IsActive);
			base.ExecuteNonQuery(RfidAccess.getReportAccess(53592));
			return true;
		}

		public bool DeleteSeperatorRFIDTagsInfo(int seperatorRFIDTagID)
		{
			base.DBParameters.Clear();
			base.AddParameter(RfidAccess.getReportAccess(53621), seperatorRFIDTagID);
			base.ExecuteNonQuery(RfidAccess.getReportAccess(53650));
			return true;
		}

		public List<SeperatorTagInfo> GetSeperatorRFIDTagsInfo(int seperatorRFIDTagID)
		{
			List<SeperatorTagInfo> result;
			do
			{
				base.DBParameters.Clear();
				do
				{
					new List<SeperatorTagInfo>();
					base.AddParameter(RfidAccess.getReportAccess(53621), seperatorRFIDTagID);
				}
				while (4 == 0);
				IDataReader dataReader = base.ExecuteReader(RfidAccess.getReportAccess(53687));
				result = this.PopulateSeperatorTagsInfo(dataReader);
				dataReader.Close();
			}
			while (2 == 0);
			return result;
		}

		public List<SeperatorTagInfo> PopulateSeperatorTagsInfo(IDataReader sqlReader)
		{
			List<SeperatorTagInfo> list = new List<SeperatorTagInfo>();
			SeperatorTagInfo seperatorTagInfo = null;
			if (3 != 0)
			{
				goto IL_D2;
			}
			IL_4B:
			seperatorTagInfo.TagID = base.GetFieldValue(sqlReader, RfidAccess.getReportAccess(53745), string.Empty);
			seperatorTagInfo.CreatedOn = base.GetFieldValue(sqlReader, RfidAccess.getReportAccess(3576), DateTime.Now);
			seperatorTagInfo.LocationName = base.GetFieldValue(sqlReader, RfidAccess.getReportAccess(29680), string.Empty);
			seperatorTagInfo.IsActive = base.GetFieldValue(sqlReader, RfidAccess.getReportAccess(3533), false);
			list.Add(seperatorTagInfo);
			IL_D2:
			if (!sqlReader.Read())
			{
				return list;
			}
			seperatorTagInfo = new SeperatorTagInfo();
			seperatorTagInfo.SeparatorRFIDTagID = base.GetFieldValue(sqlReader, RfidAccess.getReportAccess(53720), 0);
			goto IL_4B;
		}

		public List<PhotographerRFIDAssociationInfo> GetPhotographerRFIDAssociation(int? photoGrapherId, DateTime dtFrom, DateTime dtTo)
		{
			base.DBParameters.Clear();
			base.AddParameter(RfidAccess.getReportAccess(48825), photoGrapherId);
			List<PhotographerRFIDAssociationInfo> result;
			do
			{
				base.AddParameter(RfidAccess.getReportAccess(53754), dtFrom);
				base.AddParameter(RfidAccess.getReportAccess(53771), dtTo);
				IDataReader dataReader = base.ExecuteReader(RfidAccess.getReportAccess(53784));
				result = this.PhotographerRFIDAssociationInfotk(dataReader);
				dataReader.Close();
			}
			while (3 == 0);
			return result;
		}

		private List<PhotographerRFIDAssociationInfo> PhotographerRFIDAssociationInfotk(IDataReader IDataReader)
		{
			List<PhotographerRFIDAssociationInfo> expr_14F = new List<PhotographerRFIDAssociationInfo>();
			List<PhotographerRFIDAssociationInfo> list;
			if (3 != 0)
			{
				list = expr_14F;
			}
			while (IDataReader.Read())
			{
				PhotographerRFIDAssociationInfo photographerRFIDAssociationInfo = new PhotographerRFIDAssociationInfo();
				photographerRFIDAssociationInfo.PhotographerID = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(53837), 0);
				photographerRFIDAssociationInfo.PhotographerName = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(3644), string.Empty);
				photographerRFIDAssociationInfo.Location = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(26953), string.Empty);
				photographerRFIDAssociationInfo.TotalCaptured = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(53858), 0);
				photographerRFIDAssociationInfo.TotalAssociated = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(53879), 0);
				photographerRFIDAssociationInfo.TotalNonAssociated = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(53900), 0);
				photographerRFIDAssociationInfo.LastAssociatedOn = new DateTime?(base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(53925), DateTime.MinValue));
				if (photographerRFIDAssociationInfo.LastAssociatedOn == DateTime.MinValue)
				{
					photographerRFIDAssociationInfo.LastAssociatedOn = null;
				}
				list.Add(photographerRFIDAssociationInfo);
			}
			return list;
		}

		private List<RFIDImageAssociationInfo> RFIDImageAssociationInfouk ( IDataReader IDataReader )
		{
			List<RFIDImageAssociationInfo> list = new List<RFIDImageAssociationInfo>();
			while (IDataReader.Read())
			{
				RFIDImageAssociationInfo rFIDImageAssociationInfo = new RFIDImageAssociationInfo();
				rFIDImageAssociationInfo.DeviceId = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(48727), 0);
				rFIDImageAssociationInfo.DeviceName = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(48883), string.Empty);
				rFIDImageAssociationInfo.RFID = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(53950), string.Empty);
				rFIDImageAssociationInfo.Count = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(15553), 0);
				rFIDImageAssociationInfo.PhotoIds = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(49342), string.Empty);
				rFIDImageAssociationInfo.IsShowDetailActive = (rFIDImageAssociationInfo.Count > 0);
				list.Add(rFIDImageAssociationInfo);
			}
			return list;
		}

		private List<PhotoDetail> PhotoDetailvk ( IDataReader IDataReader, string wk)
		{
			List<PhotoDetail> list = new List<PhotoDetail>();
			while (IDataReader.Read())
			{
				PhotoDetail photoDetail = new PhotoDetail();
				photoDetail.PhotoId = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(1335), 0);
				photoDetail.DG_Photos_CreatedOn = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(3328), default(DateTime));
				do
				{
					photoDetail.FileName = Path.Combine(base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(21607), string.Empty), photoDetail.DG_Photos_CreatedOn.ToString(RfidAccess.getReportAccess(49549)), base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(31368), string.Empty));
					photoDetail.PhotoRFID = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(53142), string.Empty);
				}
				while (8 == 0);
				photoDetail.PhotoRFID = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(53142), string.Empty);
				list.Add(photoDetail);
			}
			return list;
		}

		private List<RFIDTagInfo> RFIDTagInfoxk ( IDataReader IDataReader )
		{
			List<RFIDTagInfo> list = new List<RFIDTagInfo>();
			while (IDataReader.Read())
			{
				RFIDTagInfo rFIDTagInfo = new RFIDTagInfo();
				rFIDTagInfo.DummyRFIDTagID = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(53963), 0);
				do
				{
					rFIDTagInfo.TagId = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(53984), string.Empty);
					rFIDTagInfo.CreatedOn = new DateTime?(base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(3576), DateTime.Now));
					rFIDTagInfo.IsActive = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(3533), false);
				}
				while (2 == 0);
				list.Add(rFIDTagInfo);
			}
			return list;
		}

		private List<RfidFlushHistotyInfo> RfidFlushHistotyInfoyk ( IDataReader IDataReader)
		{
			List<RfidFlushHistotyInfo> list = new List<RfidFlushHistotyInfo>();
			DateTime? defaultValue = null;
			while (IDataReader.Read())
			{
				list.Add(new RfidFlushHistotyInfo
				{
					FlushId = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(53993), 0),
					EndDate = new DateTime?(base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(2929), defaultValue)),
					ErrorMessage = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(2951), string.Empty),
					ScheduleDate = new DateTime?(base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(2899), defaultValue)),
					StartDate = new DateTime?(base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(2916), defaultValue)),
					Status = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(2942), 0),
					SubStoreId = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(2968), 0),
					SubStore = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(54006), string.Empty),
					LocationName = base.GetFieldValue(IDataReader, RfidAccess.getReportAccess(29680), string.Empty)
				});
			}
			return list;
		}

		public bool SaveRfidFlushHistory(RfidFlushHistotyInfo rfidFlush)
		{
			if (!false)
			{
				base.DBParameters.Clear();
				if (5 == 0)
				{
					goto IL_BD;
				}
				base.AddParameter(RfidAccess.getReportAccess(34106), rfidFlush.SubStoreId);
			}
			base.AddParameter(RfidAccess.getReportAccess(7696), rfidFlush.LocationId);
			IL_64:
			base.AddParameter(RfidAccess.getReportAccess(54019), rfidFlush.ScheduleDate);
			do
			{
				base.AddParameter(RfidAccess.getReportAccess(54040), rfidFlush.Status);
			}
			while (!true);
			base.ExecuteNonQuery(RfidAccess.getReportAccess(54053));
			IL_BD:
			if (!false)
			{
				return true;
			}
			goto IL_64;
		}

		public bool RfidFlushNow(int SubStoreId, int LocationId, int ExcludeDays)
		{
			base.DBParameters.Clear();
			base.AddParameter(RfidAccess.getReportAccess(34106), SubStoreId);
			base.AddParameter(RfidAccess.getReportAccess(54082), LocationId);
			base.AddParameter(RfidAccess.getReportAccess(54091), ExcludeDays);
			base.ExecuteNonQuery(RfidAccess.getReportAccess(54108));
			return true;
		}

		static RfidAccess()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(RfidAccess));
		}
	}
}
