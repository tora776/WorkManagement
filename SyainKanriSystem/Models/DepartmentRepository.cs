using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SyainKanriSystem;

namespace SyainKanriSystem.Models
{
    public class DepartmentRepository { 
       
        // SELECT文のクエリを作成する。
        public string MakeSelectQueryDepartment(){
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
        

        // クエリの実行結果を取得する。
        public List<Departments> GetSelectDepartment(DataTable dt) {
            List<Departments> dataList = new List<Departments>();

            foreach(DataRow dr in dt.Rows)
            {
                Departments department = new Departments();
                department.DepartmentID = int.Parse(dr[0].ToString());
                department.DepartmentName = dr[1].ToString();
                department.Location = dr[2].ToString();
                
                dataList.Add(department);
            }
            return dataList;
        }
    }
}

