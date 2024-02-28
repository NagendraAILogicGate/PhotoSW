using PhotoSW.IMIX.Model;
//using ErrorHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using PhotoSW.IMIX.Model;
using PhotoSW.IMIX.DataAccess;

namespace PhotoSW.IMIX.Business
{
    public class CustomBusineses : BaseBusiness
    {
        private sealed class CustomBusineses_SOH
        {
            public DateTime dtSOH;
            public CustomBusineses STX;
            public void SOH()
            {
                ValueTypeDao valueTypeDao = new ValueTypeDao(this.STX.Transaction);
                this.dtSOH = valueTypeDao.GetServerDateTime();
            }
        }

        private sealed class CustomBusineses_STX
        {
            public List<ServicesInfo> list_SOH;
            public CustomBusineses STX;
            public void SOH()
            {
                ServicesDao servicesDao = new ServicesDao(this.STX.Transaction);
                this.list_SOH = servicesDao.GetServices();

            }
        }
        private sealed class CustomBusineses_ETX
        {
            public ServicesInfo ServicesInfo_SOH;
            public CustomBusineses STX;

            public void m_SOH()
            {
                while (true)
                {
                    ServicesDao servicesDao = new ServicesDao(this.STX.Transaction);
                    servicesDao.AddServices(this.ServicesInfo_SOH);
                }
            }
            public void m_STX()
            {
                while (true)
                {
                    ServicesDao servicesDao = new ServicesDao(this.STX.Transaction);
                    servicesDao.AddServices(this.ServicesInfo_SOH);
                }
            }

            public void m_ETX()
            {
                while (true)
                {
                    ServicesDao servicesDao = new ServicesDao(this.STX.Transaction);
                    servicesDao.AddServices(this.ServicesInfo_SOH);
                }
            }
            public void m_EOT()
            {
                while (true)
                {
                    ServicesDao servicesDao = new ServicesDao(this.STX.Transaction);
                    servicesDao.AddServices(this.ServicesInfo_SOH);
                }
            }
            public void m_ENQ()
            {
                while (true)
                {
                    ServicesDao servicesDao = new ServicesDao(this.STX.Transaction);
                    servicesDao.AddServices(this.ServicesInfo_SOH);
                }
            }
            public void m_ACK()
            {
                while (true)
                {
                    ServicesDao servicesDao = new ServicesDao(this.STX.Transaction);
                    servicesDao.AddServices(this.ServicesInfo_SOH);
                }
            }
            public void m_BEL()
            {
                while (true)
                {
                    ServicesDao servicesDao = new ServicesDao(this.STX.Transaction);
                    servicesDao.AddServices(this.ServicesInfo_SOH);
                }
            }
            public void m_BS()
            {
                while (true)
                {
                    ServicesDao servicesDao = new ServicesDao(this.STX.Transaction);
                    servicesDao.AddServices(this.ServicesInfo_SOH);
                }
            }
            public void m_SO()
            {
                while (true)
                {
                    ServicesDao servicesDao = new ServicesDao(this.STX.Transaction);
                    servicesDao.AddServices(this.ServicesInfo_SOH);
                }
            }

            public void m_SI()
            {
                while (true)
                {
                    ServicesDao servicesDao = new ServicesDao(this.STX.Transaction);
                    servicesDao.AddServices(this.ServicesInfo_SOH);
                }
            }
            public void m_DLE()
            {
                while (true)
                {
                    ServicesDao servicesDao = new ServicesDao(this.STX.Transaction);
                    servicesDao.AddServices(this.ServicesInfo_SOH);
                }
            }

            public void m_DC1()
            {
                while (true)
                {
                    ServicesDao servicesDao = new ServicesDao(this.STX.Transaction);
                    servicesDao.AddServices(this.ServicesInfo_SOH);

                }
            }
        }
            internal static SmartAssembly.Delegates.GetString BEL;
            public DateTime ServerDateTime()
            {
                CustomBusineses STX;
                DateTime SOH=new DateTime ();

                CustomBusineses_SOH SOH2=new CustomBusineses_SOH ();
                do
                {
                   SOH2.STX   = this;
                } 
                while (false);
                SOH2.dtSOH  =DateTime.Now;
                do{
                    this.operation = new BaseBusiness.TransactionMethod(SOH2.SOH);
                   
                }while(2==0);
                 base.Start(false);

                 return SOH2.dtSOH;
             }

