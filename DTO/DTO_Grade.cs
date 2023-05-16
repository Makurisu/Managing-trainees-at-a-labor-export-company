using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Grade
    {
        private string student_id;
        private string course_id;
        private string quatrinh1;
        private string quatrinh2;
        private string giuaki;
        private string cuoiki;
        private string tongket;

        public string Student_id { get { return student_id; } set { student_id = value; } }
        public string Course_id { get { return course_id; } set { course_id = value;} }
        public string Quatrinh1 { get { return quatrinh1; } set { quatrinh1 = value; } }
        public string Quatrinh2 { get { return quatrinh2; } set { quatrinh2 = value; } }
        public string Giuaki { get { return giuaki; } set { giuaki = value; } }
        public string Cuoiki { get { return cuoiki; } set { cuoiki = value; } }
        public string Tongket { get { return tongket; } set { tongket = value; } }

        public DTO_Grade() { }
        public DTO_Grade(string student_id, string course_id, string quatrinh1, string quatrinh2, string giuaki, string cuoiki, string tongket)
        {
            this.Student_id = student_id;
            this.Course_id = course_id;
            this.Quatrinh1 = quatrinh1;
            this.Quatrinh2 = quatrinh2;
            this.Giuaki = giuaki;
            this.Cuoiki = cuoiki;
            this.tongket = tongket;
        }
    }
}
