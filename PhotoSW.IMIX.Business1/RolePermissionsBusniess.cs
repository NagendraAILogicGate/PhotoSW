using PhotoSW.IMIX.DataAccess;
using PhotoSW.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Data;

namespace PhotoSW.IMIX.Business
{
	public class RolePermissionsBusniess : BaseBusiness
	{
		private sealed class csSOH
		{
			public RolePermissionsBusniess SOH;

			public int STX;
		}

		private sealed class csSTX
		{
			public RolePermissionsBusniess.csSOH RolePermissionsBusniess_SOH ;
            public List<PermissionRoleInfo> STX;
             public void SOH()
			{
                    RolePermissionDao rolePermissionDao = new RolePermissionDao(this.RolePermissionsBusniess_SOH.SOH.Transaction);
                    this.STX = rolePermissionDao.SelectRolePermissions(this.RolePermissionsBusniess_SOH.STX);
                 
			}
		}

		private sealed class csETX
		{
			public RolePermissionsBusniess SOH;
			public int STX;
            public string ETX;
		}
        private sealed class csEOT
		{
			public RolePermissionsBusniess.csETX RolePermissionsBusniess_SOH;

			public List<RoleInfo> STX;

            public void SOH()
			{
				RoleDao roleDao = new RoleDao(this.RolePermissionsBusniess_SOH.SOH.Transaction);
                this.STX = roleDao.SelectRole(this.RolePermissionsBusniess_SOH.STX, this.RolePermissionsBusniess_SOH.ETX);
			}
		}
        private sealed class csENQ
		{
			public RolePermissionsBusniess SOH;

			public string STX;

			public string ETX;
		}

		
		private sealed class csACK
		{
			public RolePermissionsBusniess.csENQ  RolePermissionsBusniess_SOH;

			public List<PermissionInfo> STX;

			public void SOH()
			{
				RolePermissionDao rolePermissionDao = new RolePermissionDao(this.RolePermissionsBusniess_SOH.SOH.Transaction);
				this.STX = rolePermissionDao.SelectPermission(this.RolePermissionsBusniess_SOH.STX, this.RolePermissionsBusniess_SOH.ETX);
			}
		}

       private sealed class csBEL
		{
			public RolePermissionsBusniess RolePermissionsBusniess_SOH;

			public int STX;

			public string ETX;

			public string EOT;

			public int ENQ;

			public void SOH()
			{
				RoleDao roleDao = new RoleDao(this.RolePermissionsBusniess_SOH.Transaction);
				roleDao.UPDANDINS_User_Roles(this.STX, false, this.ETX, this.EOT,this.ENQ);
			}
		}

        private sealed class csBS
		{
            public RolePermissionsBusniess SOH;

			public int STX;
		}

		
		private sealed class csSO
		{
			public RolePermissionsBusniess.csBS RolePermissionsBusniess_SOH;

			public bool STX;

			public void SOH()
			{
				
					RoleDao roleDao = new RoleDao(this.RolePermissionsBusniess_SOH.SOH.Transaction);
					this.STX= roleDao.DeleteRoleData(this.RolePermissionsBusniess_SOH.STX);
				
			}
		}

        private sealed class csSI
		{
			public List<RoleInfo> lst_SOH;

			public RolePermissionsBusniess STX;

			public int ETX;

			public void SOH()
			{
				RoleDao expr_31 = new RoleDao(this.STX.Transaction);
				RoleDao roleDao;
				if (!false)
				{
					roleDao = expr_31;
				}
				this.lst_SOH= roleDao.SelectRole(this.ETX, string.Empty);
			}
		}

		private sealed class csDLE
		{
			public bool Is_SOH;

			public RolePermissionsBusniess STX;

			public int ETX;

			public int EOT;

			public void SOH()
			{
				while (true)
				{
					RolePermissionDao rolePermissionDao;
					if (-1 != 0)
					{
						rolePermissionDao = new RolePermissionDao(this.STX.Transaction);
						goto IL_10;
					}
					IL_33:
					if (!false)
					{
						if (false)
						{
							continue;
						}
						if (5 != 0)
						{
							break;
						}
					}
					IL_10:
					this.Is_SOH= rolePermissionDao.InsertPermissionData(this.ETX, this.EOT,this.Is_SOH);
					goto IL_33;
				}
			}
		}

