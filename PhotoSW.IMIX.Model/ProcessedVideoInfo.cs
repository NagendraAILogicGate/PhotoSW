using System;
using System.Collections.Generic;

namespace PhotoSW.IMIX.Model
{
	public class ProcessedVideoInfo
	{
		public long ProcessedVideoId
		{
			get;
			set;
		}

		public int VideoId
		{
			get;
			set;
		}

		public string Effects
		{
			get;
			set;
		}

		public string OutputVideoFileName
		{
			get;
			set;
		}

		public int CreatedBy
		{
			get;
			set;
		}

		public DateTime? CreatedOn
		{
			get;
			set;
		}

		public int ProductId
		{
			get;
			set;
		}

		public string FirstMediaRFID
		{
			get;
			set;
		}

		public int SubStoreId
		{
			get;
			set;
		}

		public long VideoLength
		{
			get;
			set;
		}

		public string HotFolderPath
		{
			get;
			set;
		}

		public IEnumerable<ProcessedVideoDetailsInfo> processedVideoItemsDetails
		{
			get;
			set;
		}

		public string lightness
		{
			get;
			set;
		}

		public string saturation
		{
			get;
			set;
		}

		public string contrast
		{
			get;
			set;
		}

		public string darkness
		{
			get;
			set;
		}

		public bool greyScale
		{
			get;
			set;
		}

		public bool invert
		{
			get;
			set;
		}

		public string textLogo
		{
			get;
			set;
		}

		public string textLogoPosition
		{
			get;
			set;
		}

		public string graphicLogo
		{
			get;
			set;
		}

		public string graphicLogoPosition
		{
			get;
			set;
		}

		public string zoom
		{
			get;
			set;
		}

		public string fadeInOut
		{
			get;
			set;
		}

		public bool chroma
		{
			get;
			set;
		}

		public string chromaKeyColor
		{
			get;
			set;
		}

		public string chromaKeyBG
		{
			get;
			set;
		}

		public string audio
		{
			get;
			set;
		}

		public string audioEffects
		{
			get;
			set;
		}

		public string textfontName
		{
			get;
			set;
		}

		public string textfontColor
		{
			get;
			set;
		}

		public string textfontSize
		{
			get;
			set;
		}

		public string textfontStyle
		{
			get;
			set;
		}

		public string amplify
		{
			get;
			set;
		}

		public string equal1
		{
			get;
			set;
		}

		public string equal2
		{
			get;
			set;
		}

		public string equal3
		{
			get;
			set;
		}

		public string equal4
		{
			get;
			set;
		}

		public string equal5
		{
			get;
			set;
		}

		public string equal6
		{
			get;
			set;
		}
	}
}
