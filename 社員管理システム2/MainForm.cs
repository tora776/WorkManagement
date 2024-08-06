using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SyainKanriSystem.Models;

namespace SyainKanriSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DataTable dt = SetDataGridViewEmployeeInfo();
            dataGridView1.DataSource = InitializeDataGridView(dt);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeAddForm addForm = new EmployeeAddForm();
            addForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EmployeeSearchForm form7 = new EmployeeSearchForm();
            form7.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EmployeeDetailForm detailForm = new EmployeeDetailForm();
            detailForm.Show();
        }

        private DataTable SetDataGridViewEmployeeInfo(){
            var DB = new DatabaseContext();
            var EmployeeRepos = new EmployeeRepository();
            try
            {
                NpgsqlConnection conn = DB.connectDB();
                String query = EmployeeRepos.makeSelectQuery();
                DataTable dt = EmployeeRepos.sqlExecute(query, conn);              
                DB.disconnectDB();
                return dt;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return null;
            }
        }

        private DataTable InitializeDataGridView(DataTable dt){
            // カラム名を変更
            dt.Columns["employeeid"].ColumnName = "社員番号";
            dt.Columns["firstname"].ColumnName = "姓";
            dt.Columns["lastname"].ColumnName = "名";
            dt.Columns["firstnamekana"].ColumnName = "姓（かな）";
            dt.Columns["lastnamekana"].ColumnName = "名（かな）";
            dt.Columns["email"].ColumnName = "メールアドレス";
            dt.Columns["phonenumber"].ColumnName = "電話番号";
            dt.Columns["hiredate"].ColumnName = "雇用日";
            dt.Columns["departmentname"].ColumnName = "部門";
            dt.Columns["positionname"].ColumnName = "役職";
            dt.Columns["status"].ColumnName = "ステータス";

           // dt.Columns["ステータス"].ReadOnly = false;

            //dt.AsEnumerable().Where(r => r.Field<int>("ステータス") == 0)
              //  .Select(r => r["ステータス"] = "在籍")
               // .ToList();

            return dt;
        }
    }
}
