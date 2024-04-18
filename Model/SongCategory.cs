using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class SongCategory : BaseEntity
    {
        private int songId;
        private int categoryId;

        [DataMember]
        public int SongID { get {return songId; } set { songId = value; } }
        [DataMember]
        public int CategoryID { get { return categoryId; } set { categoryId = value; } }
    }
    [CollectionDataContract]
    public class SongCategoryList : List<SongCategory>
    {

        public SongCategoryList() { }
        public SongCategoryList(IEnumerable<SongCategory> list) : base(list) { }
        public SongCategoryList(IEnumerable<BaseEntity> list) : base(list.Cast<SongCategory>().ToList()) { }
    }
}
