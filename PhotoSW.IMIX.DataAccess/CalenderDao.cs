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
	public class CalenderDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static GetString getCalender;
        public CalenderDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public CalenderDao()
		{
		}

		public List<ItemTemplateDetailModel> GetItemTemplateDetail()
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(CalenderDao.getCalender(30861), 0);
			}
			IDataReader dataReader;
			List<ItemTemplateDetailModel> result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				if (3 != 0)
				{
					result = this.itemTemplateDetailModel(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<ItemTemplateDetailModel> itemTemplateDetailModel ( IDataReader dataReader)
		{
			List<ItemTemplateDetailModel> list = new List<ItemTemplateDetailModel>();
			while (dataReader.Read())
			{
				ItemTemplateDetailModel item = new ItemTemplateDetailModel
				{
					Id = base.GetFieldValue(dataReader, CalenderDao.getCalender(30894), 0),
					MasterTemplateId = base.GetFieldValue(dataReader, CalenderDao.getCalender(30899), 0),
					TemplateType = base.GetFieldValue(dataReader, CalenderDao.getCalender(30924), 0),
					FileName = base.GetFieldValue(dataReader, CalenderDao.getCalender(30941), string.Empty).Replace(CalenderDao.getCalender(30954), CalenderDao.getCalender(24188)).Replace(CalenderDao.getCalender(30963), CalenderDao.getCalender(24188)),
					FilePath = base.GetFieldValue(dataReader, CalenderDao.getCalender(30972), string.Empty),
					FileOrder = base.GetFieldValue(dataReader, CalenderDao.getCalender(30985), 0),
					I1_X1 = base.GetFieldValue(dataReader, CalenderDao.getCalender(30998), 0),
					I1_X2 = base.GetFieldValue(dataReader, CalenderDao.getCalender(31007), 0),
					I1_Y1 = base.GetFieldValue(dataReader, CalenderDao.getCalender(31016), 0),
					I1_Y2 = base.GetFieldValue(dataReader, CalenderDao.getCalender(31025), 0)
				};
				list.Add(item);
			}
			return list;
		}

		public List<ItemTemplateMasterModel> GetItemTemplateMaster()
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(CalenderDao.getCalender(31034), 0);
			}
			IDataReader dataReader;
			List<ItemTemplateMasterModel> result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				if (3 != 0)
				{
					result = this.itemTemplateMasterModel(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<ItemTemplateMasterModel> itemTemplateMasterModel ( IDataReader dataReader)
		{
			List<ItemTemplateMasterModel> list = new List<ItemTemplateMasterModel>();
			while (true)
			{
				while (dataReader.Read())
				{
					ItemTemplateMasterModel itemTemplateMasterModel = new ItemTemplateMasterModel();
					itemTemplateMasterModel.Id = base.GetFieldValue(dataReader, CalenderDao.getCalender(30894), 0);
					itemTemplateMasterModel.Name = base.GetFieldValue(dataReader, CalenderDao.getCalender(548), string.Empty);
					itemTemplateMasterModel.Description = base.GetFieldValue(dataReader, CalenderDao.getCalender(3132), string.Empty);
					itemTemplateMasterModel.SubtemplateCount = base.GetFieldValue(dataReader, CalenderDao.getCalender(31075), 0);
					itemTemplateMasterModel.PathType = base.GetFieldValue(dataReader, CalenderDao.getCalender(31100), 0);
					if (!false)
					{
						itemTemplateMasterModel.TemplateType = base.GetFieldValue(dataReader, CalenderDao.getCalender(30924), 0);
						itemTemplateMasterModel.ThumbnailImagePath = base.GetFieldValue(dataReader, CalenderDao.getCalender(31113), string.Empty);
						itemTemplateMasterModel.ThumbnailImageName = base.GetFieldValue(dataReader, CalenderDao.getCalender(31138), string.Empty);
						if (3 != 0)
						{
							ItemTemplateMasterModel item = itemTemplateMasterModel;
							list.Add(item);
						}
					}
				}
				break;
			}
			return list;
		}

		public bool AddItemTemplatePrintOrder(ItemTemplatePrintOrderModel objModel)
		{
			base.DBParameters.Clear();
			base.AddParameter(CalenderDao.getCalender(31163), objModel.OrderLineItemId);
			base.AddParameter(CalenderDao.getCalender(31188), objModel.MasterTemplateId);
			base.AddParameter(CalenderDao.getCalender(31213), objModel.DetailTemplateId);
			base.AddParameter(CalenderDao.getCalender(31238), objModel.PrintTypeId);
			base.AddParameter(CalenderDao.getCalender(1080), objModel.PhotoId);
			if (7 == 0)
			{
				goto IL_17C;
			}
			base.AddParameter(CalenderDao.getCalender(31255), objModel.PageNo);
			base.AddParameter(CalenderDao.getCalender(31268), objModel.PrintPosition);
			base.AddParameter(CalenderDao.getCalender(31289), objModel.RotationAngle);
			base.AddParameter(CalenderDao.getCalender(19504), objModel.Status);
			base.AddParameter(CalenderDao.getCalender(31310), objModel.PrinterQueueId);
			IL_161:
			base.AddParameter(CalenderDao.getCalender(31331), objModel.CreatedBy);
			IL_17C:
			base.ExecuteNonQuery("");
			if (!false)
			{
				return true;
			}
			goto IL_161;
		}

		public List<ItemTemplateDetailModel> GetTemplatePath(int Id)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(CalenderDao.getCalender(31163), Id);
			}
			IDataReader dataReader;
			List<ItemTemplateDetailModel> result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				if (3 != 0)
				{
					result = this.itemTemplateDetailModel2(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<ItemTemplateDetailModel> itemTemplateDetailModel2 ( IDataReader dataReader)
		{
			List<ItemTemplateDetailModel> list = new List<ItemTemplateDetailModel>();
			while (true)
			{
				if (4 == 0)
				{
					goto IL_61;
				}
				IL_68:
				ItemTemplateDetailModel itemTemplateDetailModel;
				if (!dataReader.Read())
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
					itemTemplateDetailModel = new ItemTemplateDetailModel();
					itemTemplateDetailModel.MasterTemplateId = base.GetFieldValue(dataReader, CalenderDao.getCalender(30899), 0);
				}
				if (!false)
				{
					itemTemplateDetailModel.Id = base.GetFieldValue(dataReader, CalenderDao.getCalender(31348), 0);
				}
				ItemTemplateDetailModel item = itemTemplateDetailModel;
				IL_61:
				list.Add(item);
				goto IL_68;
			}
			return list;
		}

		static CalenderDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(CalenderDao));
		}
	}
}
