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
using System.CodeDom;
using 社員管理システム2;

namespace SyainKanriSystem
{
    public partial class MainForm : Form
    {
        private List<Employees> employeeList;
        private List<Departments> departmentList;
        private List<Positions> positionList;
        private List<string[]> searchNameList;

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

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<string[]> searchNameList = new List<string[]>();
                string[] searchSet = { searchComboBox0.Name, searchTextBox0.Name };
                searchNameList.Add(searchSet);
                this.searchNameList = searchNameList;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        // 追加処理完了後、DataGridViewをリセットし、最新の社員データを更新する
        private void resetDataGridView()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 0;
        }

        public void closeForm_ResetDataGridView()
        {
            resetDataGridView();
            employeeList = InitializeEmployeeRepository();
            setEmployeesDataGridView();
        }

        private void setEmployeesDataGridView()
        {
            // employeeList = InitializeEmployeeRepository();
            dataGridView1 = InitializeDataGridView();
            SetDataGridViewEmployeeInfo(this.dataGridView1, this.employeeList, this.departmentList, this.positionList);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        // 追加ボタンを押下し、AddFormを表示する
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            EmployeeAddForm addForm = new EmployeeAddForm(this, employeeList, departmentList, positionList);
            addForm.Show();
        }

        // 検索ボタンを押下し、DBより検索結果を取得する
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                /* 検索フォームを表示する
                EmployeeSearchForm searchForm = new EmployeeSearchForm();
                searchForm.Show();
                */
                List<string> searchComboStr = new List<string>();
                List<string> searchTextStr = new List<string>();
                getSearchConditions(searchComboStr, searchTextStr);
                var employeeService = new EmployeeService();
                this.employeeList = employeeService.searchEmployeeData(searchComboStr, searchTextStr);
                resetDataGridView();
                setEmployeesDataGridView();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        // 詳細表示ボタンを押下し、detailFormを表示する
        private void buttonDetailed_Click(object sender, EventArgs e)
        {
            try
            {
                Employees detailedEmployee = SelectedDataGridView();
                EmployeeDetailForm detailForm = new EmployeeDetailForm(this, employeeList, departmentList, positionList, detailedEmployee);
                detailForm.Show();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        // DataGridViewに取得した社員データを表示する
        private DataGridView SetDataGridViewEmployeeInfo(DataGridView dataGridView1, List<Employees> employeeList, List<Departments> departmentList, List<Positions> positionList) {

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
                    row.Cells["名"].Value = item.LastName;
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
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
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
            if (employeeList != null)
            {
                employeeList.Clear();
            }
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
        private Employees SelectedDataGridView()
        {
            try
            {
                int selectedRowCount = dataGridView1.SelectedRows.Count;
                if (selectedRowCount == 1)
                {
                    // 選択している行を取得
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    // 選択している行の社員番号からデータを取得
                    Employees detailedEmployee = employeeList.Find(x => x.EmployeeID == selectedRow.Cells[0].Value.ToString());

                    return detailedEmployee;
                }
                else if(selectedRowCount == 0)
                {
                    throw new Exception("行選択をしてください");
                }
                else if(selectedRowCount > 1)
                {
                    throw new Exception("行選択は1行のみにしてください");
                }
            }
            catch (Exception error)
            {
                throw error;
                return null;
            }

            return null;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // 「+」ボタンを押下すると、テキストフォーム・コンボボックスが追加される
        private void button_AddSearchCondition_Click(object sender, EventArgs e)
        {
            int textBoxCount = countSearchTextBox();
            string searchComboBox_Name = searchComboBox_Add(textBoxCount);
            string searchTextBox_Name = searchTextBox_Add(textBoxCount);
            string[] searchSet = { searchComboBox_Name, searchTextBox_Name };
            searchNameList.Add(searchSet);
        }

        // コンボボックス追加処理
        // テキストボックスとコンボボックスの数は同一なので、textBoxCountを格納。変数名をcomboBoxCountに変更している
        private string searchComboBox_Add(int comboBoxCount)
        {
            ComboBox searchComboBox = new ComboBox();

            searchComboBox.Name = "searchComboBox" + comboBoxCount;
            // 166はx軸、21 + textBoxCount * 18はy軸
            searchComboBox.Location = new Point(40, 10 + comboBoxCount * 20);
            searchComboBox.Size = new Size(115, 28);
            searchComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            searchComboBox.Items.AddRange(new object[] {
            "社員番号",
            "姓",
            "名",
            "姓（かな）",
            "名（かな）",
            "メールアドレス",
            "電話番号",
            "雇用日",
            "部門",
            "役職",
            "ステータス"});
            // panel1のコントロールに格納
            this.panel1.Controls.Add(searchComboBox);

            return searchComboBox.Name;

        }

        // テキストフォーム追加処理
        private string searchTextBox_Add(int textBoxCount)
        {
            TextBox searchTextBox = new TextBox();

            searchTextBox.Name = "searchTextBox" + textBoxCount;
            // 166はx軸、21 + textBoxCount * 18はy軸
            searchTextBox.Location = new Point(166, 10 + textBoxCount * 20);
            searchTextBox.Size = new Size(196, 26);
            // panel1のコントロールに格納
            this.panel1.Controls.Add(searchTextBox);

            return searchTextBox.Name;
        }

        // 「+」ボタンを押した際、現在のテキストボックスの数を取得する
        private int countSearchTextBox()
        {
            int textBoxCount = 0;

            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is TextBox)
                {
                    textBoxCount++;
                }
            }
            return textBoxCount;
        }

        // 検索テキストボックスを初期化する
        private void clearSearchConditions()
        {
            if (searchNameList.Count > 0)
            {
                for (int i = 1; i < searchNameList.Count; i++)
                {
                    panel1.Controls.RemoveByKey(searchNameList[i][0]);
                    panel1.Controls.RemoveByKey(searchNameList[i][1]);
                }
            }
            searchComboBox0.SelectedIndex = -1;
            searchTextBox0.Clear();
        }

        // クリアボタンを押した際の処理
        private void button_AddSearchConditionsClick(object sender, EventArgs e)
        {
            clearSearchConditions();
            searchNameList.Clear();
            string[] searchSet = { searchComboBox0.Name, searchTextBox0.Name };
            searchNameList.Add(searchSet);
        }

        // 検索コンボボックス・テキストボックスの数だけ入力値を取得する
        private void getSearchConditions(List<string> searchComboStr, List<string> searchTextStr)
        {
            try
            {
                // エラーチェックのクラスインスタンス作成
                var validationService = new ValidationService();
                for (int i = 0; i < searchNameList.Count; i++)
                {
                    // 検索コンボボックスのNameを指定し、入力値を取得
                    Control ctrlComboBox = this.panel1.Controls[searchNameList[i][0]];
                    string searchComboValue = ctrlComboBox.Text;
                    // 検索テキストボックスのNameを指定し、入力値を取得
                    Control ctrlTextBox = this.panel1.Controls[searchNameList[i][1]];
                    string searchTextValue = ctrlTextBox.Text;

                    // 空白でないコンボボックス・テキストボックスにエラーチェック
                    if (String.IsNullOrEmpty(searchComboValue) == false && String.IsNullOrEmpty(searchTextValue) == false)
                    {
                        switch (searchComboValue)
                        {
                            case "社員番号":
                                searchComboValue = "EmployeeID";
                                validationService.wordCount_Main(searchTextValue, 6);
                                validationService.employeeIDChk(searchTextValue);
                                break;
                            case "姓":
                                searchComboValue = "FirstName";
                                validationService.wordCount_Main(searchTextValue, 50);
                                break;
                            case "名":
                                searchComboValue = "LastName";
                                validationService.wordCount_Main(searchTextValue, 50);
                                break;
                            case "姓（かな）":
                                searchComboValue = "FirstNameKana";
                                validationService.wordCount_Main(searchTextValue, 50);
                                validationService.kanaChk(searchTextValue);
                                break;
                            case "名（かな）":
                                searchComboValue = "LastNameKana";
                                validationService.wordCount_Main(searchTextValue, 50);
                                validationService.kanaChk(searchTextValue);
                                break;
                            case "メールアドレス":
                                searchComboValue = "Email";
                                validationService.wordCount_Main(searchTextValue, 255);
                                validationService.mailChk(searchTextValue);
                                break;
                            case "電話番号":
                                searchComboValue = "PhoneNumber";
                                // TODO 引数が1つの電話番号エラーチェック関数を作成
                                validationService.wordCount_Main(searchTextValue, 13);
                                // validationService.phoneChk(searchTextValue);
                                break;
                            case "雇用日":
                                searchComboValue = "HireDate";
                                validationService.wordCount_Main(searchTextValue, 10);
                                // string型に戻して、日付の入力形式を修正
                                searchTextValue = validationService.calendarChk(searchTextValue).ToString("yyyy/MM/dd");
                                break;
                            case "部門":
                                searchComboValue = "Department";
                                validationService.wordCount_Main(searchTextValue, 6);
                                // int型からString型に戻す
                                searchTextValue = validationService.departmentChk(searchTextValue, departmentList).ToString();
                                break;
                            case "役職":
                                searchComboValue = "Position";
                                validationService.wordCount_Main(searchTextValue, 6);
                                // int型からString型に戻す
                                searchTextValue = validationService.positionChk(searchTextValue, positionList).ToString();
                                break;
                            case "ステータス":
                                searchComboValue = "Status";
                                validationService.wordCount_Main(searchTextValue, 3);
                                // int型からString型に戻す
                                searchTextValue = validationService.statusChk(searchTextValue).ToString();
                                break;
                        }
                        // searchComboStrに同じ項目のものがある場合にエラーを出力する
                        if (searchComboStr.IndexOf(searchComboValue) == -1)
                        {
                            // エラーチェックした文字列をリストに格納
                            searchComboStr.Add(searchComboValue);
                            searchTextStr.Add(searchTextValue);
                        }
                        else
                        {
                            throw new Exception("検索コンボボックスに同一の項目を入力することはできません");
                        }
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }

        }
    }
}

    

