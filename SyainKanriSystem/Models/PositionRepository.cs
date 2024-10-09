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
    public class PositionRepository { 

        // SELECT文のクエリを実行する。
        
        public DataTable sqlExecutePosition(String query, NpgsqlConnection conn){
            NpgsqlCommand sql = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = sql.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
            }
        
            
        // SELECT文のクエリを作成する。
        public string makeSelectQueryPosition(){
            try
            {
                string query = "SELECT * FROM Positions";
                return query;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // 取得したクエリ結果を配列に格納する。
        public List<Positions> getSelectPosition(DataTable dt) {
            List<Positions> dataList = new List<Positions>();

            foreach(DataRow dr in dt.Rows)
            {             
                Positions position = new Positions();
                position.PositionID = int.Parse(dr[0].ToString());
                position.PositionName = dr[1].ToString();
                position.Description = dr[2].ToString();
                
                dataList.Add(position);
            }
            return dataList;
        }
    }
}

