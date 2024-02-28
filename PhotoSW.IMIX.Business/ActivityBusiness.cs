using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.BAL;

namespace PhotoSW.IMIX.Business
{
   public class ActivityBusiness
   {
       public List<PhotoSW.IMIX.Model.ActivityInfo> GetActivity(bool ISFromDate, bool IsToDate,
           DateTime FromDate, DateTime ToDate, int UserID)
       {
           try
           {
               var obj =baActivityInfo.GetActivityInfoData()
                   .Select(p => new PhotoSW.IMIX.Model.ActivityInfo
                   {                       
                       DG_Actions_pkey =(int) p.Id,
                       DG_Acitivity_Action_Pkey = p.PS_Acitivity_Action_Pkey,
                       DG_Acitivity_ActionType = p.PS_Acitivity_ActionType,
                       DG_Acitivity_Date = p.ActivityDate,
                       DG_Acitivity_By = p.PS_Acitivity_By,
                       DG_Acitivity_Descrption = p.PS_Acitivity_Descrption,
                       DG_Reference_ID = p.PS_Reference_ID,                     
                       DG_Actions_Name = p.PS_Actions_Name,
                       Name = p.Name,
                       ActivityDate = p.ActivityDate,
                       SyncCode = p.SyncCode,
                       IsSynced = p.IsSynced,
                       Version = p.Version,                    
                       //IsActive = p.IsActive
                   }).ToList();
               return obj;
           }
           catch
           {
               return new List<Model.ActivityInfo>();
           }
        // return  new List<PhotoSW.IMIX.Model.ActivityInfo>();
       }
       public DataSet GetActivityReport(DateTime? FromDate, DateTime? ToDate, int? UserID)
       {
            // var obj = baActivityInfo.GetActivityInfoData();
            //DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            //obj.Where(c=> c.ActivityDate == FromDate && c.PS_Acitivity_Date == ToDate);

            var obj = baVW_GetActivityReports.GetPhotoGroupInfoData();

            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable("dtActivity");

            ////dataTable.Columns.Add("DG_Actions_Name", typeof(string));
            ////dataTable.Columns.Add("User Name", typeof(string));
            ////dataTable.Columns.Add("ActivityDate", typeof(DateTime));
            ////dataTable.Columns.Add("DG_Acitivity_Descrption", typeof(string));
            ////dataTable.Columns.Add("DG_User_Name", typeof(string));
            ////dataTable.Columns.Add("DG_User_First_Name", typeof(string));
            ////dataTable.Columns.Add("DG_User_Last_Name", typeof(string));

            ////dataTable.Columns.Add("DG_Actions_pkey", typeof(int));

            //obj.CopyToDataTable(dataTable, LoadOption.PreserveChanges);
            dataTable.Columns.Add("PS_Actions_Name", typeof(string));
//dataTable.Columns.Add("PS_Activity_Date", typeof(DateTime));                     
            dataTable.Columns.Add("PS_User_Name", typeof(string));
            dataTable.Columns.Add("PS_User_First_Name", typeof(string));
            dataTable.Columns.Add("PS_User_Last_Name", typeof(string));
          //  dataTable.Columns.Add("Name",typeof(string));
            dataTable.Columns.Add("PS_Acitivity_Descrption", typeof(string));
            dataTable.Columns.Add("PS_Actions_pkey", typeof(int));
////dataTable.Columns.Add("PS_User_pkey", typeof(int));
        //    dataTable.Columns.Add("PS_Activity_Action_Pkey",typeof(int));
            dataTable.Columns.Add("ActivityDate", typeof(DateTime));

            foreach(var test in obj)
                {
                dataTable.Rows.Add(test.PS_Actions_Name,  test.PS_User_Name, test.PS_User_First_Name, test.PS_User_Last_Name, test.PS_Acitivity_Descrption, test.PS_Actions_pkey, test.ActivityDate);
                }

            // dataTable.Rows.Add("Photo", "Jay", "1/11/2018", "Description","Jay", "Jay", "Shukla");
            //dataTable.Rows.Add("Vidio", "Jay", "1/11/2018", "Description", "Jay", "Jay", "Shukla", 44);
            // dataTable.Rows.Add("Albam", "3", "10", "Jay", "Shukla", "Admin", "abc");

            dataSet.Tables.Add(dataTable);
            
            return dataSet;

           // return new DataSet();
       }
       public bool RegisterLog(int CurrentUser, int ActivityType, string Description, string SyncCode)
       {
        
           return false;
       }
       public bool RegisterLog(int CurrentUser, int ActivityType, string Description, string SyncCode, int RefID)
       {
           return false;
       }
    }
}
