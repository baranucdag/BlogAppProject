using Business.Abstact;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Helpers.PaginationHelper;
using Core.Results;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        IUserDal userDal;

        public UserService(IUserDal userDal)
        {
            this.userDal = userDal;
        }

        public IResult Add(User user)
        {
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

        //get users paged (by using pagination helper)
        public PaginationHelper<User> GetBlogsPaginated(int pageNumber, int pageSize)
        {
            return (PaginationHelper<User>.ToPagedList(userDal.GetAll(), pageNumber, pageSize));
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
