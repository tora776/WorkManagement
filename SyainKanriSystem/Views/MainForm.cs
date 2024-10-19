using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SyainKanriSystem.Models;
using System.Security.Cryptography.Xml;
using System.CodeDom;
using SyainKanriSystem;

namespace SyainKanriSystem
{
    public partial class MainForm : Form
    {
        private List<Employees> employeeList;
        private readonly List<Departments> departmentList;
        private readonly List<Positions> positionList;
        private List<string[]> searchNameList;

        // MainFormを表示する
        public MainForm()
        {
            InitializeComponent();
            // 社員情報を初期化
            employeeList = InitializeEmployeeRepository();
            // 部門情報を初期化
            var departmentService = new DepartmentService();
            departmentList = departmentService.SelectDepartmentData();
            // 役職情報を初期化
            var positionService = new PositionService();
            positionList = positionService.SelectPositionData();
            //DataGridViewを初期化
            dataGridView1 = InitializeDataGridView();
            SetDataGridViewEmployeeInfo(dataGridView1, employeeList, departmentList, positionList);
        }

        // MainFormをロードし、searchNameListに検索条件コンボボックス・検索条件テキストボックスのNameを格納する
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 検索条件コンボボックス・テキストボックスのNameを格納するListを作成。
                List<string[]> searchNameList = new List<string[]>();
                string[] searchSet = { searchComboBox0.Name, searchTextBox0.Name };
                searchNameList.Add(searchSet);
                this.searchNameList = searchNameList;
                // DataGridViewのColumnHeaderMouseClickイベントにハンドラーを追加
                // dataGridView1.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(dataGridView1_ColumnHeaderMouseClick);

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        
        /*
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // ソートする列の名前を取得
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

            // 現在のソート方向を取得
            SortOrder sortOrder = getSortOrder(e.ColumnIndex);

            // 特定の列に基づいてソート処理を分岐
            if (columnName == "姓")
            {
                SortByFirstNameKana(sortOrder);  // 「姓」を「姓（かな）」と同様にソート
            }
            else if (columnName == "部門")
            {
                SortByDepartment(sortOrder);  // 「部門」をDepartmentの値に基づいてソート
            }
            else
            {
                // デフォルトのソート処理（通常の列ソート）
                SortDataGridView(columnName, sortOrder);
            }
        }

        private SortOrder getSortOrder(int columnIndex)
        {
            // 現在のソート状況を確認
            if (dataGridView1.SortedColumn != null && dataGridView1.SortedColumn.Index == columnIndex)
            {
                if (dataGridView1.SortOrder == SortOrder.Ascending)
                {
                    return SortOrder.Descending;
                }
                else if (dataGridView1.SortOrder == SortOrder.Descending)
                {
                    return SortOrder.Ascending;
                }
            }
            return SortOrder.Ascending; // デフォルトでは昇順でソート
        }

        // 「姓（かな）」列に基づいてソートするメソッド
        private void SortByFirstNameKana(SortOrder sortOrder)
        {
            if (sortOrder == SortOrder.Ascending)
            {
                employeeList = employeeList.OrderBy(x => x.SeiKana).ToList();
            }
            else
            {
                employeeList = employeeList.OrderByDescending(x => x.MeiKana).ToList();
            }
        }

        // Departmentに基づいてソートするメソッド
        private void SortByDepartment(SortOrder sortOrder)
        {
            if (sortOrder == SortOrder.Ascending)
            {
                employeeList = employeeList.OrderBy(x => x.Department).ToList();
                // employeeList = employeeList.Where(x => x.Department == departmentList.DepartmentName).OrderBy(x => departmentList.DepartmentID).ToList();
            }
            else
            {
                employeeList = employeeList.OrderByDescending(x => x.Department).ToList();
            }
            // resetDataGridView();
            // setEmployeesDataGridView();
        }

        // 通常の列ソート処理を行うメソッド
        private void SortDataGridView(string columnName, SortOrder sortOrder)
        {
            if (sortOrder == SortOrder.Ascending)
            {
                dataGridView1.Sort(dataGridView1.Columns[columnName], System.ComponentModel.ListSortDirection.Ascending);
            }
            else
            {
                dataGridView1.Sort(dataGridView1.Columns[columnName], System.ComponentModel.ListSortDirection.Descending);
            }
        }
        */
        

        // DataGridViewをリセットする
        private void ResetDataGridView()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 0;
        }

