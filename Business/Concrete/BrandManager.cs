using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
         IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        
        public void Add(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _brandDal.Add(brand);
                Console.WriteLine($"\t Marka Başarıyla Eklendi.");
            }
            else
            {
                Console.WriteLine($"\t Marka İsmi İki(2) Karakterden Fazla Olmalıdır.");
            }
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("Marka Başarıyla Silindi.");
        }

        public Brand Get(int id)
        {
            return _brandDal.Get(b => b.BrandId == id);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public void Update(Brand brand)
        {
            if (brand.BrandName.Length >=2)
            {
                _brandDal.Update(brand);
                Console.WriteLine("Marka Başarıyla Güncellendi.");
            }
            else
            {
                Console.WriteLine("Marka İsmi İki(2) Karakterden Fazla Olmalıdır.");
            }
            
        }
    }
}
