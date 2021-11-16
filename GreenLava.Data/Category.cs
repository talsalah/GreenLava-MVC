using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLava.Data
{
    public class Category
    {
        public int CategoryId { get; set; }
       // public DrinkCategory drinkCategory { get; set; }
        public string Description { get; set; }
        public List<Drink> Drinks { get; set; }
    }

        //public enum DrinkCategory
        //{
        //   Caffeinated = 1,
        //   Decafe,
        //   WithTea, 
        //   WithFruits,
        //}
    
}

