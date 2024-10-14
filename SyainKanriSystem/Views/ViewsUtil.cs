using SyainKanriSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyainKanriSystem
{
    public static class ViewsUtil
    {

        // 入力値が空かどうか取得する
        public static bool EmptyChk(string chkData)
        {
            try
            {
                if (String.IsNullOrEmpty(chkData) == true)
                {
                    throw new Exception("入力されていないテキストボックスがあります");
                }
                
                return true;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        // 文字数チェック
        // 入力文字数がDBの入力制限を超えていないか確認する
        public static void WordCount(string chkData, int limit)
        {
            try
            {
                    if (chkData.Length > limit)
                    {
                        // TODO contentの{1}がフォーマットされているか確認する
                        string content = string.Format("{0}は既定の文字数をオーバーしています。※{1}文字まで", chkData, limit);
                        throw new Exception(content);
                    }
                
            }
            catch (Exception error)
            {
                throw error;
            }
        }        

        // 社員番号が数字か確認する
        // 6桁かどうかはwordCount_Mainで確認する
        public static void EmployeeIDChk(string chkData)
        {
            try
            {
                bool result = int.TryParse(chkData, out _);
                if (result == false)
                {
                    throw new Exception("社員番号は6桁の数字を入力してください");
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        // 姓（かな）・名（かな）が平仮名か確認する
        public static void KanaChk(string chkData)
        {
            try
            {
                    if (Regex.IsMatch(chkData, @"^\p{IsHiragana}*$") == false)
                    {
                        string content = string.Format("{0}をひらがな入力してください", chkData);
                        throw new Exception(content);
                    }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        // 入力値が数字か確認する
        // 電話番号を「xxx-xxxx-xxxx」の形に成形する
        // TODO 電話番号が指定の文字数を下回っていないことを確認
        public static void PhoneChk(string phoneNumber)
        {
            try
            {
                // 入力値が数字かどうか確認する
                bool result = int.TryParse(phoneNumber, out _);
                if (result == false)
                    {
                        throw new Exception("電話番号には数字を記載してください");
                    }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        // 入力値に「@」「.」が含まれているか確認する
        public static void MailChk(string chkData)
        {
            try
            {
                String[] strRequired = { "@", "." };
                foreach (String str in strRequired)
                {
                    if (chkData.Contains(str) == false)
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

        // TODO 日付以外のデータが入力されている場合、Catch部に移行するエラーを作成
        public static DateTime CalendarChk(string chkData)
        {
            try
            {
                DateTime hireDateValue = DateTime.Parse(chkData);

                return hireDateValue;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        // TODO 入力値が空の場合はemptyChk関数で精査できるので、この関数は不要？
        // 部門コンボボックスに異なる値が入力されていないか確認する
        public static int DepartmentChk(string chkData, List<Departments> departmentList)
        {
            try
            {
                // departmentIDが0の場合、データが存在しない
                int departmentID = departmentList.Where(x => x.DepartmentName == chkData).Select(x => x.DepartmentID).FirstOrDefault();
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

        // TODO 入力値が空の場合はemptyChk関数で精査できるので、この関数は不要？
        // 役職コンボボックスに異なる値が入力されていないか確認する
        public static int PositionChk(string chkData, List<Positions> positionList)
        {
            try
            {
                int positionID = positionList.Where(x => x.PositionName == chkData).Select(x => x.PositionID).FirstOrDefault();
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
        public static int StatusChk(string chkData)
        {
            try
            {
                int statusID;
                if (chkData == "在籍")
                {
                    statusID = 0;
                }
                else if (chkData == "退職済")
                {
                    statusID = 1;
                }
                else
                {
                    throw new Exception("ステータスは「在籍」か「退職済」と入力してください");
                }

                return statusID;
            }

            catch (Exception error)
            {
                throw error;
            }
        }

        // 部門コンボボックスにDBから取得した値を格納する
        public static ComboBox InitializeDepartmentComboBox(ComboBox comboBox_Department, List<Departments> departmentList)
        {
            try
            {
                // コンボボックスに表示と値をセット
                comboBox_Department.DataSource = departmentList;
                comboBox_Department.DisplayMember = "DepartmentName";
                comboBox_Department.ValueMember = "DepartmentId";

                return comboBox_Department;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        // 役職コンボボックスにDBから取得した値を格納する
        public static ComboBox InitializePositionComboBox(ComboBox comboBox_Position, List<Positions> positionList)
        {
            try
            {
                // コンボボックスに表示と値をセット
                comboBox_Position.DataSource = positionList;
                comboBox_Position.DisplayMember = "PositionName";
                comboBox_Position.ValueMember = "PositionId";

                return comboBox_Position;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
