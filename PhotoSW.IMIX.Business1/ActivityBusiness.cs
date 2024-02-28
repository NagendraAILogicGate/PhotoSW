//using DigiPhoto.IMIX.DataAccess;
using PhotoSW.IMIX.Model;
//using ErrorHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

using PhotoSW.IMIX.DataAccess;

namespace PhotoSW.IMIX.Business
{
	public class ActivityBusiness : BaseBusiness
	{
	
        private sealed class ActivityBus_SOH
        {
            public ActivityInfo  activityInfo{get;set;}
            public ActivityBusiness activityBusiness{get;set;}
            public void ActivityBusSOH()
            {	
                ActivityDao expr_2E = new ActivityDao(this.activityBusiness.Transaction);
				ActivityDao activityDao=new ActivityDao ();
                activityDao = expr_2E;
                this.activityInfo.DG_Acitivity_Action_Pkey=activityDao.AddActivity(this.activityInfo);
                //this.activityInfo.DG_Acitivity_Action_Pkey = activityDao.AddActivity(this.);
            }
        }
  
        private sealed class ActivityBus_STX
        {
            public ActivityInfo  activityInfo{get;set;}
            public ActivityBusiness activityBusiness{get;set;}
            public void ActivityBusSTX()
            {	
                ActivityDao expr_2E = new ActivityDao(this.activityBusiness.Transaction);
				ActivityDao activityDao=new ActivityDao ();
                activityDao = expr_2E;
                this.activityInfo.DG_Acitivity_Action_Pkey=activityDao.AddActivity(this.activityInfo);
                //this.activityInfo.DG_Acitivity_Action_Pkey = activityDao.AddActivity(this.);
            }
        }
		
        private sealed class ActivityBusiness_ETX
        {
            public List<ActivityInfo> activityInfo;
            public ActivityBusiness activityBusiness;
            public void ActivityBusinessETX()
            {
                ActivityDao activityDao=new ActivityDao (this.activityBusiness.Transaction);
                this.activityInfo=activityDao.GetActivityReports();
            }
        }
        private sealed class ActivityBusiness_EOT
        {
            public DataSet Dt_SOH;

            public ActivityBusiness activityBusiness;
            public DateTime? ETX;
            public DateTime? EOT;
            public int? ENQ;

            public void ActivityBusinessSOH()
            {
                ActivityDao activityDao = new ActivityDao();
                this.Dt_SOH = activityDao.GetActivityReport(this.ETX, this.EOT, this.ENQ);
            }
        }
        private CustomBusineses customerBusiness;

        public bool RegisterLog(int CurrentUser, int ActivityType, string Description, string SyncCode)
        {
            ActivityBusiness.ActivityBus_SOH SOH = new ActivityBus_SOH();
            SOH.activityBusiness = this;
            this.customerBusiness = new CustomBusineses();
            SOH.activityInfo = new ActivityInfo();
            SOH.activityInfo.DG_Acitivity_By = CurrentUser;
            SOH.activityInfo.DG_Acitivity_ActionType = ActivityType;
            if (true)
            {
                SOH.activityInfo.DG_Acitivity_Descrption = Description;
                SOH.activityInfo.DG_Acitivity_Date = DateTime.Now;
                SOH.activityInfo.SyncCode = SyncCode;

                SOH.activityInfo.IsSynced = false;
                this.operation = new BaseBusiness.TransactionMethod(SOH.ActivityBusSOH);

                base.Start(false);
            }

            return SOH.activityInfo.DG_Acitivity_Action_Pkey > 0;//..DG_Acitivity_Action_Pkey > 0;

        }

        public bool RegisterLog(int CurrentUser, int ActivityType, string Description, string SyncCode, int RefID)
		{
            ActivityBusiness .ActivityBus_STX STX=new ActivityBusiness .ActivityBus_STX ();
		
            STX.activityBusiness=this;
			  this.customerBusiness = new CustomBusineses();
            STX.activityInfo=new ActivityInfo ();
		 STX.activityInfo.DG_Acitivity_By=CurrentUser;
            STX.activityInfo.DG_Acitivity_ActionType=ActivityType;

            
            STX.activityInfo.DG_Acitivity_Descrption = Description;
            STX.activityInfo.DG_Acitivity_Date = DateTime.Now;
            STX.activityInfo.DG_Reference_ID = RefID;
            STX.activityInfo.SyncCode = SyncCode;
            STX.activityInfo.IsSynced = false;
            this.operation =new BaseBusiness .TransactionMethod(STX.ActivityBusSTX);
            base.Start(false);
            return STX.activityInfo.DG_Acitivity_Action_Pkey > 0;
			
		}
        public List<ActivityInfo> GetActivity(bool ISFromDate, bool IsToDate, DateTime FromDate, DateTime ToDate, int UserID)
        { 
            
            BaseBusiness.TransactionMethod transactionMethod = null;
            ActivityBusiness.ActivityBusiness_ETX ETX=new ActivityBusiness.ActivityBusiness_ETX ();
			
            ETX.activityBusiness=this;
	        ETX.activityInfo=null;
			
			try
			{
				if (transactionMethod == null)
				{
                    transactionMethod =new BaseBusiness .TransactionMethod (ETX.ActivityBusinessETX);
				
				}
				this.operation = transactionMethod;
			}
			catch (Exception serviceException)
			{
				//string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				//ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
            return ETX.activityInfo;
		
        
        }
        public DataSet GetActivityReport(DateTime? FromDate, DateTime? ToDate, int? UserID)
        {
            ActivityBusiness.ActivityBusiness_EOT EOT =new ActivityBusiness.ActivityBusiness_EOT ();
          EOT.ETX=FromDate;
		  EOT.EOT=ToDate;
		  EOT.ENQ=UserID;
              EOT .activityBusiness=this;
            EOT.Dt_SOH=new DataSet ();
            this.operation=new BaseBusiness .TransactionMethod(EOT.ActivityBusinessSOH);
			
			base.Start(false);
            return EOT.Dt_SOH;
        }
        
	}
}
