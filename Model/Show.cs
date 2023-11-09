using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Show : BaseEntity
    {
        private DateTime showDate;
        public DateTime ShowDate { get { return showDate; } set { showDate = value; } }

        private string country;
        public string Country { get { return country; } set { country = value; } }

        private string city;
        public string City { get { return city; } set { city = value; } }

        private string showName;
        public string ShowName { get { return showName; } set { showName = value; } }

    }
    public class ShowList : List<Show>
    {
        public ShowList() { }
        public ShowList(IEnumerable<Show> list) : base(list) { }
        public ShowList(IEnumerable<BaseEntity> list) : base(list.Cast<Show>().ToList()) { }
    }
}
