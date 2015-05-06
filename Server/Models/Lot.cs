using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Lot
    {
        public int lotID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double? currentPrice { get; set; }
        public double? step { get; set; }
        public double? blic { get; set; }
        public DateTime? date { get; set; }
        public string image { get; set; }
        public int? cityID { get; set; }
        public int? categoryID { get; set; }

        public static List<Lot> listLot;

        public static List<Lot> GetLot(int? cityID, int? categoryID, int page, int PageSize)
        {
            try
            {
                listLot = new List<Lot>();

                DataContext context = new DataContext();

                IQueryable<IGrouping<Int32, lot>> Lots =
                    from p in context.lots.OrderBy(x => x.date).Skip((page - 1) * PageSize).Take(PageSize)
                    where p.cityID == cityID & p.categoryID == categoryID
                    group p by p.lotID into grouping
                    select grouping;

                foreach (IGrouping<Int32, lot> grp in Lots)
                {
                    foreach (var itemLots in grp)
                    {
                        Lot newLot = new Lot();
                        newLot.lotID = itemLots.lotID;
                        newLot.name = itemLots.name;
                        newLot.description = itemLots.description;
                        newLot.currentPrice = Convert.ToDouble(itemLots.currentPrice);
                        newLot.step = itemLots.step;
                        newLot.blic = itemLots.blic;
                        newLot.date = itemLots.date;
                        newLot.image = itemLots.image;
                        newLot.cityID = itemLots.cityID;
                        newLot.categoryID = itemLots.categoryID;
                        listLot.Add(newLot);
                    }
                }
                
                return listLot;
            }
            catch (Exception eGetLot)
            {
                return null;
            }
        }

        public static int GetCountLot(int? cityID, int? categoryID)
        {
            try
            {
                DataContext context = new DataContext();

                IQueryable<lot> Lots =
                    from p in context.lots
                    where p.cityID == cityID & p.categoryID == categoryID
                    select p;
                return Lots.Count(); ;
            }
            catch (Exception eGetCountLot)
            {
                return 0;
            }
        }
    }


}
