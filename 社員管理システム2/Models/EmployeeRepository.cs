using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyainKanriSystem.Models
{
    public class EmployeeRepository { 

        public object sqlExecute(String query, NpgsqlConnection conn){
            NpgsqlCommand sql = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = sql.ExecuteReader();
            return reader;
            }
            

        public string makeSelectQuery(){
            try
            {
                string query = "SELECT * FROM Employees";
                return query;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object getSelectEmployee(IEnumerable<Type> reader) {
            var dataList = new List<object>();
            foreach (var item in reader) {
                Employees employee = new Employees();
                employee.EmployeeID = item.EmployeeID;
                employee.FirstName = item.FirstName;
                employee.LastName = item.LastName;
                employee.FirstNameKana = item.FirstNameKana;
                employee.LastNameKana = item.LastNameKana;
                employee.Email = item.Email;
                employee.PhoneNumber = item.PhoneNumber;
                employee.HireDate = item.HireDate;
                employee.Department = item.Department;
                employee.Positon = item.Positon;
                employee.Status = item.Status;

                dataList.Add(employee);
            }
            return dataList;
        }
    }
}

