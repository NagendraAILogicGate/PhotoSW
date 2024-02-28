using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PhotoSW.IMIX.Model
{
	public class ReportConfigurationDetails : BaseDataModel
	{
		private string exportPath;

		private string emailAddress;

		private string scheduleTime;

		private bool isRecursive;

		private List<ReportTypeDetails> reportTypeDetails;

		private int selectedHour;

		private int selectedminute;

		private string selectedFormat;

		public string ExportPath
		{
			get
			{
				return this.exportPath;
			}
			set
			{
				this.exportPath = value;
				this.PropertyModified("ExportPath");
			}
		}

		public string EmailAddress
		{
			get
			{
				return this.emailAddress;
			}
			set
			{
				this.emailAddress = value;
				this.PropertyModified("EmailAddress");
			}
		}

		public string ScheduleTime
		{
			get
			{
				return string.Format("{0}:{1}", this.SelectedHour, this.SelectedMinute);
			}
		}

		public bool IsRecursive
		{
			get
			{
				return this.isRecursive;
			}
			set
			{
				this.isRecursive = value;
				this.PropertyModified("IsRecursive");
			}
		}

        public List<ReportTypeDetails> ReportTypeDetails
        {
            get
            {
                return this.reportTypeDetails;
            }
            set
            {
                this.reportTypeDetails = value;
                this.PropertyModified("ReportTypeDetails");
            }
        }

		public bool HasError
		{
			get;
			set;
		}

		public string ErrorDetails
		{
			get;
			set;
		}

		public string ErrorMessage
		{
			get;
			set;
		}

		public List<int> Hours
		{
			get
			{
				List<int> list = new List<int>();
				for (int i = 0; i <= 23; i++)
				{
					list.Add(i);
				}
				return list;
			}
		}

		public List<int> Minutes
		{
			get
			{
				List<int> list = new List<int>();
				for (int i = 0; i <= 60; i++)
				{
					list.Add(i);
				}
				return list;
			}
		}

		public List<string> DateFormat
		{
			get
			{
				return new List<string>
				{
					"AM",
					"PM"
				};
			}
		}

		public int SelectedHour
		{
			get
			{
				return this.selectedHour;
			}
			set
			{
				this.selectedHour = value;
				this.PropertyModified("SelectedHour");
			}
		}

		public int SelectedMinute
		{
			get
			{
				return this.selectedminute;
			}
			set
			{
				this.selectedminute = value;
				this.PropertyModified("SelectedMinute");
			}
		}

		public string SelectedFormat
		{
			get
			{
				return this.selectedFormat;
			}
			set
			{
				this.selectedFormat = value;
				this.PropertyModified("Selectedformat");
			}
		}

		public string StoreName
		{
			get;
			set;
		}

		public int StoreId
		{
			get;
			set;
		}

		public string UserName
		{
			get;
			set;
		}

		public int UserId
		{
			get;
			set;
		}

		public string LocationName
		{
			get;
			set;
		}

		public List<ExportServiceLog> ExportServiceLogs
		{
			get;
			set;
		}

		public string EmailFormat
		{
			get;
			set;
		}

		public static ReportConfigurationDetails LoadDefaultData()
		{
			return new ReportConfigurationDetails
			{
				EmailAddress = string.Empty,
				ExportPath = string.Empty,
				IsRecursive = false,
				//ReportTypeDetails = new List<ReportTypeDetails>(),
				SelectedHour = -1,
				SelectedMinute = -1,
				SelectedFormat = string.Empty,
				HasError = false,
				ErrorDetails = string.Empty,
				ErrorMessage = string.Empty,
				EmailFormat = string.Empty
			};
		}

		public string Validate()
		{
			string result;
			if (string.IsNullOrEmpty(this.ExportPath))
			{
				result = "Please browse export path.";
			}
			else if (string.IsNullOrEmpty(this.EmailAddress))
			{
				result = "Please enter a email address.";
			}
			else if (!Regex.IsMatch(this.EmailAddress, "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$"))
			{
				result = "Enter valid mail address.";
			}
			else if (this.SelectedHour == -1 || this.SelectedMinute == -1)
			{
				result = "Please select time";
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}
	}
}
