using Microsoft.Identity.Client;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace 社員管理システム2.Models
{
    public class DatabaseContext
    {
        private NpgsqlConnection conn;
        private NpgsqlTransaction transaction;
        public void connectDB()
        {
            //接続文字列
            string conn_str = "Server=localhost;Port=5432;User ID=dbo;Database=employeedb;Password=jigs&t4d;Enlist=true";

            //TransactionScopeの利用
            using (TransactionScope ts = new TransactionScope())
            {
                using (this.conn = new NpgsqlConnection(conn_str))
                {
                    //PostgreSQLへ接続
                    conn.Open();
                }

            }
        }

        public void disconnectDB(){
            conn.Close();
            conn.Dispose();
        }
    }
}


