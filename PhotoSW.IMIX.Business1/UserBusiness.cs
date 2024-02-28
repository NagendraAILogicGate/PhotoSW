
//using ErrorHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using PhotoSW.IMIX.DataAccess;
using PhotoSW.IMIX.Model;
namespace PhotoSW.IMIX.Business
{
	public class UserBusiness : BaseBusiness
	{
        private sealed class UserBusiness_SOH
        {
            public UsersInfo userInfoSOH;
            public UserBusiness userBusiness;
            public string ETX;
            public string EOT;
            public void SOH()
            {
                UsersDao usersDao=new UsersDao (this.userBusiness.Transaction);
                this.userInfoSOH=usersDao.GetUserDetails(this.ETX,this.EOT,true);
               
            }
        }

        private sealed class UserBusiness_STX
        {
            public UserBusiness userBusiness;
            public Dictionary<int, string> STX;
            public void SOH()
            {
                UsersDao usersDao = new UsersDao(this.userBusiness.Transaction);
                foreach (KeyValuePair<int, string> current in this.STX)
                {
                    int arg_39_0 = current.Key;
                    usersDao.UPD_EncryptUsersPwd(current.Key, current.Value);
                }
              

            }
        }
        private sealed class UserBusiness_ETX
        {
            public UserBusiness userBusiness;

            public int STX;
		    public string ETX;
            public string EOT;
            public string ENQ;
			public string ACK;
            public int  BEL;
            public int  BS;
            public bool? SO;
            public string SI;
            public string DLE;
            public string DC1;
            public void SOH()
            {
                while (true)
				{
					UsersDao usersDao = new UsersDao(this.userBusiness.Transaction);
					while (7 != 0)
					{
                        usersDao.UPD_INS_UserDetails
                            (
                             this.STX, this.BEL,this.BS,this.SO, this.ETX,this.EOT,this.ENQ, this.SI,this.DLE,this.DC1, this.ACK
                            );
                        return;
                    }
                }
            }
        }

        private sealed class UserBusiness_EOT
        {
            public Dictionary<int ,string > Dic_SOH;
            public UserBusiness userBusiness;
            private static  Func<UsersInfo,int> ETX;
            private static  Func<UsersInfo,string > EOT;
            public void SOH()
            {
                UsersDao usersDao = new UsersDao(this.userBusiness.Transaction);
				IEnumerable<UsersInfo> arg_79_0 = usersDao.GetUsersPwdDetails();
                
				if (UserBusiness_EOT.ETX == null)
				{
                    
                   UserBusiness_EOT.ETX =new Func<UsersInfo,int> (UserBusiness_EOT.ETX);
					
				}
				Func<UsersInfo, int> arg_79_1 = UserBusiness.UserBusiness_EOT.ETX;
				if (UserBusiness.UserBusiness_EOT.EOT == null)
				{
					UserBusiness.UserBusiness_EOT.EOT = new Func<UsersInfo, string>(UserBusiness.UserBusiness_EOT.EOT);
				}
                this.Dic_SOH=arg_79_0 .ToDictionary(arg_79_1,UserBusiness.UserBusiness_EOT.EOT);
				
			}
            private static int m_pKey(UsersInfo STX)
            {
                return STX.DG_User_pkey;
            }
            private static string m_Password(UsersInfo STX)
            {
                return STX.DG_User_Password;
            }

           
           
        }

       private sealed class UserBusiness_ENQ
       {
           public Dictionary<string ,int> Dic_SOH;
           public UserBusiness STX;
           public int ETX;
           public void SOH()
           {
               do{
                   UsersDao usersDao;
                   usersDao=new UsersDao(this.STX.Transaction);
                   this.Dic_SOH=usersDao.SelUserDetailsByUserId(this.ETX);
               }while(false);
           }
       }
         private sealed class UserBusiness_ACK
       {
           public List<UsersInfo> list_SOH;
           public UserBusiness STX;
           public int ETX;
           public string  EOT;
         public int ENQ;
           public void SOH()
           {
               while(true){
                   UsersDao usersDao;
                   usersDao=new UsersDao(this.STX.Transaction);
                   this.list_SOH=usersDao.SelUserDetailByUserId(this.ETX,this.EOT,this.ENQ);
                 
               }
           }
       }
         private sealed class UserBusiness_BEL
         {
             public List<UsersInfo> list_SOH;
             public UserBusiness STX;
             public int ETX;
             //public string EOT;
             //public int ENQ;
             public void SOH()
             {
                 do
                 {
                     UsersDao usersDao;
                     usersDao = new UsersDao(this.STX.Transaction);
                     this.list_SOH = usersDao.GetChildUserDetailByUserId(this.ETX);

                 } while (false);
             }
         }