        private sealed class csDC1
		{
			public bool Is_SOH;
			public RolePermissionsBusniess STX;
			public int ETX;
			public int EOT; 
			public void SOH()
			{
				if (4 != 0)
				{
					RolePermissionDao rolePermissionDao = new RolePermissionDao(this.STX.Transaction);
					this.Is_SOH = rolePermissionDao.RemovePermissionData(this.ETX, this.EOT);
				}
			}
		}

		private sealed class csDC2
		{
			public bool Is_SOH;
            public RolePermissionsBusniess STX;
            public DataTable ETX;

			public void SOH()
			{
				
					RolePermissionDao rolePermissionDao = new RolePermissionDao(this.STX.Transaction);
                    this.Is_SOH = rolePermissionDao.SetremovePermissionData(this.ETX, this.Is_SOH);
			
			}
		}
       private sealed class csDC3
		{
			public List<RoleInfo> lst_SOH;
			public RolePermissionsBusniess STX;
			public int ETX;
			public void SOH()
			{
				do
				{
					RolePermissionDao rolePermissionDao;
					rolePermissionDao = new RolePermissionDao(this.STX.Transaction);
                    this.lst_SOH = rolePermissionDao.GetChildUserData(this.ETX);
				}
				while (false);
			}
		}
      
        internal static SmartAssembly.Delegates.GetString  getRolePermissionBusniess;
        
