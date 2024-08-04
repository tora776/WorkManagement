using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 社員管理システム2
{
    internal class Employees
    {
        public char EmployeeID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string FirstNameKana {  set; get; }
        public string LastNameKana { set; get; }
        public string Email {  set; get; }
        public char PhoneNumber {  set; get; }
        public DateTime HireDate { set; get; }
        public int Department {  set; get; }
        public int Positon { set; get; }
        public int Status { set; get; }
        }
    }
