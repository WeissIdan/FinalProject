using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ChatDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Chat chat = entity as Chat;
            chat.ID = int.Parse(reader["Id"].ToString());
            chat.CreationDate = DateTime.Parse(reader["CreationDate"].ToString());
            chat.ChatManager = int.Parse(reader["ChatManager"].ToString());
            chat.ChatName = reader["ChatName"].ToString();
            return chat;
        }

        protected override BaseEntity NewEntity()
        {
            return new Chat();
        }

        public ChatList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblChats";
            ChatList list = new ChatList(ExecuteCommand());
            return list;
        }

        public Chat SelectById(int id)
        {
            command.CommandText = $"SELECT * FROM tblChats WHERE Id={id}";
            ChatList list = new ChatList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            Chat chat = entity as Chat;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@ChatManager", chat.ChatManager);
            command.Parameters.AddWithValue("@CreationDate", chat.CreationDate.ToShortDateString());
            command.Parameters.AddWithValue("@ChatName", chat.ChatName);
            command.Parameters.AddWithValue("@Id", chat.ID);
        }

        public int Insert(Chat chat)
        {
            command.CommandText = "INSERT INTO tblChats (ChatManager, CreationDate, ChatName) VALUES (@ChatManager, @CreationDate, @ChatName)";
            LoadParameters(chat);
            return ExecuteCRUD(); ;
        }
        public int Update(Chat chat)
        {
            command.CommandText = "UPDATE tblChats SET ChatManager = @ChatManager, CreationDate = @CreationDate, ChatName = @ChatName WHERE Id = @Id";
            LoadParameters(chat);
            return ExecuteCRUD();
        }
        public int Delete(Chat chat)
        {
            command.CommandText = $"DELETE FROM tblChats WHERE Id = {chat.ID}";
            LoadParameters(chat);
            return ExecuteCRUD();
        }        
        public ChatList SelectByManager(User user)
        {
            command.CommandText = $"SELECT * FROM tblChats WHERE ChatManager = {user.ID}";
            ChatList list = new ChatList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list;
        }
        public int DeleteByUser(User user)
        {
            command.CommandText = $"DELETE FROM tblChats WHERE ChatManager = {user.ID}";
            
            return ExecuteCRUD();
        }

    }
}
