using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Category
    {
        public int categoryID { get; set; }
        public string name { get; set; }

        public static List<Category> listCategory;

        public static List<Category> GetCategory()
        {
            try
            {
                listCategory = new List<Category>();
                DataContext context = new DataContext();

                IQueryable<category> Category =
                    from p in context.categories
                    select p;

                foreach (var itemCateg in Category)
                {
                    Category newCategory = new Category();
                    newCategory.categoryID = itemCateg.categoryID;
                    newCategory.name = itemCateg.name;
                    listCategory.Add(newCategory);
                }

                return listCategory;
            }
            catch (Exception eGetCategory)
            {
                return null;
            }
        }
    }
}
