using GreenLava.Data;
using GreenLava.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLava.Services
{
    public class RestaurantService
    {
        private readonly Guid _userId;
        public RestaurantService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRestaurant(RestaurantCreate model)
        {
            var entity =
                new Restaurant()
                {
                    OwnerId = _userId,
                    // DrinkId = _userId,
                    // DrinkName = model.DrinkName,
                    RestaurantName = model.RestaurantName,
                    ShortDescription = model.ShortDescription,
                    Price = model.Price,

                    // CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Restaurants.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RestaurantListItem> GetRestaurants()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Restaurants
                     .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new RestaurantListItem
                        {
                            RestaurantId = e.RestaurantId,
                            RestaurantName = e.RestaurantName,
                            ShortDescription = e.ShortDescription,
                            Price = e.Price,
                            //DrinkName = e.DrinkName,
                            DrinkName = e.Drinks.Select(d => d.Name).ToList()


                            //  CreatedUtc = e.CreatedUtc
                        }
                        );
                return query.ToArray();
            }
        }
        public RestaurantDetail GetRestaurantById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Restaurants
                        .Single(e => e.RestaurantId == id && e.OwnerId == _userId);
                return
                    new RestaurantDetail
                    {
                        RestaurantId = entity.RestaurantId,
                        RestaurantName = entity.RestaurantName,
                        ShortDescription = entity.ShortDescription,
                        Price = entity.Price,
                    };
            }
        }
        public bool UpdateRestaurant(RestaurantEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Restaurants
                        .Single(e => e.RestaurantId == model.RestaurantId && e.OwnerId == _userId);

                entity.RestaurantName = model.RestaurantName;
                entity.ShortDescription = model.ShortDescription;
                //entity.Category.CategoryId = model.CategoryId;
                //entity.Category.CategoryName = model.CategoryName;
                entity.ShortDescription = model.ShortDescription;
                entity.Price = model.Price;
               return ctx.SaveChanges() == 1;
            }

        }
        public bool DeleteRestaurant(int RestaurantId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Restaurants
                    .Single(e => e.RestaurantId == RestaurantId && e.OwnerId == _userId);
                ctx.Restaurants.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }

    }
}
