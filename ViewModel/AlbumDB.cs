using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    internal class AlbumDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Album album = entity as Album;
            album.ID = int.Parse(reader["Id"].ToString());
            album.AlbumName = reader["AlbumName"].ToString();
            album.ReleaseDate = DateTime.Parse(reader["ReleaseDate"].ToString());
            album.SongAmount = int.Parse(reader["SongAmount"].ToString());
            return album;
        }

        protected override BaseEntity NewEntity()
        {
            return new Album();
        }
        public AlbumList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblAlbums";
            AlbumList list = new AlbumList(ExecuteCommand());
            return list;
        }

        public Album SelectById(int id)
        {
            command.CommandText = $"SELECT * FROM tblAlbums WHERE Id={id}";
            AlbumList list = new AlbumList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
    }
}
