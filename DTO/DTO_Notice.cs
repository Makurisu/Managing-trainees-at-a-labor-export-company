using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Notice
    {
        private string notice;
        private string date_post;

        public string Notice { get { return notice; } set { notice = value; } }
        public string DatePost { get { return date_post;} set { date_post = value; } }

        public DTO_Notice() { }
        public DTO_Notice(string notice, string date_post)
        {
            this.Notice = notice;
            this.notice = date_post;
        }
    }
}
