using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult AddImage(CarImage carImage, IFormFile formFile);
        IResult UpdateImage(CarImage carImage , IFormFile formFile);
        IResult DeleteImage(CarImage carImage);
        IDataResult<List<CarImage>> GetImageByCarId(int id);
        IDataResult<List<CarImage>> GetByAll();
        IDataResult<CarImage> Get(int id);

    }
}
