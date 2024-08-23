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
        private List<Employees> employeeList;
        private List<Departments> departmentList;
        private List<Positions> positionList;
        private Employees detailedEmployee;

        public EmployeeDetailForm(List<Employees> employeeList, List<Departments> departmentList, List<Positions> positionList, Employees detailedEmployee)
        {
            InitializeComponent();
            this.employeeList = employeeList;
            this.departmentList = departmentList;
            this.positionList = positionList;
            this.detailedEmployee = detailedEmployee;
            inputDetailedEmployee(detailedEmployee);
            
        }

        /*
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            closeAddForm();
        }
        */

        private void inputDetailedEmployee(Employees detailedEmployee)
        {
            textBox_EmployeeID.Text = detailedEmployee.EmployeeID;
            textBox_FirstName.Text = detailedEmployee.FirstName;
            textBox_LastName.Text = detailedEmployee.LastName;
            textBox_FirstNameKana.Text = detailedEmployee.FirstNameKana;
            textBox_LastNameKana.Text = detailedEmployee.LastNameKana;
            textBox_Email.Text = detailedEmployee.Email;
            textBox_PhoneNumber1.Text = detailedEmployee.PhoneNumber;
            textBox_PhoneNumber2.Text = detailedEmployee.PhoneNumber;
            textBox_PhoneNumber3.Text = detailedEmployee.PhoneNumber;
            dateTimePicker_HireDate.Text = detailedEmployee.HireDate.ToString("yyyy/MM/dd");
            InitializeDepartmentComboBox(detailedEmployee);
            InitializePositionComboBox(detailedEmployee);
            InitializeStatusComboBox(detailedEmployee);



            // String[] addData = { FirstNameValue, LastNameValue, FirstNameKanaValue, LastNameKanaValue, EmailValue, PhoneNumber1Value, PhoneNumber2Value, PhoneNumber3Value, HireDateValue, DepartmentValue, PositionValue };
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }



        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("データを削除しますか？", "確認", MessageBoxButtons.OKCancel);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            EmployeeEditForm form3 = new EmployeeEditForm();
            form3.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("この社員を削除しますか？", "削除確認", MessageBoxButtons.OKCancel);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

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

                return comboBox_Department;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

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

                // 読み取り専用にする

                return comboBox_Position;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public ComboBox InitializeStatusComboBox(Employees detailedEmployee)
        {
            try
            {
                // 初期値セット
                comboBox_Status.SelectedIndex = detailedEmployee.Status;

                // 読み取り専用にする

                return comboBox_Status;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
