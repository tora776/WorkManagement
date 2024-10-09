﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SyainKanriSystem;

namespace SyainKanriSystem
{
    public partial class EmployeeEditForm : Form
    {
        // クラス変数を定義
        private readonly List<Employees> employeeList;
        private readonly List<Departments> departmentList;
        private readonly List<Positions> positionList;
        private readonly Employees detailedEmployee;
        private readonly EmployeeDetailForm detailForm;
        private readonly MainForm mainForm;

        // EditFormを初期化する
        public EmployeeEditForm(EmployeeDetailForm detailForm, MainForm mainForm, List<Employees> employeeList, List<Departments> departmentList, List<Positions> positionList, Employees detailedEmployee)
        {
            InitializeComponent();
            this.detailForm = detailForm;
            this.mainForm = mainForm;
            this.employeeList = employeeList;
            this.departmentList = departmentList;
            this.positionList = positionList;
            this.detailedEmployee = detailedEmployee;
            InputUpdateEmployee(detailedEmployee);
        }

        // テキストボックスに更新対象の社員情報を入力する
        private void InputUpdateEmployee(Employees detailedEmployee)
        {
            textBox_EmployeeID.Text = detailedEmployee.EmployeeID;
            textBox_Sei.Text = detailedEmployee.Sei;
            textBox_Mei.Text = detailedEmployee.Mei;
            textBox_SeiKana.Text = detailedEmployee.SeiKana;
            textBox_MeiKana.Text = detailedEmployee.MeiKana;
            textBox_Email.Text = detailedEmployee.Email;
            textBox_PhoneNumber1.Text = detailedEmployee.PhoneNumber.Substring(0, 3);
            textBox_PhoneNumber2.Text = detailedEmployee.PhoneNumber.Substring(4, 4);
            textBox_PhoneNumber3.Text = detailedEmployee.PhoneNumber.Substring(9, 4);
            dateTimePicker_HireDate.Text = detailedEmployee.HireDate.ToString("yyyy/MM/dd");
            InitializeDepartmentComboBox(detailedEmployee);
            InitializePositionComboBox(detailedEmployee);
            InitializeStatusComboBox(detailedEmployee);
        }

        // TODO 追加フォームと処理が重複。新規でコンボボックスの入力値を格納するリストを作成？
        // 部門名のコンボボックスのリストを作成・初期値を入力する
        private ComboBox InitializeDepartmentComboBox(Employees detailedEmployee)
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

        // TODO 追加フォームと処理が重複。新規でコンボボックスの入力値を格納するリストを作成？
        // 役職コンボボックスのリストを作成・初期値を入力する
        private ComboBox InitializePositionComboBox(Employees detailedEmployee)
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

        // テキストボックスの入力値を取得
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
            string hireDateValue = dateTimePicker_HireDate.Text;
            string departmentValue = comboBox_Department.Text;
            string positionValue = comboBox_Position.Text;
            string statusValue = comboBox_Status.Text;

            String[] updateData = { firstNameValue, lastNameValue, firstNameKanaValue, lastNameKanaValue, emailValue, phoneNumber1Value, phoneNumber2Value, phoneNumber3Value, hireDateValue, departmentValue, positionValue, statusValue };
            return updateData;
        }

        // DBへ社員データを更新する
        public void SubmitUpdateEmployee(Employees detailedEmployee, String[] updateData, DateTime hireDateValue, string updatePhoneNumber, int updateDepartmentID, int updatePositionID, int updateStatusID)
        {
            try
            {
                // updateするデータの作成
                Employees updateEmployee = new Employees();
                updateEmployee.EmployeeID = detailedEmployee.EmployeeID;
                updateEmployee.Sei = updateData[0];
                updateEmployee.Mei = updateData[1];
                updateEmployee.SeiKana = updateData[2];
                updateEmployee.MeiKana = updateData[3];
                updateEmployee.Email = updateData[4];
                updateEmployee.PhoneNumber = updatePhoneNumber;
                updateEmployee.HireDate = hireDateValue;
                updateEmployee.Department = updateDepartmentID;
                updateEmployee.Position = updatePositionID;
                updateEmployee.Status = updateStatusID;

                var employeeService = new EmployeeService();
                employeeService.UpdateEmployeeData(updateEmployee);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        // 更新フォームを閉じる
        private void CloseUpdateForm()
        {
            this.Close();
            this.Dispose();
        }

        // 社員更新処理
        private void UpdateEmployee()
        {
            
            try
            {
            
                // 入力値を取得
                String[] updateData = GetInputText();
                // エラーチェックのクラスインスタンス作成
                var viewsUtil = new ViewsUtil();
                // エラーチェック
                viewsUtil.EmptyChk(updateData);
                viewsUtil.WordCount_Update(updateData);
                viewsUtil.MailChk(updateData[4]);
                viewsUtil.KanaChk(updateData[2]);
                viewsUtil.KanaChk(updateData[3]);
                DateTime hireDateValue = viewsUtil.CalendarChk(updateData[8]);
                string updatePhoneNumber = viewsUtil.PhoneChk(updateData[5], updateData[6], updateData[7]);
                int updateDepartmentID = viewsUtil.DepartmentChk(updateData[9], departmentList);
                int updatePositionID = viewsUtil.PositionChk(updateData[10], positionList);
                int updateStatusID = viewsUtil.StatusChk(updateData[11]);
                // データの作成・追加処理
                SubmitUpdateEmployee(detailedEmployee, updateData, hireDateValue, updatePhoneNumber, updateDepartmentID, updatePositionID, updateStatusID);

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
 

        private void Button_CloseUpdateForm(object sender, EventArgs e)
        {
            CloseUpdateForm();
        }

        private void Button_UpdateClick(object sender, EventArgs e)
        {
            try
            {
                UpdateEmployee();
                MessageBox.Show("データを更新しました");
                // MainFormに反映
                mainForm.CloseForm_ResetDataGridView();
                detailForm.CloseDetailForm();
                CloseUpdateForm();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Button_UpdateCancel_Click(object sender, EventArgs e)
        {
            CloseUpdateForm();
        }
    }
}