using Microsoft.IdentityModel.Tokens;
using SyainKanriSystem.Models;
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
        MainForm mainForm;

        public EmployeeAddForm(MainForm form, List<Employees> employeeList, List<Departments> departmentList, List<Positions> positionList)
        {
            InitializeComponent();
            // MainForm.csより受け取ったリストをクラス変数に格納
            this.employeeList = employeeList;
            this.departmentList = departmentList;
            this.positionList = positionList;
            this.mainForm = form;
            // コンボボックスを初期化
            InitializeDepartmentComboBox();
            InitializePositionComboBox();
        }

        // 社員追加処理
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // 社員を追加する
                addEmployee();
                MessageBox.Show("社員を追加しました。");
                // MainFormに反映
                mainForm.ResetDataGridView();
                // 追加フォームを閉じる
                closeAddForm();
                
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

        //  追加フォームを閉じる
        private void button3_Click(object sender, EventArgs e)
        {
            closeAddForm();
        }

        // 追加フォームを閉じる
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            closeAddForm();
        }

        // 入力値を取得する
        private String[] getInputText()
        {
            string firstNameValue = textBox_FirstName.Text;
            string lastNameValue = textBox_LastName.Text;
            string firstNameKanaValue = textBox_FirstNameKana.Text;
            string lastNameKanaValue = textBox_LastNameKana.Text;
            string emailValue = textBox_Email.Text;
            string phoneNumber1Value = textBox_PhoneNumber1.Text;
            string phoneNumber2Value = textBox_PhoneNumber2.Text;
            string phoneNumber3Value = textBox_PhoneNumber3.Text;
            string hireDateValue = dateTimePicker1.Text;
            string departmentValue = comboBox_Department.Text;
            string positionValue = comboBox_Position.Text;

            String[] addData = {firstNameValue, lastNameValue, firstNameKanaValue, lastNameKanaValue, emailValue, phoneNumber1Value, phoneNumber2Value, phoneNumber3Value, hireDateValue,  departmentValue, positionValue};
            return addData;
        }

        // 入力値が空かどうか取得する
        private void emptyChk(string[] addData)
        {
            try
            {

                for (int i = 0; i < addData.Length; i++)
                {
                    if (String.IsNullOrEmpty(addData[i]) == true)
                    {
                        throw new Exception("入力項目が空です。");
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        // 入力文字数がDBの入力制限を超えていないか確認する
        private void wordCount(string[] addData)
        {
            try
            {
                int[] limit = { 50, 50, 50, 50, 255, 3, 4, 4, 10, 6, 6 };
                for (int i = 0; i < addData.Length; i++)
                {
                    if (addData[i].Length > limit[i])
                    {
                        // TODO contentの{1}がフォーマットされているか確認する
                        string content = string.Format("{0}は既定の文字数をオーバーしています。※{1}文字まで", addData[i], limit[i]);
                        throw new Exception(content);
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        // 姓（かな）・名（かな）が平仮名か確認する
        private void kanaChk(string[] addData)
        {
            try
            {
                for (int i = 2; i < 4; i++)
                {
                    if (Regex.IsMatch(addData[i], @"^\p{IsHiragana}*$") == false)
                    {
                        string content = string.Format("{0}をひらがな入力してください", addData[i]);
                        throw new Exception(content);
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        // 入力値が数字か確認する
        // 電話番号を「xxx-xxxx-xxxx」の形に成形する
        private string phoneChk(string[] addData)
        {
            try
            {
                String[] phoneNumberArray = { addData[5], addData[6], addData[7] };
                // 入力値が数字かどうか確認する
                for (int i = 0; i < phoneNumberArray.Length; i++)
                {
                    bool result = int.TryParse(phoneNumberArray[i], out _);
                    if (result == false)
                    {
                        throw new Exception("電話番号には数字を記載してください");
                    }
                }

                String phoneNumberValue = phoneNumberArray[0] + "-" + phoneNumberArray[1] + "-" + phoneNumberArray[2];

                return phoneNumberValue;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        // 入力値に「@」「.」が含まれているか確認する
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
                        throw new Exception(content);
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        // DateTimePickerに未来の日付が入力されていないか確認する
        // TODO 日付以外のデータが入力されている場合、Catch部に移行するエラーを作成
        private DateTime calendarChk(string[] addData)
        {
            try
            {
                DateTime hireDateValue = DateTime.Parse(addData[8]);

                if (hireDateValue > DateTime.Today)
                {
                    throw new Exception("未来の日付は入力できません");
                }

                return hireDateValue;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        // 部門コンボボックスに異なる値が入力されていないか確認する
        private int departmentComboBoxChk(string[] addData)
        {
            try
            {
                // departmentIDが0の場合、データが存在しない
                String departmentValue = addData[9];
                int departmentID = departmentList.Where(x => x.DepartmentName == departmentValue).Select(x => x.DepartmentID).FirstOrDefault();
                if(departmentID == 0)
                {
                    throw new Exception("存在しない部門名を入力しています");
                }
                
                return departmentID;
            }

            catch (Exception error)
            {
                throw error;
            }
        }


        // 役職コンボボックスに異なる値が入力されていないか確認する
        private int positionComboBoxChk(string[] addData)
        {
            try
            {
                String positionValue = addData[10];
                int positionID = positionList.Where(x => x.PositionName == positionValue).Select(x => x.PositionID).FirstOrDefault();
                if (positionID == 0)
                {
                    throw new Exception("存在しない役職名を入力しています");
                }

                return positionID;
            }

            catch (Exception error)
            {
                throw error;
            }
        }

        // DBへ社員データを追加する
        public Employees submitAddEmployee(String[] addData, DateTime hireDateValue, string addPhoneNumber, int addDepartmentID, int addPositionID)
        {
            // insertするデータの作成
            Employees addEmployee = new Employees();
            addEmployee.FirstName = addData[0];
            addEmployee.LastName = addData[1];
            addEmployee.FirstNameKana = addData[2];
            addEmployee.LastNameKana = addData[3];
            addEmployee.Email = addData[4];
            addEmployee.PhoneNumber = addPhoneNumber;
            addEmployee.HireDate = hireDateValue;
            addEmployee.Department = addDepartmentID;
            addEmployee.Position = addPositionID;
            addEmployee.Status = 0;

            var employeeService = new EmployeeService();
            employeeService.insertEmployeeData(addEmployee);

            return addEmployee;
        }

        // 追加フォームを閉じる
        private void closeAddForm()
        {
            this.Close();
        }



        // 社員追加処理
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
                DateTime hireDateValue = calendarChk(addData);
                string addPhoneNumber = phoneChk(addData);
                int addDepartmentID = departmentComboBoxChk(addData);
                int addPositionID = positionComboBoxChk(addData);
                // データの作成・追加処理
                submitAddEmployee(addData, hireDateValue, addPhoneNumber, addDepartmentID, addPositionID);
                // 追加フォームを閉じる。閉じずに入力フォームを初期化したほうがよい？
                // closeAddForm();
                

            }
            catch (Exception error)
            {
                throw error;
            }
        }
        
        
        // 部門コンボボックスにDBから取得した値を格納する
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

        // 役職コンボボックスにDBから取得した値を格納する
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

                return  comboBox_Position;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void comboBox_Department_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
