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
        private void Button_AddEmployee(object sender, EventArgs e)
        {
            try
            {
                // 社員を追加する
                AddEmployee();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        // 追加フォームを閉じる
        private void Button_CloseAddForm(object sender, EventArgs e)
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
                        if (label_PhoneNumber_Error.Text.Contains(" ※電話番号は5桁以上入力できません") == false)
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

        private void Button_ClearInputText(object sender, EventArgs e)
        {
            ClearInputText();
        }
    }
}
