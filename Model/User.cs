using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class User : BaseEntity
    {
        protected string firstname;
        [DataMember]
        public string FirstName { get { return firstname; } set { firstname = value; } }

        protected string lastname;
        [DataMember]
        public string LastName { get { return lastname; } set { lastname = value; } }


        protected string username;
        [DataMember]
        public string UserName { get { return username; } set { username = value; } }

        protected string password;
        [DataMember]
        public string Password { get { return password; } set { password = value; } }

        protected string email;
        [DataMember]
        public string Email { get { return email; } set { email = value; } }

        protected bool ismale;
        [DataMember]
        public bool IsMale { get { return ismale; } set { ismale = value; } }


        protected int accesslevel;
        [DataMember]
        public int Accesslevel { get { return accesslevel; } set { accesslevel = value; } }
        protected DateTime birthdate;
        [DataMember]
        public DateTime Birthdate { get { return birthdate; } set { birthdate = value; } }

    }

    [CollectionDataContract]
    public class UserList : List<User>
    {
        public UserList() { }
        public UserList(IEnumerable<User> list) : base(list) { }
        public UserList(IEnumerable<BaseEntity> list) : base(list.Cast<User>().ToList()) { }
    }
}
