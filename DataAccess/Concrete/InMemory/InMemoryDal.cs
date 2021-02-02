using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryDal()
        {
            _cars = new List<Car>
            {
            new Car{ Id=1, BrandId=1, ColorId=1, DailyPrice=1050, Description="Aile Arabası",   ModelYear=2000},
            new Car{ Id=2, BrandId=2, ColorId=1, DailyPrice=3000, Description="Arazi Arabası", ModelYear=2010},
            new Car{ Id=3, BrandId=1, ColorId=2, DailyPrice=1000, Description="Tertemiz",       ModelYear=2020},
            new Car{ Id=4, BrandId=3, ColorId=2, DailyPrice=2050, Description="Öğretmenden Satılık", ModelYear=2003},
            };
        }
        public void Add(Car car)
        {
           /*car.Id = _cars.Last().Id + 1; --> LINQ
            _cars.Add(car);*/
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.BrandId == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
