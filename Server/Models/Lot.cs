using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Lot
    {
        public int lotID { get; set; }

        [Required(ErrorMessage = "Введите название лота")]
        public string name { get; set; }
        public string description { get; set; }
        [Required(ErrorMessage = "Введите начальную цену")]
        public double currentPrice { get; set; }
        [Required(ErrorMessage = "Введите шаг")]
        public double step { get; set; }
        [Required(ErrorMessage = "Введите блиц")]
        public double blic { get; set; }
        public DateTime date { get; set; }
        public string image { get; set; }
        [Required(ErrorMessage = "Выберите город")]
        public int cityID { get; set; }
        public int categoryID { get; set; }
    }
}
