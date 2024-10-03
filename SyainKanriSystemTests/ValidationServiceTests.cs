using Microsoft.VisualStudio.TestTools.UnitTesting;
using 社員管理システム2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 社員管理システム2.Tests
{
    [TestClass()]
    public class ValidationServiceTests
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
        public void wordCount_MainTest(string hoge1, int hoge2)
        {
            try
            {
                var validationService = new ValidationService();
                validationService.wordCount_Main(hoge1, hoge2);
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
        [DataRow("2/2")]
        [DataRow("*")]
        public void employeeIDChkTest_CatchError(string hoge)
        {
            try
            {
                var validationService = new ValidationService();
                validationService.employeeIDChk(hoge);
                Assert.Fail();
            }
            catch (Exception ex)
            {

            }
        }

        [TestMethod()]
        [DataRow("あ")]
        public void kanaChkTest(string hoge)
        {
            try
            {
                var validationService = new ValidationService();
                validationService.kanaChk(hoge);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [DataRow("ア")]
        [DataRow("a")]
        [DataRow("!")]
        public void kanaChkTest_CatchError(string hoge)
        {
            try
            {
                var validationService = new ValidationService();
                validationService.kanaChk(hoge);
                Assert.Fail();
            }
            catch (Exception ex)
            {

            }
        }

        [TestMethod()]
        [DataRow("h", "h", "h", "h", "h", "h", "h", "h", "h", "h", "h")]
        public void wordCount_AddTest(string hoge1, string hoge2, string hoge3, string hoge4, string hoge5, string hoge6, string hoge7, string hoge8, string hoge9, string hoge10, string hoge11) { 
            try
            {
                string[] testData = { hoge1, hoge2, hoge3, hoge4, hoge5, hoge6, hoge7, hoge8, hoge9, hoge10, hoge11 };
                var validationService = new ValidationService();
                validationService.wordCount_Add(testData);
                Assert.Fail();
            }
            catch
            {
                
            }
        }
    }
}