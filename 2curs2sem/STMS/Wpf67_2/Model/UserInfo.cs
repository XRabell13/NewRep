using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf67.Model
{
   public class UserInfo
    {
        public int id_user { get; set; }
        public string passport { get; set; }
        public string email { get; set; }
        public string telephone { get; set; }

        public UserInfo(int id_user, string passport, string email, string telephone)
        {
            this.id_user = id_user;
            this.passport = passport;
            this.email = email;
            this.telephone = telephone;
        }

        public override string ToString()
        {
            return id_user.ToString() + " " + passport;
        }
    }
}
