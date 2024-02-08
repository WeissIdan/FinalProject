using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Rating : BaseEntity
    {
        private int userId;
        [DataMember]
        public int UserId { get { return userId; } set { userId = value; } }

        private int albumId;
        [DataMember]
        public int AlbumId { get { return albumId; } set { albumId = value; } }

        private int rating;
        [DataMember]
        public int _Rating { get { return rating; } set { rating = value; } }
    }
    [CollectionDataContract]
    public class RatingList : List<Rating>
    {
        public RatingList() { }
        public RatingList(IEnumerable<Rating> list) : base(list) { }
        public RatingList(IEnumerable<BaseEntity> list) : base(list.Cast<Rating>().ToList()) { }
    }
}
