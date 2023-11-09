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

    }
}
