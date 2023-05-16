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
    public class BUS_Class
    {
        DAL_Class dalClass = new DAL_Class();
        public DataTable getClass()
        {
            return dalClass.getClass();
        }

        public DataTable getStudentClass(string id)
        {
            return dalClass.getStudentClass(id);
        }

        public bool themClass(DTO_Class Class)
        {
            return dalClass.themClass(Class);
        }

        public bool suaClass(DTO_Class Class)
        {
            return dalClass.suaClass(Class);
        }

        public bool xoaClass(DTO_Class Class)
        {
            return dalClass.xoaClass(Class);
        }
        public DataTable searchClass(String type, String value)
        {
            return dalClass.searchClass(type, value);
        }

        public string countClass()
        {
            return dalClass.countClass();
        }
    }
}
