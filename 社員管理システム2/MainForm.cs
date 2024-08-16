﻿using Npgsql;
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
using System.Security.Cryptography.Xml;

namespace SyainKanriSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            List<Employees> employeeList = InitializeEmployeeRepository();
            List<Departments> departmentList = new List<Departments>();
            departmentList = InitializeDepartmentRepository();
            // List<Departments> departmentList = InitializeDepartmentRepository();
            List<Positions> positionList = InitializePositionRepository();
            dataGridView1 = InitializeDataGridView();
            SetDataGridViewEmployeeInfo(dataGridView1, employeeList, departmentList, positionList);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            EmployeeAddForm addForm = new EmployeeAddForm();
            addForm.Show();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            EmployeeSearchForm searchForm = new EmployeeSearchForm();
            searchForm.Show();
        }

        private void buttonDetailed_Click(object sender, EventArgs e)
        {
            EmployeeDetailForm detailForm = new EmployeeDetailForm();
            SelectedDataGridView();
            detailForm.Show();
        }

        private DataGridView SetDataGridViewEmployeeInfo(DataGridView dataGridView1, List<Employees> employeeList, List<Departments> departmentList, List<Positions> positionList){

            try
            {            
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
                    row.Cells["雇用日"].Value = item.HireDate.ToString("yyyy/MM/dd");
                    row.Cells["部門"].Value = departmentList.Where(x => x.DepartmentID == item.Department).Select(x => x.DepartmentName).FirstOrDefault();
                    row.Cells["役職"].Value = positionList.Where(x => x.PositionID == item.Position).Select(x => x.PositionName).FirstOrDefault();
                    row.Cells["ステータス"].Value = (item.Status == 0) ? "在籍" : "退職";

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

            //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            for(int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].MinimumWidth = 80;
            }

            // ヘッダーを設定
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

        private List<Employees> InitializeEmployeeRepository()
        {
            var DB = new DatabaseContext();
            var EmployeeReposiroty = new EmployeeRepository();
            try
            {
                NpgsqlConnection conn = DB.connectDB();
                String query = EmployeeReposiroty.makeSelectQuery();
                DataTable dt = EmployeeReposiroty.sqlExecute(query, conn);
                DB.disconnectDB(conn);
                List<Employees> employeeList = EmployeeReposiroty.getSelectEmployee(dt);
                return employeeList;

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return null;
            }
        }

        private List<Departments> InitializeDepartmentRepository()
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

        private List<Positions> InitializePositionRepository()
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

        
        private String[] SelectedDataGridView()
        {

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            String[] employeeSelected = new string[11];
                
            for (int i = 0; i < selectedRow.Cells.Count; i++)
            {
            // 選択行のセルを取得する
            employeeSelected[i] = selectedRow.Cells[i].Value.ToString();
            }

            // MessageBox.Show(string.Join(", ", employeeSelected));
            return employeeSelected;

        }
    }
}
