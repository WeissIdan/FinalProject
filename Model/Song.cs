using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class Song : BaseEntity
    {
        private int albumId;
        [DataMember]
        public int AlbumId { get { return albumId; } set { albumId= value; } }

        private string songName;
        [DataMember]
        public string SongName { get { return songName; } set { songName= value; } }

        private string lyrics;
        [DataMember]
        public string Lyrics { get { return lyrics; } set { lyrics= value; } }

    }
    [CollectionDataContract]
    public class SongList : List<Song>
    {
        public SongList() { }
        public SongList(IEnumerable<Song> list) : base(list) { }
        public SongList(IEnumerable<BaseEntity> list) : base(list.Cast<Song>().ToList()) { }
    }
}
