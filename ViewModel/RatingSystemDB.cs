using Model;
using System;
using System.Collections.Generic;
using System.Data;
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
            Rating rate = entity as Rating;
            rate.ID = 0;
            rate._Rating = int.Parse(reader["Rating"].ToString());
            rate.UserId = int.Parse(reader["UserId"].ToString());
            rate.AlbumId = int.Parse(reader["AlbumId"].ToString());
            return rate;
        }      
        protected BaseEntity CreateSongModel(BaseEntity entity)
        {
            Rating rate = entity as Rating;
            rate.ID = 0;
            rate._Rating = int.Parse(reader["Rating"].ToString());
            rate.UserId = int.Parse(reader["UserId"].ToString());
            rate.AlbumId = int.Parse(reader["SongId"].ToString());
            return rate;
        }

        protected override BaseEntity NewEntity()
        {
            return new Rating();
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
        public int GetAlbumRatingByUser(int AlbumId, int UserId)
        {
            string q = $"SELECT * FROM tblAlbumRatings WHERE (AlbumId={AlbumId} AND UserId={UserId})";
            command.CommandText = q;

            RatingList list = new RatingList(ExecuteCommand());
            if(list.Count == 0)
            {
                return 0;
            }
            return list[0]._Rating;
        }       
        public int GetSongRatingByUser(int SongId, int UserId)
        {
            string q = $"SELECT * FROM tblSongRatings WHERE (SongId={SongId} AND UserId={UserId})";
            command.CommandText = q;

            RatingList list = new RatingList(ExecuteSongCommand());
            if(list.Count == 0)
            {
                return 0;
            }
            return list[0]._Rating;
        }

        public int InsertAlbumR(int userId, int albumId, int rating)
        {
            command.CommandText = $"INSERT INTO tblAlbumRatings (UserId, AlbumId, Rating) VALUES ({userId}, {albumId}, {rating})";
            return ExecuteCRUD(); ;
        }
        public int UpdateAlbumR(int userId, int albumId, int rating)
        {
            command.CommandText = $"UPDATE tblAlbumRatings SET UserId = {userId}, albumId = @{albumId}, rating = {rating} WHERE Id = @Id";
            return ExecuteCRUD();
        }
        public int DeleteAlbumR(int userId, int albumId)
        {
            command.CommandText = $"DELETE FROM tblAlbumRatings WHERE UserId = {userId} AND AlbumId = {albumId}";
            return ExecuteCRUD();
        }        
        public int DeleteAlbumRatingByUser(int userId)
        {
            command.CommandText = $"DELETE FROM tblAlbumRatings WHERE UserId = {userId}";
            return ExecuteCRUD();
        }

        public int InsertSongR(int userId, int songId, int rating)
        {
            command.CommandText = $"INSERT INTO tblSongRatings (UserId, SongId, Rating) VALUES ({userId}, {songId}, {rating})";
            return ExecuteCRUD(); ;
        }
        public int UpdateSongR(int userId, int songId, int rating)
        {
            command.CommandText = $"UPDATE tblAlbumRating SET UserId = {userId}, albumId = {songId}, rating = {rating} WHERE Id = @Id";
            return ExecuteCRUD();
        }
        public int DeleteSongR(int userId, int songId)
        {
            command.CommandText = $"DELETE FROM tblSongRatings WHERE userId = {userId} AND SongId = {songId}";
            return ExecuteCRUD();
        }        
        public int DeleteSongRatingByUser(int userId)
        {
            command.CommandText = $"DELETE FROM tblSongRatings WHERE userId = {userId}";
            return ExecuteCRUD();
        }




        public List<BaseEntity> ExecuteSongCommand() //עבודה וניהול התקשורת מול המסד
        {
            List<BaseEntity> list = new List<BaseEntity>();
            try
            {
                connection.Open(); //פתיחת תקשורת עם המסד
                reader = command.ExecuteReader(); //ביצוע השאילתה
                while (reader.Read()) //מעבר על כל התוצאות
                {
                    BaseEntity entity = NewEntity(); //יצירת עצם חדש מותאם לצורך הנוכחי
                    list.Add(CreateSongModel(entity)); //מילוי העצם בתכונות מותאמות
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return list;
        }
    }
}
