﻿using Npgsql;
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

        public DataTable sqlExecute(String query, NpgsqlConnection conn){
            NpgsqlCommand sql = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = sql.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
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

        public List<object> getSelectEmployee(DataTable dt) {
            var dataList = new List<object>();

            foreach(DataRow dr in dt.Rows)
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
                employee.Positon = int.Parse(dr[9].ToString());
                employee.Status = int.Parse(dr[10].ToString());
                dataList.Add(employee);
            }
            return dataList;
        }
    }
}

