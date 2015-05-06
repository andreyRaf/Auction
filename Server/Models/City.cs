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
                listCity = new List<City>();

                DataContext context = new DataContext();

                IQueryable<city> City =
                    from p in context.cities
                    select p;

                foreach (var itemCity in City)
                {
                    City newCity = new City();
                    newCity.cityID = itemCity.cityID;
                    newCity.name = itemCity.name;
                    listCity.Add(newCity);
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
                    DataContext context = new DataContext();

                    city City = new city();
                    City.cityID = newCity.cityID;
                    City.name = newCity.name;

                    context.cities.Add(City);
                    context.SaveChanges();

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
                    DataContext context = new DataContext();

                    IQueryable<city> City =
                        from p in context.cities
                        where p.cityID == deleteCity.cityID
                        select p;

                    foreach (var itemCity in City)
                    {
                        context.cities.Remove(itemCity);
                    }

                    context.SaveChanges();

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
