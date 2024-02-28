using System;
using System.Windows;

namespace PhotoSW.Interop
{
	public class TemplateListItems
	{
		private Visibility _CheckedBoxVisible;

		private long _Item_ID;

		private bool _IsChecked;

		private string _DisplayName;

		private string _Name;

		private string _FilePath;

		private int _MediaType;

		private long _Length;

		private string _Tooltip;

		public Visibility CheckedBoxVisible
		{
			get
			{
				return this._CheckedBoxVisible;
			}
			set
			{
				this._CheckedBoxVisible = value;
			}
		}

		public long Item_ID
		{
			get
			{
				return this._Item_ID;
			}
			set
			{
				this._Item_ID = value;
			}
		}

		public bool IsChecked
		{
			get
			{
				return this._IsChecked;
			}
			set
			{
				this._IsChecked = value;
			}
		}

		public string DisplayName
		{
			get
			{
				return this._DisplayName;
			}
			set
			{
				this._DisplayName = value;
			}
		}

		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				this._Name = value;
			}
		}

		public string FilePath
		{
			get
			{
				return this._FilePath;
			}
			set
			{
				this._FilePath = value;
			}
		}

		public int MediaType
		{
			get
			{
				return this._MediaType;
			}
			set
			{
				this._MediaType = value;
			}
		}

		public long Length
		{
			get
			{
				return this._Length;
			}
			set
			{
				this._Length = value;
			}
		}

		public string Tooltip
		{
			get
			{
				return this._Tooltip;
			}
			set
			{
				this._Tooltip = value;
			}
		}

		public int StartTime
		{
			get;
			set;
		}

		public int EndTime
		{
			get;
			set;
		}

		public int InsertTime
		{
			get;
			set;
		}

		public bool isActive
		{
			get;
			set;
		}

		public string GuestVideoPath
		{
			get;
			set;
		}

		public int LeftPositon
		{
			get;
			set;
		}

		public int TopPositon
		{
			get;
			set;
		}
	}
}
