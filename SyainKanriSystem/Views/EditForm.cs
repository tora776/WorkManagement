using System;
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
        private bool GetInputText()
        {
            try
            {
                // bool result = true;

                if (textBox_Sei.Text != "")
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

                if (dateTimePicker_HireDate.Text != "")
                {
                    ViewsUtil.WordCount(dateTimePicker_HireDate.Text, 10);
                    ViewsUtil.CalendarChk(dateTimePicker_HireDate.Text);
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

                if (comboBox_Status.Text != "")
                {
                    ViewsUtil.WordCount(comboBox_Position.Text, 3);
                    ViewsUtil.StatusChk(comboBox_Status.Text);
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
