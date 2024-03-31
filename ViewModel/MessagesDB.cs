using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MessagesDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Messages messages = entity as Messages;
            messages.ID = int.Parse(reader["Id"].ToString());
            messages.Message = reader["Message"].ToString();
            messages.ChatId = int.Parse(reader["ChatId"].ToString());
            messages.UserId = int.Parse(reader["UserId"].ToString());
            return messages;
        }

        protected override BaseEntity NewEntity()
        {
            return new Messages();
        }

        public MessagesList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblMessages";
            MessagesList list = new MessagesList(ExecuteCommand());
            return list;
        }

        public Messages SelectById(int id)
        {
            command.CommandText = $"SELECT * FROM tblMessages WHERE Id={id}";
            MessagesList list = new MessagesList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }

        public MessagesList SelectByChatId(int chatId)
        {
            command.CommandText = $"SELECT * FROM tblMessages WHERE ChatId={chatId}";
            MessagesList list = new MessagesList(ExecuteCommand());
            return list; 
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            Messages message = entity as Messages;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@ChatId", message.ChatId);
            command.Parameters.AddWithValue("@Message", message.Message);
            command.Parameters.AddWithValue("@UserId", message.UserId);
            command.Parameters.AddWithValue("@Id", message.ID);
        }

        public int Insert(Messages message)
        {
            command.CommandText = "INSERT INTO tblMessages (ChatId, Message, UserId) VALUES (@ChatId, @Message, @UserId)";
            LoadParameters(message);
            return ExecuteCRUD(); ;
        }
        public int Update(Messages message)
        {
            command.CommandText = "UPDATE tblMessages SET ChatId = @ChatId, Message = @Message, UserId = @UserId WHERE Id = @Id";
            LoadParameters(message);
            return ExecuteCRUD();
        }
        public int Delete(Messages message)
        {
            command.CommandText = "DELETE FROM tblMessages WHERE Id = @Id";
            LoadParameters(message);
            return ExecuteCRUD();
        }        
        public int DeleteByUser(User user)
        {
            command.CommandText = $"DELETE FROM tblMessages WHERE UserId = {user.ID}";
            return ExecuteCRUD();
        }        
        public int DeleteByChat(Chat chat)
        {
            command.CommandText = $"DELETE FROM tblMessages WHERE ChatId = {chat.ID}";
            return ExecuteCRUD();
        }
    }
}
