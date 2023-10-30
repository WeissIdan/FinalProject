using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : BaseEntity
    {
        protected string firstname;
        public string FirstName { get { return firstname; } set { firstname = value; } }

        protected string lastname;
        public string LastName { get { return lastname; } set { lastname = value; } }


        protected string username;
        public string UserName { get { return username; } set { username = value; } }

        protected string password;
        public string Password { get { return password; } set { password = value; } }

        protected string email;
        public string Email { get { return email; } set { email = value; } }

        protected bool ismale;
        public bool IsMale { get { return ismale; } set { ismale = value; } }


        protected int accesslevel;
        public int Accesslevel { get { return accesslevel; } set { accesslevel = value; } }
        protected DateTime birthdate;
        public DateTime Birthdate { get { return birthdate; } set { birthdate = value; } }

    }

    public class UserList : List<User>
    {
        public UserList() { }
        public UserList(IEnumerable<User> list) : base(list) { }
        public UserList(IEnumerable<BaseEntity> list) : base(list.Cast<User>().ToList()) { }
    }
}
