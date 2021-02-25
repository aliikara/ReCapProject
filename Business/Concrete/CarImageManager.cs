using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
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

        public IResult AddImage(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckOfImageLimitExceded(carImage.CarId),
                                               CheckOfCreateNewFolder(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = GuidPath(carImage.CarId);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult DeleteImage(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetByAllCarImage()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImageByCarId(int id)
        {
            if ((_carImageDal.GetAll(c => c.CarId == id)).Count == 0)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage>
                                            { new CarImage { ImagePath = "Default.jpeg",
                                            CarId=id,
                                            Date=DateTime.Now} });
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id));
        }

        public IResult UpdateImage(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckOfImageLimitExceded(int carId)
        {
            if (_carImageDal.GetAll(c => c.CarId == carId).Count > 4)
            {
                return new ErrorResult(Messages.ImageLimitError);
            }
            return new SuccessResult();
        }
        private IResult CheckOfCreateNewFolder(int carId)
        {
            string name = Convert.ToInt32(carId).ToString();
            bool checkFolder = Directory.Exists(name);
            if (!checkFolder)
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"images\" + name);
            }
            return new SuccessResult(Messages.CreatedFolderError);
        }
        private string GuidPath(int carId)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"images\ ");
            string name = directoryInfo.FullName;
            string unique = Guid.NewGuid().ToString();
            return  name + carId + @"\" + unique + ".jpeg";

        }

    }
}
