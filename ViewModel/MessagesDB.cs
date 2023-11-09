using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    internal class MessagesDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Messages messages = entity as Messages;
            messages.ID = int.Parse(reader["Id"].ToString());
            messages.Message = reader["Message"].ToString();
            messages.ChatId = int.Parse(reader["ChatId"].ToString());
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
    }
}
