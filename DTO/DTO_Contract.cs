using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Contract
    {
        private String contract_id;
        private String contract_name;
        private String contract_country;
        private String contract_nhomnganh;
        private String contract_nghenghiep;
        private int contract_salary;
        private int contract_slot;
        private String contract_status;

        public String Contract_id { get { return contract_id; } set { contract_id = value; } } 
        public String Contract_country { get { return contract_country; } set { contract_country = value; } }
        public String Contract_name { get { return contract_name; } set { contract_name = value; } }
        public String Contract_nhomnganh { get { return contract_nhomnganh; } set { contract_nhomnganh= value; } }
        public String Contract_nghenghiep { get { return contract_nghenghiep; } set { contract_nghenghiep= value; } }
        public int Contract_salary { get { return contract_salary; } set { contract_salary = value; } }
        public int Contract_slot { get { return contract_slot; } set { contract_slot = value; } }
        public String Contract_status { get { return contract_status; } set { contract_status = value;} }

        public DTO_Contract() { }

        public DTO_Contract(String contract_id, String contract_name, String contract_contry,String contract_nhomnganh, String contract_nghenhiep, int contract_salary, int contract_slot, String contract_status)
        {
            this.Contract_id = contract_id;
            this.Contract_name = contract_name;
            this.Contract_country = contract_contry;
            this.Contract_nhomnganh = contract_nhomnganh;
            this.Contract_nghenghiep = contract_nghenhiep;
            this.Contract_salary = contract_salary;
            this.Contract_slot = contract_slot;
            this.Contract_status = contract_status;
        }
    }
}
