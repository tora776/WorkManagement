﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
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
        private readonly List<Departments> departmentList;
        private readonly List<Positions> positionList;
        private readonly Employees detailedEmployee;
        private readonly EmployeeDetailForm detailForm;
        private readonly MainForm mainForm;

        // EditFormを初期化する
        public EmployeeEditForm(EmployeeDetailForm detailForm, MainForm mainForm, List<Departments> departmentList, List<Positions> positionList, Employees detailedEmployee)
        {
            InitializeComponent();
            this.detailForm = detailForm;
            this.mainForm = mainForm;
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
        private bool GetInputText()
        {
            // エラーチェックのクラスインスタンス作成
            var viewsUtil = new ViewsUtil();
            try
            {
                // bool result = true;

                if (textBox_Sei.Text != "")
                {
                    viewsUtil.WordCount(textBox_Sei.Text, 50);
                }
                else
                {
                    return false;
                }

                if (textBox_Mei.Text != "")
                {
                    viewsUtil.WordCount(textBox_Sei.Text, 50);
                }
                else
                {
                    return false;
                }

                if (textBox_SeiKana.Text != "")
                {
                    viewsUtil.WordCount(textBox_Sei.Text, 50);
                    viewsUtil.KanaChk(textBox_SeiKana.Text);
                }
                else
                {
                    return false;
                }

                if (textBox_MeiKana.Text != "")
                {
                    viewsUtil.WordCount(textBox_Mei.Text, 50);
                    viewsUtil.KanaChk(textBox_MeiKana.Text);
                }
                else
                {
                    return false;
                }

                if (textBox_Email.Text != "")
                {
                    viewsUtil.WordCount(textBox_Email.Text, 255);
                    viewsUtil.MailChk(textBox_Email.Text);
                }
                else
                {
                    return false;
                }

                if (textBox_PhoneNumber1.Text != "")
                {
                    viewsUtil.WordCount(textBox_PhoneNumber1.Text, 4);
                    viewsUtil.PhoneChk(textBox_PhoneNumber1.Text);
                }
                else
                {
                    return false;
                }

                if (textBox_PhoneNumber2.Text != "")
                {
                    viewsUtil.WordCount(textBox_PhoneNumber2.Text, 4);
                    viewsUtil.PhoneChk(textBox_PhoneNumber2.Text);
                }
                else
                {
                    return false;
                }

                if (textBox_PhoneNumber3.Text != "")
                {
                    viewsUtil.WordCount(textBox_PhoneNumber3.Text, 4);
                    viewsUtil.PhoneChk(textBox_PhoneNumber3.Text);
                }
                else
                {
                    return false;
                }

                if (dateTimePicker_HireDate.Text != "")
                {
                    viewsUtil.WordCount(dateTimePicker_HireDate.Text, 10);
                    viewsUtil.CalendarChk(dateTimePicker_HireDate.Text);
                }
                else
                {
                    return false;
                }

                if (comboBox_Department.Text != "")
                {
                    viewsUtil.WordCount(comboBox_Department.Text, 5);
                    viewsUtil.DepartmentChk(comboBox_Department.Text, departmentList);
                }
                else
                {
                    return false;
                }

                if (comboBox_Position.Text != "")
                {
                    viewsUtil.WordCount(comboBox_Position.Text, 5);
                    viewsUtil.PositionChk(comboBox_Position.Text, positionList);
                }
                else
                {
                    return false;
                }

                if (comboBox_Status.Text != "")
                {
                    viewsUtil.WordCount(comboBox_Position.Text, 3);
                    viewsUtil.StatusChk(comboBox_Status.Text);
                }
                else
                {
                    return false;
                }

                return true;
            }

            catch (Exception error)
            {
                throw error;
            }
        }
        

        // DBへ社員データを更新する
        public void SubmitUpdateEmployee(Employees detailedEmployee)
        {
            try
            {
                // updateするデータの作成
                Employees updateEmployee = new Employees();
                
                updateEmployee.EmployeeID = detailedEmployee.EmployeeID;
                updateEmployee.Sei = textBox_Sei.Text;
                updateEmployee.Mei = textBox_Mei.Text;
                updateEmployee.SeiKana = textBox_SeiKana.Text;
                updateEmployee.MeiKana = textBox_MeiKana.Text;
                updateEmployee.Email = textBox_Email.Text;
                updateEmployee.PhoneNumber = textBox_PhoneNumber1.Text + "-" + textBox_PhoneNumber2.Text + "-" + textBox_PhoneNumber3.Text;
                updateEmployee.HireDate = DateTime.Parse(dateTimePicker_HireDate.Text);
                updateEmployee.Department = departmentList.Where(x => x.DepartmentName == comboBox_Department.Text).Select(x => x.DepartmentID).FirstOrDefault(); ;
                updateEmployee.Position = positionList.Where(x => x.PositionName == comboBox_Position.Text).Select(x => x.PositionID).FirstOrDefault();
                updateEmployee.Status = (comboBox_Status.Text == "在籍") ? 0 : 1;


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
                GetInputText();
                // データの作成・追加処理
                SubmitUpdateEmployee(detailedEmployee);

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
