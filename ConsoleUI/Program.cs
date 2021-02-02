using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryDal());
            foreach (var car in carManager.GetByAll())
            {
                Console.WriteLine($"Id= {car.Id}, BrandId={car.BrandId}, ColorId={car.ColorId}, ModelYear={car.ModelYear}, Description={car.Description}, DailyPrice={car.DailyPrice}");
            }
            Console.WriteLine("Marka ID'si Giriniz : ");
            int BrandId = int.Parse(Console.ReadLine());
            Console.WriteLine($"BrandId'si={BrandId} Olan Arabalar");
            foreach (var car in carManager.GetById(BrandId))
            {
                Console.WriteLine($"{car.Id}\t{car.BrandId}\t\t{car.ColorId}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
        }
    }
}
