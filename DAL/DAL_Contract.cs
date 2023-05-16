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
    public class DAL_Contract : DBConnect
    {
        public DataTable getContract()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM contracts", conn);
            DataTable dtContract = new DataTable();
            da.Fill(dtContract);
            return dtContract;
        }

        public bool themContract(DTO_Contract contract)
        {
            conn.Open();
            string sql = "exec InsertContract N'" + contract.Contract_name + "',N'" + contract.Contract_country + "', N'" + contract.Contract_nhomnganh + "', N'" + contract.Contract_nghenghiep + "','" + contract.Contract_salary + "','" + contract.Contract_slot + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }

        public bool suaContract(DTO_Contract contract)
        {
            conn.Open();
            string sql = "exec updateContract '" + contract.Contract_id+"', N'" + contract.Contract_name + "',N'" + contract.Contract_country + "','" + contract.Contract_salary + "','" + contract.Contract_slot + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }

        public bool xoaContract(DTO_Contract contract)
        {
            conn.Open();
            string check = "select * from student_contracts where contract_id = '" + contract.Contract_id + "'";
            SqlCommand checkCmd = new SqlCommand(check, conn);
            SqlDataReader reader = checkCmd.ExecuteReader();
            if(!reader.Read())
            {
                reader.Close();
                string sql = "exec DeleteContract '" + contract.Contract_id + "'";
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
        public DataTable searchContract(String type, String value)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM contracts where "+type+" LIKE N'"+value+"%'", conn);
            DataTable dtContract = new DataTable();
            da.Fill(dtContract);
            return dtContract;
        }

        public string countContract()
        {
            string count = "0";
            conn.Open();
            string sql = "SELECT COUNT(*) FROM contracts";
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
