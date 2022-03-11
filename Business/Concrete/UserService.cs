using Business.Abstact;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService:IUserService
    {
        IUserDal userDal;

        public UserService(IUserDal userDal)
        {
            this.userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return userDal.Get(u => u.Email == email);
        }
    }
}
