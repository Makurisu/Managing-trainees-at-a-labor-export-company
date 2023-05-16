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
    public class DAL_Grade : DBConnect
    {
        public DataTable getGrade()
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT
                                                        gv.full_name AS giangvien_name,
                                                        c.id AS course_id,
                                                        c.course_name,
                                                        g.student_id,
                                                        g.quatrinh1,
                                                        g.quatrinh2,
                                                        g.giuaki,
                                                        g.cuoiki,
                                                        g.tongket
                                                    FROM
                                                        giangvien gv
                                                    JOIN courses c ON gv.id = c.id_giangvien
                                                    JOIN grades g ON c.id = g.course_id
                                                    WHERE
                                                        gv.id = 'GV0001';", conn);
            DataTable dtGrade = new DataTable();
            da.Fill(dtGrade);
            return dtGrade;
        }

        public DataTable getGradeById(string id)
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT c.id AS course_id,
                                                            c.course_name,
                                                            g.quatrinh1,
                                                            g.quatrinh2,
                                                            g.giuaki,
                                                            g.cuoiki
                                                        FROM
                                                            students s
                                                        JOIN
                                                            grades g ON s.id = g.student_id
                                                        JOIN
                                                            courses c ON g.course_id = c.id
                                                        WHERE
                                                            s.id = '"+id+"';", conn);
            DataTable dtGrade = new DataTable();
            da.Fill(dtGrade);
            return dtGrade;
        }

        public DataTable getGradeByTeacher(string id)
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT
                                                        c.id AS course_id,
                                                        c.course_name,
                                                        g.student_id,
                                                        g.quatrinh1,
                                                        g.quatrinh2,
                                                        g.giuaki,
                                                        g.cuoiki,
                                                        g.tongket
                                                    FROM
                                                        giangvien gv
                                                    JOIN courses c ON gv.id = c.id_giangvien
                                                    JOIN grades g ON c.id = g.course_id
                                                    WHERE
                                                        gv.id = 'GV0001';", conn);
            DataTable dtGrade = new DataTable();
            da.Fill(dtGrade);
            return dtGrade;
        }

        public bool suaGrade(DTO_Grade dtoGrade)
        {
            conn.Open();
            string sql = "exec updateGrade '" + dtoGrade.Student_id + "', '" + dtoGrade.Course_id + "','" + dtoGrade.Quatrinh1 + "','" + dtoGrade.Quatrinh2 + "','" + dtoGrade.Giuaki + "', '"+ dtoGrade.Cuoiki + "', '"+ dtoGrade.Tongket + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }

        public DataTable searchGrade(String type, String value)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM grade where " + type + " LIKE '" + value + "%'", conn);
            DataTable dtGrade = new DataTable();
            da.Fill(dtGrade);
            return dtGrade;
        }

    }
}
