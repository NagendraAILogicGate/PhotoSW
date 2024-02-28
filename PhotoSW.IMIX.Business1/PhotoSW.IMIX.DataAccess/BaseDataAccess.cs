using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;



namespace PhotoSW.IMIX.DataAccess
    {
    public class BaseDataAccess
        {
        private SqlConnection sqlCon;

		private SqlCommand sqlCom;

		private SqlTransaction sqlTransaction;

		private SqlDataAdapter sqlDA;

		[CompilerGenerated]
        private List<SqlParameter> sqlParam;

		//[NonSerialized]
  //      internal static SmartAssembly.Delegates.GetString ;

		public List<SqlParameter> DBParameters
            {
            get;
            set;
            }

        public string MyConString
            {
            get
                {
                return "";     //ConfigurationManager.ConnectionStrings[BaseDataAccess.(158)].ConnectionString;
                }
            }

        public SqlTransaction Transaction
            {
            get
                {
                return this.sqlTransaction;
			}
            }

        public BaseDataAccess ()
            {
            this.DBParameters = new List<SqlParameter>();
            }

        public BaseDataAccess ( BaseDataAccess baseAccess )
            {
            this.DBParameters = new List<SqlParameter>();
            this.sqlCon = baseAccess.sqlCon;
			this.sqlTransaction = baseAccess.sqlTransaction;
			this.sqlDA = baseAccess.sqlDA;
		}

        protected DataSet ExecuteDataSet ( string spName )
            {
            DataSet result;
            try
                {
                DataSet dataSet = new DataSet();
                this.sqlCom = this.sqlCon.CreateCommand();
				this.sqlCom.CommandTimeout = 180;
				if(!false)
                    {
                    this.sqlCom.CommandText = spName;
				}
                this.sqlCom.CommandType = CommandType.StoredProcedure;
				if(this.DBParameters != null)
                    {
                    this.sqlCom.Parameters.AddRange(this.DBParameters.ToArray());
				}
                if(this.sqlDA == null)
				{
                    this.sqlDA = new SqlDataAdapter();
				}
                this.sqlDA.SelectCommand = this.sqlCom;
				this.sqlDA.Fill(dataSet);
				result = dataSet;
                }
            catch(Exception ex)
                {
               //ErrorHandler.LogError(ex);
                throw ex;
                }
            return result;
            }

        protected IDataReader ExecuteReader ( string spName )
            {
            IDataReader result;
            try
                {
                if(-1 != 0)
                    {
                    this.sqlCom = this.sqlCon.CreateCommand();
					do
                        {
                        this.sqlCom.CommandTimeout = 180;
					}
                    while(3 == 0);
                    this.sqlCom.CommandText = spName;
					this.sqlCom.CommandType = CommandType.StoredProcedure;
					if(!false && this.DBParameters != null)
                        {
                        this.sqlCom.Parameters.AddRange(this.DBParameters.ToArray());
					}
                    }
                result = this.sqlCom.ExecuteReader(CommandBehavior.CloseConnection);
			}
            catch(Exception serviceException)
                {
                //if(3 != 0)
                //    {
                //    ErrorHandler.LogError(serviceException);
                //    }
                    throw serviceException;
                }
            return result;
            }

        protected object ExecuteScalar ( string spName )
            {
            object result;
            try
                {
                this.sqlCom = this.sqlCon.CreateCommand();
				this.sqlCom.CommandText = spName;
				this.sqlCom.CommandTimeout = 120;
				this.sqlCom.CommandType = CommandType.StoredProcedure;
				if(this.DBParameters != null)
                    {
                    this.sqlCom.Parameters.AddRange(this.DBParameters.ToArray());
				}
                result = this.sqlCom.ExecuteScalar();
			}
            catch(Exception ex)
                {
              //  ErrorHandler.LogError(ex);
                throw ex;
                }
            return result;
            }

        protected object ExecuteNonQuery ( string spName )
            {
            object result;
            try
                {
                this.sqlCom = this.sqlCon.CreateCommand();
				this.sqlCom.CommandText = spName;
				this.sqlCom.CommandTimeout = 120;
				this.sqlCom.CommandType = CommandType.StoredProcedure;
				if(this.DBParameters != null)
                    {
                    this.sqlCom.Parameters.AddRange(this.DBParameters.ToArray());
				}
                result = this.sqlCom.ExecuteNonQuery();
			}
            catch(Exception ex)
                {
              //  ErrorHandler.LogError(ex);
                throw ex;
                }
            return result;
            }

        protected object ExecuteNonQueryWithSqlDependency ( string spName )
            {
            object result;
            try
                {
                SqlDependency.Stop(this.MyConString);
                SqlDependency.Start(this.MyConString);
                this.sqlCom = this.sqlCon.CreateCommand();
				this.sqlCom.CommandText = spName;
				SqlDependency sqlDependency;
                do
                    {
                    this.sqlCom.CommandTimeout = 120;
					this.sqlCom.CommandType = CommandType.StoredProcedure;
					if(this.DBParameters != null)
                        {
                        this.sqlCom.Parameters.AddRange(this.DBParameters.ToArray());
					}
                    this.sqlCom.Notification = null;
					sqlDependency = new SqlDependency(this.sqlCom);
				}
                while(6 == 0);
                sqlDependency.OnChange += new OnChangeEventHandler(this.OnChange);
                result = this.sqlCom.ExecuteNonQuery();
			}
            catch(Exception ex)
                {
              //  ErrorHandler.LogError(ex);
                throw ex;
                }
            return result;
            }

        public void OnChange ( object sender, SqlNotificationEventArgs e )
            {
            }

        protected void AddParameter ( string name, object value )
            {
            this.DBParameters.Add(new SqlParameter(name, value));
            }

        protected void AddParameter ( string name, object value, ParameterDirection direction )
            {
            while(true)
                {
                SqlParameter sqlParameter = new SqlParameter(name, value);
                while(true)
                    {
                    sqlParameter.Direction = direction;
                    if(false)
                        {
                        break;
                        }
                    this.DBParameters.Add(sqlParameter);
                    if(!false)
                        {
                        return;
                        }
                    }
                }
            }

        protected void AddOutParameter ( string name, SqlDbType dbType )
            {
            while(true)
                {
                SqlParameter sqlParameter = new SqlParameter(name, dbType);
                while(true)
                    {
                    sqlParameter.Direction = ParameterDirection.Output;
                    if(false)
                        {
                        break;
                        }
                    this.DBParameters.Add(sqlParameter);
                    if(!false)
                        {
                        return;
                        }
                    }
                }
            }

        protected void AddOutParameterString ( string name, SqlDbType dbType, int size )
            {
            SqlParameter sqlParameter;
            if(!false)
                {
                SqlParameter expr_31 = new SqlParameter(name, dbType, size);
                if(5 != 0)
                    {
                    sqlParameter = expr_31;
                    }
                }
            do
                {
                sqlParameter.Direction = ParameterDirection.Output;
                if(!false)
                    {
                    if(false)
                        {
                        continue;
                        }
                    this.DBParameters.Add(sqlParameter);
                    }
                }
            while(false);
            }

        protected object GetOutParameterValue ( string parameterName )
            {
            if(this.sqlCom != null)
			{
                return this.sqlCom.Parameters[parameterName].Value;
			}
            return null;
            }

        protected bool SaveData ( string spName )
            {
            bool result;
            try
                {
                if(3 == 0)
                    {
                    goto IL_7F;
                    }
                this.sqlCom = this.sqlCon.CreateCommand();
				this.sqlCom.CommandTimeout = 180;
				this.sqlCom.CommandText = spName;
				this.sqlCom.CommandType = CommandType.StoredProcedure;
				this.sqlCom.Parameters.AddRange(this.DBParameters.ToArray());
				IL_6F:
				int num = this.sqlCom.ExecuteNonQuery();
				if(num <= 0)
                    {
                    goto IL_89;
                    }
                IL_7F:
                if(8 != 0)
                    {
                    if(3 == 0)
                        {
                        goto IL_89;
                        }
                    result = true;
                    }
                return result;
                IL_89:
                if(false)
                    {
                    goto IL_6F;
                    }
                result = false;
                }
            catch(Exception ex)
                {
                //if(5 != 0)
                //    {
                //    ErrorHandler.LogError(ex);
                //    }
                throw ex;
                }
            return result;
            }

        public bool BeginTransaction ()
            {
            try
                {
                if(2 != 0)
                    {
                    bool flag = this.OpenConnection();
                    if(!false && flag)
                        {
                        this.sqlTransaction = this.sqlCon.BeginTransaction();
					}
                    }
                }
            catch(Exception ex)
                {
                if(7 != 0 && 3 != 0)
                    {
                    this.CloseConnection();
                    }
              //  ErrorHandler.LogError(ex);
                throw ex;
                }
            return true;
            }

        public bool CommitTransaction ()
            {
            try
                {
                this.sqlTransaction.Commit();
			}
            catch(Exception ex)
                {
              //  ErrorHandler.LogError(ex);
                throw ex;
                }
            finally
                {
                this.CloseConnection();
                }
            return true;
            }

        public void RollbackTransaction ()
            {
            try
                {
                do
                    {
                    DbTransaction expr_02 = this.sqlTransaction;
					if(7 != 0)
                        {
                        expr_02.Rollback();
                        }
                    }
                while(8 == 0);
                }
            catch(Exception ex)
                {
                //do
                //    {
                //    if(2 != 0)
                //        {
                //        ErrorHandler.LogError(ex);
                //        }
                //    }
                //while(false);
                throw ex;
                }
            finally
                {
                if(7 != 0)
                    {
                    this.CloseConnection();
                    }
                }
            }

        public bool OpenConnection ()
            {
            try
                {
                if(this.sqlCon == null)
				{
                    this.sqlCon = new SqlConnection(this.MyConString);
				}
                if(this.sqlCon.State != ConnectionState.Open)
				{
                    this.sqlCon.Open();
				}
                }
            catch(Exception ex)
                {
                //do
                //    {
                //    ErrorHandler.LogError(ex);
                //    }
                //while(-1 == 0);
                throw ex;
                }
            return true;
            }

        public bool CloseConnection ()
            {
            try
                {
                while(true)
                    {
                    if(this.sqlCon.State == ConnectionState.Closed)
					{
                        goto IL_17;
                        }
                    IL_0B:
                    if(!true)
                        {
                        continue;
                        }
                    this.sqlCon.Close();
					IL_17:
					if(!false)
                        {
                        break;
                        }
                    goto IL_0B;
                    }
                }
            catch(Exception ex)
                {
                //do
                //    {
                //    if(!false)
                //        {
                //        ErrorHandler.LogError(ex);
                //        }
                //    }
                //while(false || 8 == 0);
                throw ex;
                }
            finally
                {
                if(this.sqlCon != null)
				{
                    this.sqlCon.Dispose();
					this.sqlCon = null;
				}
                }
            return true;
            }

        protected long GetFieldValue ( IDataReader sqlReader, string fieldName, long defaultValue )
            {
            int ordinal;
            do
                {
                ordinal = sqlReader.GetOrdinal(fieldName);
                if(sqlReader.IsDBNull(ordinal) && !false)
                    {
                    goto Block_1;
                    }
                }
            while(false);
            long arg_1C_0 = sqlReader.GetInt64(ordinal);
            return arg_1C_0;
            Block_1:
            long expr_21 = arg_1C_0 = 0L;
            if(8 != 0 && !false)
                {
                return expr_21;
                }
            return arg_1C_0;
            }

        protected int GetFieldValue ( IDataReader sqlReader, string fieldName, int defaultValue )
            {
            int arg_26_0;
            if(4 != 0)
                {
                int expr_2D = sqlReader.GetOrdinal(fieldName);
                int i;
                if(!false)
                    {
                    i = expr_2D;
                    }
                do
                    {
                    bool expr_3D = (arg_26_0 = (sqlReader.IsDBNull(i) ? 1 : 0)) != 0;
                    if(false)
                        {
                        return arg_26_0;
                        }
                    if(expr_3D)
                        {
                        goto IL_25;
                        }
                    }
                while(false);
                return sqlReader.GetInt32(i);
                }
            IL_25:
            arg_26_0 = 0;
            return arg_26_0;
            }

        protected int? GetFieldValueIntNull ( IDataReader sqlReader, string fieldName, int defaultValue )
            {
            int arg_42_0 = sqlReader.GetOrdinal(fieldName);
            int arg_1F_0;
            do
                {
                int i = arg_42_0;
                bool expr_4B = (arg_1F_0 = (arg_42_0 = (sqlReader.IsDBNull(i) ? 1 : 0))) != 0;
                if(-1 != 0)
                    {
                    if(expr_4B && !false && !false)
                        {
                        goto Block_4;
                        }
                    arg_42_0 = (arg_1F_0 = sqlReader.GetInt32(i));
                    }
                }
            while(!true);
            return new int?(arg_1F_0);
            Block_4:
            return null;
            }

        protected float GetFieldValue ( IDataReader sqlReader, string fieldName, float defaultValue )
            {
            int ordinal;
            do
                {
                ordinal = sqlReader.GetOrdinal(fieldName);
                if(sqlReader.IsDBNull(ordinal))
                    {
                    goto IL_21;
                    }
                }
            while(false);
            double arg_1C_0 = sqlReader.GetDouble(ordinal);
            IL_1C:
            float arg_2C_0;
            float arg_20_0 = (float)(arg_1C_0 = (double)(arg_2C_0 = (float)arg_1C_0));
            IL_1D:
            if(!false)
                {
                return arg_20_0;
                }
            goto IL_26;
            IL_21:
            arg_20_0 = (float)(arg_1C_0 = (double)(arg_2C_0 = 0f));
            IL_26:
            if(8 == 0)
                {
                goto IL_1D;
                }
            if(!false)
                {
                return arg_2C_0;
                }
            goto IL_1C;
            }

        protected double GetFieldValue ( IDataReader sqlReader, string fieldName, double defaultValue )
            {
            if(4 != 0)
                {
                int arg_3C_0 = sqlReader.GetOrdinal(fieldName);
                int i;
                while(true)
                    {
                    if(!false)
                        {
                        i = arg_3C_0;
                        }
                    while(true)
                        {
                        bool expr_45 = (arg_3C_0 = (sqlReader.IsDBNull(i) ? 1 : 0)) != 0;
                        if(false)
                            {
                            break;
                            }
                        if(expr_45)
                            {
                            goto IL_25;
                            }
                        if(!false)
                            {
                            goto Block_4;
                            }
                        }
                    }
                Block_4:
                return sqlReader.GetDouble(i);
                }
            IL_25:
            return 0.0;
            }

        protected decimal GetFieldValue ( IDataReader sqlReader, string fieldName, decimal defaultValue )
            {
            int ordinal;
            do
                {
                ordinal = sqlReader.GetOrdinal(fieldName);
                if(sqlReader.IsDBNull(ordinal))
                    {
                    goto IL_1D;
                    }
                }
            while(false);
            return sqlReader.GetDecimal(ordinal);
            IL_1D:
            return 0m;
            }

        protected string GetFieldValue ( IDataReader sqlReader, string fieldName, string defaultValue )
            {
            if(4 != 0)
                {
                int arg_38_0 = sqlReader.GetOrdinal(fieldName);
                int i;
                while(true)
                    {
                    if(!false)
                        {
                        i = arg_38_0;
                        }
                    while(true)
                        {
                        bool expr_41 = (arg_38_0 = (sqlReader.IsDBNull(i) ? 1 : 0)) != 0;
                        if(false)
                            {
                            break;
                            }
                        if(expr_41)
                            {
                            goto IL_25;
                            }
                        if(!false)
                            {
                            goto Block_4;
                            }
                        }
                    }
                Block_4:
                return sqlReader.GetString(i);
                }
            IL_25:
            return string.Empty;
            }

        protected DateTime GetFieldValue ( IDataReader sqlReader, string fieldName, DateTime defaultValue )
            {
            int ordinal;
            DateTime result;
            do
                {
                ordinal = sqlReader.GetOrdinal(fieldName);
                if(sqlReader.IsDBNull(ordinal))
                    {
                    goto IL_20;
                    }
                if(3 == 0)
                    {
                    return result;
                    }
                }
            while(false);
            return sqlReader.GetDateTime(ordinal);
            IL_20:
            result = default(DateTime);
            return result;
            }

        protected DateTime? GetFieldValueDateTimeNull ( IDataReader sqlReader, string fieldName, DateTime defaultValue )
            {
            if(false)
                {
                goto IL_27;
                }
            int arg_44_0 = sqlReader.GetOrdinal(fieldName);
            int i;
            bool expr_4D;
            do
                {
                if(7 != 0)
                    {
                    i = arg_44_0;
                    }
                expr_4D = ((arg_44_0 = (sqlReader.IsDBNull(i) ? 1 : 0)) != 0);
                }
            while(-1 == 0);
            if(expr_4D)
                {
                goto IL_27;
                }
            IL_18:
            return new DateTime?(sqlReader.GetDateTime(i));
            IL_27:
            if(!false && !false)
                {
                return null;
                }
            goto IL_18;
            }

        protected DateTime GetFieldValue ( IDataReader sqlReader, string fieldName, DateTime? defaultValue )
            {
            int ordinal;
            DateTime result;
            do
                {
                ordinal = sqlReader.GetOrdinal(fieldName);
                if(sqlReader.IsDBNull(ordinal))
                    {
                    goto IL_20;
                    }
                if(3 == 0)
                    {
                    return result;
                    }
                }
            while(false);
            return sqlReader.GetDateTime(ordinal);
            IL_20:
            result = default(DateTime);
            return result;
            }

        protected bool GetFieldValue ( IDataReader sqlReader, string fieldName, bool defaultValue )
            {
            int arg_26_0;
            if(4 != 0)
                {
                int expr_2D = sqlReader.GetOrdinal(fieldName);
                int i;
                if(!false)
                    {
                    i = expr_2D;
                    }
                do
                    {
                    bool expr_3D = (arg_26_0 = (sqlReader.IsDBNull(i) ? 1 : 0)) != 0;
                    if(false)
                        {
                        return arg_26_0 != 0;
                        }
                    if(expr_3D)
                        {
                        goto IL_25;
                        }
                    }
                while(false);
                return sqlReader.GetBoolean(i);
                }
            IL_25:
            arg_26_0 = 0;
            return arg_26_0 != 0;
            }

        protected object SetNullIntegerValue ( int? value )
            {
            int? num;
            while(true)
                {
                num = value;
                if(false)
                    {
                    goto IL_35;
                    }
                if(num.GetValueOrDefault() == -1)
                    {
                    break;
                    }
                if(!false)
                    {
                    goto Block_1;
                    }
                }
            IL_1A:
            int arg_27_0 = num.HasValue ? 1 : 0;
            goto IL_27;
            Block_1:
            arg_27_0 = 0;
            IL_27:
            if(arg_27_0 != 0)
                {
                goto IL_4A;
                }
            int? expr_87 = value;
            int? num2;
            if(true)
                {
                num2 = expr_87;
                }
            IL_2F:
            bool arg_3F_0;
            if(num2.GetValueOrDefault() != 0)
                {
                arg_3F_0 = false;
                goto IL_3F;
                }
            IL_35:
            arg_3F_0 = ((arg_27_0 = (num2.HasValue ? 1 : 0)) != 0);
            if(false)
                {
                goto IL_27;
                }
            IL_3F:
            object result;
            if(!arg_3F_0 && value.HasValue)
                {
                result = value;
                return result;
                }
            IL_4A:
            if(5 == 0)
                {
                goto IL_2F;
                }
            if(false)
                {
                goto IL_1A;
                }
            result = DBNull.Value;
            return result;
            }

        protected object SetNullLongValue ( long? value )
            {
            if(4 == 0)
                {
                goto IL_3F;
                }
            object result = null;
            if(4 == 0)
                {
                goto IL_45;
                }
            long? num = value;
            bool arg_2B_0;
            if(num.GetValueOrDefault() == -1L)
                {
                if(false)
                    {
                    return result;
                    }
                arg_2B_0 = num.HasValue;
                }
            else
                {
                arg_2B_0 = false;
                }
            IL_25:
            if(7 == 0)
                {
                goto IL_25;
                }
            if(arg_2B_0)
                {
                goto IL_4E;
                }
            long? num2 = value;
            if(num2.GetValueOrDefault() != 0L)
                {
                goto IL_3F;
                }
            bool arg_43_0 = num2.HasValue;
            IL_3D:
            goto IL_40;
            IL_3F:
            arg_43_0 = false;
            IL_40:
            if(8 == 0)
                {
                goto IL_3D;
                }
            if(arg_43_0)
                {
                goto IL_4E;
                }
            IL_45:
            if(value.HasValue)
                {
                result = value;
                return result;
                }
            IL_4E:
            result = DBNull.Value;
            return result;
            }

        protected object SetNullDoubleValue ( double? value )
            {
            if(4 == 0)
                {
                goto IL_52;
                }
            object result = null;
            if(4 == 0)
                {
                goto IL_58;
                }
            double? num = value;
            bool arg_36_0;
            if(num.GetValueOrDefault() == -1.0)
                {
                if(false)
                    {
                    return result;
                    }
                arg_36_0 = num.HasValue;
                }
            else
                {
                arg_36_0 = false;
                }
            IL_30:
            if(7 == 0)
                {
                goto IL_30;
                }
            if(arg_36_0)
                {
                goto IL_61;
                }
            double? num2 = value;
            if(num2.GetValueOrDefault() != 0.0)
                {
                goto IL_52;
                }
            bool arg_56_0 = num2.HasValue;
            IL_50:
            goto IL_53;
            IL_52:
            arg_56_0 = false;
            IL_53:
            if(8 == 0)
                {
                goto IL_50;
                }
            if(arg_56_0)
                {
                goto IL_61;
                }
            IL_58:
            if(value.HasValue)
                {
                result = value;
                return result;
                }
            IL_61:
            result = DBNull.Value;
            return result;
            }

        protected object SetNullBoolValue ( bool? value )
            {
            object result;
            if(5 != 0)
                {
                object expr_03 = null;
                if(3 != 0)
                    {
                    result = expr_03;
                    }
                if(!value.HasValue)
                    {
                    result = DBNull.Value;
                    }
                else if(!false)
                    {
                    object expr_1C = value;
                    if(5 != 0)
                        {
                        result = expr_1C;
                        }
                    }
                }
            IL_15:
            if(5 != 0)
                {
                return result;
                }
            goto IL_15;
            }

        protected object SetNullDecimalValue ( decimal? value )
            {
            IL_00:
            object result;
            while(!false)
                {
                decimal? num = value;
                int arg_22_0 = (num.GetValueOrDefault() == -1m) ? 1 : 0;
                bool arg_37_0;
                do
                    {
                    if(arg_22_0 != 0)
                        {
                        if(7 == 0)
                            {
                            goto IL_00;
                            }
                        if(false)
                            {
                            goto IL_43;
                            }
                        arg_37_0 = ((arg_22_0 = (num.HasValue ? 1 : 0)) != 0);
                        }
                    else
                        {
                        arg_37_0 = ((arg_22_0 = 0) != 0);
                        }
                    }
                while(5 == 0);
                if(arg_37_0)
                    {
                    goto IL_6F;
                    }
                IL_39:
                decimal? num2 = value;
                IL_43:
                if(!(num2 == 0m))
                    {
                    if(3 == 0)
                        {
                        goto IL_39;
                        }
                    if(value.HasValue)
                        {
                        break;
                        }
                    }
                IL_6F:
                result = DBNull.Value;
                return result;
                }
            result = value;
            return result;
            }

        protected object SetNullStringValue ( string value )
            {
            object result;
            if(5 != 0)
                {
                object expr_03 = null;
                if(3 != 0)
                    {
                    result = expr_03;
                    }
                if(string.IsNullOrEmpty(value))
                    {
                    result = DBNull.Value;
                    }
                else if(!false)
                    {
                    object expr_3B = value.ToString();
                    if(5 != 0)
                        {
                        result = expr_3B;
                        }
                    }
                }
            IL_15:
            if(5 != 0)
                {
                return result;
                }
            goto IL_15;
            }

        protected object SetNullDateTimeValue ( DateTime? value )
            {
            object result = value;
   //         if(value == DateTime.MinValue || value == BaseDataAccess.(187).ToDateTime(false))
			//{
   //             result = DBNull.Value;
   //         }
			//else
			//{
   //             result = value;
   //             }
            return result;
            }

        static BaseDataAccess ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(BaseDataAccess));
            }

        }
    }
