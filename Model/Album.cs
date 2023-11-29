using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Album : BaseEntity
    {
        private string albumName;

        [DataMember]
        public string AlbumName { get { return albumName; } set { albumName = value; } }
        
        private DateTime releaseDate;
        [DataMember]
        public DateTime ReleaseDate { get { return releaseDate; } set { releaseDate = value; } }
        private int songAmount;
        [DataMember]
        public int SongAmount { get { return songAmount; } set { songAmount = value; } }    
    }
    [CollectionDataContract]
    public class AlbumList : List<Album>
    {
        public AlbumList() { }
        public AlbumList(IEnumerable<Album> list) : base(list) { }
        public AlbumList(IEnumerable<BaseEntity> list) : base(list.Cast<Album>().ToList()) { }
    }
}
