using DAL;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace BUS
{
    public class BUS_HocVien
    {
        DAL_HocVien dalHocVien = new DAL_HocVien();

        public DataTable getHocVien()
        {
            return dalHocVien.getHocVien();
        }

        public DataTable getHocVien(string id)
        {
            return dalHocVien.getHocVien(id);
        }

        public string getNameHocVien(string id)
        {
            return dalHocVien.getNameHocVien(id);
        }

        public bool getStatusHocVien(String id)
        {
            return dalHocVien.getStatusHocVien(id);
        }

        public bool themHocVien(DTO_Hocvien hv)
        {
            return dalHocVien.themHocVien(hv);
        }
        public DataTable searchHocVien(String type, String value)
        {
            return dalHocVien.searchHocVien(type, value);
        }
        public bool xoaHocVien(String id)
        {
            return dalHocVien.xoaHocVien(id);
        }
        public bool suaHocVien(DTO_Hocvien hv)
        {
            return dalHocVien.suaHocVien(hv);
        }

        public string countHocVien()
        {
            return dalHocVien.countHocVien();
        }
    }
}