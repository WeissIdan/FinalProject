using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    internal class SongsDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Song song = entity as Song;
            song.ID = int.Parse(reader["Id"].ToString());
            song.AlbumId = int.Parse(reader["AlbumId"].ToString());
            song.Lyrics = reader["Lyrics"].ToString();
            song.SongName = reader["SongName"].ToString();
            return song;
        }

        protected override BaseEntity NewEntity()
        {
            return new Song();
        }

        public SongList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblSongs";
            SongList list = new SongList(ExecuteCommand());
            return list;
        }
        public Song SelectById(int id)
        {
            command.CommandText = $"SELECT * FROM tblSongs WHERE Id={id}"; ;
            SongList list = new SongList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
    }
}
