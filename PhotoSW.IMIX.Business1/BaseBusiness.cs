
using System;
using PhotoSW.IMIX.DataAccess;
//using PhotoSW.IMIX.DataAccess;

namespace PhotoSW.IMIX.Business
{
    public class BaseBusiness
        {
        public delegate void TransactionMethod ();

        //  public bool test {get;set;}

        protected BaseBusiness.TransactionMethod operation;

        public BaseDataAccess m_Access;

        public BaseDataAccess Transaction
            {
            get
                {
                return this.m_Access;
                }
            }

        public BaseBusiness.TransactionMethod Operation
            {
            set
                {
                this.operation = value;
                }
            }

        public BaseBusiness ()
            {
            this.m_Access = new BaseDataAccess();
            }

        public BaseBusiness ( BaseDataAccess transaction )
            {
            this.m_Access = transaction;
            }
        private bool flag { get; set; }
        private void mAccess_OpenCon ()
            {
            if(this.m_Access != null)
                {
                this.m_Access.OpenConnection();
                }
            }

        private void mAccess_CloseCon ()
            {
            if(this.m_Access != null)
                {
                this.m_Access.CloseConnection();
                }
            }


        private void mAccess_BeginTransaction ()
            {
            if(this.m_Access != null)
                {
                this.m_Access.BeginTransaction();
                }
            }
        private void mAccess_CommitTransaction ()
            {
            if(this.m_Access != null)
                {
                this.m_Access.CommitTransaction();
                }
            }
        public virtual void ExecuteOperation ( bool isTransactionRequired )
            {
            try
                {
                //bool flag1 = this.flag;
                this.flag = isTransactionRequired;

                if(isTransactionRequired)
                    {
                    this.mAccess_BeginTransaction();
                   // this.mAccessBeginTransaction();
                    if(this.operation != null)
                        {
                        this.operation();
                        }
                    this.mAccess_CommitTransaction();
                   // this.mAccessCommitTransaction();
                    }
                else
                    {
                    this.mAccess_OpenCon();
                    if(this.operation != null)
                        {
                        this.operation();
                        }
                    }
                IL_2A:
                if(false)
                    {
                    goto IL_2A;
                    }
                }
            catch(Exception ex)
                {
                if (!false)
                {
                	//this.();
                	//ErrorHandler.ErrorHandler.LogError(ex);
                }
                throw ex;
                }
            finally
                {
                //	if (!false && !false)
                //	{
                //		this.();
                //	}
                }
            }

        public bool Start ( bool isTransactionRequired )
            {
            int arg_36_0 = 0;
            bool expr_39;
            do
                {
                bool flag = arg_36_0 != 0;
                try
                    {
                    while(!false)
                        {
                        this.ExecuteOperation(isTransactionRequired);
                        if(!false)
                            {
                            flag = true;
                            break;
                            }
                        }
                    }
                catch(Exception ex)
                    {
                    do
                        {
                       // ErrorHandler.ErrorHandler.LogError(ex);
                        }
                    while(5 == 0);
                    throw ex;
                    }
                expr_39 = ((arg_36_0 = (flag ? 1 : 0)) != 0);
                }
            while(3 == 0);
            return expr_39;
            }

      
      


    public void mAccessRollbackTransaction ()
		{
			if (flag)
			{
				//do
				//{
					if (this.m_Access != null)
					{
						this.m_Access.RollbackTransaction();
					}
					if (false)
					{
						return;
					}
				//}
				//while (false);
				//return;
			}
		}
	}
}
