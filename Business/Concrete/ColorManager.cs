using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
     public class ColorManager : IColorService
    {
        readonly IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        [SecuredOperation("color.add,admin")]
        [CacheRemoveAspect("IColorService.Get")]
        
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        
        public IDataResult<Color> Get(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id));
        }

        //[CacheAspect]
        [PerformanceAspect(1)]
        public IDataResult<List<Color>> GetAll()
        {
            Thread.Sleep(1000);
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }
        [TransactionScopeAspect]
        public IResult TransactionOperation(Color color)
        {
            _colorDal.Update(color);
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorUpdated);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
