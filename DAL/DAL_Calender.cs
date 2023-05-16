using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_Calender : DBConnect
    {
        public bool addEvent(DTO_Calender cld)
        {
            conn.Open();
            string check = "select * from calender where schedule = '" + cld.Calender_schedule + "'";
            SqlCommand checkCmd = new SqlCommand(check, conn);
            SqlDataReader reader = checkCmd.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                string sql = "exec updateEvent '" + cld.Calender_schedule + "',N'" + cld.Calender_event + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    return true;
                }
                conn.Close();
            }
            else
            {
                reader.Close();
                string sql = "exec InsertCalender '" + cld.Calender_schedule + "',N'" + cld.Calender_event + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    return true;
                }
                conn.Close();
            }
            return false;
        }

        public String showEvent(String date)
        {
            string events = string.Empty;
            conn.Open();
            string sql = "select * from calender where schedule = '" + date + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read()) { events = reader.GetString(1); }
            conn.Close();
            return events;
        }
    }
}
