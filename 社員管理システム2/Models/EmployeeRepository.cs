using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 社員管理システム2.Models
{
    public class EmployeeRepository { 

        public DataTable sqlExecute(String query, NpgsqlConnection conn){
            NpgsqlCommand sql = new NpgsqlCommand(query, conn);
            DataTable tbl = new DataTable();
            using (NpgsqlDataReader reader = sql.ExecuteReader())
            {
                tbl.Load(reader);
            }
            return tbl;
        }

        public string makeSelectQuery(){
            try
            {
                string query = "SELECT Employees.EmployeeID, Employees.FirstName, Employees.LastName, \r\nEmployees.FirstNameKana, Employees.LastNameKana, Employees.Email, \r\nEmployees.PhoneNumber, Employees.HireDate, Departments.DepartmentName, \r\nPositions.PositionName, Employees.Status \r\nFROM Employees LEFT OUTER JOIN Departments ON Employees.department = Departments.departmentid LEFT OUTER JOIN Positions ON Employees.position = Positions.positionid;";
                return query;
            }
            catch (Exception)
            {
                throw;
            }
        }
    
    }
}
