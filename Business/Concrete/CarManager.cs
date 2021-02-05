using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{

    public class CarManager : ICarService
    {
        readonly ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car) //Günlük Kiralama Süresi Sıfırdan Fazla ise Aracı Ekler.
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Araba Başarıyla Eklendi.");
            }
            else
            {
                Console.WriteLine("Kiralanacak Gün Sayısı Sıfırdan (0) Büyük Olmalıdır.");
            }
            
        }

        public void Delete(Car car)//Aracı Siler
        {
            _carDal.Delete(car);
            Console.WriteLine("Araba Başarıyla Silindi");
        }

        public Car Get(int id) //Girilen Id Numarası Ait Aracı Gösterir
        {
            return _carDal.Get(c => c.CarId == id);
        }

        public List<Car> GetByAll()//Ekli Olan Araçları Listeleme
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)//Günlük Kiralama Fiyat Aralığına Göre Listeleme
        {
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public List<Car> GetByModelYear(int year) //İstenilen Model Yılına Göre Listeleme
        {
            return _carDal.GetAll(c => c.ModelYear == year);
        }

        public List<Car> GetCarsBrandId(int id) //Markasına Göre Sıralama
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsColorId(int id) //Rengine Göre Sıralama
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Update(Car car) //Kiralanacak Gün Sayısı Sıfırdan Büyük ise Güncelleme İşlemi Gerçekleşecek
        {
            if (car.DailyPrice>0)
            {
                _carDal.Update(car);
                Console.WriteLine("Güncellendi.");
            }
            else
            {
                Console.WriteLine("Günlük Fiyat Kısmını Sıfırdan (0) Büyük Giriniz.");
            }
            
        }
    }
}
