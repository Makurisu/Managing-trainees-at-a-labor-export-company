using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Class
    {
        private String class_id;
        private String class_teacher;
        private String class_name;
        private String class_language;
        private int class_fee;

        public String Class_id { get { return class_id; } set { class_id = value; } }
        public String Class_teacher { get { return class_teacher; } set { class_teacher = value; } }
        public String Class_name { get { return class_name; } set { class_name = value; } }
        public String Class_language { get { return class_language; } set { class_language = value;} }
        public int Class_fee { get { return class_fee; } set { class_fee = value;} }

        public DTO_Class() { }

        public DTO_Class(string class_id, string class_teacher, string class_name, string class_language, int class_fee)
        {
            this.Class_id = class_id;
            this.Class_teacher = class_teacher;
            this.Class_name = class_name;
            this.Class_language = class_language;
            this.Class_fee = class_fee;
        }
    }
}
