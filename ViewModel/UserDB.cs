﻿using Model;
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
            user.FirstName = reader["Firstname"].ToString();
            user.LastName = reader["Lastname"].ToString();
            user.UserName = reader["UserName"].ToString();
            user.Password = reader["Password"].ToString();
            user.Email = reader["Email"].ToString();
            user.IsMale = bool.Parse(reader["IsMale"].ToString());
            user.Accesslevel = int.Parse(reader["AccessLevel"].ToString());
            user.Birthdate = DateTime.Parse(reader["Birthdate"].ToString());
            user.ID = int.Parse(reader["Id"].ToString());
            return user;
        }

        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblUsers";
            UserList list = new UserList(ExecuteCommand());
            return list;
        }
        public User Login(User user)
        {
            command.CommandText = $"SELECT * FROM tblUsers WHERE UserName='{user.UserName}' AND [Password]='{user.Password}'";
            UserList list = new UserList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        public User SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tblUsers WHERE Id=" + id;
            UserList list = new UserList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }

        public int Insert(User user)
        {
            string date = user.Birthdate.ToString("dd/MM/yyyy");
            command.CommandText = $"INSERT INTO tblUsers (Firstname, LastName, UserName, [Password], Email, IsMale, AccessLevel, Birthdate) Values (@Firstname, @LastName, @UserName, @Password, @Email, @IsMale, @AccessLevel, @Birthdate)";
            LoadParameters(user);
            return ExecuteCRUD();
        }

        public int UpdateUser(User user)
        {
            command.CommandText = "UPDATE tblUsers SET FirstName = @Firstname, LastName = @LastName, UserName = @UserName, [Password] = @Password, Email = @Email, IsMale = @IsMale, AccessLevel = @AccessLevel, Birthdate = @Birthdate WHERE Id = @Id";
            LoadParameters(user);
            return ExecuteCRUD();
        }

        public int Delete(User user)
        {
            command.CommandText = $"DELETE FROM tblUsers WHERE Id = {user.ID}";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            User user = entity as User;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Firstname", user.FirstName);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@UserName", user.UserName);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@IsMale", user.IsMale? 1:0);
            command.Parameters.AddWithValue("@AccessLevel", user.Accesslevel);
            command.Parameters.AddWithValue("@Birthdate", user.Birthdate.ToShortDateString());
            command.Parameters.AddWithValue("@Id", user.ID);

        }
    }
}
