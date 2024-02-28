//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class ProcessedVideoAccess : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getProcessedVideoAccess;
        public ProcessedVideoAccess(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public ProcessedVideoAccess()
		{
		}

		public int SaveProcessedVideoAndDetails(ProcessedVideoInfo processedvideo, DataTable dtPVDetails)
		{
			base.DBParameters.Clear();
			string expr_1D3 = ProcessedVideoAccess.getProcessedVideoAccess(50060);
			object expr_2D = processedvideo.ProcessedVideoId;
			if (!false)
			{
				base.AddParameter(expr_1D3, expr_2D);
			}
			base.AddParameter(ProcessedVideoAccess.getProcessedVideoAccess(1518), processedvideo.VideoId);
			base.AddParameter(ProcessedVideoAccess.getProcessedVideoAccess(50085), processedvideo.Effects);
			base.AddParameter(ProcessedVideoAccess.getProcessedVideoAccess(50098), processedvideo.OutputVideoFileName);
			base.AddParameter(ProcessedVideoAccess.getProcessedVideoAccess(31756), processedvideo.CreatedBy);
			base.AddParameter(ProcessedVideoAccess.getProcessedVideoAccess(32652), processedvideo.CreatedOn);
			base.AddParameter(ProcessedVideoAccess.getProcessedVideoAccess(50127), processedvideo.ProductId);
			base.AddParameter(ProcessedVideoAccess.getProcessedVideoAccess(50144), processedvideo.FirstMediaRFID);
			base.AddParameter(ProcessedVideoAccess.getProcessedVideoAccess(34104), processedvideo.SubStoreId);
			base.AddParameter(ProcessedVideoAccess.getProcessedVideoAccess(50165), dtPVDetails);
			base.AddParameter(ProcessedVideoAccess.getProcessedVideoAccess(32896), processedvideo.VideoLength);
			base.AddParameter(ProcessedVideoAccess.getProcessedVideoAccess(50202), 0, ParameterDirection.Output);
			base.ExecuteNonQuery(ProcessedVideoAccess.getProcessedVideoAccess(50219));
			return (int)base.GetOutParameterValue(ProcessedVideoAccess.getProcessedVideoAccess(50202));
		}

		public List<VideoProducts> GetVideoPackages()
		{
			base.DBParameters.Clear();
			IDataReader dataReader = base.ExecuteReader(ProcessedVideoAccess.getProcessedVideoAccess(50264));
			List<VideoProducts> result;
			do
			{
				result = this.videoProducts(dataReader);
			}
			while (false);
			dataReader.Close();
			return result;
		}

		private List<VideoProducts> videoProducts ( IDataReader dataReader)

        {
			List<VideoProducts> list;
			if (!false)
			{
				list = new List<VideoProducts>();
			}
			while (dataReader.Read())
			{
				list.Add(new VideoProducts
				{
					ProductID = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(3397), 0),
					ProductName = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(3259), string.Empty),
					ProductLength = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(20421), 0),
					ProductQuantity = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(20122), 0)
				});
			}
			return list;
		}

		public ProcessedVideoInfo GetProcessedVideoDetails(int VideoId)
		{
			if (!false)
			{
				base.DBParameters.Add(new SqlParameter(ProcessedVideoAccess.getProcessedVideoAccess(50289), VideoId));
				goto IL_1E;
			}
			IL_3B:
			IDataReader dataReader;
			while (-1 != 0)
			{
				dataReader.Close();
				if (!false)
				{
					ProcessedVideoInfo result;
					//return result;
				}
			}
			goto IL_2F;
			IL_1E:
			dataReader = base.ExecuteReader(ProcessedVideoAccess.getProcessedVideoAccess(50302));
			IL_2F:
			if (true)
			{
				ProcessedVideoInfo result = this.processedVideoInfo(dataReader, VideoId);
				goto IL_3B;
			}
			goto IL_1E;
		}

		private ProcessedVideoInfo processedVideoInfo ( IDataReader dataReader, int info)
		{
			ProcessedVideoInfo processedVideoInfo = new ProcessedVideoInfo();
			while (dataReader.Read())
			{
				ProcessedVideoInfo expr_1A6 = processedVideoInfo;
				long expr_1C2 = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(50335), 0L);
				if (true)
				{
					expr_1A6.ProcessedVideoId = expr_1C2;
				}
				processedVideoInfo.VideoId = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(50289), 0);
				processedVideoInfo.OutputVideoFileName = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(21141), string.Empty);
				processedVideoInfo.CreatedOn = new DateTime?(base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(21166), DateTime.MinValue));
				processedVideoInfo.FirstMediaRFID = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(21195), string.Empty);
				processedVideoInfo.CreatedBy = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(21216), 0);
				processedVideoInfo.SubStoreId = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(21533), 0);
				processedVideoInfo.ProductId = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(27675), 0);
				processedVideoInfo.Effects = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(50360), string.Empty);
				processedVideoInfo.VideoLength = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(21643), 0L);
				processedVideoInfo.HotFolderPath = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(21605), string.Empty);
				processedVideoInfo.processedVideoItemsDetails = this.GetProcessedVideoItemsDetails(info);
			}
			return processedVideoInfo;
		}

		public List<ProcessedVideoDetailsInfo> GetProcessedVideoItemsDetails(int VideoId)
		{
			List<SqlParameter> expr_46 = base.DBParameters;
			if (!false)
			{
				expr_46.Clear();
			}
			base.DBParameters.Add(new SqlParameter(ProcessedVideoAccess.getProcessedVideoAccess(50289), VideoId));
			IDataReader iDataReader = base.ExecuteReader(ProcessedVideoAccess.getProcessedVideoAccess(50373));
			return this.processedVideoDetailsInfo(iDataReader);
		}

		private List<ProcessedVideoDetailsInfo> processedVideoDetailsInfo ( IDataReader dataReader)
		{
			List<ProcessedVideoDetailsInfo> list = new List<ProcessedVideoDetailsInfo>();
			while (true)
			{
				ProcessedVideoDetailsInfo processedVideoDetailsInfo;
				if (dataReader.Read())
				{
					processedVideoDetailsInfo = new ProcessedVideoDetailsInfo();
					processedVideoDetailsInfo.DisplayTime = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(50414), 0);
					processedVideoDetailsInfo.FrameTime = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(50431), 0);
					processedVideoDetailsInfo.JoiningOrder = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(50444), 0);
					processedVideoDetailsInfo.MediaId = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(50461), 0L);
					processedVideoDetailsInfo.MediaType = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(3544), 0);
					goto IL_B7;
				}
				if (!false)
				{
					break;
				}
				IL_12C:
				if (6 != 0)
				{
					list.Add(processedVideoDetailsInfo);
					continue;
				}
				IL_B7:
				processedVideoDetailsInfo.ProcessedVideoDetailId = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(50474), 0L);
				processedVideoDetailsInfo.ProcessedVideoId = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(50289), 0);
				processedVideoDetailsInfo.StartTime = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(50507), 0);
				processedVideoDetailsInfo.EndTime = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(50520), 0);
				goto IL_12C;
			}
			return list;
		}

		public FilePhotoInfo GetFileInfo(int photos_Key)
		{
			base.DBParameters.Add(new SqlParameter(ProcessedVideoAccess.getProcessedVideoAccess(50533), photos_Key));
			IDataReader dataReader;
			FilePhotoInfo result;
			do
			{
				dataReader = base.ExecuteReader(ProcessedVideoAccess.getProcessedVideoAccess(50546));
				result = this.filePhotoInfo(dataReader);
			}
			while (5 == 0);
			dataReader.Close();
			return result;
		}

		private FilePhotoInfo filePhotoInfo ( IDataReader dataReader)
		{
			FilePhotoInfo expr_B2 = new FilePhotoInfo();
			FilePhotoInfo filePhotoInfo;
			if (5 != 0)
			{
				filePhotoInfo = expr_B2;
			}
			while (dataReader.Read())
			{
				filePhotoInfo.Photo_RFID = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(21195), string.Empty);
				filePhotoInfo.FileName = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(21141), string.Empty);
				filePhotoInfo.CreatedOn = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(21166), DateTime.MinValue);
				filePhotoInfo.HotFolderPath = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(21605), string.Empty);
			}
			return filePhotoInfo;
		}

		public List<ProcessedVideoInfo> GetProcessedVideosByPackageId(int packageID)
		{
			base.DBParameters.Add(new SqlParameter(ProcessedVideoAccess.getProcessedVideoAccess(50575), packageID));
			IDataReader dataReader;
			List<ProcessedVideoInfo> result;
			do
			{
				dataReader = base.ExecuteReader(ProcessedVideoAccess.getProcessedVideoAccess(50592));
				result = this.processedVideoInfo(dataReader);
			}
			while (5 == 0);
			dataReader.Close();
			return result;
		}

		private List<ProcessedVideoInfo> processedVideoInfo ( IDataReader dataReader)
		{
			List<ProcessedVideoInfo> list;
			while (true)
			{
				IL_00:
				list = new List<ProcessedVideoInfo>();
				if (false)
				{
					goto IL_2D;
				}
				IL_37:
				ProcessedVideoInfo processedVideoInfo;
				while (!false)
				{
					if (!dataReader.Read())
					{
						return list;
					}
					processedVideoInfo = new ProcessedVideoInfo();
					if (false)
					{
						goto IL_00;
					}
					if (7 != 0)
					{
						processedVideoInfo.VideoId = base.GetFieldValue(dataReader, ProcessedVideoAccess.getProcessedVideoAccess(21120), 0);
						break;
					}
				}
				IL_2D:
				if (3 != 0)
				{
					list.Add(processedVideoInfo);
					goto IL_37;
				}
				goto IL_37;
			}
			return list;
		}

		static ProcessedVideoAccess()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(ProcessedVideoAccess));
		}
	}
}
