using Microsoft.VisualStudio.TestTools.UnitTesting;
using SyainKanriSystem;
using SyainKanriSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyainKanriSystem.Tests
{
    [TestClass()]
    public class ViewsUtilTests
    {

        [TestMethod()]
        [DataRow("田中", 50)]
        [DataRow("太郎", 50)]
        [DataRow("たなか", 50)]
        [DataRow("たろう", 50)]
        [DataRow("tanaka-taro@gmail.com", 255)]
        [DataRow("090-1111-1111", 13)]
        [DataRow("2024/12/31", 11)]
        [DataRow("名古屋支部", 5)]
        [DataRow("TL", 5)]
        [DataRow("000003", 6)]
        [DataRow("退職済", 3)]
        public void WordCountTest(string hoge1, int hoge2)
        {
            try
            {
                if (ViewsUtil.WordCountCheck(hoge1, hoge2) == true)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
            }
            catch
            {
                Assert.Fail();
            }

        }

        [TestMethod()]
        [DataRow("あああああああああああああああああああああああああああああああああああああああああああああああああああ", 50)]
        [DataRow("あああああああああああああああああああああああああああああああああああああああああああああああああああ", 50)]
        [DataRow("あああああああああああああああああああああああああああああああああああああああああああああああああああ", 50)]
        [DataRow("あああああああああああああああああああああああああああああああああああああああああああああああああああ", 50)]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 255)]
        [DataRow("090-1111-11111", 13)]
        [DataRow("2024年12月310日", 11)]
        [DataRow("名古屋支部長", 5)]
        [DataRow("新規テスト役職", 5)]
        [DataRow("0000003", 6)]
        [DataRow("退職済み", 3)]
        public void WordCount_False(string hoge1, int hoge2)
        {
            try
            {
                if (ViewsUtil.WordCountCheck(hoge1, hoge2) == false)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
                return;
            }
            catch
            {
                Assert.Fail();
            }

        }

        [TestMethod()]
        [DataRow("000002")]
        public void EmployeeIDChkTest(string hoge)
        {
            try
            {
                if (ViewsUtil.EmployeeIDCheck(hoge) == true)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
                return;

            }
            catch
            {
                Assert.Fail();
            }

        }

        [TestMethod()]
        [DataRow("あ")]
        [DataRow("ア")]
        [DataRow("/")]
        [DataRow("2-2")]
        [DataRow("*")]
        public void EmployeeIDChkTest_False(string hoge)
        {
            try
            {
                if (ViewsUtil.EmployeeIDCheck(hoge) == false)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
                return;
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [DataRow("ア")]
        public void KanaChkTest(string hoge)
        {
            try
            {
                if (ViewsUtil.KanaCheck(hoge) == true)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
                return;
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [DataRow("あ")]
        [DataRow("a")]
        [DataRow("!")]
        public void KanaChkTest_CatchErrorCheck(string hoge)
        {
            try
            {
                if (ViewsUtil.KanaCheck(hoge) == false)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
            }
            catch
            {
                Assert.Fail();
                return;
            }
        }

        [TestMethod()]
        [DataRow("090")]
        public void PhoneChkTest(string hoge)
        {
            try
            {
                if (ViewsUtil.PhoneCheck(hoge) == true)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [DataRow("あ")]
        [DataRow("ア")]
        [DataRow("/")]
        [DataRow("2-2")]
        [DataRow("*")]
        public void PhoneChkTest_False(string hoge)
        {

            try
            {
                if (ViewsUtil.PhoneCheck(hoge) == false)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
            }
            catch
            {
                Assert.Fail();
            }

        }

        [TestMethod()]
        [DataRow("aaa@ost.co.jp")]
        public void MailJapaneseCheckTest(string hoge)
        {
            try
            {
                if (ViewsUtil.MailJapaneseCheck(hoge) == true)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [DataRow("あ")]
        [DataRow("ア")]
        [DataRow("号@ost.co.jp")]
        public void MailJapaneseCheckTest_False(string hoge)
        {
            try
            {
                if (ViewsUtil.MailJapaneseCheck(hoge) == false)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
            }
            catch
            {
                Assert.Fail();
            }
            // 例外が発生していない
            Assert.Fail();
        }

        [TestMethod()]
        [DataRow("aaa@gmail.com")]
        public void MailRequiredStrCheckTest(string hoge)
        {
            try
            {
                if (ViewsUtil.InputEmptyCheck(hoge) == true)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [DataRow("aaa@gmailcom")]
        [DataRow("aaagmail.com")]
        [DataRow("aaagmailcom")]
        public void MailRequiredStrCheckTest_False(string hoge)
        {
            try
            {
                if (ViewsUtil.InputEmptyCheck(hoge) == true)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [DataRow("aaa@gmail.com")]
        [DataRow("aaa_a@gmail.com")]
        [DataRow("aaa.a@gmail.com")]
        [DataRow("aaa12@gmail.com")]
        [DataRow("aaa-a@gmail.com")]
        public void MailSymbolCheckTest(string hoge)
        {
            try
            {
                if (ViewsUtil.MailSymbolCheck(hoge) == true)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
            }
            catch
            {
                Assert.Fail();
            }
        }


        [TestMethod()]
        [DataRow("aaa/a@gmail.com")]
        [DataRow("aaa\a@gmail.com")]
        [DataRow("aaa!2@gmail.com")]
        [DataRow("aa?a@gmail.com")]
        public void MailSymbolCheckTest_False(string hoge)
        {
            try
            {
                if (ViewsUtil.MailSymbolCheck(hoge) == false)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
            }
            catch
            {
                Assert.Fail();
            }
        }



        [TestMethod()]
        [DataRow("2024年")]
        [DataRow("2024年4月")]
        [DataRow("2024/04")]
        [DataRow("2024-04")]
        [DataRow("2024/04/01")]
        [DataRow("2024年4月1日")]
        [DataRow("2024年04月01日")]
        public void CalendarCheckTest(string hoge)
        {
            try
            {
                if (ViewsUtil.CalendarCheck(hoge) == true)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [DataRow("あ")]
        [DataRow("ア")]
        [DataRow("2024ねん")]
        [DataRow("2024/4!")]
        public void CalendarCheckTest_False(string hoge)
        {
            try
            {
                if (ViewsUtil.CalendarCheck(hoge) == false)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [DataRow("名古屋支部")]
        public void DepartmentCheckTest(string hoge)
        {
            try
            {
                var departmentService = new DepartmentService();
                List<Departments> departmentList = departmentService.SelectDepartmentData();
                if (ViewsUtil.DepartmentCheck(hoge, departmentList) != 0)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [DataRow("あ")]
        public void DepartmentCheckTest_False(string hoge)
        {
            try
            {
                var departmentService = new DepartmentService();
                List<Departments> departmentList = departmentService.SelectDepartmentData();
                if (ViewsUtil.DepartmentCheck(hoge, departmentList) == -1)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [DataRow("TL")]
        public void PositionCheckTest(string hoge)
        {
            try
            {
                var positionService = new PositionService();
                List<Positions> positionList = positionService.SelectPositionData();
                if (ViewsUtil.PositionCheck(hoge, positionList) != -1)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [DataRow("ＴＬ")]
        [DataRow("あ")]
        public void PositionCheckTest_False(string hoge)
        {
            try
            {
                var positionService = new PositionService();
                List<Positions> positionList = positionService.SelectPositionData();
                if (ViewsUtil.PositionCheck(hoge, positionList) == -1)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [DataRow("在籍")]
        [DataRow("退職済")]
        public void StatusCheckTest(string hoge)
        {
            try
            {
                if (ViewsUtil.StatusCheck(hoge) != -1)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [DataRow("あ")]
        [DataRow("退職")]
        public void StatusCheckTest_False(string hoge)
        {
            try
            {
                if (ViewsUtil.StatusCheck(hoge) == -1)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [DataRow("あ")]
        public void SpaceCheckTest(string hoge)
        {
            try
            {
                if (ViewsUtil.SpaceCheck(hoge) == true)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
            }
            catch
            {
                Assert.Fail();
            }

        }

        [TestMethod()]
        [DataRow("あ　")]
        [DataRow("あ ")]
        public void SpaceCheckTest_False(string hoge)
        {
            try
            {
                if (ViewsUtil.SpaceCheck(hoge) != true)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
            }
            catch
            {
                Assert.Fail();
            }
        }


        [TestMethod()]
        [DataRow("")]
        public void InputEmptyCheckTest(string hoge)
        {
            try
            {
                if (ViewsUtil.InputEmptyCheck(hoge) == false)
                {
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail();
            }
            catch
            {
                Assert.Fail();
            }
            // 例外が発生していない
            Assert.Fail();
        }
    }
}