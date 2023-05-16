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
    public class BUS_GiangVien
    {
        DAL_GiangVien dalGiangVien = new DAL_GiangVien();
        public DataTable getGiangVien()
        {
            return dalGiangVien.getGiangVien();
        }
        public DataTable getGiangVienLanguage(String language)
        {
            return dalGiangVien.getGiangVienLanguage(language);
        }

        public bool themGiangVien(DTO_GiangVien GiangVien)
        {
            return dalGiangVien.themGiangVien(GiangVien);
        }

        public bool suaGiangVien(DTO_GiangVien GiangVien)
        {
            return dalGiangVien.suaGiangVien(GiangVien);
        }

        public bool xoaGiangVien(DTO_GiangVien GiangVien)
        {
            return dalGiangVien.xoaGiangVien(GiangVien);
        }
        public DataTable searchGiangVien(String type, String value)
        {
            return dalGiangVien.searchGiangVien(type, value);
        }

        public List<DTO_GiangVien> getGiangVienIdName(String language)
        {
            return dalGiangVien.getGiangVienIdName(language);
        }
    }
}
