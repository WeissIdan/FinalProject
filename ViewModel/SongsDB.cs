using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class SongsDB : BaseDB
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
        public SongList SelectAllSongsFromAlbum(int albumId)
        {
            command.CommandText = $"SELECT * FROM tblSongs Where (AlbumId={albumId})";
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
        public int Insert(Song song)
        {
            command.CommandText = "INSERT INTO tblSongs (AlbumId, Lyrics, SongName) VALUES (@AlbumId, @Lyrics, @SongName)";
            LoadParameters(song);
            return ExecuteCRUD(); ;
        }
        public int Update(Song song)
        {
            command.CommandText = "UPDATE tblSongs SET AlbumId = @AlbumId, Lyrics = @Lyrics, SongName = @SongName WHERE Id = @Id";
            LoadParameters(song);
            return ExecuteCRUD();
        }
        public int Delete(Song song)
        {
            command.CommandText = "DELETE FROM tblSongs WHERE Id = @Id";
            LoadParameters(song);
            return ExecuteCRUD();
        }
        public SongList SelectAllSongsFromCategory(Category category)
        {
            command.CommandText = $"SELECT tblSongs.Id, tblSongs.AlbumId, tblSongs.Lyrics, tblSongs.SongName FROM (tblSongCategory INNER JOIN tblSongs ON tblSongCategory.Song = tblSongs.Id) WHERE (tblSongCategory.Category = {category.ID}) ORDER BY tblSongs.AlbumId";
            SongList list = new SongList(ExecuteCommand());
            return list;
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            Song song = entity as Song;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Id", song.ID);
            command.Parameters.AddWithValue("@AlbumId", song.AlbumId);
            command.Parameters.AddWithValue("@Lyrics", song.Lyrics);
            command.Parameters.AddWithValue("@SongName", song.SongName);
        }
    }
}
