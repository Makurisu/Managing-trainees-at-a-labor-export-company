using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Account
    {
        private string username;
        private string password;
        private string type;

        public string Username { get { return username; } set { username = value; } }
        public static string tempUsername { get; set; }
        public string Password { get { return password; } set { password = value; } }
        public string Type { get { return type; } set { type = value; } }

        public DTO_Account() { }

        public DTO_Account(string username, string password, string type)
        {
            this.Username = username;
            this.Password = password;
            this.Type = type;
        }
    }
}
