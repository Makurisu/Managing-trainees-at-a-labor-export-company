namespace DTO
{
    public class DTO_Hocvien
    {
        private String hocvien_id;
        private String hocvien_fullName;
        private String hocvien_dob;
        private String hocvien_gender;
        private String hocvien_address;
        private String hocvien_sdt;
        private String hocvien_email;
        private String hocvien_dpv;
        private String hocvien_pathImage;
        private String hocvien_status;

        public String Hocvien_id
        {
            get { return hocvien_id; }
            set { hocvien_id = value; }
        }
        public String Hocvien_fullName
        {
            get { return hocvien_fullName; }
            set { hocvien_fullName = value;}
        }
        public String Hocvien_dob
        {
            get { return hocvien_dob; }
            set { hocvien_dob = value; }
        }
        public String Hocvien_gender
        {
            get { return hocvien_gender; }
            set { hocvien_gender = value; }
        }
        public String Hocvien_address
        {
            get { return hocvien_address;}
            set
            {
                hocvien_address = value;
            }
        }
        public String Hocvien_sdt
        {
            get { return hocvien_sdt;}
            set
            {
                hocvien_sdt = value;
            }
        }
        public String Hocvien_email
        {
            get { return hocvien_email; }
            set { hocvien_email = value; }
        }
        public String Hocvien_dpv
        {
            get { return hocvien_dpv; }
            set { hocvien_dpv = value; }
        }

        public String Hocvien_pathImage { get { return hocvien_pathImage; } set { hocvien_pathImage= value; } }
        public String Hocvien_status
        {
            get { return hocvien_status;}
            set { hocvien_status = value;}
        }

        public DTO_Hocvien()
        {

        }

        public DTO_Hocvien(String hocvien_id, string hocvien_fullName, string hocvien_dob, string hocvien_gender, string hocvien_address, string hocvien_sdt, string hocvien_email, string hocvien_dpv, string hocvien_pathImage, string hocvien_status)
        {
            this.Hocvien_id = hocvien_id;
            this.Hocvien_fullName = hocvien_fullName;
            this.Hocvien_dob = hocvien_dob;
            this.Hocvien_gender = hocvien_gender;
            this.Hocvien_address = hocvien_address;
            this.Hocvien_sdt = hocvien_sdt;
            this.Hocvien_email = hocvien_email;
            this.Hocvien_dpv = hocvien_dpv;
            this.Hocvien_pathImage = hocvien_pathImage;
            this.Hocvien_status = hocvien_status;
        }
    }
}