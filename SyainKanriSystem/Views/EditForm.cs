using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SyainKanriSystem.Models;

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
        }

        private void EmployeeEditForm_Load(object sender, EventArgs e)
        {
            // コンボボックスを初期化（Statusコンボボックスのリストの値はDesignerにて指定済みの為、不要）
            ViewsUtil.InitializeDepartmentComboBox(this.comboBox_Department, this.departmentList);
            ViewsUtil.InitializePositionComboBox(this.comboBox_Position, this.positionList);
            // 部門コンボボックス初期値セット。Model.csにてDepartmentクラスDepartmentIDは1から始まっているので、-1する
            this.comboBox_Department.SelectedIndex = this.detailedEmployee.Department - 1;
            // 役職コンボボックス初期値セット。Model.csにてPositionクラスPositionIDは1から始まっているので、-1する
            this.comboBox_Position.SelectedIndex = this.detailedEmployee.Position - 1;
            // ステータスコンボボックス初期値セット。
            this.comboBox_Status.SelectedIndex = this.detailedEmployee.Status;
        }

        // テキストボックスの入力値を取得
        private bool InputTextCheck()
        {
            bool ret = true;
            InitializeErrorTextBox();
            try
            {
                // 「姓」が入力されているか確認する
                if (ViewsUtil.InputEmptyCheck(textBox_Sei.Text) == true)
                {
                    // 文字数チェック
                    if (ViewsUtil.WordCountCheck(textBox_Sei.Text, 50) != true)
                    {
                        label_Sei_Error.Text = " ※「姓」は51文字以上入力できません";
                        // label_Sei_Error.Visible = true;
                        textBox_Sei.BackColor = Color.Khaki;
                        label_Sei_Error.ForeColor = Color.Red;
                        ret = false;
                    }
                    // 記号チェック
                    if (ViewsUtil.SymbolCheck(textBox_Sei.Text) != true)
                    {
                        label_Sei_Error.Text = " ※「･」以外の記号は使用できません";
                        // label_Sei_Error.Visible = true;
                        textBox_Sei.BackColor = Color.Khaki;
                        label_Sei_Error.ForeColor = Color.Red;
                        ret = false;
                    }
                }
                else
                {
                    label_Sei_Error.Text = " ※「姓」は必須入力です";
                    // label_Sei_Error.Visible = true;
                    textBox_Sei.BackColor = Color.Khaki;
                    label_Sei_Error.ForeColor = Color.Red;
                    ret = false;
                }
                // 「名」が入力されているか確認する
                if (ViewsUtil.InputEmptyCheck(textBox_Mei.Text) == true)
                {
                    // 文字数チェック
                    if (ViewsUtil.WordCountCheck(textBox_Mei.Text, 50) != true)
                    {
                        label_Mei_Error.Text = " ※「名」は51文字以上入力できません";
                        // label_Mei_Error.Visible = true;
                        textBox_Mei.BackColor = Color.Khaki;
                        label_Mei_Error.ForeColor = Color.Red;
                        ret = false;
                    }
                    // 記号チェック
                    if (ViewsUtil.SymbolCheck(textBox_Mei.Text) != true)
                    {
                        label_Mei_Error.Text = " ※「･」以外の記号は使用できません";
                        // label_Mei_Error.Visible = true;
                        textBox_Mei.BackColor = Color.Khaki;
                        label_Mei_Error.ForeColor = Color.Red;
                        ret = false;
                    }
                }
                else
                {
                    label_Mei_Error.Text = " ※「名」は必須入力です";
                    // label_Mei_Error.Visible = true;
                    textBox_Mei.BackColor = Color.Khaki;
                    label_Mei_Error.ForeColor = Color.Red;
                    ret = false;
                }

                // 「姓（かな）」が入力されているか確認する
                if (ViewsUtil.InputEmptyCheck(textBox_SeiKana.Text) == true)
                {
                    // 文字数チェック
                    if (ViewsUtil.WordCountCheck(textBox_SeiKana.Text, 50) != true)
                    {
                        label_SeiKana_Error.Text = " ※「姓（カナ）」は51文字以上入力できません";
                        // label_SeiKana_Error.Visible = true;
                        textBox_SeiKana.BackColor = Color.Khaki;
                        label_SeiKana_Error.ForeColor = Color.Red;
                        ret = false;
                    }
                    // 平仮名かどうか確認する
                    if (ViewsUtil.KanaCheck(textBox_SeiKana.Text) != true)
                    {
                        label_SeiKana_Error.Text = " ※「姓（カナ）」をカタカナ入力してください";
                        // label_SeiKana_Error.Visible = true;
                        textBox_SeiKana.BackColor = Color.Khaki;
                        label_SeiKana_Error.ForeColor = Color.Red;
                        ret = false;
                    }
                    /* 正規表現で半角全角スペースをチェックできているため不要。
                    // 半角全角スペースチェック
                    if (ViewsUtil.SpaceCheck(textBox_SeiKana.Text) != true)
                    {
                        label_SeiKana_Error.Text = " ※半角または全角スペースが含まれています";
                        // label_SeiKana_Error.Visible = true;
                        textBox_SeiKana.BackColor = Color.Khaki;
                        label_SeiKana_Error.ForeColor = Color.Red;
                        ret = false;
                    }
                    */
                }
                else
                {
                    label_SeiKana_Error.Text = " ※「姓（カナ）」は必須入力です";
                    // label_SeiKana_Error.Visible = true;
                    textBox_SeiKana.BackColor = Color.Khaki;
                    label_SeiKana_Error.ForeColor = Color.Red;
                    ret = false;
                }


                // 「名（かな）」が入力されているか確認する
                if (ViewsUtil.InputEmptyCheck(textBox_MeiKana.Text) == true)
                {
                    // 文字数チェック
                    if (ViewsUtil.WordCountCheck(textBox_MeiKana.Text, 50) != true)
                    {
                        label_MeiKana_Error.Text = " ※「名（カナ）」は51文字以上入力できません";
                        // label_MeiKana_Error.Visible = true;
                        textBox_MeiKana.BackColor = Color.Khaki;
                        label_MeiKana_Error.ForeColor = Color.Red;
                        ret = false;
                    }
                    // 平仮名かどうか確認する
                    if (ViewsUtil.KanaCheck(textBox_MeiKana.Text) != true)
                    {
                        label_MeiKana_Error.Text = " ※「名（カナ）」はカタカナ入力してください";
                        // label_MeiKana_Error.Visible = true;
                        textBox_MeiKana.BackColor = Color.Khaki;
                        label_MeiKana_Error.ForeColor = Color.Red;
                        ret = false;
                    }
                    /* 正規表現で半角全角スペースをチェックできているため不要。
                    // 半角全角スペースチェック
                    if (ViewsUtil.SpaceCheck(textBox_MeiKana.Text) != true)
                    {
                        label_MeiKana_Error.Text += " ※半角または全角スペースが含まれています";
                        // label_MeiKana_Error.Visible = true;
                        textBox_MeiKana.BackColor = Color.Khaki;
                        label_MeiKana_Error.ForeColor = Color.Red;
                        ret = false;
                    }
                    */
                }
                else
                {
                    label_MeiKana_Error.Text = " ※「名（カナ）」は必須入力です";
                    // label_MeiKana_Error.Visible = true;
                    textBox_MeiKana.BackColor = Color.Khaki;
                    label_MeiKana_Error.ForeColor = Color.Red;
                    ret = false;
                }


                // 「メールアドレス」が入力されているか確認する
                if (ViewsUtil.InputEmptyCheck(textBox_Email.Text) == true)
                {
                    // 文字数チェック
                    if (ViewsUtil.WordCountCheck(textBox_Email.Text, 255) != true)
                    {
                        label_Email_Error.Text = " ※メールアドレスは256文字以上入力できません";
                        // label_Email_Error.Visible = true;
                        textBox_Email.BackColor = Color.Khaki;
                        label_Email_Error.ForeColor = Color.Red;
                        ret = false;
                    }
                    // メールアドレスの書式チェック（使用不可の記号の有無）半角全角スペースも本メソッドでチェックする。
                    if (ViewsUtil.MailSymbolCheck(textBox_Email.Text) != true)
                    {
                        label_Email_Error.Text += " ※メールアドレスには下記以外の記号の入力はできません「.」「@」「_」「-」";
                        // label_Email_Error.Visible = true;
                        textBox_Email.BackColor = Color.Khaki;
                        label_Email_Error.ForeColor = Color.Red;
                        ret = false;
                    }
                    // メールアドレスに必須文字列が含まれているかチェック（「@」「.」の有無）
                    string str = ViewsUtil.MailRequiredStrCheck(textBox_Email.Text);
                    if (str != null)
                    {
                        string content = string.Format(" ※メールアドレスに指定の文字（{0}）が入力されていません", str);
                        label_Email_Error.Text = content;
                        // label_Email_Error.Visible = true;
                        textBox_Email.BackColor = Color.Khaki;
                        label_Email_Error.ForeColor = Color.Red;
                        ret = false;
                    }
                }
                else
                {
                    label_Email_Error.Text = " ※「メールアドレス」は必須入力です";
                    // label_Email_Error.Visible = true;
                    textBox_Email.BackColor = Color.Khaki;
                    label_Email_Error.ForeColor = Color.Red;
                    ret = false;
                }
                // 「電話番号」のテキストボックス1つ目が入力されているか確認する
                if (ViewsUtil.InputEmptyCheck(textBox_PhoneNumber1.Text) == true)
                {
                    // 文字数チェック
                    if (ViewsUtil.WordCountCheck(textBox_PhoneNumber1.Text, 4) != true)
                    {
                        label_PhoneNumber_Error.Text = " ※電話番号は5桁以上入力できません";
                        
                        textBox_PhoneNumber1.BackColor = Color.Khaki;
                        label_PhoneNumber_Error.ForeColor = Color.Red;
                        ret = false;
                    }
                    // 電話番号の書式チェック（数字が入力されているか）
                    if (ViewsUtil.PhoneCheck(textBox_PhoneNumber1.Text) != true)
                    {
                        label_PhoneNumber_Error.Text += " ※電話番号は数字を入力してください";
                        
                        textBox_PhoneNumber1.BackColor = Color.Khaki;
                        label_PhoneNumber_Error.ForeColor = Color.Red;
                        ret = false;
                    }
                    // 半角全角スペースチェック
                    if (ViewsUtil.SpaceCheck(textBox_PhoneNumber1.Text) != true)
                    {
                        label_PhoneNumber_Error.Text += " ※半角または全角スペースが含まれています";
                        
                        textBox_PhoneNumber1.BackColor = Color.Khaki;
                        label_PhoneNumber_Error.ForeColor = Color.Red;
                        ret = false;
                    }
                }
                else
                {
                    label_PhoneNumber_Error.Text += " ※「電話番号」は必須入力です";
                    
                    textBox_PhoneNumber1.BackColor = Color.Khaki;
                    label_PhoneNumber_Error.ForeColor = Color.Red;
                    ret = false;
                }
                // 「電話番号」のテキストボックス2つ目が入力されているか確認する
                if (ViewsUtil.InputEmptyCheck(textBox_PhoneNumber2.Text) == true)
                {
                    // 文字数チェック
                    if (ViewsUtil.WordCountCheck(textBox_PhoneNumber2.Text, 4) != true)
                    {
                        // 既にエラーメッセージが出力されている場合のみ、エラー出力する
                        if(label_PhoneNumber_Error.Text.Contains(" ※電話番号は5桁以上入力できません") == false)
                        {
                            label_PhoneNumber_Error.Text += " ※電話番号は5桁以上入力できません";
                            
                            label_PhoneNumber_Error.ForeColor = Color.Red;
                        }
                        textBox_PhoneNumber2.BackColor = Color.Khaki;
                        ret = false;
                    }
                    // 電話番号の書式チェック（数字が入力されているか）
                    if (ViewsUtil.PhoneCheck(textBox_PhoneNumber2.Text) != true)
                    {
                        // 既にエラーメッセージが出力されている場合のみ、エラー出力する
                        if (label_PhoneNumber_Error.Text.Contains(" ※電話番号は数字を入力してください") == false)
                        {
                            label_PhoneNumber_Error.Text += " ※電話番号は数字を入力してください";
                            
                            label_PhoneNumber_Error.ForeColor = Color.Red;
                        }
                        textBox_PhoneNumber2.BackColor = Color.Khaki;
                        ret = false;
                    }
                    // 半角全角スペースチェック
                    if (ViewsUtil.SpaceCheck(textBox_PhoneNumber2.Text) != true)
                    {
                        // 既にエラーメッセージが出力されている場合のみ、エラー出力する
                        if (label_PhoneNumber_Error.Text.Contains(" ※半角または全角スペースが含まれています") == false)
                        {
                            label_PhoneNumber_Error.Text += " ※半角または全角スペースが含まれています";
                            
                            label_PhoneNumber_Error.ForeColor = Color.Red;
                        }
                        textBox_PhoneNumber2.BackColor = Color.Khaki;
                        ret = false;
                    }
                }
                else
                {
                    // 既にエラーメッセージが出力されている場合のみ、エラー出力する
                    if (label_PhoneNumber_Error.Text.Contains(" ※「電話番号」は必須入力です") == false)
                    {
                        label_PhoneNumber_Error.Text += " ※「電話番号」は必須入力です";
                        
                        label_PhoneNumber_Error.ForeColor = Color.Red;
                    }
                    textBox_PhoneNumber2.BackColor = Color.Khaki;
                    ret = false;
                }
                // 「電話番号」のテキストボックス3つ目が入力されているか確認する
                if (ViewsUtil.InputEmptyCheck(textBox_PhoneNumber3.Text) == true)
                {
                    // 文字数チェック
                    if (ViewsUtil.WordCountCheck(textBox_PhoneNumber3.Text, 4) != true)
                    {
                        // 既にエラーメッセージが出力されている場合のみ、エラー出力する
                        if (label_PhoneNumber_Error.Text.Contains(" ※電話番号は5桁以上入力できません") == false)
                        {
                            label_PhoneNumber_Error.Text += " ※電話番号は5桁以上入力できません";
                            label_PhoneNumber_Error.ForeColor = Color.Red;
                        }
                        textBox_PhoneNumber3.BackColor = Color.Khaki;
                        ret = false;
                    }
                    // 電話番号の書式チェック（数字が入力されているか）
                    if (ViewsUtil.PhoneCheck(textBox_PhoneNumber3.Text) != true)
                    {
                        // 既にエラーメッセージが出力されている場合のみ、エラー出力する
                        if (label_PhoneNumber_Error.Text.Contains(" ※電話番号は数字を入力してください") == false)
                        {
                            label_PhoneNumber_Error.Text += " ※電話番号は数字を入力してください";
                            label_PhoneNumber_Error.ForeColor = Color.Red;
                        }
                        textBox_PhoneNumber3.BackColor = Color.Khaki;
                        ret = false;
                    }
                    // 半角全角スペースチェック
                    if (ViewsUtil.SpaceCheck(textBox_PhoneNumber3.Text) != true)
                    {
                        // 既にエラーメッセージが出力されている場合のみ、エラー出力する
                        if (label_PhoneNumber_Error.Text.Contains(" ※半角または全角スペースが含まれています") == false)
                        {
                            label_PhoneNumber_Error.Text += " ※半角または全角スペースが含まれています";
                            label_PhoneNumber_Error.ForeColor = Color.Red;
                        }
                        
                        textBox_PhoneNumber3.BackColor = Color.Khaki;
                        ret = false;
                    }
                }
                else
                {
                    // 既にエラーメッセージが出力されている場合のみ、エラー出力する
                    if (label_PhoneNumber_Error.Text.Contains(" ※「電話番号」は必須入力です") == false)
                    {
                        label_PhoneNumber_Error.Text += " ※「電話番号」は必須入力です";
                        label_PhoneNumber_Error.ForeColor = Color.Red;
                    }
                    
                    textBox_PhoneNumber3.BackColor = Color.Khaki;
                    ret = false;
                }
                // エラーがあった際、エラーテキストから "※必須 半角数字のみ" を削除する
                if (label_PhoneNumber_Error.ForeColor == Color.Red)
                {
                    if (label_PhoneNumber_Error.Text.Contains("※必須 半角数字のみ"))
                    {
                        label_PhoneNumber_Error.Text = label_PhoneNumber_Error.Text.Replace("※必須 半角数字のみ", "");
                    }
                }

                // 「雇用日」が入力されているか確認する
                if (ViewsUtil.InputEmptyCheck(dateTimePicker_HireDate.Text) == true)
                {
                    // 文字数チェック
                    if (ViewsUtil.WordCountCheck(dateTimePicker_HireDate.Text, 11) != true)
                    {
                        label_HireDate_Error.Text = " ※雇用日は11文字以上入力できません";
                        // label_HireDate_Error.Visible = true;
                        label_HireDate_Error.ForeColor = Color.Red;
                        dateTimePicker_HireDate.BackColor = Color.Khaki;
                        ret = false;
                    }
                    // 日付の書式かどうか確認する
                    if (ViewsUtil.CalendarCheck(dateTimePicker_HireDate.Text) != true)
                    {
                        label_HireDate_Error.Text += " ※日付を入力してください";
                        // label_HireDate_Error.Visible = true;
                        label_HireDate_Error.ForeColor = Color.Red;
                        dateTimePicker_HireDate.BackColor = Color.Khaki;
                        ret = false;
                    }
                    // 半角全角スペースチェック
                    if (ViewsUtil.SpaceCheck(dateTimePicker_HireDate.Text) != true)
                    {
                        label_HireDate_Error.Text += " ※半角または全角スペースが含まれています";
                        // label_HireDate_Error.Visible = true;
                        label_HireDate_Error.ForeColor = Color.Red;
                        dateTimePicker_HireDate.BackColor = Color.Khaki;
                        ret = false;
                    }
                }
                else
                {
                    label_HireDate_Error.Text = (" ※「雇用日」は必須入力です");
                    // label_HireDate_Error.Visible = true;
                    label_HireDate_Error.ForeColor = Color.Red;
                    dateTimePicker_HireDate.BackColor = Color.Khaki;
                    ret = false;
                }
                // 「部門」が入力されているか確認する
                if (ViewsUtil.InputEmptyCheck(comboBox_Department.Text) == true)
                {
                    // 文字数チェック
                    if (ViewsUtil.WordCountCheck(comboBox_Department.Text, 5) != true)
                    {
                        label_Department_Error.Text = " ※部門は6文字以上入力できません";
                        // label_Department_Error.Visible = true;
                        label_Department_Error.ForeColor = Color.Red;
                        comboBox_Department.BackColor = Color.Khaki;
                        ret = false;
                    }
                    // コンボボックスに存在する部門名と一致しているか確認する。存在しない部門名の場合は0。
                    if (ViewsUtil.DepartmentCheck(comboBox_Department.Text, departmentList) == 0)
                    {
                        label_Department_Error.Text += " ※存在しない部門名を入力しています";
                        // label_Department_Error.Visible = true;
                        label_Department_Error.ForeColor = Color.Red;
                        comboBox_Department.BackColor = Color.Khaki;
                        ret = false;
                    }
                    // 半角全角スペースチェック
                    if (ViewsUtil.SpaceCheck(comboBox_Department.Text) != true)
                    {
                        label_Department_Error.Text += " ※半角または全角スペースが含まれています";
                        // label_Department_Error.Visible = true;
                        label_Department_Error.ForeColor = Color.Red;
                        comboBox_Department.BackColor = Color.Khaki;
                        ret = false;
                    }
                }
                else
                {
                    label_Department_Error.Text = " ※「部門」は必須入力です";
                    // label_Department_Error.Visible = true;
                    label_Department_Error.ForeColor = Color.Red;
                    comboBox_Department.BackColor = Color.Khaki;
                    ret = false;
                }
                // 「役職」が入力されているか確認する
                if (ViewsUtil.InputEmptyCheck(comboBox_Position.Text) == true)
                {
                    // 文字数チェック
                    if (ViewsUtil.WordCountCheck(comboBox_Position.Text, 5) != true)
                    {
                        label_Position_Error.Text = " ※役職は6文字以上入力できません";
                        // label_Position_Error.Visible = true;
                        label_Position_Error.ForeColor = Color.Red;
                        comboBox_Position.BackColor = Color.Khaki;
                        ret = false;
                    }
                    // コンボボックスに存在する役職名と一致しているか確認する。存在しない役職名の場合は0・
                    if (ViewsUtil.PositionCheck(comboBox_Position.Text, positionList) == 0)
                    {
                        label_Position_Error.Text += " ※存在しない役職名を入力しています";
                        // label_Position_Error.Visible = true;
                        label_Position_Error.ForeColor = Color.Red;
                        comboBox_Position.BackColor = Color.Khaki;
                        ret = false;
                    }
                    // 半角全角スペースチェック
                    if (ViewsUtil.SpaceCheck(comboBox_Position.Text) != true)
                    {
                        label_Position_Error.Text += " ※半角または全角スペースが含まれています";
                        // label_Position_Error.Visible = true;
                        label_Position_Error.ForeColor = Color.Red;
                        comboBox_Position.BackColor = Color.Khaki;
                        ret = false;
                    }
                }
                else
                {
                    label_Position_Error.Text = " ※役職は必須入力です";
                    // label_Position_Error.Visible = true;
                    label_Position_Error.ForeColor = Color.Red;
                    comboBox_Position.BackColor = Color.Khaki;
                    ret = false;
                }
                if (ViewsUtil.InputEmptyCheck(comboBox_Status.Text) == true)
                {
                    // 文字数チェック
                    if (ViewsUtil.WordCountCheck(comboBox_Status.Text, 3) != true)
                    {
                        label_Status_Error.Text = " ※ステータスは4文字以上入力できません";
                        // label_Status_Error.Visible = true;
                        label_Status_Error.ForeColor = Color.Red;
                        comboBox_Status.BackColor = Color.Khaki;
                        ret = false;
                    }
                    // コンボボックスに存在するステータスと一致しているか確認する。「在籍」は0、「退職済」は1となる。
                    if (ViewsUtil.StatusCheck(comboBox_Status.Text) != 0 && ViewsUtil.StatusCheck(comboBox_Status.Text) != 1)
                    {
                        label_Status_Error.Text += " ※存在しないステータス名を入力しています";
                        // label_Status_Error.Visible = true;
                        label_Status_Error.ForeColor = Color.Red;
                        comboBox_Status.BackColor = Color.Khaki;
                        ret = false;
                    }
                    // 半角全角スペースチェック
                    if (ViewsUtil.SpaceCheck(comboBox_Status.Text) != true)
                    {
                        label_Status_Error.Text += " ※半角または全角スペースが含まれています";
                        // label_Status_Error.Visible = true;
                        label_Status_Error.ForeColor = Color.Red;
                        comboBox_Status.BackColor = Color.Khaki;
                        ret = false;
                    }
                }
                else
                {
                    label_Status_Error.Text = " ※「ステータス」は必須入力です";
                    // label_Status_Error.Visible = true;
                    label_Status_Error.ForeColor = Color.Red;
                    comboBox_Status.BackColor = Color.Khaki;
                    ret = false;
                }

                return ret;
            }

            catch (Exception error)
            {
                throw error;
            }
        }

        private void InitializeErrorTextBox()
        {
            //「姓」のエラーメッセージを初期化
            textBox_Sei.BackColor = Color.White;
            label_Sei_Error.Text = "※必須 50文字まで";
            label_Sei_Error.ForeColor = Color.Black;
            //「名」のエラーメッセージを初期化
            textBox_Mei.BackColor = Color.White;
            label_Mei_Error.Text = "※必須 50文字まで";
            label_Mei_Error.ForeColor = Color.Black;
            //「姓（かな）」のエラーメッセージを初期化
            textBox_SeiKana.BackColor = Color.White;
            label_SeiKana_Error.Text = "※必須 カタカナのみ 50文字まで";
            label_SeiKana_Error.ForeColor = Color.Black;
            //「名（かな）」のエラーメッセージを初期化
            textBox_MeiKana.BackColor = Color.White;
            label_MeiKana_Error.Text = "※必須 カタカナのみ 50文字まで";
            label_MeiKana_Error.ForeColor = Color.Black;
            //「メールアドレス」のエラーメッセージを初期化
            textBox_Email.BackColor = Color.White;
            label_Email_Error.Text = "※必須 半角英数字一部記号のみ 255文字まで";
            label_Email_Error.ForeColor = Color.Black;
            //「電話番号」のエラーメッセージを初期化
            textBox_PhoneNumber1.BackColor = Color.White;
            textBox_PhoneNumber2.BackColor = Color.White;
            textBox_PhoneNumber3.BackColor = Color.White;
            label_PhoneNumber_Error.Text = "※必須 半角数字のみ";
            label_PhoneNumber_Error.ForeColor = Color.Black;
            //「雇用日」のエラーメッセージを初期化
            dateTimePicker_HireDate.BackColor = Color.White;
            label_HireDate_Error.Text = "※必須 半角数字のみ";
            label_HireDate_Error.ForeColor = Color.Black;
            //「部門」のエラーメッセージを初期化
            comboBox_Department.BackColor = Color.White;
            label_Department_Error.Text = "必須";
            label_Department_Error.ForeColor = Color.Black;
            //「役職」のエラーメッセージを初期化
            comboBox_Position.BackColor = Color.White;
            label_Position_Error.Text = "必須";
            label_Position_Error.ForeColor = Color.Black;
            //「ステータス」のエラーメッセージを初期化
            comboBox_Status.BackColor = Color.White;
            label_Status_Error.Text = "必須";
            label_Status_Error.ForeColor = Color.Black;
        }


        // DBへ社員データを更新する
        private void SubmitUpdateEmployee(Employees detailedEmployee)
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
                bool ret = InputTextCheck();
                // 入力値が不正であれば処理終了する
                if (!ret)
                {
                    return;
                }
                // データの作成・追加処理
                SubmitUpdateEmployee(detailedEmployee);
                MessageBox.Show("データを更新しました");
                // MainFormに反映
                mainForm.CloseForm_ResetDataGridView();
                detailForm.CloseDetailForm();
                CloseUpdateForm();

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
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

    }
}
