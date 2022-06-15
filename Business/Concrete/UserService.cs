﻿using Business.Abstact;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Results;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private IUserDal userDal;
        private IBlogService blogService;

        public UserService(IUserDal userDal,IBlogService blogService)
        {
            this.userDal = userDal;
            this.blogService = blogService;
        }

        public IResult Add(User user)
        {
            if (blogService.GetAll().Data.FirstOrDefault(x => x.UserId == user.Id) != null)
            {
                return new ErrorResult("There are some blog relelated this user");
            }
            userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(userDal.GetAll(), Messages.DataListed);
        }

        //get users paged (by using Take() and Skip() methods)
        public IDataResult<List<User>> GetBlogsPaginated(int pageNumber, int pageSize)
        {
            return new SuccessDataResult<List<User>>(userDal.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList());
        }
        public IDataResult<User> GetByUserId(int id)
        {
            return new SuccessDataResult<User>(userDal.Get(x => x.Id == id));
        }

        public IResult Update(User user)
        {
            userDal.Uptade(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return userDal.GetClaims(user);
        }
        public User GetByMail(string email)
        {
            return userDal.Get(x => x.Email == email);
        }
    }
}
