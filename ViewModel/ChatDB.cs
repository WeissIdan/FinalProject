using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    internal class ChatDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Chat chat = entity as Chat;
            chat.ID = int.Parse(reader["Id"].ToString());
            chat.CreationDate = DateTime.Parse(reader["CreationDate"].ToString());
            chat.ChatManager = int.Parse(reader["ChatManager"].ToString());
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
    }
}
