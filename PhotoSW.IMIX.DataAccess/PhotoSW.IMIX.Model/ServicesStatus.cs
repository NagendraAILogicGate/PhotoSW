using System;

namespace PhotoSW.IMIX.Model
{
	public class ServicesStatus
	{
		private string _serviceName;

		private string _runningStatus;

		private string _buttonText;

		private string _originalservicename;

		private string _servicePath;

		private bool? _isInterface;

		private string _backOffsetColor;

		private string _backColor;

		public string ServiceName
		{
			get
			{
				return this._serviceName;
			}
			set
			{
				this._serviceName = value;
			}
		}

		public string RunningStatus
		{
			get
			{
				return this._runningStatus;
			}
			set
			{
				this._runningStatus = value;
			}
		}

		public string ButtonText
		{
			get
			{
				return this._buttonText;
			}
			set
			{
				this._buttonText = value;
			}
		}

		public string Originalservicename
		{
			get
			{
				return this._originalservicename;
			}
			set
			{
				this._originalservicename = value;
			}
		}

		public string ServicePath
		{
			get
			{
				return this._servicePath;
			}
			set
			{
				this._servicePath = value;
			}
		}

		public bool? IsInterface
		{
			get
			{
				return this._isInterface;
			}
			set
			{
				this._isInterface = value;
			}
		}

		public string BackOffsetColor
		{
			get
			{
				return this._backOffsetColor;
			}
			set
			{
				this._backOffsetColor = value;
			}
		}

		public string BackColor
		{
			get
			{
				return this._backColor;
			}
			set
			{
				this._backColor = value;
			}
		}
	}
}
