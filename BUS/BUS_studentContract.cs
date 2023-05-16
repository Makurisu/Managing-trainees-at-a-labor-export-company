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
    public class BUS_studentContract
    {
        DAL_studentContract dalStudentContract = new DAL_studentContract();
        public DataTable getStudentContract()
        {
            return dalStudentContract.getStudentContract();
        }

        public DataTable getStudentContract(string id)
        {
            return dalStudentContract.getStudentContract(id);
        }

        public bool themStudentContract(DTO_studentContract studentContract)
        {
            return dalStudentContract.themStudentContract(studentContract);
        }

        public bool checkStudentContract(string id)
        {
            return dalStudentContract.checkStudentContract(id);
        }

        public bool xoaStudentContract(DTO_studentContract studentContract)
        {
            return dalStudentContract.xoaStudentContract(studentContract);
        }

        public DataTable searchStudentContract(String type, String value)
        {
            return dalStudentContract.searchStudentContract(type, value);
        }
    }
}
