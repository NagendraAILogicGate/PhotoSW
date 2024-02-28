//using #2j;
//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class SearchCriteriaAccess : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getSearchCriteriaAccess;
        public SearchCriteriaAccess(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public SearchCriteriaAccess()
		{
		}

		public List<SearchDetailInfo> GetSearchDetailWithQrcode(SearchDetailInfo Searchdetails, out long maxPhotoId, out long minPhotoId, out long imgCount, int mediaType)
		{
			imgCount = 0L;
			maxPhotoId = 0L;
			minPhotoId = 0L;
			base.DBParameters.Clear();
			List<SearchDetailInfo> searchDetailByPhotoIdsOnly;
			if (!false)
			{
				base.AddParameter(SearchCriteriaAccess.getSearchCriteriaAccess(55958), Searchdetails.FromDate);
				base.AddParameter(SearchCriteriaAccess.getSearchCriteriaAccess(55979), Searchdetails.ToDate);
				base.AddParameter(SearchCriteriaAccess.getSearchCriteriaAccess(4187), Searchdetails.Locationid);
				base.AddParameter(SearchCriteriaAccess.getSearchCriteriaAccess(55996), Searchdetails.Userid);
				base.AddParameter(SearchCriteriaAccess.getSearchCriteriaAccess(56029), Searchdetails.SubstoreId);
				base.AddParameter(SearchCriteriaAccess.getSearchCriteriaAccess(56050), Searchdetails.Qrcode);
				base.AddParameter(SearchCriteriaAccess.getSearchCriteriaAccess(16518), Searchdetails.IsAnonymousQrcodeEnabled);
				base.AddParameter(SearchCriteriaAccess.getSearchCriteriaAccess(56067), Searchdetails.PageNumber);
				base.AddParameter(SearchCriteriaAccess.getSearchCriteriaAccess(22415), Searchdetails.PageSize);
				base.AddParameter(SearchCriteriaAccess.getSearchCriteriaAccess(21869), Searchdetails.StartIndex);
				base.AddParameter(SearchCriteriaAccess.getSearchCriteriaAccess(21990), Searchdetails.NewRecord);
				base.AddParameter(SearchCriteriaAccess.getSearchCriteriaAccess(8494), base.SetNullIntegerValue(Searchdetails.CharacterId));
				base.AddParameter(SearchCriteriaAccess.getSearchCriteriaAccess(22065), mediaType);
				base.AddOutParameter(SearchCriteriaAccess.getSearchCriteriaAccess(22011), SqlDbType.Int);
				base.AddOutParameter(SearchCriteriaAccess.getSearchCriteriaAccess(22036), SqlDbType.Int);
				base.AddOutParameter(SearchCriteriaAccess.getSearchCriteriaAccess(56092), SqlDbType.Int);
				IDataReader dataReader = base.ExecuteReader("");
				searchDetailByPhotoIdsOnly = this.GetSearchDetailByPhotoIdsOnly(dataReader);
				dataReader.Close();
				if (searchDetailByPhotoIdsOnly.Count <= 0)
				{
					return searchDetailByPhotoIdsOnly;
				}
				minPhotoId = Convert.ToInt64(base.GetOutParameterValue(SearchCriteriaAccess.getSearchCriteriaAccess(22036)));
			}
			maxPhotoId = Convert.ToInt64(base.GetOutParameterValue(SearchCriteriaAccess.getSearchCriteriaAccess(22011)));
			imgCount = Convert.ToInt64(base.GetOutParameterValue(SearchCriteriaAccess.getSearchCriteriaAccess(56092)));
			return searchDetailByPhotoIdsOnly;
		}

		public List<SearchDetailInfo> GetSearchDetailByPhotoIds(IDataReader sqlReader)
		{
			List<SearchDetailInfo> list = new List<SearchDetailInfo>();
			while (sqlReader.Read())
			{
				list.Add(new SearchDetailInfo
				{
					PhotoId = base.GetFieldValue(sqlReader, SearchCriteriaAccess.getSearchCriteriaAccess(21124), 0),
					Name = base.GetFieldValue(sqlReader, SearchCriteriaAccess.getSearchCriteriaAccess(21199), string.Empty),
					FileName = base.GetFieldValue(sqlReader, SearchCriteriaAccess.getSearchCriteriaAccess(21145), string.Empty),
					CreatedOn = base.GetFieldValue(sqlReader, SearchCriteriaAccess.getSearchCriteriaAccess(21170), DateTime.Now),
					HotFolderPath = base.GetFieldValue(sqlReader, SearchCriteriaAccess.getSearchCriteriaAccess(21609), string.Empty),
					MediaType = base.GetFieldValue(sqlReader, SearchCriteriaAccess.getSearchCriteriaAccess(21630), 0),
					VideoLength = new long?(base.GetFieldValue(sqlReader, SearchCriteriaAccess.getSearchCriteriaAccess(21647), 0L))
				});
			}
			return list;
		}

		public List<SearchDetailInfo> GetSearchDetailByPhotoIdsOnly(IDataReader sqlReader)
		{
			List<SearchDetailInfo> list = new List<SearchDetailInfo>();
			while (true)
			{
				while (sqlReader.Read())
				{
					SearchDetailInfo searchDetailInfo = new SearchDetailInfo();
					searchDetailInfo.PhotoId = base.GetFieldValue(sqlReader, SearchCriteriaAccess.getSearchCriteriaAccess(21124), 0);
					searchDetailInfo.Name = base.GetFieldValue(sqlReader, SearchCriteriaAccess.getSearchCriteriaAccess(21199), string.Empty);
					searchDetailInfo.FileName = base.GetFieldValue(sqlReader, SearchCriteriaAccess.getSearchCriteriaAccess(21145), string.Empty);
					searchDetailInfo.CreatedOn = base.GetFieldValue(sqlReader, SearchCriteriaAccess.getSearchCriteriaAccess(21170), DateTime.Now);
					searchDetailInfo.HotFolderPath = base.GetFieldValue(sqlReader, SearchCriteriaAccess.getSearchCriteriaAccess(21609), string.Empty);
					if (!false)
					{
						searchDetailInfo.MediaType = base.GetFieldValue(sqlReader, SearchCriteriaAccess.getSearchCriteriaAccess(21630), 0);
						searchDetailInfo.VideoLength = new long?(base.GetFieldValue(sqlReader, SearchCriteriaAccess.getSearchCriteriaAccess(21647), 0L));
						searchDetailInfo.OnlineQRCode = base.GetFieldValue(sqlReader, SearchCriteriaAccess.getSearchCriteriaAccess(21714), string.Empty);
						list.Add(searchDetailInfo);
					}
				}
				break;
			}
			return list;
		}

		static SearchCriteriaAccess()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(SearchCriteriaAccess));
		}
	}
}
