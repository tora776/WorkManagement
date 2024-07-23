using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 社員管理システム2
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            //接続文字列
            string conn_str = "Server=localhost;Port=5432;User ID=dbo;Database=employeedb;Password=jigs&t4d;Enlist=true";

            using (NpgsqlConnection conn = new NpgsqlConnection(conn_str))
            {
                //PostgreSQLへ接続
                conn.Open();
                Console.WriteLine("Connection success!");
            }
        }
    }
}
