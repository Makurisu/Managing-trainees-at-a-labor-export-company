using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_GiangVien
    {
        private String giangvien_id;
        private String giangvien_fullName;
        private String giangvien_dob;
        private String giangvien_gender;
        private String giangvien_address;
        private String giangvien_sdt;
        private String giangvien_email;
        private String giangvien_language;
        private String giangvien_pathImage;

        public String GiangVien_id
        {
            get { return giangvien_id; }
            set { giangvien_id = value; }
        }
        public String GiangVien_fullName
        {
            get { return giangvien_fullName; }
            set { giangvien_fullName = value; }
        }
        public String GiangVien_dob
        {
            get { return giangvien_dob; }
            set { giangvien_dob = value; }
        }
        public String GiangVien_gender
        {
            get { return giangvien_gender; }
            set { giangvien_gender = value; }
        }
        public String GiangVien_address
        {
            get { return giangvien_address; }
            set
            {
                giangvien_address = value;
            }
        }
        public String GiangVien_sdt
        {
            get { return giangvien_sdt; }
            set
            {
                giangvien_sdt = value;
            }
        }
        public String GiangVien_email
        {
            get { return giangvien_email; }
            set { giangvien_email = value; }
        }
        public string GiangVien_idName
        {
            get { return $"{giangvien_id} - {giangvien_fullName}"; }
        }

        public String GiangVien_language { get { return giangvien_language; } set { giangvien_language= value; } }
        public String GiangVien_pathImage { get { return giangvien_pathImage; } set { giangvien_pathImage= value; } }
        public DTO_GiangVien() {}

        public DTO_GiangVien(String giangvien_id, string giangvien_fullName, string giangvien_dob, string giangvien_gender, string giangvien_address, string giangvien_sdt, string giangvien_email, string giangvien_language, string giangvien_pathImage)
        {
            this.GiangVien_id = giangvien_id;
            this.GiangVien_fullName = giangvien_fullName;
            this.GiangVien_dob = giangvien_dob;
            this.GiangVien_gender = giangvien_gender;
            this.GiangVien_address = giangvien_address;
            this.GiangVien_sdt = giangvien_sdt;
            this.GiangVien_email = giangvien_email;
            this.giangvien_language = giangvien_language;
            this.GiangVien_pathImage = giangvien_pathImage;
        }
    }
}
