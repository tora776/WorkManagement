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
        // DBに接続する
        public NpgsqlConnection ConnectDB()
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
                MessageBox.Show("DBに接続できません。DB接続情報を確認してください。");
                throw error;
            }
        }

        // クエリを実行する。
        public DataTable SqlExecute(String query, NpgsqlConnection conn)
        {
            NpgsqlCommand sql = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = sql.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }

        // DB接続を切断する
        public void DisconnectDB(NpgsqlConnection conn)
        {
            conn.Close();
            conn.Dispose();
        }


    }


}


