using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].ReturnDate==null || result[i].RentDate>result[i].ReturnDate)
                {
                    return new ErrorResult(Messages.RentAddedError);
                }
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentSuccess);
        }

       /*public IResult DateCheck(int carId,int customerId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.ReturnDateNullError);
            }
            _rentalDal.Add(new Rental
            {
                CarId = carId,
                CustomerId = customerId,
                RentDate = DateTime.Now,
                ReturnDate = null,
            });
            return new SuccessResult(Messages.RentSuccess);
        }*/

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailDto(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetailDtos(x => x.CarId == carId));
        }

        
    }
}