            public List<ServicesInfo> GetRunningServices()
            {
                List<ServicesInfo> result=null;
                try
                {
                    CustomBusineses.CustomBusineses_STX STX= new CustomBusineses_STX();
                    STX.STX = this;
                    STX.list_SOH = new List<ServicesInfo>();
                    this.operation = new BaseBusiness.TransactionMethod(STX.SOH);
                    base.Start(false);
                    result = STX.list_SOH;
                }
                catch
                {
                    return result;
                }
                return result;
            }
            private bool m_SOH(string STX, List<ServicesInfo> ETX)
            {
                bool result;
                result = false;
                    List<ServicesInfo>.Enumerator enumerator = ETX.GetEnumerator();
                try
                {
                    
                    while (true)
                    {
                        int arg_2E_0;
                        bool expr_33 = (arg_2E_0 = (enumerator.MoveNext() ? 1 : 0)) != 0;
                        ServicesInfo current=null;
					
                        if (!(current.DG_Sevice_Name == STX))
						{
							continue;
						}
                        current = enumerator.Current;
                        result = (arg_2E_0 != 0);
                        return result;
                    }
                }
                catch
                {
                    return result;
                }
                finally
                {
                    do
					{
						((IDisposable)enumerator).Dispose();
					}
					while (3 == 0);
                }
            }
          

