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
        private Song song;
        private Category category;

        [DataMember]
        public Song SongName { get {return song; } set {song = value; } }
        [DataMember]
        public Category categoryName { get { return category; } set { category = value; } }
    }
    [CollectionDataContract]
    public class SongCategoryList : List<SongCategory>
    {

        public SongCategoryList() { }
        public SongCategoryList(IEnumerable<SongCategory> list) : base(list) { }
        public SongCategoryList(IEnumerable<BaseEntity> list) : base(list.Cast<SongCategory>().ToList()) { }
    }
}
