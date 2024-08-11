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
            List<Employees> employeeList = InitializeEmployees();
            InitializeDepartment();
            InitializePosition();
            dataGridView1 = InitializeDataGridView();
            SetDataGridViewEmployeeInfo(dataGridView1, employeeList);
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

        private DataGridView SetDataGridViewEmployeeInfo(DataGridView dataGridView1, List<Employees> employeeList){
            var DB = new DatabaseContext();
            var EmployeeRepos = new EmployeeRepository();
            try
            {
                /*
                NpgsqlConnection conn = DB.connectDB();
                String query = EmployeeRepos.makeSelectQuery();
                DataTable dt = EmployeeRepos.sqlExecute(query, conn);
                DB.disconnectDB(conn);
                List<Employees> dataList = EmployeeRepos.getSelectEmployee(dt);
                */
                
                foreach (Employees item in employeeList)
                {
                    int rowIndex = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[rowIndex];

                    row.Cells["社員番号"].Value = item.EmployeeID;
                    row.Cells["姓"].Value = item.FirstName;
                    row.Cells["名"].Value =item.LastName;
                    row.Cells["姓（かな）"].Value = item.FirstNameKana;
                    row.Cells["名（かな）"].Value = item.LastNameKana;
                    row.Cells["メールアドレス"].Value = item.Email;
                    row.Cells["電話番号"].Value = item.PhoneNumber;
                    row.Cells["雇用日"].Value = item.LastName;
                    row.Cells["部門"].Value = item.Department;
                    row.Cells["役職"].Value = item.Position;
                    row.Cells["ステータス"].Value = item.Status;

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
            // dataGridView1 = new DataGridView();
            
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

        private List<Employees> InitializeEmployees()
        {
            var DB = new DatabaseContext();
            var EmployeeRepos = new EmployeeRepository();
            try
            {
                NpgsqlConnection conn = DB.connectDB();
                String query = EmployeeRepos.makeSelectQuery();
                DataTable dt = EmployeeRepos.sqlExecute(query, conn);
                DB.disconnectDB(conn);
                List<Employees> employeeList = EmployeeRepos.getSelectEmployee(dt);
                return employeeList;

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return null;
            }
        }

        private List<Departments> InitializeDepartment()
        {
            var DB = new DatabaseContext();
            var DepartmentRepository = new DepartmentRepository();
            try
            {
                NpgsqlConnection conn = DB.connectDB();
                String query = DepartmentRepository.makeSelectQueryDepartment();
                DataTable dt = DepartmentRepository.sqlExecuteDepartment(query, conn);
                DB.disconnectDB(conn);
                List<Departments> departmentList = DepartmentRepository.getSelectDepartment(dt);
                return departmentList;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return null;
            }
        }

        private List<Positions> InitializePosition()
        {
            var DB = new DatabaseContext();
            var PositionRepository = new PositionRepository();
            try
            {
                NpgsqlConnection conn = DB.connectDB();
                String query = PositionRepository.makeSelectQueryPosition();
                DataTable dt = PositionRepository.sqlExecutePosition(query, conn);
                DB.disconnectDB(conn);
                List<Positions> departmentList = PositionRepository.getSelectPosition(dt);
                return departmentList;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return null;
            }
        }



    }
}
