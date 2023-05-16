using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Language
    {
        private string language_name;

        public String Language_name { get { return language_name; } set { language_name = value; } }

        public DTO_Language() { }

        public DTO_Language(string language_name)
        {
            this.Language_name = language_name;
        }
    }
}
