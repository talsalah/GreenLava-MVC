using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLava.Data
{
    public class Drink
    {
       public Guid OwnerId { get; set; }
        [Key]
        public int DrinkId { get; set; }
        public string Name { get; set; }

        public DrinkCategory drinkCategory { get; set; }
        public string ShortDescription { get; set; }

        public string Recipes { get; set; }
        public double AverageCost { get; set; }
        public virtual string ImageUrl { get; set; }

        public bool IsPreferredDrinks { get; set; }

        [ForeignKey(nameof(Restaurant))]
        public int? RestaurantId { get; set; }// Foreign Key for category Model

        public virtual Restaurant Restaurant { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }

    public enum DrinkCategory
    {
        Caffeinated = 1,
        Decafe,
        WithTea,
        WithFruits,
    }
}
