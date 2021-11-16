using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLava.Data
{
    public class Restaurant
    {
        public Guid OwnerId { get; set; }
        [Key]
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        // public string DrinkName { get; set; }
        //   public DrinkCategory drinkCategory { get; set; }
        public string ShortDescription { get; set; }

        // public string Recipes { get; set; }
        public double Price { get; set; }

        public virtual List<Drink> Drinks { get; set; }

        [ForeignKey(nameof(Location))]
        public int? LocationID { get; set; }// Foreign Key for category Model

        public virtual Location Location { get; set; }
    }
}
