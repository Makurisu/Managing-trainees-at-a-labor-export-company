using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_Calender
    {
        DAL_Calender cld = new DAL_Calender();
        public bool addEvent(DTO_Calender dTO_Calender)
        {
            return cld.addEvent(dTO_Calender);
        }

        public String showEvent(String date)
        {
            return cld.showEvent(date);
        }
    }
}
