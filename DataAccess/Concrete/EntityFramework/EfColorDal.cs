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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (RecapContext recapContext=new RecapContext())
            {
                var addedEntity = recapContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                recapContext.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (RecapContext recapContext=new RecapContext())
            {
                var deletedEntity = recapContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                recapContext.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (RecapContext recapContext = new RecapContext())
            {
                return recapContext.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (RecapContext recapContext=new RecapContext())
            {
                return filter == null ? recapContext.Set<Color>().ToList() : recapContext.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color entity)
        {
            using (RecapContext recapContext = new RecapContext())
            {
                var updatedEntity = recapContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                recapContext.SaveChanges();
            }
        }
    }
}
