using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (RecapContext recapContext=new RecapContext())
            {
                var addedEntity = recapContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                recapContext.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (RecapContext recapContext=new RecapContext())
            {
                var deletedEntity = recapContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                recapContext.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RecapContext recapContext=new RecapContext())
            {
                return recapContext.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RecapContext recapContext=new RecapContext())
            {
                return filter == null ? recapContext.Set<Car>().ToList() : recapContext.Set<Car>().Where(filter).ToList(); 
            }
        }

        public void Update(Car entity)
        {
            using (RecapContext recapContext=new RecapContext())
            {
                var updatedEntity = recapContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                recapContext.SaveChanges();
            }
        }
    }
}
