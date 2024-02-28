using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class SearchCriteriaInfo : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public long ;

			public long ;

			public long ;

			public List<SearchDetailInfo> ;

			public SearchCriteriaInfo ;

			public SearchDetailInfo ;

			public int ;

			public void ()
			{
				SearchCriteriaAccess searchCriteriaAccess = new SearchCriteriaAccess(this..Transaction);
				this. = searchCriteriaAccess.GetSearchDetailWithQrcode(this., out this., out this., out this., this.);
			}
		}

		public List<SearchDetailInfo> GetSearchDetailWithQrcode(SearchDetailInfo Searchdetails, out long maxPhotoId, out long minPhotoId, out long imgCount, int mediaType)
		{
			if (2 == 0)
			{
				goto IL_59;
			}
			SearchCriteriaInfo.  = new SearchCriteriaInfo.();
			. = Searchdetails;
			IL_1C:
			. = mediaType;
			. = this;
			. = 0L;
			if (!false)
			{
				. = 0L;
				. = 0L;
			}
			IL_59:
			. = new List<SearchDetailInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			if (2 != 0)
			{
				maxPhotoId = .;
				minPhotoId = .;
				imgCount = .;
				return .;
			}
			goto IL_1C;
		}
	}
}
