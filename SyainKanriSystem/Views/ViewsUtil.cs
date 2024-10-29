using SyainKanriSystem.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SyainKanriSystem
{
    public static class ViewsUtil
    {

        // 入力値が空かどうか取得する
        public static bool InputEmptyCheck(string checkData)
        {
            try
            {
                if (String.IsNullOrEmpty(checkData) != true)
                {
                    return true;
                }
                
                return false;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        // 文字数チェック
        // 入力文字数がDBの入力制限を超えていないか確認する
        public static bool WordCountCheck(string inputData, int limit)
        {
            bool ret = true;
            try
            {
                    if (inputData.Length > limit)
                    {
                        ret = false;
                    }
                    return ret;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                ret = false;
                return ret;
            }
        }        

        // 社員番号が数字か確認する
        // 6桁かどうかはwordCount_Mainで確認する
        public static bool EmployeeIDCheck(string checkData)
        {
            try
            {
                if (int.TryParse(checkData, out _) != true)
                {
                    MessageBox.Show("社員番号は6桁の数字を入力してください");
                    return false;
                }
                return true;

            }
            catch (Exception error)
            {
                throw error;
            }
        }

        // 姓（かな）・名（かな）が平仮名か確認する
        public static bool KanaCheck(string checkData)
        {
            try
            {
                    if (Regex.IsMatch(checkData, @"^\p{IsKatakana}*$") != true)
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

        // 入力値が数字か確認する
        // 電話番号を「xxx-xxxx-xxxx」の形に成形する
        // TODO 電話番号が指定の文字数を下回っていないことを確認
        public static bool PhoneCheck(string phoneNumber)
        {
            try
            {
                // 入力値が数字かどうか確認する
                if (int.TryParse(phoneNumber, out _) != true)
                    {
                        return false;
                    }
            }
            catch (Exception error)
            {
                throw error;
            }
            return true;
        }

        // メールアドレスのチェック
        public static bool MailJapaneseCheck(string email)
        {
            bool ret = true;
            try
            {
                // メールアドレスの日本語チェック
                bool isJapanese = Regex.IsMatch(email, @"[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]+");
                if (isJapanese == true)
                {
                    ret = false;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
            return ret;
        }

        // メールアドレスのチェック
        public static string MailRequiredStrCheck(string email)
        {
            // bool ret = true;
            try
            {
                String[] strRequired = { "@", "." };
                foreach (String str in strRequired)
                {
                    if (email.Contains(str) == false)
                    {
                        // string content = string.Format("メールアドレスに指定の文字（{0}）が入力されていません", str);
                        // throw new Exception(content);
                        // ret = false;
                        return str;
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
            return null;
        }

        public static bool MailSymbolCheck(string email)
        {
            bool ret = true;
            try
            {
                bool mailValidCheck = Regex.IsMatch(email, @"^[a-zA-Z0-9\-\._@]+$");
                if (mailValidCheck != true)
                {
                    ret = false;
                }
            }
            catch(Exception error)
            {
                throw error;
            }
            return ret;
        }
        /*
        public static bool MailDomainCheck(string email)
        {
            bool ret = true;
            try
            {
                // ドメインを正規化する(入力したメールアドレスのドメイン部分を正規表現に変換している)
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                //  メールのドメイン部分を調べ、正規化します。
                string DomainMapper(Match match)
                {
                    // IdnMappingクラスを使用してUnicodeドメイン名を変換します。
                    var idn = new IdnMapping();

                    // ドメイン名を引き出して処理する（無効な場合はArgumentExceptionをスローする）
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException error)
            {
                MessageBox.Show(error.Message);
                ret = false;
                return ret;
            }
            catch (ArgumentException error)
            {
                MessageBox.Show(error.Message);
                ret = false;
                return ret;
            }
        }
        */


        // TODO 日付以外のデータが入力されている場合、Catch部に移行するエラーを作成
        public static bool CalendarCheck(string checkData)
        {
            try
            {
                bool result = DateTime.TryParse(checkData, out DateTime _);
                if (result == false)
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

        // TODO 入力値が空の場合はemptyChk関数で精査できるので、この関数は不要？
        // 部門コンボボックスに異なる値が入力されていないか確認する
        public static int DepartmentCheck(string checkData, List<Departments> departmentList)
        {
            try
            {
                // departmentIDが0の場合、データが存在しない
                int departmentID = departmentList.Where(x => x.DepartmentName == checkData).Select(x => x.DepartmentID).FirstOrDefault();
                if (departmentID == 0)
                {
                    return -1;
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
        public static int PositionCheck(string checkData, List<Positions> positionList)
        {
            try
            {
                // IDが0の場合、データが存在しない
                int positionID = positionList.Where(x => x.PositionName == checkData).Select(x => x.PositionID).FirstOrDefault();
                if (positionID == 0)
                {
                    MessageBox.Show("存在しない役職名を入力しています");
                }

                return positionID;
            }

            catch (Exception error)
            {
                throw error;
            }
        }

        // ステータスコンボボックスに異なる値が入力されていないか確認する
        public static int StatusCheck(string checkData)
        {
            try
            {
                int statusID;
                if (checkData == "在籍")
                {
                    statusID = 0;
                }
                else if (checkData == "退職済")
                {
                    statusID = 1;
                }
                else
                {
                    // 0か1ではない数字を返す。return後、falseとなる。
                    return -1;
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

        public static bool SpaceCheck(string checkData)
        {
            bool ret = true;
            // 半角・全角スペースを含むかチェックする正規表現
            string pattern = @"[\u0020\u3000]";

            if (Regex.IsMatch(checkData, pattern))
            {
                // MessageBox.Show("半角または全角スペースが含まれています");
                ret = false;
            }
            return ret;
        }

        /*
        public static void SymbolCheck(string checkData)
        {
            // string str = @"[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}A-Za-z･]";
            // bool res = Regex.IsMatch(checkData, str);
        }
        */

    }
}
