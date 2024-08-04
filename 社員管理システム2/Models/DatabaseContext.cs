﻿using Microsoft.Identity.Client;
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
using 社員管理システム2.Models;

namespace 社員管理システム2.Models
{
    public class DatabaseContext
    {
        private NpgsqlConnection conn;
        private NpgsqlTransaction transaction;
        public void connectDB()
        {
            //接続文字列
            string conn_str = "Server=localhost;Port=5432;User ID=dbo;Database=employeedb;Password=jigs12t4d;Enlist=true";

            try
            {
                this.conn = new NpgsqlConnection(conn_str);
                //PostgreSQLへ接続
                this.conn.Open();
            }
            catch (Exception e)
            {
                throw;
            }
        }
        
        public void disconnectDB(){
            this.conn.Close();
            this.conn.Dispose();
            MessageBox.Show("接続解除しました");
        }
    }


}


