using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
    public class SearchCriteriaInfo //: BaseBusiness
    {
        public SearchCriteriaInfo()
        {
        }

        public List<PhotoSW.IMIX.Model.SearchDetailInfo> GetSearchDetailWithQrcode(PhotoSW.IMIX.Model.SearchDetailInfo Searchdetails,
            out long maxPhotoId, out long minPhotoId, out long imgCount, int mediaType)
        {
            imgCount = 0;
            minPhotoId = 0;
            maxPhotoId = 0;
            return new List<PhotoSW.IMIX.Model.SearchDetailInfo>();
        }
    }
}
