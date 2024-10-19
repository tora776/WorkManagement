using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyainKanriSystem.Models
{
    public class DepartmentService
    {
        // 部門データを取得し、フロントエンドに伝える。
        public List<Departments> SelectDepartmentData()
        {
            var DB = new DatabaseContext();
            var DepartmentRepository = new DepartmentRepository();
            NpgsqlConnection conn = DB.ConnectDB();
            try
            {
                String query = DepartmentRepository.MakeSelectQueryDepartment();
                DataTable dt = DB.SqlExecute(query, conn);
                DB.DisconnectDB(conn);
                List<Departments> departmentList = DepartmentRepository.GetSelectDepartment(dt);
                return departmentList;
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
