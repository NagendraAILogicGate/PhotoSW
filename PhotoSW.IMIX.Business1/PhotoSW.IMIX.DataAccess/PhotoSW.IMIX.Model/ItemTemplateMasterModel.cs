using System;
using System.Collections.Generic;

namespace PhotoSW.IMIX.Model
{
	public class ItemTemplateMasterModel
	{
		public int Id
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public int SubtemplateCount
		{
			get;
			set;
		}

		public int PathType
		{
			get;
			set;
		}

		public int TemplateType
		{
			get;
			set;
		}

		public string ThumbnailImagePath
		{
			get;
			set;
		}

		public string ThumbnailImageName
		{
			get;
			set;
		}

		public int Status
		{
			get;
			set;
		}

		public string BasePath
		{
			get;
			set;
		}

		public List<ItemTemplateDetailModel> ItemTemplateDetailList
		{
			get;
			set;
		}
	}
}
