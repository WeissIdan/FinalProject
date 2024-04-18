using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class SongCategoryDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            SongCategory songCategory = entity as SongCategory;
            songCategory.SongID = int.Parse(reader["Song"].ToString());
            songCategory.CategoryID = int.Parse(reader["Category"].ToString());
            return songCategory;
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            SongCategory songCategory = entity as SongCategory;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Song", songCategory.SongID);
            command.Parameters.AddWithValue("@Category", songCategory.CategoryID);
            command.Parameters.AddWithValue("@Id", songCategory.ID);
        }

        protected override BaseEntity NewEntity()
        {
            return new SongCategory();
        }
        public SongCategoryList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblSongCategory";
            SongCategoryList list = new SongCategoryList(ExecuteCommand());
            return list;
        }
        public SongCategoryList SelectAllSongsFromCategory(Category category)
        {
            command.CommandText = $"SELECT * FROM tblSongCategory WHERE (Category = {category.ID})";
            SongCategoryList list = new SongCategoryList(ExecuteCommand());
            return list;
        }

        public int Insert(SongCategory songCategory)
        {
            command.CommandText = "INSERT INTO tblSongCategory (Song, Category) VALUES (@Song, @Category)";
            LoadParameters(songCategory);
            return ExecuteCRUD(); ;
        }
        public int Update(SongCategory songCategory)
        {
            command.CommandText = "UPDATE tblSongCategory SET Song = @Song, Category = @Category WHERE Id = @Id";
            LoadParameters(songCategory);
            return ExecuteCRUD();
        }
        public int Delete(SongCategory songCategory)
        {
            command.CommandText = "DELETE FROM tblSongCategory WHERE Id = @Id";
            LoadParameters(songCategory);
            return ExecuteCRUD();
        }
    }
}
