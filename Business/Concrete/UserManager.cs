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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User userId)
        {
            _userDal.Add(userId);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User userId)
        {
            _userDal.Delete(userId);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
           return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IResult Update(User userId)
        {
            _userDal.Update(userId);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
