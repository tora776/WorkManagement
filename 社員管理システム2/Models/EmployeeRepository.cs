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

    public class EmployeeRepository
    {


        // SELECT文のクエリを実行する。
        public DataTable sqlExecute(String query, NpgsqlConnection conn)
        {
            NpgsqlCommand sql = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = sql.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }

        // SELECT文のクエリを作成する。
        public string makeSelectQuery()
        {
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

        // 取得したクエリ結果を配列に格納する。
        public List<Employees> getSelectEmployee(DataTable dt)
        {
            List<Employees> dataList = new List<Employees>();
            // 社員リストを作成
            foreach (DataRow dr in dt.Rows)
            {
                Employees employee = new Employees();
                employee.EmployeeID = dr[0].ToString();
                employee.FirstName = dr[1].ToString();
                employee.LastName = dr[2].ToString();
                employee.FirstNameKana = dr[3].ToString();
                employee.LastNameKana = dr[4].ToString();
                employee.Email = dr[5].ToString();
                employee.PhoneNumber = dr[6].ToString();
                employee.HireDate = DateTime.Parse(dr[7].ToString());
                employee.Department = int.Parse(dr[8].ToString());
                employee.Position = int.Parse(dr[9].ToString());
                employee.Status = int.Parse(dr[10].ToString());
                dataList.Add(employee);
            }
            return dataList;
        }

        // Insert文のクエリを作成する。
        public string makeInsertQuery(Employees addEmployee)
        {
            try
            {
                string query = $@"INSERT INTO Employees (EmployeeID, FirstName, LastName, FirstNameKana, LastNameKana, Email, PhoneNumber, HireDate, Department, Position, Status) VALUES ('{addEmployee.EmployeeID}', '{addEmployee.FirstName}', '{addEmployee.LastName}', '{addEmployee.FirstNameKana}', '{addEmployee.LastNameKana}', '{addEmployee.Email}', '{addEmployee.PhoneNumber}', '{addEmployee.HireDate.ToString("yyyyMMdd")}', {addEmployee.Department}, {addEmployee.Position}, {addEmployee.Status})";
                return query;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Insert文の処理にて社員番号の最大値を取得する
        public string GetMaxEmployeeIDQuery()
        {

            try
            {
                string query = "SELECT Max(CAST(EmployeeID as INTEGER)) FROM Employees";
                return query;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string makeDeleteQuery(string deleteEmployeeID)
        {
            try
            {
                string query = $@"DELETE FROM Employees WHERE employeeid ='{deleteEmployeeID}'";
                return query;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string makeUpdateQuery(Employees updateEmployee)
        {
            try
            {
                string query = $@"UPDATE Employees SET (FirstName, LastName, FirstNameKana, LastNameKana, Email, PhoneNumber, HireDate, Department, Position, Status) = ('{updateEmployee.FirstName}', '{updateEmployee.LastName}', '{updateEmployee.FirstNameKana}', '{updateEmployee.LastNameKana}', '{updateEmployee.Email}', '{updateEmployee.PhoneNumber}', '{updateEmployee.HireDate.ToString("yyyyMMdd")}', {updateEmployee.Department}, {updateEmployee.Position}, {updateEmployee.Status}) WHERE employeeid ='{updateEmployee.EmployeeID}'";
                return query;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string makeSearchQuery(List<string> searchComboStr, List<string> searchTextStr)
        {
            try
            {
                string conditionQuery = null;
                // 条件式を作成
                for (int i = 0; i < searchComboStr.Count; i++)
                {
                    // TODO int型の場合クォーテーションは不要。switch-case文で場合分けする？int-TryParseできるなら？
                    if(conditionQuery == null)
                    {
                        conditionQuery = $@"Where {searchComboStr[i]} = '{searchTextStr[i]}' "; 
                    }
                    else
                    {
                        conditionQuery = conditionQuery + $@"AND {searchComboStr[i]} = '{searchTextStr[i]}'";
                    }
                }

                string query = "SELECT * FROM Employees " + conditionQuery;
                return query;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
