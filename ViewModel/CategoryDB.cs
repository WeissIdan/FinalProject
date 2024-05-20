using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CategoryDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Category category = entity as Category;
            category.CategoryName = reader["CategotyName"].ToString();
            category.CategoryType = reader["CategoryType"].ToString();
            category.ID = int.Parse(reader["Id"].ToString());
            return category;
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            Category category = entity as Category;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
            command.Parameters.AddWithValue("@CategoryType", category.CategoryType);
            command.Parameters.AddWithValue("@Id", category.ID);
        }

        protected override BaseEntity NewEntity()
        {
            return new Category();
        }

        public CategoryList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblCategories";
            CategoryList list = new CategoryList(ExecuteCommand());
            return list;
        }

        public CategoryList SelectCategoryByType(Category category)
        {
            command.CommandText = "SELECT * FROM tblCategories WHERE (CategoryType = @CategoryType)";
            LoadParameters(category);
            CategoryList list = new CategoryList(ExecuteCommand());
            return list;
        }

        public int Insert(Category category)
        {
            command.CommandText = "INSERT INTO tblCategories (CategotyName, CategoryType) VALUES (@CategoryName, @CategoryType)";
            LoadParameters(category);
            return ExecuteCRUD(); ;
        }
        public int Update(Category category)
        {
            command.CommandText = "UPDATE tblCategories SET CategotyName = @CategoryName, CategoryType = @CategoryType WHERE Id = @Id";
            LoadParameters(category);
            return ExecuteCRUD();
        }
        public int Delete(Category category)
        {
            command.CommandText = "DELETE FROM tblCategories WHERE Id = @Id";
            LoadParameters(category);
            return ExecuteCRUD();
        }
    }
}
