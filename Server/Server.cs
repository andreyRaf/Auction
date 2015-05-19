using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;
using Server.EF;

namespace Server
{
    // Класс для работы с базой
    public class DbUtils
    {
        //private static DataContext context = new DataContext();

        //public static List<Lot> listLot;
        //public static List<Category> listCategory;
        //public static List<City> listCity;

        //public static List<City> GetCity()
        //{
        //    try
        //    {
        //        listCity = new List<City>();

        //        IQueryable<city> City =
        //            from p in context.cities
        //            select p;

        //        foreach (var itemCity in City)
        //        {
        //            City newCity = new City();
        //            newCity.cityID = itemCity.cityID;
        //            newCity.name = itemCity.name;
        //            listCity.Add(newCity);
        //        }

        //        return listCity;
        //    }
        //    catch (Exception eGetCity)
        //    {
        //        return null;
        //    }
        //}

        //public static bool InsertCity(City newCity)
        //{
        //    try
        //    {
        //        if (newCity != null)
        //        {
        //            city City = new city();
        //            City.cityID = newCity.cityID;
        //            City.name = newCity.name;

        //            context.cities.Add(City);
        //            context.SaveChanges();

        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception eInsertCity)
        //    {
        //        return false;
        //    }
        //}

        //public static bool DeleteCity(City deleteCity)
        //{
        //    try
        //    {
        //        if (deleteCity != null)
        //        {
        //            IQueryable<city> City =
        //                from p in context.cities
        //                where p.cityID == deleteCity.cityID
        //                select p;

        //            foreach (var itemCity in City)
        //            {
        //                context.cities.Remove(itemCity);
        //            }

        //            context.SaveChanges();

        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception eInsertCity)
        //    {
        //        return false;
        //    }
        //}

        //public static List<Category> GetCategory()
        //{
        //    try
        //    {
        //        listCategory = new List<Category>();
                
        //        IQueryable<category> Category =
        //            from p in context.categories
        //            select p;

        //        foreach (var itemCateg in Category)
        //        {
        //            Category newCategory = new Category();
        //            newCategory.categoryID = itemCateg.categoryID;
        //            newCategory.name = itemCateg.name;
        //            listCategory.Add(newCategory);
        //        }

        //        return listCategory;
        //    }
        //    catch (Exception eGetCategory)
        //    {
        //        return null;
        //    }
        //}

        //public static List<Lot> GetLot(int page, int PageSize)
        //{
        //    return GetLot(null, null, page, PageSize);
        //}

        //public static List<Lot> GetLot(int? cityID, int? categoryID, int page, int PageSize)
        //{
        //    try
        //    {
        //        listLot = new List<Lot>();

        //        IQueryable<lot> Lots = 
        //            context.lots
        //            .Where(e => categoryID == null || e.categoryID == categoryID)
        //            .Where(e => cityID == null || e.cityID == cityID)
        //            .OrderBy(p => p.lotID)
        //            .Skip((page - 1) * PageSize)
        //            .Take(PageSize);

        //        foreach (var itemLots in Lots)
        //            {
        //                Lot newLot = new Lot();
        //                newLot.lotID = itemLots.lotID;
        //                newLot.name = itemLots.name;
        //                newLot.description = itemLots.description;
        //                newLot.currentPrice = Convert.ToDouble(itemLots.currentPrice);
        //                newLot.step = itemLots.step;
        //                newLot.blic = itemLots.blic;
        //                newLot.date = itemLots.date;
        //                newLot.image = itemLots.image;
        //                newLot.cityID = itemLots.cityID;
        //                newLot.categoryID = itemLots.categoryID;
        //                listLot.Add(newLot);
        //        }

        //        return listLot;
        //    }
        //    catch (Exception eGetLot)
        //    {
        //        return null;
        //    }
        //}

        //public static int GetCountLot(int? cityID, int? categoryID)
        //{
        //    try
        //    {
        //        IQueryable<lot> Lots =
        //            context.lots
        //            .Where(e => categoryID == null || e.categoryID == categoryID)
        //            .Where(e => cityID == null || e.cityID == cityID);

        //        return Lots.Count();
        //    }
        //    catch (Exception eGetCountLot)
        //    {
        //        return 0;
        //    }
        //}
    }
}
