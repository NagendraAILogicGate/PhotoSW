using PhotoSW.IMIX.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
    {
    public class BaseBusiness
	{
		public delegate void TransactionMethod();

        private bool SOH;

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

		public BaseBusiness()
		{
			this.m_Access = new BaseDataAccess();
		}

		public BaseBusiness(BaseDataAccess transaction)
		{
			this.m_Access = transaction;
		}

        public virtual void ExecuteOperation(bool isTransactionRequired)
        {
        try
            {
            this.SOH = isTransactionRequired;
            if(isTransactionRequired)
                {
                this.mETX();
                if(this.operation != null)
                    {
                    this.operation();
                    }
                this.mEOT();
                }
            else
                {
                this.mSOH();
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
            if(!false)
                {
                this.mENQ();
                ErrorHandler.ErrorHandler.LogError(ex);
                }
            throw ex;
            }
        finally
            {
            if(!false && !false)
                {
                this.mSTX();
                }
            }
        }

		public bool Start(bool isTransactionRequired)
		{
			int arg_36_0 = 0;
			bool expr_39;
			do
			{
				bool flag = arg_36_0 != 0;
				try
				{
					while (!false)
					{
						this.ExecuteOperation(isTransactionRequired);
						if (!false)
						{
							flag = true;
							break;
						}
					}
				}
				catch (Exception ex)
				{
					do
					{
						ErrorHandler.ErrorHandler.LogError(ex);
					}
					while (5 == 0);
					throw ex;
				}
				expr_39 = ((arg_36_0 = (flag ? 1 : 0)) != 0);
			}
			while (3 == 0);
			return expr_39;
		}
        private void mSOH()
		{
			if (this.m_Access != null)
			{
				this.m_Access.OpenConnection();
			}
		}

		private void mSTX()
		{
			if (this.m_Access != null)
			{
				this.m_Access.CloseConnection();
			}
		}

		private void mETX()
		{
			if (this.m_Access != null)
			{
				this.m_Access.BeginTransaction();
			}
		}

		private void mEOT()
		{
			if (this.m_Access != null)
			{
				this.m_Access.CommitTransaction();
			}
		}

		private void mENQ()
		{
			if (!true || (!false && this.SOH))
			{
				do
				{
					if (this.m_Access != null)
					{
						this.m_Access.RollbackTransaction();
					}
					if (false)
					{
						return;
					}
				}
				while (false);
				return;
			}
		}
    }
    }
