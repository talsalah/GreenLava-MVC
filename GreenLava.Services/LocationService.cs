using GreenLava.Data;
using System;
using GreenLava.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLava.Services
{
    public class LocationService
    {
        private readonly Guid _userId;
        public LocationService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateLocation(LocationCreate model)
        {
            var entity =
                new Location()
                {
                    OwnerId = _userId,
                    // Id = _userId,
                    StreetOne = model.StreetOne,
                    StreetTwo = model.StreetTwo,
                    City = model.City,
                    State = model.State,
                    Zipcode = model.Zipcode,

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<LocationListItem> GetLocations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =  // searching in application dbcontext- grapping drinks entities 
                    ctx
                    .Locations //grapping drinks entities(Drink table)
                     .Where(e => e.OwnerId == _userId)
                    .Select(  // select customer address list item 
                        e => new LocationListItem  // create new object-  drink list Item 
                        {

                            LocationID = e.LocationID,
                            StreetOne = e.StreetOne,
                            StreetTwo = e.StreetTwo,
                            City = e.City,
                            State = e.State,
                            Zipcode = e.Zipcode,




                            //  CreatedUtc = e.CreatedUtc
                        }
                        );
                return query.ToArray();
            }


        }

        public LocationDetail GetLocationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationID == id && e.OwnerId == _userId);
                return
                    new LocationDetail
                    {
                        LocationID = entity.LocationID,
                        StreetOne = entity.StreetOne,
                        StreetTwo = entity.StreetTwo,
                        City = entity.City,
                        State = entity.State,
                        //drinkCategory = entity.drinkCategory,
                        Zipcode = entity.Zipcode,
                    };
            }


        }

        public bool UpdateLocation(LocationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationID == model.LocationID && e.OwnerId == _userId);

                entity.LocationID = model.LocationID;
                entity.StreetOne = model.StreetOne;
                //entity.Category.CategoryId = model.CategoryId;
                //entity.Category.CategoryName = model.CategoryName;
                entity.City = model.City;
                entity.State = model.State;
                entity.Zipcode = model.Zipcode;

                return ctx.SaveChanges() == 1;
            }

        }
        public bool DeleteLocation(int locationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Locations
                    .Single(e => e.LocationID == locationId && e.OwnerId == _userId);
                ctx.Locations.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }

    }
}
