using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLava.Models
{
   public class RestaurantDetail
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string DrinkName { get; set; }
        public string ShortDescription { get; set; }

        public double Price { get; set; }
    }
}
