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
                if (listCategory != null) return listCategory;
                listCategory = new List<Category>();
                DataTable tableCategory = ServerConnect.Select("select distinct categoryID, name from category order by categoryID;");
                if (tableCategory != null)
                {
                    foreach (DataRow row in tableCategory.Rows)
                    {
                        Category newCategory = new Category();
                        newCategory.categoryID = Convert.ToInt32(row["categoryID"]);
                        newCategory.name = row["name"].ToString();
                        listCategory.Add(newCategory);
                    }
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
