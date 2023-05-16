using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_Notice : DBConnect
    {
        public DataTable getNotice()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 5 * FROM notice ORDER BY date_post DESC", conn);
            DataTable dtNotice = new DataTable();
            da.Fill(dtNotice);
            return dtNotice;
        }

        public bool themNotice(DTO_Notice notice)
        {
            conn.Open();
            string sql = "exec InsertStudent N'" + notice.Notice + "','" + notice.DatePost + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }
    }
}