            public bool setServicePathForApplication(string directoryPath)
            {
                bool result;
                try
                {
                    BaseBusiness.TransactionMethod transactionMethod = null;
                    BaseBusiness.TransactionMethod transactionMethod2 = null;
                    BaseBusiness.TransactionMethod transactionMethod3 = null;
                    BaseBusiness.TransactionMethod transactionMethod4 = null;
                    BaseBusiness.TransactionMethod transactionMethod5 = null;
                    BaseBusiness.TransactionMethod transactionMethod6 = null;
                    BaseBusiness.TransactionMethod transactionMethod7 = null;
                    BaseBusiness.TransactionMethod transactionMethod8 = null;
                    BaseBusiness.TransactionMethod transactionMethod9 = null;
                    BaseBusiness.TransactionMethod transactionMethod10 = null;
                    BaseBusiness.TransactionMethod transactionMethod11 = null;
                    BaseBusiness.TransactionMethod transactionMethod12 = null;
                    CustomBusineses.CustomBusineses_ETX ETX=new CustomBusineses_ETX ();
                    ETX.STX=this;
                  
                    List<ServicesInfo> runningServices = this.GetRunningServices();
                    if(!this.m_SOH(CustomBusineses.BEL(1566),runningServices))
                    {
                        ETX.ServicesInfo_SOH=new ServicesInfo ();
                        ETX.ServicesInfo_SOH.DG_Service_Display_Name=CustomBusineses.BEL(1583);
                        ETX.ServicesInfo_SOH.DG_Service_Path=directoryPath +CustomBusineses.BEL(1600);
                        ETX.ServicesInfo_SOH.DG_Sevice_Name=CustomBusineses.BEL(1566);
                        ETX.ServicesInfo_SOH.IsService =false;
                        ETX.ServicesInfo_SOH.RunLevel = 2L;
                        ETX.ServicesInfo_SOH.IsInterface = new bool ?(true);
                         if (transactionMethod == null)
                         {
                             transactionMethod=new BaseBusiness.TransactionMethod(ETX.m_SOH);
                         }
                        this.operation=transactionMethod;
                        base.Start(false);
                    }
                    if(!this.m_SOH(CustomBusineses.BEL(1625),runningServices))
                    {
                        ETX.ServicesInfo_SOH=new ServicesInfo ();
                        ETX.ServicesInfo_SOH.DG_Service_Display_Name=CustomBusineses.BEL(1654);
                        ETX.ServicesInfo_SOH.DG_Service_Path=directoryPath +CustomBusineses.BEL(1695);
                        ETX.ServicesInfo_SOH.DG_Sevice_Name=CustomBusineses.BEL(1625);
                        
                        ETX.ServicesInfo_SOH.RunLevel = 2L;
                        ETX.ServicesInfo_SOH.IsService=false;
                        ETX.ServicesInfo_SOH.IsInterface = new bool ?(true);
                         if (transactionMethod2 == null)
                         {
                             transactionMethod2=new BaseBusiness.TransactionMethod(ETX.m_STX);
                         }
                        this.operation=transactionMethod2;
                        base.Start(false);
                    }
                  

                      if(!this.m_SOH(CustomBusineses.BEL(1728),runningServices))
                    {
                        ETX.ServicesInfo_SOH=new ServicesInfo ();
                        ETX.ServicesInfo_SOH.DG_Service_Display_Name=CustomBusineses.BEL(1761);
                        ETX.ServicesInfo_SOH.DG_Service_Path=directoryPath +CustomBusineses.BEL(1798);
                        ETX.ServicesInfo_SOH.DG_Sevice_Name=CustomBusineses.BEL(1728);
                        
                        ETX.ServicesInfo_SOH.RunLevel = 2L;
                        ETX.ServicesInfo_SOH.IsService=true;
                        ETX.ServicesInfo_SOH.IsInterface = new bool ?(false);
                         if (transactionMethod3 == null)
                         {
                             transactionMethod3=new BaseBusiness.TransactionMethod(ETX.m_ETX);
                         }
                        this.operation=transactionMethod3;
                        base.Start(false);
                    }
                        if(!this.m_SOH(CustomBusineses.BEL(1839),runningServices))
                    {
                        ETX.ServicesInfo_SOH=new ServicesInfo ();
                        ETX.ServicesInfo_SOH.DG_Service_Display_Name=CustomBusineses.BEL(1864);
                        ETX.ServicesInfo_SOH.DG_Service_Path=directoryPath +CustomBusineses.BEL(1889);
                        ETX.ServicesInfo_SOH.DG_Sevice_Name=CustomBusineses.BEL(1839);
                        
                        ETX.ServicesInfo_SOH.RunLevel = 1L;
                        ETX.ServicesInfo_SOH.IsService=true;
                        ETX.ServicesInfo_SOH.IsInterface = new bool ?(false);
                         if (transactionMethod4 == null)
                         {
                             transactionMethod4=new BaseBusiness.TransactionMethod(ETX.m_EOT);
                         }
                        this.operation=transactionMethod4;
                        base.Start(false);
                    }
                    
                        if(!this.m_SOH(CustomBusineses.BEL(1914),runningServices))
                    {
                        ETX.ServicesInfo_SOH=new ServicesInfo ();
                        ETX.ServicesInfo_SOH.DG_Service_Display_Name=CustomBusineses.BEL(1914);
                        ETX.ServicesInfo_SOH.DG_Service_Path=directoryPath +CustomBusineses.BEL(1939);
                        ETX.ServicesInfo_SOH.DG_Sevice_Name=CustomBusineses.BEL(1914);
                        
                        ETX.ServicesInfo_SOH.RunLevel = 1L;
                        ETX.ServicesInfo_SOH.IsService=true;
                        ETX.ServicesInfo_SOH.IsInterface = new bool ?(false);
                         if (transactionMethod5 == null)
                         {
                             transactionMethod5=new BaseBusiness.TransactionMethod(ETX.m_ENQ);
                         }
                        this.operation=transactionMethod5;
                        base.Start(false);
                    }
                        if(!this.m_SOH(CustomBusineses.BEL(1972),runningServices))
                    {
                        ETX.ServicesInfo_SOH=new ServicesInfo ();
                        ETX.ServicesInfo_SOH.DG_Service_Display_Name=CustomBusineses.BEL(1972);
                        ETX.ServicesInfo_SOH.DG_Service_Path=directoryPath +CustomBusineses.BEL(2005);
                        ETX.ServicesInfo_SOH.DG_Sevice_Name=CustomBusineses.BEL(1972);
                        
                        ETX.ServicesInfo_SOH.RunLevel = 1L;
                        ETX.ServicesInfo_SOH.IsService=true;
                        ETX.ServicesInfo_SOH.IsInterface = new bool ?(false);
                         if (transactionMethod6 == null)
                         {
                             transactionMethod6=new BaseBusiness.TransactionMethod(ETX.m_ACK);
                         }
                        this.operation=transactionMethod6;
                        base.Start(false);
                    }
                          if(!this.m_SOH(CustomBusineses.BEL(2038),runningServices))
                    {
                        ETX.ServicesInfo_SOH=new ServicesInfo ();
                        ETX.ServicesInfo_SOH.DG_Service_Display_Name=CustomBusineses.BEL(2038);
                        ETX.ServicesInfo_SOH.DG_Service_Path=directoryPath +CustomBusineses.BEL(2075);
                        ETX.ServicesInfo_SOH.DG_Sevice_Name=CustomBusineses.BEL(2038);
                        
                        ETX.ServicesInfo_SOH.RunLevel = 1L;
                        ETX.ServicesInfo_SOH.IsService=true;
                        ETX.ServicesInfo_SOH.IsInterface = new bool ?(false);
                         if (transactionMethod7 == null)
                         {
                             transactionMethod7=new BaseBusiness.TransactionMethod(ETX.m_BEL);
                         }
                        this.operation=transactionMethod7;
                        base.Start(false);
                    }
                   if(!this.m_SOH(CustomBusineses.BEL(2120),runningServices))
                    {
                        ETX.ServicesInfo_SOH=new ServicesInfo ();
                        ETX.ServicesInfo_SOH.DG_Service_Display_Name=CustomBusineses.BEL(2120);
                        ETX.ServicesInfo_SOH.DG_Service_Path=directoryPath +CustomBusineses.BEL(2141);
                        ETX.ServicesInfo_SOH.DG_Sevice_Name=CustomBusineses.BEL(2120);
                        
                        ETX.ServicesInfo_SOH.RunLevel = 2L;
                        ETX.ServicesInfo_SOH.IsService=true;
                        ETX.ServicesInfo_SOH.IsInterface = new bool ?(false);
                         if (transactionMethod8 == null)
                         {
                             transactionMethod8=new BaseBusiness.TransactionMethod(ETX.m_BS);
                         }
                        this.operation=transactionMethod8;
                        base.Start(false);
                    }
                    if(!this.m_SOH(CustomBusineses.BEL(2170),runningServices))
                    {
                        ETX.ServicesInfo_SOH=new ServicesInfo ();
                        ETX.ServicesInfo_SOH.DG_Service_Display_Name=CustomBusineses.BEL(2170);
                        ETX.ServicesInfo_SOH.DG_Service_Path=directoryPath +CustomBusineses.BEL(2195);
                        ETX.ServicesInfo_SOH.DG_Sevice_Name=CustomBusineses.BEL(2170);
                        
                        ETX.ServicesInfo_SOH.RunLevel = 1L;
                        ETX.ServicesInfo_SOH.IsService=true;
                        ETX.ServicesInfo_SOH.IsInterface = new bool ?(false);
                         if (transactionMethod9 == null)
                         {
                             transactionMethod9=new BaseBusiness.TransactionMethod(ETX.m_SO);
                         }
                        this.operation=transactionMethod9;
                        base.Start(false);
                    }
                     if(!this.m_SOH(CustomBusineses.BEL(2224),runningServices))
                    {
                        ETX.ServicesInfo_SOH=new ServicesInfo ();
                        ETX.ServicesInfo_SOH.DG_Service_Display_Name=CustomBusineses.BEL(2224);
                        ETX.ServicesInfo_SOH.DG_Service_Path=directoryPath +CustomBusineses.BEL(2257);
                        ETX.ServicesInfo_SOH.DG_Sevice_Name=CustomBusineses.BEL(2224);
                        
                        ETX.ServicesInfo_SOH.RunLevel = 2L;
                        ETX.ServicesInfo_SOH.IsService=true;
                        ETX.ServicesInfo_SOH.IsInterface = new bool ?(false);
                         if (transactionMethod10 == null)
                         {
                             transactionMethod10=new BaseBusiness.TransactionMethod(ETX.m_SI);
                         }
                        this.operation=transactionMethod10;
                        base.Start(false);
                    }
                     if(!this.m_SOH(CustomBusineses.BEL(2294),runningServices))
                    {
                        ETX.ServicesInfo_SOH=new ServicesInfo ();
                        ETX.ServicesInfo_SOH.DG_Service_Display_Name=CustomBusineses.BEL(2294);
                        ETX.ServicesInfo_SOH.DG_Service_Path=directoryPath +CustomBusineses.BEL(2323);
                        ETX.ServicesInfo_SOH.DG_Sevice_Name=CustomBusineses.BEL(2294);
                        
                        ETX.ServicesInfo_SOH.RunLevel = 2L;
                        ETX.ServicesInfo_SOH.IsService=false;
                        ETX.ServicesInfo_SOH.IsInterface = new bool ?(false);
                         if (transactionMethod11 == null)
                         {
                             transactionMethod11=new BaseBusiness.TransactionMethod(ETX.m_DLE);
                         }
                        this.operation=transactionMethod11;
                        base.Start(false);
                    }
                     if(!this.m_SOH(CustomBusineses.BEL(2360),runningServices))
                    {
                        ETX.ServicesInfo_SOH=new ServicesInfo ();
                        ETX.ServicesInfo_SOH.DG_Service_Display_Name=CustomBusineses.BEL(2360);
                        ETX.ServicesInfo_SOH.DG_Service_Path=directoryPath +CustomBusineses.BEL(2393);
                        ETX.ServicesInfo_SOH.DG_Sevice_Name=CustomBusineses.BEL(2360);
                        
                        ETX.ServicesInfo_SOH.RunLevel = 1L;
                        ETX.ServicesInfo_SOH.IsService=true;
                        ETX.ServicesInfo_SOH.IsInterface = new bool ?(false);
                         if (transactionMethod12 == null)
                         {
                             transactionMethod12=new BaseBusiness.TransactionMethod(ETX.m_DC1);
                         }
                        this.operation=transactionMethod12;
                        base.Start(false);
                    }
                
                    result = true;
                }
                catch (Exception serviceException)
                {
                    string message = "";//ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    //ErrorHandler.ErrorHandler.LogFileWrite(message);
                    result = false;
                }
                return result;
            }

            static CustomBusineses()
            {
                // Note: this type is marked as 'beforefieldinit'.
                SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(CustomBusineses));
            }
       
    }
}
