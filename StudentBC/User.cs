using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBC
{
    class User
    {
        public string username { get; set; }

        public string Password { get; set; }

        public User(string usr, string p)
        {
            this.username = usr;
            this.Password = p;
        }
        public override string ToString()
        {
            return username + ","+ Password;
        }
    }
}
