using ErrorHandler;
using System;
using System.Data;
using System.IO;
using System.Linq;

namespace PhotoSW.ExtensionMethods
{
	public static class ExtensionMethods
	{
		public static void ExportToCSV(this DataTable dtDataTable, string removableWords, string exportPath)
		{
			try
			{
				using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(exportPath, false))
				{
					for (int i = 0; i < dtDataTable.Columns.Count; i++)
					{
						string text = dtDataTable.Columns[i].ColumnName;
						text = text.Replace(removableWords, string.Empty);
						streamWriter.Write(text.Trim());
						if (i < dtDataTable.Columns.Count - 1)
						{
							streamWriter.Write(",");
						}
					}
					streamWriter.Write(streamWriter.NewLine);
					foreach (DataRow dataRow in dtDataTable.Rows)
					{
						for (int i = 0; i < dtDataTable.Columns.Count; i++)
						{
							if (!System.Convert.IsDBNull(dataRow[i]))
							{
								string text2 = dataRow[i].ToString();
								if (text2.Contains(','))
								{
									text2 = string.Format("\"{0}\"", text2);
									streamWriter.Write(text2);
								}
								else
								{
									streamWriter.Write(dataRow[i].ToString());
								}
							}
							if (i < dtDataTable.Columns.Count - 1)
							{
								streamWriter.Write(",");
							}
						}
						streamWriter.Write(streamWriter.NewLine);
					}
				}
			}
			catch (System.Exception ex)
			{
				ExtensionMethods.LogError("DigiReportExportService", "Extensions", "ExportToCSV", ex.Message + "\n" + ex.StackTrace);
			}
		}

		public static bool ExportToCSV(this DataTable dtDataTable, string removableWords, string exportPath, out string exceptionMessage)
		{
			bool result = false;
			exceptionMessage = string.Empty;
			try
			{
				using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(exportPath, false))
				{
					for (int i = 0; i < dtDataTable.Columns.Count; i++)
					{
						string text = dtDataTable.Columns[i].ColumnName;
						text = text.Replace(removableWords, string.Empty);
						streamWriter.Write(text.Trim());
						if (i < dtDataTable.Columns.Count - 1)
						{
							streamWriter.Write(",");
						}
					}
					streamWriter.Write(streamWriter.NewLine);
					foreach (DataRow dataRow in dtDataTable.Rows)
					{
						for (int i = 0; i < dtDataTable.Columns.Count; i++)
						{
							if (!System.Convert.IsDBNull(dataRow[i]))
							{
								string text2 = dataRow[i].ToString();
								if (text2.Contains(','))
								{
									text2 = string.Format("\"{0}\"", text2);
									streamWriter.Write(text2);
								}
								else
								{
									streamWriter.Write(dataRow[i].ToString());
								}
							}
							if (i < dtDataTable.Columns.Count - 1)
							{
								streamWriter.Write(",");
							}
						}
						streamWriter.Write(streamWriter.NewLine);
						result = true;
					}
				}
			}
			catch (System.Exception ex)
			{
				ExtensionMethods.LogError("DigiReportExportService", "Extensions", "ExportToCSV", ex.Message + "\n" + ex.StackTrace);
				exceptionMessage = ex.Message + "\n" + ex.StackTrace;
				result = false;
			}
			return result;
		}

		public static void LogError(string applicationName, string className, string methodNaame, string message)
		{
			string message2 = string.Format("Application : {0} , Module : {1} , Method : {2} , ErrorMessage : {3}", new object[]
			{
				applicationName,
				className,
				methodNaame,
				message
			});
			LogConfigurator.log.Error(message2);
			ErrorHandler.ErrorHandler.LogError(new System.Exception(message2));
		}
	}
}
