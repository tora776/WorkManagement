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
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string FirstNameKana {  set; get; }
        public string LastNameKana { set; get; }
        public string Email {  set; get; }
        public string PhoneNumber {  set; get; }
        public DateTime HireDate { set; get; }
        public int Department {  set; get; }
        public int Positon { set; get; }
        public int Status { set; get; }
        }

    public class Departments
    {
        public string DepartmentID { set; get; }
        public string DepartmentName { set; get; }
        public string Location { set; get; }
    }

    public class Positions
    {
        public string PositionID { set; get; }
        public string PositionName { set; get; }
        public string Description { set; get; }
    }
}
