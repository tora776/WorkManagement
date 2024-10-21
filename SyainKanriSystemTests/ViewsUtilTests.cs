using Microsoft.VisualStudio.TestTools.UnitTesting;
using SyainKanriSystem;
using SyainKanriSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [DataRow("tanaka-taro@ost.co.jp", 255)]
        [DataRow("090-1111-1111", 13)]
        [DataRow("2024/12/31", 11)]
        [DataRow("名古屋支部", 5)]
        [DataRow("TL", 5)]
        [DataRow("000003", 6)]
        [DataRow("退職済", 3)]
        public void WordCount_MainTest(string hoge1, int hoge2)
        {
            try
            {
                ViewsUtil.WordCountCheck(hoge1, hoge2);
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
                ViewsUtil.EmployeeIDCheck(hoge);
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
        public void EmployeeIDChkTest_CatchErrorCheck(string hoge)
        {
            try
            {
                ViewsUtil.EmployeeIDCheck(hoge);
            }
            catch
            {
                Assert.IsTrue(true);
                return;
            }
            // 例外が発生していない。
            Assert.Fail();
        }

        [TestMethod()]
        [DataRow("あ")]
        public void KanaChkTest(string hoge)
        {
            try
            {
                ViewsUtil.KanaCheck(hoge);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [DataRow("ア")]
        [DataRow("a")]
        [DataRow("!")]
        public void KanaChkTest_CatchErrorCheck(string hoge)
        {
            try
            {
                ViewsUtil.KanaCheck(hoge);
            }
            catch
            {
                Assert.IsTrue(true);
                return;
            }
            // 例外が発生していない
            Assert.Fail();
        }

        [TestMethod()]
        [DataRow("090")]
        public void PhoneChkTest(string hoge)
        {
            try
            {
                ViewsUtil.PhoneCheck(hoge);
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
        public void PhoneChkTest_CatchErrorCheck(string hoge)
        {
            try
            {
                ViewsUtil.PhoneCheck(hoge);
            }
            catch
            {
                Assert.IsTrue(true);
                return;
            }
            // 例外が発生していない
            Assert.Fail();
        }

        [TestMethod()]
        [DataRow("aaa@ost.co.jp")]
        public void MailCheckTest(string hoge)
        {
            try
            {
                ViewsUtil.MailCheck(hoge);
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
        [DataRow("aaa@ostcojp")]
        [DataRow("aaa.ostcojp")]
        [DataRow("aa,>?\a@ost.co.jp")]
        [DataRow("***@ost.co.jp")]
        public void MailCheckTest_CatchErrorCheck(string hoge)
        {
            try
            {
                ViewsUtil.MailCheck(hoge);
            }
            catch
            {
                Assert.IsTrue(true);
                return;
            }
            // 例外が発生していない
            Assert.Fail();
        }

        [TestMethod()]
        [DataRow("2024年")]
        [DataRow("2024年4月")]
        [DataRow("2024/04")]
        [DataRow("2024-04")]
        [DataRow("2024/04/01")]
        public void CalendarCheckTest(string hoge)
        {
            try
            {
                ViewsUtil.CalendarCheck(hoge);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [DataRow("あ")]
        [DataRow("ア")]

        public void CalendarCheckTest_CatchErrorCheck(string hoge)
        {
            try
            {
                ViewsUtil.CalendarCheck(hoge);
            }
            catch
            {
                Assert.IsTrue(true);
                return;
            }
            // 例外が発生していない
            Assert.Fail();
        }

        [TestMethod()]
        [DataRow("名古屋支部")]
        public void DepartmentCheckTest(string hoge)
        {
            try
            {
                var departmentService = new DepartmentService();
                List<Departments> departmentList = departmentService.SelectDepartmentData();
                ViewsUtil.DepartmentCheck(hoge, departmentList);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [DataRow("あ")]
        public void DepartmentCheckTest_CatchErrorCheck(string hoge)
        {
            try
            {
                var departmentService = new DepartmentService();
                List<Departments> departmentList = departmentService.SelectDepartmentData();
                ViewsUtil.DepartmentCheck(hoge, departmentList);
            }
            catch
            {
                Assert.IsTrue(true);
                return;
            }
            // 例外が発生していない
            Assert.Fail();
        }

        [TestMethod()]
        [DataRow("TL")]
        public void PositionCheckTest(string hoge)
        {
            try
            {
                var positionService = new PositionService();
                List<Positions> positionList = positionService.SelectPositionData();
                ViewsUtil.PositionCheck(hoge, positionList);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [DataRow("ＴＬ")]
        [DataRow("あ")]
        public void PositionCheckTest_CatchErrorCheck(string hoge)
        {
            try
            {
                var positionService = new PositionService();
                List<Positions> positionList = positionService.SelectPositionData();
                ViewsUtil.PositionCheck(hoge, positionList);
            }
            catch
            {
                Assert.IsTrue(true);
                return;
            }
            // 例外が発生していない
            Assert.Fail();
        }

        [TestMethod()]
        [DataRow("在籍")]
        [DataRow("退職済")]
        public void StatusCheckTest(string hoge)
        {
            try
            {
                ViewsUtil.StatusCheck(hoge);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [DataRow("あ")]
        [DataRow("退職")]
        public void StatusCheckTest_CatchErrorCheck(string hoge)
        {
            try
            {
                ViewsUtil.StatusCheck(hoge);
            }
            catch
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        [DataRow("あ")]
        public void SpaceCheckTest(string hoge)
        {
            try
            {
                ViewsUtil.SpaceCheck(hoge);
            }
            catch
            {
                Assert.Fail();
            }
            
        }

        [TestMethod()]
        [DataRow("あ　")]
        [DataRow("あ ")]
        public void SpaceCheckTest_CatchErrorCheck(string hoge)
        {
            try
            {
                ViewsUtil.SpaceCheck(hoge);
            }
            catch
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.Fail();
        }
    }
}