        // 追加・詳細・更新フォームを閉じた際、DataGridViewをリセットし、更新後の社員情報を取得する
        public void CloseForm_ResetDataGridView()
        {
            ResetDataGridView();
            employeeList = InitializeEmployeeRepository();
            SetEmployeesDataGridView();
        }

        // DataGridViewに社員情報をセットする
        private void SetEmployeesDataGridView()
        {
            // employeeList = InitializeEmployeeRepository();
            dataGridView1 = InitializeDataGridView();
            SetDataGridViewEmployeeInfo(this.dataGridView1, this.employeeList, this.departmentList, this.positionList);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        // 追加ボタンを押下すると、AddFormを表示する
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            EmployeeAddForm addForm = new EmployeeAddForm(this, departmentList, positionList);
            addForm.Show();
        }

        // 検索ボタンを押下すると、DBより検索結果を取得する
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                /* 検索フォームを表示する
                EmployeeSearchForm searchForm = new EmployeeSearchForm();
                searchForm.Show();
                */
                // 検索コンボボックスの値を格納するリストを作成
                List<string> searchComboStr = new List<string>();
                // 検索テキストボックスの値を格納するリストを作成
                List<string> searchTextStr = new List<string>();
                // 検索コンボボックス・検索テキストボックスの値を取得する
                GetSearchConditions(searchComboStr, searchTextStr);
                var employeeService = new EmployeeService();
                // DBから検索結果を取得する
                this.employeeList = employeeService.SearchEmployeeData(searchComboStr, searchTextStr);
                // DataGridViewを初期化する
                ResetDataGridView();
                // DataGridViewに検索結果を格納する
                SetEmployeesDataGridView();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        // 詳細表示ボタンを押下すると、detailFormを表示する
        private void ButtonDetailed_Click(object sender, EventArgs e)
        {
            try
            {
                Employees detailedEmployee = GetSelectedRow();
                EmployeeDetailForm detailForm = new EmployeeDetailForm(this, departmentList, positionList, detailedEmployee);
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
                    row.Cells["姓"].Value = item.Sei;
                    row.Cells["名"].Value = item.Mei;
                    row.Cells["姓（かな）"].Value = item.SeiKana;
                    row.Cells["名（かな）"].Value = item.MeiKana;
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

        // 社員情報を初期化する
        private List<Employees> InitializeEmployeeRepository()
        {
            // NULLチェック
            employeeList?.Clear();           
            // employeeServiceのクラスインスタンスを作成
            var employeeService = new EmployeeService();
            // DBよりemployeeListを取得
            employeeList = employeeService.SelectEmployeeData();
            return employeeList;
        }
        
        // DataGridViewから選択行のデータを取得
        private Employees GetSelectedRow()
        {
            try
            {
                // 選択行の行数を取得
                int selectedRowCount = dataGridView1.SelectedRows.Count;
                if (selectedRowCount == 1)
                {
                    // 選択している行を取得
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    // 選択している行の社員番号からデータを取得
                    Employees detailedEmployee = employeeList.Find(x => x.EmployeeID == selectedRow.Cells[0].Value.ToString());

                    return detailedEmployee;
                }
                // 全く行が選択されていない場合
                else if(selectedRowCount == 0)
                {
                    throw new Exception("行選択をしてください");
                }
                // 2行以上選択されている場合
                else if(selectedRowCount > 1)
                {
                    throw new Exception("行選択は1行のみにしてください");
                }
            }
            catch (Exception error)
            {
                throw error;
                // return null;
            }

            return null;
        }

        // 「+」ボタンを押下すると、テキストフォーム・コンボボックスが追加される
        private void Button_AddSearchCondition_Click(object sender, EventArgs e)
        {
            try
            {
                if (searchNameList.Count < 12)
                {
                    int searchConditionsCount = CountSearchConditions();
                    string searchComboBox_Name = SearchComboBox_Add(searchConditionsCount);
                    string searchTextBox_Name = SearchTextBox_Add(searchConditionsCount);
                    string[] searchSet = { searchComboBox_Name, searchTextBox_Name };
                    searchNameList.Add(searchSet);
                }
                else
                {
                    throw new Exception("検索条件を12件以上追加できません");
                }
            }
            catch
            {
                MessageBox.Show("検索条件を12件以上追加できません");
            }
        }

        // 検索条件コンボボックス追加処理
        // テキストボックスとコンボボックスの数は同一なので、textBoxCountを格納。変数名をcomboBoxCountに変更している
        private string SearchComboBox_Add(int searchConditionsCount)
        {
            ComboBox searchComboBox = new ComboBox();
            // 検索条件コンボボックスのNameを指定 ex)searchComboBox1, searchComboBox2...
            searchComboBox.Name = "searchComboBox" + searchConditionsCount;
            // 166はx軸、21 + textBoxCount * 18はy軸
            searchComboBox.Location = new Point(40, 10 + searchConditionsCount * 20);
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

        // 検索条件テキストボックス追加処理
        private string SearchTextBox_Add(int searchConditionsCount)
        {
            TextBox searchTextBox = new TextBox();
            // 検索条件テキストボックスのNameを指定 ex)searchTextBox1, searchTextBox2...
            searchTextBox.Name = "searchTextBox" + searchConditionsCount;
            // 166はx軸、21 + textBoxCount * 18はy軸
            searchTextBox.Location = new Point(166, 10 + searchConditionsCount * 20);
            searchTextBox.Size = new Size(196, 26);
            // panel1のコントロールに格納
            this.panel1.Controls.Add(searchTextBox);

            return searchTextBox.Name;
        }

        // 「+」ボタンを押した際、現在の検索条件の数を取得する
        private int CountSearchConditions()
        {
            int searchConditionsCount = 0;

            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is TextBox)
                {
                    searchConditionsCount++;
                }
            }
            return searchConditionsCount;
        }

        // 「＋」ボタンで増やした、検索条件コンボボックス・検索条件テキストボックスをクリアする。
        private void ClearSearchConditions()
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
        private void Button_clearSearchConditionsClick(object sender, EventArgs e)
        {
            ClearSearchConditions();
            searchNameList.Clear();
            string[] searchSet = { searchComboBox0.Name, searchTextBox0.Name };
            searchNameList.Add(searchSet);
        }

        // 検索条件コンボボックス・検索条件テキストボックスの値を取得する
        private void GetSearchConditions(List<string> searchComboStr, List<string> searchTextStr)
        {
            try
            {
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
                                ViewsUtil.WordCountCheck(searchTextValue, 6);
                                ViewsUtil.EmployeeIDCheck(searchTextValue);
                                break;
                            case "姓":
                                searchComboValue = "Sei";
                                ViewsUtil.WordCountCheck(searchTextValue, 50);
                                break;
                            case "名":
                                searchComboValue = "Mei";
                                ViewsUtil.WordCountCheck(searchTextValue, 50);
                                break;
                            case "姓（かな）":
                                searchComboValue = "SeiKana";
                                ViewsUtil.WordCountCheck(searchTextValue, 50);
                                ViewsUtil.KanaCheck(searchTextValue);
                                break;
                            case "名（かな）":
                                searchComboValue = "MeiKana";
                                ViewsUtil.WordCountCheck(searchTextValue, 50);
                                ViewsUtil.KanaCheck(searchTextValue);
                                break;
                            case "メールアドレス":
                                searchComboValue = "Email";
                                ViewsUtil.WordCountCheck(searchTextValue, 255);
                                ViewsUtil.MailCheck(searchTextValue);
                                break;
                            case "電話番号":
                                searchComboValue = "PhoneNumber";
                                // TODO 引数が1つの電話番号エラーチェック関数を作成
                                ViewsUtil.WordCountCheck(searchTextValue, 13);
                                // ViewsUtil.phoneChk(searchTextValue);
                                break;
                            case "雇用日":
                                searchComboValue = "HireDate";
                                ViewsUtil.WordCountCheck(searchTextValue, 10);
                                // string型に戻して、日付の入力形式を修正
                                searchTextValue = ViewsUtil.CalendarCheck(searchTextValue).ToString("yyyy/MM/dd");
                                break;
                            case "部門":
                                searchComboValue = "Department";
                                ViewsUtil.WordCountCheck(searchTextValue, 6);
                                // int型からString型に戻す
                                searchTextValue = ViewsUtil.DepartmentCheck(searchTextValue, departmentList).ToString();
                                break;
                            case "役職":
                                searchComboValue = "Position";
                                ViewsUtil.WordCountCheck(searchTextValue, 6);
                                // int型からString型に戻す
                                searchTextValue = ViewsUtil.PositionCheck(searchTextValue, positionList).ToString();
                                break;
                            case "ステータス":
                                searchComboValue = "Status";
                                ViewsUtil.WordCountCheck(searchTextValue, 3);
                                // int型からString型に戻す
                                searchTextValue = ViewsUtil.StatusCheck(searchTextValue).ToString();
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

    

