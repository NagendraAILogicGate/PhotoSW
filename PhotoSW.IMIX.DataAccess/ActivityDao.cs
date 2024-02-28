//using #2j;
//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
    {
    public delegate string GetString ( int i );

    public class ActivityDao : BaseDataAccess
        {
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getActivity;

        public ActivityDao ( BaseDataAccess baseaccess ) : base(baseaccess)
            {
            }

        public ActivityDao ()
            {
            }

        public int AddActivity ( ActivityInfo activityInfo )
            {
            string expr_143 = ActivityDao.getActivity(201);
            object expr_1E = activityInfo.DG_Acitivity_ActionType;
            if(4 != 0)
                {
                base.AddParameter(expr_143, expr_1E);
                }
            if(4 != 0)
                {
                base.AddParameter(ActivityDao.getActivity(242), activityInfo.DG_Acitivity_Date);
                base.AddParameter(ActivityDao.getActivity(275), activityInfo.DG_Acitivity_By);
                base.AddParameter(ActivityDao.getActivity(304), activityInfo.DG_Acitivity_Descrption);
                base.AddParameter(ActivityDao.getActivity(345), activityInfo.DG_Reference_ID);
                base.AddParameter(ActivityDao.getActivity(374), activityInfo.SyncCode);
                base.AddParameter(ActivityDao.getActivity(395), activityInfo.IsSynced);
                base.AddParameter(ActivityDao.getActivity(416), activityInfo.DG_Acitivity_Action_Pkey, ParameterDirection.Output);
                base.ExecuteNonQuery("");
                }
            int result;
            do
                {
                result = (int)base.GetOutParameterValue(ActivityDao.getActivity(416));
                }
            while(3 == 0);
            return result;
            }

        public List<ActivityInfo> GetActivityReports ()
            {
            base.DBParameters.Clear();
            IDataReader dataReader;
            if(8 != 0)
                {
                dataReader = base.ExecuteReader("");
                }
            List<ActivityInfo> result = this.ActivityInfo(dataReader);
            dataReader.Close();
            return result;
            }

        private List<ActivityInfo> ActivityInfo ( IDataReader IDataReader )
            {
            List<ActivityInfo> list = new List<ActivityInfo>();
            while(IDataReader.Read())
                {
                ActivityInfo item = new ActivityInfo
                    {
                    DG_Actions_pkey = base.GetFieldValue(IDataReader, ActivityDao.getActivity(441), 0),
                    DG_Actions_Name = base.GetFieldValue(IDataReader, ActivityDao.getActivity(462), string.Empty),
                    DG_Acitivity_Date = base.GetFieldValue(IDataReader, ActivityDao.getActivity(483), DateTime.Now),
                    Name = base.GetFieldValue(IDataReader, ActivityDao.getActivity(508), string.Empty),
                    DG_Acitivity_Descrption = base.GetFieldValue(IDataReader, ActivityDao.getActivity(517), string.Empty),
                    DG_Acitivity_Action_Pkey = base.GetFieldValue(IDataReader, ActivityDao.getActivity(550), 0),
                    ActivityDate = base.GetFieldValue(IDataReader, ActivityDao.getActivity(583), DateTime.Now),
                    //usersInfo = new UsersInfo
                    //                   {
                    //                   DG_User_Name = base.GetFieldValue(IDataReader, ActivityDao.getActivity(600), string.Empty),
                    //	DG_User_First_Name = base.GetFieldValue(IDataReader, ActivityDao.getActivity(617), string.Empty),
                    //	DG_User_Last_Name = base.GetFieldValue(IDataReader, ActivityDao.getActivity(642), string.Empty),
                    //	DG_User_pkey = base.GetFieldValue(IDataReader, ActivityDao.getActivity(667), 0)
                    //}

                    };
                list.Add(item);
                }
            return list;
            }

        public DataSet GetActivityReport ( DateTime? FromDate, DateTime? ToDate, int? UserID )
            {
            base.DBParameters.Clear();
            DataSet result;
            while(true)
                {
                if(8 != 0)
                    {
                    string expr_AA = ActivityDao.getActivity(684);
                    object expr_C0 = base.SetNullDateTimeValue(FromDate);
                    if(8 != 0)
                        {
                        base.AddParameter(expr_AA, expr_C0);
                        }
                    }
                while(true)
                    {
                    base.AddParameter(ActivityDao.getActivity(705), base.SetNullDateTimeValue(ToDate));
                    if(false)
                        {
                        break;
                        }
                    base.AddParameter(ActivityDao.getActivity(722), base.SetNullIntegerValue(UserID));
                    result = base.ExecuteDataSet("");
                    if(5 != 0)
                        {
                        return result;
                        }
                    }
                }
            return result;
            }

        public List<string> IsUpdateAvailable ( string currVersion )
            {
            IDataReader dataReader;
            List<string> result;
            while(-1 != 0)
                {
                base.DBParameters.Clear();
                if(false)
                    {
                    break;
                    }
                base.AddParameter(ActivityDao.getActivity(751), currVersion);
                if(8 != 0)
                    {
                    if(!false)
                        {
                        dataReader = base.ExecuteReader("");
                        result = this.stringList(dataReader);
                        break;
                        }
                    break;
                    }
                }
            dataReader.Close();
            return result;
            }

        private List<string> stringList ( IDataReader IDataReader )
            {
            List<string> list = new List<string>();
            while(!false)
                {
                while(true)
                    {
                    ActivityInfo activityInfo;
                    if(!false)
                        {
                        if(!IDataReader.Read())
                            {
                            return list;
                            }
                        if(4 == 0)
                            {
                            break;
                            }
                        activityInfo = new ActivityInfo();
                        }
                    activityInfo.Version = base.GetFieldValue(IDataReader, ActivityDao.getActivity(764), string.Empty);
                    ActivityInfo activityInfo2 = activityInfo;
                    list.Add(activityInfo2.Version);
                    }
                }
            return list;
            }

        static ActivityDao ()
            {
            // Note: this type is marked as 'beforefieldinit'.
            SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(ActivityDao));
            }
        }
    }

