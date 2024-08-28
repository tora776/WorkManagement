using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyainKanriSystem
{
    public partial class EmployeeEditForm : Form
    {
        // クラス変数を定義
        private List<Employees> employeeList;
        private List<Departments> departmentList;
        private List<Positions> positionList;
        private Employees detailedEmployee;
        EmployeeDetailForm detailForm;
        MainForm mainForm;

        public EmployeeEditForm(EmployeeDetailForm detailForm, MainForm mainForm, List<Employees> employeeList, List<Departments> departmentList, List<Positions> positionList, Employees detailedEmployee)
        {
            InitializeComponent();
            this.detailForm = detailForm;
            this.mainForm = mainForm;
            this.employeeList = employeeList;
            this.departmentList = departmentList;
            this.positionList = positionList;
            this.detailedEmployee = detailedEmployee;
            inputUpdateEmployee(detailedEmployee);
            
        }

        public void inputUpdateEmployee(Employees detailedEmployee)
        {
            textBox_EmployeeID.Text = detailedEmployee.EmployeeID;
            textBox_FirstName.Text = detailedEmployee.FirstName;
            textBox_LastName.Text = detailedEmployee.LastName;
            textBox_FirstNameKana.Text = detailedEmployee.FirstNameKana;
            textBox_LastNameKana.Text = detailedEmployee.LastNameKana;
            textBox_Email.Text = detailedEmployee.Email;
            textBox_PhoneNumber1.Text = detailedEmployee.PhoneNumber.Substring(0, 3);
            textBox_PhoneNumber2.Text = detailedEmployee.PhoneNumber.Substring(4, 4);
            textBox_PhoneNumber3.Text = detailedEmployee.PhoneNumber.Substring(9, 4);
            dateTimePicker_HireDate.Text = detailedEmployee.HireDate.ToString("yyyy/MM/dd");
            InitializeDepartmentComboBox(detailedEmployee);
            InitializePositionComboBox(detailedEmployee);
            InitializeStatusComboBox(detailedEmployee);
        }

        // 部門名のコンボボックスのリストを作成・初期値を入力する
        public ComboBox InitializeDepartmentComboBox(Employees detailedEmployee)
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

        // 役職コンボボックスのリストを作成・初期値を入力する
        public ComboBox InitializePositionComboBox(Employees detailedEmployee)
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

        // テキストフォームの入力値を取得
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
            string hireDateValue = dateTimePicker_HireDate.Text;
            string departmentValue = comboBox_Department.Text;
            string positionValue = comboBox_Position.Text;
            string statusValue = comboBox_Status.Text;

            String[] updateData = { firstNameValue, lastNameValue, firstNameKanaValue, lastNameKanaValue, emailValue, phoneNumber1Value, phoneNumber2Value, phoneNumber3Value, hireDateValue, departmentValue, positionValue, statusValue };
            return updateData;
        }

        // 入力値が空かどうか取得する
        private void emptyChk(string[] updateData)
        {
            try
            {

                for (int i = 0; i < updateData.Length; i++)
                {
                    if (String.IsNullOrEmpty(updateData[i]) == true)
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
        private void wordCount(string[] updateData)
        {
            try
            {
                int[] limit = { 50, 50, 50, 50, 255, 3, 4, 4, 10, 6, 6, 3 };
                for (int i = 0; i < updateData.Length; i++)
                {
                    if (updateData[i].Length > limit[i])
                    {
                        // TODO contentの{1}がフォーマットされているか確認する
                        string content = string.Format("{0}は既定の文字数をオーバーしています。※{1}文字まで", updateData[i], limit[i]);
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
        private void kanaChk(string[] updateData)
        {
            try
            {
                for (int i = 2; i < 4; i++)
                {
                    if (Regex.IsMatch(updateData[i], @"^\p{IsHiragana}*$") == false)
                    {
                        string content = string.Format("{0}をひらがな入力してください", updateData[i]);
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
        private string phoneChk(string[] updateData)
        {
            try
            {
                String[] phoneNumberArray = { updateData[5], updateData[6], updateData[7] };
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
        private void mailChk(string[] updateData)
        {
            try
            {
                String[] strRequired = { "@", "." };
                foreach (String str in strRequired)
                {
                    if (updateData[4].Contains(str) == false)
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
        private DateTime calendarChk(string[] updateData)
        {
            try
            {
                DateTime hireDateValue = DateTime.Parse(updateData[8]);

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
        private int departmentComboBoxChk(string[] updateData)
        {
            try
            {
                // departmentIDが0の場合、データが存在しない
                String departmentValue = updateData[9];
                int departmentID = departmentList.Where(x => x.DepartmentName == departmentValue).Select(x => x.DepartmentID).FirstOrDefault();
                if (departmentID == 0)
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
        private int positionComboBoxChk(string[] updateData)
        {
            try
            {
                String positionValue = updateData[10];
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

        // ステータスコンボボックスに異なる値が入力されていないか確認する
        private int statusComboBoxChk(string[] updateData)
        {
            try
            {
                String statusValue = updateData[11];
                int statusID;
                if (statusValue == "在籍")
                {
                    statusID = 0;
                }
                else
                {
                    statusID= 1;
                }

                if (statusID != 0 && statusID != 1)
                {
                    throw new Exception("存在しないステータスを入力しています");
                }

                return statusID;
            }

            catch (Exception error)
            {
                throw error;
            }
        }

        // DBへ社員データを更新する
        public void submitUpdateEmployee(Employees detailedEmployee, String[] updateData, DateTime hireDateValue, string updatePhoneNumber, int updateDepartmentID, int updatePositionID, int updateStatusID)
        {
            // updateするデータの作成
            Employees updateEmployee = new Employees();
            updateEmployee.EmployeeID = detailedEmployee.EmployeeID;
            updateEmployee.FirstName = updateData[0];
            updateEmployee.LastName = updateData[1];
            updateEmployee.FirstNameKana = updateData[2];
            updateEmployee.LastNameKana = updateData[3];
            updateEmployee.Email = updateData[4];
            updateEmployee.PhoneNumber = updatePhoneNumber;
            updateEmployee.HireDate = hireDateValue;
            updateEmployee.Department = updateDepartmentID;
            updateEmployee.Position = updatePositionID;
            updateEmployee.Status = updateStatusID;

            var employeeService = new EmployeeService();
            employeeService.updateEmployeeData(updateEmployee);
        }

        // 更新フォームを閉じる
        private void closeUpdateForm()
        {
            this.Close();
            this.Dispose();
        }

        // 社員更新処理
        private void updateEmployee()
        {
            
            try
            {
            
                // 入力値を取得
                String[] updateData = getInputText();
                // エラーチェック
                emptyChk(updateData);
                wordCount(updateData);
                mailChk(updateData);
                kanaChk(updateData);
                DateTime hireDateValue = calendarChk(updateData);
                string updatePhoneNumber = phoneChk(updateData);
                int updateDepartmentID = departmentComboBoxChk(updateData);
                int updatePositionID = positionComboBoxChk(updateData);
                int updateStatusID = statusComboBoxChk(updateData);
                // データの作成・追加処理
                submitUpdateEmployee(detailedEmployee, updateData, hireDateValue, updatePhoneNumber, updateDepartmentID, updatePositionID, updateStatusID);

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
 

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateEmployee();
            MessageBox.Show("データを更新しました");
            // MainFormに反映
            mainForm.ResetDataGridView();
            closeUpdateForm();
            detailForm.closeDetailForm();
        }
    }
}
