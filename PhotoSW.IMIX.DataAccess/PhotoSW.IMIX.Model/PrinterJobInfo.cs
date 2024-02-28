using System;

namespace PhotoSW.IMIX.Model
{
	public class PrinterJobInfo
	{
		private string _jobName;

		private int _jobId;

		private string _jobStatus;

		private string _printername;

		private long _imageId;

		private string Filepath;

		public string JobName
		{
			get
			{
				return this._jobName;
			}
			set
			{
				this._jobName = value;
			}
		}

		public int JobId
		{
			get
			{
				return this._jobId;
			}
			set
			{
				this._jobId = value;
			}
		}

		public string JobStatus
		{
			get
			{
				return this._jobStatus;
			}
			set
			{
				this._jobStatus = value;
			}
		}

		public string Printername
		{
			get
			{
				return this._printername;
			}
			set
			{
				this._printername = value;
			}
		}

		public long ImageId
		{
			get
			{
				return this._imageId;
			}
			set
			{
				this._imageId = value;
			}
		}

		public string Filepath1
		{
			get
			{
				return this.Filepath;
			}
			set
			{
				this.Filepath = value;
			}
		}

		public string DG_Orders_ProductType_Name
		{
			get;
			set;
		}

		public string DG_Orders_Number
		{
			get;
			set;
		}

		public string RFID
		{
			get;
			set;
		}

		public int DG_Orders_LineItems_pkey
		{
			get;
			set;
		}

		public string PhotoID
		{
			get;
			set;
		}
	}
}
