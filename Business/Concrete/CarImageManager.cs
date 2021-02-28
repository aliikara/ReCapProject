using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete 
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        public IResult AddImage(CarImage carImage, IFormFile formFile)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(formFile);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult DeleteImage(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetByAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImageByCarId(int id)
        {
            //if ((_carImageDal.GetAll(c => c.CarId == id)).Count == 0)
            //{
            //    return new SuccessDataResult<List<CarImage>>(new List<CarImage>
            //                                { new CarImage { ImagePath = "Default.jpeg",
            //                                CarId=id,
            //                                Date=DateTime.Now} });
            //}

            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id));
        }

        public IResult UpdateImage(CarImage carImage , IFormFile formFile)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.CarImageId == carImage.CarImageId).ImagePath, formFile);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.CarId == id));
        }

        //private IResult CheckOfImageLimitExceded(int carId)
        //{
        //    if (_carImageDal.GetAll(c => c.CarId == carId).Count > 4)
        //    {
        //        return new ErrorResult(Messages.ImageLimitError);
        //    }
        //    return new SuccessResult();
        //}
        //private IResult CheckOfCreateNewFolder(int carId)
        //{
        //    string name = Convert.ToInt32(carId).ToString();
        //    bool checkFolder = Directory.Exists(name);
        //    if (!checkFolder)
        //    {
        //        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"images\" + name);
        //    }
        //    return new SuccessResult(Messages.CreatedFolderError);
        //}
        //private string GuidPath(int carId)
        //{
        //    DirectoryInfo directoryInfo = new DirectoryInfo(@"images\ ");
        //    string name = directoryInfo.FullName;
        //    string unique = Guid.NewGuid().ToString();
        //    return  name + carId + @"\" + unique + ".jpeg";
        //}
        private IResult CheckImageLimitExceeded(int carid)
        {
            var carImagecount = _carImageDal.GetAll(p => p.CarId == carid).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.ImageLimitError);
            }

            return new SuccessResult();
        }
        private List<CarImage> CheckIfCarImageNull(int id)
        {
            string path = @"\Images\logo.jpg";
            var result =_carImageDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };
            }
            return _carImageDal.GetAll(p => p.CarId == id);
        }


    }
}
