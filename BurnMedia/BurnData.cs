using System;

namespace BurnMedia
{
	public class BurnData
	{
		public string uniqueRecorderId;

		public string statusMessage;

		public BURN_MEDIA_TASK task;

		public long elapsedTime;

		public long remainingTime;

		public long totalTime;

		public IMAPI_FORMAT2_DATA_WRITE_ACTION currentAction;

		public long startLba;

		public long sectorCount;

		public long lastReadLba;

		public long lastWrittenLba;

		public long totalSystemBuffer;

		public long usedSystemBuffer;

		public long freeSystemBuffer;

		public int BOID;

		public string ORDERNUMBER;
	}
}
