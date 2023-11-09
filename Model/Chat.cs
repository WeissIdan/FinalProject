using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Chat : BaseEntity
    {
        private int chatManager;
        public int ChatManager { get { return chatManager; } set { chatManager = value; } }

        private DateTime creationDate;
        public DateTime CreationDate { get { return creationDate; } set { creationDate = value; } }

    }
    public class ChatList : List<Chat>
    {
        public ChatList() { }
        public ChatList(IEnumerable<Chat> list) : base(list) { }
        public ChatList(IEnumerable<BaseEntity> list) : base(list.Cast<Chat>().ToList()) { }
    }
}