         private sealed class UserBusiness_BS
         {
             public bool Is_SOH;
             public UserBusiness STX;
             public int ETX;
             //public string EOT;
             //public int ENQ;
             public void SOH()
             {
                 do
                 {
                     UsersDao usersDao;
                     usersDao = new UsersDao(this.STX.Transaction);
                     this.Is_SOH = usersDao.DeleteUsersbyId(this.ETX);

                 } while (false);
             }
         }

         private sealed class UserBusiness_SO
         {
             public List<UsersInfo> list_SOH;
             public UserBusiness STX;
             public string ETX;
             public string EOT;
             public int ENQ;
             public string ACK;
             public int BEL;
             public string BS;
			 public string SO;
             public int SI;
             public string DLE;


             public void SOH()
             {
                 do
                 {
                     UsersDao usersDao;
                     usersDao = new UsersDao(this.STX.Transaction);
                     this.list_SOH = usersDao.SearchUserDetails(
                           this.ETX,this.EOT,this. ENQ,this.ACK,this.BEL,this.BS,this.SO,this.SI,this.DLE);

                 } while (false);
             }
         }

         private sealed class UserBusiness_SI
         {
             public List<UserInfo> list_SOH;
             public UserBusiness STX;
             public int ETX;
             //public string EOT;
             //public int ENQ;
             public void SOH()
             {
                 do
                 {
                     UserAccess userAccess;
                     userAccess = new UserAccess(this.STX.Transaction);
                     this.list_SOH = userAccess.GetPhotoGraphersList();

                 } while (false);
             }
         }
         private sealed class UserBusiness_DLE
         {
             public List<PhotoGraphersInfo> list_SOH;
             public UserBusiness STX;
             public int ETX;
             //public string EOT;
             //public int ENQ;
             public void SOH()
             {
                 do
                 {
                     StoreDao storeDao;
                     storeDao = new StoreDao(this.STX.Transaction);
                     this.list_SOH = storeDao.SelectPhotoGraphersList(this.ETX);

                 } while (false);
             }
         }
         private sealed class UserBusiness_DC1
         {
             public List<UserInfo> list_SOH;
             public UserBusiness STX;
             public int ETX;
             //public string EOT;
             //public int ENQ;
             public void SOH()
             {
                 do
                 {
                     UsersDao usersDao;
                     usersDao = new UsersDao(this.STX.Transaction);
                     this.list_SOH = usersDao.GetPhotoGrapherList();

                 } while (false);
             }
         }
         private sealed class UserBusiness_DC2
        {
            public UserBusiness  userBusiness ;
            public int STX;
        }
        private sealed class UserBusiness_DC3
        {
            public List<UsersInfo> list_SOH;
            public UserBusiness.UserBusiness_DC2 STX;
            public int ETX;
            //public string EOT;
            //public int ENQ;
            public void SOH()
            {
                do
                {
                    UsersDao usersDao;
                    usersDao = new UsersDao(this.STX.userBusiness.Transaction);
                    this.list_SOH = usersDao.GetUserByUserId(this.STX.STX);

                } while (false);
            }
        }
        public UsersInfo GetUserDetails(string username,string password)
        {
            UserBusiness.UserBusiness_SOH SOH=new UserBusiness_SOH ();
            SOH.ETX=username;
            SOH.EOT=password;
            do{
                SOH.userBusiness=this;
                SOH.userInfoSOH=new UsersInfo ();
            }while(false);
            this.operation=new BaseBusiness.TransactionMethod(SOH.SOH);
            base.Start(false);
            return SOH.userInfoSOH;
        }
    
