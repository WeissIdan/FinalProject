using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Model
{
    [DataContract]
    public class BaseEntity
    {
        protected int id;
        [DataMember]
        public int ID { get { return id; } set { id = value; } }
    }
}
