using GreenLava.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GreenLava.Models
{
    public class DrinkCreate
    {
        public int LocationID { get; set; }
        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string Recipes { get; set; }
        public double AverageCost { get; set; }
        public virtual string ImageUrl { get; set; }

        public bool IsPreferredDrinks { get; set; }
        public DrinkCategory drinkCategory { get; set; }
        public int? RestaurantId { get; set; }
    }
}
