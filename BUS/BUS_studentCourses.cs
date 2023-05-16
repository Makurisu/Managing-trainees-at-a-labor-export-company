using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_studentCourses
    {
        DAL_studentCourses dalStudentCourses = new DAL_studentCourses();
        public DataTable getStudentCourses(string id)
        {
            return dalStudentCourses.getStudentCourses(id);
        }

        public DataTable getDetailStudentCourses()
        {
            return dalStudentCourses.getDetailStudentCourses();
        }

        public bool themStudentCourses(DTO_studentCourses studentCourses)
        {
            return dalStudentCourses.themStudentCourses(studentCourses);
        }

        public bool xoaStudentCourses(DTO_studentCourses studentCourses)
        {
            return dalStudentCourses.xoaStudentCourses(studentCourses);
        }

        public DataTable searcStudentCourses(String id, String type, String value)
        {
            return dalStudentCourses.searcStudentCourses(id, type, value);
        }
        public DataTable searcStudentCourses(String type, String value)
        {
            return dalStudentCourses.searcStudentCourses(type, value);
        }
    }
}
