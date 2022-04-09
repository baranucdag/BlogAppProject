using Business.Abstact;
using Business.Constans;
using Core.Entities.Concrete;
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
            //todo:email küçük yada büyük girerse giriş olur mu check et, yoksa uppercase ile kontrol et, I İ problemini halletmeye çalış: örnek:İsmail@gmail.com dönüşümü
            return userDal.Get(x => x.Email == email);
        }
    }
}
