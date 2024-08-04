using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 社員管理システム2.Models;

namespace 社員管理システム2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var DB = new DatabaseContext();
            var EmployeeRepos = new EmployeeRepository();
            try
            {
                NpgsqlConnection conn = DB.connectDB();
                String query = EmployeeRepos.makeSelectQuery();
                DataTable dt = EmployeeRepos.sqlExecute(query, conn);
                dt = InitializeDataGridView(dt);
                SetDataGridViewEmployeeInfo(dt);

                DB.disconnectDB();
            }
            catch(Exception error) {
                MessageBox.Show(error.Message);
            }




            // カラム数を指定
            // dataGridView1.ColumnCount = 5;

            // カラム名を指定
            // dataGridView1.Columns[0].HeaderText = "社員番号";
            // dataGridView1.Columns[1].HeaderText = "氏名";
            // dataGridView1.Columns[2].HeaderText = "氏名（かな）";
            // dataGridView1.Columns[3].HeaderText = "所属部門";
            // dataGridView1.Columns[4].HeaderText = "役職";

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

        private DataTable SetDataGridViewEmployeeInfo(DataTable dt){
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
            return dt;
        }

        private DataTable InitializeDataGridView(DataTable dt){
            // カラム名を指定
            // dataGridView1.Columns[0].HeaderText = "社員番号";
            // dataGridView1.Columns[1].HeaderText = "氏名";
            // dataGridView1.Columns[2].HeaderText = "氏名（かな）";
            // dataGridView1.Columns[3].HeaderText = "所属部門";
            // dataGridView1.Columns[4].HeaderText = "役職";
            dt.Columns["employeeid"].ColumnName = "社員番号";
            dt.Columns["firstname"].ColumnName = "姓";
            dt.Columns["lastname"].ColumnName = "名";
            dt.Columns["firstnamekana"].ColumnName = "姓（かな）";
            dt.Columns["lastnamekana"].ColumnName = "名（かな）";
            dt.Columns["email"].ColumnName = "メールアドレス";
            dt.Columns["phonenumber"].ColumnName = "電話番号";
            dt.Columns["hiredate"].ColumnName = "雇用日";
            dt.Columns["department"].ColumnName = "部門";
            dt.Columns["position"].ColumnName = "役職";
            dt.Columns["status"].ColumnName = "ステータス";
            return dt;
        }
    }
}
