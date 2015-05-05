using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class City
    {
        public int cityID { get; set; }
        public string name { get; set; }

        public static List<City> listCity;

        public static List<City> GetCity()
        {
            try
            {
                if (listCity != null) return listCity;
                listCity = new List<City>();
                DataTable tableCity = ServerConnect.Select("select distinct cityID, name from city order by cityID;");
                if (tableCity != null)
                {
                    foreach (DataRow row in tableCity.Rows)
                    {
                        City newCity = new City();
                        newCity.cityID = Convert.ToInt32(row["cityID"]);
                        newCity.name = row["name"].ToString();
                        listCity.Add(newCity);
                    }
                }

                return listCity;
            }
            catch (Exception eGetCity)
            {
                return null;
            }
        }

        public static bool InsertCity(City newCity)
        {
            try
            {
                if (newCity != null)
                {
                    ServerConnect.Insert("insert into city (cityID, name) values (" + newCity.cityID + ",N'" + newCity.name + "');");
                    return true;
                }
                return false;
            }
            catch (Exception eInsertCity)
            {
                return false;
            }
        }

        public static bool DeleteCity(City deleteCity)
        {
            try
            {
                if (deleteCity != null)
                {
                    ServerConnect.Delete("delete from city where cityID = " + deleteCity.cityID + ";");
                    return true;
                }
                return false;
            }
            catch (Exception eInsertCity)
            {
                return false;
            }
        }
    }
}
