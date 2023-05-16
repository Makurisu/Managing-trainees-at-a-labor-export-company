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
    public class DAL_studentContract : DBConnect
    {
        public DataTable getStudentContract()
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT student_id, contracts.id, contracts.name_contracts, contracts.country, contracts.nhomnganh, contracts.nghenghiep, contracts.salary
                                                         FROM student_contracts st_contracts
                                                         JOIN contracts ON st_contracts.contract_id = contracts.id", conn);
            DataTable dtStudentContract = new DataTable();
            da.Fill(dtStudentContract);
            return dtStudentContract;
        }

        public DataTable getStudentContract(string id)
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT contracts.name_contracts, contracts.country, contracts.nhomnganh, contracts.nghenghiep
                                                         FROM student_contracts st_contracts
                                                         JOIN contracts ON st_contracts.contract_id = contracts.id
                                                            WHERE st_contracts.student_id = '" + id+"'", conn);
            DataTable dtStudentContract = new DataTable();
            da.Fill(dtStudentContract);
            return dtStudentContract;
        }

        public bool themStudentContract(DTO_studentContract studentContract)
        {
            conn.Open();
            string check = "select * from student_contracts where student_id = '" + studentContract.Student_id + "'";
            SqlCommand checkCmd = new SqlCommand(check, conn);
            SqlDataReader reader = checkCmd.ExecuteReader();
            if (!reader.Read())
            {
                string sql = "exec AddContractToStudent '" + studentContract.Student_id + "', '" + studentContract.Contract_id + "'";
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

        public bool checkStudentContract(string id)
        {
            conn.Open();
            string check = "select * from student_contracts where student_id = '" + id + "'";
            SqlCommand checkCmd = new SqlCommand(check, conn);
            SqlDataReader reader = checkCmd.ExecuteReader();
            if (reader.Read())
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }

        public bool xoaStudentContract(DTO_studentContract studentContract)
        {
            conn.Open();
            string sql = "exec RemoveContractFromStudent '" + studentContract.Student_id + "', '" + studentContract.Contract_id + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }

        public DataTable searchStudentContract(String type, String value)
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT student_id, contracts.id, contracts.name_contracts, contracts.country, contracts.nhomnganh, contracts.nghenghiep, contracts.salary
                                                         FROM student_contracts st_contracts
                                                         JOIN contracts ON st_contracts.contract_id = contracts.id
                                                            WHERE " + type + " LIKE '%" + value + "%'", conn);
            DataTable dtStudentContract = new DataTable();
            da.Fill(dtStudentContract);
            return dtStudentContract;
        }
    }
}
