using GreenLava.Data;
using GreenLava.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLava.Services
{
    public class DrinkService
    {
        private readonly Guid _userId;
        public DrinkService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateDrink(DrinkCreate model)
        {
            var entity =
                new Drink()
                {
                    OwnerId = _userId,
                    // DrinkId = _userId,
                    Name = model.Name,
                    Recipes = model.Recipes,
                    ShortDescription = model.ShortDescription,
                    AverageCost = model.AverageCost,
                    IsPreferredDrinks = model.IsPreferredDrinks,
                    drinkCategory = model.drinkCategory,
                    CreatedUtc = DateTimeOffset.Now,
                    RestaurantId = model.RestaurantId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Drinks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<DrinkListItem> GetDrinks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =  // searching in application dbcontext- grapping drinks entities 
                    ctx
                    .Drinks //grapping drinks entities(Drink table)
                     .Where(e => e.OwnerId == _userId)
                    .Select(  // select customer address list item 
                        e => new DrinkListItem  // create new object-  drink list Item 
                        {
                            DrinkId = e.DrinkId,
                            Name = e.Name,
                            ShortDescription = e.ShortDescription,
                            Recipes = e.Recipes,
                            AverageCost = e.AverageCost,
                            IsPreferredDrinks = e.IsPreferredDrinks,
                            drinkCategory = e.drinkCategory,



                            //  CreatedUtc = e.CreatedUtc
                        }
                        );
                return query.ToArray();
            }


        }
        public DrinkDetail GetDrinkById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Drinks
                        .Single(e => e.DrinkId == id && e.OwnerId == _userId);
                return
                    new DrinkDetail
                    {
                        DrinkId = entity.DrinkId,
                        Name = entity.Name,
                        ShortDescription = entity.ShortDescription,
                        Recipes = entity.Recipes,
                        IsPreferredDrinks = entity.IsPreferredDrinks,
                        //drinkCategory = entity.drinkCategory,
                        AverageCost = entity.AverageCost,
                    };
            }

        }
        public bool UpdateDrink(DrinkEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Drinks
                        .Single(e => e.DrinkId == model.DrinkId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.ShortDescription = model.ShortDescription;
                //entity.Category.CategoryId = model.CategoryId;
                //entity.Category.CategoryName = model.CategoryName;
                entity.AverageCost = model.AverageCost;
                entity.Recipes = model.Recipes;
                entity.IsPreferredDrinks = model.IsPreferredDrinks;

                return ctx.SaveChanges() == 1;
            }

        }
        public bool DeleteDrink(int drinkId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity=
                    ctx
                    .Drinks
                    .Single(e=> e.DrinkId == drinkId && e.OwnerId == _userId);
                ctx.Drinks.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }



    }
}