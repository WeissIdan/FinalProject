using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    internal class ShowsDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Show show = entity as Show;
            show.ID = int.Parse(reader["Id"].ToString());
            show.ShowDate = DateTime.Parse(reader["ShowDate"].ToString());
            show.ShowName = reader["ShowName"].ToString();
            show.Country = reader["Country"].ToString();
            show.City = reader["City"].ToString();
            return show;
        }

        protected override BaseEntity NewEntity()
        {
            return new Show();
        }

        public ShowList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblShows";
            ShowList list = new ShowList(ExecuteCommand());
            return list;
        }

        public Show SelectById(int id)
        {
            command.CommandText = $"SELECT * FROM tblShows WHERE Id={id}";
            ShowList list = new ShowList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        protected override void LoadParameters(BaseEntity entity)
        {
             Show show = entity as Show;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Id", show.ID);
            command.Parameters.AddWithValue("@ShowName", show.ShowName);
            command.Parameters.AddWithValue("@Country", show.Country);
            command.Parameters.AddWithValue("@City", show.City);
            command.Parameters.AddWithValue("@ShowDate", show.ShowDate);
        }

        public int Insert(Show show)
        {
            command.CommandText = "INSERT INTO tblShows (ShowDate, Country, City, ShowName) VALUES (@ShowDate, @Country, @City, @ShowName)";
            LoadParameters(show);
            return ExecuteCRUD(); ;
        }
        public int Update(Show show)
        {
            command.CommandText = "UPDATE tblShows SET ShowDate = @ShowDate, Country = @Country, City = @City, ShowName = @ShowName WHERE Id = @Id";
            LoadParameters(show);
            return ExecuteCRUD();
        }
        public int Delete(Show show)
        {
            command.CommandText = "DELETE FROM tblShows WHERE Id = @Id";
            LoadParameters(show);
            return ExecuteCRUD();
        }

    }
}
