using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Messages : BaseEntity
    {
        private int chatId;
        public int ChatId { get { return chatId; } set { chatId = value; } }

        private string message;
        public string Message { get { return message; } set { message = value; } }
    }

    public class MessagesList : List<Messages>
    {
        public MessagesList() { }
        public MessagesList(IEnumerable<Messages> list) : base(list) { }
        public MessagesList(IEnumerable<BaseEntity> list) : base(list.Cast<Messages>().ToList()) { }
    }
}
