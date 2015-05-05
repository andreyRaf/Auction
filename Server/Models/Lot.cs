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
        public double currentPrice { get; set; }
        public double step { get; set; }
        public double blic { get; set; }
        public DateTime date { get; set; }
        public string image { get; set; }
        public int cityID { get; set; }
        public int categoryID { get; set; }

        public static List<Lot> listLot;

        public static List<Lot> GetLot(int? cityID, int? categoryID, int page, int PageSize)
        {
            try
            {
                listLot = new List<Lot>();

                string sqlString =
                    String.Format(
                    " SELECT "+
                    " lotID, name, description, currentPrice, step, blic, date, image, cityID, categoryID " +
                    " FROM lot "+
                    (cityID != null || categoryID != null ? " WHERE " : "" )+
                    (cityID != null ? " cityID = " + cityID : "")+
                    (cityID != null & categoryID != null ? " and categoryID = " + categoryID : ((cityID == null & categoryID != null ? " categoryID = " + categoryID : "" ))) +
                    " order by lotID "+
                    " OFFSET {0} ROWS "+
                    " FETCH NEXT {1} ROWS ONLY;", (page - 1) * PageSize, PageSize);
                DataTable tableLot = ServerConnect.Select(sqlString);
                if (tableLot != null)
                {
                    foreach (DataRow row in tableLot.Rows)
                    {
                        Lot newLot = new Lot();
                        if (row["lotID"] != DBNull.Value) newLot.lotID = Convert.ToInt32(row["lotID"]);
                        if (row["name"] != DBNull.Value) newLot.name = row["name"].ToString();
                        if (row["description"] != DBNull.Value) newLot.description = row["description"].ToString();
                        if (row["currentPrice"] != DBNull.Value) newLot.currentPrice = Convert.ToDouble(row["currentPrice"]);
                        if (row["step"] != DBNull.Value) newLot.step = Convert.ToDouble(row["step"]);
                        if (row["blic"] != DBNull.Value) newLot.blic = Convert.ToDouble(row["blic"]);
                        if (row["date"] != DBNull.Value) newLot.date = Convert.ToDateTime(row["date"]);
                        if (row["image"] != DBNull.Value) newLot.image = row["image"].ToString();
                        if (row["cityID"] != DBNull.Value) newLot.cityID = Convert.ToInt32(row["cityID"]);
                        if (row["categoryID"] != DBNull.Value) newLot.categoryID = Convert.ToInt32(row["categoryID"]);
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
                string sqlString =
                    "select count(distinct lotId) from lot "+
                    (cityID != null || categoryID != null ? " WHERE " : "") +
                    (cityID != null ? " cityID = " + cityID : "") +
                    (cityID != null & categoryID != null ? " and categoryID = " + categoryID : ((cityID == null & categoryID != null ? " categoryID = " + categoryID : "")));
                return ServerConnect.Count(sqlString);
            }
            catch (Exception eGetCountLot)
            {
                return 0;
            }
        }
    }


}
