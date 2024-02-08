using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class Messages : BaseEntity
    {
        private int chatId;
        [DataMember]
        public int ChatId { get { return chatId; } set { chatId = value; } }

        private string message;
        [DataMember]
        public string Message { get { return message; } set { message = value; } }

        private int userId;
        [DataMember]
        public int UserId { get { return userId; } set { userId = value; } }
    }

    [CollectionDataContract]
    public class MessagesList : List<Messages>
    {
        public MessagesList() { }
        public MessagesList(IEnumerable<Messages> list) : base(list) { }
        public MessagesList(IEnumerable<BaseEntity> list) : base(list.Cast<Messages>().ToList()) { }
    }
}
