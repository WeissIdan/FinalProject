using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//reader = command.ExecuteReader(); //ביצוע השאילתה

namespace ViewModel
{
    internal class RatingSystemDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            return null;
        }

        protected override BaseEntity NewEntity()
        {
            return null;
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
    }
}
