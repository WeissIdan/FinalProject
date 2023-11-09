using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Song : BaseEntity
    {
        private int albumId;
        public int AlbumId { get { return albumId; } set { albumId= value; } }

        private string songName;
        public string SongName { get { return songName; } set { songName= value; } }

        private string lyrics;
        public string Lyrics { get { return lyrics; } set { lyrics= value; } }

    }
    public class SongList : List<Song>
    {
        public SongList() { }
        public SongList(IEnumerable<Song> list) : base(list) { }
        public SongList(IEnumerable<BaseEntity> list) : base(list.Cast<Song>().ToList()) { }
    }
}
