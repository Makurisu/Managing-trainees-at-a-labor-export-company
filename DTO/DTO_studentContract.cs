using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_studentContract
    {
        private string student_id;
        private string contract_id;

        public string Student_id { get { return student_id; } set { student_id = value; } }
        public string Contract_id { get { return contract_id; } set { contract_id = value; } }

        public DTO_studentContract() { }

        public DTO_studentContract(string student_id, string contract_id)
        {
            this.Student_id = student_id;
            this.Contract_id = contract_id;
        }
    }
}
