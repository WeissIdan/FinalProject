using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new User();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User user = entity as User;
            user.ID = int.Parse(reader["Id"].ToString());
            user.FirstName = reader["Firstname"].ToString();
            user.LastName = reader["Lastname"].ToString();
            user.UserName = reader["UserName"].ToString();
            user.Password = reader["Password"].ToString();
            user.Email = reader["Email"].ToString();
            user.IsMale = bool.Parse(reader["IsMale"].ToString());
            user.Accesslevel = int.Parse(reader["AccessLevel"].ToString());
            user.Birthdate = DateTime.Parse(reader["Birthdate"].ToString());
            return user;
        }

        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblUsers";
            UserList list = new UserList(ExecuteCommand());
            return list;
        }
        public User SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tblUsers WHERE Id=" + id;
            UserList list = new UserList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
    }
}
