using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyainKanriSystem
{
    public partial class EmployeeDetailForm : Form
    {
        // クラス変数を定義
        private List<Employees> employeeList;
        private List<Departments> departmentList;
        private List<Positions> positionList;
        private Employees detailedEmployee;
        MainForm mainForm;
        
        // 詳細表示画面を表示する
        public EmployeeDetailForm(MainForm mainForm, List<Employees> employeeList, List<Departments> departmentList, List<Positions> positionList, Employees detailedEmployee)
        {
            InitializeComponent();

            this.employeeList = employeeList;
            this.departmentList = departmentList;
            this.positionList = positionList;
            this.mainForm = mainForm;
            this.detailedEmployee = detailedEmployee;
            inputDetailedEmployee(detailedEmployee);
        }

        // 詳細表示画面を閉じる
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        

        // DataGridView選択行の社員データをフォーム・コンボボックスに入力する
        // TODO コンボボックス・DateTimePickerを読み取り専用（入力不可）にする
        public void inputDetailedEmployee(Employees detailedEmployee)
        {
            textBox_EmployeeID.Text = detailedEmployee.EmployeeID;
            textBox_FirstName.Text = detailedEmployee.FirstName;
            textBox_LastName.Text = detailedEmployee.LastName;
            textBox_FirstNameKana.Text = detailedEmployee.FirstNameKana;
            textBox_LastNameKana.Text = detailedEmployee.LastNameKana;
            textBox_Email.Text = detailedEmployee.Email;
            textBox_PhoneNumber1.Text = detailedEmployee.PhoneNumber.Substring(0,3);
            textBox_PhoneNumber2.Text = detailedEmployee.PhoneNumber.Substring(4,4);
            textBox_PhoneNumber3.Text = detailedEmployee.PhoneNumber.Substring(9,4);
            dateTimePicker_HireDate.Text = detailedEmployee.HireDate.ToString("yyyy/MM/dd");
            dateTimePicker_HireDate.Enabled = false;
            InitializeDepartmentComboBox(detailedEmployee);
            InitializePositionComboBox(detailedEmployee);
            InitializeStatusComboBox(detailedEmployee);
        }

        public void closeDetailForm()
        {
            this.Close();
            this.Dispose();
        }



        private void button1_Click_2(object sender, EventArgs e)
        {
            EmployeeEditForm editForm = new EmployeeEditForm(this, mainForm, employeeList, departmentList, positionList, detailedEmployee);
            editForm.Show();
        }

        // 削除ボタン処理
        // TODO 削除ボタン処理が2個あるのでどちらが正しいか調べる
        
        private void button2_Click_1(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("この社員を削除しますか？", "削除確認", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                submitDeleteEmployee(detailedEmployee);
            }
        }
        

        private void button3_Click(object sender, EventArgs e)
        {

        }

        // 部門名のコンボボックスのリストを作成・初期値を入力する
        public ComboBox InitializeDepartmentComboBox(Employees detailedEmployee)
        {
            try
            {
                List<Departments> departmentList = this.departmentList;

                // コンボボックスに表示と値をセット
                comboBox_Department.DataSource = departmentList;
                comboBox_Department.DisplayMember = "DepartmentName";
                comboBox_Department.ValueMember = "DepartmentId";

                // 初期値セット。Model.csにてDepartmentクラスDepartmentIDは1から始まっているので、-1する
                comboBox_Department.SelectedIndex = detailedEmployee.Department - 1;

                // 読み取り専用にする
                comboBox_Department.Enabled = false;

                return comboBox_Department;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        // 役職コンボボックスのリストを作成・初期値を入力する
        public ComboBox InitializePositionComboBox(Employees detailedEmployee)
        {
            try
            {
                List<Positions> positionList = this.positionList;

                // コンボボックスに表示と値をセット
                comboBox_Position.DataSource = positionList;
                comboBox_Position.DisplayMember = "PositionName";
                comboBox_Position.ValueMember = "PositionId";

                // 初期値セット。Model.csにてPositionクラスPositionIDは1から始まっているので、-1する
                comboBox_Position.SelectedIndex = detailedEmployee.Position - 1;

                // TODO 読み取り専用にする
                comboBox_Position.Enabled = false;

                return comboBox_Position;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        // ステータスコンボボックスに初期値を入力する（ステータスコンボボックスのリストはDesignerで作成したものを使用する）
        public ComboBox InitializeStatusComboBox(Employees detailedEmployee)
        {
            try
            {
                // 初期値セット
                comboBox_Status.SelectedIndex = detailedEmployee.Status;

                // 読み取り専用にする
                comboBox_Status.Enabled = false;

                return comboBox_Status;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        // DBへ社員データを削除する
        public void submitDeleteEmployee(Employees detailedEmployee)
        {
            // deleteするデータの作成
            string deleteEmployeeID = detailedEmployee.EmployeeID;
            // deleteクエリの作成・実行
            var employeeService = new EmployeeService();
            employeeService.deleteEmployeeData(deleteEmployeeID);
        }


    }
}
