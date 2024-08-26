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
using System.Security.Cryptography.Xml;
using System.Drawing.Text;

namespace SyainKanriSystem
{
    public partial class MainForm : Form
    {
        private List<Employees> employeeList;
        private List<Departments> departmentList;
        private List<Positions> positionList;

        // MainFormを表示する
        public MainForm()
        {
            InitializeComponent();
            employeeList = InitializeEmployeeRepository();
            departmentList = InitializeDepartmentRepository();
            positionList = InitializePositionRepository();
            dataGridView1 = InitializeDataGridView();
            SetDataGridViewEmployeeInfo(dataGridView1, employeeList, departmentList, positionList);
        }

        // 追加処理完了後、DataGridViewをリセットし、最新の社員データを更新する
        // TODO EmployeeAddFormクラスから本メソッドを起動できるようにする
        public static void ResetDataGridView()
        {
            employeeList.Clear();
            employeeList = InitializeEmployeeRepository();
            dataGridView1 = InitializeDataGridView();
            SetDataGridViewEmployeeInfo(dataGridView1, employeeList, departmentList, positionList);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        // 追加ボタンを押下し、AddFormを表示する
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            EmployeeAddForm addForm = new EmployeeAddForm(employeeList, departmentList, positionList);
            addForm.Show();
        }

        // 検索ボタンを押下し、searchFormを表示する
        // TODO 検索フォームを表示する or MainFormに検索内容を表示させるかは要相談
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            EmployeeSearchForm searchForm = new EmployeeSearchForm();
            searchForm.Show();
        }

        // 詳細表示ボタンを押下し、detailFormを表示する
        private void buttonDetailed_Click(object sender, EventArgs e)
        {
            Employees detailedEmployee = SelectedDataGridView();
            EmployeeDetailForm detailForm = new EmployeeDetailForm(employeeList, departmentList, positionList, detailedEmployee);
            detailForm.Show();
        }

        // DataGridViewに取得した社員データを表示する
        private DataGridView SetDataGridViewEmployeeInfo(DataGridView dataGridView1, List<Employees> employeeList, List<Departments> departmentList, List<Positions> positionList){

            try
            {            
                foreach (Employees item in employeeList)
                {
                    // 行番号を指定する
                    int rowIndex = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[rowIndex];
                    // 社員データを記載する
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
                    row.Cells["ステータス"].Value = (item.Status == 0) ? "在籍" : "退職済";

                }

                return dataGridView1;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return null;
            }
        }

        // DataGridViewを初期化する
        private DataGridView InitializeDataGridView()
        {   
            // 列数を指定
            dataGridView1.ColumnCount = 11;
            // カラムヘッダーを可視化できるようにする
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

        // DBより社員データを取得する
        private List<Employees> InitializeEmployeeRepository()
        {
            // employeeServiceのクラスインスタンスを作成
            var employeeService = new EmployeeService();
            // DBよりemployeeListを取得
            employeeList = employeeService.selectEmployeeData();
            return employeeList;
        }

        // DBより部門データを取得
        // TODO DepartmentServiceクラスを新規作成し、そのクラス内でDBとやりとりする必要がある（MVCのため）
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

        // DBより役職データを取得
        // TODO PositionServiceクラスを新規作成し、そのクラス内でDBとやりとりする必要がある（MVCのため）
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

        // DataGridViewから選択行のデータを取得
        // TODO 2行以上選択した場合のエラーチェックを作成する
        // TODO 行選択がない場合のエラーチェックを作成する
        private Employees SelectedDataGridView()
        {
            try
            {
                // 選択している行を取得
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                // 選択している行の社員番号からデータを取得
                Employees detailedEmployee = employeeList.Find(x => x.EmployeeID == selectedRow.Cells[0].Value.ToString());

                return detailedEmployee;
            }
            catch (Exception error)
            {
                throw error;
            }

        }
    }
}
