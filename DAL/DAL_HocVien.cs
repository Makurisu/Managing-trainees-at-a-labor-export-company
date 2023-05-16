using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;
using System.Xml.Linq;

namespace DAL
{
    public class DAL_HocVien : DBConnect
    {
        public DataTable getHocVien()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM students", conn);
            DataTable dtHocVien = new DataTable();
            da.Fill(dtHocVien);
            return dtHocVien;
        }

        public DataTable getHocVien(string id)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM students WHERE id = '"+id+"'", conn);
            DataTable dtHocVien = new DataTable();
            da.Fill(dtHocVien);
            return dtHocVien;
        }

        public bool themHocVien(DTO_Hocvien hv) 
        {
            conn.Open();
            string sql = "exec InsertStudent N'" + hv.Hocvien_fullName + "','"+hv.Hocvien_dob+"',N'"+hv.Hocvien_gender+"',N'"+hv.Hocvien_address+"','"+hv.Hocvien_sdt+"','"+hv.Hocvien_email+"', '"+hv.Hocvien_pathImage+"' ,'"+hv.Hocvien_dpv+"'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }

        public string getNameHocVien(string id)
        {
            string name = string.Empty;
            conn.Open();
            string sql = "SELECT full_name FROM students WHERE id = '" + id + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) 
            { 
                name = reader.GetString(0);
                conn.Close();
                return name;
            }
            conn.Close();
            return name;
        }

        public string countHocVien()
        {
            string count = "0";
            conn.Open();
            string sql = "SELECT COUNT(*) FROM students";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                count = reader.GetInt32(0).ToString();
                conn.Close();
                return count;
            }
            conn.Close();
            return count;
        }

        public DataTable searchHocVien(String type, String value)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM students where "+type+" LIKE '"+value+"%'", conn);
            DataTable dtHocVien = new DataTable();
            da.Fill(dtHocVien);
            return dtHocVien;
        }

        public bool getStatusHocVien(String id)
        {
            conn.Open();
            string sql = "SELECT status FROM students WHERE id = '" + id + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if(reader.GetString(0) == "Đã đào tạo")
                {
                    conn.Close();
                    return true;
                }    
            }
            conn.Close();
            return false;
        }

        public bool xoaHocVien(String id)
        {
            conn.Open();
            string sql = "exec DeleteStudent '" + id + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }    
            conn.Close();
            return false;
        }

        public bool suaHocVien(DTO_Hocvien hv)
        {
            conn.Open();
            string sql = "exec UpdateStudent '" + hv.Hocvien_id + "', N'" + hv.Hocvien_fullName + "','" + hv.Hocvien_dob + "',N'" + hv.Hocvien_gender + "','" + hv.Hocvien_address + "','" + hv.Hocvien_sdt + "','" + hv.Hocvien_email + "','" + hv.Hocvien_dpv + "', '"+hv.Hocvien_pathImage+"', N'"+hv.Hocvien_status+"'";
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
