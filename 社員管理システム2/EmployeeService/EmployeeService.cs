using Microsoft.Data.SqlClient;
using Npgsql;
using SyainKanriSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyainKanriSystem
{
    public class EmployeeService
    {
        public void selectEmployeeData()
        {

        }

        public void insertEmployeeData(Employees addEmployee)
        {
            var DB = new DatabaseContext();
            var EmployeeReposiroty = new EmployeeRepository();
            
            try
            {
            
                NpgsqlConnection conn = DB.connectDB();
                String query = EmployeeReposiroty.GetMaxEmployeeIDQuery();
                DataTable dtMaxID = EmployeeReposiroty.sqlExecute(query, conn);
                if (dtMaxID.Rows.Count > 0)
                {
                    int maxEmployeeID = Convert.ToInt32(dtMaxID.Rows[0][0]);
                    int addEmployeeID = maxEmployeeID + 1;
                    string insertEmployeeID = addEmployeeID.ToString("000000");
                    addEmployee.EmployeeID = insertEmployeeID;
                }
                
                // DB.disconnectDB(conn);


                query = EmployeeReposiroty.makeInsertQuery(addEmployee);
                
                DataTable dt = EmployeeReposiroty.sqlExecute(query, conn);
                DB.disconnectDB(conn);              
            
            }
            catch (Exception error)
            {
                // DBに接続していれば切断する
                
                throw error;
            }
            
        }


    }
}
