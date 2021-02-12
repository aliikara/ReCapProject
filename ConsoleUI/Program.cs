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
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());

            //userManager.Add(new User {FirstName = "Ali", LastName = "KARA", Email = "info@alikara.com", Password = "123" });

            //rentalManager.Add(new Rental { CarId = 4, CustomerId = 6, RentDate = DateTime.Today, ReturnDate = DateTime.Today.AddDays(2) });

            /*var result = rentalManager.GetRentalDetailDto(4);
            if (result.Success == true)
            {
                foreach (var rentalDetail in result.Data)
                {
                    Console.WriteLine(rentalDetail.CarName + " " + rentalDetail.CustomerName + " " + rentalDetail.RentDate + " " + rentalDetail.ReturnDate);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }*/
            var result = rentalManager.Add(new Rental { CarId = 4, CustomerId = 6, RentDate = DateTime.Now});
            Console.WriteLine(result.Message);
            
            #region
            /*Console.WriteLine("GİRİLEN FİYAT ARALIĞINDAKİ DEĞERLERE GÖRE ARAÇLARI LİSTELER");
            foreach (var car in carManager.GetByDailyPrice(100, 1000))
            {
                Console.WriteLine($"\t{car.CarId}\t{colorManager.Get(car.ColorId).ColorName}\t\t{brandManager.Get(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
            Console.WriteLine("\n");

            Console.WriteLine("KİRALAMA GÜNÜNÜ KONTROL EDER");
            carManager.Add(new Car {BrandId = 3, ColorId = 4, DailyPrice = -1 , ModelYear = 2015, Description = " Dizel" });
            Console.WriteLine("\n");

            Console.WriteLine("MARKA ADININ KARAKTER UZUNLUĞUNU KONTROL EDER");
            brandManager.Add(new Brand { BrandName = "E" });//Marka İsminin Kontolünü Sağlıyor
            Console.WriteLine("\n");

            Console.WriteLine("TÜM KİRALANAN ARABALARI LİSTELER"); 
            foreach (var car in carManager.GetByAll())
            {
                Console.WriteLine($"\t Id= {car.CarId}, BrandId={car.BrandId}, ColorId={car.ColorId}, ModelYear={car.ModelYear}, Description={car.Description}, DailyPrice={car.DailyPrice}");
            }
            Console.WriteLine("\n");

            Console.WriteLine("SEÇİLEN CAR_ID'YE GÖRE ID BİLGİLERİNİ LİSTELER");
            Car carById = carManager.Get(2);
            Console.WriteLine($"\t {carById.CarId}\t{colorManager.Get(carById.ColorId).ColorName}\t\t{brandManager.Get(carById.BrandId).BrandName}\t\t{carById.ModelYear}\t\t{carById.DailyPrice}\t\t{carById.Description}");
            
            Console.WriteLine("\n");
            Console.WriteLine("CAR , BRAND , COLOR TABLOLARINDAN GELEN BİLGİLERİ YAZDIRMA");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine($"\t{car.BrandName}\t{car.ColorName}\t{car.DailyPrice}");
            }*/
            #endregion
        }
    }
}
