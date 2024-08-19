using Npgsql;
using SyainKanriSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyainKanriSystem
{
    public class EmployeeService
    {
        public void selectEmployeeData()
        {

        }

        public void insertEmployeeData(Array insertData)
        {
            var DB = new DatabaseContext();
            var EmployeeReposiroty = new EmployeeRepository();
            /*
            try
            {
            */
                NpgsqlConnection conn = DB.connectDB();
                String query = EmployeeReposiroty.GetMaxEmployeeIDQuery();
                DataTable dtMaxID = EmployeeReposiroty.sqlExecute(query, conn);
                DataRow[] dr = dtMaxID.Select("max");
                int addEmployeeID = int.Parse(dr[0].ToString()) + 1;
                string insertEmployeeID = addEmployeeID.ToString("000000");
                DB.disconnectDB(conn);


                query = EmployeeReposiroty.makeInsertQuery(insertData, insertEmployeeID);
                /*
                DataTable dt = EmployeeReposiroty.sqlExecute(query, conn);
                DB.disconnectDB(conn);
                List<Employees> employeeList = EmployeeReposiroty.getSelectEmployee(dt);
                */

            /*
            }
            catch (Exception error)
            {
                throw error;
            }
            */
        }


    }
}
