using System;

namespace PhotoSW.IMIX.Model
{
	public class SearchDetailInfo
	{
		public int Locationid
		{
			get;
			set;
		}

		public string SubstoreId
		{
			get;
			set;
		}

		public int Userid
		{
			get;
			set;
		}

		public string PhotoGrapherName
		{
			get;
			set;
		}

		public int CodeType
		{
			get;
			set;
		}

		public string Qrcode
		{
			get;
			set;
		}

		public string SubstoreName
		{
			get;
			set;
		}

		public DateTime FromDate
		{
			get;
			set;
		}

		public DateTime ToDate
		{
			get;
			set;
		}

		public DateTime FromTime
		{
			get;
			set;
		}

		public DateTime ToTime
		{
			get;
			set;
		}

		public int PhotoId
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string FileName
		{
			get;
			set;
		}

		public int MediaType
		{
			get;
			set;
		}

		public long? VideoLength
		{
			get;
			set;
		}

		public bool IsAnonymousQrcodeEnabled
		{
			get;
			set;
		}

		public DateTime CreatedOn
		{
			get;
			set;
		}

		public int PageNumber
		{
			get;
			set;
		}

		public int PageSize
		{
			get;
			set;
		}

		public int TotalRecords
		{
			get;
			set;
		}

		public long StartIndex
		{
			get;
			set;
		}

		public int NewRecord
		{
			get;
			set;
		}

		public int TotalPage
		{
			get
			{
				return (this.TotalRecords + this.PageSize - 1) / this.PageSize;
			}
		}

		public int? CharacterId
		{
			get;
			set;
		}

		public string HotFolderPath
		{
			get;
			set;
		}

		public string OnlineQRCode
		{
			get;
			set;
		}
	}
}
