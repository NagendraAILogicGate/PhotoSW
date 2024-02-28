using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class ProcessedVideoBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public ProcessedVideoBusiness ;

			public ProcessedVideoInfo ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProcessedVideoBusiness. ;

			public DataTable ;

			public int ;

			public void ()
			{
				while (true)
				{
					ProcessedVideoAccess processedVideoAccess;
					if (-1 != 0)
					{
						processedVideoAccess = new ProcessedVideoAccess(this...Transaction);
						goto IL_15;
					}
					IL_33:
					if (!false)
					{
						if (false)
						{
							continue;
						}
						if (5 != 0)
						{
							break;
						}
					}
					IL_15:
					this. = processedVideoAccess.SaveProcessedVideoAndDetails(this.., this.);
					goto IL_33;
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<VideoProducts> ;

			public ProcessedVideoBusiness ;

			public void ()
			{
				ProcessedVideoAccess processedVideoAccess = new ProcessedVideoAccess(this..Transaction);
				this. = processedVideoAccess.GetVideoPackages();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProcessedVideoBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProcessedVideoBusiness. ;

			public ProcessedVideoInfo ;

			public void ()
			{
				if (4 != 0)
				{
					ProcessedVideoAccess processedVideoAccess = new ProcessedVideoAccess(this...Transaction);
					if (!false)
					{
						this. = processedVideoAccess.GetProcessedVideoDetails(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProcessedVideoBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProcessedVideoBusiness. ;

			public FilePhotoInfo ;

			public void ()
			{
				if (4 != 0)
				{
					ProcessedVideoAccess processedVideoAccess = new ProcessedVideoAccess(this...Transaction);
					if (!false)
					{
						this. = processedVideoAccess.GetFileInfo(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProcessedVideoBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProcessedVideoBusiness. ;

			public List<ProcessedVideoInfo> ;

			public void ()
			{
				if (4 != 0)
				{
					ProcessedVideoAccess processedVideoAccess = new ProcessedVideoAccess(this...Transaction);
					if (!false)
					{
						this. = processedVideoAccess.GetProcessedVideosByPackageId(this..);
					}
				}
			}
		}

		[NonSerialized]
		internal static SmartAssembly.Delegates.GetString ;

		public int SaveProcessedVideoAndDetails(ProcessedVideoInfo processedVideo, List<ProcessedVideoDetailsInfo> lstPVDetails)
		{
			ProcessedVideoBusiness.  = new ProcessedVideoBusiness.();
			. = processedVideo;
			. = this;
			int result;
			try
			{
				ProcessedVideoBusiness.  = new ProcessedVideoBusiness.();
				. = ;
				. = new DataTable();
				if (!false)
				{
					..Columns.Add(ProcessedVideoBusiness.(3510));
					..Columns.Add(ProcessedVideoBusiness.(3543));
					..Columns.Add(ProcessedVideoBusiness.(3568));
					..Columns.Add(ProcessedVideoBusiness.(3581));
					..Columns.Add(ProcessedVideoBusiness.(3598));
					..Columns.Add(ProcessedVideoBusiness.(3611));
					..Columns.Add(ProcessedVideoBusiness.(3624));
					..Columns.Add(ProcessedVideoBusiness.(3641));
					..Columns.Add(ProcessedVideoBusiness.(3654));
					foreach (ProcessedVideoDetailsInfo current in lstPVDetails)
					{
						..Rows.Add(new object[]
						{
							current.ProcessedVideoDetailId,
							current.ProcessedVideoId,
							current.FrameTime,
							current.DisplayTime,
							current.MediaId,
							current.MediaType,
							current.JoiningOrder,
							current.StartTime,
							current.EndTime
						});
					}
					. = 0;
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				int arg_26C_0 = base.Start(false) ? 1 : 0;
				if (!false)
				{
					arg_26C_0 = .;
				}
				result = arg_26C_0;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}

		public List<VideoProducts> GetVideoPackages()
		{
			List<VideoProducts> result;
			try
			{
				if (!false)
				{
					ProcessedVideoBusiness.  = new ProcessedVideoBusiness.();
					. = this;
					if (8 != 0)
					{
						if (false)
						{
							goto IL_3C;
						}
						. = new List<VideoProducts>();
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					base.Start(false);
					IL_3C:
					result = .;
				}
			}
			catch (Exception)
			{
				if (2 != 0)
				{
					result = null;
				}
			}
			return result;
		}

		public ProcessedVideoInfo GetProcessedVideoDetails(int VideoId)
		{
			if (!false && -1 != 0)
			{
			}
			. = VideoId;
			. = this;
			ProcessedVideoInfo result;
			try
			{
				ProcessedVideoBusiness.  = new ProcessedVideoBusiness.();
				if (!false)
				{
					. = ;
				}
				. = new ProcessedVideoInfo();
				if (6 != 0)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					if (!false)
					{
						base.Start(false);
						result = .;
					}
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		public FilePhotoInfo GetFileInfo(int photos_Key)
		{
			if (!false && -1 != 0)
			{
			}
			. = photos_Key;
			. = this;
			FilePhotoInfo result;
			try
			{
				ProcessedVideoBusiness.  = new ProcessedVideoBusiness.();
				if (!false)
				{
					. = ;
				}
				. = new FilePhotoInfo();
				if (6 != 0)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					if (!false)
					{
						base.Start(false);
						result = .;
					}
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		public List<ProcessedVideoInfo> GetProcessedVideosByPackageId(int packageID)
		{
			if (!false && -1 != 0)
			{
			}
			. = packageID;
			. = this;
			List<ProcessedVideoInfo> result;
			try
			{
				ProcessedVideoBusiness.  = new ProcessedVideoBusiness.();
				if (!false)
				{
					. = ;
				}
				. = new List<ProcessedVideoInfo>();
				if (6 != 0)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					if (!false)
					{
						base.Start(false);
						result = .;
					}
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		static ProcessedVideoBusiness()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(ProcessedVideoBusiness));
		}
	}
}
