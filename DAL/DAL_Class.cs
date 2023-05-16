using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Class : DBConnect
    {
        public DataTable getClass()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM courses", conn);
            DataTable dtClass = new DataTable();
            da.Fill(dtClass);
            return dtClass;
        }

        public DataTable getStudentClass(string id)
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT c.id, c.course_name, c.language, c.course_fee
                                                        FROM courses c
                                                        WHERE NOT EXISTS (
                                                            SELECT 1
                                                            FROM student_courses hvl
                                                            JOIN students hv ON hvl.student_id = hv.id
                                                            WHERE hvl.course_id = c.id AND hv.id = '"+id+"');", conn);
            DataTable dtClass = new DataTable();
            da.Fill(dtClass);
            return dtClass;
        }

        public bool themClass(DTO_Class dtoClass)
        {
            conn.Open();
            string sql = "exec InsertCourse '" + dtoClass.Class_teacher + "',N'" + dtoClass.Class_name + "',N'" + dtoClass.Class_language + "','" + dtoClass.Class_fee + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }

        public bool suaClass(DTO_Class dtoClass)
        {
            conn.Open();
            string sql = "exec updateClass '" + dtoClass.Class_id + "', N'" + dtoClass.Class_teacher + "',N'" + dtoClass.Class_name + "',N'" + dtoClass.Class_language + "','" + dtoClass.Class_fee + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }

        public bool xoaClass(DTO_Class dtoClass)
        {
            conn.Open();
            string check = "select * from student_courses where course_id = '" + dtoClass.Class_id + "'";
            SqlCommand checkCmd = new SqlCommand(check, conn);
            SqlDataReader reader = checkCmd.ExecuteReader();
            if (!reader.Read())
            {
                string sql = "exec DeleteCourse '" + dtoClass.Class_id + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                reader.Close();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    return true;
                }
            }
            conn.Close();
            return false;
        }
        public DataTable searchClass(String type, String value)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM courses where " + type + " LIKE '" + value + "%'", conn);
            DataTable dtClass = new DataTable();
            da.Fill(dtClass);
            return dtClass;
        }

        public string countClass()
        {
            string count = "0";
            conn.Open();
            string sql = "SELECT COUNT(*) FROM courses";
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
    }   
}
