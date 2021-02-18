using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
            //return new ErrorResult(Messages.BrandNameInvalid);
            //Console.WriteLine($"\t Marka İsmi İki(2) Karakterden Fazla Olmalıdır.")
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
            //Console.WriteLine("Marka Başarıyla Silindi.");
        }

        public IDataResult<Brand> Get(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id));
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IResult Update(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.BrandUpdated);
                //Console.WriteLine("Marka Başarıyla Güncellendi.");
            }
            else
            {
                return new ErrorResult(Messages.BrandErrorUpdated);
                //Console.WriteLine("Marka İsmi İki(2) Karakterden Fazla Olmalıdır.");
            }

        }
    }
}
