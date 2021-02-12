using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Abstract
{
   public interface ICarService
    {
        IDataResult<List<Car>> GetByAll();
        IDataResult<Car> Get(int id);
        IDataResult<List<Car>> GetCarsBrandId(int id);
        IDataResult<List<Car>> GetCarsColorId(int id);
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        IDataResult<List<Car>> GetByModelYear(int year);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        

    }
}
