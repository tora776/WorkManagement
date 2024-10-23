using Microsoft.VisualStudio.TestTools.UnitTesting;
using SyainKanriSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SyainKanriSystem.Models.Tests
{
    [TestClass()]
    public class EmployeeRepositoryTests
    {
        [TestMethod()]
        public void MakeSelectQueryTest()
        {
            try
            {
                var employeeRepository = new EmployeeRepository();
                employeeRepository.MakeSelectQuery();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [DataRow("000001", "田中", "太郎", "たなか", "たろう", "aaa@ost.co.jp", "090-1111-1111", "2024/1/1", 1, 1, 0)]
        public void MakeInsertQueryTest(string employeeID, string sei, string mei, string seiKana, string meiKana, string email, string phoneNumber, string hireDate, int department, int position, int status)
        {
            Employees addEmployee = new Employees { EmployeeID = employeeID, Sei = sei, Mei = mei, SeiKana = seiKana, MeiKana = meiKana, Email = email, PhoneNumber = phoneNumber, HireDate = DateTime.Parse(hireDate), Department = department, Position = position, Status = status };
            var employeeRepository = new EmployeeRepository();
            employeeRepository.MakeInsertQuery(addEmployee);
        }

        [TestMethod()]
        public void GetMaxEmployeeIDQueryTest()
        {
            var employeeRepository = new EmployeeRepository();
            employeeRepository.GetMaxEmployeeIDQuery();
        }

        [TestMethod()]
        public void MakeDeleteQueryTest()
        {
            var employeeRepository = new EmployeeRepository();
            employeeRepository.MakeDeleteQuery("000001");
        }

        [TestMethod()]
        [DataRow("000001", "田中", "太郎", "たなか", "たろう", "aaa@ost.co.jp", "090-1111-1111", "2024/1/1", 1, 1, 0)]
        public void MakeUpdateQueryTest(string employeeID, string sei, string mei, string seiKana, string meiKana, string email, string phoneNumber, string hireDate, int department, int position, int status)
        {
            Employees updateEmployee = new Employees { EmployeeID = employeeID, Sei = sei, Mei = mei, SeiKana = seiKana, MeiKana = meiKana, Email = email, PhoneNumber = phoneNumber, HireDate = DateTime.Parse(hireDate), Department = department, Position = position, Status = status };
            var employeeRepository = new EmployeeRepository();
            employeeRepository.MakeInsertQuery(updateEmployee);
        }
        /*
        [TestMethod()]
        [DataRow("EmployeeID", "000001")]
        [DataRow("EmployeeID", "000001")]
        [DataRow("EmployeeID", "000001")]
        [DataRow("EmployeeID", "000001")]
        public void MakeSearchQueryTest(string searchComboValue, string searchTextValue)
        {
            
        }
        */
        
    }
}