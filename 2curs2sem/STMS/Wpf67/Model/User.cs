using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf67.Model
{
    public class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public bool isAdmin { get; set; }

        public User(int id, string login, string password, bool isAdmin)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.isAdmin = isAdmin;
        }

        public override string ToString()
        {
            return id.ToString() + " " + login;
        }
    }
}
