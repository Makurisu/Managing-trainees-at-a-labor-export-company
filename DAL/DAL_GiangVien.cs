using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using System.Reflection.PortableExecutable;

namespace DAL
{
    public class DAL_GiangVien : DBConnect
    {
        public DataTable getGiangVien()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM giangvien", conn);
            DataTable dtGiangVien = new DataTable();
            da.Fill(dtGiangVien);
            return dtGiangVien;
        }

        public DataTable getGiangVienLanguage(String language)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM giangvien where language = N'"+language+"'", conn);
            DataTable dtGiangVien = new DataTable();
            da.Fill(dtGiangVien);
            return dtGiangVien;
        }

        public bool themGiangVien(DTO_GiangVien gv)
        {
            conn.Open();
            string sql = "exec InsertGiangVien N'" + gv.GiangVien_fullName + "','" + gv.GiangVien_dob + "',N'" + gv.GiangVien_gender + "',N'" + gv.GiangVien_address + "' , '"+gv.GiangVien_sdt+"', '"+gv.GiangVien_email+"', N'"+gv.GiangVien_language+"', '"+gv.GiangVien_pathImage+"' ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }

        public DataTable searchGiangVien(String type, String value)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM giangvien where " + type + " LIKE '" + value + "%'", conn);
            DataTable dtGiangVien = new DataTable();
            da.Fill(dtGiangVien);
            return dtGiangVien;
        }

        public bool xoaGiangVien(DTO_GiangVien gv)
        {
            conn.Open();
            string check = "select * from courses where giangvien_id = '" + gv.GiangVien_id + "'";
            SqlCommand checkCmd = new SqlCommand(check, conn);
            SqlDataReader reader = checkCmd.ExecuteReader();
            if (!reader.Read())
            {
                string sql = "exec DeleteContract '" + gv.GiangVien_id + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    return true;
                }
            }
            conn.Close();
            return false;
        }

        public bool suaGiangVien(DTO_GiangVien gv)
        {
            conn.Open();
            string sql = "exec UpdateStudent '" + gv.GiangVien_id + "', N'" + gv.GiangVien_fullName + "','" + gv.GiangVien_dob + "',N'" + gv.GiangVien_gender + "','" + gv.GiangVien_address + "','" + gv.GiangVien_sdt + "','" + gv.GiangVien_email + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }

        public List<DTO_GiangVien> getGiangVienIdName(String language)
        {
            conn.Open();
            string sql = "SELECT * FROM giangvien where language = N'" + language + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<DTO_GiangVien> giangvien = new List<DTO_GiangVien>();
            while (reader.Read())
            {
                giangvien.Add(new DTO_GiangVien
                {
                    GiangVien_id = reader.GetString(0),
                    GiangVien_fullName = reader.GetString(1)
                });
            }
            conn.Close();
            return giangvien;
        }
    }
}
