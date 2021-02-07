using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Abstract
{
   public interface ICarService
    {
        List<Car> GetByAll();
        Car Get(int id);
        List<Car> GetCarsBrandId(int id);
        List<Car> GetCarsColorId(int id);
        List<Car> GetByDailyPrice(decimal min, decimal max);
        List<Car> GetByModelYear(int year);
        List<CarDetailDto> GetCarDetails();

        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        

    }
}
