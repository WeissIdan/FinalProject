using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class Chat : BaseEntity
    {
        private int chatManager;
        [DataMember]
        public int ChatManager { get { return chatManager; } set { chatManager = value; } }

        private DateTime creationDate;
        [DataMember]
        public DateTime CreationDate { get { return creationDate; } set { creationDate = value; } }

        private string chatName;
        [DataMember]
        public string ChatName{get{return chatName ;} set { chatName = value; } }

    }
    [CollectionDataContract]
    public class ChatList : List<Chat>
    {
        public ChatList() { }
        public ChatList(IEnumerable<Chat> list) : base(list) { }
        public ChatList(IEnumerable<BaseEntity> list) : base(list.Cast<Chat>().ToList()) { }
    }
}
