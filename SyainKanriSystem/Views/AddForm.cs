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
        private bool addEmployeeFlg;

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
            // 社員追加実施した際に、MainFormのDataGridViewを更新するフラグ
            this.addEmployeeFlg = false;
        }

        // 社員追加処理
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // 社員を追加する
                AddEmployee();                
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
            try
            {
                if (this.addEmployeeFlg == true)
                {
                    // MainFormに反映
                    mainForm.CloseForm_ResetDataGridView();
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }


        // 入力値を取得する
        private bool InputTextCheck()
        {
            try
            {
                // 「姓」が入力されているか確認する
                if (ViewsUtil.InputEmptyCheck(textBox_Sei.Text) == true)
                {
                    // 文字数チェック
                    ViewsUtil.WordCountCheck(textBox_Sei.Text, 50);
                }
                else
                {
                    MessageBox.Show("「姓」は必須入力です");
                    return false;
                }
                // 「名」が入力されているか確認する
                if (ViewsUtil.InputEmptyCheck(textBox_Mei.Text) == true)
                {
                    // 文字数チェック
                    ViewsUtil.WordCountCheck(textBox_Mei.Text, 50);
                }
                else
                {
                    MessageBox.Show("「名」は必須入力です");
                    return false;
                }
                // 「姓（かな）」が入力されているか確認する
                if (ViewsUtil.InputEmptyCheck(textBox_SeiKana.Text) == true)
                {
                    // 文字数チェック
                    ViewsUtil.WordCountCheck(textBox_SeiKana.Text, 50);
                    // 平仮名かどうか確認する
                    ViewsUtil.KanaCheck(textBox_SeiKana.Text);
                }
                else
                {
                    MessageBox.Show("「姓（かな）」は必須入力です");
                    return false;
                }
                // 「名（かな）」が入力されているか確認する
                if (ViewsUtil.InputEmptyCheck(textBox_MeiKana.Text) == true)
                {
                    // 文字数チェック
                    ViewsUtil.WordCountCheck(textBox_MeiKana.Text, 50);
                    // 平仮名かどうか確認する
                    ViewsUtil.KanaCheck(textBox_MeiKana.Text);
                }
                else
                {
                    MessageBox.Show("「名（かな）」は必須入力です");
                    return false;
                }
                // 「メールアドレス」が入力されているか確認する
                if (ViewsUtil.InputEmptyCheck(textBox_Email.Text) == true)
                {
                    // 文字数チェック
                    ViewsUtil.WordCountCheck(textBox_Email.Text, 255);
                    // メールアドレスの書式チェック（「@」「.」の有無）
                    ViewsUtil.MailJapaneseCheck(textBox_Email.Text);
                }
                else
                {
                    MessageBox.Show("「メールアドレス」は必須入力です");
                    return false;
                }
                // 「電話番号」のテキストボックス1つ目が入力されているか確認する
                if (ViewsUtil.InputEmptyCheck(textBox_PhoneNumber1.Text) == true)
                {
                    // 文字数チェック
                    ViewsUtil.WordCountCheck(textBox_PhoneNumber1.Text, 4);
                    // 電話番号の書式チェック（数字が入力されているか）
                    ViewsUtil.PhoneCheck(textBox_PhoneNumber1.Text);
                }
                else
                {
                    MessageBox.Show("「電話番号」は必須入力です");
                    return false;
                }
                // 「電話番号」のテキストボックス2つ目が入力されているか確認する
                if (ViewsUtil.InputEmptyCheck(textBox_PhoneNumber2.Text) == true)
                {
                    // 文字数チェック
                    ViewsUtil.WordCountCheck(textBox_PhoneNumber2.Text, 4);
                    // 電話番号の書式チェック（数字が入力されているか）
                    ViewsUtil.PhoneCheck(textBox_PhoneNumber2.Text);
                }
                else
                {
                    MessageBox.Show("「電話番号」は必須入力です");
                    return false;
                }
                // 「電話番号」のテキストボックス3つ目が入力されているか確認する
                if (ViewsUtil.InputEmptyCheck(textBox_PhoneNumber3.Text) == true)
                {
                    // 文字数チェック
                    ViewsUtil.WordCountCheck(textBox_PhoneNumber3.Text, 4);
                    // 電話番号の書式チェック（数字が入力されているか）
                    ViewsUtil.PhoneCheck(textBox_PhoneNumber3.Text);
                }
                else
                {
                    MessageBox.Show("「電話番号」は必須入力です");
                    return false;
                }
                // 「雇用日」が入力されているか確認する
                if (ViewsUtil.InputEmptyCheck(dateTimePicker_HireDate.Text) == true)
                {
                    // 文字数チェック
                    ViewsUtil.WordCountCheck(dateTimePicker_HireDate.Text, 11);
                    // 日付の書式かどうか確認する
                    ViewsUtil.CalendarCheck(dateTimePicker_HireDate.Text);
                }
                else
                {
                    MessageBox.Show("「雇用日」は必須入力です");
                    return false;
                }
                // 「部門」が入力されているか確認する
                if (ViewsUtil.InputEmptyCheck(comboBox_Department.Text) == true)
                {
                    // 文字数チェック
                    ViewsUtil.WordCountCheck(comboBox_Department.Text, 5);
                    // コンボボックスに存在する部門名と一致しているか確認する
                    ViewsUtil.DepartmentCheck(comboBox_Department.Text, departmentList);
                }
                else
                {
                    MessageBox.Show("「部門」は必須入力です");
                    return false;
                }
                // 「役職」が入力されているか確認する
                if (ViewsUtil.InputEmptyCheck(comboBox_Position.Text) == true)
                {
                    // 文字数チェック
                    ViewsUtil.WordCountCheck(comboBox_Position.Text, 5);
                    // コンボボックスに存在する役職名と一致しているか確認する
                    ViewsUtil.PositionCheck(comboBox_Position.Text, positionList);
                }
                else
                {
                    MessageBox.Show("「役職」は必須入力です");
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
            addEmployee.HireDate = DateTime.Parse(dateTimePicker_HireDate.Text);
            addEmployee.Department = departmentList.Where(x => x.DepartmentName == comboBox_Department.Text).Select(x => x.DepartmentID).FirstOrDefault(); ;
            addEmployee.Position = positionList.Where(x => x.PositionName == comboBox_Position.Text).Select(x => x.PositionID).FirstOrDefault();
            addEmployee.Status = 0;
            
            var employeeService = new EmployeeService();
            employeeService.InsertEmployeeData(addEmployee);

            this.addEmployeeFlg = true;

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
                // 入力値をチェックする
                bool result = InputTextCheck();
                // 入力値が不正であれば処理終了する
                if (!result)
                {
                    return;
                }
                // データの作成・追加処理
                SubmitAddEmployee();
                MessageBox.Show("社員を追加しました。");
                // テキストボックスを初期化する
                ClearInputText();
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
