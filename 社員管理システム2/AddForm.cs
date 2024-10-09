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
        // private readonly List<Employees> employeeList;
        private readonly List<Departments> departmentList;
        private readonly List<Positions> positionList;
        private readonly MainForm mainForm;

        // AddFormを初期化する。
        public EmployeeAddForm(MainForm form, List<Departments> departmentList, List<Positions> positionList)
        {
            InitializeComponent();
            // MainForm.csより受け取ったリストをクラス変数に格納
            this.departmentList = departmentList;
            this.positionList = positionList;
            this.mainForm = form;
            // コンボボックスを初期化
            InitializeDepartmentComboBox();
            InitializePositionComboBox();

            this.FormClosing += new FormClosingEventHandler(AddForm_FormClosing);
        }

        // 社員追加処理
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // 社員を追加する
                AddEmployee();
                MessageBox.Show("社員を追加しました。");
                // テキストボックスを初期化する
                ClearInputText();
                
            }
            catch (Exception error) {
                MessageBox.Show(error.Message);
            }
        }

        // 追加フォームを閉じる
        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            
            // 追加フォームを閉じる
            CloseAddForm();
        }

        // 追加フォームを閉じる際、最新の社員情報をMainFormに反映させる
        private void AddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // MainFormに反映
            mainForm.CloseForm_ResetDataGridView();
        }


        // 入力値を取得する
        private String[] GetInputText()
        {
            string firstNameValue = textBox_Sei.Text;
            string lastNameValue = textBox_Mei.Text;
            string firstNameKanaValue = textBox_SeiKana.Text;
            string lastNameKanaValue = textBox_MeiKana.Text;
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

        // 入力値をクリアする
        private void ClearInputText()
        {
            textBox_Sei.Clear();
            textBox_Mei.Clear();
            textBox_SeiKana.Clear();
            textBox_MeiKana.Clear();
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
        private Employees SubmitAddEmployee(String[] addData, DateTime hireDateValue, string addPhoneNumber, int addDepartmentID, int addPositionID)
        {
            // insertするデータの作成
            Employees addEmployee = new Employees();
            addEmployee.Sei = addData[0];
            addEmployee.Mei = addData[1];
            addEmployee.SeiKana = addData[2];
            addEmployee.MeiKana = addData[3];
            addEmployee.Email = addData[4];
            addEmployee.PhoneNumber = addPhoneNumber;
            addEmployee.HireDate = hireDateValue;
            addEmployee.Department = addDepartmentID;
            addEmployee.Position = addPositionID;
            addEmployee.Status = 0;

            var employeeService = new EmployeeService();
            employeeService.InsertEmployeeData(addEmployee);

            return addEmployee;
        }

        // 追加フォームを閉じる
        private void CloseAddForm()
        {
            this.Close();
            this.Dispose();
        }



        // 社員追加処理
        private void AddEmployee()
        {
            try
            {
                // 入力値を取得
                String[] addData = GetInputText();
                // エラーチェックのクラスインスタンス作成
                var viewsUtil = new ViewsUtil();
                // エラーチェック
                viewsUtil.EmptyChk(addData);
                viewsUtil.WordCount_Add(addData);
                viewsUtil.MailChk(addData[4]);
                viewsUtil.KanaChk(addData[2]);
                viewsUtil.KanaChk(addData[3]);
                DateTime hireDateValue = viewsUtil.CalendarChk(addData[8]);
                string addPhoneNumber = viewsUtil.PhoneChk(addData[5], addData[6], addData[7]);
                int addDepartmentID = viewsUtil.DepartmentChk(addData[9], departmentList);
                int addPositionID = viewsUtil.PositionChk(addData[10], positionList);
                // データの作成・追加処理
                SubmitAddEmployee(addData, hireDateValue, addPhoneNumber, addDepartmentID, addPositionID);
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
        private ComboBox InitializeDepartmentComboBox()
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
        private ComboBox InitializePositionComboBox()
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

        private void ComboBox_Department_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button_Clear_Click(object sender, EventArgs e)
        {
            ClearInputText();
        }
    }
}
