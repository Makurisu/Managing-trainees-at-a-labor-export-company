using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Account : DBConnect
    {
        public int getType(string id, string password)
        {
            conn.Open();
            string sql = "SELECT type FROM account where username = '"+id+"' and password = '"+password+"'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                if (reader.GetString(0) == "student")
                {
                    conn.Close();
                    return 1;
                }
                else if (reader.GetString(0) == "teacher")
                {
                    conn.Close();
                    return 2;
                }
            }
            conn.Close();
            return 0;
        }

        public bool checkPassword(string username, string password, string newPass)
        {
            conn.Open();
            string sql = "SELECT password FROM account where username = '" + username + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(0) == password)
                {
                    string update = "UPDATE account set password = '" + newPass + "' WHERE username = '" + username + "'";
                    SqlCommand cmdUpdate = new SqlCommand(update, conn);
                    reader.Close();
                    if (cmdUpdate.ExecuteNonQuery() > 0)
                    {
                        conn.Close();
                        return true;
                    }
                }
            }
            conn.Close();
            return false;
        }
    }
}
