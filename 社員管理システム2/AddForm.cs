using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Hierarchy;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyainKanriSystem
{
    public partial class EmployeeAddForm : Form


    {
        private List<Employees> employeeList;
        private List<Departments> departmentList;
        private List<Positions> positionList;

        public EmployeeAddForm(List<Employees> employeeList, List<Departments> departmentList, List<Positions> positionList)
        {
            InitializeComponent();
            this.employeeList = employeeList;
            this.departmentList = departmentList;
            this.positionList = positionList;
            InitializeDepartmentComboBox();
            InitializePositionComboBox();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                addEmployee();
                MessageBox.Show("データを追加しました。");
            }
            catch (Exception error) {
                MessageBox.Show(error.Message);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            closeAddForm();
            // MainForm.ResetDataGridView(MainForm.dataGridView1);
        }
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            closeAddForm();
        }

        private String[] getInputText()
        {
            string FirstNameValue = textBox_FirstName.Text;
            string LastNameValue = textBox_LastName.Text;
            string FirstNameKanaValue = textBox_FirstNameKana.Text;
            string LastNameKanaValue = textBox_LastNameKana.Text;
            string EmailValue = textBox_Email.Text;
            string PhoneNumber1Value = textBox_PhoneNumber1.Text;
            string PhoneNumber2Value = textBox_PhoneNumber2.Text;
            string PhoneNumber3Value = textBox_PhoneNumber3.Text;
            string HireDateValue = dateTimePicker1.Text;
            string DepartmentValue = comboBox_Department.Text;
            string PositionValue = comboBox_Position.Text;

            String[] addData = {FirstNameValue, LastNameValue, FirstNameKanaValue, LastNameKanaValue, EmailValue, PhoneNumber1Value, PhoneNumber2Value, PhoneNumber3Value, HireDateValue,  DepartmentValue, PositionValue};
            return addData;
        }

        private void emptyChk(string[] addData)
        {
            try
            {

                for (int i = 0; i < addData.Length; i++)
                {
                    if (String.IsNullOrEmpty(addData[i]) == true)
                    {
                        MessageBox.Show("空の入力項目が存在します");
                        break;
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void wordCount(string[] addData)
        {
            try
            {
                int[] limit = { 50, 50, 50, 50, 255, 3, 4, 4, 10, 6, 6 };
                for (int i = 0; i < addData.Length; i++)
                {
                    if (addData[i].Length > limit[i])
                    {
                        string content = string.Format("{0}は既定の文字数をオーバーしています。※{1}文字まで", addData[i], limit[i]);
                        MessageBox.Show(content);
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void kanaChk(string[] addData)
        {
            try
            {
                for (int i = 2; i < 4; i++)
                {
                    if (Regex.IsMatch(addData[i], @"^\p{IsHiragana}*$") == false)
                    {
                        string content = string.Format("{0}をひらがな入力してください", addData[i]);
                        MessageBox.Show(content);
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private string phoneChk(string[] addData)
        {
            try
            {
                String[] PhoneNumberArray = { addData[5], addData[6], addData[7] };
                for (int i = 0; i < PhoneNumberArray.Length; i++)
                {
                    bool result = int.TryParse(PhoneNumberArray[i], out _);
                    if (result == false)
                    {
                        MessageBox.Show("電話番号には数字を記載してください");
                        return null;
                    }
                }

                String PhoneNumberValue = PhoneNumberArray[0] + "-" + PhoneNumberArray[1] + "-" + PhoneNumberArray[2];

                return PhoneNumberValue;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void mailChk(string[] addData)
        {
            try
            {
                String[] strRequired = { "@", "." };
                foreach (String str in strRequired)
                {
                    if (addData[4].Contains(str) == false)
                    {
                        string content = string.Format("メールアドレスに指定の文字（{0}）が入力されていません", str);
                        MessageBox.Show(content);
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private DateTime calendarChk(string[] addData)
        {
            try
            {
                DateTime HireDateValue = DateTime.Parse(addData[8]);

                if (HireDateValue > DateTime.Today)
                {
                    MessageBox.Show("未来の日付は入力できません");
                }

                return HireDateValue;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private int departmentComboBoxChk(string[] addData)
        {
            try
            {
                // departmentIDが0の場合、ないデータを記入しています
                String DepartmentValue = addData[9];
                int departmentID = departmentList.Where(x => x.DepartmentName == DepartmentValue).Select(x => x.DepartmentID).FirstOrDefault();
                if(departmentID == 0)
                {
                    MessageBox.Show("存在しない部門名を入力しています");
                }
                
                return departmentID;
            }

            catch (Exception error)
            {
                throw error;
            }
        }

        private int positionComboBoxChk(string[] addData)
        {
            try
            {
                String PositionValue = addData[10];
                int positionID = positionList.Where(x => x.PositionName == PositionValue).Select(x => x.PositionID).FirstOrDefault();
                if (positionID == 0)
                {
                    MessageBox.Show("存在しない役職名を入力しています");
                }

                return positionID;
            }

            catch (Exception error)
            {
                throw error;
            }
        }

        public Employees submitAddEmployee(String[] addData, DateTime HireDateValue, string addPhoneNumber, int addDepartmentID, int addPositionID)
        {
            // insertするデータの作成
            Employees addEmployee = new Employees();
            addEmployee.FirstName = addData[0];
            addEmployee.LastName = addData[1];
            addEmployee.FirstNameKana = addData[2];
            addEmployee.LastNameKana = addData[3];
            addEmployee.Email = addData[4];
            addEmployee.PhoneNumber = addPhoneNumber;
            addEmployee.HireDate = HireDateValue;
            addEmployee.Department = addDepartmentID;
            addEmployee.Position = addPositionID;
            addEmployee.Status = 0;

            var employeeService = new EmployeeService();
            employeeService.insertEmployeeData(addEmployee);

            return addEmployee;
        }

        private void closeAddForm()
        {
            this.Close();
        }




        private void addEmployee()
        {
            try
            {
                // 入力値を取得
                String[] addData = getInputText();
                // エラーチェック
                emptyChk(addData);
                wordCount(addData);
                mailChk(addData);
                kanaChk(addData);
                DateTime HireDateValue = calendarChk(addData);
                string addPhoneNumber = phoneChk(addData);
                int addDepartmentID = departmentComboBoxChk(addData);
                int addPositionID = positionComboBoxChk(addData);
                // データの作成・追加処理
                submitAddEmployee(addData, HireDateValue, addPhoneNumber, addDepartmentID, addPositionID);
                // 追加フォームを閉じる。閉じずに入力フォームを初期化したほうがよい？
                closeAddForm();
                

            }
            catch (Exception error)
            {
                throw error;
            }
        }
        
        
        public ComboBox InitializeDepartmentComboBox()
        {
            try
            {
                List<Departments> departmentList = this.departmentList;

                // コンボボックスに表示と値をセット
                comboBox_Department.DataSource = departmentList;
                comboBox_Department.DisplayMember = "DepartmentName";
                comboBox_Department.ValueMember = "DepartmentId";

                // 初期値セット
                comboBox_Department.SelectedIndex = -1;

                return comboBox_Department;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public ComboBox InitializePositionComboBox()
        {
            try
            {
                List<Positions> positionList = this.positionList;

                // コンボボックスに表示と値をセット
                comboBox_Position.DataSource = positionList;
                comboBox_Position.DisplayMember = "PositionName";
                comboBox_Position.ValueMember = "PositionId";

                // 初期値セット
                comboBox_Position.SelectedIndex = -1;

                return comboBox_Position;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        
    }
}
