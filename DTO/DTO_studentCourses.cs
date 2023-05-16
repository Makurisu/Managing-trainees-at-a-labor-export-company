using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_studentCourses
    {
        private string student_id;
        private string courses_id;
        private string status;

        public string Student_id { get { return student_id; } set { student_id = value; } }
        public string Courses_id { get { return courses_id; } set { courses_id = value; } }
        public string Status { get { return status; } set { status = value; } }

        public DTO_studentCourses() { }

        public DTO_studentCourses(string student_id, string courses_id, string status)
        {
            this.Student_id = student_id;
            this.Courses_id = courses_id;
            this.Status = status;
        }
    }
}
