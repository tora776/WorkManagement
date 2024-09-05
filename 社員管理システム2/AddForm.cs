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
using 社員管理システム2;

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
                // テキストボックスを初期化する
                resetInputText();
                
            }
            catch (Exception error) {
                MessageBox.Show(error.Message);
            }
        }

        // 追加フォームを閉じる
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            // MainFormに反映
            mainForm.closeForm_ResetDataGridView();
            // 追加フォームを閉じる
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

        // 入力値を取得する
        private void resetInputText()
        {
            textBox_FirstName.Clear();
            textBox_LastName.Clear();
            textBox_FirstNameKana.Clear();
            textBox_LastNameKana.Clear();
            textBox_Email.Clear();
            textBox_PhoneNumber1.Clear();
            textBox_PhoneNumber2.Clear();
            textBox_PhoneNumber3.Clear();
            // 同日に入社する人が多いと思われるので、dateTimePickerを初期化する
            // dateTimePicker1.Clear();
            comboBox_Department.SelectedIndex = -1;
            comboBox_Position.SelectedIndex = -1;
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
            this.Dispose();
        }



        // 社員追加処理
        private void addEmployee()
        {
            try
            {
                // 入力値を取得
                String[] addData = getInputText();
                // エラーチェックのクラスインスタンス作成
                var validationService = new ValidationService();
                // エラーチェック
                validationService.emptyChk(addData);
                validationService.wordCount_Add(addData);
                validationService.mailChk(addData[4]);
                validationService.kanaChk(addData[2]);
                validationService.kanaChk(addData[3]);
                DateTime hireDateValue = validationService.calendarChk(addData[8]);
                string addPhoneNumber = validationService.phoneChk(addData[5], addData[6], addData[7]);
                int addDepartmentID = validationService.departmentChk(addData[9], departmentList);
                int addPositionID = validationService.positionChk(addData[10], positionList);
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


        // TODO 編集フォームと処理が重複。新規でコンボボックスの入力値を格納するリストを作成？
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

        // TODO 編集フォームと処理が重複。新規でコンボボックスの入力値を格納するリストを作成？
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

        private void button_Back_Click(object sender, EventArgs e)
        {
            resetInputText();
        }
    }
}
