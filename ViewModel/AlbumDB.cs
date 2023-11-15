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

        protected override void LoadParameters(BaseEntity entity)
        {
            Album album = entity as Album;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Id", album.ID);
            command.Parameters.AddWithValue("@AlbumName", album.AlbumName);
            command.Parameters.AddWithValue("@ReleaseDate", album.ReleaseDate);
            command.Parameters.AddWithValue("@SongAmount", album.SongAmount);
        }

        public int Insert(Album album)
        {
            command.CommandText = "INSERT INTO tblAlbums (Albumname, ReleaseDate, SongAmount) VALUES (@Albumname, @ReleaseDate, @SongAmount)";
            LoadParameters(album);
            return ExecuteCRUD(); ;
        }
        public int Update(Album album)
        {
            command.CommandText = "UPDATE tblAlbums SET Albumname = @Albumname, ReleaseDate = @ReleaseDate, SongAmount = @SongAmount WHERE Id = @Id";
            LoadParameters(album);
            return ExecuteCRUD();
        }
        public int Delete(Album album)
        {
            command.CommandText = "DELETE FROM tblAlbums WHERE Id = @Id";
            LoadParameters(album);
            return ExecuteCRUD();
        }
    }
}
