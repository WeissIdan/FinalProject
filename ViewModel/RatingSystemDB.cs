using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//reader = command.ExecuteReader(); //ביצוע השאילתה

namespace ViewModel
{
    public class RatingSystemDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            return null;
        }

        protected override BaseEntity NewEntity()
        {
            return null;
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public double GetSongRating(int songId)
        {
            string q = $"SELECT AVG(Rating) FROM tblSongRatings WHERE (SongID={songId})";
            command.CommandText = q;
            connection.Open(); //פתיחת תקשורת עם
            double result = double.Parse(command.ExecuteScalar().ToString());
            return result;
        }   
        public double GetAlbumRating(int AlbumId)
        {
            string q = $"SELECT AVG(Rating) FROM tblAlbumRatings WHERE (AlbumId={AlbumId})";
            command.CommandText = q;
            connection.Open(); //פתיחת תקשורת עם
            double result = double.Parse(command.ExecuteScalar().ToString());
            return result;
        }

        public int InsertAlbumR(int userId, int albumId, int rating)
        {
            command.CommandText = $"INSERT INTO tblAlbumRating (UserId, AlbumId, Rating) VALUES ({userId}, {albumId}, {rating})";
            return ExecuteCRUD(); ;
        }
        public int UpdateAlbumR(int userId, int albumId, int rating)
        {
            command.CommandText = $"UPDATE tblAlbumRating SET UserId = {userId}, albumId = @{albumId}, rating = {rating} WHERE Id = @Id";
            return ExecuteCRUD();
        }
        public int DeleteAlbumR(int userId, int albumId)
        {
            command.CommandText = $"DELETE FROM tblAlbumRating WHERE userId = @userId";
            return ExecuteCRUD();
        }

        public int InsertSongR(int userId, int songId, int rating)
        {
            command.CommandText = $"INSERT INTO tblAlbumRating (UserId, AlbumId, Rating) VALUES ({userId}, {songId}, {rating})";
            return ExecuteCRUD(); ;
        }
        public int UpdateSongR(int userId, int songId, int rating)
        {
            command.CommandText = $"UPDATE tblAlbumRating SET UserId = {userId}, albumId = {songId}, rating = {rating} WHERE Id = @Id";
            return ExecuteCRUD();
        }
        public int DeleteSongR(int userId, int songId)
        {
            command.CommandText = $"DELETE FROM tblAlbumRating WHERE userId = @userId";
            return ExecuteCRUD();
        }
    }
}
