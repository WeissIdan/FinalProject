using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class Show : BaseEntity
    {
        private DateTime showDate;
        [DataMember]
        public DateTime ShowDate { get { return showDate; } set { showDate = value; } }

        private string country;
        [DataMember]
        public string Country { get { return country; } set { country = value; } }

        private string city;
        [DataMember]
        public string City { get { return city; } set { city = value; } }

        private string showName;
        [DataMember]
        public string ShowName { get { return showName; } set { showName = value; } }


        private string stadiumName;
        [DataMember]
        public string StadiumName { get { return stadiumName; } set { stadiumName = value; } }

        private string url;
        [DataMember]
        public string Url { get { return url; } set { url = value; } }
    }
    [CollectionDataContract]
    public class ShowList : List<Show>
    {
        public ShowList() { }
        public ShowList(IEnumerable<Show> list) : base(list) { }
        public ShowList(IEnumerable<BaseEntity> list) : base(list.Cast<Show>().ToList()) { }
    }
}
