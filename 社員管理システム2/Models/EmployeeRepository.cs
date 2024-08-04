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
                string query = "SELECT * FROM Employees";
                return query;
            }
            catch (Exception)
            {
                throw;
            }
        }
    
    }
}
