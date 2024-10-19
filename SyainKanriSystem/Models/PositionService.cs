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
    public class PositionService
    {
        // 役職情報を取得する
        public List<Positions> SelectPositionData()
        {
            var DB = new DatabaseContext();
            var PositionRepository = new PositionRepository();
            NpgsqlConnection conn = DB.ConnectDB();
            try
            {
                String query = PositionRepository.MakeSelectQueryPosition();
                DataTable dt = DB.SqlExecute(query, conn);
                List<Positions> positionList = PositionRepository.GetSelectPosition(dt);
                return positionList;
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
