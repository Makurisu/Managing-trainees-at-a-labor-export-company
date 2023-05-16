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
    public class DAL_studentCourses : DBConnect
    {
        public DataTable getStudentCourses(string id)
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT courses.id, courses.course_name, courses.language, courses.course_fee, st_courses.status
                                                        FROM student_courses st_courses
                                                            JOIN courses ON st_courses.course_id = courses.id
                                                                WHERE st_courses.student_id = '" + id+"'", conn);
            DataTable dtStudentCourses = new DataTable();
            da.Fill(dtStudentCourses);
            return dtStudentCourses;
        }

        public DataTable getDetailStudentCourses()
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT student_id, courses.id, courses.id_giangvien, courses.course_name, courses.language, courses.course_fee, st_courses.status
                                                        FROM student_courses st_courses
                                                            JOIN courses ON st_courses.course_id = courses.id", conn);
            DataTable dtStudentCourses = new DataTable();
            da.Fill(dtStudentCourses);
            return dtStudentCourses;
        }

        public bool themStudentCourses(DTO_studentCourses studentCourses)
        {
            conn.Open();
            string sql = "exec EnrollStudentInCourse '" + studentCourses.Student_id + "', '" + studentCourses.Courses_id + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }

        public bool xoaStudentCourses(DTO_studentCourses studentCourses)
        {
            conn.Open();
            string sql = "exec RemoveStudentFromCourse '" + studentCourses.Student_id + "', '"+ studentCourses.Courses_id+ "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }

        public DataTable searcStudentCourses(String type, String value)
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT student_id, courses.id, courses.id_giangvien, courses.course_name, courses.language, courses.course_fee, st_courses.status
                                                        FROM student_courses st_courses
                                                            JOIN courses ON st_courses.course_id = courses.id
                                                              WHERE "+type+" LIKE '%"+value+"%' ", conn);
            DataTable dtStudentCourses = new DataTable();
            da.Fill(dtStudentCourses);
            return dtStudentCourses;
        }

        public DataTable searcStudentCourses(String id, String type, String value)
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT courses.id, courses.course_name, courses.language, courses.course_fee, st_courses.status
                                                        FROM student_courses st_courses
                                                            JOIN courses ON st_courses.course_id = courses.id
                                                                WHERE st_courses.student_id = '"+id+"' and "+type+" LIKE '%"+value+"%'", conn);
            DataTable dtStudentCourses = new DataTable();
            da.Fill(dtStudentCourses);
            return dtStudentCourses;
        }
    }
}
