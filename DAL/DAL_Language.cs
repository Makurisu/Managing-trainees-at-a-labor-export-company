using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Language : DBConnect
    {
        public DataTable getLanguage()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM languages", conn);
            DataTable dtLanguage = new DataTable();
            da.Fill(dtLanguage);
            return dtLanguage;
        }
    }
}
