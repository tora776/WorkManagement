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
using System.Windows.Forms;
using SyainKanriSystem.Models;

namespace SyainKanriSystem.Models
{
    public class DatabaseContext
    {
        // private NpgsqlConnection conn;
        // private NpgsqlTransaction transaction;
        public NpgsqlConnection connectDB()
        {
            //接続文字列
            string conn_str = "Server=localhost;Port=5432;User ID=dbo;Database=employeedb;Password=jigs12t4d;Enlist=true";

            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(conn_str);
                //PostgreSQLへ接続
                conn.Open();
                return conn;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        
        public void disconnectDB(NpgsqlConnection conn){
            conn.Close();
            conn.Dispose();
        }

       
    }


}


