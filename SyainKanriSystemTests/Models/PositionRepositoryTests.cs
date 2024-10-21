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
    public class PositionRepositoryTests
    {
        [TestMethod()]
        public void MakeSelectQueryPositionTest()
        {
            var positionRepository = new PositionRepository();
            positionRepository.MakeSelectQueryPosition();
        }
    }
}