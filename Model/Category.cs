using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Category : BaseEntity
    {
        private string categoryName;
        private string categoryType;
        [DataMember]
        public string CategoryName { get { return categoryName; } set { categoryName = value; } }
        [DataMember]
        public string CategoryType { get { return categoryType; } set { categoryType = value; } } 
    }
    [CollectionDataContract]

    public class CategoryList : List<Category>
    {
        public CategoryList() { }
        public CategoryList(IEnumerable<Category> list) : base(list) { }
        public CategoryList(IEnumerable<BaseEntity> list) : base(list.Cast<Category>().ToList()) { }
    }
}
