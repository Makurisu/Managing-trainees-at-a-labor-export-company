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
    public class BUS_Notice
    {
        DAL_Notice dalNotice = new DAL_Notice();
        public DataTable getNotice()
        {
            return dalNotice.getNotice();
        }

        public bool themNotice(DTO_Notice notice)
        {
            return dalNotice.themNotice(notice);
        }
    }
}
