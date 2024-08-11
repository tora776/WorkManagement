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
    public class DepartmentRepository { 

        // SELECT文のクエリを実行する。
        /*
        public DataTable sqlExecute(String query, NpgsqlConnection conn){
            NpgsqlCommand sql = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = sql.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
            }
        */
            
        // SELECT文のクエリを作成する。
        public string makeSelectQuery(){
            try
            {
                string query = "SELECT * FROM Departments";
                return query;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // 取得したクエリ結果を配列に格納する。
        public List<Departments> getSelectEmployee(DataTable dt) {
            List<Departments> dataList = new List<Departments>();

            foreach(DataRow dr in dt.Rows)
            {             
                Departments department = new Departments();
                department.DepartmentID = dr[0].ToString();
                department.DepartmentName = dr[1].ToString();
                department.Location = dr[2].ToString();
                
                dataList.Add(department);
            }
            return dataList;
        }
    }
}