	public bool EncryptUsersPwd(Dictionary<int, string> ltEncryptedpwd)
		{
		
			BaseBusiness.TransactionMethod transactionMethod = null;
			IL_06:
             UserBusiness.UserBusiness_STX STX=new UserBusiness_STX ();
			//UserBusiness.UserBusiness_STX STX = new UserBusiness.UserBusiness_STX();
			IL_10:
			if (4 == 0)
			{
				goto IL_06;
			}
              STX.STX=ltEncryptedpwd;
		
			if (-1 != 0)
			{
				STX.userBusiness=this;
				bool result;
				try
				{
					if (transactionMethod == null)
					{
						transactionMethod = new BaseBusiness.TransactionMethod(STX.SOH);
					}
					this.operation = transactionMethod;
					bool arg_56_0 = base.Start(false);
					if (3 != 0)
					{
						arg_56_0 = true;
					}
					result = arg_56_0;
				}
				catch
				{
					if (true)
					{
						result = false;
					}
				}
				return result;
			}
			goto IL_06;
		}
public bool AddUpdateUserDetails(int DG_User_pkey, string DG_User_Name, string DG_User_First_Name,    string DG_User_Last_Name, string DG_User_Password, int DG_User_Roles_Id, int DG_Location_ID, 
    bool? DG_User_Status, string DG_User_PhoneNo, 
    string DG_User_Email,
    string SyncCode)
		{
    UserBusiness_ETX ETX2=null;
			BaseBusiness.TransactionMethod transactionMethod;
			do
			{
				transactionMethod = null;
			}
            while (false);
			ETX2.ETX= DG_User_Name;
			ETX2.EOT= DG_User_First_Name;
			ETX2.ENQ= DG_User_Last_Name;
			ETX2.ACK= DG_User_Password;
			ETX2.BEL= DG_User_Roles_Id;
			ETX2.BS= DG_Location_ID;
			ETX2.SO= DG_User_Status;
			ETX2.SI= DG_User_PhoneNo;
			ETX2.DLE= DG_User_Email;
			ETX2.DC1= SyncCode;
			ETX2.userBusiness= this;
			bool result;
			try
			{
				if (transactionMethod == null)
				{
				
	             transactionMethod = new BaseBusiness.TransactionMethod(ETX2.SOH);
				}
				this.operation = transactionMethod;
				base.Start(false);
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
        public Dictionary<int, string> GetUsersPwdDetails()
		{
			Dictionary<int, string> result;
			try
			{
				if (!false)
				{
					UserBusiness.UserBusiness_EOT EOT = new UserBusiness.UserBusiness_EOT();
					EOT.userBusiness= this;
					if (8 != 0)
					{
						if (false)
						{
							goto IL_38;
						}
                        EOT.userBusiness = null;
						this.operation = new BaseBusiness.TransactionMethod(EOT.SOH);
					}
					base.Start(false);
					IL_38:
					result =EOT.Dic_SOH ;
				}
			}
			catch
			{
				if (2 != 0)
				{
					result = null;
				}
			}
			return result;
		}
       	public Dictionary<string, int> GetUserDetailsByUserId(int userId)
		{
			UserBusiness.UserBusiness_ENQ ENQ = new UserBusiness.UserBusiness_ENQ();
			ENQ.ETX= userId;
			ENQ.STX= this;
            ENQ.Dic_SOH= new Dictionary<string, int>();
			this.operation = new BaseBusiness.TransactionMethod(ENQ.SOH);
			base.Start(false);
			return ENQ.Dic_SOH;
		}
        public List<UsersInfo> GetUserDetailByUserId(int userId, string userName, int roleId)
		{
			UserBusiness.UserBusiness_ACK ACK = new UserBusiness.UserBusiness_ACK();
			ACK.ETX = userId;
			ACK.EOT= userName;
			ACK.ENQ= roleId;
			ACK.STX = this;
			ACK.list_SOH = new List<UsersInfo>();
            this.operation = new BaseBusiness.TransactionMethod(ACK.SOH);
			base.Start(false);
            return ACK.list_SOH;
		}

        public List<UsersInfo> GetChildUserDetailByUserId(int roleId)
		{
			UserBusiness.UserBusiness_BEL BEL = new UserBusiness.UserBusiness_BEL();
			BEL.ETX = roleId;
			BEL.STX = this;
			BEL.list_SOH = new List<UsersInfo>();
			this.operation = new BaseBusiness.TransactionMethod(BEL.SOH);
			base.Start(false);
            return BEL.list_SOH;
		}

        public bool DeleteUsers(int userID)
		{
			UserBusiness.UserBusiness_BS BS= new UserBusiness.UserBusiness_BS();
			BS.ETX = userID;
			BS.STX= this;
			BS.Is_SOH = false;
			this.operation = new BaseBusiness.TransactionMethod(BS.SOH);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 = BS.Is_SOH;
				}
			}
			while (2 == 0);
			return arg_46_0;
        }////
        public List<UsersInfo> SearchUserDetails(
            string FName, 
            string LName, int StoreId,
            string Status, int RoleId, string MobileNumber, 
            string EmailId, int locationId, string userName)
		{
			UserBusiness.UserBusiness_SO SO = new UserBusiness.UserBusiness_SO();
			SO.ETX = FName;
			SO.EOT= LName;
			SO.ENQ= StoreId;
			SO.ACK= Status;
			SO.BEL = RoleId;
			SO.BS= MobileNumber;
			SO.SO= EmailId;
			do
			{
			SO.SI	= locationId;
			SO.DLE	= userName;
			}
			while (false);
			SO.STX = this;
			SO.list_SOH= new List<UsersInfo>();
			this.operation = new BaseBusiness.TransactionMethod(SO.SOH);
			base.Start(false);
            return SO.list_SOH;
		}

