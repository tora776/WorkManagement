using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyainKanriSystem
{
    public class Employees
    {
        public string EmployeeID { set; get; }
        public string Sei { set; get; }
        public string Mei { set; get; }
        public string SeiKana {  set; get; }
        public string MeiKana { set; get; }
        public string Email {  set; get; }
        public string PhoneNumber {  set; get; }
        public DateTime HireDate { set; get; }
        public int Department {  set; get; }
        public int Position { set; get; }
        public int Status { set; get; }
        }

    public class Departments
    {
        public int DepartmentID { set; get; }
        public string DepartmentName { set; get; }
        public string Location { set; get; }
    }

    public class Positions
    {
        public int PositionID { set; get; }
        public string PositionName { set; get; }
        public string Description { set; get; }
    }
}
