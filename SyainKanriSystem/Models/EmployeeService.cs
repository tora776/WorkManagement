﻿using Npgsql;
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
        // 社員データを取得し、フロントエンドに伝える。
        public List<Employees> SelectEmployeeData()
        {
            var DB = new DatabaseContext();
            var employeeReposiroty = new EmployeeRepository();
            NpgsqlConnection conn = DB.ConnectDB();
            try
            {
                String query = employeeReposiroty.MakeSelectQuery();
                DataTable dt = DB.SqlExecute(query, conn);
                List<Employees> employeeList = employeeReposiroty.GetSelectEmployee(dt);
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
                    DB.DisconnectDB(conn);
                }
            }
        }

        // DBにInsert文のクエリを送り、社員データを追加する。
        public void InsertEmployeeData(Employees addEmployee)
        {
            var DB = new DatabaseContext();
            var employeeReposiroty = new EmployeeRepository();
            NpgsqlConnection conn = DB.ConnectDB();

            try
            {
                String query = employeeReposiroty.GetMaxEmployeeIDQuery();
                DataTable dtMaxID = DB.SqlExecute(query, conn);
                if (dtMaxID.Rows.Count > 0)
                {
                    int maxEmployeeID = Convert.ToInt32(dtMaxID.Rows[0][0]);
                    int addEmployeeID = maxEmployeeID + 1;
                    string insertEmployeeID = addEmployeeID.ToString("000000");
                    addEmployee.EmployeeID = insertEmployeeID;
                }
                // Insert文を作成
                query = employeeReposiroty.MakeInsertQuery(addEmployee);
                // クエリを実行
                DB.SqlExecute(query, conn);              
            
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
                    DB.DisconnectDB(conn);
                }
            }
            
        }

        // DBにDelete文のクエリを送り、社員データを削除する。
        public void DeleteEmployeeData(string deleteEmployeeID)
        {
            var DB = new DatabaseContext();
            var employeeReposiroty = new EmployeeRepository();
            NpgsqlConnection conn = DB.ConnectDB();

            try
            {
                // Delete文を作成
                string query = employeeReposiroty.MakeDeleteQuery(deleteEmployeeID);
                // クエリを実行
                DB.SqlExecute(query, conn);

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
                    DB.DisconnectDB(conn);
                }
            }

        }

        // DBにUpdate文のクエリを送り、社員データを更新する
        public void UpdateEmployeeData(Employees updateEmployee)
        {
            var DB = new DatabaseContext();
            var employeeReposiroty = new EmployeeRepository();
            NpgsqlConnection conn = DB.ConnectDB();

            try
            {
                // Update文を作成
                string query = employeeReposiroty.MakeUpdateQuery(updateEmployee);
                // クエリを実行
                DB.SqlExecute(query, conn);

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
                    DB.DisconnectDB(conn);
                }
            }
        }

        // DBに検索処理のSelect文のクエリを送り、社員データを検索し、フロントエンドに伝える。
        public List<Employees> SearchEmployeeData(List<string> searchComboStr, List<string> searchTextStr)
        {
            var DB = new DatabaseContext();
            var employeeReposiroty = new EmployeeRepository();
            NpgsqlConnection conn = DB.ConnectDB();
            try
            {
                string query = employeeReposiroty.MakeSearchQuery(searchComboStr, searchTextStr);
                DataTable dt = DB.SqlExecute(query, conn);
                List<Employees> employeeList = employeeReposiroty.GetSelectEmployee(dt);
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
                    DB.DisconnectDB(conn);
                }
            }
        }



    }
}
