using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager=new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            // GİRİLEN FİYAT ARALIĞINDAKİ DEĞERLERE GÖRE ARAÇLARI LİSTELER
            foreach (var car in carManager.GetByDailyPrice(100, 1000))
            {
                Console.WriteLine($"{car.CarId}\t{colorManager.Get(car.ColorId).ColorName}\t\t{brandManager.Get(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
            // KİRALAMA GÜNÜNÜ KONTROL EDER
            carManager.Add(new Car { BrandId = 3, ColorId = 4, DailyPrice = -1 , ModelYear = 2015, Description = " Dizel" }); 
            // MARKA ADININ KARAKTER UZUNLUĞUNU KONTROL EDER
            brandManager.Add(new Brand { BrandName = "E" });//Marka İsminin Kontolünü Sağlıyor

            // TÜM KİRALANAN ARABALARI LİSTELER
            foreach (var car in carManager.GetByAll())
            {
                Console.WriteLine($"Id= {car.CarId}, BrandId={car.BrandId}, ColorId={car.ColorId}, ModelYear={car.ModelYear}, Description={car.Description}, DailyPrice={car.DailyPrice}");
            }
            // SEÇİLEN CAR_ID'YE GÖRE ID BİLGİLERİNİ LİSTELER
            Car carById = carManager.Get(2);
            Console.WriteLine($"{carById.CarId}\t{colorManager.Get(carById.ColorId).ColorName}\t\t{brandManager.Get(carById.BrandId).BrandName}\t\t{carById.ModelYear}\t\t{carById.DailyPrice}\t\t{carById.Description}");
        }
    }
}
