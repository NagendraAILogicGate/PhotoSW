using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using DigiPhoto;

namespace PhotoSW.PSControls
{
    public partial class ImageCalculator : UserControl, IComponentConnector
    {
        public string DGconn = ConfigurationManager.ConnectionStrings["DigiConnectionString"].ConnectionString;

       // internal StackPanel ProgressIndicator;

       // private bool _contentLoaded;

        public ImageCalculator()
        {
            this.InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
        }

        private void GetNewImagesList()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(this.DGconn);
                try
                {
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    //goto IL_26;
                    try
                    {
                        do
                        {
                        IL_26:
                            sqlCommand.CommandType = CommandType.Text;
                            if (false)
                            {
                                goto IL_85;
                            }
                            if (-1 == 0)
                            {
                                goto IL_7D;
                            }
                            sqlCommand.CommandText = "SELECT  count(DISTINCT [DG_Photos_FileName])  from [dbo].[DG_Photos]  where datediff(dd,DG_Photos_CreatedOn,GETDATE())=0";
                        }
                        while (false);
                        sqlConnection.Open();
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (false || sqlDataReader.Read())
                            {
                            }
                        }
                    IL_7D:
                        sqlConnection.Close();
                    IL_85: ;
                    }
                    finally
                    {
                        if (sqlCommand != null)
                        {
                            ((IDisposable)sqlCommand).Dispose();
                        }
                    }
                }
                finally
                {
                    if (sqlConnection != null && !false)
                    {
                        ((IDisposable)sqlConnection).Dispose();
                    }
                }
            }
            catch (Exception var_3_F5)
            {
            }
            finally
            {
                do
                {
                    MemoryManagement.FlushMemory();
                }
                while (3 == 0);
            }
        }

        private void GetTotalImages()
        {
            SqlConnection expr_DC = new SqlConnection(this.DGconn);
            SqlConnection sqlConnection;
            if (3 != 0)
            {
                sqlConnection = expr_DC;
            }
            try
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                //goto IL_27;
                try
                {
                    do
                    {
                    IL_27:
                        DbCommand expr_81 = sqlCommand;
                        CommandType expr_2A = CommandType.Text;
                        if (!false)
                        {
                            expr_81.CommandType = expr_2A;
                        }
                        sqlCommand.CommandText = "select count(DISTINCT [DG_Photos_FileName])  from [Digiphoto].[dbo].[DG_Photos]";
                        sqlConnection.Open();
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                        try
                        {
                            while (sqlDataReader.Read())
                            {
                            }
                        }
                        finally
                        {
                            bool flag = sqlDataReader == null;
                            if (!false && !flag)
                            {
                                ((IDisposable)sqlDataReader).Dispose();
                            }
                        }
                        sqlConnection.Close();
                    }
                    while (5 == 0);
                }
                finally
                {
                    bool flag;
                    do
                    {
                        flag = (sqlCommand == null);
                        if (false)
                        {
                            goto IL_A3;
                        }
                    }
                    while (2 == 0);
                    if (!flag)
                    {
                        ((IDisposable)sqlCommand).Dispose();
                    }
                IL_A3: ;
                }
            }
            finally
            {
                bool flag = sqlConnection == null;
                while (true)
                {
                    if (flag)
                    {
                        goto IL_D0;
                    }
                    ((IDisposable)sqlConnection).Dispose();
                IL_CC:
                    if (8 == 0)
                    {
                        continue;
                    }
                IL_D0:
                    if (!false)
                    {
                        break;
                    }
                    goto IL_CC;
                }
            }
        }

        private void GetLastImageTime()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(this.DGconn);
                try
                {
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    //goto IL_26;
                    try
                    {
                        do
                        {
                        IL_26:
                            sqlCommand.CommandType = CommandType.Text;
                            if (false)
                            {
                                goto IL_85;
                            }
                            if (-1 == 0)
                            {
                                goto IL_7D;
                            }
                            sqlCommand.CommandText = "select DG_Photos_CreatedOn from [Digiphoto].[dbo].[DG_Photos] where DG_Photos_pkey=(select max(DG_Photos_pkey) from [Digiphoto].[dbo].[DG_Photos])";
                        }
                        while (false);
                        sqlConnection.Open();
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (false || sqlDataReader.Read())
                            {
                            }
                        }
                    IL_7D:
                        sqlConnection.Close();
                    IL_85: ;
                    }
                    finally
                    {
                        if (sqlCommand != null)
                        {
                            ((IDisposable)sqlCommand).Dispose();
                        }
                    }
                }
                finally
                {
                    if (sqlConnection != null && !false)
                    {
                        ((IDisposable)sqlConnection).Dispose();
                    }
                }
            }
            catch (Exception var_3_F5)
            {
            }
            finally
            {
                do
                {
                    MemoryManagement.FlushMemory();
                }
                while (3 == 0);
            }
        }

       
    }
}
