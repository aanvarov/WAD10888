using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAD._10888.APP
{
    public class LibraryUser
    {
        public String Name { get; set; }

        public String Surname { get; set; }

        public String Nickname { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

        public LibraryUser(string name, string surname, string nickname, string email, string password)
        {
            this.Name = name;
            this.Surname = surname;
            this.Nickname = nickname;
            this.Email = email;
            this.Password = password;
        }

    }

}