        public List<UserInfo> GetPhotoGraphersList()
		{UserBusiness.UserBusiness_SI SI = new UserBusiness.UserBusiness_SI();
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
				SI.STX= this;
				}
				while (false);
				SI.list_SOH= new List<UserInfo>();
				do
				{
				this.operation = new BaseBusiness.TransactionMethod(SI.SOH);
				}
				while (2 == 0);
				base.Start(false);
			}
            return SI.list_SOH;
		}

        public List<PhotoGraphersInfo> GetPhotoGraphersList(int storeId)
		{
			UserBusiness.UserBusiness_DLE DLE= new UserBusiness.UserBusiness_DLE();
            DLE.ETX = storeId;
            DLE.STX = this;
            DLE.list_SOH = new List<PhotoGraphersInfo>();
            this.operation = new BaseBusiness.TransactionMethod(DLE.SOH);
			base.Start(false);
            return DLE.list_SOH;
		}

        public List<UserInfo> GetPhotoGrapher()
		{
			List<UserInfo> result;
			try
			{
				UserBusiness.UserBusiness_DC1 DC1= new UserBusiness.UserBusiness_DC1();
				
				DC1.STX= this;
				do
				{
					
					DC1.list_SOH = new List<UserInfo>();
					this.operation = new BaseBusiness.TransactionMethod(DC1.SOH);
					base.Start(false);
				}
				while (7 == 0);
                result = DC1.list_SOH;
				
			}
			catch (Exception serviceException)
			{
				if (6 != 0)
				{
                    //ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException));
					result = null;
				}
			}
			return result;
		}
        public List<UsersInfo> GetUserDetailsByUserIddetail(int userId)
		{
			UserBusiness.UserBusiness_DC2 DC2= new UserBusiness.UserBusiness_DC2();
			DC2.STX = userId;
			DC2.userBusiness = this;
			List<UsersInfo> result;
			try
			{
				UserBusiness.UserBusiness_DC3 DC3 = new UserBusiness.UserBusiness_DC3();
				do
				{
					
					if (4 != 0)
					{
						DC3.list_SOH= new List<UsersInfo>();
						this.operation = new BaseBusiness.TransactionMethod(DC3.SOH);
						if (false)
						{
							goto IL_6C;
						}
						if (!false)
						{
							base.Start(false);
						}
					}
					if (false)
					{
						continue;
					}
                    result = DC3.list_SOH;
					IL_6C:;
				}
				while (6 == 0);
			}
			catch (Exception serviceException)
			{
				//ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException));
				result = null;
			}
			return result;
		}

	}
}
