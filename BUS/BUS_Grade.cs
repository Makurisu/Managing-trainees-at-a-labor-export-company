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
    public class BUS_Grade
    {
        DAL_Grade dalGrade = new DAL_Grade();
        public DataTable getGrade()
        {
            return dalGrade.getGrade();
        }

        public DataTable getGradeById(string id)
        {
            return dalGrade.getGradeById(id);
        }

        public DataTable getGradeByTeacher(string id)
        {
            return dalGrade.getGradeByTeacher(id);
        }

        public bool suaGrade(DTO_Grade dtoGrade)
        {
            return dalGrade.suaGrade(dtoGrade);
        }
    }
}
