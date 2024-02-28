namespace DigiPhoto.ExtensionMethods
{
    using ErrorHandler;
    using System;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class ExtensionMethods
    {
        public static void ExportToCSV(this DataTable dtDataTable, string removableWords, string exportPath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(exportPath, false))
                {
                    int num = 0;
                    while (num < dtDataTable.Columns.Count)
                    {
                        writer.Write(dtDataTable.Columns[num].ColumnName.Replace(removableWords, string.Empty).Trim());
                        if (num < (dtDataTable.Columns.Count - 1))
                        {
                            writer.Write(",");
                        }
                        num++;
                    }
                    writer.Write(writer.NewLine);
                    foreach (DataRow row in dtDataTable.Rows)
                    {
                        for (num = 0; num < dtDataTable.Columns.Count; num++)
                        {
                            if (!Convert.IsDBNull(row[num]))
                            {
                                string source = row[num].ToString();
                                if (source.Contains<char>(','))
                                {
                                    source = string.Format("\"{0}\"", source);
                                    writer.Write(source);
                                }
                                else
                                {
                                    writer.Write(row[num].ToString());
                                }
                            }
                            if (num < (dtDataTable.Columns.Count - 1))
                            {
                                writer.Write(",");
                            }
                        }
                        writer.Write(writer.NewLine);
                    }
                }
            }
            catch (Exception exception)
            {
                LogError("DigiReportExportService", "Extensions", "ExportToCSV", exception.Message + "\n" + exception.StackTrace);
            }
        }

        public static bool ExportToCSV(this DataTable dtDataTable, string removableWords, string exportPath, out string exceptionMessage)
        {
            bool flag = false;
            exceptionMessage = string.Empty;
            try
            {
                using (StreamWriter writer = new StreamWriter(exportPath, false))
                {
                    int num = 0;
                    while (num < dtDataTable.Columns.Count)
                    {
                        writer.Write(dtDataTable.Columns[num].ColumnName.Replace(removableWords, string.Empty).Trim());
                        if (num < (dtDataTable.Columns.Count - 1))
                        {
                            writer.Write(",");
                        }
                        num++;
                    }
                    writer.Write(writer.NewLine);
                    foreach (DataRow row in dtDataTable.Rows)
                    {
                        for (num = 0; num < dtDataTable.Columns.Count; num++)
                        {
                            if (!Convert.IsDBNull(row[num]))
                            {
                                string source = row[num].ToString();
                                if (source.Contains<char>(','))
                                {
                                    source = string.Format("\"{0}\"", source);
                                    writer.Write(source);
                                }
                                else
                                {
                                    writer.Write(row[num].ToString());
                                }
                            }
                            if (num < (dtDataTable.Columns.Count - 1))
                            {
                                writer.Write(",");
                            }
                        }
                        writer.Write(writer.NewLine);
                        flag = true;
                    }
                    return flag;
                }
            }
            catch (Exception exception)
            {
                LogError("DigiReportExportService", "Extensions", "ExportToCSV", exception.Message + "\n" + exception.StackTrace);
                exceptionMessage = exception.Message + "\n" + exception.StackTrace;
                flag = false;
            }
            return flag;
        }

        public static void LogError(string applicationName, string className, string methodNaame, string message)
        {
            string str = string.Format("Application : {0} , Module : {1} , Method : {2} , ErrorMessage : {3}", new object[] { applicationName, className, methodNaame, message });
            LogConfigurator.log.Error(str);
            ErrorHandler.ErrorHandler.LogError(new Exception(str));
        }
    }
}

