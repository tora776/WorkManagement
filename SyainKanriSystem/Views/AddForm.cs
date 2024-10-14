using Microsoft.IdentityModel.Tokens;
using SyainKanriSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SyainKanriSystem;

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

            this.FormClosing += new FormClosingEventHandler(AddForm_FormClosing);
        }

        private void EmployeeAddForm_Load(object sender, EventArgs e)
        {
            // コンボボックスを初期化
            ViewsUtil.InitializeDepartmentComboBox(this.comboBox_Department, this.departmentList);
            ViewsUtil.InitializePositionComboBox(this.comboBox_Position, this.positionList);
            // 初期値セット 
            this.comboBox_Department.SelectedIndex = -1;
            this.comboBox_Position.SelectedIndex = -1;
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
        private bool GetInputText()
        {
            try
            {
                // bool result = true;

                if(textBox_Sei.Text != "")
                {
                    ViewsUtil.WordCount(textBox_Sei.Text, 50);
                }
                else
                {
                    return false;
                }

                if (textBox_Mei.Text != "")
                {
                    ViewsUtil.WordCount(textBox_Sei.Text, 50);
                }
                else
                {
                    return false;
                }

                if (textBox_SeiKana.Text != "")
                {
                    ViewsUtil.WordCount(textBox_Sei.Text, 50);
                    ViewsUtil.KanaChk(textBox_SeiKana.Text);
                }
                else
                {
                    return false;
                }

                if (textBox_MeiKana.Text != "")
                {
                    ViewsUtil.WordCount(textBox_Mei.Text, 50);
                    ViewsUtil.KanaChk(textBox_MeiKana.Text);
                }
                else
                {
                    return false;
                }

                if (textBox_Email.Text != "")
                {
                    ViewsUtil.WordCount(textBox_Email.Text, 255);
                    ViewsUtil.MailChk(textBox_Email.Text);
                }
                else
                {
                    return false;
                }

                if (textBox_PhoneNumber1.Text != "")
                {
                    ViewsUtil.WordCount(textBox_PhoneNumber1.Text, 4);
                    ViewsUtil.PhoneChk(textBox_PhoneNumber1.Text);
                }
                else
                {
                    return false;
                }

                if (textBox_PhoneNumber2.Text != "")
                {
                    ViewsUtil.WordCount(textBox_PhoneNumber2.Text, 4);
                    ViewsUtil.PhoneChk(textBox_PhoneNumber2.Text);
                }
                else
                {
                    return false;
                }

                if (textBox_PhoneNumber3.Text != "")
                {
                    ViewsUtil.WordCount(textBox_PhoneNumber3.Text, 4);
                    ViewsUtil.PhoneChk(textBox_PhoneNumber3.Text);
                }
                else
                {
                    return false;
                }

                if (dateTimePicker1.Text != "")
                {
                    ViewsUtil.WordCount(dateTimePicker1.Text, 10);
                    ViewsUtil.CalendarChk(dateTimePicker1.Text);
                }
                else
                {
                    return false;
                }

                if (comboBox_Department.Text != "")
                {
                    ViewsUtil.WordCount(comboBox_Department.Text, 5);
                    ViewsUtil.DepartmentChk(comboBox_Department.Text, departmentList);
                }
                else
                {
                    return false;
                }

                if (comboBox_Position.Text != "")
                {
                    ViewsUtil.WordCount(comboBox_Position.Text, 5);
                    ViewsUtil.PositionChk(comboBox_Position.Text, positionList);
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
        private Employees SubmitAddEmployee()
        {
            // insertするデータの作成
            Employees addEmployee = new Employees();
            
            addEmployee.Sei = textBox_Sei.Text;
            addEmployee.Mei = textBox_Mei.Text;
            addEmployee.SeiKana = textBox_SeiKana.Text;
            addEmployee.MeiKana = textBox_MeiKana.Text;
            addEmployee.Email = textBox_Email.Text;
            addEmployee.PhoneNumber = textBox_PhoneNumber1.Text + "-" + textBox_PhoneNumber2.Text + "-" + textBox_PhoneNumber3.Text;
            addEmployee.HireDate = DateTime.Parse(dateTimePicker1.Text);
            addEmployee.Department = departmentList.Where(x => x.DepartmentName == comboBox_Department.Text).Select(x => x.DepartmentID).FirstOrDefault(); ;
            addEmployee.Position = positionList.Where(x => x.PositionName == comboBox_Position.Text).Select(x => x.PositionID).FirstOrDefault();
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
                GetInputText();
                // データの作成・追加処理
                SubmitAddEmployee();
                // 追加フォームを閉じる。閉じずに入力フォームを初期化したほうがよい？
                // closeAddForm();
                

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