        public List<PermissionRoleInfo> GetPermissionData(int RoleId)
        {
            var STX=RoleId;
            var SOH=this;
            List<PermissionRoleInfo> result;
            try
            {
                RolePermissionsBusniess.csSTX STX2 = new RolePermissionsBusniess.csSTX();
				
            STX2.STX= new List<PermissionRoleInfo>();
				
                    this.operation = new BaseBusiness.TransactionMethod(STX2.SOH);
					
                        base.Start(false);
                        result=STX2.STX;
				
				
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }
        public List<RoleInfo> GetRoleNames(int RoleId, string RoleName)
		{
			RolePermissionsBusniess.csETX ETX= new RolePermissionsBusniess.csETX();
			List<RoleInfo> result;
			do
			{
				ETX.STX = RoleId;
				if (!false)
				{
					ETX.ETX= RoleName;
					ETX.SOH= this;
					try
					{
						RolePermissionsBusniess.csEOT EOT = new RolePermissionsBusniess.csEOT();
						EOT.RolePermissionsBusniess_SOH=ETX;
						EOT.STX= new List<RoleInfo>();
						this.operation = new BaseBusiness.TransactionMethod(EOT.SOH);
						base.Start(false);
						
							result =EOT.STX;
						
					}
					catch (Exception)
					{
						do
						{
							result = null;
						}
						while (2 == 0);
					}
				}
			}
			while (3 == 0);
			return result;
		}		
        public List<PermissionInfo> GetPermissionNames(string PermissionId, string PermissionName)
		{
			RolePermissionsBusniess.csENQ ENQ = new RolePermissionsBusniess.csENQ ();
			List<PermissionInfo> result;
			do
			{
				ENQ.STX= PermissionId;
				if (!false)
				{
					ENQ.ETX= PermissionName;
					ENQ.SOH= this;
					try
					{
						RolePermissionsBusniess.csACK ACK= new RolePermissionsBusniess.csACK();
                        ACK.STX= new List<PermissionInfo>();
						this.operation = new BaseBusiness.TransactionMethod(ACK.SOH);
						base.Start(false);

                        result = ACK.STX;
						
					}
					catch (Exception)
					{
						do
						{
							result = null;
						}
						while (2 == 0);
					}
				}
			}
			while (3 == 0);
			return result;
		}
 public string AddUpdateRoleData(int RoleId, string RoleName, string SyncCode, int ParentRoleId)
		{
			BaseBusiness.TransactionMethod transactionMethod;
			while (true)
			{
				transactionMethod = null;
				int STX;
				while (true)
				{
				STX= RoleId;
					if (false)
					{
						break;
					}
					if (!false)
					{
						goto Block_1;
					}
				}
			}
			Block_1:
			csBEL BEL=new csBEL();
             BEL.ETX= RoleName;
		     BEL.EOT= SyncCode;
		     BEL.ENQ = ParentRoleId;
		     BEL.RolePermissionsBusniess_SOH= this;
			string result;
			try
			{
				new List<PermissionInfo>();
				if (transactionMethod == null)
				{
                    
					transactionMethod = new BaseBusiness.TransactionMethod(BEL.SOH);
				}
				this.operation = transactionMethod;
				base.Start(false);
                result = RolePermissionsBusniess.getRolePermissionBusniess(4398);
			}
			catch (Exception ex)
			{
				if (ex.InnerException.Message.Contains(RolePermissionsBusniess.getRolePermissionBusniess(4407)))
				{
					result = RolePermissionsBusniess.getRolePermissionBusniess(4436);
				}
				else
				{
					result = ex.Message;
				}
			}
			return result;
		}
       public bool DeleteRoleData(int RoleId)
		{
			csBS BS=new csBS ();
			BS.STX= RoleId;
			BS.SOH= this;
			bool result;
			try
			{
				RolePermissionsBusniess.csSO SO = new RolePermissionsBusniess.csSO();
				SO.RolePermissionsBusniess_SOH=BS;
               SO.STX = false;
				this.operation = new BaseBusiness.TransactionMethod(SO.SOH);
				bool arg_67_0 = base.Start(false);
				
					arg_67_0 =SO.STX;
				
				result = arg_67_0;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public string GetRoleName(int roleID)
		{
			RolePermissionsBusniess.csSI SI= new RolePermissionsBusniess.csSI();
			SI.ETX= roleID;
			SI.STX= this;
			SI.lst_SOH= new List<RoleInfo>();
			this.operation = new BaseBusiness.TransactionMethod(SI.SOH);
			base.Start(false);
			if (SI.lst_SOH!=null)
			{
				return SI.lst_SOH.FirstOrDefault<RoleInfo>().DG_User_Role;
			}
			return RolePermissionsBusniess.getRolePermissionBusniess(4449);
		}
        public bool SetPermissionData(int RoleId, int PermissonId)
		{
           csDLE DLE=new csDLE ();
			
			do
			{
				IL_25:
				DLE.Is_SOH= false;
				new PermissionRoleInfo();
				
			}
			while (3 == 0);
			this.operation = new BaseBusiness.TransactionMethod(DLE.SOH);
			base.Start(false);
			
		      DLE.STX= this;
		return DLE .Is_SOH;
		}

        	public bool RemovePermissionData(int RoleId, int PermissonId)
		{
			RolePermissionsBusniess.csDC1 DC1= new RolePermissionsBusniess.csDC1();
			if (!false)
			{
			DC1.ETX= RoleId;
				if (!false)
				{
				DC1.EOT= PermissonId;
				}
			}
			do
			{
				if (-1 != 0)
				{
					DC1.STX = this;
				}
				if (8 == 0)
				{
					goto IL_4B;
				}
				DC1.Is_SOH= false;
			}
			while (false);
			this.operation = new BaseBusiness.TransactionMethod(DC1.SOH);
			IL_4B:
			base.Start(false);
			return DC1.Is_SOH;
		}
        public bool SetremovePermissionData(DataTable udt_Permission)
		{
			RolePermissionsBusniess.csDC2 DC2= new RolePermissionsBusniess.csDC2();
			DC2.ETX = udt_Permission;
			DC2.STX= this;
		     DC2.Is_SOH= false;
			this.operation = new BaseBusiness.TransactionMethod(DC2.SOH);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 =DC2.Is_SOH;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}

		public List<RoleInfo> GetChildUserData(int UserId)
		{
			RolePermissionsBusniess.csDC3 DC3 = new RolePermissionsBusniess.csDC3();
		    DC3.ETX= UserId;
		    DC3.STX= this;
		    DC3.lst_SOH= new List<RoleInfo>();
			this.operation = new BaseBusiness.TransactionMethod(DC3.SOH);
			base.Start(false);
			return DC3.lst_SOH;
		}
        //static RolePermissionsBusniess()
        //{
        //    // Note: this type is marked as 'beforefieldinit'.
        //    SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(RolePermissionsBusniess));
        //}
	}
}
