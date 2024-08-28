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
        public List<Employees> selectEmployeeData()
        {
            var DB = new DatabaseContext();
            var EmployeeReposiroty = new EmployeeRepository();
            NpgsqlConnection conn = DB.connectDB();
            try
            {
                String query = EmployeeReposiroty.makeSelectQuery();
                DataTable dt = EmployeeReposiroty.sqlExecute(query, conn);
                List<Employees> employeeList = EmployeeReposiroty.getSelectEmployee(dt);
                return employeeList;

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return null;
            }
            finally
            {
                // DBに接続していれば切断する
                if (conn != null)
                {
                    DB.disconnectDB(conn);
                }
            }
        }

        public void insertEmployeeData(Employees addEmployee)
        {
            var DB = new DatabaseContext();
            var EmployeeReposiroty = new EmployeeRepository();
            NpgsqlConnection conn = DB.connectDB();

            try
            {
                String query = EmployeeReposiroty.GetMaxEmployeeIDQuery();
                DataTable dtMaxID = EmployeeReposiroty.sqlExecute(query, conn);
                if (dtMaxID.Rows.Count > 0)
                {
                    int maxEmployeeID = Convert.ToInt32(dtMaxID.Rows[0][0]);
                    int addEmployeeID = maxEmployeeID + 1;
                    string insertEmployeeID = addEmployeeID.ToString("000000");
                    addEmployee.EmployeeID = insertEmployeeID;
                }
                // Insert文を作成
                query = EmployeeReposiroty.makeInsertQuery(addEmployee);
                // クエリを実行
                EmployeeReposiroty.sqlExecute(query, conn);              
            
            }
            catch (Exception error)
            {                
                throw error;
            }
            finally
            {
                // DBに接続していれば切断する
                if (conn != null)
                {
                    DB.disconnectDB(conn);
                }
            }
            
        }

        public void deleteEmployeeData(string deleteEmployeeID)
        {
            var DB = new DatabaseContext();
            var EmployeeReposiroty = new EmployeeRepository();
            NpgsqlConnection conn = DB.connectDB();

            try
            {
                // Delete文を作成
                string query = EmployeeReposiroty.makeDeleteQuery(deleteEmployeeID);
                // クエリを実行
                EmployeeReposiroty.sqlExecute(query, conn);

            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                // DBに接続していれば切断する
                if (conn != null)
                {
                    DB.disconnectDB(conn);
                }
            }

        }

        public void updateEmployeeData(Employees updateEmployee)
        {
            var DB = new DatabaseContext();
            var EmployeeReposiroty = new EmployeeRepository();
            NpgsqlConnection conn = DB.connectDB();

            try
            {
                // Update文を作成
                string query = EmployeeReposiroty.makeUpdateQuery(updateEmployee);
                // クエリを実行
                EmployeeReposiroty.sqlExecute(query, conn);

            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                // DBに接続していれば切断する
                if (conn != null)
                {
                    DB.disconnectDB(conn);
                }
            }

        }



    }
}
