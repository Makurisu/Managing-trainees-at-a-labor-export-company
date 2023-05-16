using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_Contract
    {
        DAL_Contract dalContract = new DAL_Contract();
        public DataTable getContract()
        {
            return dalContract.getContract();
        }

        public bool themContract(DTO_Contract contract)
        {
            return dalContract.themContract(contract);
        }

        public bool suaContract(DTO_Contract contract)
        {
            return dalContract.suaContract(contract);
        }

        public bool xoaContract(DTO_Contract contract)
        {
            return dalContract.xoaContract(contract);
        }
        public DataTable searchContract(String type, String value)
        {
            return dalContract.searchContract(type, value);
        }

        public string countContract()
        {
            return dalContract.countContract();
        }
    }
}
