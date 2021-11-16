using GreenLava.Data;
using GreenLava.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLava.Services
{
    public class PersonService
    {
        private readonly Guid _userId;
        public PersonService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePerson(PersonCreate model)
        {
            var entity =
                new Person()
                {
                    UserID = _userId,
                    Name = model.Name,
                    Email = model.Email,
                    Hobby = model.Hobby,
                    DateJoined = model.DateJoined
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Persons.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PersonListItem> GetPersons()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Persons
                    .Where(e => e.UserID == _userId)
                    .Select(
                        e =>
                        new PersonListItem
                        {
                            PersonId = e.PersonId,
                            Name = e.Name,
                            Email = e.Email,
                            Hobby = e.Hobby,
                            DateJoined = e.DateJoined,
                        }
                  );
                return query.ToArray();
            }
        }
      /*  public PersonDetail GetPersonById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Persons
                        .Single(e => e.PersonId == id && e.UserID == _userId);
                return
                    new PersonDetail
                    {
                        PersonId = entity.PersonId,
                        Name = entity.Name,
                        Email = entity.Email,
                        DateJoined = entity.DateJoined,
                        Role = entity.Hobby
                    };
            }
        }
        public bool UpdatePerson(PersonEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Persons
                        .Single(e => e.PersonId == model.PersonId && e.UserID == _userId);
                entity.PersonId = model.PersonId;
                entity.Name = model.Name;
                entity.Email = model.Email;
                entity.Hobby = model.Role;
                entity.DateJoined = model.DateJoined;
                entity.UserID = _userId;

                return ctx.SaveChanges() == 1;

            }
        }*/
        public bool DeletePerson(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Persons
                        .Single(e => e.PersonId == id && e.UserID == _userId);
                ctx.Persons.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }

}
