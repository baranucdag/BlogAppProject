using Business.Abstact;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Results;
using DataAccess.Abstract;
using Entities.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class UserOperationClaimService : IUserOperationClaimService
    {
        private IUserOperationClaimDal userOperationClaimDal;
        public UserOperationClaimService(IUserOperationClaimDal userOperationClaimDal)
        {
            this.userOperationClaimDal = userOperationClaimDal;
        }

        [SecuredOperation("admin")]
        public IResult Add(UserOperationClaim userOperationClaim)
        {
            if (userOperationClaimDal.GetAll(x=>x.OperationClaimId==userOperationClaim.OperationClaimId && x.UserId == userOperationClaim.UserId).FirstOrDefault()!=null)
            {
                return new ErrorResult("This user operation claim is already exist!");
            }
            userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult("User operation claim added");
        }

        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult("User Operation Claim deleted.");
        }

        public IDataResult<List<UserOperationClaimDto>> GetAllPaged(int pageNumber,int pageSize)
        {
            return new SuccessDataResult<List<UserOperationClaimDto>>(userOperationClaimDal.GetOperationClaimList().Skip((pageNumber - 1)*pageSize).Take(pageSize).ToList(), Messages.DataListed);
        }
        public IDataResult<List<UserOperationClaimDto>> GetDetailsByUserId(int id)
        {
            return new SuccessDataResult<List<UserOperationClaimDto>>(userOperationClaimDal.GetDetailsById(x => x.UserId == id), Messages.DataListed);
        }

        public IResult Update(UserOperationClaim userOperationClaim)
        {
            userOperationClaimDal.Uptade(userOperationClaim);
            return new SuccessResult();
        }
    }
}
