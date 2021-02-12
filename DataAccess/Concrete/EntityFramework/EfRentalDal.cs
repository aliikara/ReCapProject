using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RecapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailDtos(Expression<Func<Rental, bool>> filter = null)
        {
           using (RecapContext recapContext=new RecapContext())
            {
                var result = from rental in filter is null ? recapContext.Rentals : recapContext.Rentals.Where(filter)
                             join car in recapContext.Cars
                             on rental.CarId equals car.CarId
                             join customer in recapContext.Customers
                             on rental.CustomerId equals customer.CustomerId
                             join user in recapContext.Users
                             on customer.UserId equals user.UserId
                             select new RentalDetailDto
                             {
                                 RentalDetailId = rental.RentalId,
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 CustomerName = customer.CompanyName,
                                 UserName = user.FirstName + " " + user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
