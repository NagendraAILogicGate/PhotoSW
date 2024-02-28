using System;

namespace PhotoSW.IMIX.DataAccess
{
	public class Constants
	{
		public enum SyncOrderStatus
		{
			NotSynced,
			Synced,
			Error = -1,
			Invalid = -2,
			UploadedDataOnCentralServerandCloudinary = 3,
			UploadedDataOnCentralServerButFailedonCloudinary = -3,
			ProcessedDataOnCentralServer = 4,
			FailedToProcessDataOnCentralServer = -4,
			FailedtoProcessonPartnerDB = -5
		}
	}
}
