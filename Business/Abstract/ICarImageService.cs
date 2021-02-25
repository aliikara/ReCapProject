using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult AddImage(CarImage carImage);
        IResult UpdateImage(CarImage carImage);
        IResult DeleteImage(CarImage carImage);
        IDataResult<List<CarImage>> GetImageByCarId(int id);
        IDataResult<List<CarImage>> GetByAllCarImage();

    }
}
