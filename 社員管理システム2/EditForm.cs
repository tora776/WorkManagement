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
    public partial class EmployeeEditForm : Form
    {
        // クラス変数を定義
        private List<Employees> employeeList;
        private List<Departments> departmentList;
        private List<Positions> positionList;
        private Employees detailedEmployee;
        private EmployeeDetailForm detailForm;
        private MainForm mainForm;

        public EmployeeEditForm(EmployeeDetailForm detailForm, MainForm mainForm, List<Employees> employeeList, List<Departments> departmentList, List<Positions> positionList, Employees detailedEmployee)
        {
            InitializeComponent();
            this.detailForm = detailForm;
            this.mainForm = mainForm;
            this.employeeList = employeeList;
            this.departmentList = departmentList;
            this.positionList = positionList;
            this.detailedEmployee = detailedEmployee;
            inputUpdateEmployee(detailedEmployee);
            
        }

        public void inputUpdateEmployee(Employees detailedEmployee)
        {
            textBox_EmployeeID.Text = detailedEmployee.EmployeeID;
            textBox_FirstName.Text = detailedEmployee.FirstName;
            textBox_LastName.Text = detailedEmployee.LastName;
            textBox_FirstNameKana.Text = detailedEmployee.FirstNameKana;
            textBox_LastNameKana.Text = detailedEmployee.LastNameKana;
            textBox_Email.Text = detailedEmployee.Email;
            textBox_PhoneNumber1.Text = detailedEmployee.PhoneNumber.Substring(0, 3);
            textBox_PhoneNumber2.Text = detailedEmployee.PhoneNumber.Substring(4, 4);
            textBox_PhoneNumber3.Text = detailedEmployee.PhoneNumber.Substring(9, 4);
            dateTimePicker_HireDate.Text = detailedEmployee.HireDate.ToString("yyyy/MM/dd");
            InitializeDepartmentComboBox(detailedEmployee);
            InitializePositionComboBox(detailedEmployee);
            InitializeStatusComboBox(detailedEmployee);
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

                return comboBox_Status;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void Edit_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("データを更新しました");
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
