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
            dataGridView1 = InitializeDataGridView();
            SetDataGridViewEmployeeInfo(dataGridView1);

            ;
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

        private DataGridView SetDataGridViewEmployeeInfo(DataGridView dataGridView1){
            var DB = new DatabaseContext();
            var EmployeeRepos = new EmployeeRepository();
            try
            {
                NpgsqlConnection conn = DB.connectDB();
                String query = EmployeeRepos.makeSelectQuery();
                DataTable dt = EmployeeRepos.sqlExecute(query, conn);
                DB.disconnectDB(conn);
                List<Employees> dataList = EmployeeRepos.getSelectEmployee(dt);

                foreach (Employees item in dataList)
                {
                    dataGridView1.Rows.Add(item);
                }
                return dataGridView1;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return null;
            }
        }

        private DataGridView InitializeDataGridView()
        {   
            dataGridView1 = new DataGridView();
            dataGridView1.ColumnCount = 11;
            dataGridView1.ColumnHeadersVisible = true;

            
            dataGridView1.Columns[0].Name = "社員番号";
            dataGridView1.Columns[1].Name = "姓";
            dataGridView1.Columns[2].Name = "名";
            dataGridView1.Columns[3].Name = "姓（かな）";
            dataGridView1.Columns[4].Name = "名（かな）";
            dataGridView1.Columns[5].Name = "メールアドレス";
            dataGridView1.Columns[6].Name = "電話番号";
            dataGridView1.Columns[7].Name = "雇用日";
            dataGridView1.Columns[8].Name = "部門";
            dataGridView1.Columns[9].Name = "役職";
            dataGridView1.Columns[10].Name = "ステータス";






            return dataGridView1;
        }
    }
}
