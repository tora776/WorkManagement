using Microsoft.VisualStudio.TestTools.UnitTesting;
using SyainKanriSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyainKanriSystem.Models.Tests
{
    [TestClass()]
    public class DepartmentRepositoryTests
    {
        [TestMethod()]
        public void MakeSelectQueryDepartmentTest()
        {
            var departmentRepository = new DepartmentRepository();
            departmentRepository.MakeSelectQueryDepartment();
        }
    }
}